using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NHibernate.Linq;
using JqueryAjaxComboBoxAspNetMvcHelperDemo.Models;


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
                return View("Input", s.Get<Product>(id));
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

        [HttpPost]
        public JsonResult Lookup(string cascaded_word, string q_word, string primary_key, int per_page, int page_num)
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
