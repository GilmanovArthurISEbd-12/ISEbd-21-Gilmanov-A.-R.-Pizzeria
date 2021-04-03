using AbstractPizzeriaBusinessLogic.BindingModel;
using AbstractPizzeriaBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractPizzeriaBusinessLogic.Interfaces
{
    public interface IIngredientStorage
    {
        List<IngredientViewModel> GetFullList();
        List<IngredientViewModel> GetFilteredList(IngredientBindingModel model);
        IngredientViewModel GetElement(IngredientBindingModel model);
        void Insert(IngredientBindingModel model);
        void Update(IngredientBindingModel model);
        void Delete(IngredientBindingModel model);

    }
}
