using System;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace SecondTask
{
    public partial class ExchangeRate : Form
    {
        static string dollarPurchaseMinfinComUa, dollarSaleMinfinComUa, euroPurchaseMinfinComUa, euroSaleMinfinComUa, rublePurchaseMinfinComUa, rubleSaleMinfinComUa;
        static string dollarPurchaseKursComUa, dollarSaleKursComUa, euroPurchaseKursComUa, euroSaleKursComUa, rublePurchaseKursComUa, rubleSaleKursComUa;
        static string dollarPurchaseFinanceUa, dollarSaleFinanceUa, euroPurchaseFinanceUa, euroSaleFinanceUa, rublePurchaseFinanceUa, rubleSaleFinanceUa;
        static DataTable dataTable = new DataTable();

        public ExchangeRate()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void LoadData_Click(object sender, EventArgs e)
        {
            try
            {
                dataTable.Columns.Add(Properties.Resources.ResourceColumnTitle, typeof(string));
                dataTable.Columns.Add(Properties.Resources.CurrencyColumnTitle, typeof(string));
                dataTable.Columns.Add(Properties.Resources.PurchaseColumnTitle, typeof(string));
                dataTable.Columns.Add(Properties.Resources.SaleColumnTitle, typeof(string));

                GetDollarMinfinComUa();
                System.Threading.Thread.Sleep(200);
                GetEuroMinfinComUa();
                System.Threading.Thread.Sleep(200);
                GetRubleMinfinComUa();
                System.Threading.Thread.Sleep(200);
                GetDollarFinanceUa();
                System.Threading.Thread.Sleep(200);
                GetEuroFinanceUa();
                System.Threading.Thread.Sleep(200);
                GetRubleFinanceUa();
                System.Threading.Thread.Sleep(200);
                GetDollarKursComUa();
                System.Threading.Thread.Sleep(200);
                GetEuroKursComUa();
                System.Threading.Thread.Sleep(200);
                GetRubleKursComUa();

                dataCurrencyTable.DataSource = dataTable;
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static async void GetDollarMinfinComUa()
        {
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(Constants.MinfinComUaUrl);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var dollarDocumentListHtml = htmlDocument.DocumentNode.Descendants("td")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("mfm-text-nowrap")).ToList();

                var dollarPurchaseString = dollarDocumentListHtml[0].InnerHtml.ToString();
                string[] dollarPurchaseStringArray = dollarPurchaseString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                dollarPurchaseMinfinComUa = dollarPurchaseStringArray[0].Trim();


                var dollarSaleString = dollarDocumentListHtml[1].InnerHtml.ToString();
                string[] dollarSaleStringArrayHtml = dollarSaleString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                string dollarSaleHtml = dollarSaleStringArrayHtml[6].Trim();
                var dollarSaleStringArray = dollarSaleHtml.Split(new[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
                dollarSaleMinfinComUa = dollarSaleStringArray[1].Trim();

                dataTable.Rows.Add(Properties.Resources.MinfinComUaTitle, Properties.Resources.Dollar, dollarPurchaseMinfinComUa, dollarSaleMinfinComUa);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static async void GetEuroMinfinComUa()
        {
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(Constants.MinfinComUaUrl);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var euroDocumentListHtml = htmlDocument.DocumentNode.Descendants("td")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("mfm-text-nowrap")).ToList();

                var euroPurchaseString = euroDocumentListHtml[2].InnerHtml.ToString();
                string[] euroPurchaseStringArray = euroPurchaseString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                euroPurchaseMinfinComUa = euroPurchaseStringArray[0].Trim();

                var euroSaleString = euroDocumentListHtml[3].InnerHtml.ToString();
                string[] euroSaleStringArrayHtml = euroSaleString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                string euroSaleHtml = euroSaleStringArrayHtml[6].Trim();
                var euroSaleStringArray = euroSaleHtml.Split(new[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
                euroSaleMinfinComUa = euroSaleStringArray[1].Trim();

                dataTable.Rows.Add(Properties.Resources.MinfinComUaTitle, Properties.Resources.Euro, euroPurchaseMinfinComUa, euroSaleMinfinComUa);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static async void GetRubleMinfinComUa()
        {
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(Constants.MinfinComUaUrl);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var rubleDocumentListHtml = htmlDocument.DocumentNode.Descendants("td")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("mfm-text-nowrap")).ToList();

                var rublePurchaseString = rubleDocumentListHtml[4].InnerHtml.ToString();
                string[] rublePurchaseStringArray = rublePurchaseString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                rublePurchaseMinfinComUa = rublePurchaseStringArray[0].Trim();

                var rubleSaleString = rubleDocumentListHtml[5].InnerHtml.ToString();
                string[] rubleSaleStringArrayHtml = rubleSaleString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                string rubleSaleHtml = rubleSaleStringArrayHtml[6].Trim();
                var rubleSaleStringArray = rubleSaleHtml.Split(new[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
                rubleSaleMinfinComUa = rubleSaleStringArray[1].Trim();

                dataTable.Rows.Add(Properties.Resources.MinfinComUaTitle, Properties.Resources.Ruble, rublePurchaseMinfinComUa, rubleSaleMinfinComUa);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static async void GetDollarKursComUa()
        {
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(Constants.KursComUaUrl);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var dollarDocumentListHtml = htmlDocument.DocumentNode.Descendants("div")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("course_first")).ToList();

                var dollarPurchaseString = dollarDocumentListHtml[0].InnerHtml.ToString();
                string[] dollarPurchaseStringArray = dollarPurchaseString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                dollarPurchaseKursComUa = dollarPurchaseStringArray[0];

                var dollarSaleString = dollarDocumentListHtml[1].InnerHtml.ToString();
                string[] dollarSaleStringArray = dollarSaleString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                dollarSaleKursComUa = dollarSaleStringArray[0];

                dataTable.Rows.Add(Properties.Resources.KursComUaTitle, Properties.Resources.Dollar, dollarPurchaseKursComUa, dollarSaleKursComUa);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static async void GetEuroKursComUa()
        {
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(Constants.KursComUaUrl);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var euroDocumentListHtml = htmlDocument.DocumentNode.Descendants("div")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("course_first")).ToList();

                var euroPurchaseString = euroDocumentListHtml[4].InnerHtml.ToString();
                string[] euroPurchaseStringArray = euroPurchaseString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                euroPurchaseKursComUa = euroPurchaseStringArray[0];

                var euroSaleString = euroDocumentListHtml[5].InnerHtml.ToString();
                string[] euroSaleStringArray = euroSaleString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                euroSaleKursComUa = euroSaleStringArray[0];

                dataTable.Rows.Add(Properties.Resources.KursComUaTitle, Properties.Resources.Euro, euroPurchaseKursComUa, euroSaleKursComUa);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static async void GetRubleKursComUa()
        {
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(Constants.KursComUaUrl);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var rubleDocumentListHtml = htmlDocument.DocumentNode.Descendants("div")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("course_first")).ToList();

                var rublePurchaseString = rubleDocumentListHtml[8].InnerHtml.ToString();
                string[] rublePurchaseStringArray = rublePurchaseString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                rublePurchaseKursComUa = rublePurchaseStringArray[0];

                var rubleSaleString = rubleDocumentListHtml[9].InnerHtml.ToString();
                string[] rubleSaleStringArray = rubleSaleString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                rubleSaleKursComUa = rubleSaleStringArray[0];

                dataTable.Rows.Add(Properties.Resources.KursComUaTitle, Properties.Resources.Ruble, rublePurchaseKursComUa, rubleSaleKursComUa);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static async void GetDollarFinanceUa()
        {
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(Constants.FinanceUaUrl);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var dollarPurchaseDocumentListHtml = htmlDocument.DocumentNode.Descendants("tr")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("topcurs1")).ToList();

                var dollarPurchaseDocumentList = dollarPurchaseDocumentListHtml[0].Descendants("td")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("value")).ToList();

                var dollarPurchaseString = dollarPurchaseDocumentList[0].InnerHtml.ToString();
                string[] dollarPurchaseStringArray = dollarPurchaseString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                dollarPurchaseFinanceUa = dollarPurchaseStringArray[0];

                var dollarSaleDocumentList = dollarPurchaseDocumentListHtml[0].Descendants("td")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("value")).ToList();

                var dollarSaleString = dollarSaleDocumentList[1].InnerHtml.ToString();
                string[] dollarSaleStringArray = dollarSaleString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                dollarSaleFinanceUa = dollarSaleStringArray[0];

                dataTable.Rows.Add(Properties.Resources.FinanceUaTitle, Properties.Resources.Dollar, dollarPurchaseFinanceUa, dollarSaleFinanceUa);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static async void GetEuroFinanceUa()
        {
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(Constants.FinanceUaUrl);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var euroDocumentListHtml = htmlDocument.DocumentNode.Descendants("td")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("value")).ToList();

                var euroPurchaseString = euroDocumentListHtml[2].InnerHtml.ToString();
                string[] euroPurchaseStringArray = euroPurchaseString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                euroPurchaseFinanceUa = euroPurchaseStringArray[0];

                var euroSaleString = euroDocumentListHtml[3].InnerHtml.ToString();
                string[] euroSaleStringArray = euroSaleString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                euroSaleFinanceUa = euroSaleStringArray[0];

                dataTable.Rows.Add(Properties.Resources.FinanceUaTitle, Properties.Resources.Euro, euroPurchaseFinanceUa, euroSaleFinanceUa);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static async void GetRubleFinanceUa()
        {
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(Constants.FinanceUaUrl);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var rublePurchaseDocumentListHtml = htmlDocument.DocumentNode.Descendants("tr")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("topcurs2")).ToList();

                var rublePurchaseDocumentList = rublePurchaseDocumentListHtml[0].Descendants("td")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("value")).ToList();

                var rublePurchaseString = rublePurchaseDocumentList[0].InnerHtml.ToString();
                string[] rublePurchaseStringArray = rublePurchaseString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                rublePurchaseFinanceUa = rublePurchaseStringArray[0];

                var rubleSaleDocumentList = rublePurchaseDocumentListHtml[0].Descendants("td")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("value")).ToList();

                var rubleSaleString = rubleSaleDocumentList[1].InnerHtml.ToString();
                string[] rubleSaleStringArray = rubleSaleString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                rubleSaleFinanceUa = rubleSaleStringArray[0];

                dataTable.Rows.Add(Properties.Resources.FinanceUaTitle, Properties.Resources.Ruble, rublePurchaseFinanceUa, rubleSaleFinanceUa);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
