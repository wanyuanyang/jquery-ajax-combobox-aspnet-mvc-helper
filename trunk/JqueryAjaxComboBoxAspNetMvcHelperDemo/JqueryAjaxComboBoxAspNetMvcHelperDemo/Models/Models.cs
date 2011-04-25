namespace JqueryAjaxComboBoxAspNetMvcHelperDemo.Models
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;


public class Product
{
    public virtual int ProductId { get; set; }
    public virtual string ProductCode { get; set; }
    public virtual string ProductName { get; set; }
    public virtual Category Category { get; set; }
}

public class ProductMap : ClassMap<Product>
{
    public ProductMap()
    {
        Id(x => x.ProductId);
        Map(x => x.ProductCode);
        Map(x => x.ProductName);
        References(x => x.Category).Column("CategoryId");                
    }

}



public class Category
{
    public virtual int CategoryId { get; set; }
    public virtual string CategoryCode { get; set; }
    public virtual string CategoryName { get; set; }
    public virtual int Ranking { get; set; }
}

public class CategoryMap : ClassMap<Category>
{
    public CategoryMap()
    {
        Id(x => x.CategoryId);
        Map(x => x.CategoryCode);
        Map(x => x.CategoryName);
        Map(x => x.Ranking);
    }
}

    
public class Purchased
{
    public virtual int PurchasedId { get; set; }
    public virtual Product Product { get; set; }
    public virtual int Quantity { get; set; }
    public virtual string PurchasedBy { get; set; }
}

    
public class PurchasedMap : ClassMap<Purchased>
{
    public PurchasedMap()
    {
        Id(x => x.PurchasedId);
        References(x => x.Product).Column("ProductId");
        Map(x => x.Quantity);
        Map(x => x.PurchasedBy);
    }
}


}//namespace

