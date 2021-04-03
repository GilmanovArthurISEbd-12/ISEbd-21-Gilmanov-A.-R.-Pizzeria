using System;
using AbstractPizzeriaBusinessLogic.Enums;


namespace AbstractPizzeriaBusinessLogic.BindingModel
{
    ///Заказ
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
