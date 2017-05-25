namespace ProduktionRecords_by_Kovalenko
{
    partial class Doc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Doc));
            this.db_uchetkaaccdbDataSet = new ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSet();
            this.agreementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.agreementsTableAdapter = new ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSetTableAdapters.agreementsTableAdapter();
            this.tableAdapterManager = new ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSetTableAdapters.TableAdapterManager();
            this.kontraagetsTableAdapter = new ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSetTableAdapters.kontraagetsTableAdapter();
            this.agreementsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.agreementsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.agreementsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.kontraagetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.db_uchetkaaccdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agreementsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agreementsBindingNavigator)).BeginInit();
            this.agreementsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agreementsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kontraagetsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // db_uchetkaaccdbDataSet
            // 
            this.db_uchetkaaccdbDataSet.DataSetName = "db_uchetkaaccdbDataSet";
            this.db_uchetkaaccdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // agreementsBindingSource
            // 
            this.agreementsBindingSource.DataMember = "agreements";
            this.agreementsBindingSource.DataSource = this.db_uchetkaaccdbDataSet;
            // 
            // agreementsTableAdapter
            // 
            this.agreementsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.agreementsTableAdapter = this.agreementsTableAdapter;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.kontraagetsTableAdapter = this.kontraagetsTableAdapter;
            this.tableAdapterManager.n_in_otgTableAdapter = null;
            this.tableAdapterManager.nomenclatureTableAdapter = null;
            this.tableAdapterManager.otg_ttnTableAdapter = null;
            this.tableAdapterManager.skladTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // kontraagetsTableAdapter
            // 
            this.kontraagetsTableAdapter.ClearBeforeFill = true;
            // 
            // agreementsBindingNavigator
            // 
            this.agreementsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.agreementsBindingNavigator.BindingSource = this.agreementsBindingSource;
            this.agreementsBindingNavigator.CountItem = null;
            this.agreementsBindingNavigator.DeleteItem = null;
            this.agreementsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.agreementsBindingNavigatorSaveItem,
            this.toolStripLabel1,
            this.toolStripTextBox1});
            this.agreementsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.agreementsBindingNavigator.MoveFirstItem = null;
            this.agreementsBindingNavigator.MoveLastItem = null;
            this.agreementsBindingNavigator.MoveNextItem = null;
            this.agreementsBindingNavigator.MovePreviousItem = null;
            this.agreementsBindingNavigator.Name = "agreementsBindingNavigator";
            this.agreementsBindingNavigator.PositionItem = null;
            this.agreementsBindingNavigator.Size = new System.Drawing.Size(625, 25);
            this.agreementsBindingNavigator.TabIndex = 0;
            this.agreementsBindingNavigator.Text = "bindingNavigator1";
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
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // agreementsBindingNavigatorSaveItem
            // 
            this.agreementsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.agreementsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("agreementsBindingNavigatorSaveItem.Image")));
            this.agreementsBindingNavigatorSaveItem.Name = "agreementsBindingNavigatorSaveItem";
            this.agreementsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.agreementsBindingNavigatorSaveItem.Text = "Сохранить данные";
            this.agreementsBindingNavigatorSaveItem.Click += new System.EventHandler(this.agreementsBindingNavigatorSaveItem_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel1.Text = "Поиск";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // agreementsDataGridView
            // 
            this.agreementsDataGridView.AutoGenerateColumns = false;
            this.agreementsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.agreementsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.agreementsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.agreementsDataGridView.DataSource = this.agreementsBindingSource;
            this.agreementsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agreementsDataGridView.Location = new System.Drawing.Point(0, 25);
            this.agreementsDataGridView.Name = "agreementsDataGridView";
            this.agreementsDataGridView.Size = new System.Drawing.Size(625, 288);
            this.agreementsDataGridView.TabIndex = 1;
            this.agreementsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.agreementsDataGridView_CellDoubleClick);
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
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ID_kontagent";
            this.dataGridViewTextBoxColumn3.DataSource = this.kontraagetsBindingSource;
            this.dataGridViewTextBoxColumn3.DisplayMember = "Name_org";
            this.dataGridViewTextBoxColumn3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn3.HeaderText = "Контрагент";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.ValueMember = "ID";
            // 
            // kontraagetsBindingSource
            // 
            this.kontraagetsBindingSource.DataMember = "kontraagets";
            this.kontraagetsBindingSource.DataSource = this.db_uchetkaaccdbDataSet;
            // 
            // Doc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 313);
            this.Controls.Add(this.agreementsDataGridView);
            this.Controls.Add(this.agreementsBindingNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Doc";
            this.Text = "Doc";
            this.Load += new System.EventHandler(this.Doc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.db_uchetkaaccdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agreementsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agreementsBindingNavigator)).EndInit();
            this.agreementsBindingNavigator.ResumeLayout(false);
            this.agreementsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agreementsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kontraagetsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private db_uchetkaaccdbDataSet db_uchetkaaccdbDataSet;
        private System.Windows.Forms.BindingSource agreementsBindingSource;
        private db_uchetkaaccdbDataSetTableAdapters.agreementsTableAdapter agreementsTableAdapter;
        private db_uchetkaaccdbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator agreementsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton agreementsBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView agreementsDataGridView;
        private db_uchetkaaccdbDataSetTableAdapters.kontraagetsTableAdapter kontraagetsTableAdapter;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.BindingSource kontraagetsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
    }
}