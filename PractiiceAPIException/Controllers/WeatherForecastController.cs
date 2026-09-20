using Microsoft.AspNetCore.Mvc;
using PractiiceAPIException.Model;
using PractiiceAPIException.Services;

namespace PractiiceAPIException.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<OrderService> _logger;

        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public async Task CreateOrderAsync(Order order, User user)
        {
            try
            {
                await OrderService.ChargeAsync(order.CardId, order.TotalAmount);
                await orderRepository.SaveAsync(order);
            }
            catch (Exception ex)
            {
                var logger = 
                Console.WriteLine(
                    $"Ошибка создания заказа {order.Id} для пользователя {user.Id}: {ex.Message}");

                throw ex;
            }
        }

        public async Task CreateOrderAsync(Order order, User user)
        {
            using (_logger.BeginScope(new
            {
                OrderId = order.Id,
                UserId = user.Id
            }))
            {
                try
                {
                    await _paymentService.ChargeAsync(order.CardId, order.TotalAmount);
                    await _orderRepository.SaveAsync(order);
                }
                catch (PaymentException ex)
                {
                    _logger.LogError(
                        ex,
                        "Ошибка проведения оплаты. CardId={CardId}",
                        ex.Order.CardId);

                    throw;
                }
                catch (Exception ex)
                {
                    {
                        _logger.LogError(
                            ex,
                            "Неизвестная ошибка создания заказа");

                        throw;
                    }
                }
            }
        }
}
