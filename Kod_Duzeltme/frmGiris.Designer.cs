namespace Kod_Duzeltme
{
    partial class frmGiris
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
            this.btnGiris = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRepoAdı = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbGithubAd = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGiris
            // 
            this.btnGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiris.Location = new System.Drawing.Point(83, 273);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(229, 34);
            this.btnGiris.TabIndex = 0;
            this.btnGiris.Text = "Giris Yap";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(21, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Repositorie Adı:";
            // 
            // cmbRepoAdı
            // 
            this.cmbRepoAdı.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbRepoAdı.FormattingEnabled = true;
            this.cmbRepoAdı.Items.AddRange(new object[] {
            "talhadrz.github.io",
            "projeler"});
            this.cmbRepoAdı.Location = new System.Drawing.Point(203, 199);
            this.cmbRepoAdı.Name = "cmbRepoAdı";
            this.cmbRepoAdı.Size = new System.Drawing.Size(178, 30);
            this.cmbRepoAdı.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(59, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Github İsmi:";
            // 
            // cmbGithubAd
            // 
            this.cmbGithubAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbGithubAd.FormattingEnabled = true;
            this.cmbGithubAd.Items.AddRange(new object[] {
            "talhadrz"});
            this.cmbGithubAd.Location = new System.Drawing.Point(203, 163);
            this.cmbGithubAd.Name = "cmbGithubAd";
            this.cmbGithubAd.Size = new System.Drawing.Size(178, 30);
            this.cmbGithubAd.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(106, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Token:";
            // 
            // txtToken
            // 
            this.txtToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtToken.Location = new System.Drawing.Point(203, 129);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(178, 28);
            this.txtToken.TabIndex = 7;
            // 
            // frmGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(412, 351);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbGithubAd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbRepoAdı);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGiris);
            this.Name = "frmGiris";
            this.Text = "GİRİŞ SAYFASI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRepoAdı;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGithubAd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtToken;
    }
}