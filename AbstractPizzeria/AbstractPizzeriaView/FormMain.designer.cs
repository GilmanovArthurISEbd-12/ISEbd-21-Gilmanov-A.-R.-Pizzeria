namespace AbstractPizzeriaView
{
    partial class FormMain
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
            this.menuStripGuide = new System.Windows.Forms.MenuStrip();
            this.guideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingredientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pizzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonSubForExec = new System.Windows.Forms.Button();
            this.buttonOrderReady = new System.Windows.Forms.Button();
            this.buttonOrderPaid = new System.Windows.Forms.Button();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStripGuide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripGuide
            // 
            this.menuStripGuide.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guideToolStripMenuItem});
            this.menuStripGuide.Location = new System.Drawing.Point(0, 0);
            this.menuStripGuide.Name = "menuStripGuide";
            this.menuStripGuide.Size = new System.Drawing.Size(800, 24);
            this.menuStripGuide.TabIndex = 0;
            this.menuStripGuide.Text = "Guide";
            // 
            // guideToolStripMenuItem
            // 
            this.guideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingredientsToolStripMenuItem,
            this.pizzaToolStripMenuItem});
            this.guideToolStripMenuItem.Name = "guideToolStripMenuItem";
            this.guideToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.guideToolStripMenuItem.Text = "Guide";
            // 
            // ingredientsToolStripMenuItem
            // 
            this.ingredientsToolStripMenuItem.Name = "ingredientsToolStripMenuItem";
            this.ingredientsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ingredientsToolStripMenuItem.Text = "Ingredients";
            this.ingredientsToolStripMenuItem.Click += new System.EventHandler(this.IngredientsToolStripMenuItem_Click);
            // 
            // pizzaToolStripMenuItem
            // 
            this.pizzaToolStripMenuItem.Name = "pizzaToolStripMenuItem";
            this.pizzaToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.pizzaToolStripMenuItem.Text = "Pizza";
            this.pizzaToolStripMenuItem.Click += new System.EventHandler(this.PizzaToolStripMenuItem_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(647, 52);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(141, 23);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Create order";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
            // 
            // buttonSubForExec
            // 
            this.buttonSubForExec.Location = new System.Drawing.Point(647, 94);
            this.buttonSubForExec.Name = "buttonSubForExec";
            this.buttonSubForExec.Size = new System.Drawing.Size(141, 23);
            this.buttonSubForExec.TabIndex = 3;
            this.buttonSubForExec.Text = "Submit for execution";
            this.buttonSubForExec.UseVisualStyleBackColor = true;
            this.buttonSubForExec.Click += new System.EventHandler(this.buttonSubForExec_Click);
            // 
            // buttonOrderReady
            // 
            this.buttonOrderReady.Location = new System.Drawing.Point(647, 136);
            this.buttonOrderReady.Name = "buttonOrderReady";
            this.buttonOrderReady.Size = new System.Drawing.Size(141, 23);
            this.buttonOrderReady.TabIndex = 4;
            this.buttonOrderReady.Text = "Order`s ready";
            this.buttonOrderReady.UseVisualStyleBackColor = true;
            this.buttonOrderReady.Click += new System.EventHandler(this.ButtonOrderReady_Click);
            // 
            // buttonOrderPaid
            // 
            this.buttonOrderPaid.Location = new System.Drawing.Point(647, 181);
            this.buttonOrderPaid.Name = "buttonOrderPaid";
            this.buttonOrderPaid.Size = new System.Drawing.Size(141, 23);
            this.buttonOrderPaid.TabIndex = 5;
            this.buttonOrderPaid.Text = "Order`s paid ";
            this.buttonOrderPaid.UseVisualStyleBackColor = true;
            this.buttonOrderPaid.Click += new System.EventHandler(this.ButtonOrderPaid_Click);
            // 
            // buttonUpd
            // 
            this.buttonUpd.Location = new System.Drawing.Point(647, 223);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(141, 23);
            this.buttonUpd.TabIndex = 6;
            this.buttonUpd.Text = "Update list";
            this.buttonUpd.UseVisualStyleBackColor = true;
            this.buttonUpd.Click += new System.EventHandler(this.ButtonUpd_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(612, 305);
            this.dataGridView.TabIndex = 7;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 336);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonUpd);
            this.Controls.Add(this.buttonOrderPaid);
            this.Controls.Add(this.buttonOrderReady);
            this.Controls.Add(this.buttonSubForExec);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.menuStripGuide);
            this.MainMenuStrip = this.menuStripGuide;
            this.Name = "FormMain";
            this.Text = "Pizzeria";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStripGuide.ResumeLayout(false);
            this.menuStripGuide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripGuide;
        private System.Windows.Forms.ToolStripMenuItem guideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingredientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pizzaToolStripMenuItem;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonSubForExec;
        private System.Windows.Forms.Button buttonOrderReady;
        private System.Windows.Forms.Button buttonOrderPaid;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}