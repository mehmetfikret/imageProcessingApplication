using System.Windows.Forms;

namespace goruntuisleme
{
    partial class Form1
    {

        private PictureBox pictureBox1;








        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            trackBar1 = new TrackBar();
            label2 = new Label();
            textBoxX = new TextBox();
            textBoxY = new TextBox();
            textBoxWidth = new TextBox();
            textBoxHeight = new TextBox();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            txtUst = new TextBox();
            txtAlt = new TextBox();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            textBoxUzunluk = new TextBox();
            label10 = new Label();
            pictureBox3 = new PictureBox();
            buttonLoad2 = new Button();
            buttonLoad = new Button();
            buttonSave = new Button();
            buttonProcess = new Button();
            textBoxNoise = new TextBox();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(236, 240, 241);
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(12, 75);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(568, 330);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(15, 441);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(238, 28);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightGray;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(15, 418);
            label1.Name = "label1";
            label1.Size = new Size(121, 20);
            label1.TabIndex = 7;
            label1.Text = "Yapılacak İşlem";
            // 
            // trackBar1
            // 
            trackBar1.BackColor = Color.Green;
            trackBar1.LargeChange = 100;
            trackBar1.Location = new Point(617, 439);
            trackBar1.Maximum = 360;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(345, 56);
            trackBar1.TabIndex = 8;
            trackBar1.TickFrequency = 5;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Green;
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(972, 460);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 9;
            // 
            // textBoxX
            // 
            textBoxX.Location = new Point(613, 653);
            textBoxX.Name = "textBoxX";
            textBoxX.Size = new Size(125, 26);
            textBoxX.TabIndex = 14;
            // 
            // textBoxY
            // 
            textBoxY.Location = new Point(755, 653);
            textBoxY.Name = "textBoxY";
            textBoxY.Size = new Size(125, 26);
            textBoxY.TabIndex = 15;
            // 
            // textBoxWidth
            // 
            textBoxWidth.Location = new Point(898, 653);
            textBoxWidth.Name = "textBoxWidth";
            textBoxWidth.Size = new Size(125, 26);
            textBoxWidth.TabIndex = 16;
            // 
            // textBoxHeight
            // 
            textBoxHeight.Location = new Point(1038, 653);
            textBoxHeight.Name = "textBoxHeight";
            textBoxHeight.Size = new Size(125, 26);
            textBoxHeight.TabIndex = 17;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.LightGray;
            pictureBox2.Location = new Point(617, 75);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(534, 330);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 18;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Red;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(617, 41);
            label4.Name = "label4";
            label4.Size = new Size(209, 31);
            label4.TabIndex = 19;
            label4.Text = "Değiştirilmiş Resim";
            // 
            // txtUst
            // 
            txtUst.Location = new Point(755, 567);
            txtUst.Name = "txtUst";
            txtUst.Size = new Size(125, 26);
            txtUst.TabIndex = 21;
            // 
            // txtAlt
            // 
            txtAlt.Location = new Point(613, 567);
            txtAlt.Name = "txtAlt";
            txtAlt.Size = new Size(125, 26);
            txtAlt.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightGray;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(613, 530);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 23;
            label3.Text = "Alt Değer";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.LightGray;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(755, 530);
            label5.Name = "label5";
            label5.Size = new Size(81, 20);
            label5.TabIndex = 24;
            label5.Text = "Üst Değer";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.LightGray;
            label6.ForeColor = Color.Black;
            label6.Location = new Point(613, 618);
            label6.Name = "label6";
            label6.Size = new Size(95, 20);
            label6.TabIndex = 25;
            label6.Text = "X koordinatı";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.LightGray;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(755, 618);
            label7.Name = "label7";
            label7.Size = new Size(93, 20);
            label7.TabIndex = 26;
            label7.Text = "Y koordinatı";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.LightGray;
            label8.ForeColor = Color.Black;
            label8.Location = new Point(898, 618);
            label8.Name = "label8";
            label8.Size = new Size(26, 20);
            label8.TabIndex = 27;
            label8.Text = "En";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.LightGray;
            label9.ForeColor = Color.Black;
            label9.Location = new Point(1042, 618);
            label9.Name = "label9";
            label9.Size = new Size(36, 20);
            label9.TabIndex = 28;
            label9.Text = "Boy";
            // 
            // textBoxUzunluk
            // 
            textBoxUzunluk.Location = new Point(898, 567);
            textBoxUzunluk.Name = "textBoxUzunluk";
            textBoxUzunluk.Size = new Size(125, 26);
            textBoxUzunluk.TabIndex = 29;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.LightGray;
            label10.ForeColor = Color.Black;
            label10.Location = new Point(898, 530);
            label10.Name = "label10";
            label10.Size = new Size(64, 20);
            label10.TabIndex = 30;
            label10.Text = "Uzunluk";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(236, 240, 241);
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Location = new Point(15, 490);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(568, 330);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 31;
            pictureBox3.TabStop = false;
            // 
            // buttonLoad2
            // 
            buttonLoad2.BackColor = Color.FromArgb(52, 152, 219);
            buttonLoad2.FlatAppearance.BorderSize = 0;
            buttonLoad2.FlatStyle = FlatStyle.Flat;
            buttonLoad2.ForeColor = Color.White;
            buttonLoad2.Location = new Point(15, 833);
            buttonLoad2.Name = "buttonLoad2";
            buttonLoad2.Size = new Size(80, 30);
            buttonLoad2.TabIndex = 32;
            buttonLoad2.Text = "Yükle";
            buttonLoad2.UseVisualStyleBackColor = false;
            buttonLoad2.Click += buttonLoad2_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.BackColor = Color.FromArgb(52, 152, 219);
            buttonLoad.FlatAppearance.BorderSize = 0;
            buttonLoad.FlatStyle = FlatStyle.Flat;
            buttonLoad.ForeColor = Color.White;
            buttonLoad.Location = new Point(15, 21);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(80, 30);
            buttonLoad.TabIndex = 33;
            buttonLoad.Text = "Yükle";
            buttonLoad.UseVisualStyleBackColor = false;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.IndianRed;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(111, 21);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(80, 30);
            buttonSave.TabIndex = 34;
            buttonSave.Text = "Kaydet";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonProcess
            // 
            buttonProcess.BackColor = Color.LimeGreen;
            buttonProcess.FlatAppearance.BorderSize = 0;
            buttonProcess.FlatStyle = FlatStyle.Flat;
            buttonProcess.ForeColor = Color.White;
            buttonProcess.Location = new Point(291, 439);
            buttonProcess.Name = "buttonProcess";
            buttonProcess.Size = new Size(80, 30);
            buttonProcess.TabIndex = 35;
            buttonProcess.Text = "İşle";
            buttonProcess.UseVisualStyleBackColor = false;
            buttonProcess.Click += buttonProcess_Click;
            // 
            // textBoxNoise
            // 
            textBoxNoise.Location = new Point(1038, 567);
            textBoxNoise.Name = "textBoxNoise";
            textBoxNoise.Size = new Size(125, 26);
            textBoxNoise.TabIndex = 36;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.LightGray;
            label11.ForeColor = Color.Black;
            label11.Location = new Point(1038, 530);
            label11.Name = "label11";
            label11.Size = new Size(123, 20);
            label11.TabIndex = 37;
            label11.Text = "Gürültü Seviyesi";
            // 
            // Form1
            // 
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1175, 875);
            Controls.Add(label11);
            Controls.Add(textBoxNoise);
            Controls.Add(buttonProcess);
            Controls.Add(buttonSave);
            Controls.Add(buttonLoad);
            Controls.Add(buttonLoad2);
            Controls.Add(pictureBox3);
            Controls.Add(label10);
            Controls.Add(textBoxUzunluk);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(txtAlt);
            Controls.Add(txtUst);
            Controls.Add(label4);
            Controls.Add(pictureBox2);
            Controls.Add(textBoxHeight);
            Controls.Add(textBoxWidth);
            Controls.Add(textBoxY);
            Controls.Add(textBoxX);
            Controls.Add(label2);
            Controls.Add(trackBar1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox1);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Görüntü İşleme Uygulaması";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBox1;
        private Label label1;
        private TrackBar trackBar1;
        private Label label2;
        private TextBox textBoxX;
        private TextBox textBoxY;
        private TextBox textBoxWidth;
        private TextBox textBoxHeight;
        private PictureBox pictureBox2;
        private Label label4;
        private TextBox txtUst;
        private TextBox txtAlt;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox textBoxUzunluk;
        private Label label10;
        private PictureBox pictureBox3;
        private Button buttonLoad2;
        private Button buttonLoad;
        private Button buttonSave;
        private Button buttonProcess;
        private TextBox textBoxNoise;
        private Label label11;
    }
}