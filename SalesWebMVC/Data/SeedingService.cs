using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data

{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
             if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; 
            }
          
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Mary Jane", "mary@email.com", new DateTime(1998, 4, 22), 1000.0, d2);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 9, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 9, 25), 10000.0, SaleStatus.Billed, s2);

            _context.Department.AddRange(d1, d2);
            _context.Seller.AddRange(s1, s2); 
            _context.SalesRecord.AddRange(r1, r2);
            //
            _context.SaveChanges();
        }
    }
}
