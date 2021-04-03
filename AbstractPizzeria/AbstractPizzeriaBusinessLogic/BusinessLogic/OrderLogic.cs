using AbstractPizzeriaBusinessLogic.BindingModel;
using AbstractPizzeriaBusinessLogic.Enums;
using AbstractPizzeriaBusinessLogic.Interfaces;
using AbstractPizzeriaBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace AbstractPizzeriaBusinessLogic.BusinessLogic
{
    public class OrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        public OrderLogic(IOrderStorage orderStorage)
        {
            _orderStorage = orderStorage;
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }

        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                PizzaId = model.PizzaId,
                Quantity = model.Quantity,
                Cost = model.Cost,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId
            });
            if (order == null)
            {
                throw new Exception("Order did not found");
            }
            if (order.Status != OrderStatus.Принят)
            {
                throw new Exception("Order is not in status \"Accepted\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                PizzaId = order.PizzaId,
                Quantity = order.Quantity,
                Cost = order.Cost,
                DateCreate = order.DateCreate,
                DateImplement = DateTime.Now,
                Status = OrderStatus.Выполняется
            });
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id =
           model.OrderId
            });
            if (order == null)
            {
                throw new Exception("Order did not found");
            }
            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Order is not in status \"Executing\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                PizzaId = order.PizzaId,
                Quantity = order.Quantity,
                Cost = order.Cost,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Готов
            });
        }

        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Order did not found");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Order is not in status \"not ready\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                PizzaId = order.PizzaId,
                PizzaName = order.PizzaName,
                Quantity = order.Quantity,
                Cost = order.Cost,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
        }
    }
}
