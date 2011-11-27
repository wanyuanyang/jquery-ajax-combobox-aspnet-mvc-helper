namespace JqueryAjaxComboBoxAspNetMvcHelperDemo
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using JqueryAjaxComboBoxAspNetMvcHelperDemo.Models;
using System.Reflection;


public static class SessionFactoryBuilder
{
    static ISessionFactory _sf = null;
    public static ISessionFactory GetSessionFactory()
    {
        // Building SessionFactory is costly, should be done only once, making the backing variable static would prevent creation of multiple factory
        try
        {
            if (_sf != null) return _sf;


            

            _sf =
                Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString(              
@"Data Source=C:\Users\Michael\_CODE\JqueryAjaxComboBoxAspNetMvcHelperDemo\JqueryAjaxComboBoxAspNetMvcHelperDemo\Content\Database\TheCatalog.sqlite;Version=3;"))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Category>())
                .BuildSessionFactory();

            return _sf;
        }
        catch (Exception ex)
        {                      
            throw new Exception(ex.InnerException.Message + "\n" + ex.InnerException.StackTrace);
        }
    }


}//SessionFactoryBuilder

public static class Helpers
{
    public static IQueryable<T> LimitAndOffset<T>(this IQueryable<T> q,
                        int pageSize, int pageOffset)
    {
        return q.Skip((pageOffset - 1) * pageSize).Take(pageSize);
    }

}


}//JqueryAjaxComboBoxAspNetMvcHelperDemo