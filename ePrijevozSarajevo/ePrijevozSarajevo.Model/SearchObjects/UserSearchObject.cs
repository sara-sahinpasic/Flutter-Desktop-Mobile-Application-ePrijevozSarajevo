namespace ePrijevozSarajevo.Model.SearchObjects
{
    public class UserSearchObject : BaseSearchObject
    {
        public string? FirstNameGTE { get; set; }
        public string? LastNameGTE { get; set; }
        /*//pagination:
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        */
    }
}
