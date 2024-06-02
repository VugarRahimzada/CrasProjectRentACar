using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete.TableModels.Membership
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }
    }
}
