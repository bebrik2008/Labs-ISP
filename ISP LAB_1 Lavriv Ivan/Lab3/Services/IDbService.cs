using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_LAB_1_Lavriv_Ivan
{
    public interface IDbService
    {
        IEnumerable<Cocktail> GetAllCocktails();
        IEnumerable<Ingredient> GetIngredientsForCocktail(int id);
        void Init();
    }
}
