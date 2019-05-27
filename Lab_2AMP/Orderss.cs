using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Lab_2AMP
{
    public partial class Orderss : MaterialForm
    {
        string find;
        public Orderss(string str)
        {
            find = str;
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

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Home"].Location = this.Location;
            Application.OpenForms["Home"].Show();
            this.Close();
        }

       
        public void except()//18
        {
            using (BookContext db = new BookContext())
            {
                var selector1 = db.Books.Where(p => p.Price < 200);//10
                var selector2 = db.Books.Where(p => p.Title.Contains("2"));//14
                var books = selector1.Except(selector2);//13
            }
        }
        public void intersect()//18
        {
            using (BookContext db = new BookContext())
            {
                var books = db.Books.Where(b => b.Price < 200)
                    .Intersect(db.Books.Where(p => p.Title.Contains("2")));
            }
        }
        public void union()//18
        {
            using (BookContext db = new BookContext())
            {
                var books = db.Books.Where(b => b.Price < 200)
                    .Union(db.Books.Where(b => b.Title.Contains("2")));
            }
        }
        public void jointable()//17
        {
            using (BookContext db = new BookContext())
            {
                var orders = db.Books.Join(db.Orders, // второй набор      12
                b => b.Title, // свойство-селектор объекта из первого набора
                o => o.BookName, // свойство-селектор объекта из второго набора
                (b, o) => new // результат
                {
                    Name = b.Title,
                    Sum = o.TotalSum,
                    Author = b.Author
                });
            }
        }
        delegate void MessageHandler();

      
        private void Order_Load(object sender, EventArgs e)
        {
            materialSingleLineTextField7.Visible = false;
            BookContext db = new BookContext();
            var books = db.Books;
            int counter = 1;
            foreach (Book book in books)
            {
                if (book.Title == find)
                {
                    pictureBox1.Load(book.Photo);
                    materialSingleLineTextField6.Text = Convert.ToString(book.Title);
                    materialSingleLineTextField8.Text = Convert.ToString(book.Author);
                    materialSingleLineTextField5.Text =  Convert.ToString(book.Price) + " UAH";
                    book.Status = "Reserved";
                }
                counter++;

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("You want to complete the purchase?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK) { 
            Application.OpenForms["Home"].Location = this.Location;
            Application.OpenForms["Home"].Show();
            this.Close();
            } 
            this.TopMost = true;

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        { DialogResult result = MessageBox.Show("You want to complete the purchase?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                Books books;
                books = new Books();
                books.Location = this.Location;
                this.Hide();
                books.Show();
            }
            this.TopMost = true;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        { DialogResult result = MessageBox.Show("You want to complete the purchase?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                Keepintouch keepintouch;
                keepintouch = new Keepintouch();
                keepintouch.Location = this.Location;
                this.Hide();
                keepintouch.Show();
            }
            this.TopMost = true;

        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            materialSingleLineTextField7.Visible = false;
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            materialSingleLineTextField7.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text == string.Empty && materialSingleLineTextField2.Text == string.Empty && materialSingleLineTextField3.Text == string.Empty && materialSingleLineTextField4.Text == string.Empty)
            {
                MessageBox.Show("Please fill in the data fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                if (materialRadioButton2.Checked && materialSingleLineTextField7.Text != string.Empty)
                {
                    Reader reader = new Reader(Convert.ToString(materialSingleLineTextField1), Convert.ToString(materialSingleLineTextField2), Convert.ToInt32(materialSingleLineTextField7.Text));
                    reader.Put(500);

                    BookContext db = new BookContext();
                    var books = db.Books;
                    foreach (Book book in books)
                    {
                        if (book.Title == find)
                        {
                            reader.Withdraw(book.Price);
                            book.Status = "Buyed";
                        }

                    }


                }
                materialSingleLineTextField1.Text = "";
                materialSingleLineTextField2.Text = "";
                materialSingleLineTextField3.Text = "";
                materialSingleLineTextField4.Text = "";
                materialSingleLineTextField7.Text = "";
                materialSingleLineTextField5.Text = "";
                materialSingleLineTextField6.Text = "";
                materialSingleLineTextField7.Visible = false;
                materialRadioButton1.Checked = false;
                materialRadioButton2.Checked = false;
                Last last;
                last = new Last();
                last.Location = this.Location;
                this.Hide();
                last.Show();
                MessageHandler handler = delegate ()
                {
                    using (BookContext db = new BookContext())
                    {
                        var book = db.Books.FirstOrDefault(b => b.Status == "Reserved");
                        Reader reader = new Reader();
                        //reader.Withdraw(book.Price);//Console.WriteLine(mes);
                        //var books = db.Books;
                        //foreach (Book book_ in books)
                        //{
                        //    if (book_.Title == find)
                        //    {
                        //        book_.Status = "Buyed";
                        //    }


                        //}
                        //book.Status = "Buyed";
                        //db.Books.Remove(book);
                        db.SaveChanges();

                    }
                };

                handler();
                using (BookContext db = new BookContext())
                {
                    var orders = db.Orders.Include(p => p.Reader).ToList();//eager loading
                    var orders_by_price = orders.GroupBy(p => p.TotalSum);//group by price  11
                    var books = db.Books.ToList();
                    var result = from o in orders//12,13
                                 join b in books on o.BookName equals b.Title
                                 select new { Name = o.BookName, Number = o.Id };
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Books books;
            books = new Books();
            books.Location = this.Location;
            this.Hide();
            books.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
