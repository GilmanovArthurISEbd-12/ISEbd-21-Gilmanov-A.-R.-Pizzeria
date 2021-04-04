namespace AbstractPizzeriaView
{
    partial class FormIngredient
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
            this.labelNameIngredient = new System.Windows.Forms.Label();
            this.IngredienttextBoxName = new System.Windows.Forms.TextBox();
            this.IngredientSaveButton = new System.Windows.Forms.Button();
            this.IngredientCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNameIngredient
            // 
            this.labelNameIngredient.AutoSize = true;
            this.labelNameIngredient.Location = new System.Drawing.Point(30, 33);
            this.labelNameIngredient.Name = "labelNameIngredient";
            this.labelNameIngredient.Size = new System.Drawing.Size(38, 13);
            this.labelNameIngredient.TabIndex = 0;
            this.labelNameIngredient.Text = "Name:";
            // 
            // IngredienttextBoxName
            // 
            this.IngredienttextBoxName.Location = new System.Drawing.Point(89, 30);
            this.IngredienttextBoxName.Name = "IngredienttextBoxName";
            this.IngredienttextBoxName.Size = new System.Drawing.Size(266, 20);
            this.IngredienttextBoxName.TabIndex = 1;
            // 
            // IngredientSaveButton
            // 
            this.IngredientSaveButton.Location = new System.Drawing.Point(160, 54);
            this.IngredientSaveButton.Name = "IngredientSaveButton";
            this.IngredientSaveButton.Size = new System.Drawing.Size(75, 23);
            this.IngredientSaveButton.TabIndex = 2;
            this.IngredientSaveButton.Text = "Save";
            this.IngredientSaveButton.UseVisualStyleBackColor = true;
            this.IngredientSaveButton.Click += new System.EventHandler(this.IngredientButtonSave_Click);
            // 
            // IngredientCancelButton
            // 
            this.IngredientCancelButton.Location = new System.Drawing.Point(241, 54);
            this.IngredientCancelButton.Name = "IngredientCancelButton";
            this.IngredientCancelButton.Size = new System.Drawing.Size(75, 23);
            this.IngredientCancelButton.TabIndex = 3;
            this.IngredientCancelButton.Text = "Cancel";
            this.IngredientCancelButton.UseVisualStyleBackColor = true;
            this.IngredientCancelButton.Click += new System.EventHandler(this.IngredientCancelButton_Click);
            // 
            // FormIngredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 89);
            this.Controls.Add(this.IngredientCancelButton);
            this.Controls.Add(this.IngredientSaveButton);
            this.Controls.Add(this.IngredienttextBoxName);
            this.Controls.Add(this.labelNameIngredient);
            this.Name = "FormIngredient";
            this.Text = "Ingredient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNameIngredient;
        private System.Windows.Forms.TextBox IngredienttextBoxName;
        private System.Windows.Forms.Button IngredientSaveButton;
        private System.Windows.Forms.Button IngredientCancelButton;
    }
}