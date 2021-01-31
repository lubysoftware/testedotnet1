namespace ApiLuby.Infrastructure.Data.Repositories
{
    public class QueryResult<T>
    {
        public bool Succeeded { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
    }
}