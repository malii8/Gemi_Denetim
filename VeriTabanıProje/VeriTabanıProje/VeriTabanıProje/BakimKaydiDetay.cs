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
    public partial class BakimKaydiDetay : Form
    {
        static string BağlantıAdresi = "Data Source=DESKTOP-SUOJ7H3;Initial Catalog=GemiYonetimi_DataBase;Integrated Security=True;Encrypt=False;TrustServerCertificate=False";
        private int ekipmanId;
        private int? bakimId; // Nullable, 0 veya null ise yeni kayıt

        public BakimKaydiDetay(int id, int? bakimId = null)
        {
            InitializeComponent();
            ekipmanId = id;
            this.bakimId = bakimId;
        }

        private void BakimKaydiDetay_Load_1(object sender, EventArgs e)
        {
            DurumlariGetir();

            if (bakimId.HasValue && bakimId > 0)
            {
                // Düzenleme modunda, mevcut verileri yükle
                BakimKaydiBilgileriniGetir();
            }
            else
            {
                // Yeni kayıt modunda, varsayılan değerleri ayarla
                comboBoxBakimDurumu.SelectedIndex = 0; // Tamamlandı
                dateTimePickerBirSonrakiBakimTarihi.Enabled = false;
            }
        }

        private void DurumlariGetir()
        {
            comboBoxBakimDurumu.Items.Clear();
            comboBoxBakimDurumu.Items.Add("Tamamlandı");
            comboBoxBakimDurumu.Items.Add("Devam Ediyor");
            comboBoxBakimDurumu.Items.Add("Planlandı");
            comboBoxBakimDurumu.SelectedIndex = 0; // Varsayılan "Tamamlandı"
        }

        private void BakimKaydiBilgileriniGetir()
        {
            using (SqlConnection baglantı = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    baglantı.Open();
                    string query = @"
                        SELECT son_bakim_tarih, bir_sonraki_bakim_tarihi, bakim_durumu, aciklama
                        FROM BakimKayitlari
                        WHERE id = @BakimId";
                    SqlCommand command = new SqlCommand(query, baglantı);
                    command.Parameters.AddWithValue("@BakimId", bakimId.Value);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        dateTimePickerSonBakimTarihi.Value = Convert.ToDateTime(reader["son_bakim_tarih"]);
                        if (reader["bir_sonraki_bakim_tarihi"] != DBNull.Value)
                        {
                            dateTimePickerBirSonrakiBakimTarihi.Value = Convert.ToDateTime(reader["bir_sonraki_bakim_tarihi"]);
                            dateTimePickerBirSonrakiBakimTarihi.Enabled = true;
                        }
                        else
                        {
                            dateTimePickerBirSonrakiBakimTarihi.Enabled = false;
                        }

                        comboBoxBakimDurumu.SelectedItem = reader["bakim_durumu"].ToString();
                        textBoxAciklama.Text = reader["aciklama"].ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bakım kaydı bilgileri getirilirken hata oluştu: {ex.Message}");
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

                    if (bakimId.HasValue && bakimId > 0)
                    {
                        // Güncelleme işlemi
                        query = @"
                            UPDATE BakimKayitlari
                            SET son_bakim_tarih = @SonBakimTarihi,
                                bir_sonraki_bakim_tarihi = @BirSonrakiBakimTarihi,
                                bakim_durumu = @BakimDurumu,
                                aciklama = @Aciklama
                            WHERE id = @BakimId";
                    }
                    else
                    {
                        // Yeni kayıt işlemi
                        query = @"
                            INSERT INTO BakimKayitlari (ekipman_id, son_bakim_tarih, bir_sonraki_bakim_tarihi, bakim_durumu, aciklama)
                            VALUES (@EkipmanId, @SonBakimTarihi, @BirSonrakiBakimTarihi, @BakimDurumu, @Aciklama)";
                    }

                    SqlCommand command = new SqlCommand(query, baglantı);
                    command.Parameters.AddWithValue("@SonBakimTarihi", dateTimePickerSonBakimTarihi.Value);
                    command.Parameters.AddWithValue("@BakimDurumu", comboBoxBakimDurumu.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Aciklama", textBoxAciklama.Text.Trim());

                    if (comboBoxBakimDurumu.SelectedItem.ToString() == "Planlandı" ||
                        comboBoxBakimDurumu.SelectedItem.ToString() == "Tamamlandı")
                    {
                        command.Parameters.AddWithValue("@BirSonrakiBakimTarihi", dateTimePickerBirSonrakiBakimTarihi.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@BirSonrakiBakimTarihi", DBNull.Value);
                    }

                    if (bakimId.HasValue && bakimId > 0)
                    {
                        command.Parameters.AddWithValue("@BakimId", bakimId.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@EkipmanId", ekipmanId);
                    }

                    command.ExecuteNonQuery();
                    MessageBox.Show(bakimId.HasValue && bakimId > 0 ? "Bakım kaydı başarıyla güncellendi." : "Bakım kaydı başarıyla eklendi.");
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

            if (comboBoxBakimDurumu.SelectedItem.ToString() == "Planlandı" && dateTimePickerBirSonrakiBakimTarihi.Value <= dateTimePickerSonBakimTarihi.Value)
                hatalar.Add("Bir sonraki bakım tarihi, son bakım tarihinden sonra olmalıdır.");

            if (comboBoxBakimDurumu.SelectedItem.ToString() == "Tamamlandı" && dateTimePickerSonBakimTarihi.Value > DateTime.Now)
                hatalar.Add("Son bakım tarihi bugünden önce olmalıdır.");

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

        private void comboBoxBakimDurumu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBakimDurumu.SelectedItem.ToString() == "Planlandı" || comboBoxBakimDurumu.SelectedItem.ToString() == "Tamamlandı")
            {
                dateTimePickerBirSonrakiBakimTarihi.Enabled = true;
            }
            else
            {
                dateTimePickerBirSonrakiBakimTarihi.Enabled = false;
                dateTimePickerBirSonrakiBakimTarihi.Value = DateTime.Now;
            }
        }

        private void textBoxAciklama_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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
