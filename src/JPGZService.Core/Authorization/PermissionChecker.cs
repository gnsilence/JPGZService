using Abp.Authorization;
using JPGZService.Authorization.Roles;
using JPGZService.Authorization.Users;

namespace JPGZService.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
