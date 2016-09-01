namespace CurrencyRates.Client.Subscriber
{
    partial class frmSubscriber
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtPairName = new System.Windows.Forms.TextBox();
            this.lstData = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.btnClearAstaListView = new System.Windows.Forms.Button();
            this.btnUnSubscribe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Pair Name";
            // 
            // txtPairName
            // 
            this.txtPairName.Location = new System.Drawing.Point(64, 32);
            this.txtPairName.Name = "txtPairName";
            this.txtPairName.Size = new System.Drawing.Size(102, 20);
            this.txtPairName.TabIndex = 33;
            // 
            // lstData
            // 
            this.lstData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6});
            this.lstData.GridLines = true;
            this.lstData.Location = new System.Drawing.Point(5, 58);
            this.lstData.MultiSelect = false;
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(592, 172);
            this.lstData.TabIndex = 31;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Item #";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Pair Name";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Data";
            this.columnHeader6.Width = 470;
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Location = new System.Drawing.Point(172, 29);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(84, 23);
            this.btnSubscribe.TabIndex = 29;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // btnClearAstaListView
            // 
            this.btnClearAstaListView.Location = new System.Drawing.Point(529, 236);
            this.btnClearAstaListView.Name = "btnClearAstaListView";
            this.btnClearAstaListView.Size = new System.Drawing.Size(68, 23);
            this.btnClearAstaListView.TabIndex = 30;
            this.btnClearAstaListView.Text = "Clear";
            this.btnClearAstaListView.UseVisualStyleBackColor = true;
            this.btnClearAstaListView.Click += new System.EventHandler(this.btnClearAstaListView_Click);
            // 
            // btnUnSubscribe
            // 
            this.btnUnSubscribe.Location = new System.Drawing.Point(172, 30);
            this.btnUnSubscribe.Name = "btnUnSubscribe";
            this.btnUnSubscribe.Size = new System.Drawing.Size(84, 23);
            this.btnUnSubscribe.TabIndex = 35;
            this.btnUnSubscribe.Text = "UnSubscribe";
            this.btnUnSubscribe.UseVisualStyleBackColor = true;
            this.btnUnSubscribe.Visible = false;
            this.btnUnSubscribe.Click += new System.EventHandler(this.btnUnSubscribe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Subscribe to a currency pair";
            // 
            // frmSubscriber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 260);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUnSubscribe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPairName);
            this.Controls.Add(this.lstData);
            this.Controls.Add(this.btnSubscribe);
            this.Controls.Add(this.btnClearAstaListView);
            this.Name = "frmSubscriber";
            this.Text = "Subscriber Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPairName;
        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnSubscribe;
        private System.Windows.Forms.Button btnClearAstaListView;
        private System.Windows.Forms.Button btnUnSubscribe;
        private System.Windows.Forms.Label label1;
    }
}

