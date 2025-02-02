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
    public partial class Form4 : Form
    {
        // Veritabanı bağlantı dizesi
        static string BağlantıAdresi = "Data Source=DESKTOP-SUOJ7H3;Initial Catalog=GemiYonetimi_DataBase;Integrated Security=True;Encrypt=False;TrustServerCertificate=False";
        private int gemiId;
        private int? denetimId; // Nullable, eğer null ise yeni denetim ekleniyor

        // Constructor for new denetim (denetimId null)
        public Form4(int gemiId)
        {
            InitializeComponent();
            this.gemiId = gemiId;
            this.denetimId = null;
        }

        // Constructor for editing existing denetim
        public Form4(int gemiId, int denetimId)
        {
            InitializeComponent();
            this.gemiId = gemiId;
            this.denetimId = denetimId;
        }

        // Form yüklendiğinde çalışacak olay
        private void Form4_Load(object sender, EventArgs e)
        {
            DenetimTurleriniGetir();

            // Denetim durumu ComboBox'ına sabit veri ekleme
            comboBoxDenetimDurumu.Items.Add("Devam Ediyor");
            comboBoxDenetimDurumu.Items.Add("Tamamlandı");

            // İlk seçim olarak "Devam Ediyor" ayarla (isteğe bağlı)
            comboBoxDenetimDurumu.SelectedIndex = 0;

            // Denetim durumu değişim olayını ekleyelim
            comboBoxDenetimDurumu.SelectedIndexChanged += comboBoxDenetimDurumu_SelectedIndexChanged;
            comboBoxDenetimTuru.SelectedIndexChanged += comboBoxDenetimTuru_SelectedIndexChanged;

            if (denetimId.HasValue && denetimId > 0)
            {
                // Mevcut denetim bilgilerini yükle
                DenetimBilgileriniGetir();
            }
            else
            {
                // Yeni denetim ekleme modunda, kriterleri yükle
                KriterleriYukle();
            }
        }

        // Denetim Türlerini ComboBox'a yükleyen metod
        private void DenetimTurleriniGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    baglanti.Open();
                    string query = "SELECT id, tur_adi FROM KontrolTurleri ORDER BY tur_adi";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, baglanti);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // ComboBox'ı uygun şekilde veri kaynağına bağlayın
                    comboBoxDenetimTuru.DisplayMember = "tur_adi"; // Görüntülenecek alan
                    comboBoxDenetimTuru.ValueMember = "id"; // Seçilen değerin ID'si
                    comboBoxDenetimTuru.DataSource = table;
                    comboBoxDenetimTuru.SelectedIndex = -1; // Başlangıçta seçili öğe olmaması için
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Denetim türleri getirilirken bir hata oluştu: {ex.Message}");
                }
            }
        }

        // Denetim Türüne bağlı olarak kriterleri yükleyen metod
        private void KriterleriYukle()
        {
            if (comboBoxDenetimTuru.SelectedValue == null)
            {
                // Denetim türü seçilmediyse kriterleri yüklemeyin
                dataGridViewKriterler.DataSource = null;
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    string query = "SELECT id, kriter, onem_duzeyi FROM KontrolKriterleri WHERE kontrol_tur_id = @TurId";
                    SqlCommand command = new SqlCommand(query, baglanti);
                    command.Parameters.AddWithValue("@TurId", comboBoxDenetimTuru.SelectedValue);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewKriterler.DataSource = table;
                    dataGridViewKriterler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Kriterler yüklenirken bir hata oluştu: {ex.Message}");
                }
            }
        }

        // Mevcut denetimin bilgilerini yükleyen metod (Düzenleme modunda)
        private void DenetimBilgileriniGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    string query = @"SELECT kontrol_tur_id, kontrol_tarih, durum, kontrol_tarih_bitits 
                                     FROM Kontroller 
                                     WHERE id = @DenetimId";
                    SqlCommand command = new SqlCommand(query, baglanti);
                    command.Parameters.AddWithValue("@DenetimId", denetimId.Value); // denetimId kullanılıyor

                    baglanti.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Denetim Türünü seç
                        comboBoxDenetimTuru.SelectedValue = reader["kontrol_tur_id"];
                        dateTimePickerTarih.Value = Convert.ToDateTime(reader["kontrol_tarih"]);
                        comboBoxDenetimDurumu.SelectedItem = reader["durum"].ToString();

                        if (reader["kontrol_tarih_bitits"] != DBNull.Value)
                        {
                            dateTimePickerBitisTarih.Value = Convert.ToDateTime(reader["kontrol_tarih_bitits"]);
                            dateTimePickerBitisTarih.Enabled = true;
                        }
                        else
                        {
                            dateTimePickerBitisTarih.Enabled = false;
                        }
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

        // "Kaydet" butonuna tıklandığında çalışacak olay
        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            if (!KontrolEt())
                return;

            using (SqlConnection baglanti = new SqlConnection(BağlantıAdresi))
            {
                try
                {
                    baglanti.Open();

                    string query;
                    if (denetimId.HasValue && denetimId > 0)
                    {
                        // Güncelleme işlemi
                        query = @"
                            UPDATE Kontroller 
                            SET kontrol_tur_id = @TurId, 
                                kontrol_tarih = @Tarih, 
                                durum = @Durum, 
                                kontrol_tarih_bitits = @BitisTarih
                            WHERE id = @DenetimId";
                    }
                    else
                    {
                        // Yeni kayıt işlemi
                        query = @"
                            INSERT INTO Kontroller (gemi_id, kontrol_tur_id, kontrol_tarih, durum, kontrol_tarih_bitits)
                            VALUES (@GemiId, @TurId, @Tarih, @Durum, @BitisTarih)";
                    }

                    SqlCommand command = new SqlCommand(query, baglanti);

                    if (denetimId.HasValue && denetimId > 0)
                    {
                        command.Parameters.AddWithValue("@DenetimId", denetimId.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@GemiId", gemiId);
                    }

                    // ComboBox'tan seçilen değeri kullanıyoruz
                    command.Parameters.AddWithValue("@TurId", comboBoxDenetimTuru.SelectedValue);
                    command.Parameters.AddWithValue("@Tarih", dateTimePickerTarih.Value);
                    command.Parameters.AddWithValue("@Durum", comboBoxDenetimDurumu.SelectedItem.ToString());

                    // Duruma bağlı olarak bitiş tarihini ayarlıyoruz
                    if (comboBoxDenetimDurumu.SelectedItem.ToString() == "Tamamlandı")
                    {
                        command.Parameters.AddWithValue("@BitisTarih", dateTimePickerBitisTarih.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@BitisTarih", DBNull.Value);
                    }

                    command.ExecuteNonQuery();

                    MessageBox.Show(denetimId.HasValue && denetimId > 0 ? "Denetim başarıyla güncellendi." : "Denetim başarıyla eklendi.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        // Verilerin doğru girildiğini kontrol eden metod
        private bool KontrolEt()
        {
            List<string> hatalar = new List<string>();

            if (comboBoxDenetimTuru.SelectedValue == null)
                hatalar.Add("Lütfen bir denetim türü seçin.");

            if (comboBoxDenetimDurumu.SelectedItem == null)
                hatalar.Add("Lütfen bir denetim durumu seçin.");

            if (comboBoxDenetimDurumu.SelectedItem.ToString() == "Tamamlandı" && !dateTimePickerBitisTarih.Enabled)
                hatalar.Add("Denetim tamamlandığında bitiş tarihi girmelisiniz.");

            if (hatalar.Count > 0)
            {
                MessageBox.Show(string.Join("\n", hatalar));
                return false;
            }

            return true;
        }

        // "İptal" butonuna tıklandığında formu kapatan olay
        private void buttonIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Denetim Durumu ComboBox'ında seçim değiştiğinde bitiş tarihini ayarlayan olay
        private void comboBoxDenetimDurumu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDenetimDurumu.SelectedItem != null && comboBoxDenetimDurumu.SelectedItem.ToString() == "Tamamlandı")
            {
                dateTimePickerBitisTarih.Enabled = true;
                dateTimePickerBitisTarih.Focus();
            }
            else
            {
                dateTimePickerBitisTarih.Enabled = false;
                dateTimePickerBitisTarih.Value = DateTime.Now;
            }
        }

        // Denetim Türü ComboBox'ında seçim değiştiğinde kriterleri yükleyen olay
        private void comboBoxDenetimTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            KriterleriYukle();
        }

        private void lblKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void lblKapat_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
