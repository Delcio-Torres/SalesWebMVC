using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebMVC.Models
{
   public class Seller
   {
      public Seller()
      {
      }

      public int Id { get; set; }

      [Required]
      [StringLength(80, MinimumLength = 5, ErrorMessage ="{0} size should be between {2} and {1}")]
      public string Name { get; set; }

      [Required]
      [StringLength(80, MinimumLength = 5, ErrorMessage = "{0} size should be between {2} and {1}")]
      [EmailAddress(ErrorMessage ="Entre email válido")]
      public string Email { get; set; }
      
      [Required(ErrorMessage ="{0} required")]
      [Display(Name="Birth Date")]
      [DataType(DataType.Date)]
      [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
      public DateTime BirthDate { get; set; }

      [Required(ErrorMessage = "{0} required")]
      [Display(Name="Salário Base")]
      [DisplayFormat(DataFormatString = "{0:F2}")]
      public double BaseSalary { get; set; }
      
      public Department Department { get; set; }
      
      [Display(Name = "Departamento")]
      public int DepartmentId { get; set; }
      
      public ICollection<SaleRecord> Sales { get; set; } = new List<SaleRecord>();

      public Seller( string name, string email, DateTime birthDate, double baseSalary, Department department)
      {
         //Id = id;
         Name = name;
         Email = email;
         BirthDate = birthDate;
         BaseSalary = baseSalary;
         Department = department;
      }

      public void AddSales(SaleRecord sr)
      {
         Sales.Add(sr);
      }

      public void RemoveSales(SaleRecord sr)
      {
         Sales.Remove(sr);
      }

      public double TotalSales(DateTime initial, DateTime final)
      {
         return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
      }
   }
}
