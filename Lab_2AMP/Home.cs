using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Lab_2AMP
{
    public partial class Home : MaterialForm
    {
        //private Font OldFont;
        //Font myFont;
        //PrivateFontCollection private_fonts = new PrivateFontCollection();
        public Home()
        {
            
            InitializeComponent();
         
            //materialLabel1.Font = new Font(private_fonts.Families[0], 22);
            //materialLabel1.UseCompatibleTextRendering = true;
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //this.TopMost = true;
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
              Primary.Brown800, Primary.Brown900,
                Primary.Brown400, Accent.LightBlue200,
                TextShade.WHITE
                );
            //System.Drawing.Text.PrivateFontCollection f = new System.Drawing.Text.PrivateFontCollection();
            //f.AddFontFile("2211.ttf");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Books books;
            books = new Books();
            books.Location = this.Location;
            this.Hide();
            books.Show();
         
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            About about;
            about = new About();
            about.Location = this.Location;
            this.Hide();
            about.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Keepintouch keepintouch;
            keepintouch = new Keepintouch();
            keepintouch.Location = this.Location;
            this.Hide();
            keepintouch.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Delivery delivery;
            delivery = new Delivery();
            delivery.Location = this.Location;
            this.Hide();
            delivery.Show();
        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }
      
        private void Home_Load(object sender, EventArgs e)
        {
         

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Books books;
            books = new Books();
            books.Location = this.Location;
            this.Hide();
            books.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Keepintouch keepintouch;
            keepintouch = new Keepintouch();
            keepintouch.Location = this.Location;
            this.Hide();
            keepintouch.Show();
        }
    }
}
