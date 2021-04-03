namespace AbstractPizzeriaView
{
    partial class FormPizza
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.labelCost = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxCost = new System.Windows.Forms.TextBox();
            this.groupBoxIng = new System.Windows.Forms.GroupBox();
            this.dataGridViewIng = new System.Windows.Forms.DataGridView();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.IdPizza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingredient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxIng.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIng)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name:";
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Location = new System.Drawing.Point(12, 38);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(31, 13);
            this.labelCost.TabIndex = 1;
            this.labelCost.Text = "Cost:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(56, 6);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(263, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxCost
            // 
            this.textBoxCost.Location = new System.Drawing.Point(56, 35);
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.Size = new System.Drawing.Size(104, 20);
            this.textBoxCost.TabIndex = 3;
            // 
            // groupBoxIng
            // 
            this.groupBoxIng.Controls.Add(this.dataGridViewIng);
            this.groupBoxIng.Controls.Add(this.buttonUpd);
            this.groupBoxIng.Controls.Add(this.buttonDelete);
            this.groupBoxIng.Controls.Add(this.buttonChange);
            this.groupBoxIng.Controls.Add(this.buttonAdd);
            this.groupBoxIng.Location = new System.Drawing.Point(13, 82);
            this.groupBoxIng.Name = "groupBoxIng";
            this.groupBoxIng.Size = new System.Drawing.Size(537, 331);
            this.groupBoxIng.TabIndex = 4;
            this.groupBoxIng.TabStop = false;
            this.groupBoxIng.Text = "Ingredients";
            // 
            // dataGridViewIng
            // 
            this.dataGridViewIng.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewIng.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIng.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPizza,
            this.Ingredient,
            this.Quantity});
            this.dataGridViewIng.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewIng.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewIng.Name = "dataGridViewIng";
            this.dataGridViewIng.RowHeadersVisible = false;
            this.dataGridViewIng.Size = new System.Drawing.Size(403, 306);
            this.dataGridViewIng.TabIndex = 4;
            // 
            // buttonUpd
            // 
            this.buttonUpd.Location = new System.Drawing.Point(436, 180);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(75, 23);
            this.buttonUpd.TabIndex = 3;
            this.buttonUpd.Text = "Update";
            this.buttonUpd.UseVisualStyleBackColor = true;
            this.buttonUpd.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(436, 136);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(436, 89);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(75, 23);
            this.buttonChange.TabIndex = 1;
            this.buttonChange.Text = "Change";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(436, 42);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(449, 419);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(368, 419);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // IdPizza
            // 
            this.IdPizza.HeaderText = "Id";
            this.IdPizza.Name = "IdPizza";
            this.IdPizza.Visible = false;
            // 
            // Ingredient
            // 
            this.Ingredient.HeaderText = "Ingredient";
            this.Ingredient.Name = "Ingredient";
            this.Ingredient.Width = 260;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 140;
            // 
            // FormPizza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 450);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxIng);
            this.Controls.Add(this.textBoxCost);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelCost);
            this.Controls.Add(this.labelName);
            this.Name = "FormPizza";
            this.Text = "FormPizza";
            this.Load += new System.EventHandler(this.FormPizza_Load);
            this.groupBoxIng.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIng)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxCost;
        private System.Windows.Forms.GroupBox groupBoxIng;
        private System.Windows.Forms.DataGridView dataGridViewIng;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPizza;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingredient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
    }
}