namespace MiniUdemyWebAPI.Helpers
{
    // A helper class to represent the result of a paged query.
    public class PagedResult<T>
    {
        // The items for the current page, typically a collection of entities like students, courses, etc.
        public IEnumerable<T> Items { get; set; }

        // The total number of items in the entire dataset (not just the items for the current page).
        // This helps in calculating pagination metadata like total pages, next page availability, etc.
        public int totalItems { get; set; }

        // The current page number. This helps the consumer understand which page of data they are on.
        public   int  PageNumber { get; set; }

        // The number of items to be displayed per page. It can be set dynamically (e.g., 10, 20, 50 items per page).
        public int PageSize { get; set; }

        //Total page can possible
        public int TotalPagesCount { get; set; }


        // Constructor to initialize a PagedResult object with items, total count, page number, and page size.
        public PagedResult(IEnumerable<T> items, int totalCount, int pageNumber, int pageSize)
        {
            Items = items;            // Set the list of items (usually fetched from a database)
            totalItems = totalCount;  // Set the total count of items in the dataset (useful for calculating pagination)
            PageNumber = pageNumber;  // Set the current page number
            PageSize = pageSize;      // Set how many items should be shown on each 
            TotalPagesCount = (int)Math.Ceiling(totalCount / (double)pageSize);

        }


        public bool HasNextPage()
        {
            return PageNumber < TotalPagesCount;
        }

        public bool HasPreviousPage()
        {
            return PageNumber > 1;
        }

    }
}