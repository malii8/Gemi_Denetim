namespace VeriTabanıProje
{
    partial class BakimKaydiDetay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BakimKaydiDetay));
            this.dateTimePickerSonBakimTarihi = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBirSonrakiBakimTarihi = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxBakimDurumu = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAciklama = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonIptal = new System.Windows.Forms.Button();
            this.buttonKaydet = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblKucult = new System.Windows.Forms.Label();
            this.lblKapat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerSonBakimTarihi
            // 
            this.dateTimePickerSonBakimTarihi.Location = new System.Drawing.Point(193, 72);
            this.dateTimePickerSonBakimTarihi.Name = "dateTimePickerSonBakimTarihi";
            this.dateTimePickerSonBakimTarihi.Size = new System.Drawing.Size(224, 22);
            this.dateTimePickerSonBakimTarihi.TabIndex = 0;
            // 
            // dateTimePickerBirSonrakiBakimTarihi
            // 
            this.dateTimePickerBirSonrakiBakimTarihi.Location = new System.Drawing.Point(690, 73);
            this.dateTimePickerBirSonrakiBakimTarihi.Name = "dateTimePickerBirSonrakiBakimTarihi";
            this.dateTimePickerBirSonrakiBakimTarihi.Size = new System.Drawing.Size(224, 22);
            this.dateTimePickerBirSonrakiBakimTarihi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(166)))));
            this.label1.Location = new System.Drawing.Point(57, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "SonBakimTarihi";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(166)))));
            this.label2.Location = new System.Drawing.Point(502, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bir Sonraki BakimTarihi";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBoxBakimDurumu
            // 
            this.comboBoxBakimDurumu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(199)))), ((int)(((byte)(217)))));
            this.comboBoxBakimDurumu.FormattingEnabled = true;
            this.comboBoxBakimDurumu.Location = new System.Drawing.Point(690, 127);
            this.comboBoxBakimDurumu.Name = "comboBoxBakimDurumu";
            this.comboBoxBakimDurumu.Size = new System.Drawing.Size(148, 24);
            this.comboBoxBakimDurumu.TabIndex = 4;
            this.comboBoxBakimDurumu.SelectedIndexChanged += new System.EventHandler(this.comboBoxBakimDurumu_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(166)))));
            this.label3.Location = new System.Drawing.Point(562, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bakim Durumu";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxAciklama
            // 
            this.textBoxAciklama.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(199)))), ((int)(((byte)(217)))));
            this.textBoxAciklama.Location = new System.Drawing.Point(193, 129);
            this.textBoxAciklama.Name = "textBoxAciklama";
            this.textBoxAciklama.Size = new System.Drawing.Size(112, 22);
            this.textBoxAciklama.TabIndex = 6;
            this.textBoxAciklama.TextChanged += new System.EventHandler(this.textBoxAciklama_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(166)))));
            this.label4.Location = new System.Drawing.Point(102, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Aciklama";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // buttonIptal
            // 
            this.buttonIptal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.buttonIptal.Location = new System.Drawing.Point(155, 193);
            this.buttonIptal.Name = "buttonIptal";
            this.buttonIptal.Size = new System.Drawing.Size(137, 56);
            this.buttonIptal.TabIndex = 8;
            this.buttonIptal.Text = "İPTAL";
            this.buttonIptal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonIptal.UseVisualStyleBackColor = false;
            this.buttonIptal.Click += new System.EventHandler(this.buttonIptal_Click);
            // 
            // buttonKaydet
            // 
            this.buttonKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.buttonKaydet.Location = new System.Drawing.Point(701, 193);
            this.buttonKaydet.Name = "buttonKaydet";
            this.buttonKaydet.Size = new System.Drawing.Size(137, 56);
            this.buttonKaydet.TabIndex = 9;
            this.buttonKaydet.Text = "KAYDET";
            this.buttonKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonKaydet.UseVisualStyleBackColor = false;
            this.buttonKaydet.Click += new System.EventHandler(this.buttonKaydet_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(782, 199);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(236, 200);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 43);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 47;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 25);
            this.label5.TabIndex = 48;
            this.label5.Text = "Bakım Kayıtları Detay";
            // 
            // lblKucult
            // 
            this.lblKucult.AutoSize = true;
            this.lblKucult.BackColor = System.Drawing.Color.Transparent;
            this.lblKucult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblKucult.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKucult.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblKucult.Location = new System.Drawing.Point(941, -4);
            this.lblKucult.Name = "lblKucult";
            this.lblKucult.Size = new System.Drawing.Size(36, 38);
            this.lblKucult.TabIndex = 58;
            this.lblKucult.Text = "_";
            this.lblKucult.Click += new System.EventHandler(this.lblKucult_Click);
            // 
            // lblKapat
            // 
            this.lblKapat.AutoSize = true;
            this.lblKapat.BackColor = System.Drawing.Color.Transparent;
            this.lblKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblKapat.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKapat.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblKapat.Location = new System.Drawing.Point(984, 2);
            this.lblKapat.Name = "lblKapat";
            this.lblKapat.Size = new System.Drawing.Size(34, 38);
            this.lblKapat.TabIndex = 57;
            this.lblKapat.Text = "x";
            this.lblKapat.Click += new System.EventHandler(this.lblKapat_Click);
            // 
            // BakimKaydiDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1021, 330);
            this.Controls.Add(this.lblKucult);
            this.Controls.Add(this.lblKapat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonKaydet);
            this.Controls.Add(this.buttonIptal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxAciklama);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxBakimDurumu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerBirSonrakiBakimTarihi);
            this.Controls.Add(this.dateTimePickerSonBakimTarihi);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(166)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BakimKaydiDetay";
            this.Text = "BakimKaydiDetay";
            this.Load += new System.EventHandler(this.BakimKaydiDetay_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerSonBakimTarihi;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirSonrakiBakimTarihi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBakimDurumu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAciklama;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonIptal;
        private System.Windows.Forms.Button buttonKaydet;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblKucult;
        private System.Windows.Forms.Label lblKapat;
    }
}