using System.Collections.Generic;
namespace CookingBook.Models
{
    public class SearchViewModel
    {
        public Recipe RecipeTemplate;
        public IEnumerable<CookingBook.Models.APIRecipe> APIObject;
        public IEnumerable<CookingBook.Models.Recipe> DBObject;
    }
}
