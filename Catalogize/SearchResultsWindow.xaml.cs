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

namespace Catalogize
{
    /// <summary>
    /// Логика взаимодействия для SearchResultsWindow.xaml
    /// </summary>
    public partial class SearchResultsWindow : Window
    {
        public Base BookBase;
        private List<Book> res { get; set; }
        public SearchResultsWindow()
        {
            InitializeComponent();
            
        }

        public SearchResultsWindow(List<Book> results, Base BookBase)
        {
            InitializeComponent();
            res = results;
            SearchResultDataGrid.ItemsSource = results;
            this.BookBase = BookBase;
        }

        private void SearchResultDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BookBase.Save();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            Book bk = SearchResultDataGrid.SelectedItem as Book;
            if (bk != null)
                System.Diagnostics.Process.Start(bk.Path);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            BookBase.Remove(SearchResultDataGrid.SelectedItem as Book);
            res.Remove(SearchResultDataGrid.SelectedItem as Book);
            OpenButton.IsEnabled = false;
            BookBase.Save();
            SearchResultDataGrid.Items.Refresh();
            
        }
    }
}
