﻿using System.Collections.Generic;
using System.Web.Mvc;
using LanguageFeatures.Models;
using System.Linq;
using System;
using System.Text;
using System.Data;

namespace LanguageFeatures.Controllers {
    public class HomeController:Controller {
        //定义及初始化一个对象
        Product myProduct = new Product() {
            ProductId = 1,
            Name = "Kayak",
            Description="A boat for on person",
            Category="Watersports",
            Price=275M
        };

        public ActionResult Index() {
            //return "A test";
            return View();
        }

        public PartialViewResult ProductList() {
            List<Product> products = new List<Product>{
                   new Product {Name="Kayak",Price=275M,Category="Watersports" },
                    new Product {Name="Lifejacket",Price=48.95M,Category="Watersports"},
                    new Product {Name="Soccer ball" ,Price=19.50M,Category="Soccer"},
                    new  Product {Name="Corner flag",Price=34.95M,Category="Soccer" }
            };

            return PartialView(products);
        }

        public JsonResult _GetProducts(){
            List<Product> products = new List<Product>{
                   new Product {Name="Kayak",Price=275M,Category="Watersports" },
                    new Product {Name="Lifejacket",Price=48.95M,Category="Watersports"},
                    new Product {Name="Soccer ball" ,Price=19.50M,Category="Soccer"},
                    new  Product {Name="Corner flag",Price=34.95M,Category="Soccer" }
            };
            return Json(products,JsonRequestBehavior.AllowGet);
            //return PartialView("_GetProducts",JsonRequestBehavior.AllowGet);
        }
        //自动属性
        public ViewResult AutoProperty() {
            Product p = new Product();
            p.Name = "Kayak";
            string productName = p.Name;
            return View("Result",(object)string.Format("Product:name:{0}",p.Name));
        }
        //对象初始化
        public ViewResult CreateProduct() {
            //对象初始化
            Product p = new Product() {
                ProductId = 100,
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 275M,
                Category = "Watersports"
            };
            return View("Result",(object)string.Format("Category:{0}",p.Category));
        }
        ////初始化器{}
        public ViewResult CreateCollection() {
            //初始化器{}
            string[] stringArray = { "apple","orange","plum" };
            List<int> intlist = new List<int> { 10,20,30,40 };
            Dictionary<string,int> myDict = new Dictionary<string,int>() {
                { "apple",10},{"orange",20 },{"plum",30 }
            };
            return View("Result",(object)stringArray[1]);
        }

        //扩展方法使用
        public ViewResult UseExtension() {
            ShoppingCart cart = new ShoppingCart {
                Products = new List<Product>() {
                    new Product {Name="Kayak",Price=275M },
                    new Product {Name="Lifejacket",Price=48.95M},
                    new Product {Name="Soccer ball" ,Price=19.50M},
                    new  Product {Name="Corner flag",Price=34.95M }
                }
            };
            decimal cartTotal = cart.TotalPrices();
            return View("Result",(object)string.Format("Total:{0:c}",cartTotal));
        }

        public ViewResult UserExtensionEnumerable() {
            IEnumerable<Product> products = new ShoppingCart() {
                Products = new List<Product> {
                      new Product {Name="Kayak",Price=275M },
                    new Product {Name="Lifejacket",Price=48.95M},
                    new Product {Name="Soccer ball" ,Price=19.50M},
                    new  Product {Name="Corner flag",Price=34.95M }
                }
            };
            //数组
            Product[] productArray = {
                  new Product {Name="Kayak",Price=275M },
                    new Product {Name="Lifejacket",Price=48.95M},
                    new Product {Name="Soccer ball" ,Price=19.50M},
                    new  Product {Name="Corner flag",Price=34.95M }
            };

            decimal cartTotal = products.TotalPrices();
            decimal arrayToral = productArray.TotalPrices();
            return View("Result",(object)string.Format("Cart Total:{0},Array Total:{1}",cartTotal,arrayToral));
        }

        public ViewResult UserFilterExtensionMethod() {
            #region 实现
            //创建一个筛选器-委托方式            
            Func<Product,bool> categoryFilter = delegate (Product p) {
                return p.Category == "Soccer";
            };
            //lambda 替换委托定义
            Func<Product,bool> categoryFilter1 = p => p.Category == "Soccer";

            IEnumerable<Product> products = new ShoppingCart() {
                Products = new List<Product> {
                      new Product {Name="Kayak",Price=275M,Category="Watersports" },
                    new Product {Name="Lifejacket",Price=48.95M,Category="Watersports"},
                    new Product {Name="Soccer ball" ,Price=19.50M,Category="Soccer"},
                    new  Product {Name="Corner flag",Price=34.95M,Category="Soccer" }
                }
            };

            decimal total = 0;

            //foreach(Product p in products.Filter(categoryFilter)) {
            //    total += p.Price;
            //}

            //多条件委托
            foreach(Product p in products.Filter(p => p.Category == "Soccer" && p.Price > 20)) {
                total += p.Price;
            }
            //foreach(Product p in products.FilterByCategory("Watersports")) {
            //    total += p.Price;
            //}

            return View("Result",(object)string.Format("Total:{0}",total));
            #endregion
        }

        //自动类型,匿名类型
        public ViewResult CreateAnonArray() {
            //声明匿名类型属猪，对象属性要一致
            var oddsAndEnds = new[] {
                new {Name="MVC",Category="Pattern"},
                new {Name="Hat",Category="Clothing"},
                new {Name="Apple",Category="Friuit"}
            };

            StringBuilder result = new StringBuilder();
            foreach(var item in oddsAndEnds) {
                result.Append(item.Name).Append(" ");
            }

            return View("Result",(object)result.ToString());

        }

        //Linq,在类中查询数据的一种类似于sql的语法
        public ViewResult FindProducts() {
            //Product数组
            Product[] products = {
                   new Product {Name="Kayak",Price=275M,Category="Watersports" },
                    new Product {Name="Lifejacket",Price=48.95M,Category="Watersports"},
                    new Product {Name="Soccer ball" ,Price=19.50M,Category="Soccer"},
                    new  Product {Name="Corner flag",Price=34.95M,Category="Soccer" }
            };
            
            Product[] foundProducts = new Product[3];
           // Action<IEnumerable<Product>> a = PrintProduct;
            //对数组进行排序        
            Array.Sort(products,(item1,item2) => { return Comparer<decimal>.Default.Compare(item1.Price,item2.Price); });
          
            //对数组进行排序                                      
            //Array.Sort(products,(i1,i2)=> { return Comparer<string>.Default.Compare(i1.Name,i2.Name); });

            //取出数组的前三个数据
            Array.Copy(products,foundProducts,3);

            //以上是以前的方式
            //下面是LINQ方式,排序，生成
            var foundProducts1 = from match in products
                                 orderby match.Price descending
                                 select new { match.Name,match.Price };

            //LINQ  点语法 , ,排序,取值、投影
            var fonudProducts2 = products.OrderByDescending(e => e.Price).Take(3).Select(e => new { e.Name,e.Price });

            //过滤数据
            var fonudProducts3 = products.Take<Product>(5).Where(p => p.Price > 40);

            //按Category分组，获取所有Category，并获取各Category 中Price最大值
            var fff = from p in products
                      where p.Category!=null
                      where p.Category!=""
                      group p by p.Category into g
                      select new { g.Key , MaxPrice=g.Max(p=>p.Price)};

            //多列分组
            var f = from p in products
                    group p by new { p.Category,p.Name } into g
                    select new { g.Key };
            DataTable dt = new DataTable();
           // dt.AsEnumerable
            var ff = from p in products
                     group p by new { c = p.Price > 20 } into g
                     select g;

            //products.Except<Product>(fonudProducts2);

            List < int > arr = new List<int>() { 1,2,3,4,5,6,7 };
            var result = arr.Where(a => { return a > 3; }).Sum();
            arr.SelectMany<int,string>(a => { return new List<string> { "a",a.ToString() }; });
            Console.WriteLine(result);
            
            //Console.ReadKey();


            products[2] = new Product { Name = "Stadium",Price = 79600M,Category = "Watersports" };
            //Category="Watersports"                         
            int count = 0;
            StringBuilder sb = new StringBuilder();
            foreach(var p in f) {                
                sb.AppendFormat("Category:{0},MaxPrice:{1} ",p.Key.Category,p.Key.Name);
                //   sb.Append(p.Name + " ");                
                //sb.AppendFormat("Price:{0},",p.Price);
                //if(count++ == 2) {
                //    break;
                //}
            }

            return View("Result",(object)sb.ToString());
        }

   
    }
}