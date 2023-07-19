
namespace Layer.Entity.RequestFeatures
{
    public class FeatureParams
    {
        const int maxPageSize = 50;// bir sayfada en fazla 50 ürün olabilir

        private int _pageSize = 5; // bir sayfada en az 5 ürün olabilir
        public int PageNumber { get; set; } = 1; // default olarak 1. sayfadan başlar
        public int PageSize
        {
            // gerekli sayfa bilgisi girilmediğinde default sayfa bilgisi atar
            get { return _pageSize; }
            set { _pageSize = value < maxPageSize ? value : maxPageSize; } 
        }

        public String? SearchTerm { get; set; }
    }
}
