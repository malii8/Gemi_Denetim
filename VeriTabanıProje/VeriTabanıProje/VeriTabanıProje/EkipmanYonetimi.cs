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

namespace VeriTabanıProje
{
    public partial class EkipmanYonetimi : Form
    {
        static string BağlantıAdresi = "Data Source=DESKTOP-SUOJ7H3;Initial Catalog=GemiYonetimi_DataBase;Integrated Security=True;Encrypt=False;TrustServerCertificate=False";
        private int gemiId;

        public EkipmanYonetimi(int id)
        {
            InitializeComponent();
            gemiId = id;
        }

        private void EkipmanYonetimi_Load_1(object sender, EventArgs e)
        {
            EkipmanlariGetir();
            GemiBilgileriniGetir(); // Gemi sahibinin adı ve IMO numarasını getir
        }

        public void EkipmanlariGetir(string arama = "")
        {
            using (SqlConnection baglantı = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    baglantı.Open();
                    string query = @"
                        SELECT e.id AS [ID],
                               e.ekipman_adi AS [Ekipman Adı],
                               ek.kategori_adi AS [Kategori],
                               e.eklenme_tarihi AS [Eklenme Tarihi],
                               e.durum AS [Durum]
                        FROM Ekipmanlar e
                        JOIN EkipmanKategorisi ek ON e.kategori_id = ek.id
                        WHERE e.gemi_id = @GemiId AND (e.ekipman_adi LIKE @Arama OR ek.kategori_adi LIKE @Arama)
                        ORDER BY e.ekipman_adi";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, baglantı);
                    adapter.SelectCommand.Parameters.AddWithValue("@GemiId", gemiId);
                    adapter.SelectCommand.Parameters.AddWithValue("@Arama", $"%{arama}%");
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewEkipmanlar.DataSource = table;
                    dataGridViewEkipmanlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewEkipmanlar.Columns["ID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        private void GemiBilgileriniGetir()
        {
            using (SqlConnection baglantı = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    baglantı.Open();
                    string query = @"
                        SELECT gs.ad + ' ' + gs.soyad AS [Sahip Adı], g.IMO_No 
                        FROM Gemiler g
                        JOIN GemiSahibi gs ON g.sahip_id = gs.id
                        WHERE g.id = @GemiId";

                    SqlCommand command = new SqlCommand(query, baglantı);
                    command.Parameters.AddWithValue("@GemiId", gemiId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
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

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            EkipmanDetay form = new EkipmanDetay(gemiId);
            form.ShowDialog();
            EkipmanlariGetir();
        }

        private void buttonDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridViewEkipmanlar.SelectedRows.Count > 0)
            {
                int ekipmanId = Convert.ToInt32(dataGridViewEkipmanlar.SelectedRows[0].Cells["ID"].Value);
                EkipmanDetay form = new EkipmanDetay(gemiId, ekipmanId);
                form.ShowDialog();
                EkipmanlariGetir();
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek için bir ekipman seçin.");
            }
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewEkipmanlar.SelectedRows.Count > 0)
            {
                int ekipmanId = Convert.ToInt32(dataGridViewEkipmanlar.SelectedRows[0].Cells["ID"].Value);
                DialogResult result = MessageBox.Show("Seçilen ekipmanı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection baglantı = new SqlConnection(BağlantıAdresi))
                    {
                        try
                        {
                            baglantı.Open();
                            string deleteQuery = "DELETE FROM Ekipmanlar WHERE id = @EkipmanId";
                            SqlCommand command = new SqlCommand(deleteQuery, baglantı);
                            command.Parameters.AddWithValue("@EkipmanId", ekipmanId);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Ekipman başarıyla silindi.");
                            EkipmanlariGetir();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Silme sırasında hata oluştu: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir ekipman seçin.");
            }
        }

        private void buttonBakimKayitlari_Click(object sender, EventArgs e)
        {
            if (dataGridViewEkipmanlar.SelectedRows.Count > 0)
            {
                int ekipmanId = Convert.ToInt32(dataGridViewEkipmanlar.SelectedRows[0].Cells["ID"].Value);
                BakimKayitlariYonetimi form = new BakimKayitlariYonetimi(ekipmanId);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen bakım kayıtlarını görüntülemek için bir ekipman seçin.");
            }
        }

        private void textBoxArama_TextChanged(object sender, EventArgs e)
        {
            EkipmanlariGetir(textBoxArama.Text.Trim());
        }

        private void SahipText_Click(object sender, EventArgs e)
        {

        }

        private void lblKapat_Click(object sender, EventArgs e)
        {
            
            this.Close();

            GemiBilgileri frm = new GemiBilgileri();
            frm.ShowDialog();

        }

        private void lblKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
