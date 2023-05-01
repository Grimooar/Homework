namespace ConsoleApp1.models;

public class SalesInvoice
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string DocumentNumber { get; set; }
    public List<Element> Elements { get; set; }
    public Customer Customer { get; set; }
}