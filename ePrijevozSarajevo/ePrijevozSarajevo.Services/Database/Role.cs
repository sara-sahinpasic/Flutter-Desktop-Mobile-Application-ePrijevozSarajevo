namespace ePrijevozSarajevo.Services.Database
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; } = null!;
        //
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
