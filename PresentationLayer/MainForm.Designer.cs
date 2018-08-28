namespace PresentationLayer
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuManager = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMembership = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackgroundImage = global::PresentationLayer.Properties.Resources.menuBg;
            this.menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(128, 128);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManager,
            this.menuMembership,
            this.menuExit});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 136);
            this.menuStrip.Stretch = false;
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuManager
            // 
            this.menuManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuManager.DoubleClickEnabled = true;
            this.menuManager.Image = global::PresentationLayer.Properties.Resources.Manager;
            this.menuManager.Name = "menuManager";
            this.menuManager.Size = new System.Drawing.Size(140, 132);
            this.menuManager.Text = "toolStripMenuItem1";
            this.menuManager.DoubleClick += new System.EventHandler(this.menuManager_DoubleClick);
            // 
            // menuMembership
            // 
            this.menuMembership.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuMembership.DoubleClickEnabled = true;
            this.menuMembership.Image = global::PresentationLayer.Properties.Resources.Membership;
            this.menuMembership.Name = "menuMembership";
            this.menuMembership.Size = new System.Drawing.Size(140, 132);
            this.menuMembership.DoubleClick += new System.EventHandler(this.menuMembership_DoubleClick);
            // 
            // menuExit
            // 
            this.menuExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuExit.DoubleClickEnabled = true;
            this.menuExit.Image = global::PresentationLayer.Properties.Resources.Exit2;
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(140, 132);
            this.menuExit.DoubleClick += new System.EventHandler(this.menuExit_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuManager;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuMembership;
    }
}