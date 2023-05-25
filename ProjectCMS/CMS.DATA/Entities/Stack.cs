namespace CMS.DATA.Entities
{
    public class Stack : BaseEntity
    {
        public string? StackName { get; set; }
        public List<UserStack> User { get; set; }
    }
}