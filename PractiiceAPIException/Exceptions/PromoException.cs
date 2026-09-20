using PractiiceAPIException.Model;

namespace PractiiceAPIException.Exceptions;

public class PromoException : Exception
{
    public Promo? Promo { get; }
    public User? User { get; }
    public Basket? Basket { get; }

    public PromoException() : base("Неизвестная ошибка применения промокода")
    {
    }

    public PromoException(
        Promo promo, 
        User user, 
        Basket basket, 
        string message) : base(message)
    {
        Promo = promo;
        User = user;
        Basket = basket;
    }

    public PromoException(
        Promo promo,
        User user,
        Basket basket, 
        string message, 
        Exception inner) : base(message)
    {
        Promo = promo;
        User = user;
        Basket = basket;

    }


}
