using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace ServerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        public static int recipeCode=9;
        public static List<Recipe> recipeList = new List<Recipe>()
        {
            new Recipe(){ RecipeCode=1, RecipeName="פיצה", CategoryCode=2,PreparationTimeMinutes=50, DifficultyLevel=3, DateAdded=new DateTime(),
                Ingredients=["water"], PreparationSteps=["rrr","rg"], UserCode=111, ImageRoute="sss" },
            new Recipe(){ RecipeCode=2, RecipeName="סלט", CategoryCode=3,PreparationTimeMinutes=45, DifficultyLevel=5, DateAdded=new DateTime(),
                Ingredients=["water"], PreparationSteps=["rrr","rg"], UserCode=111, ImageRoute="sss" },
            new Recipe(){ RecipeCode=3, RecipeName="עוגת קצפת", CategoryCode=1,PreparationTimeMinutes=35, DifficultyLevel=4, DateAdded=new DateTime(),
                Ingredients=["water"], PreparationSteps=["rrr","rg"], UserCode=111, ImageRoute="sss" },
            new Recipe(){ RecipeCode=4, RecipeName="עוגת יומולדת", CategoryCode=2,PreparationTimeMinutes=200, DifficultyLevel=3, DateAdded=new DateTime(),
                Ingredients=["water"], PreparationSteps=["rrr","rg"], UserCode=111, ImageRoute="sss" },
            new Recipe(){ RecipeCode=5, RecipeName="עוגיות אוראו", CategoryCode=3,PreparationTimeMinutes=240, DifficultyLevel=2, DateAdded=new DateTime(),
                Ingredients=["water"], PreparationSteps=["rrr","rg"], UserCode=111, ImageRoute="sss" },
            new Recipe(){ RecipeCode=6, RecipeName="מילקשייק", CategoryCode=1,PreparationTimeMinutes=120, DifficultyLevel=3, DateAdded=new DateTime(),
                Ingredients=["water"], PreparationSteps=["rrr","rg"], UserCode=111, ImageRoute="sss" },
            new Recipe(){ RecipeCode=7, RecipeName="ארטיקים", CategoryCode=2,PreparationTimeMinutes=15, DifficultyLevel=1, DateAdded=new DateTime(),
                Ingredients=["water"], PreparationSteps=["rrr","rg"], UserCode=111, ImageRoute="sss" },
            new Recipe(){ RecipeCode=8, RecipeName="ספגטי מוקרם", CategoryCode=3,PreparationTimeMinutes=180, DifficultyLevel=5, DateAdded=new DateTime(),
                Ingredients=["water"], PreparationSteps=["rrr","rg"], UserCode=111, ImageRoute="src\\assets\\26935595_burger_05.jpg" }

        };
        //Get all recipe
        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return recipeList;
        }
        //Get by id
        //[HttpGet("{id}")]
        //public Recipe Get(int id) 
        //{
        //    var recipe = recipeList[id-1];
        //    return recipe;
        //}
        [HttpPost]
        public IActionResult Post([FromBody] Recipe recipe) 
        {
            try
            {
                recipe.RecipeCode = recipeCode++;
                recipeList.Add(recipe);
                return Ok(recipeList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{

        //}
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var existingRecipe = recipeList.FirstOrDefault(r => r.RecipeCode == id);
                if (existingRecipe == null)
                {
                    return NotFound();
                }
                recipeList.Remove(existingRecipe);
                return Ok(existingRecipe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Recipe updatedRecipe)
        {
            try
            {
                var existingRecipe = recipeList.FirstOrDefault(r => r.RecipeCode == id);
                if (existingRecipe == null)
                {
                    return NotFound();
                }

                // Update the existing recipe with the properties from the updatedRecipe object
                existingRecipe.RecipeName = updatedRecipe.RecipeName;
                existingRecipe.CategoryCode = updatedRecipe.CategoryCode;
                existingRecipe.PreparationTimeMinutes = updatedRecipe.PreparationTimeMinutes;
                existingRecipe.DifficultyLevel = updatedRecipe.DifficultyLevel;
                existingRecipe.DateAdded = updatedRecipe.DateAdded;
                existingRecipe.Ingredients = updatedRecipe.Ingredients;
                existingRecipe.PreparationSteps = updatedRecipe.PreparationSteps;
                existingRecipe.UserCode = updatedRecipe.UserCode;
                existingRecipe.ImageRoute = updatedRecipe.ImageRoute;

                return Ok(existingRecipe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            var recipe = recipeList.Find(x => x.RecipeCode == id);
            if (recipe != null)
                return recipe;
            return null;
        }

















    }
}
