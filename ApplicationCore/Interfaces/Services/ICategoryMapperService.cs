using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Services
{
    public interface ICategoryMapperService
    {
        Task<Category> MapEntryToCategory(string entry);
        //this method will receive a sentence or  word as paramenter and it should attempt to map it to an existent category, whose then is returned to the method caller.
        // Algorithm:
        //  #1 - Search for exact matches in the Mapper.Category table;
        //  #2 - Search for similar name pattern in the Mapper.Category table;
    }
}
