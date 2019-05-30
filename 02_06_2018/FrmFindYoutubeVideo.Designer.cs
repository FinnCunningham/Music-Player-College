namespace _02_06_2018
{
    partial class FrmFindYoutubeVideo
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
            this.rtbVideos = new System.Windows.Forms.RichTextBox();
            this.txtVideoName = new System.Windows.Forms.TextBox();
            this.btnFindVideos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbVideos
            // 
            this.rtbVideos.Location = new System.Drawing.Point(88, 157);
            this.rtbVideos.Name = "rtbVideos";
            this.rtbVideos.Size = new System.Drawing.Size(628, 494);
            this.rtbVideos.TabIndex = 2;
            this.rtbVideos.Text = "";
            this.rtbVideos.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbVideos_LinkClicked);
            // 
            // txtVideoName
            // 
            this.txtVideoName.Location = new System.Drawing.Point(100, 81);
            this.txtVideoName.Name = "txtVideoName";
            this.txtVideoName.Size = new System.Drawing.Size(174, 20);
            this.txtVideoName.TabIndex = 0;
            // 
            // btnFindVideos
            // 
            this.btnFindVideos.Location = new System.Drawing.Point(302, 111);
            this.btnFindVideos.Name = "btnFindVideos";
            this.btnFindVideos.Size = new System.Drawing.Size(121, 40);
            this.btnFindVideos.TabIndex = 1;
            this.btnFindVideos.Text = "Find Videos";
            this.btnFindVideos.UseVisualStyleBackColor = true;
            this.btnFindVideos.Click += new System.EventHandler(this.btnFindVideos_Click);
            // 
            // FrmFindYoutubeVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 663);
            this.Controls.Add(this.btnFindVideos);
            this.Controls.Add(this.txtVideoName);
            this.Controls.Add(this.rtbVideos);
            this.Name = "FrmFindYoutubeVideo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmFindYoutubeVideo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbVideos;
        private System.Windows.Forms.TextBox txtVideoName;
        private System.Windows.Forms.Button btnFindVideos;
    }
}