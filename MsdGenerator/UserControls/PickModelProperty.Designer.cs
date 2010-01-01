namespace MsdGenerator.UserControls
{
    partial class PickModelProperty
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickModelProperty));
            this.tS = new System.Windows.Forms.ToolStrip();
            this.MainBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.tS.SuspendLayout();
            this.SuspendLayout();
            // 
            // tS
            // 
            this.tS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainBtn});
            this.tS.Location = new System.Drawing.Point(0, 0);
            this.tS.Name = "tS";
            this.tS.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tS.Size = new System.Drawing.Size(312, 133);
            this.tS.TabIndex = 0;
            this.tS.Text = "toolStrip1";
            // 
            // MainBtn
            // 
            this.MainBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MainBtn.Image = ((System.Drawing.Image)(resources.GetObject("MainBtn.Image")));
            this.MainBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MainBtn.Name = "MainBtn";
            this.MainBtn.Size = new System.Drawing.Size(47, 130);
            this.MainBtn.Text = "Main";
            // 
            // PickModelProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tS);
            this.Name = "PickModelProperty";
            this.Size = new System.Drawing.Size(312, 133);
            this.tS.ResumeLayout(false);
            this.tS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tS;
        private System.Windows.Forms.ToolStripDropDownButton MainBtn;
    }
}
