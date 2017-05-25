namespace ProduktionRecords_by_Kovalenko
{
    partial class journalttn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(journalttn));
            this.db_uchetkaaccdbDataSet = new ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSet();
            this.otg_ttnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.otg_ttnTableAdapter = new ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSetTableAdapters.otg_ttnTableAdapter();
            this.tableAdapterManager = new ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSetTableAdapters.TableAdapterManager();
            this.otg_ttnBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.otg_ttnDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.kontraagetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.agreementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.skladBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbuchetkaaccdbDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kontraagetsTableAdapter = new ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSetTableAdapters.kontraagetsTableAdapter();
            this.agreementsTableAdapter = new ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSetTableAdapters.agreementsTableAdapter();
            this.skladTableAdapter = new ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSetTableAdapters.skladTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.db_uchetkaaccdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.otg_ttnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.otg_ttnBindingNavigator)).BeginInit();
            this.otg_ttnBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.otg_ttnDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kontraagetsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agreementsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skladBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbuchetkaaccdbDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // db_uchetkaaccdbDataSet
            // 
            this.db_uchetkaaccdbDataSet.DataSetName = "db_uchetkaaccdbDataSet";
            this.db_uchetkaaccdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // otg_ttnBindingSource
            // 
            this.otg_ttnBindingSource.DataMember = "otg_ttn";
            this.otg_ttnBindingSource.DataSource = this.db_uchetkaaccdbDataSet;
            // 
            // otg_ttnTableAdapter
            // 
            this.otg_ttnTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.agreementsTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.kontraagetsTableAdapter = null;
            this.tableAdapterManager.n_in_otgTableAdapter = null;
            this.tableAdapterManager.nomenclatureTableAdapter = null;
            this.tableAdapterManager.otg_ttnTableAdapter = this.otg_ttnTableAdapter;
            this.tableAdapterManager.skladTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ProduktionRecords_by_Kovalenko.db_uchetkaaccdbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // otg_ttnBindingNavigator
            // 
            this.otg_ttnBindingNavigator.AddNewItem = null;
            this.otg_ttnBindingNavigator.BindingSource = this.otg_ttnBindingSource;
            this.otg_ttnBindingNavigator.CountItem = null;
            this.otg_ttnBindingNavigator.DeleteItem = null;
            this.otg_ttnBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.otg_ttnBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.otg_ttnBindingNavigator.MoveFirstItem = null;
            this.otg_ttnBindingNavigator.MoveLastItem = null;
            this.otg_ttnBindingNavigator.MoveNextItem = null;
            this.otg_ttnBindingNavigator.MovePreviousItem = null;
            this.otg_ttnBindingNavigator.Name = "otg_ttnBindingNavigator";
            this.otg_ttnBindingNavigator.PositionItem = null;
            this.otg_ttnBindingNavigator.Size = new System.Drawing.Size(853, 25);
            this.otg_ttnBindingNavigator.TabIndex = 0;
            this.otg_ttnBindingNavigator.Text = "bindingNavigator1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(95, 22);
            this.toolStripButton1.Text = "Новая отгрузка";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(55, 22);
            this.toolStripButton2.Text = "Удалить";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(91, 22);
            this.toolStripButton3.Text = "Редактировать";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // otg_ttnDataGridView
            // 
            this.otg_ttnDataGridView.AllowUserToAddRows = false;
            this.otg_ttnDataGridView.AllowUserToDeleteRows = false;
            this.otg_ttnDataGridView.AutoGenerateColumns = false;
            this.otg_ttnDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.otg_ttnDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.otg_ttnDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7});
            this.otg_ttnDataGridView.DataSource = this.otg_ttnBindingSource;
            this.otg_ttnDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.otg_ttnDataGridView.Location = new System.Drawing.Point(0, 25);
            this.otg_ttnDataGridView.Name = "otg_ttnDataGridView";
            this.otg_ttnDataGridView.ReadOnly = true;
            this.otg_ttnDataGridView.Size = new System.Drawing.Size(853, 320);
            this.otg_ttnDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Date_otg";
            this.dataGridViewTextBoxColumn2.HeaderText = "Дата отгрузки";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Kontrg";
            this.dataGridViewTextBoxColumn3.DataSource = this.kontraagetsBindingSource;
            this.dataGridViewTextBoxColumn3.DisplayMember = "Name_org";
            this.dataGridViewTextBoxColumn3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn3.HeaderText = "Контрагент";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.ValueMember = "ID";
            // 
            // kontraagetsBindingSource
            // 
            this.kontraagetsBindingSource.DataMember = "kontraagets";
            this.kontraagetsBindingSource.DataSource = this.db_uchetkaaccdbDataSet;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "agr";
            this.dataGridViewTextBoxColumn4.DataSource = this.agreementsBindingSource;
            this.dataGridViewTextBoxColumn4.DisplayMember = "Name";
            this.dataGridViewTextBoxColumn4.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn4.HeaderText = "Договор";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn4.ValueMember = "ID";
            // 
            // agreementsBindingSource
            // 
            this.agreementsBindingSource.DataMember = "agreements";
            this.agreementsBindingSource.DataSource = this.db_uchetkaaccdbDataSet;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Sklad";
            this.dataGridViewTextBoxColumn5.DataSource = this.skladBindingSource;
            this.dataGridViewTextBoxColumn5.DisplayMember = "Name";
            this.dataGridViewTextBoxColumn5.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn5.HeaderText = "Склад";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn5.ValueMember = "Код";
            // 
            // skladBindingSource
            // 
            this.skladBindingSource.DataMember = "sklad";
            this.skladBindingSource.DataSource = this.db_uchetkaaccdbDataSet;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "All";
            this.dataGridViewTextBoxColumn7.HeaderText = "Общая стоимость";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dbuchetkaaccdbDataSetBindingSource
            // 
            this.dbuchetkaaccdbDataSetBindingSource.DataSource = this.db_uchetkaaccdbDataSet;
            this.dbuchetkaaccdbDataSetBindingSource.Position = 0;
            // 
            // kontraagetsTableAdapter
            // 
            this.kontraagetsTableAdapter.ClearBeforeFill = true;
            // 
            // agreementsTableAdapter
            // 
            this.agreementsTableAdapter.ClearBeforeFill = true;
            // 
            // skladTableAdapter
            // 
            this.skladTableAdapter.ClearBeforeFill = true;
            // 
            // journalttn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 345);
            this.Controls.Add(this.otg_ttnDataGridView);
            this.Controls.Add(this.otg_ttnBindingNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "journalttn";
            this.Text = "journalttn";
            this.Load += new System.EventHandler(this.journalttn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.db_uchetkaaccdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.otg_ttnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.otg_ttnBindingNavigator)).EndInit();
            this.otg_ttnBindingNavigator.ResumeLayout(false);
            this.otg_ttnBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.otg_ttnDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kontraagetsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agreementsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skladBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbuchetkaaccdbDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private db_uchetkaaccdbDataSet db_uchetkaaccdbDataSet;
        private System.Windows.Forms.BindingSource otg_ttnBindingSource;
        private db_uchetkaaccdbDataSetTableAdapters.otg_ttnTableAdapter otg_ttnTableAdapter;
        private db_uchetkaaccdbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator otg_ttnBindingNavigator;
        private System.Windows.Forms.DataGridView otg_ttnDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource dbuchetkaaccdbDataSetBindingSource;
        private System.Windows.Forms.BindingSource kontraagetsBindingSource;
        private db_uchetkaaccdbDataSetTableAdapters.kontraagetsTableAdapter kontraagetsTableAdapter;
        private System.Windows.Forms.BindingSource agreementsBindingSource;
        private db_uchetkaaccdbDataSetTableAdapters.agreementsTableAdapter agreementsTableAdapter;
        private System.Windows.Forms.BindingSource skladBindingSource;
        private db_uchetkaaccdbDataSetTableAdapters.skladTableAdapter skladTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}