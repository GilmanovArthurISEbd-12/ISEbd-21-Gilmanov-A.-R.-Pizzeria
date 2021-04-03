using System.Collections.Generic;

namespace AbstractPizzeriaBusinessLogic.BindingModel
{
    /// Изделие, изготавливаемое в магазине
    public class PizzaBindingModel
    {
        public int? Id { get; set; }
        public string PizzaName { get; set; }
        public decimal Cost { get; set; }
        public Dictionary<int, (string, int)> Ingredients { get; set; }

    }
}
