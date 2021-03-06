using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Client.Singletons
{
  /// <summary>
  /// Defines ProductSingleton class
  /// </summary>
  public class ProductSingleton
  {
    private static ProductSingleton _productSingleton;
    private static readonly ProductRepository _productRepository = new ProductRepository();

    public List<Product> Products { get; private set; }
    public static ProductSingleton Instance
    {
      get
      {
        if (_productSingleton == null)
        {
          _productSingleton = new ProductSingleton();
        }

        return _productSingleton;
      }
    }

    /// <summary>
    /// Retrieves Product collection
    /// </summary>
    private ProductSingleton()
    {
      Products = _productRepository.Select();
    }

    /// <summary>
    /// Adds to Product collection
    /// </summary>
    /// <param name="product"></param>
    public void Add(Product product)
    {
      _productRepository.Insert(product);
      Products = _productRepository.Select();
    }
    public void Append(Product product)
    {
      _productRepository.Append(product);
      Products = _productRepository.Select();
    }
  }
}