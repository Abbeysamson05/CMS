namespace CMS.MVC.ViewModels
{
    public class PermittedUser
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Id { get; set; }
    }
    public class InviteModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StackId { get; set; }
        public string SquadNumber { get; set; }
        public string UserType { get; set; }

    }
    public class PermissionViewModel
    {
        public List<PermittedUser> PermittedUsers { get; set; }
        public InviteModel InviteUser { get; set; }
    }
}
