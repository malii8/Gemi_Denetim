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
    public partial class BakimKayitlariYonetimi : Form
    {
        static string BağlantıAdresi = "Data Source=DESKTOP-SUOJ7H3;Initial Catalog=GemiYonetimi_DataBase;Integrated Security=True;Encrypt=False;TrustServerCertificate=False";
        private int ekipmanId;

        public BakimKayitlariYonetimi(int id)
        {
            InitializeComponent();
            ekipmanId = id;
        }

        private void BakimKayitlariYonetimi_Load_1(object sender, EventArgs e)
        {
            BakimKayitlariniGetir();
            EkipmanAdiniGetir(); // Ekipman adını getir
        }

        public void BakimKayitlariniGetir(string arama = "")
        {
            using (SqlConnection baglantı = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    baglantı.Open();
                    string query = @"
                        SELECT br.id AS [Bakım ID],
                               br.son_bakim_tarih AS [Son Bakım Tarihi],
                               br.bakim_durumu AS [Bakım Durumu],
                               br.bir_sonraki_bakim_tarihi AS [Bir Sonraki Bakım Tarihi],
                               br.aciklama AS [Açıklama]
                        FROM BakimKayitlari br
                        WHERE br.ekipman_id = @EkipmanId AND (br.bakim_durumu LIKE @Arama OR br.aciklama LIKE @Arama)
                        ORDER BY br.son_bakim_tarih DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, baglantı);
                    adapter.SelectCommand.Parameters.AddWithValue("@EkipmanId", ekipmanId);
                    adapter.SelectCommand.Parameters.AddWithValue("@Arama", $"%{arama}%");
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewBakimKayitlari.DataSource = table;
                    dataGridViewBakimKayitlari.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewBakimKayitlari.Columns["Bakım ID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        private void EkipmanAdiniGetir()
        {
            using (SqlConnection baglantı = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    baglantı.Open();
                    string query = @"SELECT ekipman_adi FROM Ekipmanlar WHERE id = @EkipmanId";

                    SqlCommand command = new SqlCommand(query, baglantı);
                    command.Parameters.AddWithValue("@EkipmanId", ekipmanId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        EkipmanText.Text = reader["ekipman_adi"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Ekipman bilgisi bulunamadı.");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ekipman adı alınırken bir hata oluştu: {ex.Message}");
                }
            }
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            BakimKaydiDetay form = new BakimKaydiDetay(ekipmanId);
            form.ShowDialog();
            BakimKayitlariniGetir();
        }

        private void buttonDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridViewBakimKayitlari.SelectedRows.Count > 0)
            {
                int bakimId = Convert.ToInt32(dataGridViewBakimKayitlari.SelectedRows[0].Cells["Bakım ID"].Value);
                BakimKaydiDetay form = new BakimKaydiDetay(ekipmanId, bakimId);
                form.ShowDialog();
                BakimKayitlariniGetir();
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek için bir bakım kaydı seçin.");
            }
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewBakimKayitlari.SelectedRows.Count > 0)
            {
                int bakimId = Convert.ToInt32(dataGridViewBakimKayitlari.SelectedRows[0].Cells["Bakım ID"].Value);
                DialogResult result = MessageBox.Show("Seçilen bakım kaydını silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection baglantı = new SqlConnection(BağlantıAdresi))
                    {
                        try
                        {
                            baglantı.Open();
                            string deleteQuery = "DELETE FROM BakimKayitlari WHERE id = @BakimId";
                            SqlCommand command = new SqlCommand(deleteQuery, baglantı);
                            command.Parameters.AddWithValue("@BakimId", bakimId);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Bakım kaydı başarıyla silindi.");
                            BakimKayitlariniGetir();
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
                MessageBox.Show("Lütfen silmek için bir bakım kaydı seçin.");
            }
        }

        private void textBoxAramaBakim_TextChanged(object sender, EventArgs e)
        {
            BakimKayitlariniGetir(textBoxAramaBakim.Text.Trim());
        }

        private void dataGridViewBakimKayitlari_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblKapat_Click(object sender, EventArgs e)
        {
            this.Close();
            

        }

        private void lblKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
