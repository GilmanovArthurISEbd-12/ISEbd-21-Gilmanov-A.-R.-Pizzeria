using System;
using System.Collections.Generic;
using AbstractPizzeriaBusinessLogic.Interfaces;
using AbstractPizzeriaBusinessLogic.BindingModel;
using AbstractPizzeriaBusinessLogic.ViewModels;


namespace AbstractPizzeriaBusinessLogic.BusinessLogic
{
    public class PizzaLogic
    {
        private readonly IPizzaStorage _pizzaStorage;
        public PizzaLogic(IPizzaStorage pizzaStorage)
        {
            _pizzaStorage = pizzaStorage;
        }

        public List<PizzaViewModel> Read(PizzaBindingModel model)
        {
            if (model == null)
            {
                return _pizzaStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PizzaViewModel> { _pizzaStorage.GetElement(model) };
            }
            return _pizzaStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(PizzaBindingModel model)
        {
            var ingredient = _pizzaStorage.GetElement(new PizzaBindingModel { PizzaName = model.PizzaName });
            if (ingredient != null && ingredient.Id != model.Id)
            {
                throw new Exception("there is already ingredient with dat name");
            }
            if (model.Id.HasValue)
            {
                _pizzaStorage.Update(model);
            }
            else
            {
                _pizzaStorage.Insert(model);
            }
        }

        public void Delete(PizzaBindingModel model)
        {
            var element = _pizzaStorage.GetElement(new PizzaBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Element did not found");
            }
            _pizzaStorage.Delete(model);
        }
    }
}
