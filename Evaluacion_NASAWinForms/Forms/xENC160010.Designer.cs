namespace Evaluacion_NASAWinForms.Forms
{
    partial class xENC160010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xENC160010));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LargeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmallImageStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainApplicationMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // RibbonControl
            // 
            this.RibbonControl.ApplicationButtonImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("RibbonControl.ApplicationButtonImageOptions.Image")));
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            // 
            // 
            // 
            this.RibbonControl.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.RibbonControl.SearchEditItem.EditWidth = 150;
            this.RibbonControl.SearchEditItem.Id = -5000;
            this.RibbonControl.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.RibbonControl.Size = new System.Drawing.Size(800, 49);
            this.RibbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // MainDefaultLookAndFeel
            // 
            this.MainDefaultLookAndFeel.LookAndFeel.SkinName = "DevExpress Style";
            // 
            // LargeImage
            // 
            this.LargeImage.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("LargeImage.ImageStream")));
            this.LargeImage.Images.SetKeyName(0, "Documents New_32x32.png");
            this.LargeImage.Images.SetKeyName(1, "Documents Timestamp_32x32.png");
            this.LargeImage.Images.SetKeyName(2, "Documents Check Out_32x32.png");
            this.LargeImage.Images.SetKeyName(3, "Documents Check_32x32.png");
            this.LargeImage.Images.SetKeyName(4, "Documents Delete_32x32.png");
            this.LargeImage.Images.SetKeyName(5, "Perspective Save Configuration_32x32.png");
            this.LargeImage.Images.SetKeyName(6, "Group_32x32.png");
            this.LargeImage.Images.SetKeyName(7, "Shipping 2.png");
            this.LargeImage.Images.SetKeyName(8, "Software.png");
            this.LargeImage.Images.SetKeyName(9, "Bank 2 Add_32x32.png");
            this.LargeImage.Images.SetKeyName(10, "Building_32x32.png");
            this.LargeImage.Images.SetKeyName(11, "Graphic-Design_32x32.png");
            this.LargeImage.Images.SetKeyName(12, "Industrial_32x32.png");
            this.LargeImage.Images.SetKeyName(13, "Industrial-2_32x32.png");
            this.LargeImage.Images.SetKeyName(14, "Mathematics_32x32.png");
            this.LargeImage.Images.SetKeyName(15, "Printing-and-Publishing_32x32.png");
            this.LargeImage.Images.SetKeyName(16, "Security_32x32.png");
            this.LargeImage.Images.SetKeyName(17, "Mail List.png");
            this.LargeImage.Images.SetKeyName(18, "Logout.png");
            this.LargeImage.Images.SetKeyName(19, "Check Book.png");
            this.LargeImage.Images.SetKeyName(20, "confg_32.png");
            // 
            // SmallImageStatus
            // 
            this.SmallImageStatus.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("SmallImageStatus.ImageStream")));
            this.SmallImageStatus.Images.SetKeyName(0, "User 3_12x12.png");
            this.SmallImageStatus.Images.SetKeyName(1, "Software.png");
            this.SmallImageStatus.Images.SetKeyName(2, "Window.png");
            this.SmallImageStatus.Images.SetKeyName(3, "Symbol New.png");
            this.SmallImageStatus.Images.SetKeyName(4, "Symbol Information 2.png");
            this.SmallImageStatus.Images.SetKeyName(5, "Email Edit 2.png");
            this.SmallImageStatus.Images.SetKeyName(6, "Flag.png");
            // 
            // XtraConsoftToolBar1
            // 
            this.XtraConsoftToolBar1.Location = new System.Drawing.Point(753, 49);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.chart1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 49);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(753, 370);
            this.layoutControl1.TabIndex = 7;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(753, 370);
            this.Root.TextVisible = false;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(109, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(632, 346);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chart1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(733, 350);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(93, 13);
            // 
            // xENC160010
            // 
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("xENC160010.Appearance.Image")));
            this.Appearance.Options.UseImage = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutControl1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("xENC160010.IconOptions.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "xENC160010";
            this.Text = "xENC160010";
            this.Load += new System.EventHandler(this.xENC160010_Load);
            this.Controls.SetChildIndex(this.RibbonControl, 0);
            this.Controls.SetChildIndex(this.XtraConsoftToolBar1, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LargeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmallImageStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainApplicationMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}