namespace MovieFinder.Models.Forms
{
    public class UserRolesForm
    {
        public UserRolesForm() 
        {
            UserRoles = new List<UserRoleForm>();
        }
        public List<UserRoleForm> UserRoles { get; set; }
    }
}
