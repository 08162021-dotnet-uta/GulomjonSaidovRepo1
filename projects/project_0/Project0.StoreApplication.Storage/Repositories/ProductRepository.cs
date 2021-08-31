using System.Collections.Generic;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
  /// <summary>
  /// 
  /// </summary>
  public class ProductRepository : IRepository<Product>
  {
    private const string _path = @"/home/gulom/revature/gulomjon_repo/data/products.xml";
    private static readonly FileAdapter _fileAdapter = new FileAdapter();

    public ProductRepository()
    {
      if (_fileAdapter.ReadFromFile<Product>(_path) == null)
      {
        _fileAdapter.WriteToFile<Product>(_path, new List<Product>()
        {
          new Product(){ProductId = 1, Name = "Dell XPS 15.4", Price = 1500, StoreId = 1},
          new Product(){ProductId = 1, Name = "Dell XPS 15.4", Price = 1500, StoreId = 2},
          new Product(){ProductId = 1, Name = "Dell XPS 15.4", Price = 1500, StoreId = 3},
        });
      }
    }

    /// <summary>
    /// Deletes Product collection
    /// </summary>
    /// <returns></returns>
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    /// <summary>
    /// Inserts into Product collection
    /// </summary>
    /// <returns></returns>
    public bool Insert(Product entry)
    {
      _fileAdapter.WriteToFile<Product>(_path, new List<Product> { entry });

      return true;
    }

    /// <summary>
    /// Gets Product collection
    /// </summary>
    /// <returns></returns>
    public List<Product> Select()
    {
      return _fileAdapter.ReadFromFile<Product>(_path);
    }

    /// <summary>
    /// Updates Product collection
    /// </summary>
    /// <returns></returns>
    public Product Update()
    {
      throw new System.NotImplementedException();
    }
  }
}