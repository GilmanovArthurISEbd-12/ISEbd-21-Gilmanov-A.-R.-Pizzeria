using System;
using System.Collections.Generic;
using AbstractPizzeriaBusinessLogic.BindingModel;
using AbstractPizzeriaBusinessLogic.BusinessLogic;
using AbstractPizzeriaBusinessLogic.ViewModels;
using System.Windows.Forms;
using Unity;

namespace AbstractPizzeriaView
{
    public partial class FormPizza : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly PizzaLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> pizzaIngredients;
        public FormPizza(PizzaLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }

        private void LoadData()
        {
            try
            {
                if (pizzaIngredients != null)
                {
                    dataGridViewIng.Rows.Clear();
                    foreach (var pi in pizzaIngredients)
                    {
                        dataGridViewIng.Rows.Add(new object[] { pi.Key, pi.Value.Item1,
                        pi.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPizzaIngredient>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (pizzaIngredients.ContainsKey(form.Id))
                {
                    pizzaIngredients[form.Id] = (form.IngredientName, form.Count);
                }
                else
                {
                    pizzaIngredients.Add(form.Id, (form.IngredientName, form.Count));
                }
                LoadData();
            }
        }
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewIng.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormPizzaIngredient>();
                int id = Convert.ToInt32(dataGridViewIng.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = pizzaIngredients[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    pizzaIngredients[form.Id] = (form.IngredientName, form.Count);
                    LoadData();
                }
            }
        }
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewIng.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Delete ", "Question", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        pizzaIngredients.Remove(Convert.ToInt32(dataGridViewIng.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonChange_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Fill name", "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxCost.Text))
            {
                MessageBox.Show("Fill cost", "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (pizzaIngredients == null || pizzaIngredients.Count == 0)
            {
                MessageBox.Show("Fill ingredients", "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new PizzaBindingModel
                {
                    Id = id,
                    PizzaName = textBoxName.Text,
                    Cost = Convert.ToDecimal(textBoxCost.Text),
                    Ingredients = pizzaIngredients
                });
                MessageBox.Show("Save was succesful", "Message",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormPizza_Load(object sender, EventArgs e)
        {
                if (id.HasValue)
                {
                    try
                    {
                        PizzaViewModel view = logic.Read(new PizzaBindingModel
                        {
                            Id = id.Value
                        })?[0];
                        if (view != null)
                        {
                            textBoxName.Text = view.PizzaName;
                            textBoxCost.Text = view.Cost.ToString();
                            pizzaIngredients = view.PizzaIngredient;
                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                }
                else
                {
                    pizzaIngredients = new Dictionary<int, (string, int)>();
                }
            
        }
    }
}
