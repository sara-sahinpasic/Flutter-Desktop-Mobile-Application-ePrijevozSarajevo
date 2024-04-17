namespace ePrijevozSarajevo.Model.SearchObjects
{
    public class UserSearchObject : BaseSearchObject
    {
        public string? FirstNameGTE { get; set; }
        public string? LastNameGTE { get; set; }
        public bool? IsRoleIncluded { get; set; }
        public bool? IsUserStatusIncluded { get; set; }
    }
}
