namespace LubySoftware.Domain.Models
{
    public class ReturnModel<T>
    {
        public bool? IsError { get; set; }
        public string MessageError { get; set; }
        public string DetailsError { get; set; }
        public T Object { get; set; }
    }
}
