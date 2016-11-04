
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/**
* 命名空间: LanguageFeatures.Models
*
* 功 能： N/A
* 类 名： Product
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016-11-01 17:10:46 杨伟贤 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：*****有限公司 　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
namespace LanguageFeatures.Models {
    public class Product {        


        private string ID { get; }
        ///语言特性，自动属性与规则属性
        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 产品描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 产品价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 产品分类
        /// </summary>
        public string Category { get; set; }

      
    }


}