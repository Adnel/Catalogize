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
        public Base BookBase { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            new Initialize(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Base.xml");
            BookBase = new Base(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Base.xml");

            BookBaseDataGrid.ItemsSource = BookBase._bookBase;
           
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            List<Book> FindedBooks = new List<Book>();
            FindedBooks = BookBase.Find(FindValue.Text);
            SearchResultsWindow wn = new SearchResultsWindow(FindedBooks, BookBase);
            if (FindedBooks[0] != null)
                wn.Show();
            else
                MessageBox.Show("Книга не найдена");
            
        }

        private void BookBaseDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BookBase.Save();
            BookBaseDataGrid.Items.Refresh();
            Book bk = BookBaseDataGrid.SelectedItem as Book;
            FindValue.Text = bk.Name;
        }

        private void MainOpenButton_Click(object sender, RoutedEventArgs e)
        {
            Book bk;
            bk = BookBaseDataGrid.SelectedItem as Book;
            if(bk!=null)
                System.Diagnostics.Process.Start(bk.Path);
        }

        private void MainAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addwn = new AddWindow(BookBase);
            addwn.Show();
        }

        private void MainWindowActivated(object sender, EventArgs e)
        {
            BookBaseDataGrid.Items.Refresh();
        }

        private void MainWindowClosed(object sender, EventArgs e)
        {
            BookBase.Save();
        }

        private void FindValue_TextChanged(object sender, TextChangedEventArgs e)
        {

        }




    }
}
