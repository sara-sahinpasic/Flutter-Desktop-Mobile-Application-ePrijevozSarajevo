namespace ePrijevozSarajevo.Model
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime ModificationDate { get; set; }
        public virtual Role Role { get; set; } = null!;
    }
}
