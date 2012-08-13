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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Catalogize
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new Initialize(@"D:/Base.xml");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Base bd = new Base(@"D:\Base.xml");
            if(bd.Add(new Book("Blah", "Blah", "D||", 2011, 5)))
                MessageBox.Show("Added 1");
            if(bd.Add(new Book("ASD", "ASD", "D", 2011, 3)))
                MessageBox.Show("Added 2");
            if(bd.Save())
                MessageBox.Show("Saved");
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Book bk = new Book("Blah", "Blah", "D||", 2011, 5, 2);
            Base bd = new Base(@"D:\Base.xml");
            if (bd.Remove(bk))
                MessageBox.Show("Removed");
            bd.Save();
        }
    }
}
