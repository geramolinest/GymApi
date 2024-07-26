namespace GymApi;

public class BaseReponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string StatusText { get; set; }
    public object Data { get; set; }
}
