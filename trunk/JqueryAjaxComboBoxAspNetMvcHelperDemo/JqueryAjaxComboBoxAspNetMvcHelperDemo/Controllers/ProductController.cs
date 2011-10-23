using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NHibernate.Linq;
using JqueryAjaxComboBoxAspNetMvcHelperDemo.Models;
using Ienablemuch.JqueryAjaxComboBox;


namespace JqueryAjaxComboBoxAspNetMvcHelperDemo.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Home/

        public ViewResult Index()
        {
            using (var s = SessionFactoryBuilder.GetSessionFactory().OpenSession())
            {
                return View( s.Query<Product>().OrderBy(x=>x.ProductName).Fetch(x=>x.Category).ToList());
            }
        }

        public ViewResult DeletePreview(int id)
        {
            using (var s = SessionFactoryBuilder.GetSessionFactory().OpenSession())
            {
                return View(                    
                    s.Query<Product>().Fetch(x => x.Category)
                    .Where(x => x.ProductId == id).Single());
            }            
        }

        [HttpPost]
        public ActionResult Delete(int ProductId)
        {
            using (var s = SessionFactoryBuilder.GetSessionFactory().OpenSession())
            {
                s.Delete(s.Load<Product>(ProductId));                
                s.Flush();
                return RedirectToAction("Index");
            }            
        }


        public ActionResult Input()
        {
            return View(new Product());
        }

        public ActionResult InputEdit(int id)
        { 
            using(var s = SessionFactoryBuilder.GetSessionFactory().OpenSession())
            {
                var p = s.Get<Product>(id);                
                return View("Input", p);
            }
        }

        [HttpPost]
        public ActionResult Input(Product p)
        {

            if (ModelState.IsValid)
            {
                using (var s = SessionFactoryBuilder.GetSessionFactory().OpenSession())
                {
                    s.Merge(p);
                    s.Flush();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
            
        }

        public JsonResult TesterA(string q_word, string primary_key, int per_page, int page_num, string cascaded_word)
        {
            return Json(new { q_word, primary_key, per_page, page_num, cascaded_word}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TesterB([Bind(Include = "q_word, primary_key, per_page, page_num, cascaded_word")]LookupRequest lr)
        {
            return Json(new { lr.q_word, lr.primary_key, lr.per_page, lr.page_num, lr.cascaded_word }, JsonRequestBehavior.AllowGet);
        }


        public class Person
        {
            public string Lastname { get; set; }
            public string Firstname { get; set; }
            public string Middlename{ get; set; }
        }

        public JsonResult TesterC(string Lastname, string Firstname, string Middlename)
        {
            return Json(new { Lastname, Firstname, Middlename }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TesterD(Person p)
        {
            return Json(new { p.Lastname, p.Firstname, p.Middlename }, JsonRequestBehavior.AllowGet);
        }






        [HttpPost]
        public JsonResult xLookup(string cascaded_word, string q_word, string primary_key, int per_page, int page_num)
        {


            using (var svc = SessionFactoryBuilder.GetSessionFactory().OpenSession())
            {

                int categoryId = 0;

                bool isNumber = int.TryParse(cascaded_word, out categoryId);




                var FilteredProduct = svc.Query<Product>()
                                        .Where(x =>
                                            (

                                                categoryId == 0
                                                ||
                                                (categoryId != 0 && x.Category.CategoryId == categoryId)

                                            )

                                            &&

                                            (q_word == "" || x.ProductName.Contains(q_word))

                                            );


                var PagedFilter = FilteredProduct.OrderBy(x => x.ProductName)
                                  .LimitAndOffset(per_page, page_num)
                                  .Fetch(x => x.Category)
                                  .ToList();

                return Json(
                    new
                    {
                        cnt = FilteredProduct.Count()

                        ,primary_key = PagedFilter.Select(x => x.ProductId)

                        ,candidate = PagedFilter.Select(x => x.ProductName)

                        ,cnt_page = PagedFilter.Count()

                        ,attached = PagedFilter.Select(x =>
                               new[]
                                {
                                    new string[] { "Product Code", x.ProductCode },                                    
                                    new string[] { "Category Code", x.Category.CategoryCode },
                                    new string[] { "Category", x.Category.CategoryName }
                                }
                           )
                    }
                    );

            }//using
        }//CascadedFromCategoryLookup


        [HttpPost]
        public JsonResult Lookup(LookupRequest lr)
        {

            // lr.q_word = Request["q_word"];
            
            

            using (var svc = SessionFactoryBuilder.GetSessionFactory().OpenSession())
            {

                int categoryId = 0;

                bool isNumber = int.TryParse(lr.cascaded_word, out categoryId);


                /* categoryId = 0; */
                /*lr.per_page = 5;
                lr.page_num = 1;*/
                // lr.q_word = lr.q_word ?? "";

                lr.q_word = lr.q_word ?? "";

                var FilteredProduct = svc.Query<Product>()
                                        .Where(x =>
                                            (

                                                categoryId == 0
                                                ||
                                                (categoryId != 0 && x.Category.CategoryId == categoryId)

                                            )

                                            &&

                                            (lr.q_word == "" || x.ProductName.Contains(lr.q_word))

                                            );


                var PagedFilter = FilteredProduct.OrderBy(x => x.ProductName)
                                  .LimitAndOffset(lr.per_page, lr.page_num)
                                  .Fetch(x => x.Category)
                                  .ToList();

                return Json(
                    new
                    {
                        cnt = FilteredProduct.Count()

                        ,
                        primary_key = PagedFilter.Select(x => x.ProductId)

                        ,
                        candidate = PagedFilter.Select(x => x.ProductName)

                        ,
                        cnt_page = PagedFilter.Count()

                        ,
                        attached = PagedFilter.Select(x =>
                              new[]
                                {
                                    new string[] { "Product Code", x.ProductCode },                                    
                                    new string[] { "Category Code", x.Category.CategoryCode },
                                    new string[] { "Category", x.Category.CategoryName }
                                }
                          )
                    }
                    );

            }//using
        }//CascadedFromCategoryLookup


        [HttpPost]
        public string Caption(string q_word)
        {
            using (var svc = SessionFactoryBuilder.GetSessionFactory().OpenSession())
            {
                int productId;
                bool isOk = int.TryParse(q_word, out productId);


                return
                    isOk ?
                    svc.Query<Product>()
                    .Where(x => x.ProductId == productId)
                    .Select(x => x.ProductName)
                    .SingleOrDefault()
                    : "";
            }

        }//Caption





    }// Product
}
