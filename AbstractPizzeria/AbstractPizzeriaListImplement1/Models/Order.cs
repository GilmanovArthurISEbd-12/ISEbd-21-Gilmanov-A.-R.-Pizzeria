using System;
using AbstractPizzeriaBusinessLogic.Enums;

namespace AbstractPizzeriaListImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
