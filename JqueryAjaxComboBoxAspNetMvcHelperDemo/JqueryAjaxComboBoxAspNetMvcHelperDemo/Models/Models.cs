namespace JqueryAjaxComboBoxAspNetMvcHelperDemo.Models
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;


public class ProductDto
{
    public virtual int ProductId { get; set; }
    public virtual string ProductCode { get; set; }
    public virtual string ProductName { get; set; }
    public virtual int CategoryId { get; set; }
}

public class ProductDtoMap : ClassMap<ProductDto>
{
    public ProductDtoMap()
    {
        Table("Product");        
        Not.LazyLoad();       
        Id(x => x.ProductId);
        Map(x => x.ProductCode);
        Map(x => x.ProductName);
        Map(x => x.CategoryId);
    }
   
}

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
        Table("Product");
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


}//namespace

