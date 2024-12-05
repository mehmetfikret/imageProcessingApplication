using System.Xml.XPath;

namespace goruntuisleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(new string[]
            {
                "Gri Yap",
                "Binary Yap",
                "Görüntü Döndürme",
                "Görüntü Kýrpma",
                "Görüntüyü Zoomla",
                "Aritmetik Ýþlem (Çýkarma)",
                "Aritmetik Ýþlem (Çarpma)",
                "HSV'ye Dönüþtür",
                "Grayscale'e Dönüþtür",
                "Histogram Germe",
                "Kontrast Azaltma",
                "Konvolüsyon Ýþlemi (Median)",
                "Çift Eþikleme",
                "Canny Kenar Bulma",
                "Salt & Pepper Gürültü Ekle",
                "Mean Filtre ile Gürültü Temizleme",
                "Median Filtre ile Gürültü Temizleme",
                "Motion Filtresi",
                "Geniþleme",
                "Aþýnma",
                "Açma",
                "Kapama"
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Deðer: " + trackBar1.Value.ToString();
            label2.BackColor = Color.Green;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "resimler|*.bmp|All Files|*.*";

            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            pictureBox1.ImageLocation = ofd.FileName;
        }

        private void buttonLoad2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "resimler|*.bmp|All Files|*.*";

            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            pictureBox3.ImageLocation = ofd.FileName;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("Lütfen önce bir iþlem yapýnýz.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Bitmap Image|*.bmp";
            sfd.Title = "Ýþlenmiþ Görüntüyü Kaydet";
            sfd.FileName = "islenmis_goruntu";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(sfd.FileName);
            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Lütfen önce bir resim yükleyin.");
                return;
            }

            string selectedOperation = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedOperation))
            {
                MessageBox.Show("Lütfen bir iþlem seçin.");
                return;
            }

            Bitmap original = new Bitmap(pictureBox1.Image);
            Bitmap original1 = pictureBox3.Image != null ? new Bitmap(pictureBox3.Image) : null;

            Bitmap result = null;

            if ((selectedOperation == "Aritmetik Ýþlem (Çýkarma)" || selectedOperation == "Aritmetik Ýþlem (Çarpma)") && original1 == null)
            {
                MessageBox.Show("Lütfen ikinci resmi yükleyin.");
                return;
            }

            switch (selectedOperation)
            {
                case "Gri Yap":
                    result = griDonusum(original);
                    break;
                case "Binary Yap":
                    int threshold = 128;
                    result = binaryDonusum(original, threshold);
                    break;
                case "Görüntü Döndürme":
                    float angle = trackBar1.Value;
                    result = goruntuDondurme(original, angle);
                    break;
                case "Görüntü Kýrpma":
                    if (!int.TryParse(textBoxX.Text, out int x) ||
                        !int.TryParse(textBoxY.Text, out int y) ||
                        !int.TryParse(textBoxWidth.Text, out int width) ||
                        !int.TryParse(textBoxHeight.Text, out int height))
                    {
                        MessageBox.Show("Lütfen geçerli kýrpma deðerleri (X, Y, En, Boy) giriniz.");
                        return;
                    }
                    result = goruntuKirpma(original, x, y, width, height);
                    break;
                case "Görüntüyü Zoomla":
                    if (!int.TryParse(textBoxX.Text, out int centerX) ||
                        !int.TryParse(textBoxY.Text, out int centerY))
                    {
                        MessageBox.Show("Lütfen geçerli X ve Y koordinat deðerlerini giriniz.");
                        return;
                    }
                    result = goruntuZoomla(original, trackBar1.Value, centerX, centerY);
                    break;
                case "Aritmetik Ýþlem (Çýkarma)":
                    result = goruntuCikarma(original, original1);
                    break;
                case "Aritmetik Ýþlem (Çarpma)":
                    result = goruntuCarpma(original, original1);
                    break;
                case "HSV'ye Dönüþtür":
                    result = HSVdonusum(original);
                    break;
                case "Grayscale'e Dönüþtür":
                    result = griDonusum(original);
                    break;
                case "Histogram Germe":
                    result = histogramGerme(original);
                    break;
                case "Kontrast Azaltma":
                    int scaleValue = trackBar1.Value;
                    result = kontrastAzaltma(original, scaleValue);
                    break;
                case "Konvolüsyon Ýþlemi (Median)":
                    result = konvolusyonIslemi(original, 3); // Çekirdek boyutu
                    break;
                case "Çift Eþikleme":
                    if (!int.TryParse(txtAlt.Text, out int altEsik) ||
                        !int.TryParse(txtUst.Text, out int ustEsik))
                    {
                        MessageBox.Show("Lütfen geçerli alt ve üst eþik deðerlerini giriniz.");
                        return;
                    }
                    result = ciftEsikleme(original, altEsik, ustEsik);
                    break;
                case "Canny Kenar Bulma":
                    if (!int.TryParse(txtAlt.Text, out int altEsikDeger) ||
                        !int.TryParse(txtUst.Text, out int ustEsikDeger))
                    {
                        MessageBox.Show("Lütfen geçerli alt ve üst eþik deðerlerini giriniz.");
                        return;
                    }
                    result = cannyKenarBulma(original, altEsikDeger, ustEsikDeger);
                    break;
                case "Salt & Pepper Gürültü Ekle":
                    if (!double.TryParse(textBoxNoise.Text, out double noiseLevel))
                    {
                        MessageBox.Show("Lütfen geçeri gürültü seviyesi giriniz.");
                        break;
                    }
                    result = saltPepperGurultusu(original, noiseLevel);
                    break;
                case "Mean Filtre ile Gürültü Temizleme":
                    result = meanFiltre(original, 3); // Çekirdek boyutu
                    break;
                case "Median Filtre ile Gürültü Temizleme":
                    result = medyanFiltre(original, 3); // Çekirdek boyutu
                    break;
                case "Motion Filtresi":
                    if (!int.TryParse(textBoxUzunluk.Text, out int motionLength))
                    {
                        MessageBox.Show("Lütfen geçerli bir uzunluk deðeri giriniz.");
                        return;
                    }
                    double motionAngle = trackBar1.Value; // Uygulanacak açý (örneðin 45 derece)
                    result = motionBlur(original, motionLength, motionAngle);
                    break;
                case "Geniþleme":
                    result = genisleme(original, kernel3x3);
                    break;
                case "Aþýnma":
                    result = asinma(original, kernel3x3);
                    break;
                case "Açma":
                    result = acma(original, kernel3x3);
                    break;
                case "Kapama":
                    result = kapama(original, kernel3x3);
                    break;
                default:
                    MessageBox.Show("Geçersiz iþlem.");
                    return;
            }

            if (result != null)
            {
                pictureBox2.Image = result;
            }
        }

        private Bitmap griDonusum(Bitmap original)
        {
            Bitmap griyeDonusum = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Height; i++)
            {
                for (int j = 0; j < original.Width; j++)
                {
                    Color orijinalRenk = original.GetPixel(j, i);
                    int griTonlama = (int)((orijinalRenk.R * 0.3) + (orijinalRenk.G * 0.59) + (orijinalRenk.B * 0.11));
                    Color gri = Color.FromArgb(griTonlama, griTonlama, griTonlama);
                    griyeDonusum.SetPixel(j, i, gri);
                }
            }
            return griyeDonusum;
        }

        private Bitmap binaryDonusum(Bitmap bmp, int e)
        {
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    int griDeger = (bmp.GetPixel(j, i).R + bmp.GetPixel(j, i).G + bmp.GetPixel(j, i).B) / 3;
                    Color renk = griDeger >= e ? Color.White : Color.Black;
                    bmp.SetPixel(j, i, renk);
                }
            }
            return bmp;
        }

        private Bitmap goruntuDondurme(Bitmap bmp, float angle)
        {

            double radyan = (Math.PI / 180) * angle;

            double cos = Math.Cos(radyan);
            double sin = Math.Sin(radyan);

            int width = bmp.Width;
            int height = bmp.Height;

            int newWidth = (int)(Math.Abs(width * cos) + Math.Abs(height * sin));
            int newHeight = (int)(Math.Abs(height * cos) + Math.Abs(width * sin));

            Bitmap dondurulmusGoruntu = new Bitmap(newWidth, newHeight);

            int x0 = width / 2;
            int y0 = height / 2;
            int x1 = newWidth / 2;
            int y1 = newHeight / 2;

            for (int x = 0; x < newWidth; x++)
            {
                for (int y = 0; y < newHeight; y++)
                {
                    int eskiX = (int)((x - x1) * cos + (y - y1) * sin + x0);
                    int eskiY = (int)(-(x - x1) * sin + (y - y1) * cos + y0);

                    if (eskiX >= 0 && eskiX < width && eskiY >= 0 && eskiY < height)
                    {
                        dondurulmusGoruntu.SetPixel(x, y, bmp.GetPixel(eskiX, eskiY));
                    }
                    else
                    {
                        dondurulmusGoruntu.SetPixel(x, y, Color.White);
                    }
                }
            }
            return dondurulmusGoruntu;
        }

        private Bitmap goruntuKirpma(Bitmap kaynak, int x, int y, int width, int height)
        {

            int kucukX = Math.Max(0, x);
            int kucukY = Math.Max(0, y);
            int buyukX = Math.Min(kaynak.Width, x + width);
            int buyukY = Math.Min(kaynak.Height, y + height);

            int kirpilmisGenislik = buyukX - kucukX;
            int kirpilmisYukseklik = buyukY - kucukY;

            Bitmap kirpilmisGoruntu = new Bitmap(kirpilmisGenislik, kirpilmisYukseklik);

            for (int i = 0; i < kirpilmisGenislik; i++)
            {
                for (int j = 0; j < kirpilmisYukseklik; j++)
                {
                    Color renk = kaynak.GetPixel(kucukX + i, kucukY + j);
                    kirpilmisGoruntu.SetPixel(i, j, renk);
                }
            }

            return kirpilmisGoruntu;
        }

        private Bitmap goruntuZoomla(Bitmap bmp, int trackBarValue, int merkezX, int merkezY)
        {

            float olcek = trackBarValue / 100f;
            if (olcek <= 0) olcek = 0.01f;

            int zoomWidth = (int)(bmp.Width / olcek);
            int zoomHeight = (int)(bmp.Height / olcek);

            int baslangicX = merkezX - zoomWidth / 2;
            int baslangicY = merkezY - zoomHeight / 2;

            if (baslangicX < 0) baslangicX = 0;
            if (baslangicY < 0) baslangicY = 0;
            if (baslangicX + zoomWidth > bmp.Width) zoomWidth = bmp.Width - baslangicX;
            if (baslangicY + zoomHeight > bmp.Height) zoomHeight = bmp.Height - baslangicY;

            Bitmap zoomed = new Bitmap(bmp.Width, bmp.Height);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    int kaynakX = baslangicX + (int)(x * zoomWidth / (float)bmp.Width);
                    int kaynakY = baslangicY + (int)(y * zoomHeight / (float)bmp.Height);

                    if (kaynakX >= zoomWidth + baslangicX) kaynakX = zoomWidth + baslangicX - 1;
                    if (kaynakY >= zoomHeight + baslangicY) kaynakY = zoomHeight + baslangicY - 1;

                    zoomed.SetPixel(x, y, bmp.GetPixel(kaynakX, kaynakY));
                }
            }

            return zoomed;
        }

        private Bitmap goruntuCikarma(Bitmap bmp1, Bitmap bmp2)
        {
            int width = Math.Min(bmp1.Width, bmp2.Width);
            int height = Math.Min(bmp1.Height, bmp2.Height);
            Bitmap sonuc = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color c1 = bmp1.GetPixel(x, y);
                    Color c2 = bmp2.GetPixel(x, y);

                    int r = Math.Max(c1.R - c2.R, 0);
                    int g = Math.Max(c1.G - c2.G, 0);
                    int b = Math.Max(c1.B - c2.B, 0);

                    sonuc.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return sonuc;
        }

        private Bitmap goruntuCarpma(Bitmap bmp1, Bitmap bmp2)
        {
            int width = Math.Min(bmp1.Width, bmp2.Width);
            int height = Math.Min(bmp1.Height, bmp2.Height);
            Bitmap sonuc = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color c1 = bmp1.GetPixel(x, y);
                    Color c2 = bmp2.GetPixel(x, y);

                    int r = Math.Min((c1.R * c2.R) / 255, 255);
                    int g = Math.Min((c1.G * c2.G) / 255, 255);
                    int b = Math.Min((c1.B * c2.B) / 255, 255);

                    sonuc.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return sonuc;
        }

        private Bitmap HSVdonusum(Bitmap original)
        {
            Bitmap hsvResim = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Height; i++)
            {
                for (int j = 0; j < original.Width; j++)
                {
                    Color orijinalRenk = original.GetPixel(j, i);
                    float renkTonu, doygunluk, deger;
                    RGBtoHSV(orijinalRenk.R, orijinalRenk.G, orijinalRenk.B, out renkTonu, out doygunluk, out deger);

                    Color hsvColor = Color.FromArgb((int)(renkTonu / 360 * 255), (int)(doygunluk * 255), (int)(deger * 255));
                    hsvResim.SetPixel(j, i, hsvColor);
                }
            }
            return hsvResim;
        }

        public void RGBtoHSV(int red, int green, int blue, out float renktonu, out float doygunluk, out float deger)
        {
            float r = red / 255.0f;
            float g = green / 255.0f;
            float b = blue / 255.0f;

            float max = Math.Max(r, Math.Max(g, b));
            float min = Math.Min(r, Math.Min(g, b));
            float fark = max - min;

            renktonu = 0;
            if (fark != 0)
            {
                if (max == r)
                {
                    renktonu = 60 * (((g - b) / fark) % 6);
                }
                else if (max == g)
                {
                    renktonu = 60 * (((b - r) / fark) + 2);
                }
                else if (max == b)
                {
                    renktonu = 60 * (((r - g) / fark) + 4);
                }
            }

            doygunluk = (max == 0) ? 0 : fark / max;
            deger = max;

            renktonu = (renktonu < 0) ? renktonu + 360 : renktonu;
        }

        private Color HSVRenkAl(float renkTonu, float doygunluk, float deger)
        {

            int renkKategori = Convert.ToInt32(Math.Floor(renkTonu / 60)) % 6;
            float f = (float)(renkTonu / 60 - Math.Floor(renkTonu / 60));

            deger = deger * 255;
            int v = Convert.ToInt32(deger);
            int p = Convert.ToInt32(deger * (1 - doygunluk));
            int q = Convert.ToInt32(deger * (1 - f * doygunluk));
            int t = Convert.ToInt32(deger * (1 - (1 - f) * doygunluk));

            switch (renkKategori)
            {
                case 0:
                    return Color.FromArgb(v, t, p);
                case 1:
                    return Color.FromArgb(q, v, p);
                case 2:
                    return Color.FromArgb(p, v, t);
                case 3:
                    return Color.FromArgb(p, q, v);
                case 4:
                    return Color.FromArgb(t, p, v);
                default:
                    return Color.FromArgb(v, p, q);
            }
        }

        private Bitmap histogramGerme(Bitmap bmp)
        {
            Bitmap yeniBitmap = new Bitmap(bmp.Width, bmp.Height);
            int[] histogram = new int[256];
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    int gray = bmp.GetPixel(x, y).R;
                    histogram[gray]++;
                }
            }

            int min = Array.FindIndex(histogram, count => count > 0);
            int max = Array.FindLastIndex(histogram, count => count > 0);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    int gray = bmp.GetPixel(x, y).R;
                    int stretchedGray = (gray - min) * 255 / (max - min);
                    Color newColor = Color.FromArgb(stretchedGray, stretchedGray, stretchedGray);
                    yeniBitmap.SetPixel(x, y, newColor);
                }
            }
            return yeniBitmap;
        }

        private Bitmap kontrastAzaltma(Bitmap bmp, int scale)
        {
            Bitmap azaltilmisKontrast = new Bitmap(bmp.Width, bmp.Height);
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color orijinalRenk = bmp.GetPixel(x, y);
                    int ortalama = (orijinalRenk.R + orijinalRenk.G + orijinalRenk.B) / 3;
                    int newR = ortalama + (orijinalRenk.R - ortalama) * scale / 100;
                    int newG = ortalama + (orijinalRenk.G - ortalama) * scale / 100;
                    int newB = ortalama + (orijinalRenk.B - ortalama) * scale / 100;
                    Color yeniRenk = Color.FromArgb(Clamp(newR), Clamp(newG), Clamp(newB));
                    azaltilmisKontrast.SetPixel(x, y, yeniRenk);
                }
            }
            return azaltilmisKontrast;
        }

        private int Clamp(int value)
        {
            return Math.Max(0, Math.Min(255, value));
        }

        private Bitmap konvolusyonIslemi(Bitmap bmp, int size)
        {
            Bitmap filtreleme = new Bitmap(bmp.Width, bmp.Height);
            int pxKaydirma = size / 2;
            for (int y = pxKaydirma; y < bmp.Height - pxKaydirma; y++)
            {
                for (int x = pxKaydirma; x < bmp.Width - pxKaydirma; x++)
                {
                    List<int> pxBolge = new List<int>();
                    for (int fy = -pxKaydirma; fy <= pxKaydirma; fy++)
                    {
                        for (int fx = -pxKaydirma; fx <= pxKaydirma; fx++)
                        {
                            pxBolge.Add(bmp.GetPixel(x + fx, y + fy).R);
                        }
                    }
                    pxBolge.Sort();
                    int ortaDeger = pxBolge[pxBolge.Count / 2];
                    Color ortaRenk = Color.FromArgb(ortaDeger, ortaDeger, ortaDeger);
                    filtreleme.SetPixel(x, y, ortaRenk);
                }
            }
            return filtreleme;
        }

        private Bitmap ciftEsikleme(Bitmap bmp, int altEsik, int ustEsik)
        {
            Bitmap esikGoruntu = new Bitmap(bmp.Width, bmp.Height);
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    int gri = bmp.GetPixel(x, y).R;
                    if (gri < altEsik)
                        esikGoruntu.SetPixel(x, y, Color.Black);
                    else if (gri > ustEsik)
                        esikGoruntu.SetPixel(x, y, Color.White);
                    else
                        esikGoruntu.SetPixel(x, y, Color.Gray);
                }
            }
            return esikGoruntu;
        }

        private Bitmap cannyKenarBulma(Bitmap bmp, int altEsik, int ustEsik)
        {
            Bitmap sonuc = new Bitmap(bmp.Width, bmp.Height);
            double[,] sobelX = new double[,]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };

            double[,] sobelY = new double[,]
            {
                { -1, -2, -1 },
                { 0, 0, 0 },
                { 1, 2, 1 }
            };

            Bitmap griResim = griDonusum(bmp);

            double[,] boyut = new double[griResim.Width, griResim.Height];
            double[,] yon = new double[griResim.Width, griResim.Height];

            for (int i = 1; i < griResim.Height - 1; i++)
            {
                for (int j = 1; j < griResim.Width - 1; j++)
                {
                    double gx = 0;
                    double gy = 0;

                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            int pikselYogunlugu = griResim.GetPixel(j + l, i + k).R;
                            gx += sobelX[k + 1, l + 1] * pikselYogunlugu;
                            gy += sobelY[k + 1, l + 1] * pikselYogunlugu;
                        }
                    }

                    boyut[j, i] = Math.Sqrt(gx * gx + gy * gy);
                    yon[j, i] = Math.Atan2(gy, gx) * (180 / Math.PI);

                    if (yon[j, i] < 0)
                    {
                        yon[j, i] += 360;
                    }
                }
            }

            Bitmap kenarResmi = new Bitmap(griResim.Width, griResim.Height);

            for (int i = 1; i < griResim.Height - 1; i++)
            {
                for (int j = 1; j < griResim.Width - 1; j++)
                {
                    double aci = yon[j, i];

                    bool kenarMi = false;

                    if ((aci >= 0 && aci < 22.5) || (aci >= 157.5 && aci < 202.5) || (aci >= 337.5 && aci < 360))
                    {
                        kenarMi = boyut[j, i] >= boyut[j + 1, i] && boyut[j, i] >= boyut[j - 1, i];
                    }
                    else if ((aci >= 22.5 && aci < 67.5) || (aci >= 202.5 && aci < 247.5))
                    {
                        kenarMi = boyut[j, i] >= boyut[j + 1, i + 1] && boyut[j, i] >= boyut[j - 1, i - 1];
                    }
                    else if ((aci >= 67.5 && aci < 112.5) || (aci >= 247.5 && aci < 292.5))
                    {
                        kenarMi = boyut[j, i] >= boyut[j, i + 1] && boyut[j, i] >= boyut[j, i - 1];
                    }
                    else if ((aci >= 112.5 && aci < 157.5) || (aci >= 292.5 && aci < 337.5))
                    {
                        kenarMi = boyut[j, i] >= boyut[j + 1, i - 1] && boyut[j, i] >= boyut[j - 1, i + 1];
                    }

                    kenarResmi.SetPixel(j, i, kenarMi ? Color.White : Color.Black);
                }
            }

            for (int i = 1; i < kenarResmi.Height - 1; i++)
            {
                for (int j = 1; j < kenarResmi.Width - 1; j++)
                {
                    int pxDegeri = kenarResmi.GetPixel(j, i).R;

                    if (pxDegeri == 255)
                    {
                        double buyuklukDegeri = boyut[j, i];

                        if (buyuklukDegeri >= ustEsik)
                        {
                            kenarResmi.SetPixel(j, i, Color.White);
                        }
                        else if (buyuklukDegeri < altEsik)
                        {
                            kenarResmi.SetPixel(j, i, Color.Black);
                        }
                        else
                        {
                            bool baglandiMi = false;

                            for (int k = -1; k <= 1; k++)
                            {
                                for (int l = -1; l <= 1; l++)
                                {
                                    if (kenarResmi.GetPixel(j + l, i + k).R == 255 && boyut[j + l, i + k] >= ustEsik)
                                    {
                                        baglandiMi = true;
                                        break;
                                    }
                                }

                                if (baglandiMi)
                                {
                                    break;
                                }
                            }

                            kenarResmi.SetPixel(j, i, baglandiMi ? Color.White : Color.Black);
                        }
                    }
                }
            }

            return kenarResmi;
        }

        private Bitmap saltPepperGurultusu(Bitmap bmp, double gurultuSeviyesi)
        {

            if (gurultuSeviyesi < 0 || gurultuSeviyesi > 0.1)
            {
                MessageBox.Show("Gürültü seviyesi 0.1'den büyük, 0'dan küçük olamaz.");
                return bmp;
            }

            Random rand = new Random();
            Bitmap gurultuluGoruntu = new Bitmap(bmp);

            int gurultuPxSayisi = (int)(gurultuSeviyesi * bmp.Width * bmp.Height);

            for (int i = 0; i < gurultuPxSayisi; i++)
            {
                int x = rand.Next(bmp.Width);
                int y = rand.Next(bmp.Height);

                bool tuzluMu = rand.NextDouble() < 0.5;
                gurultuluGoruntu.SetPixel(x, y, tuzluMu ? Color.White : Color.Black);
            }

            return gurultuluGoruntu;
        }

        private Bitmap meanFiltre(Bitmap bmp, int size)
        {
            Bitmap filtrele = new Bitmap(bmp.Width, bmp.Height);
            int kaydirma = size / 2;

            for (int y = kaydirma; y < bmp.Height - kaydirma; y++)
            {
                for (int x = kaydirma; x < bmp.Width - kaydirma; x++)
                {
                    int sumR = 0, sumG = 0, sumB = 0;

                    for (int fy = -kaydirma; fy <= kaydirma; fy++)
                    {
                        for (int fx = -kaydirma; fx <= kaydirma; fx++)
                        {
                            Color pixel = bmp.GetPixel(x + fx, y + fy);
                            sumR += pixel.R;
                            sumG += pixel.G;
                            sumB += pixel.B;
                        }
                    }

                    int count = size * size;
                    int r = sumR / count;
                    int g = sumG / count;
                    int b = sumB / count;

                    filtrele.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return filtrele;
        }

        private Bitmap medyanFiltre(Bitmap bmp, int size)
        {
            Bitmap filtrelenmisGoruntu = new Bitmap(bmp.Width, bmp.Height);
            int kaydirma = size / 2;

            for (int y = kaydirma; y < bmp.Height - kaydirma; y++)
            {
                for (int x = kaydirma; x < bmp.Width - kaydirma; x++)
                {
                    List<int> komsuR = new List<int>();
                    List<int> komsuG = new List<int>();
                    List<int> komsuB = new List<int>();

                    for (int fy = -kaydirma; fy <= kaydirma; fy++)
                    {
                        for (int fx = -kaydirma; fx <= kaydirma; fx++)
                        {
                            Color pixel = bmp.GetPixel(x + fx, y + fy);
                            komsuR.Add(pixel.R);
                            komsuG.Add(pixel.G);
                            komsuB.Add(pixel.B);
                        }
                    }

                    komsuR.Sort();
                    komsuG.Sort();
                    komsuB.Sort();

                    int medyanR = komsuR[komsuR.Count / 2];
                    int medyanG = komsuG[komsuG.Count / 2];
                    int medyanB = komsuB[komsuB.Count / 2];

                    filtrelenmisGoruntu.SetPixel(x, y, Color.FromArgb(medyanR, medyanG, medyanB));
                }
            }
            return filtrelenmisGoruntu;
        }

        private Bitmap motionBlur(Bitmap bmp, int uzunluk, double aci)
        {
            if (uzunluk < 1 || uzunluk > Math.Min(bmp.Width, bmp.Height))
            {
                MessageBox.Show("Kernel uzunluðu geçersiz. Görüntü boyutlarýndan daha küçük olmalýdýr.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return bmp;
            }

            if (aci < 0 || aci >= 360)
            {
                MessageBox.Show("Açý geçersiz. 0 ile 360 arasýnda olmalýdýr.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return bmp;
            }

            double radyan = aci * Math.PI / 180.0;
            double cosAcisi = Math.Cos(radyan);
            double sinAcisi = Math.Sin(radyan);
            double[,] kernel = new double[uzunluk, 1];
            double toplam = 0;

            for (int i = 0; i < uzunluk; i++)
            {
                kernel[i, 0] = 1;
                toplam += 1;
            }

            for (int i = 0; i < uzunluk; i++)
            {
                kernel[i, 0] /= toplam;
            }

            Bitmap filtrelenmisGoruntu = new Bitmap(bmp.Width, bmp.Height);
            int kaydirma = uzunluk / 2;

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    double sumR = 0, sumG = 0, sumB = 0;

                    for (int i = 0; i < uzunluk; i++)
                    {
                        int fx = (int)(i * cosAcisi - kaydirma);
                        int fy = (int)(i * sinAcisi - kaydirma);

                        int imgX = x + fx;
                        int imgY = y + fy;

                        if (imgX >= 0 && imgX < bmp.Width && imgY >= 0 && imgY < bmp.Height)
                        {
                            Color pixel = bmp.GetPixel(imgX, imgY);
                            double kernelValue = kernel[i, 0];

                            sumR += pixel.R * kernelValue;
                            sumG += pixel.G * kernelValue;
                            sumB += pixel.B * kernelValue;
                        }
                    }

                    int r = Clamp((int)sumR);
                    int g = Clamp((int)sumG);
                    int b = Clamp((int)sumB);

                    filtrelenmisGoruntu.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return filtrelenmisGoruntu;
        }

        private int[,] kernel3x3 = new int[,]
        {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 }
        };
        private Bitmap genisleme(Bitmap bmp, int[,] kernel)
        {
            Bitmap sonuc = new Bitmap(bmp.Width, bmp.Height);
            int kaydirma = kernel.GetLength(0) / 2;

            for (int y = kaydirma; y < bmp.Height - kaydirma; y++)
            {
                for (int x = kaydirma; x < bmp.Width - kaydirma; x++)
                {
                    bool pixelSet = false;

                    for (int fy = -kaydirma; fy <= kaydirma; fy++)
                    {
                        for (int fx = -kaydirma; fx <= kaydirma; fx++)
                        {
                            if (kernel[fy + kaydirma, fx + kaydirma] == 1 && bmp.GetPixel(x + fx, y + fy).R == 255)
                            {
                                pixelSet = true;
                                break;
                            }
                        }
                        if (pixelSet) break;
                    }

                    sonuc.SetPixel(x, y, pixelSet ? Color.White : Color.Black);
                }
            }

            return sonuc;
        }

        private Bitmap asinma(Bitmap bmp, int[,] kernel)
        {
            Bitmap sonuc = new Bitmap(bmp.Width, bmp.Height);
            int kaydirma = kernel.GetLength(0) / 2;

            for (int y = kaydirma; y < bmp.Height - kaydirma; y++)
            {
                for (int x = kaydirma; x < bmp.Width - kaydirma; x++)
                {
                    bool pixelSet = true;

                    for (int fy = -kaydirma; fy <= kaydirma; fy++)
                    {
                        for (int fx = -kaydirma; fx <= kaydirma; fx++)
                        {
                            if (kernel[fy + kaydirma, fx + kaydirma] == 1 && bmp.GetPixel(x + fx, y + fy).R != 255)
                            {
                                pixelSet = false;
                                break;
                            }
                        }
                        if (!pixelSet) break;
                    }

                    sonuc.SetPixel(x, y, pixelSet ? Color.White : Color.Black);
                }
            }

            return sonuc;
        }

        private Bitmap acma(Bitmap bmp, int[,] kernel)
        {
            return genisleme(asinma(bmp, kernel), kernel);
        }

        private Bitmap kapama(Bitmap bmp, int[,] kernel)
        {
            return asinma(genisleme(bmp, kernel), kernel);
        }

    }
}
