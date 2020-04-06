using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenshotBrower.Models
{
    public class OrderModel
    {
        /// <summary>
        /// 订单详情链接
        /// </summary>
        public string DetailLink { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DetailNum { get; set; }

        /// <summary>
        /// 详情编号链接
        /// </summary>
        public string DetailNumLink
        {
            get
            {
                return $"sellercentral.amazon.com/orders-v3/order/{this.DetailNum}";
            }
        }
        /// <summary>
        /// 发票链接
        /// </summary>
        public string InvoiceLink
        {
            get
            {
                return DetailLink.Replace("/info?id", "/invoice?id");

            }
        }
    }

    public class OdrderList
    {
        public string OrderLink { get; set; } = string.Empty;
        public string OrderHtml { get; set; } = string.Empty;

        public List<OrderModel> Orders { get; set; } = new List<OrderModel>();

        public void OrderPase()
        {
            Orders.Clear();

            var htmldoc = new HtmlAgilityPack.HtmlDocument();
            htmldoc.LoadHtml(OrderHtml);
            var nodea = htmldoc.DocumentNode.SelectNodes("//table//tr/td[@class='details']/a[1]");

            if (nodea != null && nodea.Any())
            {
                foreach (var item in nodea)
                {
                    var orderModel = new Models.OrderModel();
                    orderModel.DetailLink = System.IO.Path.Combine(OrderLink, item.GetAttributeValue("href", "").Trim());
                    orderModel.DetailNum = item.InnerText.Trim();
                    this.Orders.Add(orderModel);
                }

            }
        }
    }
}
