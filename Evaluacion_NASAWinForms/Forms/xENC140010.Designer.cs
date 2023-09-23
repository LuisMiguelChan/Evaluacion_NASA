namespace Evaluacion_NASAWinForms.Forms
{
    partial class xENC140010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xENC140010));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LargeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmallImageStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainApplicationMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.XtraConsoftToolBar1.Size = new System.Drawing.Size(47, 368);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(753, 368);
            this.dataGridView1.TabIndex = 7;
            // 
            // xENC140010
            // 
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("xENC140010.Appearance.Image")));
            this.Appearance.Options.UseImage = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("xENC140010.IconOptions.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "xENC140010";
            this.Text = "xENC140010";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.xENC140010_Load);
            this.Controls.SetChildIndex(this.RibbonControl, 0);
            this.Controls.SetChildIndex(this.XtraConsoftToolBar1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LargeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmallImageStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainApplicationMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
    }
}