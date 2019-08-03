namespace Patrimonio.Business.Dto
{
    public class ResponseBag<T>
    {
        public bool Ok { get; set; }
        public string Message { get; set; }
        public T ObjectResponse { get; set; }
    }
}