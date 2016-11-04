
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/**
* 命名空间: LanguageFeatures.Controllers
*
* 功 能： N/A
* 类 名： Beer
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016-11-04 16:48:36 杨伟贤 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：*****有限公司 　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
namespace LanguageFeatures.Controllers {
    public class Beer {

        public int id { get; set; }
        public int Cap { get; set; }
        public int Bottle { get; set; }
        public override string ToString() {
            return string.Format("Cap{0},Bottle,{1}",Cap,Bottle);
        }

        public bool primit() {
            return (0 < id &&id<5) ? true : false;            
        }
    }
}