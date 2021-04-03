namespace AbstractPizzeriaBusinessLogic.BindingModel
{
    /// Данные от клиента, для создания заказа
    public class CreateOrderBindingModel
    {
        public int PizzaId { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}
