using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_LAB_1_Lavriv_Ivan
{
    // Класс, представляющий коктейль
    [Table("Cocktail")]
    public class Cocktail
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; }  // Идентификатор коктейля
        public string Name { get; set; }   // Название коктейля
    }
}
