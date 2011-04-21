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
                return View(s.Query<Product>().Fetch(x=>x.Category).ToList());
            }
        }

        public ActionResult DeletePreview(int id)
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
                s.Delete(s.Load<ProductDto>(ProductId));                
                s.Flush();
                return RedirectToAction("Index");
            }            
        }


        public ActionResult Input()
        {
            return View(new ProductDto());
        }

        public ActionResult InputEdit(int id)
        { 
            using(var s = SessionFactoryBuilder.GetSessionFactory().OpenSession())
            {
                return View("Input", s.Get<ProductDto>(id));
            }
        }

        [HttpPost]
        public ActionResult Input(ProductDto p)
        {
            using (var s = SessionFactoryBuilder.GetSessionFactory().OpenSession())
            {
                s.Merge(p);
                s.Flush();
            }
            return RedirectToAction("Index");
        }


    }
}
