using System;
using System.ComponentModel;
using AbstractPizzeriaBusinessLogic.Enums;


namespace AbstractPizzeriaBusinessLogic.ViewModels
{
    ///Заказ
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        [DisplayName("Pizza")]
        public string PizzaName { get; set; }
        [DisplayName("Quantity")]
        public int Quantity { get; set; }
        [DisplayName("Cost")]
        public decimal Cost { get; set; }
        [DisplayName("Status")]
        public OrderStatus Status { get; set; }
        [DisplayName("Date of Creation")]
        public DateTime DateCreate { get; set; }
        [DisplayName("Date of execution")]
        public DateTime? DateImplement { get; set; }
    }
}
