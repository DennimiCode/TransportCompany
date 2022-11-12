namespace TransportCompany.Models;

public class Order
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string SendAddress { get; set; }
    public string DeliveryAddress { get; set; }
    public string? CommentMessage { get; set; }
}
