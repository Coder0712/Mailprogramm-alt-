namespace MailProgramm
{
    partial class Form1
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
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._accountListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._mailBoxlistView = new System.Windows.Forms.ListView();
            this.subjectColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.receivedDateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendAndReceiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._webView)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(469, 721);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(8, 8);
            this.hScrollBar1.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._accountListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1320, 532);
            this.splitContainer1.SplitterDistance = 247;
            this.splitContainer1.TabIndex = 7;
            // 
            // _accountListView
            // 
            this._accountListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this._accountListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._accountListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this._accountListView.HideSelection = false;
            this._accountListView.Location = new System.Drawing.Point(0, 0);
            this._accountListView.Name = "_accountListView";
            this._accountListView.Size = new System.Drawing.Size(247, 532);
            this._accountListView.TabIndex = 10;
            this._accountListView.UseCompatibleStateImageBehavior = false;
            this._accountListView.View = System.Windows.Forms.View.Details;
            this._accountListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this._accountListView_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 200;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this._mailBoxlistView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this._webView);
            this.splitContainer2.Size = new System.Drawing.Size(1069, 532);
            this.splitContainer2.SplitterDistance = 406;
            this.splitContainer2.TabIndex = 8;
            // 
            // _mailBoxlistView
            // 
            this._mailBoxlistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.subjectColumn,
            this.receivedDateColumn});
            this._mailBoxlistView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mailBoxlistView.FullRowSelect = true;
            this._mailBoxlistView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._mailBoxlistView.HideSelection = false;
            this._mailBoxlistView.Location = new System.Drawing.Point(0, 0);
            this._mailBoxlistView.MultiSelect = false;
            this._mailBoxlistView.Name = "_mailBoxlistView";
            this._mailBoxlistView.Size = new System.Drawing.Size(406, 532);
            this._mailBoxlistView.TabIndex = 0;
            this._mailBoxlistView.UseCompatibleStateImageBehavior = false;
            this._mailBoxlistView.View = System.Windows.Forms.View.Details;
            this._mailBoxlistView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this._mailBoxlistView_ItemSelectionChanged);
            // 
            // subjectColumn
            // 
            this.subjectColumn.Text = "Betreff";
            this.subjectColumn.Width = 250;
            // 
            // receivedDateColumn
            // 
            this.receivedDateColumn.Text = "Erhalten";
            this.receivedDateColumn.Width = 120;
            // 
            // _webView
            // 
            this._webView.CreationProperties = null;
            this._webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this._webView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._webView.Location = new System.Drawing.Point(0, 0);
            this._webView.Name = "_webView";
            this._webView.Size = new System.Drawing.Size(659, 532);
            this._webView.TabIndex = 0;
            this._webView.ZoomFactor = 1D;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.sendAndReceiveToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1320, 24);
            this.menuStrip2.TabIndex = 9;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.accountToolStripMenuItem.Text = "Create Account";
            this.accountToolStripMenuItem.Click += new System.EventHandler(this.accountToolStripMenuItem_Click);
            // 
            // sendAndReceiveToolStripMenuItem
            // 
            this.sendAndReceiveToolStripMenuItem.Enabled = false;
            this.sendAndReceiveToolStripMenuItem.Name = "sendAndReceiveToolStripMenuItem";
            this.sendAndReceiveToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.sendAndReceiveToolStripMenuItem.Text = "Send and Receive";
            this.sendAndReceiveToolStripMenuItem.Click += new System.EventHandler(this.sendAndReceiveToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 556);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.menuStrip2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mail";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._webView)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView _mailBoxlistView;
        private System.Windows.Forms.ColumnHeader subjectColumn;
        private System.Windows.Forms.ColumnHeader receivedDateColumn;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ListView _accountListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private Microsoft.Web.WebView2.WinForms.WebView2 _webView;
        private System.Windows.Forms.ToolStripMenuItem sendAndReceiveToolStripMenuItem;
    }
}