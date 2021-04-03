using System;
using AbstractPizzeriaBusinessLogic.BindingModel;
using AbstractPizzeriaBusinessLogic.BusinessLogic;
using System.Windows.Forms;
using Unity;
using AbstractPizzeriaView;

namespace AbstractPizzeriaView
{
    public partial class FormListPizza : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly PizzaLogic logic;
        public FormListPizza(PizzaLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormListPizza_Load(object sender, EventArgs e)
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
                    dataGridViewIng.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewIng.Columns[0].Visible = false;
                    dataGridViewIng.Columns[2].Visible = false;
                    dataGridViewIng.Columns[5].Visible = false;
                    dataGridViewIng.Columns[4].AutoSizeMode =
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
            var form = Container.Resolve<FormPizza>();
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
                        logic.Delete(new PizzaBindingModel { Id = id });
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
                var form = Container.Resolve<FormPizza>();
                form.Id = Convert.ToInt32(dataGridViewIng.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}
