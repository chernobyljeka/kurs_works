namespace ProduktionRecords_by_Kovalenko
{
    partial class Nom
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nom));
            this.db_uchetkaaccdbDataSet = new ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSet();
            this.nomenclatureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nomenclatureTableAdapter = new ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSetTableAdapters.nomenclatureTableAdapter();
            this.tableAdapterManager = new ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSetTableAdapters.TableAdapterManager();
            this.nomenclatureBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.nomenclatureBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.nomenclatureDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.db_uchetkaaccdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclatureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclatureBindingNavigator)).BeginInit();
            this.nomenclatureBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclatureDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // db_uchetkaaccdbDataSet
            // 
            this.db_uchetkaaccdbDataSet.DataSetName = "db_uchetkaaccdbDataSet";
            this.db_uchetkaaccdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nomenclatureBindingSource
            // 
            this.nomenclatureBindingSource.DataMember = "nomenclature";
            this.nomenclatureBindingSource.DataSource = this.db_uchetkaaccdbDataSet;
            // 
            // nomenclatureTableAdapter
            // 
            this.nomenclatureTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.agreementsTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.kontraagetsTableAdapter = null;
            this.tableAdapterManager.n_in_otgTableAdapter = null;
            this.tableAdapterManager.nomenclatureTableAdapter = this.nomenclatureTableAdapter;
            this.tableAdapterManager.otg_ttnTableAdapter = null;
            this.tableAdapterManager.skladTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // nomenclatureBindingNavigator
            // 
            this.nomenclatureBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.nomenclatureBindingNavigator.BindingSource = this.nomenclatureBindingSource;
            this.nomenclatureBindingNavigator.CountItem = null;
            this.nomenclatureBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.nomenclatureBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.nomenclatureBindingNavigatorSaveItem,
            this.toolStripLabel1,
            this.toolStripTextBox1});
            this.nomenclatureBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.nomenclatureBindingNavigator.MoveFirstItem = null;
            this.nomenclatureBindingNavigator.MoveLastItem = null;
            this.nomenclatureBindingNavigator.MoveNextItem = null;
            this.nomenclatureBindingNavigator.MovePreviousItem = null;
            this.nomenclatureBindingNavigator.Name = "nomenclatureBindingNavigator";
            this.nomenclatureBindingNavigator.PositionItem = null;
            this.nomenclatureBindingNavigator.Size = new System.Drawing.Size(679, 25);
            this.nomenclatureBindingNavigator.TabIndex = 0;
            this.nomenclatureBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // nomenclatureBindingNavigatorSaveItem
            // 
            this.nomenclatureBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nomenclatureBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("nomenclatureBindingNavigatorSaveItem.Image")));
            this.nomenclatureBindingNavigatorSaveItem.Name = "nomenclatureBindingNavigatorSaveItem";
            this.nomenclatureBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.nomenclatureBindingNavigatorSaveItem.Text = "Сохранить данные";
            this.nomenclatureBindingNavigatorSaveItem.Click += new System.EventHandler(this.nomenclatureBindingNavigatorSaveItem_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel1.Text = "Поиск";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // nomenclatureDataGridView
            // 
            this.nomenclatureDataGridView.AutoGenerateColumns = false;
            this.nomenclatureDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.nomenclatureDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nomenclatureDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.nomenclatureDataGridView.DataSource = this.nomenclatureBindingSource;
            this.nomenclatureDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nomenclatureDataGridView.Location = new System.Drawing.Point(0, 25);
            this.nomenclatureDataGridView.Name = "nomenclatureDataGridView";
            this.nomenclatureDataGridView.Size = new System.Drawing.Size(679, 304);
            this.nomenclatureDataGridView.TabIndex = 1;
            this.nomenclatureDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.nomenclatureDataGridView_CellDoubleClick);
            this.nomenclatureDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.nomenclatureDataGridView_CellValueChanged);
            this.nomenclatureDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nomenclatureDataGridView_KeyDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Cost";
            this.dataGridViewTextBoxColumn3.HeaderText = "Цена";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NDS";
            this.dataGridViewTextBoxColumn4.HeaderText = "НДС";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CostwithNds";
            this.dataGridViewTextBoxColumn5.HeaderText = "Стоимость с НДС";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // Nom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 329);
            this.Controls.Add(this.nomenclatureDataGridView);
            this.Controls.Add(this.nomenclatureBindingNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Nom";
            this.Text = "Nom";
            this.Load += new System.EventHandler(this.Nom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.db_uchetkaaccdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclatureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclatureBindingNavigator)).EndInit();
            this.nomenclatureBindingNavigator.ResumeLayout(false);
            this.nomenclatureBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclatureDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private db_uchetkaaccdbDataSet db_uchetkaaccdbDataSet;
        private System.Windows.Forms.BindingSource nomenclatureBindingSource;
        private db_uchetkaaccdbDataSetTableAdapters.nomenclatureTableAdapter nomenclatureTableAdapter;
        private db_uchetkaaccdbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator nomenclatureBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton nomenclatureBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView nomenclatureDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}