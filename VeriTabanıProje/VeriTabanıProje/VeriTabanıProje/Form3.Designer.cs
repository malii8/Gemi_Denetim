namespace VeriTabanıProje
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonYeniDenetim = new System.Windows.Forms.Button();
            this.buttonDenetimBulgulari = new System.Windows.Forms.Button();
            this.dataGridViewDenetimler = new System.Windows.Forms.DataGridView();
            this.SahipText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ImoNoText = new System.Windows.Forms.Label();
            this.buttonDuzenle = new System.Windows.Forms.Button();
            this.textBoxArama = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ButtonDenetimSil = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblKucult = new System.Windows.Forms.Label();
            this.lblKapat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDenetimler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(166)))));
            this.label1.Location = new System.Drawing.Point(461, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gemi Denetimleri";
            // 
            // buttonYeniDenetim
            // 
            this.buttonYeniDenetim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.buttonYeniDenetim.Location = new System.Drawing.Point(534, 488);
            this.buttonYeniDenetim.Name = "buttonYeniDenetim";
            this.buttonYeniDenetim.Size = new System.Drawing.Size(148, 56);
            this.buttonYeniDenetim.TabIndex = 28;
            this.buttonYeniDenetim.Text = "Yeni Denetim";
            this.buttonYeniDenetim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonYeniDenetim.UseVisualStyleBackColor = false;
            this.buttonYeniDenetim.Click += new System.EventHandler(this.buttonYeniDenetim_Click_1);
            // 
            // buttonDenetimBulgulari
            // 
            this.buttonDenetimBulgulari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.buttonDenetimBulgulari.Location = new System.Drawing.Point(955, 488);
            this.buttonDenetimBulgulari.Name = "buttonDenetimBulgulari";
            this.buttonDenetimBulgulari.Size = new System.Drawing.Size(172, 56);
            this.buttonDenetimBulgulari.TabIndex = 29;
            this.buttonDenetimBulgulari.Text = "Denetim Bulguları";
            this.buttonDenetimBulgulari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDenetimBulgulari.UseVisualStyleBackColor = false;
            this.buttonDenetimBulgulari.Click += new System.EventHandler(this.buttonDenetimBulgulari_Click_1);
            // 
            // dataGridViewDenetimler
            // 
            this.dataGridViewDenetimler.AllowUserToAddRows = false;
            this.dataGridViewDenetimler.AllowUserToDeleteRows = false;
            this.dataGridViewDenetimler.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.dataGridViewDenetimler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDenetimler.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridViewDenetimler.Location = new System.Drawing.Point(83, 141);
            this.dataGridViewDenetimler.Name = "dataGridViewDenetimler";
            this.dataGridViewDenetimler.ReadOnly = true;
            this.dataGridViewDenetimler.RowHeadersWidth = 51;
            this.dataGridViewDenetimler.RowTemplate.Height = 24;
            this.dataGridViewDenetimler.Size = new System.Drawing.Size(1056, 305);
            this.dataGridViewDenetimler.TabIndex = 31;
            // 
            // SahipText
            // 
            this.SahipText.AutoSize = true;
            this.SahipText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SahipText.Location = new System.Drawing.Point(201, 65);
            this.SahipText.Name = "SahipText";
            this.SahipText.Size = new System.Drawing.Size(0, 16);
            this.SahipText.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(166)))));
            this.label2.Location = new System.Drawing.Point(70, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Gemi Sahibi Adı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(166)))));
            this.label3.Location = new System.Drawing.Point(128, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "IMO NO:";
            // 
            // ImoNoText
            // 
            this.ImoNoText.AutoSize = true;
            this.ImoNoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ImoNoText.Location = new System.Drawing.Point(201, 98);
            this.ImoNoText.Name = "ImoNoText";
            this.ImoNoText.Size = new System.Drawing.Size(0, 16);
            this.ImoNoText.TabIndex = 35;
            this.ImoNoText.Click += new System.EventHandler(this.ImoNoText_Click);
            // 
            // buttonDuzenle
            // 
            this.buttonDuzenle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.buttonDuzenle.Location = new System.Drawing.Point(317, 488);
            this.buttonDuzenle.Name = "buttonDuzenle";
            this.buttonDuzenle.Size = new System.Drawing.Size(165, 56);
            this.buttonDuzenle.TabIndex = 36;
            this.buttonDuzenle.Text = "Denetim Düzenle";
            this.buttonDuzenle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDuzenle.UseVisualStyleBackColor = false;
            this.buttonDuzenle.Click += new System.EventHandler(this.buttonDuzenle_Click);
            // 
            // textBoxArama
            // 
            this.textBoxArama.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(199)))), ((int)(((byte)(217)))));
            this.textBoxArama.Location = new System.Drawing.Point(795, 96);
            this.textBoxArama.Name = "textBoxArama";
            this.textBoxArama.Size = new System.Drawing.Size(250, 22);
            this.textBoxArama.TabIndex = 38;
            this.textBoxArama.TextChanged += new System.EventHandler(this.textBoxArama_TextChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(166)))));
            this.label5.Location = new System.Drawing.Point(705, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 22);
            this.label5.TabIndex = 40;
            this.label5.Text = "Arama:";
            // 
            // ButtonDenetimSil
            // 
            this.ButtonDenetimSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.ButtonDenetimSil.Location = new System.Drawing.Point(108, 488);
            this.ButtonDenetimSil.Name = "ButtonDenetimSil";
            this.ButtonDenetimSil.Size = new System.Drawing.Size(145, 56);
            this.ButtonDenetimSil.TabIndex = 42;
            this.ButtonDenetimSil.Text = "Denetim Sil";
            this.ButtonDenetimSil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDenetimSil.UseVisualStyleBackColor = false;
            this.ButtonDenetimSil.Click += new System.EventHandler(this.ButtonDenetimSil_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(433, 494);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 43;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(204, 494);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(43, 43);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 44;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(632, 495);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(1078, 495);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(43, 43);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 46;
            this.pictureBox4.TabStop = false;
            // 
            // lblKucult
            // 
            this.lblKucult.AutoSize = true;
            this.lblKucult.BackColor = System.Drawing.Color.Transparent;
            this.lblKucult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblKucult.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKucult.Location = new System.Drawing.Point(1133, -6);
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
            this.lblKapat.Location = new System.Drawing.Point(1176, 0);
            this.lblKapat.Name = "lblKapat";
            this.lblKapat.Size = new System.Drawing.Size(34, 38);
            this.lblKapat.TabIndex = 57;
            this.lblKapat.Text = "x";
            this.lblKapat.Click += new System.EventHandler(this.lblKapat_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1211, 578);
            this.Controls.Add(this.lblKucult);
            this.Controls.Add(this.lblKapat);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ButtonDenetimSil);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxArama);
            this.Controls.Add(this.buttonDuzenle);
            this.Controls.Add(this.ImoNoText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SahipText);
            this.Controls.Add(this.dataGridViewDenetimler);
            this.Controls.Add(this.buttonDenetimBulgulari);
            this.Controls.Add(this.buttonYeniDenetim);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Denetim Ekranı";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDenetimler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonYeniDenetim;
        private System.Windows.Forms.Button buttonDenetimBulgulari;
        private System.Windows.Forms.DataGridView dataGridViewDenetimler;
        private System.Windows.Forms.Label SahipText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ImoNoText;
        private System.Windows.Forms.Button buttonDuzenle;
        private System.Windows.Forms.TextBox textBoxArama;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ButtonDenetimSil;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblKucult;
        private System.Windows.Forms.Label lblKapat;
    }
}