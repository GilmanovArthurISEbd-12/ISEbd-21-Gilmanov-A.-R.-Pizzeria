using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace AbstractPizzeriaDatabaseImplement.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required]
        public string IngredientName { get; set; }
        [ForeignKey("IngredientId")]
        public virtual List<PizzaIngredient> PizzaIngredient { get; set; }
    }
}
