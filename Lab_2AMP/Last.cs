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
    public partial class Last : MaterialForm
    {
        public Last()
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

        private void Last_Load(object sender, EventArgs e)
        {

        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            Books books;
            books = new Books();
            books.Location = this.Location;
            this.Hide();
            books.Show();
        }
    }
}
