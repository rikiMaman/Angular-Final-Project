namespace ServerProject
{
    public class Recipe
    {
        static int count1 = 8, count2=1;

        public int RecipeCode {  get; set; }
        public string RecipeName {  get; set; }
        public int CategoryCode {  get; set; }
        public int PreparationTimeMinutes {  get; set; }
        public int DifficultyLevel {  get; set; }
        public DateTime DateAdded {  get; set; }
        public string[] Ingredients {  get; set; }
        public string[] PreparationSteps {  get; set; }
        public int UserCode {  get; set; }
        public string ImageRoute {  get; set; }




        public Recipe() { }
    }
}
