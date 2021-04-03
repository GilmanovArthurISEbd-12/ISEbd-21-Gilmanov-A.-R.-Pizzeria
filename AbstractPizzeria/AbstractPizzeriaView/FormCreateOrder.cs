using AbstractPizzeriaBusinessLogic.BindingModel;
using AbstractPizzeriaBusinessLogic.BusinessLogic;
using AbstractPizzeriaBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace AbstractPizzeriaView
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly PizzaLogic _logicP;
        private readonly OrderLogic _logicO;
        public FormCreateOrder(PizzaLogic logicP, OrderLogic logicO)
        {
            InitializeComponent();
            _logicP = logicP;
            _logicO = logicO;
        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<PizzaViewModel> pizzalist = _logicP.Read(null);
                if (pizzalist != null)
                {
                    comboBoxPizza.DisplayMember = "PizzaName";
                    comboBoxPizza.ValueMember = "Id";
                    comboBoxPizza.DataSource = pizzalist;
                    comboBoxPizza.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void CalcSum()
        {
            if (comboBoxPizza.SelectedValue != null &&
           !string.IsNullOrEmpty(textBoxQuantity.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxPizza.SelectedValue);
                    PizzaViewModel pizza = _logicP.Read(new PizzaBindingModel
                    {
                        Id= id
                    })?[0];
                    int count = Convert.ToInt32(textBoxQuantity.Text);
                    textBoxCost.Text = (count * pizza?.Cost ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void TextBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ComboBoxPizza_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxQuantity.Text))
            {
                MessageBox.Show("Fill quantity", "error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxPizza.SelectedValue == null)
            {
                MessageBox.Show("Choose pizza", "error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicO.CreateOrder(new CreateOrderBindingModel
                {
                    PizzaId = Convert.ToInt32(comboBoxPizza.SelectedValue),
                    Quantity = Convert.ToInt32(textBoxQuantity.Text),
                    Cost = Convert.ToDecimal(textBoxCost.Text)
                });
                MessageBox.Show("Save was successful", "Message",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
        
