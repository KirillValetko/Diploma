namespace BookingWebApp.Logic
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int PagesAmount { get; set; }
        public PaginatedList(List<T> items, int itemsAmount, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PagesAmount = (int)Math.Ceiling(itemsAmount / (double)pageSize);
            this.AddRange(items);
        }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < PagesAmount;
        public static PaginatedList<T> Create(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
