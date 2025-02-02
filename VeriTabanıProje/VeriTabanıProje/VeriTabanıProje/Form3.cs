using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTabanıProje
{
    public partial class Form3 : Form
    {
        // Veritabanı bağlantı dizesi
        static string BağlantıAdresi = "Data Source=DESKTOP-SUOJ7H3;Initial Catalog=GemiYonetimi_DataBase;Integrated Security=True;Encrypt=False;TrustServerCertificate=False";
        private int gemiId;

        // Constructor: Form3'e gemiId'yi geçiriyoruz
        public Form3(int id)
        {
            InitializeComponent();
            gemiId = id;
        }

        // Form yüklendiğinde çalışacak olay
        private void Form3_Load(object sender, EventArgs e)
        {
            DenetimleriGetir();
            GemiBilgileriniGetir();
        }

        // Gemi sahibinin adı, soyadı ve IMO numarasını alıyoruz
        private void GemiBilgileriniGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    string query = @"SELECT gs.ad + ' ' + gs.soyad AS [Sahip Adı], g.IMO_No 
                                     FROM Gemiler g
                                     JOIN GemiSahibi gs ON g.sahip_id = gs.id
                                     WHERE g.id = @GemiId";
                    SqlCommand command = new SqlCommand(query, baglanti);
                    command.Parameters.AddWithValue("@GemiId", gemiId);

                    baglanti.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Sahip Adı Soyadını ve IMO numarasını TextBox'lara ekliyoruz
                        SahipText.Text = reader["Sahip Adı"].ToString();
                        ImoNoText.Text = reader["IMO_No"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Gemi bilgileri bulunamadı.");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gemi bilgileri alınırken bir hata oluştu: {ex.Message}");
                }
            }
        }

        // Denetimleri veritabanından çekip DataGridView'e yükleyen metod
        private void DenetimleriGetir(string arama = "")
        {
            using (SqlConnection baglanti = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    string query = @"SELECT c.id AS [Denetim ID], 
                                        t.tur_adi AS [Denetim Türü], 
                                        c.kontrol_tarih AS [Denetim Başlangıç Tarihi],
                                        c.durum AS [Durum],
                                        c.kontrol_tarih_bitits AS [Denetim Bittiş Tarihi]
    
                                 FROM Kontroller c
                                 JOIN KontrolTurleri t ON c.kontrol_tur_id = t.id
                                 WHERE c.gemi_id = @GemiId AND (t.tur_adi LIKE @Arama)
                                 ORDER BY c.kontrol_tarih DESC";

                    SqlCommand command = new SqlCommand(query, baglanti);
                    command.Parameters.AddWithValue("@GemiId", gemiId);
                    command.Parameters.AddWithValue("@Arama", $"%{arama}%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewDenetimler.DataSource = table;
                    dataGridViewDenetimler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewDenetimler.Columns["Denetim ID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veriler getirilirken bir hata oluştu: {ex.Message}");
                }
            }
        }

        // "Yeni Denetim" butonuna tıklandığında çalışacak olay
        private void buttonYeniDenetim_Click_1(object sender, EventArgs e)
        {
            // Yeni denetim eklemek için sadece gemiId'yi Form4'e geçiriyoruz
            Form4 form4 = new Form4(gemiId);
            form4.ShowDialog();
            DenetimleriGetir();
        }

        // "Denetim Bulguları" butonuna tıklandığında çalışacak olay
        private void buttonDenetimBulgulari_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewDenetimler.SelectedRows.Count > 0)
            {
                int denetimId = Convert.ToInt32(dataGridViewDenetimler.SelectedRows[0].Cells["Denetim ID"].Value);
                Form5 form5 = new Form5(denetimId);
                form5.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen bir denetim seçin.");
            }
        }

        // "Düzenle" butonuna tıklandığında çalışacak olay
        private void buttonDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridViewDenetimler.SelectedRows.Count > 0)
            {
                int denetimId = Convert.ToInt32(dataGridViewDenetimler.SelectedRows[0].Cells["Denetim ID"].Value);

                // Düzenleme yaparken hem gemiId hem de denetimId'yi Form4'e geçiriyoruz
                Form4 form4 = new Form4(gemiId, denetimId);
                form4.ShowDialog();
                DenetimleriGetir();  // Denetim bilgilerini güncelle
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek için bir denetim seçin.");
            }
        }

        private void textBoxArama_TextChanged_1(object sender, EventArgs e)
        {
            DenetimleriGetir(textBoxArama.Text.Trim());
        }


        private void ButtonDenetimSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewDenetimler.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki Denetim ID'sini al
                int denetimId = Convert.ToInt32(dataGridViewDenetimler.SelectedRows[0].Cells["Denetim ID"].Value);

                // Kullanıcıdan onay al
                DialogResult result = MessageBox.Show("Bu denetimi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection baglanti = new SqlConnection(BağlantıAdresi))
                    {
                        try
                        {
                            baglanti.Open();

                            // Denetim silme işlemi
                            string silQuery = @"
                        DELETE FROM KontrolBulgu WHERE kontrol_id = @DenetimId; 
                        DELETE FROM Kontroller WHERE id = @DenetimId;";

                            SqlCommand silCommand = new SqlCommand(silQuery, baglanti);
                            silCommand.Parameters.AddWithValue("@DenetimId", denetimId);

                            silCommand.ExecuteNonQuery();

                            MessageBox.Show("Denetim başarıyla silindi!");

                            // Denetimleri yenile
                            DenetimleriGetir();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Silme işlemi sırasında bir hata oluştu: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir denetim seçin.");
            }
        }

        private void ImoNoText_Click(object sender, EventArgs e)
        {

        }

        private void lblKapat_Click(object sender, EventArgs e)
        {
            this.Close();
            GemiBilgileri gemiBilgileri = new GemiBilgileri();
            gemiBilgileri.Show();

        }

        private void lblKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
