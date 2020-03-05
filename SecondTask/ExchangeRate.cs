using System;
using System.Data;
using System.Windows.Forms;

namespace SecondTask
{
    public partial class ExchangeRate : Form
    {
        static string dollarPurchaseMinfinComUa, dollarSaleMinfinComUa, euroPurchaseMinfinComUa, euroSaleMinfinComUa, rublePurchaseMinfinComUa, rubleSaleMinfinComUa;
        static string dollarPurchaseKursComUa, dollarSaleKursComUa, euroPurchaseKursComUa, euroSaleKursComUa, rublePurchaseKursComUa, rubleSaleKursComUa;
        static string dollarPurchaseFinanceUa, dollarSaleFinanceUa, euroPurchaseFinanceUa, euroSaleFinanceUa, rublePurchaseFinanceUa, rubleSaleFinanceUa;


        public ExchangeRate()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void LoadData_Click(object sender, EventArgs e)
        {
            LoadMinfinComUaData();
            LoadKursComUaData();
            LoadFinanceUaData();
            dataCurrencyTable.DataSource = SetData();
        }

        public static void LoadMinfinComUaData()
        {
            try
            {
                MinfinComUa minfinComUa = new MinfinComUa();
                var dollarMinfinComUa = minfinComUa.GetDollar();
                if (dollarMinfinComUa != null)
                {
                    dollarPurchaseMinfinComUa = dollarMinfinComUa[0];
                    dollarSaleMinfinComUa = dollarMinfinComUa[1];
                }
                var euroMinfinComUa = minfinComUa.GetEuro();
                if (euroMinfinComUa != null)
                {
                    euroPurchaseMinfinComUa = euroMinfinComUa[0];
                    euroSaleMinfinComUa = euroMinfinComUa[1];
                }
                var rubleMinfinComUa = minfinComUa.GetRuble();
                if (rubleMinfinComUa != null)
                {
                    rublePurchaseMinfinComUa = rubleMinfinComUa[0];
                    rubleSaleMinfinComUa = rubleMinfinComUa[1];
                }
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void LoadKursComUaData()
        {
            try
            {
                KursComUa kursComUa = new KursComUa();
                var dollarKursKomUa = kursComUa.GetDollar();
                if (dollarKursKomUa != null)
                {
                    dollarPurchaseKursComUa = dollarKursKomUa[0];
                    dollarSaleKursComUa = dollarKursKomUa[1];
                }
                var euroKursKomUa = kursComUa.GetEuro();
                if (euroKursKomUa != null)
                {
                    euroPurchaseKursComUa = euroKursKomUa[0];
                    euroSaleKursComUa = euroKursKomUa[1];
                }
                var rubleKursKomUa = kursComUa.GetRuble();
                if (rubleKursKomUa != null)
                {
                    rublePurchaseKursComUa = rubleKursKomUa[0];
                    rubleSaleKursComUa = rubleKursKomUa[1];
                }
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void LoadFinanceUaData()
        {
            try
            {
                FinanceUa financeUa = new FinanceUa();
                var dollarFinanceUa = financeUa.GetDollar();
                if (dollarFinanceUa != null)
                {
                    dollarPurchaseFinanceUa = dollarFinanceUa[0];
                    dollarSaleFinanceUa = dollarFinanceUa[1];
                }
                var euroFinanceUa = financeUa.GetEuro();
                if (euroFinanceUa != null)
                {
                    euroPurchaseFinanceUa = euroFinanceUa[0];
                    euroSaleFinanceUa = euroFinanceUa[1];
                }
                var rubleFinanceUa = financeUa.GetRuble();
                if (rubleFinanceUa != null)
                {
                    rublePurchaseFinanceUa = rubleFinanceUa[0];
                    rubleSaleFinanceUa = rubleFinanceUa[1];
                }
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static DataTable SetData()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(Properties.Resources.ResourceColumnTitle, typeof(string));
            dataTable.Columns.Add(Properties.Resources.CurrencyColumnTitle, typeof(string));
            dataTable.Columns.Add(Properties.Resources.PurchaseColumnTitle, typeof(string));
            dataTable.Columns.Add(Properties.Resources.SaleColumnTitle, typeof(string));
            dataTable.Rows.Add(Properties.Resources.MinfinComUaTitle, Properties.Resources.Dollar, dollarPurchaseMinfinComUa, dollarSaleMinfinComUa);
            dataTable.Rows.Add(Properties.Resources.MinfinComUaTitle, Properties.Resources.Euro, euroPurchaseMinfinComUa, euroSaleMinfinComUa);
            dataTable.Rows.Add(Properties.Resources.MinfinComUaTitle, Properties.Resources.Ruble, rublePurchaseMinfinComUa, rubleSaleMinfinComUa);
            dataTable.Rows.Add(Properties.Resources.KursComUaTitle, Properties.Resources.Dollar, dollarPurchaseKursComUa, dollarSaleKursComUa);
            dataTable.Rows.Add(Properties.Resources.KursComUaTitle, Properties.Resources.Euro, euroPurchaseKursComUa, euroSaleKursComUa);
            dataTable.Rows.Add(Properties.Resources.KursComUaTitle, Properties.Resources.Ruble, rublePurchaseKursComUa, rubleSaleKursComUa);
            dataTable.Rows.Add(Properties.Resources.FinanceUaTitle, Properties.Resources.Dollar, dollarPurchaseFinanceUa, dollarSaleFinanceUa);
            dataTable.Rows.Add(Properties.Resources.FinanceUaTitle, Properties.Resources.Euro, euroPurchaseFinanceUa, euroSaleFinanceUa);
            dataTable.Rows.Add(Properties.Resources.FinanceUaTitle, Properties.Resources.Ruble, rublePurchaseFinanceUa, rubleSaleFinanceUa);

            return dataTable;
        }
    }
}
