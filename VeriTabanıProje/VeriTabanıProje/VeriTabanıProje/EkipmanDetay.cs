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
    public partial class EkipmanDetay : Form
    {
        static string BağlantıAdresi = "Data Source=DESKTOP-SUOJ7H3;Initial Catalog=GemiYonetimi_DataBase;Integrated Security=True;Encrypt=False;TrustServerCertificate=False";
        private int gemiId;
        private int? ekipmanId; // Nullable, 0 veya null ise yeni kayıt

        public EkipmanDetay(int id, int? ekipmanId = null)
        {
            InitializeComponent();
            gemiId = id;
            this.ekipmanId = ekipmanId;
        }

        private void EkipmanDetay_Load_1(object sender, EventArgs e)
        {
            KategorileriGetir();
            DurumlariGetir();

            if (ekipmanId.HasValue && ekipmanId > 0)
            {
                // Düzenleme modunda, mevcut verileri yükle
                EkipmanBilgileriniGetir();
            }
            else
            {
                // Yeni kayıt modunda, varsayılan değerleri ayarla
                comboBoxDurum.SelectedIndex = 0; // Aktif
                dateTimePickerEklenmeTarihi.Value = DateTime.Now;
            }
        }

        private void KategorileriGetir()
        {
            using (SqlConnection baglantı = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    baglantı.Open();
                    string query = "SELECT id, kategori_adi FROM EkipmanKategorisi ORDER BY kategori_adi";
                    SqlCommand command = new SqlCommand(query, baglantı);
                    SqlDataReader reader = command.ExecuteReader();

                    comboBoxKategori.Items.Clear();
                    while (reader.Read())
                    {
                        var keyValuePair = new KeyValuePair<string, string>(reader["id"].ToString(), reader["kategori_adi"].ToString());
                        comboBoxKategori.Items.Add(keyValuePair);
                    }

                    if (comboBoxKategori.Items.Count > 0)
                    {
                        comboBoxKategori.DisplayMember = "Value";
                        comboBoxKategori.ValueMember = "Key";
                        comboBoxKategori.SelectedIndex = 0;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Kategori getirilirken hata oluştu: {ex.Message}");
                }
            }
        }

        private void DurumlariGetir()
        {
            comboBoxDurum.Items.Clear();
            comboBoxDurum.Items.Add("Aktif");
            comboBoxDurum.Items.Add("Pasif");
            comboBoxDurum.SelectedIndex = 0; // Varsayılan "Aktif"
        }

        private void EkipmanBilgileriniGetir()
        {
            using (SqlConnection baglantı = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    baglantı.Open();
                    string query = @"
                        SELECT ekipman_adi, eklenme_tarihi, durum, kategori_id
                        FROM Ekipmanlar
                        WHERE id = @EkipmanId";
                    SqlCommand command = new SqlCommand(query, baglantı);
                    command.Parameters.AddWithValue("@EkipmanId", ekipmanId.Value);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        textBoxEkipmanAdi.Text = reader["ekipman_adi"].ToString();
                        dateTimePickerEklenmeTarihi.Value = Convert.ToDateTime(reader["eklenme_tarihi"]);
                        comboBoxDurum.SelectedItem = reader["durum"].ToString();

                        string kategoriId = reader["kategori_id"].ToString();
                        foreach (var item in comboBoxKategori.Items)
                        {
                            if (((KeyValuePair<string, string>)item).Key == kategoriId)
                            {
                                comboBoxKategori.SelectedItem = item;
                                break;
                            }
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ekipman bilgileri getirilirken hata oluştu: {ex.Message}");
                }
            }
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            if (!KontrolEt())
                return;

            using (SqlConnection baglantı = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    baglantı.Open();
                    string query;

                    if (ekipmanId.HasValue && ekipmanId > 0)
                    {
                        // Güncelleme işlemi
                        query = @"
                            UPDATE Ekipmanlar
                            SET ekipman_adi = @EkipmanAdi,
                                eklenme_tarihi = @EklenmeTarihi,
                                durum = @Durum,
                                kategori_id = @KategoriId
                            WHERE id = @EkipmanId";
                    }
                    else
                    {
                        // Yeni kayıt işlemi
                        query = @"
                            INSERT INTO Ekipmanlar (gemi_id, ekipman_adi, eklenme_tarihi, durum, kategori_id)
                            VALUES (@GemiId, @EkipmanAdi, @EklenmeTarihi, @Durum, @KategoriId)";
                    }

                    SqlCommand command = new SqlCommand(query, baglantı);
                    command.Parameters.AddWithValue("@EkipmanAdi", textBoxEkipmanAdi.Text.Trim());
                    command.Parameters.AddWithValue("@EklenmeTarihi", dateTimePickerEklenmeTarihi.Value);
                    command.Parameters.AddWithValue("@Durum", comboBoxDurum.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@KategoriId", ((KeyValuePair<string, string>)comboBoxKategori.SelectedItem).Key);

                    if (ekipmanId.HasValue && ekipmanId > 0)
                    {
                        command.Parameters.AddWithValue("@EkipmanId", ekipmanId.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@GemiId", gemiId);
                    }

                    command.ExecuteNonQuery();
                    MessageBox.Show(ekipmanId.HasValue && ekipmanId > 0 ? "Ekipman başarıyla güncellendi." : "Ekipman başarıyla eklendi.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Kaydetme işlemi sırasında hata oluştu: {ex.Message}");
                }
            }
        }

        private bool KontrolEt()
        {
            List<string> hatalar = new List<string>();

            if (string.IsNullOrWhiteSpace(textBoxEkipmanAdi.Text))
                hatalar.Add("Ekipman Adı alanı boş bırakılamaz.");
            if (comboBoxKategori.SelectedItem == null)
                hatalar.Add("Lütfen bir kategori seçin.");

            if (hatalar.Count > 0)
            {
                MessageBox.Show(string.Join("\n", hatalar));
                return false;
            }

            return true;
        }

        private void buttonIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxEkipmanAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
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

