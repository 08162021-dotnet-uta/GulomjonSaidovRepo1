using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class StoreRepository : IRepository<Store>
  {
    private const string _path = @"C:\Users\gulom\source\repos\08162021-dotnet-uta\GulomjonSaidovRepo1\data\stores.xml";

    private static readonly FileAdapter _fileAdapter = new FileAdapter();

    public StoreRepository()
    {

      if (_fileAdapter.ReadFromFile<Store>(_path) == null)
      {
        _fileAdapter.WriteToFile<Store>(_path, new List<Store>()
        {
          new Colma(){StoreId = 1},
          new Central(){StoreId = 2},
          new West(){StoreId = 3},
          new Stonestown(){StoreId = 4}
        });
      }

    }

    public bool Delete()
    {
      throw new System.NotImplementedException("Not implemented yet");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Insert(Store entry)
    {
      _fileAdapter.WriteToFile<Store>(_path, new List<Store> { entry });

      return true;
    }

    public List<Store> Select()
    {
      return _fileAdapter.ReadFromFile<Store>(_path);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Store Update()
    {
      throw new System.NotImplementedException();
    }
  }
}