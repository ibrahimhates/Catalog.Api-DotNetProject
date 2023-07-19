
namespace Layer.Entity.RequestFeatures
{
    public class PaginationMetaData
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPrevios => CurrentPage > 1;
        public bool HasPage => CurrentPage < TotalPage;
    }
}
