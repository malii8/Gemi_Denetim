using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using VeriTabanıProje;


namespace VeriTabanıProje
{
    public partial class GemiBilgileri : Form
    {
        public GemiBilgileri()
        {
            InitializeComponent();
        }

        // Veritabanı bağlantı adresi
        static string BağlantıAdresi = ("Data Source=DESKTOP-SUOJ7H3;Initial Catalog=GemiYonetimi_DataBase;Integrated Security=True;Encrypt=False;TrustServerCertificate=False");

        private void Form1_Load(object sender, EventArgs e)
        {
            
            VerileriGetir();
        }

        public void VerileriGetir()
        {
            using (SqlConnection baglantı = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    baglantı.Open();

                    // Tüm verileri getiren SQL sorgusu
                    string query = @"
                        SELECT g.id AS [ID], 
                               g.IMO_No AS [IMO Numarası], 
                               g.sicil_no AS [Sicil No], 
                               gs.ad + ' ' + gs.soyad AS [Sahip Bilgileri], 
                               gt.tur_adi AS [Gemi Tipi]
                        FROM Gemiler g
                        JOIN GemiSahibi gs ON g.sahip_id = gs.id
                        JOIN GemiTurleri gt ON g.gemi_turu_id = gt.id
                        ORDER BY gt.tur_adi";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, baglantı);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    
                    dataGridView1.DataSource = table;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    
                    dataGridView1.Columns["ID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection baglantı = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    baglantı.Open();

                    
                    string aramaKriteri = textBox1.Text.Trim();

                    // SQL sorgusu (arama kriteri eklenmiş)
                    string query = @"
                        SELECT g.id AS [ID], 
                               g.IMO_No AS [IMO Numarası], 
                               g.sicil_no AS [Sicil No], 
                               gs.ad + ' ' + gs.soyad AS [Sahip Bilgileri], 
                               gt.tur_adi AS [Gemi Tipi]
                        FROM Gemiler g
                        JOIN GemiSahibi gs ON g.sahip_id = gs.id
                        JOIN GemiTurleri gt ON g.gemi_turu_id = gt.id
                        WHERE g.IMO_No LIKE @Arama OR 
                              g.sicil_no LIKE @Arama OR 
                              gs.ad + ' ' + gs.soyad LIKE @Arama OR 
                              gt.tur_adi LIKE @Arama
                        ORDER BY gt.tur_adi";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, baglantı);

                    // SQL parametresi ekle
                    adapter.SelectCommand.Parameters.AddWithValue("@Arama", $"%{aramaKriteri}%");

                    
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    
                    dataGridView1.DataSource = table;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    
                    dataGridView1.Columns["ID"].Visible = false;

                    
                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("Arama kriterine uygun bir sonuç bulunamadı.");
                    }
                    baglantı.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerileriGetir();
            textBox1.Clear();

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void Yeni_Kayıt_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(0); 
            this.Hide();
            form2.ShowDialog();

            
            VerileriGetir();
        }

        private void Kayıt_Düzenle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki ID'yi al
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                // Form2'yi aç ve ID'yi gönder
                Form2 form2 = new Form2(id);
                form2.ShowDialog();

                
                VerileriGetir();
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek için bir satır seçin.");
            }
        }

        

        private void buttonDenetimler_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int gemiId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                Form3 form3 = new Form3(gemiId);
                this.Hide();
                form3.ShowDialog();

               


            }
            else
            {
                MessageBox.Show("Lütfen denetim yapmak için bir gemi seçin.");
            }

        }

        private void buttonEkipmanYonetimi_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int gemiId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                EkipmanYonetimi form6 = new EkipmanYonetimi(gemiId);
                this.Hide();
                form6.ShowDialog();

            }
            else
            {
                MessageBox.Show("Lütfen ekipman yönetimi için geçerli bir gemi seçin.");
            }
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki ID'yi al
                int gemiId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                // Kullanıcıdan onay al
                DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection baglantı = new SqlConnection(BağlantıAdresi))
                    {
                        try
                        {
                            baglantı.Open();

                            // Gemi sahibinin ID'sini almak için sorgu
                            string gemiSahibiIdQuery = "SELECT sahip_id FROM Gemiler WHERE id = @GemiId";
                            SqlCommand gemiSahibiIdCommand = new SqlCommand(gemiSahibiIdQuery, baglantı);
                            gemiSahibiIdCommand.Parameters.AddWithValue("@GemiId", gemiId);
                            int gemiSahibiId = Convert.ToInt32(gemiSahibiIdCommand.ExecuteScalar());

                            // "Gemiler" tablosundan kaydı sil
                            string gemiSilQuery = "DELETE FROM Gemiler WHERE id = @GemiId";
                            SqlCommand gemiSilCommand = new SqlCommand(gemiSilQuery, baglantı);
                            gemiSilCommand.Parameters.AddWithValue("@GemiId", gemiId);
                            gemiSilCommand.ExecuteNonQuery();

                            // "GemiSahibi" tablosundan kaydı sil
                            string gemiSahibiSilQuery = "DELETE FROM GemiSahibi WHERE id = @GemiSahibiId";
                            SqlCommand gemiSahibiSilCommand = new SqlCommand(gemiSahibiSilQuery, baglantı);
                            gemiSahibiSilCommand.Parameters.AddWithValue("@GemiSahibiId", gemiSahibiId);
                            gemiSahibiSilCommand.ExecuteNonQuery();

                            MessageBox.Show("Kayıt başarıyla silindi!");

                            // DataGridView'ı güncelle
                            VerileriGetir();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Hata: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin.");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }

        private void lblKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void lblKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}