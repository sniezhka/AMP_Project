using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Lab_2AMP
{
    public partial class Delivery : MaterialForm
    {
        public Delivery()
        {
            InitializeComponent();
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
        }

        private void Delivery_Load(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Home"].Location = this.Location;
            Application.OpenForms["Home"].Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Home"].Location = this.Location;
            Application.OpenForms["Home"].Show();
            this.Close();
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
