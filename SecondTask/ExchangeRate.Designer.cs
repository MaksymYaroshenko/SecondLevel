namespace SecondTask
{
    partial class ExchangeRate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadData = new System.Windows.Forms.Button();
            this.dataCurrencyTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataCurrencyTable)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadData
            // 
            this.LoadData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadData.Location = new System.Drawing.Point(283, 12);
            this.LoadData.Name = "LoadData";
            this.LoadData.Size = new System.Drawing.Size(179, 41);
            this.LoadData.TabIndex = 0;
            this.LoadData.Text = "Load Data";
            this.LoadData.UseVisualStyleBackColor = true;
            this.LoadData.Click += new System.EventHandler(this.LoadData_Click);
            // 
            // dataCurrencyTable
            // 
            this.dataCurrencyTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataCurrencyTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataCurrencyTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCurrencyTable.Location = new System.Drawing.Point(67, 59);
            this.dataCurrencyTable.Name = "dataCurrencyTable";
            this.dataCurrencyTable.RowHeadersWidth = 51;
            this.dataCurrencyTable.RowTemplate.Height = 24;
            this.dataCurrencyTable.Size = new System.Drawing.Size(610, 325);
            this.dataCurrencyTable.TabIndex = 1;
            // 
            // ExchangeRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 435);
            this.Controls.Add(this.dataCurrencyTable);
            this.Controls.Add(this.LoadData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExchangeRate";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Exchange Rate";
            ((System.ComponentModel.ISupportInitialize)(this.dataCurrencyTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadData;
        private System.Windows.Forms.DataGridView dataCurrencyTable;
    }
}

