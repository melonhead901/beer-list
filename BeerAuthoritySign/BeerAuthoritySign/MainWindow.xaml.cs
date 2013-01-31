using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace BeerAuthoritySign
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private ObservableCollection<Beer> beerList = new ObservableCollection<Beer>();

    public MainWindow()
    {

      InitializeComponent();

      BeerList bl = BeerList.LoadBeerList("mybeers.txt");
      this.beerList = bl.Beers;

      while (beerList.Count < 8)
      {
        beerList.Add(new Beer());
      }

      DataContext = beerList;
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      SaveBeerList();
    }

    private void SaveBeerList()
    {
      BeerList.SaveBeerList(new BeerList() { Beers = this.beerList }, "mybeers.txt");
    }

    private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
    {
      SaveBeerList();
    }
  }
}
