using ConsoleApp1.context;
using ConsoleApp1.models;
using ConsoleApp1.Repository;

// Create an instance of MyDbContext
var dbContext = new MyDbContext();

// Create an instance of SalesInvoiceRepository and pass the MyDbContext instance to its constructor
var salesInvoiceRepository = new SalesInvoiceRepository(dbContext);

// You can now use the salesInvoiceRepository to save or retrieve data from the database
var salesInvoice = new SalesInvoice
{
    CreatedDate = DateTime.UtcNow,
    DocumentNumber = "INV0001",
    Customer = new Customer
    {
        Name = "John Smith",
        Country = "US",
        IsCompany = false
    },
    Elements = new List<Element>
    {
        new Element
        {
            Name = "Item 1",
            Quantity = 2,
            Price = 10.00m,
            VatRate = 0.20m
        },
        new Element
        {
            Name = "Item 2",
            Quantity = 1,
            Price = 5.00m,
            VatRate = 0.20m
        }
    }
};

salesInvoiceRepository.Save(salesInvoice);

var allSalesInvoices = salesInvoiceRepository.GetAll();
foreach (var si in allSalesInvoices)
{
    Console.WriteLine($"Sales Invoice {si.DocumentNumber} for {si.Customer.Name} created on {si.CreatedDate.ToShortDateString()}:");
    foreach (var e in si.Elements)
    {
        Console.WriteLine($"  {e.Quantity} x {e.Name} @ {e.Price:C} ({e.VatRate:P} VAT)");
    }
}

Console.ReadLine();
