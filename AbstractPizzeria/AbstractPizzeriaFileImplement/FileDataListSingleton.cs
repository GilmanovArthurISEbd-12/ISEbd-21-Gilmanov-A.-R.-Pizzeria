using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using AbstractPizzeriaFileImplement.Models;
using AbstractPizzeriaBusinessLogic.Enums;

namespace AbstractPizzeriaFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string IngredientFileName = "Ingredient.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string PizzaFileName = "Pizza.xml";
        public List<Ingredient> Ingredients { get; set; }
        public List<Order> Orders { get; set; }
        public List<Pizza> Pizzas { get; set; }
        private FileDataListSingleton()
        {
            Ingredients = LoadIngredients();
            Orders = LoadOrders();
            Pizzas = LoadPizzas();
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();

                foreach (var elem in xElements)
                {
                    OrderStatus status = 0;
                    switch (elem.Element("Status").Value)
                    {
                        case "Принят":
                            status = OrderStatus.Принят;
                            break;
                        case "Выполняется":
                            status = OrderStatus.Выполняется;
                            break;
                        case "Готов":
                            status = OrderStatus.Готов;
                            break;
                        case "Оплачен":
                            status = OrderStatus.Оплачен;
                            break;
                    }

                    DateTime? date = null;
                    if (elem.Element("DateImplement").Value != "")
                    {
                        date = Convert.ToDateTime(elem.Element("DateImplement").Value);
                    }
                    Console.WriteLine(( Convert.ToInt32(elem.Element("Count").Value), Convert.ToDecimal(elem.Element("Sum").Value),
                       status, Convert.ToDateTime(elem.Element("DateCreate").Value), date));
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PizzaId = Convert.ToInt32(elem.Element("PizzaId").Value),
                        Quantity = Convert.ToInt32(elem.Element("Count").Value),
                        Cost = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = status,
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = date
                    });
                }
            }
            return list;
        }

        private List<Pizza> LoadPizzas()
        {
            var list = new List<Pizza>();
            if (File.Exists(PizzaFileName))
            {
                XDocument xDocument = XDocument.Load(PizzaFileName);
                var xElements = xDocument.Root.Elements("Pizza").ToList();
                foreach (var elem in xElements)
                {
                    var pizIng = new Dictionary<int, int>();
                    foreach (var ingredient in
                   elem.Element("PizzaIngredients").Elements("PizzaIngredient").ToList())
                    {
                        pizIng.Add(Convert.ToInt32(ingredient.Element("Key").Value),
                       Convert.ToInt32(ingredient.Element("Value").Value));
                    }
                    list.Add(new Pizza
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PizzaName = elem.Element("PizzaName").Value,
                        Cost = Convert.ToDecimal(elem.Element("Cost").Value),
                        PizzaIngredients = pizIng
                    });
                }
            }
            return list;
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveIngredients();
            SaveOrders();
            SavePizzas();
        }

        private void SavePizzas()
        {
            if (Pizzas != null)
            {
                var xElement = new XElement("Pizzas");
                foreach (var pizza in Pizzas)
                {
                    var compElement = new XElement("PizzaIngredients");
                    foreach (var ingredient in pizza.PizzaIngredients)
                    {
                        compElement.Add(new XElement("PizzaIngredient",
                        new XElement("Key", ingredient.Key),
                        new XElement("Value", ingredient.Value)));
                    }
                    xElement.Add(new XElement("Pizza",
                     new XAttribute("Id", pizza.Id),
                     new XElement("PizzaName", pizza.PizzaName),
                     new XElement("Cost", pizza.Cost),
                     compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(PizzaFileName);
            }
        }

        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("PizzaId", order.PizzaId),
                    new XElement("Count", order.Quantity),
                    new XElement("Sum", order.Cost),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));

                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }

        private void SaveIngredients()
        {
            if (Ingredients != null)
            {
                var xElement = new XElement("Ingredients");
                foreach (var ingredient in Ingredients)
                {
                    xElement.Add(new XElement("Ingredient",
                    new XAttribute("Id", ingredient.Id),
                    new XElement("IngredientName", ingredient.IngredientName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(IngredientFileName);
            }
        }

        private List<Ingredient> LoadIngredients()
        {
            var list = new List<Ingredient>();
            if (File.Exists(IngredientFileName))
            {
                XDocument xDocument = XDocument.Load(IngredientFileName);
                var xElements = xDocument.Root.Elements("Ingredient").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Ingredient
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        IngredientName = elem.Element("IngredientName").Value
                    });
                }
            }

            return list;
        }
    }
}

