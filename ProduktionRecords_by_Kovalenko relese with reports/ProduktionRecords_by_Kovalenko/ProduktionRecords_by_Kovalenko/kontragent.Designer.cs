namespace ProduktionRecords_by_Kovalenko
{
    partial class kontragent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kontragent));
            this.db_uchetkaaccdbDataSet = new ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSet();
            this.kontraagetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kontraagetsTableAdapter = new ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSetTableAdapters.kontraagetsTableAdapter();
            this.tableAdapterManager = new ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSetTableAdapters.TableAdapterManager();
            this.kontraagetsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.kontraagetsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.kontraagetsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.db_uchetkaaccdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kontraagetsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kontraagetsBindingNavigator)).BeginInit();
            this.kontraagetsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kontraagetsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // db_uchetkaaccdbDataSet
            // 
            this.db_uchetkaaccdbDataSet.DataSetName = "db_uchetkaaccdbDataSet";
            this.db_uchetkaaccdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kontraagetsBindingSource
            // 
            this.kontraagetsBindingSource.DataMember = "kontraagets";
            this.kontraagetsBindingSource.DataSource = this.db_uchetkaaccdbDataSet;
            // 
            // kontraagetsTableAdapter
            // 
            this.kontraagetsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.agreementsTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.kontraagetsTableAdapter = this.kontraagetsTableAdapter;
            this.tableAdapterManager.n_in_otgTableAdapter = null;
            this.tableAdapterManager.nomenclatureTableAdapter = null;
            this.tableAdapterManager.otg_ttnTableAdapter = null;
            this.tableAdapterManager.skladTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // kontraagetsBindingNavigator
            // 
            this.kontraagetsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.kontraagetsBindingNavigator.BindingSource = this.kontraagetsBindingSource;
            this.kontraagetsBindingNavigator.CountItem = null;
            this.kontraagetsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.kontraagetsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.kontraagetsBindingNavigatorSaveItem,
            this.toolStripLabel1,
            this.toolStripTextBox1});
            this.kontraagetsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.kontraagetsBindingNavigator.MoveFirstItem = null;
            this.kontraagetsBindingNavigator.MoveLastItem = null;
            this.kontraagetsBindingNavigator.MoveNextItem = null;
            this.kontraagetsBindingNavigator.MovePreviousItem = null;
            this.kontraagetsBindingNavigator.Name = "kontraagetsBindingNavigator";
            this.kontraagetsBindingNavigator.PositionItem = null;
            this.kontraagetsBindingNavigator.Size = new System.Drawing.Size(588, 25);
            this.kontraagetsBindingNavigator.TabIndex = 0;
            this.kontraagetsBindingNavigator.Text = "bindingNavigator1";
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
            // kontraagetsBindingNavigatorSaveItem
            // 
            this.kontraagetsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.kontraagetsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("kontraagetsBindingNavigatorSaveItem.Image")));
            this.kontraagetsBindingNavigatorSaveItem.Name = "kontraagetsBindingNavigatorSaveItem";
            this.kontraagetsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.kontraagetsBindingNavigatorSaveItem.Text = "Сохранить данные";
            this.kontraagetsBindingNavigatorSaveItem.Click += new System.EventHandler(this.kontraagetsBindingNavigatorSaveItem_Click);
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
            // kontraagetsDataGridView
            // 
            this.kontraagetsDataGridView.AutoGenerateColumns = false;
            this.kontraagetsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.kontraagetsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kontraagetsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.kontraagetsDataGridView.DataSource = this.kontraagetsBindingSource;
            this.kontraagetsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kontraagetsDataGridView.Location = new System.Drawing.Point(0, 25);
            this.kontraagetsDataGridView.Name = "kontraagetsDataGridView";
            this.kontraagetsDataGridView.Size = new System.Drawing.Size(588, 293);
            this.kontraagetsDataGridView.TabIndex = 1;
            this.kontraagetsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kontraagetsDataGridView_CellClick);
            this.kontraagetsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kontraagetsDataGridView_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name_org";
            this.dataGridViewTextBoxColumn2.HeaderText = "Название организации";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Adress";
            this.dataGridViewTextBoxColumn3.HeaderText = "Адресс";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PostIndex";
            this.dataGridViewTextBoxColumn4.HeaderText = "Почтовый адресс";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Phone";
            this.dataGridViewTextBoxColumn5.HeaderText = "Телефон";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Fax";
            this.dataGridViewTextBoxColumn6.HeaderText = "Факс";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // kontragent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 318);
            this.Controls.Add(this.kontraagetsDataGridView);
            this.Controls.Add(this.kontraagetsBindingNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "kontragent";
            this.Text = "kontragent";
            this.Load += new System.EventHandler(this.kontragent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.db_uchetkaaccdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kontraagetsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kontraagetsBindingNavigator)).EndInit();
            this.kontraagetsBindingNavigator.ResumeLayout(false);
            this.kontraagetsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kontraagetsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private db_uchetkaaccdbDataSet db_uchetkaaccdbDataSet;
        private System.Windows.Forms.BindingSource kontraagetsBindingSource;
        private db_uchetkaaccdbDataSetTableAdapters.kontraagetsTableAdapter kontraagetsTableAdapter;
        private db_uchetkaaccdbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator kontraagetsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton kontraagetsBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView kontraagetsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}