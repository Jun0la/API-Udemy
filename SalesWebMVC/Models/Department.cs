using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Models;
using SalesWebMVC.Services.Exceptions;
using SalesWebMVC.Services;

namespace SalesWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department() { } 

        public Department(int id, string name) 
        {
            Id = id;
            Name = name;
        }

        public void Add(Seller Seller) 
        {
            Sellers.Add(Seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
    