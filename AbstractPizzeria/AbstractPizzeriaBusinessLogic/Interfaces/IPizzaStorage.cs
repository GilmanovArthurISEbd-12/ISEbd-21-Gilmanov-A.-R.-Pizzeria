using AbstractPizzeriaBusinessLogic.BindingModel;
using AbstractPizzeriaBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractPizzeriaBusinessLogic.Interfaces
{
    public interface IPizzaStorage
    {
        List<PizzaViewModel> GetFullList();
        List<PizzaViewModel> GetFilteredList(PizzaBindingModel model);
        PizzaViewModel GetElement(PizzaBindingModel model);
        void Insert(PizzaBindingModel model);
        void Update(PizzaBindingModel model);
        void Delete(PizzaBindingModel model); 
    }
}
