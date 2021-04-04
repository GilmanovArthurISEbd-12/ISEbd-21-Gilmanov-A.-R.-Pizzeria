using System;
using AbstractPizzeriaBusinessLogic.Interfaces;
using AbstractPizzeriaBusinessLogic.ViewModels;
using AbstractPizzeriaBusinessLogic.BindingModel;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AbstractPizzeriaDatabaseImplement.Models;

namespace AbstractPizzeriaDatabaseImplement.Implements
{
    public class PizzaStorage : IPizzaStorage
    {
            public List<PizzaViewModel> GetFullList()
            {
                using (var context = new AbstractPizzeriaDatabase())
                {
                    return context.Pizzas
                    .Include(rec => rec.PizzaIngredient)
                    .ThenInclude(rec => rec.Ingredients)
                    .ToList()
                    .Select(rec => new PizzaViewModel
                    {
                        Id = rec.Id,
                        PizzaName = rec.PizzaName,
                        Cost = rec.Cost,
                        PizzaIngredient = rec.PizzaIngredient
                    .ToDictionary(recPC => recPC.IngredientId, recPC =>
                    (recPC.Ingredients?.IngredientName, recPC.Count))
                    })
                    .ToList();
                }
            }

            public List<PizzaViewModel> GetFilteredList(PizzaBindingModel model)
            {
                if (model == null)
                {
                    return null;
                }
                using (var context = new AbstractPizzeriaDatabase())
                {
                    return context.Pizzas
                    .Include(rec => rec.PizzaIngredient)
                    .ThenInclude(rec => rec.Ingredients)
                    .Where(rec => rec.PizzaName.Contains(model.PizzaName))
                    .ToList()
                    .Select(rec => new PizzaViewModel
                    {
                        Id = rec.Id,
                        PizzaName = rec.PizzaName,
                        Cost = rec.Cost,
                        PizzaIngredient = rec.PizzaIngredient
                    .ToDictionary(recPC => recPC.IngredientId, recPC =>
                    (recPC.Ingredients?.IngredientName, recPC.Count))
                    })
                    .ToList();
                }
            }

            public PizzaViewModel GetElement(PizzaBindingModel model)
            {
                if (model == null)
                {
                    return null;
                }
                using (var context = new AbstractPizzeriaDatabase())
                {
                    var product = context.Pizzas
                    .Include(rec => rec.PizzaIngredient)
                    .ThenInclude(rec => rec.Ingredients)
                    .FirstOrDefault(rec => rec.PizzaName.Equals(model.PizzaName) || rec.Id
                    == model.Id);
                    return product != null ?
                    new PizzaViewModel
                    {
                        Id = product.Id,
                        PizzaName = product.PizzaName,
                        Cost = product.Cost,
                        PizzaIngredient = product.PizzaIngredient
                    .ToDictionary(recPC => recPC.IngredientId, recPC =>
                    (recPC.Ingredients?.IngredientName, recPC.Count))
                    } : null;
                }
            }

            public void Insert(PizzaBindingModel model)
            {
                using (var context = new AbstractPizzeriaDatabase())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            Pizza pizza = CreateModel(model, new Pizza());
                            context.Pizzas.Add(pizza);
                            context.SaveChanges();
                            CreateModel(model, pizza, context);

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }

            public void Update(PizzaBindingModel model)
            {
                using (var context = new AbstractPizzeriaDatabase())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var element = context.Pizzas.FirstOrDefault(rec => rec.Id ==
                            model.Id);
                            if (element == null)
                            {
                                throw new Exception("Element did not find");
                            }
                            CreateModel(model, element, context);
                            context.SaveChanges();
                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }

            public void Delete(PizzaBindingModel model)
            {
                using (var context = new AbstractPizzeriaDatabase())
                {
                    Pizza element = context.Pizzas.FirstOrDefault(rec => rec.Id ==
                    model.Id);
                    if (element != null)
                    {
                        context.Pizzas.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Element did not find");
                    }
                }
            }

            private Pizza CreateModel(PizzaBindingModel model, Pizza pizza)
            {
            pizza.PizzaName = model.PizzaName;
            pizza.Cost = model.Cost;
                return pizza;
            }

            private Pizza CreateModel(PizzaBindingModel model, Pizza pizza,
            AbstractPizzeriaDatabase context)
            {
                pizza.PizzaName = model.PizzaName;
                pizza.Cost= model.Cost;
                if (model.Id.HasValue)
                {
                    var pizzaIngredients = context.PizzaIngredients.Where(rec =>
                    rec.PizzaId == model.Id.Value).ToList();
                    // удалили те, которых нет в модели
                    context.PizzaIngredients.RemoveRange(pizzaIngredients.Where(rec =>
                    !model.Ingredients.ContainsKey(rec.IngredientId)).ToList());
                    context.SaveChanges();
                    // обновили количество у существующих записей
                    foreach (var updateComponent in pizzaIngredients)
                    {
                        updateComponent.Count =
                        model.Ingredients[updateComponent.IngredientId].Item2;
                        model.Ingredients.Remove(updateComponent.IngredientId);
                    }
                    context.SaveChanges();
                }
                // добавили новые
                foreach (var pc in model.Ingredients)
                {
                    context.PizzaIngredients.Add(new PizzaIngredient
                    {
                        PizzaId = pizza.Id,
                        IngredientId = pc.Key,
                        Count = pc.Value.Item2,
                    });
                        context.SaveChanges();
                }
                return pizza;
            }
    }
}
