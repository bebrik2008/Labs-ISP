using SQLite;


namespace ISP_LAB_1_Lavriv_Ivan
    {
        public class SQLiteService : IDbService
        {
            private readonly SQLiteConnection _database;

            public SQLiteService()
            {
               string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
               string dbFile = Path.Combine(path, "myDbSQLite.db3");
               
               if(File.Exists(dbFile)) File.Delete(dbFile);
               _database = new SQLiteConnection(dbFile, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            }

        public void Init()
        {
            _database.CreateTable<Cocktail>();
            _database.CreateTable<Ingredient>(); 

            AddInitialData();
        }
        public IEnumerable<Cocktail> GetAllCocktails()
            {
                return _database.Table<Cocktail>().ToList();
            }

        public IEnumerable<Ingredient> GetIngredientsForCocktail(int id)
        {
            return _database.Table<Ingredient>().Where(i => i.CocktailId == id).ToList();
        }

        private void AddInitialData()
            {
                var cocktails = new List<Cocktail>
            {
                new Cocktail { Id = 1, Name = "Мохито" },
                new Cocktail { Id = 2,Name = "Маргарита" },
                new Cocktail {Id = 3,  Name = "Негрони" },
                new Cocktail {Id = 4,  Name = "Джин тоник" },
                new Cocktail {Id = 5,  Name = "Дайкари" },
                new Cocktail {Id = 6,  Name = "Текила" },
                new Cocktail {Id = 7,  Name = "Белый русский" },
                new Cocktail {Id = 8,  Name = "Кровавая Мэри" },
                new Cocktail {Id = 9,  Name = "Беллини" },
                new Cocktail {Id = 10,  Name = "Олд фешен" }
            };

                foreach (var cocktail in cocktails)
                {
                    _database.Insert(cocktail);
                }

                var ingredients = new List<Ingredient>
            {
                // Ингредиенты для Мохито
                new Ingredient {Id = 1, Name = "Ром", CocktailId = 1 },
                new Ingredient {Id = 2, Name = "Лайм", CocktailId = 1 },
                new Ingredient {Id = 3, Name = "Сахарный сироп", CocktailId = 1 },
                new Ingredient {Id = 4, Name = "Мята", CocktailId = 1 },
                new Ingredient {Id = 5, Name = "Содовая", CocktailId = 1 },

                 // Ингредиенты для Маргариты
                new Ingredient {Id = 1, Name = "Текила", CocktailId = 2 },
                new Ingredient {Id = 2, Name = "Апельсиновый ликер", CocktailId = 2 },
                new Ingredient {Id = 3, Name = "Лаймовый сок", CocktailId = 2 },
                new Ingredient {Id = 4, Name = "Соль", CocktailId = 2 }, 

                // Ингредиенты для Негрони
                new Ingredient {Id = 1, Name = "Джин", CocktailId = 3 },
                new Ingredient {Id = 2, Name = "Красный вермут", CocktailId = 3 },
                new Ingredient {Id = 3, Name = "Красный кампари", CocktailId = 3 }, 

                // Ингредиенты для Джин тоник
                new Ingredient {Id = 1, Name = "Джин", CocktailId = 4 },
                new Ingredient {Id = 2, Name = "Тоник", CocktailId = 4 },
                new Ingredient {Id = 3, Name = "Лайм", CocktailId = 4 }, 

                // Ингредиенты для Дайкари
                new Ingredient {Id = 1, Name = "Белый ром", CocktailId = 5 },
                new Ingredient {Id = 2, Name = "Лаймовый сок", CocktailId = 5 },
                new Ingredient {Id = 3, Name = "Сахарный сироп", CocktailId = 5 }, 

                // Ингредиенты для Текилы
                new Ingredient {Id = 1, Name = "Текила", CocktailId = 6 },
                new Ingredient {Id = 2, Name = "Лайм", CocktailId = 6 },
                new Ingredient {Id = 3, Name = "Соль", CocktailId = 6 }, 

                // Ингредиенты для Белого русского
                new Ingredient {Id = 1, Name = "Водка", CocktailId = 7 },
                new Ingredient {Id = 2, Name = "Кофейный ликер", CocktailId = 7 },
                new Ingredient {Id = 3, Name = "Сливки", CocktailId = 7 }, 

                // Ингредиенты для Кровавой Мэри
                new Ingredient {Id = 1, Name = "Водка", CocktailId = 8 },
                new Ingredient {Id = 2, Name = "Томатный сок", CocktailId = 8 },
                new Ingredient {Id = 3, Name = "Вустерширский соус", CocktailId = 8 }, 

                // Ингредиенты для Беллини
                new Ingredient {Id = 1, Name = "Персиковое пюре", CocktailId = 9 },
                new Ingredient {Id = 2, Name = "Шампанское", CocktailId = 9 }, 

                // Ингредиенты для Олд фешн
                new Ingredient {Id = 1,Name = "Бурбон", CocktailId = 10 },
                new Ingredient {Id = 2, Name = "Постный сахар", CocktailId = 10 },
                new Ingredient {Id = 3, Name = "Ангостура биттер", CocktailId = 10 }
            };

                foreach (var ingredient in ingredients)
                {
                    _database.Insert(ingredient);
                }
            }
        }
    }


