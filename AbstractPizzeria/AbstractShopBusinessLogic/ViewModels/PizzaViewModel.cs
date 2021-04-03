using System.Collections.Generic;
using System.ComponentModel;

namespace AbstractPizzeriaBusinessLogic.ViewModels
{
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class PizzaViewModel
    {
        public int Id { get; set; }
        [DisplayName("Pizza Name")]   
        public string PizzaName { get; set; }
        [DisplayName("Cost")]
        public decimal Cost { get; set; }
        public Dictionary<int, (string, int)> PizzaIngredient { get; set; }
    }
}
