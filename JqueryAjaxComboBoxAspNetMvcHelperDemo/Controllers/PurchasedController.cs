using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JqueryAjaxComboBoxAspNetMvcHelperDemo.Models;

using NHibernate.Linq;
using JqueryAjaxComboBoxAspNetMvcHelperDemo.ModelsViews;


namespace JqueryAjaxComboBoxAspNetMvcHelperDemo.Controllers
{
    public class PurchasedController : Controller
    {
        //
        // GET: /Purchased/

        public ViewResult Index()
        {
            using (var s = SessionFactoryBuilder.GetSessionFactory().OpenSession())
            {
                return View(
                    s.Query<Purchased>()
                    // must do paging here
                    .Fetch(x => x.Product).ThenFetch(x => x.Category)


                    .ToList()
                    .Select(x =>
                        new PurchasedViewModel
                            {
                                PurchasedId = x.PurchasedId,
                                ProductName = x.Product.ProductName,
                                CategoryName = x.Product.Category.CategoryName,
                                Quantity = x.Quantity,
                                PurchasedBy = x.PurchasedBy
                            }
                            )
                    );
            }
        }// Index   

        public ViewResult Input()
        {
            return View(
                new PurchasedInputViewModel
                {
                    MostSellingProductAdvisory = "Tablets are fast-selling product as of late",
                    Purchased = new Purchased()
                });
        }

        public ViewResult InputEdit(int id)
        {
            using (var s = SessionFactoryBuilder.GetSessionFactory().OpenSession())
            {

                var l = s.Get<Purchased>(id);

                var px = new PurchasedInputViewModel
                {
                    MostSellingProductAdvisory = "Did you know Bumble Bee car is a fast-selling car?",
                    CategoryId = l.Product.Category.CategoryId,
                    Purchased = l
                };

                return View("Input", px);
            }
        }

        [HttpPost]
        public ActionResult Input(PurchasedInputViewModel p)
        {
            if (ModelState.IsValid)
            {
                using (var s = SessionFactoryBuilder.GetSessionFactory().OpenSession())
                {
                    s.Merge(p.Purchased);
                    s.Flush();
                    return RedirectToAction("Index");
                }
            }
            else
                return View(p);
        }

        public ViewResult DeletePreview(int id)
        {
            using (var s = SessionFactoryBuilder.GetSessionFactory().OpenSession())
            {
                return View(
                    s.Query<Purchased>().Fetch(x => x.Product).ThenFetch(x => x.Category)
                    .Where(x => x.PurchasedId == id).Single());
            }
        }

        [HttpPost]
        public ActionResult Delete(int PurchasedId)
        {
            using (var s = SessionFactoryBuilder.GetSessionFactory().OpenSession())
            {
                s.Delete(s.Load<Purchased>(PurchasedId));
                s.Flush();
                return RedirectToAction("Index");
            }
        }


         

    }//class
}
