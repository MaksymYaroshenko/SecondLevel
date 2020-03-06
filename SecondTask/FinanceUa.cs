using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace SecondTask
{
    class FinanceUa : CurrencyAPI
    {
        private static HtmlDocument htmlDocument;

        public override string[] GetDollar()
        {
            Task task = Task.Factory.StartNew(() => SendRequest());
            task.Wait();
            System.Threading.Thread.Sleep(1500);
            if (htmlDocument != null)
            {
                var dollarPurchaseDocumentListHtml = htmlDocument.DocumentNode.Descendants("tr")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("topcurs1")).ToList();

                var dollarDocumentList = dollarPurchaseDocumentListHtml[0].Descendants("td")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("value up")).ToList();

                var dollarPurchaseString = dollarDocumentList[0].InnerHtml.ToString();
                string[] dollarPurchaseStringArray = dollarPurchaseString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                var dollarPurchaseFinanceUa = dollarPurchaseStringArray[0];

                var dollarSaleString = dollarDocumentList[1].InnerHtml.ToString();
                string[] dollarSaleStringArray = dollarSaleString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                var dollarSaleFinanceUa = dollarSaleStringArray[0];

                return new string[] { dollarPurchaseFinanceUa, dollarSaleFinanceUa };
            }
            else
            {
                return null;
            }
        }

        public override string[] GetEuro()
        {
            if (htmlDocument != null)
            {
                var euroDocumentListHtml = htmlDocument.DocumentNode.Descendants("td")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("value up")).ToList();

                var euroPurchaseString = euroDocumentListHtml[2].InnerHtml.ToString();
                string[] euroPurchaseStringArray = euroPurchaseString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                var euroPurchaseFinanceUa = euroPurchaseStringArray[0];

                var euroSaleString = euroDocumentListHtml[3].InnerHtml.ToString();
                string[] euroSaleStringArray = euroSaleString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                var euroSaleFinanceUa = euroSaleStringArray[0];

                return new string[] { euroPurchaseFinanceUa, euroSaleFinanceUa };
            }
            else
            {
                return null;
            }
        }

        public override string[] GetRuble()
        {
            if (htmlDocument != null)
            {
                var rublePurchaseDocumentListHtml = htmlDocument.DocumentNode.Descendants("tr")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("topcurs2")).ToList();

                var rublePurchaseDocumentList = rublePurchaseDocumentListHtml[0].Descendants("td")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("value down")).ToList();

                var rublePurchaseString = rublePurchaseDocumentList[0].InnerHtml.ToString();
                string[] rublePurchaseStringArray = rublePurchaseString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                var rublePurchaseFinanceUa = rublePurchaseStringArray[0];

                var rubleSaleDocumentList = rublePurchaseDocumentListHtml[0].Descendants("td")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("value")).ToList();

                var rubleSaleString = rubleSaleDocumentList[0].InnerHtml.ToString();
                string[] rubleSaleStringArray = rubleSaleString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                var rubleSaleFinanceUa = rubleSaleStringArray[0];

                return new string[] { rublePurchaseFinanceUa, rubleSaleFinanceUa };
            }
            else
            {
                return null;
            }
        }

        private static async void SendRequest()
        {
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(Constants.FinanceUaUrl);

                htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
