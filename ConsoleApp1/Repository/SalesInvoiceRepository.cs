using ConsoleApp1.context;
using ConsoleApp1.models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Repository;


public class SalesInvoiceRepository
{
    private readonly MyDbContext _context;

    public SalesInvoiceRepository(MyDbContext context)
    {
        _context = context;
    }

    public void Save(SalesInvoice salesInvoice)
    {
        if (salesInvoice.Id == 0)
        {
            _context.SalesInvoices.Add(salesInvoice);
        }
        else
        {
            _context.SalesInvoices.Update(salesInvoice);
        }
        _context.SaveChanges();
    }

    public List<SalesInvoice> GetAll()
    {
        return _context.SalesInvoices
            .Include(si => si.Elements)
            .Include(si => si.Customer)
            .ToList();
    }
}




