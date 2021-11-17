using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.Features.User.ViewModel;
using MLA.ClientOrder.Application.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MLA.OrderManagement.Infrustructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public IdentityService(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
            IAuthorizationService authorizationService,
            SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _authorizationService = authorizationService;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == userId);

            return user.UserName;
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string email, string password, string role)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = email
            };

            IdentityRole iRole = _roleManager.Roles.SingleOrDefault(x => x.Name == role);
            if (_userManager.Users.All(u => u.UserName != userName && u.Email != email))
            {
                var result = await _userManager.CreateAsync(user, password);
                if(!result.Succeeded)
                {
                    throw new IdentityException(result.Errors.ToList());
                }
                await _userManager.AddToRolesAsync(user, new[] { iRole.Name });
                
                return (result.ToApplicationResult(), user.Id);
            }
            else
            {
                throw new Exception("User name Or Email already exists");
            }
        }

        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

            var result = await _authorizationService.AuthorizeAsync(principal, policyName);

            return result.Succeeded;
        }

        public async Task<UserViewModel> AuthorizeUserAsync(string userId, string password)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userId);

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if(result.Succeeded)
            {
                //var roles = await _roleManager.Roles.
                UserViewModel userView = new UserViewModel()
                {
                    Id = user.Id,
                    UserName = userId,
                    Email = user.Email,
                    Roles = new System.Collections.Generic.List<string>() { "Administrator" }
                };
                userView.token = _tokenService.BuildToken(userView);
                return userView;
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return await DeleteUserAsync(user);
            }

            return Result.Success();
        }

        public async Task<Result> DeleteUserAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        public async Task<bool> IsRoleExistAsync(string role)
        {
            return await _roleManager.RoleExistsAsync(role);
        }

        public async Task<bool> IsEmailOrUserNameValid(string email, string userName)
        {
            if (await _userManager.Users.AllAsync(u => u.UserName != userName && u.Email != email))
            {
                return true;
            }
            return false;
        }

    }
}
