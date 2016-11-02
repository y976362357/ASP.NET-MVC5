
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/**
* 命名空间: LanguageFeatures.Models
*
* 功 能： N/A
* 类 名： ShoppingCart
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016-11-01 17:41:10 杨伟贤 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：*****有限公司 　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
namespace LanguageFeatures.Models {
    //:IEnumerable<Product>
    public class ShoppingCart:IEnumerable<Product> {
        /// <summary>
        /// Product列表
        /// </summary>
        public List<Product> Products { get; set; }


        public IEnumerator<Product> GetEnumerator() {
            return ((IEnumerable<Product>)Products).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<Product>)Products).GetEnumerator();
        }

        //IEnumerator IEnumerable.GetEnumerator() {
        //    throw new NotImplementedException();
        //}

        //IEnumerator<Product> IEnumerable<Product>.GetEnumerator() {
        //    throw new NotImplementedException();
        //}
    }
}