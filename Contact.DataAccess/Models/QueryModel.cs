namespace Contact.DataAccess.Models
{
    public class QueryModel
    {
        public string SearchItem { get; set; }

        public bool IsSortAscending { get; set; }

        public string SortBy { get; set; }
    }
}
