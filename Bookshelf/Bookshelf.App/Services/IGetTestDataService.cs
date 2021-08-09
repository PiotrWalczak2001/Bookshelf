using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.App.Services
{
    public interface IGetTestDataService
    {
        Task<string> GetData();
    }
}
