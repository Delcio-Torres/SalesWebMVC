﻿using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models
{
   public class Department
   {
      public Department()
      {
      }

      public int Id { get; set; }
      [Display(Name="Departamento")]
      public string Name { get; set; }
      public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

      public Department(int id, string name)
      {
         Id = id;
         Name = name;
      }

      public Department(string name)
      {
         Name = name;
      }

      public void AddSeller(Seller seller)
      {
         Sellers.Add(seller);
      }

      public double TotalSales(DateTime initial, DateTime final)
      {
         return Sellers.Sum(seller => seller.TotalSales(initial, final));
      }
   }
}
