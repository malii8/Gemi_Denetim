using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTabanıProje
{
    public partial class Form5 : Form
    {
        static string BağlantıAdresi = ("Data Source=DESKTOP-SUOJ7H3;Initial Catalog=GemiYonetimi_DataBase;Integrated Security=True;Encrypt=False;TrustServerCertificate=False");
        public int denetimId;
        private int secilenBulguId = -1; // Düzenleme modu için değişken

        public Form5(int id)
        {
            InitializeComponent();
            denetimId = id;
        }

        private void Form5_Load_1(object sender, EventArgs e)
        {
            BulgularıGetir();
            CiddiyetleriGetir();  // Ciddiyet ComboBox'ını doldur
            DenetimBilgileriniGetir(); // Denetim bilgilerini yüklüyoruz
        }

        private void BulgularıGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    string query = @"SELECT id AS [Bulgu ID], bulgu AS [Bulgu], ciddiyet AS [Ciddiyet], aciklama AS [Açıklama]
                                     FROM KontrolBulgu
                                     WHERE kontrol_id = @DenetimId";
                    SqlCommand command = new SqlCommand(query, baglanti);
                    command.Parameters.AddWithValue("@DenetimId", denetimId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewBulgular.DataSource = table;
                    dataGridViewBulgular.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Bulgu ID sütununu gizle
                    dataGridViewBulgular.Columns["Bulgu ID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bulgular yüklenirken bir hata oluştu: {ex.Message}");
                }
            }
        }

        private void CiddiyetleriGetir()
        {
            ciddiyetComboBox.Items.Clear();
            ciddiyetComboBox.Items.Add("Yüksek");
            ciddiyetComboBox.Items.Add("Orta");
            ciddiyetComboBox.Items.Add("Düşük");
            ciddiyetComboBox.SelectedIndex = 0;  // Varsayılan seçim "Yüksek" olsun
        }

        private void DenetimBilgileriniGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    string query = @"
                        SELECT kt.tur_adi AS denetim_turu, c.kontrol_tarih AS baslangic_tarihi
                        FROM Kontroller c
                        JOIN KontrolTurleri kt ON c.kontrol_tur_id = kt.id
                        WHERE c.id = @DenetimId";
                    SqlCommand command = new SqlCommand(query, baglanti);
                    command.Parameters.AddWithValue("@DenetimId", denetimId);

                    baglanti.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Denetim Türü ve Başlangıç Tarihini Label'lara Atama
                        label6.Text = reader["denetim_turu"].ToString();
                        label7.Text = Convert.ToDateTime(reader["baslangic_tarihi"]).ToShortDateString();
                    }
                    else
                    {
                        MessageBox.Show("Denetim bilgileri bulunamadı.");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Denetim bilgileri yüklenirken bir hata oluştu: {ex.Message}");
                }
            }
        }

        private void buttonKaydet_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    baglanti.Open();

                    string bulgu = bulguTextBox.Text.Trim();
                    string aciklama = aciklamaTextBox.Text.Trim();
                    string ciddiyet = ciddiyetComboBox.SelectedItem.ToString().Trim();

                    if (string.IsNullOrWhiteSpace(bulgu) || string.IsNullOrWhiteSpace(ciddiyet))
                    {
                        MessageBox.Show("Bulgu ve Ciddiyet alanları boş bırakılamaz.");
                        return;
                    }

                    if (secilenBulguId > 0)
                    {
                        // Düzenleme işlemi
                        string updateQuery = @"UPDATE KontrolBulgu 
                                               SET bulgu = @Bulgu, ciddiyet = @Ciddiyet, aciklama = @Aciklama 
                                               WHERE id = @BulguId";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, baglanti);
                        updateCommand.Parameters.AddWithValue("@BulguId", secilenBulguId);
                        updateCommand.Parameters.AddWithValue("@Bulgu", bulgu);
                        updateCommand.Parameters.AddWithValue("@Ciddiyet", ciddiyet);
                        updateCommand.Parameters.AddWithValue("@Aciklama", aciklama);
                        updateCommand.ExecuteNonQuery();

                        MessageBox.Show("Bulgu başarıyla güncellendi.");
                    }
                    else
                    {
                        // Yeni kayıt ekleme
                        string insertQuery = @"INSERT INTO KontrolBulgu (kontrol_id, bulgu, ciddiyet, aciklama)
                                               VALUES (@DenetimId, @Bulgu, @Ciddiyet, @Aciklama)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, baglanti);
                        insertCommand.Parameters.AddWithValue("@DenetimId", denetimId);
                        insertCommand.Parameters.AddWithValue("@Bulgu", bulgu);
                        insertCommand.Parameters.AddWithValue("@Ciddiyet", ciddiyet);
                        insertCommand.Parameters.AddWithValue("@Aciklama", aciklama);
                        insertCommand.ExecuteNonQuery();

                        MessageBox.Show("Bulgu başarıyla kaydedildi.");
                    }

                    // Tabloyu güncelle ve düzenleme modunu sıfırla
                    BulgularıGetir();
                    secilenBulguId = -1;
                    bulguTextBox.Clear();
                    aciklamaTextBox.Clear();
                    ciddiyetComboBox.SelectedIndex = 0;
                    buttonKaydet.Text = "Kaydet";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        private void buttonDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridViewBulgular.SelectedRows.Count > 0)
            {
                secilenBulguId = Convert.ToInt32(dataGridViewBulgular.SelectedRows[0].Cells["Bulgu ID"].Value);
                bulguTextBox.Text = dataGridViewBulgular.SelectedRows[0].Cells["Bulgu"].Value.ToString();
                ciddiyetComboBox.SelectedItem = dataGridViewBulgular.SelectedRows[0].Cells["Ciddiyet"].Value.ToString();
                aciklamaTextBox.Text = dataGridViewBulgular.SelectedRows[0].Cells["Açıklama"].Value.ToString();

                buttonKaydet.Text = "Güncelle";
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek için bir bulgu seçin.");
            }
        }

        private void buttonSil_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewBulgular.SelectedRows.Count > 0)
            {
                int bulguId = Convert.ToInt32(dataGridViewBulgular.SelectedRows[0].Cells["Bulgu ID"].Value);

                DialogResult result = MessageBox.Show("Seçilen bulguyu silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection baglanti = new SqlConnection(BağlantıAdresi))
                    {
                        try
                        {
                            baglanti.Open();
                            string deleteQuery = @"DELETE FROM KontrolBulgu WHERE id = @BulguId";
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, baglanti);
                            deleteCommand.Parameters.AddWithValue("@BulguId", bulguId);
                            deleteCommand.ExecuteNonQuery();

                            MessageBox.Show("Bulgu başarıyla silindi.");
                            BulgularıGetir();
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
                MessageBox.Show("Lütfen silmek için bir bulgu seçin.");
            }
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
