﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Vidly.Models;
using System.Data.Entity; 

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        [Route ("customers")]
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        [Route("customers/{id}")]
        public ActionResult Details(int id)
        {
            List<Customer> cList = new List<Customer>()
            {
                new Customer {Id = 1, Name = "John Smith"},
                new Customer {Id = 2, Name = "Maty Willians"}
            };

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            
            // return View(id);
            return View(customer);
        }
    }
}