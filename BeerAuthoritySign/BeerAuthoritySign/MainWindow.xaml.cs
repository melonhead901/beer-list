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

    private EventsList eventsList;

    public int showBeer;

    public  int showEvents;

    private const string BeerListPath = "mybeers.txt";
    private const string EventsListPath = "myevents.txt";

    public static readonly string BeerListLoc = "beerlist.html";
    public static readonly string EventsListLoc = "eventlist.html";

    public MainWindow()
    {
      InitializeComponent();

      BeerList bl = BeerList.LoadBeerList(BeerListPath);
      this.beerList = bl.Beers;

      while (beerList.Count < 13)
      {
        beerList.Add(new Beer());
      }

      DataContext = beerList;

      eventsList = EventsList.LoadEventsList(EventsListPath);
      txtEventsText.DataContext = eventsList;

      this.showBeer = 5;
      this.showEvents = 5;
    }

    private void SaveButtonClick(object sender, RoutedEventArgs e)
    {
      SaveBeerList();
    }

    private void SaveBeerList()
    {
      BeerList.SaveBeerList(this.beerList, BeerListPath);
    }

    private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      SaveBeerList();
      SaveEventsList();
    }

    private void SaveEventsList()
    {
      this.eventsList.SaveToFile(EventsListPath);
    }

    private void MakeBeerListClick(object sender, RoutedEventArgs e)
    {
      int showFor = 30;
      Int32.TryParse(this.txtBeerTime.Text, out showFor);
      if (showFor < 0)
      {
        showFor = 30;
      }
      new BeerListHtmlWriter(new BeerList() { Beers = this.beerList }, "beerlist.html", showFor).Write();
    }

    private void btnUpdateEventsList_Click(object sender, RoutedEventArgs e)
    {
      int showFor = 30;
      Int32.TryParse(this.txtEventsTime.Text, out showFor);
      if (showFor < 0)
      {
        showFor = 30;
      }
      new EventsHtmlWriter("eventlist.html", this.eventsList.EventsText, showFor) .Write();
    }
  }
}
