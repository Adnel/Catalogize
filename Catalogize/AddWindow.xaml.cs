using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace Catalogize
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private Base BkBase { get; set; }
        public AddWindow(Base bs)
        {
            InitializeComponent();
            this.BkBase = bs;
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dg = new OpenFileDialog();
            dg.ShowDialog();
            BookPath.Text = dg.FileName;
        }

        private void DenyButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(BookAuthor.Text != ""& BookName.Text != ""& BookPath.Text != "" & BookPublDate.Text != "" & BookRaiting.Text != "")
                BkBase.Add(new Book(BookName.Text, BookAuthor.Text, BookPath.Text, Int32.Parse(BookPublDate.Text), Int32.Parse(BookRaiting.Text)));
            Close();
        }

        private void BookPublDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            int val;
            int.TryParse(BookPublDate.Text, out val);
            BookPublDate.Text = val.ToString();
            

        }

        private void BookRaiting_TextChanged(object sender, TextChangedEventArgs e)
        {
            int val;
            int.TryParse(BookRaiting.Text, out val);
            BookRaiting.Text = val.ToString();
        }




    }
}
