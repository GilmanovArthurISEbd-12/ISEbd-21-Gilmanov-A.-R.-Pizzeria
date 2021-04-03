using AbstractPizzeriaBusinessLogic.BindingModel;
using AbstractPizzeriaBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractPizzeriaBusinessLogic.Interfaces
{
    public interface IOrderStorage
    {
        List<OrderViewModel> GetFullList();
        List<OrderViewModel> GetFilteredList(OrderBindingModel model);
        OrderViewModel GetElement(OrderBindingModel model);
        void Insert(OrderBindingModel model);
        void Update(OrderBindingModel model);
        void Delete(OrderBindingModel model);
    }
}
