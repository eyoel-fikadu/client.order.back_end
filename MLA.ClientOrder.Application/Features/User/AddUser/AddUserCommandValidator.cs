using FluentValidation;
using MLA.ClientOrder.Application.Common.Abstraction;

namespace MLA.ClientOrder.Application.Features.User.AddUser
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator(IIdentityService identityService)
        {
            RuleFor(x => x.Role)
                .MustAsync((x,y) => identityService.IsRoleExistAsync(x))
                .WithMessage(x => $"Role '{x.Role}' doesnt exist");

            RuleFor(x => new { UserName = x.UserName , Email = x.Email})
                .MustAsync((x, y) => identityService.IsEmailOrUserNameValid(x.UserName, x.Email))
                .WithMessage(x => $"User name Or Email already exists");
        }
    }
}
