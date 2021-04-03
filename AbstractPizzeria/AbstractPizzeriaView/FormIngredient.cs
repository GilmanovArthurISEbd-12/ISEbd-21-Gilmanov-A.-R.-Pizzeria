using AbstractPizzeriaBusinessLogic.BindingModel;
using AbstractPizzeriaBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;

namespace AbstractPizzeriaView
{
    public partial class FormIngredient : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IngredientLogic logic;
        private int? id;
        public FormIngredient(IngredientLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormIngredient_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
        {
                try
                {
                    var view = logic.Read(new IngredientBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        IngredienttextBoxName.Text = view.IngredientName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void IngredientButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(IngredienttextBoxName.Text))
            {
                MessageBox.Show("Fill name", "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new IngredientBindingModel
                {
                    Id = id,
                    IngredientName = IngredienttextBoxName.Text
                });
                MessageBox.Show("Save was successful", "Message",
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
        private void IngredientCancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
