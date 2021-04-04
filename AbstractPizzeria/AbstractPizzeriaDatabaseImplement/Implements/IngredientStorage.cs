using System;
using System.Collections.Generic;
using System.Text;
using AbstractPizzeriaBusinessLogic.Interfaces;
using AbstractPizzeriaBusinessLogic.ViewModels;
using AbstractPizzeriaBusinessLogic.BindingModel;
using System.Linq;
using AbstractPizzeriaDatabaseImplement.Models;

namespace AbstractPizzeriaDatabaseImplement.Implements
{
    public class IngredientStorage : IIngredientStorage
    {
            public List<IngredientViewModel> GetFullList()
            {
                using (var context = new AbstractPizzeriaDatabase())
                {
                    return context.Ingredients.Select(rec => new IngredientViewModel
                    {
                        Id = rec.Id,
                        IngredientName = rec.IngredientName
                    })
                    .ToList();
                }
            }

            public List<IngredientViewModel> GetFilteredList(IngredientBindingModel model)
            {
                if (model == null)
                {
                    return null;
                }
                using (var context = new AbstractPizzeriaDatabase())
                {
                    return context.Ingredients
                    .Where(rec => rec.IngredientName.Contains(model.IngredientName))
                    .Select(rec => new IngredientViewModel
                    {
                        Id = rec.Id,
                        IngredientName = rec.IngredientName
                    })
                    .ToList();
                }
            }

            public IngredientViewModel GetElement(IngredientBindingModel model)
            {
                if (model == null)
                {
                    return null;
                }
                using (var context = new AbstractPizzeriaDatabase())
                {
                    var component = context.Ingredients
                    .FirstOrDefault(rec => rec.IngredientName == model.IngredientName ||
                    rec.Id == model.Id);
                    return component != null ?
                    new IngredientViewModel
                    {
                        Id = component.Id,
                        IngredientName = component.IngredientName
                    } :
                    null;
                }
            }

            public void Insert(IngredientBindingModel model)
            {
                using (var context = new AbstractPizzeriaDatabase())
                {
                    context.Ingredients.Add(CreateModel(model, new Ingredient()));
                    context.SaveChanges();
                }
            }

            public void Update(IngredientBindingModel model)
            {
                using (var context = new AbstractPizzeriaDatabase())
                {
                    var element = context.Ingredients.FirstOrDefault(rec => rec.Id ==
                    model.Id);
                    if (element == null)
                    {
                        throw new Exception("Element did not find");
                    }
                    CreateModel(model, element);
                    context.SaveChanges();
                }
            }

            public void Delete(IngredientBindingModel model)
            {
                using (var context = new AbstractPizzeriaDatabase())
                {
                    Ingredient element = context.Ingredients.FirstOrDefault(rec => rec.Id ==
                    model.Id);
                    if (element != null)
                    {
                        context.Ingredients.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Element did not find");
                    }
                }
            }

            private Ingredient CreateModel(IngredientBindingModel model, Ingredient component)
            {
                component.IngredientName = model.IngredientName;
                return component;
            }
    }
}


