
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/**
* 命名空间: LanguageFeatures.Models
*
* 功 能： N/A
* 类 名： MyExtensionMethods
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016-11-01 17:43:11 杨伟贤 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：*****有限公司 　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
namespace LanguageFeatures.Models {
    public static class MyExtensionMethods {
        /// <summary>
        ///这是一个ShoppingCart的扩展方法
        /// </summary>
        /// <param name="carParam"></param>
        /// <returns></returns>
        //public static decimal TotalPrices(this ShoppingCart carParam){
        //    Decimal total = 0;
        //    foreach(Product prod in carParam.Products) {
        //        total += prod.Price;
        //    }
        //    return total;
        //}

        /// <summary>
        /// 对接口使用扩展方法
        /// </summary>
        /// <param name="productEnum"></param>
        /// <returns></returns>
        public static decimal TotalPrices(this IEnumerable<Product> productEnum) {
            decimal total = 0;
            foreach(Product p in productEnum) {
                total += p.Price;
            }
            return total;
        }
        /// <summary>
        /// 创建过滤扩展方法
        /// </summary>
        /// <param name="productEnum"></param>
        /// <param name="categoryParam"></param>
        /// <returns></returns>
        public static IEnumerable<Product> FilterByCategory(this IEnumerable<Product> productEnum,string categoryParam) {
            foreach(Product p in productEnum) {
                //  total += p.Price;
                if(p.Category == categoryParam) {
                    yield return p;
                }
            }
        }
        /// <summary>
        /// 使用lambda表达式
        /// </summary>
        /// <param name="productEnum"></param>
        /// <param name="selectorParam"></param>
        /// <returns></returns>
        public static IEnumerable<Product>Filter(this IEnumerable<Product> productEnum,Func<Product,bool> selectorParam) {
            foreach(Product p in productEnum) {
                if(selectorParam(p)) {
                    yield return p;
                }
            }
        }
    }
}