namespace VeriTabanıProje
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.comboBoxDenetimTuru = new System.Windows.Forms.ComboBox();
            this.dateTimePickerTarih = new System.Windows.Forms.DateTimePicker();
            this.buttonKaydet = new System.Windows.Forms.Button();
            this.buttonIptal = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewKriterler = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxDenetimDurumu = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerBitisTarih = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblKucult = new System.Windows.Forms.Label();
            this.lblKapat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKriterler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxDenetimTuru
            // 
            this.comboBoxDenetimTuru.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(199)))), ((int)(((byte)(217)))));
            this.comboBoxDenetimTuru.FormattingEnabled = true;
            this.comboBoxDenetimTuru.Location = new System.Drawing.Point(275, 201);
            this.comboBoxDenetimTuru.Name = "comboBoxDenetimTuru";
            this.comboBoxDenetimTuru.Size = new System.Drawing.Size(200, 24);
            this.comboBoxDenetimTuru.TabIndex = 0;
            // 
            // dateTimePickerTarih
            // 
            this.dateTimePickerTarih.Location = new System.Drawing.Point(275, 130);
            this.dateTimePickerTarih.Name = "dateTimePickerTarih";
            this.dateTimePickerTarih.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerTarih.TabIndex = 1;
            // 
            // buttonKaydet
            // 
            this.buttonKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.buttonKaydet.Location = new System.Drawing.Point(840, 444);
            this.buttonKaydet.Name = "buttonKaydet";
            this.buttonKaydet.Size = new System.Drawing.Size(122, 56);
            this.buttonKaydet.TabIndex = 3;
            this.buttonKaydet.Text = "KAYDET";
            this.buttonKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonKaydet.UseVisualStyleBackColor = false;
            this.buttonKaydet.Click += new System.EventHandler(this.buttonKaydet_Click);
            // 
            // buttonIptal
            // 
            this.buttonIptal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.buttonIptal.Location = new System.Drawing.Point(290, 444);
            this.buttonIptal.Name = "buttonIptal";
            this.buttonIptal.Size = new System.Drawing.Size(122, 56);
            this.buttonIptal.TabIndex = 4;
            this.buttonIptal.Text = "İPTAL";
            this.buttonIptal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonIptal.UseVisualStyleBackColor = false;
            this.buttonIptal.Click += new System.EventHandler(this.buttonIptal_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(166)))));
            this.label5.Location = new System.Drawing.Point(525, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 22);
            this.label5.TabIndex = 17;
            this.label5.Text = "Denetim Kriterleri:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(166)))));
            this.label1.Location = new System.Drawing.Point(102, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 22);
            this.label1.TabIndex = 18;
            this.label1.Text = "Denetim Tarihi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(166)))));
            this.label2.Location = new System.Drawing.Point(109, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 22);
            this.label2.TabIndex = 19;
            this.label2.Text = "Denetim Türü:";
            // 
            // dataGridViewKriterler
            // 
            this.dataGridViewKriterler.AllowUserToAddRows = false;
            this.dataGridViewKriterler.AllowUserToDeleteRows = false;
            this.dataGridViewKriterler.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.dataGridViewKriterler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKriterler.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridViewKriterler.Location = new System.Drawing.Point(629, 161);
            this.dataGridViewKriterler.Name = "dataGridViewKriterler";
            this.dataGridViewKriterler.ReadOnly = true;
            this.dataGridViewKriterler.RowHeadersWidth = 51;
            this.dataGridViewKriterler.RowTemplate.Height = 24;
            this.dataGridViewKriterler.Size = new System.Drawing.Size(485, 54);
            this.dataGridViewKriterler.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(166)))));
            this.label3.Location = new System.Drawing.Point(523, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 32);
            this.label3.TabIndex = 33;
            this.label3.Text = "Denetim Ekle";
            // 
            // comboBoxDenetimDurumu
            // 
            this.comboBoxDenetimDurumu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(199)))), ((int)(((byte)(217)))));
            this.comboBoxDenetimDurumu.FormattingEnabled = true;
            this.comboBoxDenetimDurumu.Location = new System.Drawing.Point(275, 297);
            this.comboBoxDenetimDurumu.Name = "comboBoxDenetimDurumu";
            this.comboBoxDenetimDurumu.Size = new System.Drawing.Size(200, 24);
            this.comboBoxDenetimDurumu.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(166)))));
            this.label4.Location = new System.Drawing.Point(86, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 22);
            this.label4.TabIndex = 35;
            this.label4.Text = "Denetim Durumu:";
            // 
            // dateTimePickerBitisTarih
            // 
            this.dateTimePickerBitisTarih.Location = new System.Drawing.Point(275, 387);
            this.dateTimePickerBitisTarih.Name = "dateTimePickerBitisTarih";
            this.dateTimePickerBitisTarih.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerBitisTarih.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(166)))));
            this.label6.Location = new System.Drawing.Point(61, 387);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 22);
            this.label6.TabIndex = 37;
            this.label6.Text = "Denetim Bittiş Tarihi:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(911, 449);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(361, 450);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(43, 43);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 47;
            this.pictureBox3.TabStop = false;
            // 
            // lblKucult
            // 
            this.lblKucult.AutoSize = true;
            this.lblKucult.BackColor = System.Drawing.Color.Transparent;
            this.lblKucult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblKucult.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKucult.Location = new System.Drawing.Point(1132, -8);
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
            this.lblKapat.Location = new System.Drawing.Point(1175, -2);
            this.lblKapat.Name = "lblKapat";
            this.lblKapat.Size = new System.Drawing.Size(34, 38);
            this.lblKapat.TabIndex = 57;
            this.lblKapat.Text = "x";
            this.lblKapat.Click += new System.EventHandler(this.lblKapat_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1211, 578);
            this.Controls.Add(this.lblKucult);
            this.Controls.Add(this.lblKapat);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePickerBitisTarih);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxDenetimDurumu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewKriterler);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonIptal);
            this.Controls.Add(this.buttonKaydet);
            this.Controls.Add(this.dateTimePickerTarih);
            this.Controls.Add(this.comboBoxDenetimTuru);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Denetim Ekle";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKriterler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDenetimTuru;
        private System.Windows.Forms.DateTimePicker dateTimePickerTarih;
        private System.Windows.Forms.Button buttonKaydet;
        private System.Windows.Forms.Button buttonIptal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewKriterler;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxDenetimDurumu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerBitisTarih;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblKucult;
        private System.Windows.Forms.Label lblKapat;
    }
}