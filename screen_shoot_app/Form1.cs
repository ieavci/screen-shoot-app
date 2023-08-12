using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace screen_shoot_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\iavcc\\Desktop";  /*kendi kullanıcı adın*/
                openFileDialog.Filter = "Tüm Dosyalar (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;


                }
            }
        }
        #region ss alma
        private Bitmap Screenshot()
        {

            this.Opacity = 0;


            Bitmap Screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics GFX = Graphics.FromImage(Screenshot);
            GFX.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);


            this.Opacity = 1;

            return Screenshot;
        }
        string KayitYolu = @"C:\Users\iavcc\Desktop";
        string ResimAdi()
        {
            return "SS_" + DateTime.Now.ToString().Replace(" ", "_").Replace(":", "_") + ".jpg";
        }
        void Kaydet(string resimadi)
        {

            if (!File.Exists(KayitYolu))
                Directory.CreateDirectory(KayitYolu);


            Screenshot().Save(KayitYolu + "\\" + resimadi + "", ImageFormat.Jpeg);
        }

        private void yeni_Click(object sender, EventArgs e)
        {
            Kaydet(ResimAdi());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F12)
                Kaydet(ResimAdi());
            if (e.KeyData == Keys.Escape)
                Application.Exit();
        }

        private void yeni_MouseClick(object sender, MouseEventArgs e)
        {
            this.Visible = false;
            message msg = new message();
            msg.ShowDialog();
        }

        #endregion

        #region movebutonu
        private bool isDragging = false;
        private Point lastPoint;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = e.X - lastPoint.X;
                int deltaY = e.Y - lastPoint.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastPoint = e.Location;
            }
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
        #endregion
    }
}
