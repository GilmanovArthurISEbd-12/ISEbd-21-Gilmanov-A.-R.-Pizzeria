using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractPizzeriaFileImplement.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string PizzaName { get; set; }
        public decimal Cost { get; set; }
        public Dictionary<int, int> PizzaIngredients { get; set; }
    }
}
