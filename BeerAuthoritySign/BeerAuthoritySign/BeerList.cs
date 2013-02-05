using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BeerAuthoritySign
{
  [Serializable]
  class BeerList
  {
    public ObservableCollection<Beer> Beers { get; set; }

    // private BeerList() {}

    public BeerList()
    {
      this.Beers = new ObservableCollection<Beer>();
    }

    public static BeerList LoadBeerList(string path)
    {
      try
      {
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
          BeerList beerList = (BeerList)formatter.Deserialize(stream);
          return beerList;
          
        }
        
      }
      catch
      {
        return new BeerList();
      }
    }

    public static void SaveBeerList(ObservableCollection<Beer> beerList, string path)
    {
      IFormatter formatter = new BinaryFormatter();
      Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
      formatter.Serialize(stream, new BeerList() { Beers = beerList });
      stream.Close();
    }
  }
}
