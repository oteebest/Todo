namespace Todo.Application.Contracts.Model
{
    public class PagedModel<T>
    {
        public long PageSize { get; }
        public long PageNumber { get; }
        public long TotalSize { get; }
        public T[] Items { get; set; }

        public PagedModel(T[] items, long totalSize, long pageNumber, long pageSize)
        {
            if (pageNumber < 1) pageNumber = 1;
            TotalSize = totalSize;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Items = items;
        }
    }
}
