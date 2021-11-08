using System.Collections.Generic;

namespace MLA.ClientOrder.Application.Features.User.ViewModel
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
        public string Id { get; set; }
        public string UserProfileId { get; set; }
        public int ProfileId { get; set; }
        public string token { get; set; }
    }
}
