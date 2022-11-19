using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Models
{
   public class SaleRecord
   {
      public SaleRecord()
      {
      }

      public int Id { get; set; }
      public DateTime Date { get; set; }
      public double Amount { get; set; }
      public SaleStatus Status { get; set; }
      public Seller Seller { get; set; }

      public SaleRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
      {
         Id = id;
         Date = date;
         Amount = amount;
         Status = status;
         Seller = seller;
      }

      public SaleRecord(DateTime date, double amount, SaleStatus status, Seller seller)
      {
         Date = date;
         Amount = amount;
         Status = status;
         Seller = seller;
      }
   }
}
