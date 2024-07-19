namespace MovieFinder.Models.Forms
{
    public class UserRoleForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
