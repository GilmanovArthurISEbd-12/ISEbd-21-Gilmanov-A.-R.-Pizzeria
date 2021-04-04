using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace AbstractPizzeriaDatabaseImplement.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [ForeignKey("PizzaId")]
        public virtual List<PizzaIngredient> PizzaIngredient { get; set; }

        [ForeignKey("PizzaId")]
        public virtual List<Order> Order { get; set; }

        [Required]
        public string PizzaName { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}
