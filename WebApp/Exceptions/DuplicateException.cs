namespace WebApp.Exceptions
{
    public class OrderDuplicateException : Exception
    {
        public OrderDuplicateException(string? name)
            : base("Item " + name + " has already exists.")
        { }
    }
}
