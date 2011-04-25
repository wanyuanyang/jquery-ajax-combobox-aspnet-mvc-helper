namespace JqueryAjaxComboBoxAspNetMvcHelperDemo.ModelsViews
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using JqueryAjaxComboBoxAspNetMvcHelperDemo.ModelsDtos;


public class PurchasedViewModel
{
    public int PurchasedId { get; set; }
    public string CategoryName { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public string PurchasedBy { get; set; }
}

public class PurchasedInputViewModel
{
    public string MostSellingProductAdvisory { get; set; }
    public PurchasedDto PurchasedDto { get; set; }    
}

}