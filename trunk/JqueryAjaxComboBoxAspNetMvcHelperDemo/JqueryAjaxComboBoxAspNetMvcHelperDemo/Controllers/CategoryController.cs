using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NHibernate.Linq;
using JqueryAjaxComboBoxAspNetMvcHelperDemo.Models;



namespace JqueryAjaxComboBoxAspNetMvcHelperDemo.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Lookup(string q_word, string primary_key, int per_page, int page_num)
        {


            using (var svc = SessionFactoryBuilder.GetSessionFactory().OpenSession())
            {

                var FilteredCategory = svc.Query<Category>()
                                        .Where(x => q_word == "" || x.CategoryName.Contains(q_word));


                var PagedFilter = FilteredCategory.OrderBy(x => x.CategoryName)
                                  .LimitAndOffset(per_page, page_num)
                                  .ToList();

                return Json(
                    new
                    {
                        cnt = FilteredCategory.Count()

                        ,primary_key = PagedFilter.Select(x => x.CategoryId)

                        ,candidate = PagedFilter.Select(x => x.CategoryName)

                        ,cnt_page = PagedFilter.Count()

                    }
                    );

            }//using
        }//List


        [HttpPost]
        public string Caption(string q_word)
        {
            using (var svc = SessionFactoryBuilder.GetSessionFactory().OpenSession())
            {
                if (string.IsNullOrEmpty(q_word))
                    return "";
                else
                    return 
                        svc.Query<Category>()
                        .Where(x => x.CategoryId == int.Parse(q_word))
                        .Select(x => x.CategoryName)
                        .SingleOrDefault();
            }

        }

    }
}
