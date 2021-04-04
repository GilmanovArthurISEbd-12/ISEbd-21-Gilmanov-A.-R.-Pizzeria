using AbstractPizzeriaBusinessLogic.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractPizzeriaDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int PizzaId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
