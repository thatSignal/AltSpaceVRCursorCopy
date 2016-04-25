using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;

public class ProductData
{
    public IList<ProductDetails> ProductList { get; set; }
}

public class ProductDetails
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Kind { get; set; }
    public int PriceCents { get; set; }
    public List<ProductReview> Reviews { get; set; }
}

public class ProductReview
{
    public int ProductID { get; set; }
    public bool IsPositive { get; set; }
    public string Username { get; set; }
    public string Body { get; set; }
}