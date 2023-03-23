namespace WebApp.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(string? name)
            : base("Item " + name + " is not found.")
        { }
    }
}
