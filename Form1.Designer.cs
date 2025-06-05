namespace Quick_View
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.collapse = new System.Windows.Forms.Button();
      this.close = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.rotate = new System.Windows.Forms.Button();
      this.windowed = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // collapse
      // 
      this.collapse.BackColor = System.Drawing.Color.Transparent;
      this.collapse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.collapse.FlatAppearance.BorderSize = 0;
      this.collapse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
      this.collapse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
      this.collapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.collapse.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.collapse.ForeColor = System.Drawing.Color.Silver;
      this.collapse.Location = new System.Drawing.Point(295, 12);
      this.collapse.Name = "collapse";
      this.collapse.Size = new System.Drawing.Size(102, 48);
      this.collapse.TabIndex = 12;
      this.collapse.TabStop = false;
      this.collapse.Text = "⭸";
      this.collapse.UseVisualStyleBackColor = false;
      this.collapse.Click += new System.EventHandler(this.collapseClick);
      // 
      // close
      // 
      this.close.BackColor = System.Drawing.Color.Transparent;
      this.close.CausesValidation = false;
      this.close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
      this.close.FlatAppearance.BorderSize = 0;
      this.close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
      this.close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.close.ForeColor = System.Drawing.Color.Silver;
      this.close.Location = new System.Drawing.Point(414, 12);
      this.close.Name = "close";
      this.close.Size = new System.Drawing.Size(102, 48);
      this.close.TabIndex = 11;
      this.close.TabStop = false;
      this.close.Text = "✕";
      this.close.UseVisualStyleBackColor = false;
      this.close.Click += new System.EventHandler(this.closeClick);
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
      this.pictureBox1.Location = new System.Drawing.Point(0, 0);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(516, 222);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 10;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
      this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
      this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
      this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
      // 
      // rotate
      // 
      this.rotate.BackColor = System.Drawing.Color.Transparent;
      this.rotate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.rotate.FlatAppearance.BorderSize = 0;
      this.rotate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
      this.rotate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
      this.rotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.rotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.rotate.ForeColor = System.Drawing.Color.Silver;
      this.rotate.Location = new System.Drawing.Point(61, 12);
      this.rotate.Name = "rotate";
      this.rotate.Size = new System.Drawing.Size(102, 48);
      this.rotate.TabIndex = 14;
      this.rotate.TabStop = false;
      this.rotate.Text = "⭯";
      this.rotate.UseVisualStyleBackColor = false;
      this.rotate.Click += new System.EventHandler(this.rotateClick);
      // 
      // windowed
      // 
      this.windowed.BackColor = System.Drawing.Color.Transparent;
      this.windowed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.windowed.FlatAppearance.BorderSize = 0;
      this.windowed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
      this.windowed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
      this.windowed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.windowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.windowed.ForeColor = System.Drawing.Color.Silver;
      this.windowed.Location = new System.Drawing.Point(187, 12);
      this.windowed.Name = "windowed";
      this.windowed.Size = new System.Drawing.Size(102, 48);
      this.windowed.TabIndex = 15;
      this.windowed.TabStop = false;
      this.windowed.Text = "◳";
      this.windowed.UseVisualStyleBackColor = false;
      this.windowed.Click += new System.EventHandler(this.windowedClick);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
      this.ClientSize = new System.Drawing.Size(528, 326);
      this.Controls.Add(this.windowed);
      this.Controls.Add(this.rotate);
      this.Controls.Add(this.collapse);
      this.Controls.Add(this.close);
      this.Controls.Add(this.pictureBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.Name = "Form1";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Form1";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Load += new System.EventHandler(this.Form1_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
      this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button collapse;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button rotate;
        private System.Windows.Forms.Button windowed;
    }
}

