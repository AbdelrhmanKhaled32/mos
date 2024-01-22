using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace supermarket
{
    /// <summary>
    /// Interaction logic for fatora.xaml
    /// </summary>
    public partial class fatora : Page
    {
        supermarketEntities entities = new supermarketEntities();
        PRODECT ta = new PRODECT();
        string msa;
        int idd;
        public fatora()
        {
            InitializeComponent();
            dg.ItemsSource = entities.PRODECTs.ToList();


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int counter = int.Parse(counterTextBox.Text);
            counter--;
            counterTextBox.Text = counter.ToString();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int counter = int.Parse(counterTextBox.Text);
            counter++;
            counterTextBox.Text = counter.ToString();

        }
        public void add()
        {
            if (name.Text != "" && id.Text != "")
            {
                MessageBox.Show("البحث با حاجه وحده");
            }
            else if (name.Text == "" && id.Text == "")
            {
                MessageBox.Show("فين اسم المونتج او رقمه");
            }
            else
            {
                idd = int.Parse(id.Text);
                ta = entities.PRODECTs.FirstOrDefault(x => x.ID == idd || name.Text == x.NAMEE);

                if (ta != null)
                {
                    msa = ta.NAMEE + " " + counterTextBox.Text;

                    if (fa.Text == "")
                    {
                        fa.Text = msa + Environment.NewLine;
                        int xx = (int)ta.AMOUNT;
                        string[] substrings = fa.Text.Split(' ');
                        int con = int.Parse(substrings.Last());
                        xx -= con;
                        ta.AMOUNT = xx;
                        entities.PRODECTs.AddOrUpdate(ta);
                    }
                    else
                    {
                        fa.Text += msa + Environment.NewLine;
                        int xx = (int)ta.AMOUNT;
                        string[] substrings = fa.Text.Split(' ');
                        int con = int.Parse(substrings.Last());
                        xx -= con;
                        ta.AMOUNT = xx;
                        entities.PRODECTs.AddOrUpdate(ta);
                    }

                }
                else if (ta == null)
                {
                    MessageBox.Show("اسم المونتج خطا");
                }
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            if (fa.Text != "")
            {
                entities.SaveChanges();
                dg.ItemsSource = entities.PRODECTs.ToList();
                MessageBox.Show("valid");
            }
            else
            {
                MessageBox.Show("فين المونتج الي انت مدخله");
            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            entities.Entry(ta).Reload();
            fa.Text = "";
            counterTextBox.Text = "0";
            idd = 0;
        }
    }
}
