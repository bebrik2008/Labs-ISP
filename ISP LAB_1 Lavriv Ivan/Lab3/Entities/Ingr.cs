using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_LAB_1_Lavriv_Ivan
{
    // Класс, представляющий ингредиент
    [Table("Ingredient")]
    public class Ingredient
    {
        [PrimaryKey, AutoIncrement, Indexed]
        [Column("Id")]
        public int Id { get; set; }  // Идентификатор ингредиента
        public string Name { get; set; }  // Название ингредиента
        public int CocktailId { get; set; } // Идентификатор коктейля, к которому относится ингредиент (внешний ключ)
    }
}
