using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Quick_View
{
  public partial class Form1 : Form
  {
    int imageInFolderIndex;
    string[] images;
    bool dragAndDrop = false;
    int mouseX, mouseY;
    int zoomStep = 100;
    bool showInterface = true;

    public Form1(string[] args)
    {
      InitializeComponent();

      this.KeyPreview = true;
      this.MouseWheel += new MouseEventHandler(this.onMouseWheel);
      windowedClick(null, null);

      //args = new string[1];
      //args[0] = "E:/Anton/Pictures/Фото/Meizu 16/P21105-131942.jpg";
      drawImage(args[0]);

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
          imageInFolderIndex = i;
      }



      collapse.FlatAppearance.MouseOverBackColor =
       rotate.FlatAppearance.MouseOverBackColor =
       windowed.FlatAppearance.MouseOverBackColor =
       GetThemeColor();
    }
    void drawImage(string path)
    {
      Image img = Image.FromFile(path);
      pictureBox1.Size = new Size(img.Width, img.Height);
      pictureBox1.Image = img;

      this.Text = System.IO.Path.GetFileName(path);
      int h = Screen.FromHandle(this.Handle).Bounds.Height;
      if (pictureBox1.Width > Screen.FromHandle(this.Handle).Bounds.Width || pictureBox1.Height > Screen.FromHandle(this.Handle).Bounds.Height)
      {
        pictureBox1.Height = Screen.FromHandle(this.Handle).Bounds.Height;
      }
      pictureBox1.Location = new Point(Convert.ToInt16((Convert.ToDouble(this.Width) / 2.0) - (Convert.ToDouble(pictureBox1.Width) / 2.0)), Convert.ToInt16((Convert.ToDouble(this.Height) / 2.0) - (Convert.ToDouble(pictureBox1.Height) / 2.0)));
    }
    void checkForCursor()
    {
      if ((Cursor.Position.Y - this.Location.Y < 100) != showInterface)
      {
        showInterface = Cursor.Position.Y - this.Location.Y < 100;
        close.Visible = collapse.Visible = rotate.Visible = windowed.Visible = showInterface;
      }

        if ((Cursor.Position.Y > Screen.FromHandle(this.Handle).Bounds.Height - 100))
        {
          if (this.WindowState == FormWindowState.Maximized)
          {
          this.Height = Screen.FromHandle(this.Handle).WorkingArea.Height;
          this.WindowState = FormWindowState.Normal;
          }
        }
        else
        {
          if (this.WindowState == FormWindowState.Normal)
          {
          
          this.WindowState = FormWindowState.Maximized;
          
          }
        }
    }

    private void onMouseWheel(object sender, MouseEventArgs e)
    {
      if (e.Delta > 0)
      {
        pictureBox1.Width = pictureBox1.Width + this.zoomStep;
        pictureBox1.Height = pictureBox1.Height + this.zoomStep;
        pictureBox1.Location = new Point(pictureBox1.Location.X - this.zoomStep / 2, pictureBox1.Location.Y - this.zoomStep / 2);
      }
      else
      {
        if ((pictureBox1.Width > this.zoomStep && pictureBox1.Height > this.zoomStep))
        {
          pictureBox1.Width = pictureBox1.Width - this.zoomStep;
          pictureBox1.Height = pictureBox1.Height - this.zoomStep;
          pictureBox1.Location = new Point(pictureBox1.Location.X + this.zoomStep / 2, pictureBox1.Location.Y + this.zoomStep / 2);
        }
      }
    }
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        dragAndDrop = true;
        mouseX = e.X;
        mouseY = e.Y;
        this.Cursor = Cursors.Hand;
      }
    }

    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
      if (dragAndDrop)
      {
        dragAndDrop = false;
        this.Cursor = Cursors.Default;
      }
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Right && imageInFolderIndex < images.Length - 1)
      {
        imageInFolderIndex++;
        drawImage(images[imageInFolderIndex]);
      }
      if (e.KeyCode == Keys.Left && imageInFolderIndex > 0)
      {
        imageInFolderIndex--;
        drawImage(images[imageInFolderIndex]);
      }

      GC.Collect();
    }

    private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
      e.IsInputKey = true;
    }

    private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      drawImage(images[imageInFolderIndex]);
    }

    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
      checkForCursor();
    }

    private void windowedClick(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Maximized)
      {
        windowed.Text = "⭘";
        this.WindowState = FormWindowState.Normal;
        this.Size = pictureBox1.Size;
        pictureBox1.Location = new Point(0, 0);
        close.Location = new Point(this.Size.Width - collapse.Width, 0);
        collapse.Location = new Point(this.Size.Width - close.Width - collapse.Width, 0);
        windowed.Location = new Point(this.Size.Width - close.Width - collapse.Width - windowed.Width, 0);
        rotate.Location = new Point(this.Size.Width - close.Width - collapse.Width - windowed.Width - rotate.Width, 0);

        checkForCursor();
        return;
      }

      if (this.WindowState == FormWindowState.Normal)
      {
        windowed.Text = "⯏";
        this.WindowState = FormWindowState.Maximized;
        this.Location = new Point(Screen.FromHandle(this.Handle).WorkingArea.X, Screen.FromHandle(this.Handle).WorkingArea.Y);
        this.Size = new Size(Screen.FromHandle(this.Handle).Bounds.Width, Screen.FromHandle(this.Handle).Bounds.Height);
        close.Location = new Point(this.Size.Width - collapse.Width, 0);
        collapse.Location = new Point(this.Size.Width - close.Width - collapse.Width, 0);
        windowed.Location = new Point(this.Size.Width - close.Width - collapse.Width - windowed.Width, 0);
        rotate.Location = new Point(this.Size.Width - close.Width - collapse.Width - windowed.Width - rotate.Width, 0);
        pictureBox1.Location = new Point(Convert.ToInt16((Convert.ToDouble(this.Width) / 2.0) - (Convert.ToDouble(pictureBox1.Width) / 2.0)), Convert.ToInt16((Convert.ToDouble(this.Height) / 2.0) - (Convert.ToDouble(pictureBox1.Height) / 2.0)));

        checkForCursor();
        return;
      }
    }

    private void rotateClick(object sender, EventArgs e)
    {
      Image flipImage = pictureBox1.Image;
      flipImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
      pictureBox1.Image = flipImage;
    }

    private void closeClick(object sender, EventArgs e)
    {
      Environment.Exit(0);
    }

    private void collapseClick(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
      this.ShowInTaskbar = true;
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
      if (dragAndDrop)
      {
        int dx = e.X - mouseX;
        int dy = e.Y - mouseY;
        if (this.WindowState == FormWindowState.Normal)
          this.Location = new Point(this.Location.X + dx, this.Location.Y + dy);
        else
          pictureBox1.Location = new Point(pictureBox1.Location.X + dx, pictureBox1.Location.Y + dy);
      }

      checkForCursor();
    }

    [DllImport("uxtheme.dll", EntryPoint = "#95")]
    public static extern uint GetImmersiveColorFromColorSetEx(uint dwImmersiveColorSet, uint dwImmersiveColorType, bool bIgnoreHighContrast, uint dwHighContrastCacheMode);
    [DllImport("uxtheme.dll", EntryPoint = "#96")]
    public static extern uint GetImmersiveColorTypeFromName(IntPtr pName);
    [DllImport("uxtheme.dll", EntryPoint = "#98")]
    public static extern int GetImmersiveUserColorSetPreference(bool bForceCheckRegistry, bool bSkipCheckOnFail);

    public Color GetThemeColor()
    {
      var colorSetEx = GetImmersiveColorFromColorSetEx(
        (uint)GetImmersiveUserColorSetPreference(false, false),
        GetImmersiveColorTypeFromName(Marshal.StringToHGlobalUni("ImmersiveStartSelectionBackground")),
        false, 0);

      var colour = Color.FromArgb((byte)((0xFF000000 & colorSetEx) >> 24), (byte)(0x000000FF & colorSetEx),
          (byte)((0x0000FF00 & colorSetEx) >> 8), (byte)((0x00FF0000 & colorSetEx) >> 16));

      return colour;
    }
  }
}

