using MultipleRowAdding.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultipleRowAdding.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ProductDbContext db = new ProductDbContext();
        // GET: Orders
        public ActionResult Index()
        {
            List<Order> orders = db.Orders.OrderBy(s => s.OrderDate).ToList();
            return View(orders);
        }
        [HttpPost]
        public ActionResult SaveOrder(DateTime date, int customerId, OrderDetail[] orderDetails)
        {
            string result = "Error! Order Is Not Complete!";
            if (date != null && orderDetails != null)
            {
                //var cutomerId = Guid.NewGuid();
                Order model = new Order();

                model.CustomerId = customerId;
                //model.Name = name;
                //model.Address = address;
                model.OrderDate = date;
                db.Orders.Add(model);

                foreach (var item in orderDetails)
                {
                    //var orderId = Guid.NewGuid();
                    OrderDetail OD = new OrderDetail();
                    OD.OrderId = item.OrderId;
                    OD.ProductId = item.ProductId;
                    OD.Price = item.Price;
                    OD.Quantity = item.Quantity;
                    OD.Amount = item.Amount;
                    //OD.OrderId = orderId;
                    //O.ProductName = item.ProductName;
                    //O.Quantity = item.Quantity;
                    //O.Price = item.Price;
                    //O.Amount = item.Amount;
                    //O.CustomerId = cutomerId;
                    db.OrderDetails.Add(OD);
                }
                db.SaveChanges();
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditOrder(int? Orderid, int? ProductId)
        {
            OrderDetail orderDetail = db.OrderDetails
                                        .Include(z => z.Product)
                                            .Where(x => x.ProductId == ProductId && x.OrderId == Orderid)
                                                .FirstOrDefault();
            //Book book = _bookRepository.GetBookById(BookId);
            return View(orderDetail);
        }
        [HttpPost]
        public ActionResult EditOrder([Bind(Include = "OrderId,ProductId,ProductName,Quantity,Price,Amount,")] OrderDetail orderDetail)
        {
            //try
            //{
            if (ModelState.IsValid)
            {
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                //_bookRepository.UpdateBook(book);
                //_bookRepository.Save();
                return RedirectToAction("Index", "Orders");
            }
            //}
            //catch (Exception ex)
            //{
            //    //Log the error
            //    ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            //    TempData["Failed"] = "Failed";
            //}
            return View(orderDetail);
        }
        public ActionResult DeleteOrder(int orderId)
        {
            // Find the order in the database
            Order order = db.Orders.Find(orderId);
            if (order == null)
            {
                return HttpNotFound();
            }

           

            return View(order);
        }
        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrderConfirmed(int orderId)
        {
            Order order = db.Orders.Find(orderId);
            if (order == null)
            {
                return HttpNotFound();
            }

            List<OrderDetail> orderDetails = db.OrderDetails.Where(od => od.OrderId == orderId).ToList();

            db.OrderDetails.RemoveRange(orderDetails);
            db.Orders.Remove(order);
            db.SaveChanges();

            return RedirectToAction("Index", "Orders");
        }
    }
}