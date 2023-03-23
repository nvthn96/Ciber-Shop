namespace WebApp.Extension.Pagging
{
    public class ViewPagging<T> where T : class
    {
        public string SearchColumn { get; set; }
        public string SearchText { get; set; }
        public string SortColumn { get; set; }
        public string SortDir { get; set; }
        public IEnumerable<T> Data { get; set; }
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
        public int Total { get; set; } = 0;
        
    }
}
