using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AbstractPizzeriaBusinessLogic.Interfaces;
using AbstractPizzeriaBusinessLogic.ViewModels;
using AbstractPizzeriaBusinessLogic.BindingModel;
using System.Linq;
using AbstractPizzeriaDatabaseImplement.Models;

namespace AbstractPizzeriaDatabaseImplement.Implements
{
        public class OrderStorage : IOrderStorage
        {
            public List<OrderViewModel> GetFullList()
            {
                using (var context = new AbstractPizzeriaDatabase())
                {
                    return context.Orders.Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        PizzaName = context.Pizzas
                            .Include(x => x.Order)
                            .FirstOrDefault(r => r.Id == rec.PizzaId).PizzaName,
                        PizzaId = rec.PizzaId,
                        Quantity = rec.Quantity,
                        Cost = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement
                    })
                    .ToList();
                }
            }

            public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
            {
                if (model == null)
                {
                    return null;
                }
                using (var context = new AbstractPizzeriaDatabase())
                {
                    return context.Orders
                    .Where(rec => rec.Id.Equals(model.Id))
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        PizzaName = context.Pizzas
                            .Include(x => x.Order)
                            .FirstOrDefault(r => r.Id == rec.PizzaId).PizzaName,
                        PizzaId = rec.PizzaId,
                        Quantity = rec.Quantity,
                        Cost = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement
                    })
                    .ToList();
                }
            }

            public OrderViewModel GetElement(OrderBindingModel model)
            {
                if (model == null)
                {
                    return null;
                }
                using (var context = new AbstractPizzeriaDatabase())
                {
                    var order = context.Orders
                    .FirstOrDefault(rec => rec.Id == model.Id);
                    return order != null ?
                    new OrderViewModel
                    {
                        Id = order.Id,
                        PizzaName = context.Pizzas
                                .Include(x => x.Order)
                                .FirstOrDefault(r => r.Id == order.PizzaId).PizzaName,
                        PizzaId = order.PizzaId,
                        Quantity = order.Quantity,
                        Cost = order.Sum,
                        Status = order.Status,
                        DateCreate = order.DateCreate,
                        DateImplement = order.DateImplement
                    } :
                    null;
                }
            }

            public void Insert(OrderBindingModel model)
            {
                using (var context = new AbstractPizzeriaDatabase())
                {
                    context.Orders.Add(CreateModel(model, new Order()));
                    context.SaveChanges();
                }
            }

            public void Update(OrderBindingModel model)
            {
                using (var context = new AbstractPizzeriaDatabase())
                {
                    var element = context.Orders.FirstOrDefault(rec => rec.Id ==
                    model.Id);
                    if (element == null)
                    {
                        throw new Exception("Element did not find");
                    }
                    CreateModel(model, element);
                    context.SaveChanges();
                }
            }

            public void Delete(OrderBindingModel model)
            {
                using (var context = new AbstractPizzeriaDatabase())
                {
                    Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
                    model.Id);
                    if (element != null)
                    {
                        context.Orders.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Element did not find");
                    }
                }
            }

            private Order CreateModel(OrderBindingModel model, Order order)
            {
                order.PizzaId = model.PizzaId;
                order.Quantity = model.Quantity;
                order.Sum = model.Cost;
                order.Status = model.Status;
                order.DateCreate = model.DateCreate;
                order.DateImplement = model.DateImplement;
                return order;
            }
        }
}

