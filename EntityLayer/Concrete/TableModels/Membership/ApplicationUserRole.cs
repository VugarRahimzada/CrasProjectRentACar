using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete.TableModels.Membership
{
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public string Email { get; set; }
        public string Role {  get; set; }
    }
}
