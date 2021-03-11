using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenshotBrower.Models
{
    public class BulidModel
    {

        public BulidShopModel shopModel { get; set; }

        public BuildOrderModel orderModel { get; set; }


    }
    public class BulidShopModel
    {
        public string shopname { get; set; }
        public string address { get; set; }

        public string email { get; set; }
        public string tel { get; set; }

    }

    public class BuildOrderModel
    {
        public string trademarkNo { get; set; }

        public string trademarkName { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }

        public string Asin { get; set; }

        public string OrderNum { get; set; }
        public string Sku { get; internal set; } = string.Empty;
        /// <summary>
        /// 货运价格
        /// </summary>
        public string HyPrice { get; set; }
        /// <summary>
        /// 库存上架时间
        /// </summary>
        public string UpTime { get; internal set; }
        /// <summary>
        ///库存截止日期
        /// </summary>
        public string UpendTime { get; internal set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public string KcCount { get; internal set; }
    }
}
