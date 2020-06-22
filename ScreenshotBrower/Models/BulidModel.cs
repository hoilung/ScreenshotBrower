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
        public string Sku { get; internal set; }
    }
}
