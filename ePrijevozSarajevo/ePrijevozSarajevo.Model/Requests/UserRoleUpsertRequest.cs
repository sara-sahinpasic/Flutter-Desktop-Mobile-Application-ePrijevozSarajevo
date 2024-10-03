namespace ePrijevozSarajevo.Model.Requests
{
    public class UserRoleUpsertRequest
    {
        //public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime ModificationDate { get; set; } = DateTime.Now;
        //public virtual Role Role { get; set; } = null!;

    }
}
