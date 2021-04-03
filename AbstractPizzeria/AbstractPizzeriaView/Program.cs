using System;
using System.Windows.Forms;
using Unity.Lifetime;
using AbstractPizzeriaBusinessLogic.BusinessLogic;
using AbstractPizzeriaBusinessLogic.Interfaces;
using AbstractPizzeriaListImplement.Implements;
using Unity;

namespace AbstractPizzeriaView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IIngredientStorage, IngredientStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPizzaStorage, PizzaStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IngredientLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<OrderLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<PizzaLogic>(new
            HierarchicalLifetimeManager());
            return currentContainer;
        }
    }

}
