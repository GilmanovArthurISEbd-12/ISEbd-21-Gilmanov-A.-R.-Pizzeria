using AbstractPizzeriaBusinessLogic.BindingModel;
using AbstractPizzeriaBusinessLogic.Interfaces;
using AbstractPizzeriaBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace AbstractPizzeriaBusinessLogic.BusinessLogic
{
    public class IngredientLogic
    {
        private readonly IIngredientStorage _ingredientStorage;
        public IngredientLogic(IIngredientStorage ingredientStorage)
        {
            _ingredientStorage = ingredientStorage;
        }
        public List<IngredientViewModel> Read(IngredientBindingModel model)
        {
            if (model == null)
            {
                return _ingredientStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<IngredientViewModel> { _ingredientStorage.GetElement(model)
};
            }
            return _ingredientStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(IngredientBindingModel model)
        {
            var element = _ingredientStorage.GetElement(new IngredientBindingModel
            {
                IngredientName = model.IngredientName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("there is already an ingredient with dat name");
            }
            if (model.Id.HasValue)
            {
                _ingredientStorage.Update(model);
            }
            else
            {
                _ingredientStorage.Insert(model);
            }
        }
        public void Delete(IngredientBindingModel model)

        {
            var element = _ingredientStorage.GetElement(new IngredientBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Element did not found");
            }
            _ingredientStorage.Delete(model);
        }
    }
}
