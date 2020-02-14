using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace SecondTask
{
    public partial class ExchangeRate : Form
    {
        static string dollarPurchaseMinfin, dollarSaleMinfin, euroPurchaseMinfin, euroSaleMinfin, rublePurchaseMinfin, rubleSaleMinfin;
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
                dataTable.Columns.Add("Source", typeof(string));
                dataTable.Columns.Add("Currency", typeof(string));
                dataTable.Columns.Add("Purchase", typeof(string));
                dataTable.Columns.Add("Sale", typeof(string));

                GetDollarMinfin();
                System.Threading.Thread.Sleep(200);
                GetEuroMinfin();
                System.Threading.Thread.Sleep(200);
                GetRubleMinfin();
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
                MessageBox.Show("Something went wrong. Please restart the application.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static async void GetDollarMinfin()
        {
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(Constants.MinfinUrl);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var dollarDocumentListHtml = htmlDocument.DocumentNode.Descendants("td")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("mfm-text-nowrap")).ToList();

                var dollarPurchaseString = dollarDocumentListHtml[0].InnerHtml.ToString();
                string[] dollarPurchaseStringArray = dollarPurchaseString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                dollarPurchaseMinfin = dollarPurchaseStringArray[0].Trim();


                var dollarSaleString = dollarDocumentListHtml[1].InnerHtml.ToString();
                string[] dollarSaleStringArrayHtml = dollarSaleString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                string dollarSaleHtml = dollarSaleStringArrayHtml[6].Trim();
                var dollarSaleStringArray = dollarSaleHtml.Split(new[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
                dollarSaleMinfin = dollarSaleStringArray[1].Trim();

                dataTable.Rows.Add("Minfin", "USD", dollarPurchaseMinfin, dollarSaleMinfin);
            }
            catch
            {
                MessageBox.Show("Something went wrong. Please restart the application.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static async void GetEuroMinfin()
        {
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(Constants.MinfinUrl);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var euroDocumentListHtml = htmlDocument.DocumentNode.Descendants("td")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("mfm-text-nowrap")).ToList();

                var euroPurchaseString = euroDocumentListHtml[2].InnerHtml.ToString();
                string[] euroPurchaseStringArray = euroPurchaseString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                euroPurchaseMinfin = euroPurchaseStringArray[0].Trim();

                var euroSaleString = euroDocumentListHtml[3].InnerHtml.ToString();
                string[] euroSaleStringArrayHtml = euroSaleString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                string euroSaleHtml = euroSaleStringArrayHtml[6].Trim();
                var euroSaleStringArray = euroSaleHtml.Split(new[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
                euroSaleMinfin = euroSaleStringArray[1].Trim();

                dataTable.Rows.Add("Minfin", "Euro", euroPurchaseMinfin, euroSaleMinfin);
            }
            catch
            {
                MessageBox.Show("Something went wrong. Please restart the application.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static async void GetRubleMinfin()
        {
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(Constants.MinfinUrl);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var rubleDocumentListHtml = htmlDocument.DocumentNode.Descendants("td")
                   .Where(node => node.GetAttributeValue("class", "")
                   .Equals("mfm-text-nowrap")).ToList();

                var rublePurchaseString = rubleDocumentListHtml[4].InnerHtml.ToString();
                string[] rublePurchaseStringArray = rublePurchaseString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                rublePurchaseMinfin = rublePurchaseStringArray[0].Trim();

                var rubleSaleString = rubleDocumentListHtml[5].InnerHtml.ToString();
                string[] rubleSaleStringArrayHtml = rubleSaleString.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
                string rubleSaleHtml = rubleSaleStringArrayHtml[6].Trim();
                var rubleSaleStringArray = rubleSaleHtml.Split(new[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
                rubleSaleMinfin = rubleSaleStringArray[1].Trim();

                dataTable.Rows.Add("Minfin", "Ruble", rublePurchaseMinfin, rubleSaleMinfin);
            }
            catch
            {
                MessageBox.Show("Something went wrong. Please restart the application.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                dataTable.Rows.Add("KursComUa", "USD", dollarPurchaseKursComUa, dollarSaleKursComUa);
            }
            catch
            {
                MessageBox.Show("Something went wrong. Please restart the application.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                dataTable.Rows.Add("KursComUa", "Euro", euroPurchaseKursComUa, euroSaleKursComUa);
            }
            catch
            {
                MessageBox.Show("Something went wrong. Please restart the application.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                dataTable.Rows.Add("KursComUa", "Ruble", rublePurchaseKursComUa, rubleSaleKursComUa);
            }
            catch
            {
                MessageBox.Show("Something went wrong. Please restart the application.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                dataTable.Rows.Add("FinanceUa", "USD", dollarPurchaseFinanceUa, dollarSaleFinanceUa);
            }
            catch
            {
                MessageBox.Show("Something went wrong. Please restart the application.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                dataTable.Rows.Add("FinanceUa", "Euro", euroPurchaseFinanceUa, euroSaleFinanceUa);
            }
            catch
            {
                MessageBox.Show("Something went wrong. Please restart the application.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                dataTable.Rows.Add("FinanceUa", "Ruble", rublePurchaseFinanceUa, rubleSaleFinanceUa);
            }
            catch
            {
                MessageBox.Show("Something went wrong. Please restart the application.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
