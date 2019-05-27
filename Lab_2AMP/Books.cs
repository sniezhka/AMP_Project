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
    public partial class Books : MaterialForm
    {
        public Books()
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


        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField4_Click(object sender, EventArgs e)
        {

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


        private void Books_Load(object sender, EventArgs e)
        {

            //using (BookContext db = new BookContext())
            //{
            //    Genre fantasy = new Genre() { Name = "Fantasy" };
            //    Genre drama = new Genre() { Name = "Drama" };
            //    Genre tragedy = new Genre() { Name = "Tragedy" };
            //    Genre scientific = new Genre() { Name = "Scientific" };
            //    Book b1 = new Book("Harry Potter", "J.K.Rowling", 180, "1.jpeg");// fantasy
            //    Book b2 = new Book("Fences", "August Wilson", 200, "2.jpg");//drama
            //    Book b3 = new Book("Hamlet", "William Shakespeare", 250, "3.jpg");//tragedy
            //    Book b4 = new Book("Instant Systems", "GBradley J. Sugars", 350, "4.jpg");//scientific
            //    int lenght = b1.WordCount();//extension method 14
            //    db.Books.AddRange(new List<Book> { b1, b2, b3, b4 });
            //    fantasy.Books.Add(b1);
            //    drama.Books.Add(b2);
            //    tragedy.Books.Add(b3);
            //    scientific.Books.Add(b4);
            //    b1.Genres.Add(fantasy);
            //    b2.Genres.Add(drama);
            //    b3.Genres.Add(tragedy);
            //    b4.Genres.Add(scientific);
            //    db.Genres.Add(fantasy);
            //    db.Genres.Add(drama);
            //    db.Genres.Add(tragedy);
            //    db.Genres.Add(scientific);
            //    db.SaveChanges();
            //}


            BookContext db1 = new BookContext();
            var books = db1.Books;
            var genres = db1.Genres;
            int counter = 1;
            int number1 = db1.Books.Count();//19 агрегатна ф-ія
            int minPrice = db1.Books.Min(p => p.Price);//15
            // максимальная цена
            int maxPrice = db1.Books.Max(p => p.Price);//15
            foreach (Genre genre in genres)
                comboBox2.Items.Add(genre.Name);

                foreach (Book book in books)
            {

                foreach (Genre genre in genres) {
                    switch (counter)
                    {
                        case 1:
                            pictureBox1.Load(book.Photo);
                            materialSingleLineTextField1.Text = Convert.ToString(book.Title);
                            materialLabel1.Text = "Price:" + Convert.ToString(book.Price) + " UAH";
                            materialSingleLineTextField6.Text = Convert.ToString(book.Author);
                            if(genre.Id== book.Id)
                            materialSingleLineTextField10.Text = Convert.ToString(genre.Name);
                            break;
                        case 2:
                            pictureBox2.Load(book.Photo);
                            materialSingleLineTextField2.Text = Convert.ToString(book.Title);
                            materialLabel2.Text = "Price:" + Convert.ToString(book.Price) + " UAH";
                            materialSingleLineTextField7.Text = Convert.ToString(book.Author);
                            if (genre.Id == book.Id)
                                materialSingleLineTextField11.Text = Convert.ToString(genre.Name);
                            break;
                        case 3:
                            pictureBox3.Load(book.Photo);
                            materialSingleLineTextField3.Text = Convert.ToString(book.Title);
                            materialLabel3.Text = "Price:" + Convert.ToString(book.Price) + " UAH";
                            materialSingleLineTextField8.Text = Convert.ToString(book.Author);
                            if (genre.Id == book.Id)
                                materialSingleLineTextField12.Text = Convert.ToString(genre.Name);
                            break;
                        case 4:
                            pictureBox4.Load(book.Photo);
                            materialSingleLineTextField4.Text = Convert.ToString(book.Title);
                            materialLabel4.Text = "Price:" + Convert.ToString(book.Price) + " UAH";
                            materialSingleLineTextField9.Text = Convert.ToString(book.Author);
                            if (genre.Id == book.Id)
                                materialSingleLineTextField13.Text = Convert.ToString(genre.Name);
                            break;
                        default:
                            break;
                    }  }
                counter++;

            }

        }

        private void materialFlatButton1_Click_1(object sender, EventArgs e)
        {
            string str  = materialSingleLineTextField5.Text;
            materialSingleLineTextField5.Text = "";
            Orderss order;
            order = new Orderss(str);
            order.Location = this.Location;
            this.Hide();
            order.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    BookContext db1 = new BookContext();
                    var books = db1.Books.OrderByDescending(u => u.Price);//16
                    var genres = db1.Genres.OrderByDescending(u=>u.Id);
                    int counter = 1;
                    foreach (Book book in books)
                    {
                        foreach (Genre genre in genres)
                        {
                            switch (counter)
                            {
                                case 1:
                                    pictureBox1.Load(book.Photo);
                                    materialSingleLineTextField1.Text = Convert.ToString(book.Title);
                                    materialLabel1.Text = "Price:" + Convert.ToString(book.Price) + " UAH";
                                    materialSingleLineTextField6.Text = Convert.ToString(book.Author);
                                    if (genre.Id == book.Id)
                                        materialSingleLineTextField10.Text = Convert.ToString(genre.Name);
                                    break;
                                case 2:
                                    pictureBox2.Load(book.Photo);
                                    materialSingleLineTextField2.Text = Convert.ToString(book.Title);
                                    materialLabel2.Text = "Price:" + Convert.ToString(book.Price) + " UAH";
                                    materialSingleLineTextField7.Text = Convert.ToString(book.Author);
                                    if (genre.Id == book.Id)
                                        materialSingleLineTextField11.Text = Convert.ToString(genre.Name);
                                    break;
                                case 3:
                                    pictureBox3.Load(book.Photo);
                                    materialSingleLineTextField3.Text = Convert.ToString(book.Title);
                                    materialLabel3.Text = "Price:" + Convert.ToString(book.Price) + " UAH";
                                    materialSingleLineTextField8.Text = Convert.ToString(book.Author);
                                    if (genre.Id == book.Id)
                                        materialSingleLineTextField12.Text = Convert.ToString(genre.Name);
                                    break;
                                case 4:
                                    pictureBox4.Load(book.Photo);
                                    materialSingleLineTextField4.Text = Convert.ToString(book.Title);
                                    materialLabel4.Text = "Price:" + Convert.ToString(book.Price) + " UAH";
                                    materialSingleLineTextField9.Text = Convert.ToString(book.Author);
                                    if (genre.Id == book.Id)
                                        materialSingleLineTextField13.Text = Convert.ToString(genre.Name);
                                    break;
                                default:
                                    break;
                            }
                        }
                        counter++;

                    }
                    break;
                case 1:
                    BookContext db2 = new BookContext();
                    var books_ = db2.Books.OrderBy(u => u.Price);
                    var genres_ = db2.Genres.OrderBy(u => u.Id);
                    int counter1 = 1;
                    foreach (Book book in books_)
                    {
                        foreach (Genre genre in genres_)
                        {
                            switch (counter1)
                            {
                                case 1:
                                    pictureBox1.Load(book.Photo);
                                    materialSingleLineTextField1.Text = Convert.ToString(book.Title);
                                    materialLabel1.Text = "Price:" + Convert.ToString(book.Price) + " UAH";
                                    materialSingleLineTextField6.Text = Convert.ToString(book.Author);
                                    if (genre.Id == book.Id)
                                        materialSingleLineTextField10.Text = Convert.ToString(genre.Name);
                                    break;
                                case 2:
                                    pictureBox2.Load(book.Photo);
                                    materialSingleLineTextField2.Text = Convert.ToString(book.Title);
                                    materialLabel2.Text = "Price:" + Convert.ToString(book.Price) + " UAH";
                                    materialSingleLineTextField7.Text = Convert.ToString(book.Author);
                                    if (genre.Id == book.Id)
                                        materialSingleLineTextField11.Text = Convert.ToString(genre.Name);
                                    break;
                                case 3:
                                    pictureBox3.Load(book.Photo);
                                    materialSingleLineTextField3.Text = Convert.ToString(book.Title);
                                    materialLabel3.Text = "Price:" + Convert.ToString(book.Price) + " UAH";
                                    materialSingleLineTextField8.Text = Convert.ToString(book.Author);
                                    if (genre.Id == book.Id)
                                        materialSingleLineTextField12.Text = Convert.ToString(genre.Name);
                                    break;
                                case 4:
                                    pictureBox4.Load(book.Photo);
                                    materialSingleLineTextField4.Text = Convert.ToString(book.Title);
                                    materialLabel4.Text = "Price:" + Convert.ToString(book.Price) + " UAH";
                                    materialSingleLineTextField9.Text = Convert.ToString(book.Author);
                                    if (genre.Id == book.Id)
                                        materialSingleLineTextField13.Text = Convert.ToString(genre.Name);
                                    break;
                                default:
                                    break;
                            }
                        }
                        counter1++;

                    }
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str = materialSingleLineTextField5.Text;
            materialSingleLineTextField5.Text = "";
            Orderss order;
            order = new Orderss(str);
            order.Location = this.Location;
            this.Hide();
            order.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = materialSingleLineTextField1.Text;
            Orderss order;
            order = new Orderss(str);
            order.Location = this.Location;
            this.Hide();
            order.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = materialSingleLineTextField2.Text;
            Orderss order;
            order = new Orderss(str);
            order.Location = this.Location;
            this.Hide();
            order.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = materialSingleLineTextField3.Text;
            Orderss order;
            order = new Orderss(str);
            order.Location = this.Location;
            this.Hide();
            order.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = materialSingleLineTextField4.Text;
            Orderss order;
            order = new Orderss(str);
            order.Location = this.Location;
            this.Hide();
            order.Show();
        }
    }
};
