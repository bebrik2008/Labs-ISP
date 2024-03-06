using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_LAB_1_Lavriv_Ivan
{
    public partial class Cocktails_ingredients : ContentPage
    {
        private readonly IDbService _dbService;

        public Cocktails_ingredients(IDbService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            _dbService.Init();

            var CocktailList = _dbService.GetAllCocktails();
            foreach (var cocktail in CocktailList)
            {
                CocktailPicker.Items.Add(cocktail.Name); 
            }
        }

        private void OnCocktailPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCocktailName = CocktailPicker.SelectedItem as string; 
            var selectedCocktail = _dbService.GetAllCocktails().FirstOrDefault(c => c.Name == selectedCocktailName);
            if (selectedCocktail != null)
            {
                var ingredients = _dbService.GetIngredientsForCocktail(selectedCocktail.Id);
                IngredientsCollectionView.ItemsSource = ingredients;
            }
        }
    }
}
