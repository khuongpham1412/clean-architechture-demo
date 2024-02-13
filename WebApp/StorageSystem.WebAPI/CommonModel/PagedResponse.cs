namespace StorageSystem.WebAPI.CommonModel
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            TotalRecords = totalRecords;
            TotalPages = (int)Math.Ceiling((double)TotalRecords / PageSize);
            Message = null;
            Succeeded = true;
            Errors = null;
        }

        public PagedResponse(string message, List<string> error)
        {
            Message = message;
            Errors = error ?? null;
        }

        public PagedResponse(T data, string message, List<string> error)
        {
            Data = data;
            Message = message;
            Errors = error ?? null;
        }
    }
}
