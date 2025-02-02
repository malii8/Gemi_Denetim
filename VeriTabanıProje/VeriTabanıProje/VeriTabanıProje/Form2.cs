using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTabanıProje
{
    public partial class Form2 : Form
    {
        static string BağlantıAdresi = ("Data Source=DESKTOP-SUOJ7H3;Initial Catalog=GemiYonetimi_DataBase;Integrated Security=True;Encrypt=False;TrustServerCertificate=False");
        private int kayitId;

        public Form2(int id)
        {
            InitializeComponent();
            kayitId = id;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ComboBoxDoldur();

            // Eğer düzenleme modundaysa bilgileri getir
            if (kayitId > 0)
            {
                BilgileriGetir();
            }
        }

        private void ComboBoxDoldur()
        {
            using (SqlConnection baglantı = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    baglantı.Open();

                    string query = "SELECT id, tur_adi FROM GemiTurleri";
                    SqlCommand command = new SqlCommand(query, baglantı);
                    SqlDataReader reader = command.ExecuteReader();

                    // ComboBox'ı temizlemeden önce verileri ekleyelim
                    comboBoxGemiTuru.Items.Clear();

                    while (reader.Read())
                    {
                        var keyValuePair = new KeyValuePair<string, string>(reader["id"].ToString(), reader["tur_adi"].ToString());
                        comboBoxGemiTuru.Items.Add(keyValuePair);
                    }

                    // Eğer veri varsa, ComboBox'ın display ve value üyelerini ayarlayın
                    if (comboBoxGemiTuru.Items.Count > 0)
                    {
                        comboBoxGemiTuru.DisplayMember = "Value"; // Kullanıcıya görünen kısmı
                        comboBoxGemiTuru.ValueMember = "Key";    // Veritabanına gönderilecek kısmı
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        private void BilgileriGetir()
        {
            using (SqlConnection baglantı = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    baglantı.Open();

                    string query = @"
                SELECT g.IMO_No, g.sicil_no, g.gemi_turu_id, gs.ad, gs.soyad, gs.tc, gs.telefon, gs.email, 
                       gs.adres, gs.dogumTarihi, gs.yas, g.yapim_tarihi, g.tonaj
                FROM Gemiler g
                JOIN GemiSahibi gs ON g.sahip_id = gs.id
                WHERE g.id = @Id";

                    SqlCommand command = new SqlCommand(query, baglantı);
                    command.Parameters.AddWithValue("@Id", kayitId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        textBoxIMO.Text = reader["IMO_No"].ToString();
                        textBoxSicilNo.Text = reader["sicil_no"].ToString();

                        // Gemi türünü ComboBox'tan seçmek için
                        string gemiTuruId = reader["gemi_turu_id"].ToString();
                        foreach (var item in comboBoxGemiTuru.Items)
                        {
                            if (((KeyValuePair<string, string>)item).Key == gemiTuruId)
                            {
                                comboBoxGemiTuru.SelectedItem = item;
                                break;
                            }
                        }

                        textBoxSahipAd.Text = reader["ad"].ToString();
                        textBoxSahipSoyad.Text = reader["soyad"].ToString();
                        textBoxTC.Text = reader["tc"].ToString();
                        textBoxTelefon.Text = reader["telefon"].ToString();
                        textBoxEmail.Text = reader["email"].ToString();
                        textBoxAdres.Text = reader["adres"].ToString();
                        dateTimePickerDogumTarihi.Value = Convert.ToDateTime(reader["dogumTarihi"]);
                        dateTimePickerYapimTarihi.Value = Convert.ToDateTime(reader["yapim_tarihi"]);
                        textBoxTonaj.Text = reader["tonaj"].ToString();

                        YasLable.Text = $"Yaş: {reader["yas"]}"; // Yaş bilgisini label'a ekleyelim
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        private void Kaydet_Click(object sender, EventArgs e)
        {
            if (!GirisKontrol())
                return;

            using (SqlConnection baglantı = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    baglantı.Open();

                    // Yaş hesaplama
                    DateTime dogumTarihi = dateTimePickerDogumTarihi.Value;
                    int yas = DateTime.Now.Year - dogumTarihi.Year;
                    if (DateTime.Now.Month < dogumTarihi.Month || (DateTime.Now.Month == dogumTarihi.Month && DateTime.Now.Day < dogumTarihi.Day))
                    {
                        yas--;
                    }

                    if (kayitId > 0)
                    {
                        // Güncelleme işlemi
                        string sahipGuncelleQuery = @"
                            UPDATE GemiSahibi
                            SET ad = @Ad, soyad = @Soyad, tc = @TC, telefon = @Telefon, email = @Email, 
                                adres = @Adres, dogumTarihi = @DogumTarihi, yas = @Yas
                            WHERE id = (SELECT sahip_id FROM Gemiler WHERE id = @Id)";

                        SqlCommand sahipGuncelleCommand = new SqlCommand(sahipGuncelleQuery, baglantı);
                        sahipGuncelleCommand.Parameters.AddWithValue("@Ad", textBoxSahipAd.Text);
                        sahipGuncelleCommand.Parameters.AddWithValue("@Soyad", textBoxSahipSoyad.Text);
                        sahipGuncelleCommand.Parameters.AddWithValue("@TC", textBoxTC.Text);
                        sahipGuncelleCommand.Parameters.AddWithValue("@Telefon", textBoxTelefon.Text);
                        sahipGuncelleCommand.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                        sahipGuncelleCommand.Parameters.AddWithValue("@Adres", textBoxAdres.Text);
                        sahipGuncelleCommand.Parameters.AddWithValue("@DogumTarihi", dogumTarihi);
                        sahipGuncelleCommand.Parameters.AddWithValue("@Yas", yas);
                        sahipGuncelleCommand.Parameters.AddWithValue("@Id", kayitId);

                        sahipGuncelleCommand.ExecuteNonQuery();

                        string gemiGuncelleQuery = @"
                            UPDATE Gemiler
                            SET IMO_No = @IMO_No, sicil_no = @SicilNo, gemi_turu_id = @GemiTuruId, 
                                yapim_tarihi = @YapimTarihi, tonaj = @Tonaj
                            WHERE id = @Id";

                        SqlCommand gemiGuncelleCommand = new SqlCommand(gemiGuncelleQuery, baglantı);
                        gemiGuncelleCommand.Parameters.AddWithValue("@IMO_No", textBoxIMO.Text);
                        gemiGuncelleCommand.Parameters.AddWithValue("@SicilNo", textBoxSicilNo.Text);
                        gemiGuncelleCommand.Parameters.AddWithValue("@GemiTuruId", ((KeyValuePair<string, string>)comboBoxGemiTuru.SelectedItem).Key);
                        gemiGuncelleCommand.Parameters.AddWithValue("@YapimTarihi", dateTimePickerYapimTarihi.Value);
                        gemiGuncelleCommand.Parameters.AddWithValue("@Tonaj", textBoxTonaj.Text);
                        gemiGuncelleCommand.Parameters.AddWithValue("@Id", kayitId);

                        gemiGuncelleCommand.ExecuteNonQuery();

                        MessageBox.Show("Kayıt başarıyla güncellendi!");
                    }
                    else
                    {
                        // Yeni kayıt işlemi
                        string sahipEkleQuery = @"
                            INSERT INTO GemiSahibi (ad, soyad, tc, dogumTarihi, telefon, email, adres, yas) 
                            VALUES (@Ad, @Soyad, @TC, @DogumTarihi, @Telefon, @Email, @Adres, @Yas);
                            SELECT SCOPE_IDENTITY();";

                        SqlCommand sahipEkleCommand = new SqlCommand(sahipEkleQuery, baglantı);
                        sahipEkleCommand.Parameters.AddWithValue("@Ad", textBoxSahipAd.Text);
                        sahipEkleCommand.Parameters.AddWithValue("@Soyad", textBoxSahipSoyad.Text);
                        sahipEkleCommand.Parameters.AddWithValue("@TC", textBoxTC.Text);
                        sahipEkleCommand.Parameters.AddWithValue("@DogumTarihi", dogumTarihi);
                        sahipEkleCommand.Parameters.AddWithValue("@Telefon", textBoxTelefon.Text);
                        sahipEkleCommand.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                        sahipEkleCommand.Parameters.AddWithValue("@Adres", textBoxAdres.Text);
                        sahipEkleCommand.Parameters.AddWithValue("@Yas", yas);

                        int sahipId = Convert.ToInt32(sahipEkleCommand.ExecuteScalar());

                        string gemiEkleQuery = @"
                            INSERT INTO Gemiler (IMO_No, sicil_no, gemi_turu_id, sahip_id, yapim_tarihi, tonaj) 
                            VALUES (@IMO_No, @SicilNo, @GemiTuruId, @SahipId, @YapimTarihi, @Tonaj)";

                        SqlCommand gemiEkleCommand = new SqlCommand(gemiEkleQuery, baglantı);
                        gemiEkleCommand.Parameters.AddWithValue("@IMO_No", textBoxIMO.Text);
                        gemiEkleCommand.Parameters.AddWithValue("@SicilNo", textBoxSicilNo.Text);
                        gemiEkleCommand.Parameters.AddWithValue("@GemiTuruId", ((KeyValuePair<string, string>)comboBoxGemiTuru.SelectedItem).Key);
                        gemiEkleCommand.Parameters.AddWithValue("@SahipId", sahipId);
                        gemiEkleCommand.Parameters.AddWithValue("@YapimTarihi", dateTimePickerYapimTarihi.Value);
                        gemiEkleCommand.Parameters.AddWithValue("@Tonaj", textBoxTonaj.Text);

                        gemiEkleCommand.ExecuteNonQuery();

                        MessageBox.Show("Kayıt başarıyla eklendi!");
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        public bool GirisKontrol()
        {
            List<string> hatalar = new List<string>();

            // Hata kontrolü
            if (string.IsNullOrWhiteSpace(textBoxIMO.Text))
                hatalar.Add("Lütfen IMO No alanını doldurun.");
            if (string.IsNullOrWhiteSpace(textBoxSicilNo.Text))
                hatalar.Add("Lütfen Sicil No alanını doldurun.");
            if (comboBoxGemiTuru.SelectedItem == null)
                hatalar.Add("Lütfen bir Gemi Türü seçin.");
            if (dateTimePickerYapimTarihi.Value >= DateTime.Now)
                hatalar.Add("Gemi yapım tarihi bugünden önce olmalıdır.");
            if (string.IsNullOrWhiteSpace(textBoxSahipAd.Text))
                hatalar.Add("Lütfen Sahibin Adı alanını doldurun.");
            if (string.IsNullOrWhiteSpace(textBoxSahipSoyad.Text))
                hatalar.Add("Lütfen Sahibin Soyadı alanını doldurun.");
            if (string.IsNullOrWhiteSpace(textBoxTC.Text))
                hatalar.Add("Lütfen TC Kimlik Numarası alanını doldurun.");
            if (string.IsNullOrWhiteSpace(textBoxTelefon.Text))
                hatalar.Add("Lütfen Telefon alanını doldurun.");
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
                hatalar.Add("Lütfen Email alanını doldurun.");
            if (string.IsNullOrWhiteSpace(textBoxAdres.Text))
                hatalar.Add("Lütfen Adres alanını doldurun.");
            if (string.IsNullOrWhiteSpace(textBoxTonaj.Text))
                hatalar.Add("Lütfen Tonaj alanını doldurun.");


            if (hatalar.Count > 0)
            {
                MessageBox.Show(string.Join("\n", hatalar));
                return false;
            }

            return true;
        }

        private void YasLable_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
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

        private void textBoxTC_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
