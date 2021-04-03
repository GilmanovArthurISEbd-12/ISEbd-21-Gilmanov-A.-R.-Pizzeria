using AbstractPizzeriaBusinessLogic.BindingModel;
using AbstractPizzeriaBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;

namespace AbstractPizzeriaView
{
    public partial class FormIngredients : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IngredientLogic logic;
        public FormIngredients(IngredientLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormIngredients_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                    dataGridViewIng.DataSource = list;
                    dataGridViewIng.Columns[0].Visible = false;
                    dataGridViewIng.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
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
            var form = Container.Resolve<FormIngredient>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewIng.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Delete ", "Question", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id =
                   Convert.ToInt32(dataGridViewIng.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new IngredientBindingModel { Id = id });
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
            if (dataGridViewIng.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormIngredient>();
                form.Id = Convert.ToInt32(dataGridViewIng.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
         
    }
}
