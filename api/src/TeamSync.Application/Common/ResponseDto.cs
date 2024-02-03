namespace TeamSync.Application.Common;

/// <summary>
/// Defines the response of type <seealso cref="T"/>
/// </summary>
/// <typeparam name="T"></typeparam>
public class ResponseDto<T> where T : class
{
    public T Data { get; set; } = null!;
}