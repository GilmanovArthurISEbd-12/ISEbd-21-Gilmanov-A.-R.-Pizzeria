using System.ComponentModel;


namespace AbstractPizzeriaBusinessLogic.ViewModels
{
    /// Компонент, требуемый для изготовления изделия
    public class IngredientViewModel
    {
        public int Id { get; set; }
        [DisplayName("Ingredient Name")]
        public string IngredientName { get; set; }
    }
}
