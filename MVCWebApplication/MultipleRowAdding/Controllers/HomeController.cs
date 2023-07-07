using MultipleRowAdding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultipleRowAdding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductDbContext db= new ProductDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public JsonResult getCustomer()
        //{
        //    List<Customer> customers = new List<Customer>();

        //    using (ProductDbContext dc = new ProductDbContext())
        //    {
        //        customers = dc.Customers.OrderBy(a => a.CustomerName).ToList();
        //        //List<Customer> Customerlist = db.Customers.ToList();
        //        //ViewBag.Customerlist = new SelectList(Customerlist, "CustomerId", "CustomerName");
        //    }
        //    return Json ( customers, JsonRequestBehavior.AllowGet );
        //}
        public ActionResult CustomerSearch(string pCustomerSearch)
        {
            if(pCustomerSearch == null || pCustomerSearch == "")
            {
                List<Customer> CustomerList = db.Customers.ToList();
                //if (CustomerList == null) CustomerList = new List<Customer>();
                //CustomerList.Insert(0, new Customer { CustomerName = "--Select--" });
                var cList = CustomerList.OrderBy(a => Convert.ToInt32(a.CustomerId)).ToList().Select(x => new
                {
                    CustomerId = x.CustomerId,
                    CustomerName = x.CustomerName
                }

                ).ToList();
                return Json(cList, JsonRequestBehavior.AllowGet);
                
            }
            else
            {
                List<Customer> CustomerList = db.Customers.Where(b => b.CustomerName.ToLower().Contains(pCustomerSearch.ToLower()) || pCustomerSearch == null).ToList();
                //if (CustomerList == null) CustomerList = new List<Customer>();
                //CustomerList.Insert(0, new Customer { CustomerName = "--Select--" });
                var cList = CustomerList.OrderBy(a => Convert.ToInt32(a.CustomerId)).ToList().Select(x => new
                {
                    CustomerId = x.CustomerId,
                    CustomerName = x.CustomerName
                }

                ).ToList();
                return Json(cList, JsonRequestBehavior.AllowGet);
            }
            
        }
        public ActionResult getCustomer()
        {
            ProductDbContext db = new ProductDbContext();

            return Json(db.Customers.Select(x => new
            {
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getProduct()
        {
            ProductDbContext db = new ProductDbContext();

            return Json(db.Products.Select(x => new
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCustomerById(int id)
        {
          
            try
            {
               

               
                var customer = db.Customers.FirstOrDefault(c => c.CustomerId == id);

                //if (Customer != null && Customer)
                //var Customer = (from z in db.Customers
                //                where z.CustomerId == id
                //                select z).ToList();
                //db.Configuration.ProxyCreationEnabled = false;
                if (customer == null) return new HttpNotFoundResult();
                else return Json(new {customer.CustomerId, customer.CustomerName, customer.CustomerAddress }, JsonRequestBehavior.AllowGet);
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public ActionResult GetProductById(int id)
        {

            try
            {



                var product = db.Products.FirstOrDefault(c => c.ProductId == id);

                //if (Customer != null && Customer)
                //var Customer = (from z in db.Customers
                //                where z.CustomerId == id
                //                select z).ToList();
                //db.Configuration.ProxyCreationEnabled = false;
                if (product == null) return new HttpNotFoundResult();
                else return Json(new { product.ProductId, product.ProductName, product.ProductPrice }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       
    }
}