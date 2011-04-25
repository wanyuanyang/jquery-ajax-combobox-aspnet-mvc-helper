using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using System.ComponentModel.DataAnnotations;

namespace JqueryAjaxComboBoxAspNetMvcHelperDemo.ModelsDtos
{

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
            Id(x => x.ProductId);
            Map(x => x.ProductCode);
            Map(x => x.ProductName);
            Map(x => x.CategoryId);
        }

    }



    // populated manually from Purchased model
    public class PurchasedDto
    {        
        public int PurchasedId { get; set; }
        public int? CategoryId { get; set; }
        [Required] public int ProductId { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public string PurchasedBy { get; set; }
    }

      

}