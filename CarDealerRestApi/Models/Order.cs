namespace CarDealershipRestApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }
}
