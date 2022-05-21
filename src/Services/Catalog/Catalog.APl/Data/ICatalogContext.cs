using Catalog.APl.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.APl.Data
{
   public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
