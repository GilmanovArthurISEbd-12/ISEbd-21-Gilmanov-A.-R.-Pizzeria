using System.ComponentModel.DataAnnotations;

namespace AbstractPizzeriaDatabaseImplement.Models
{
    /// <summary>
    /// Сколько компонентов, требуется при изготовлении изделия
    /// </summary>
    public class PizzaIngredient
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Ingredient Ingredients { get; set; }
        public virtual Pizza Pizzas { get; set; }
    }
}