namespace Infrastructure.Common.Extensions
{
    public class PaginatedList<TEntity>
    {
        public int PageCurrent { set; get; }
        public int PageCount { set; get; }
        public string? SearchKeyword { set; get; } = string.Empty;
        public ICollection<TEntity>? List { set; get; } 
    }
}
