Console.WriteLine("Hello, World!");

public void ProcessOrder(Order order)
{
    if (order == null)
        throw new ArgumentNullException("Order is null");
    Save(order);

}