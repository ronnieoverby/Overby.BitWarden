namespace BitWardenClient;

public class Response
{
    public bool success { get; set; }
}

public class Response<T> : Response
{
    public T data { get; set; }

}