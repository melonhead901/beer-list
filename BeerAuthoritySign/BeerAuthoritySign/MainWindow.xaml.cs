using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BeerAuthoritySign
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    BeerList beerList = new BeerList();

    private ObservableCollection<Beer> beers = new ObservableCollection<Beer>();

    public MainWindow()
    {
      InitializeComponent();

      beers.Add(new Beer()
      {
        Name = "Stout",
        Brewery = "Stouts R Us",
        SchoonerPrice = 6,
        PintPrice = 10
      });


      beers.Add(new Beer()
      {
        Name = "Cider",
        Brewery = "Spire",
        SchoonerPrice = 6,
        PintPrice = 10
      });

      while (beers.Count < 8)
      {
        beers.Add(new Beer());
      }

      DataContext = beers;
    }
  }
}
