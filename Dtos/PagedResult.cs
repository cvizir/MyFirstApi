namespace MyFirstApi.Dtos;

public class PagedResult<T>
{
    public int TotalCount { get; set; }   // 符合條件的總筆數
    public int Page { get; set; }         // 目前頁碼
    public int PageSize { get; set; }     // 每頁筆數
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize); // 總頁數
    public IEnumerable<T> Items { get; set; } = new List<T>(); // 當頁資料清單
}