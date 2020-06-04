namespace papeletavirtualapp.Response
{
    public class ResultResponse<T>
    {
        public T Data { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; } 
    }
}