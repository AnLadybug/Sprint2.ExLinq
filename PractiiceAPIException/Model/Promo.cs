namespace PractiiceAPIException.Model;

public class Promo
{
    public string Name { get; set; }
    public bool IsEnabled { get; set; }
    public DateTime? Duration { get; set; }
    public HashSet<User> UseUsers = new HashSet<User>();
    public decimal MinimumBasketPrice { get; set; }
}
