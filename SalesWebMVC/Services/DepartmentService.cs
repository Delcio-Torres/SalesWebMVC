using SalesWebMVC.Context;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
   public class DepartmentService
   {
      private readonly SalesWebMvcContext _context;

      public DepartmentService(SalesWebMvcContext context)
      {
         _context = context;
      }

      public List<Department> FindAll()
      {
         return _context.Department.OrderBy(x=>x.Name).ToList();
      }
   }
}
