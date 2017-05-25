namespace Агенство_по_трудустройству
{
    partial class Претенденты
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Претенденты));
            this.деденко_курсачDataSet = new Агенство_по_трудустройству.Деденко_курсачDataSet();
            this.должностиTableAdapter = new Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.ДолжностиTableAdapter();
            this.претендентыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.претендентыTableAdapter = new Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.ПретендентыTableAdapter();
            this.tableAdapterManager = new Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.TableAdapterManager();
            this.претендентыBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.претендентыBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.претендентыDataGridView = new System.Windows.Forms.DataGridView();
            this.образованияBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.образованияTableAdapter = new Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.ОбразованияTableAdapter();
            this.сферыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.сферыTableAdapter = new Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.СферыTableAdapter();
            this.должностиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.деденко_курсачDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.претендентыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.претендентыBindingNavigator)).BeginInit();
            this.претендентыBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.претендентыDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.образованияBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.сферыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.должностиBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // деденко_курсачDataSet
            // 
            this.деденко_курсачDataSet.DataSetName = "Деденко_курсачDataSet";
            this.деденко_курсачDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // должностиTableAdapter
            // 
            this.должностиTableAdapter.ClearBeforeFill = true;
            // 
            // претендентыBindingSource
            // 
            this.претендентыBindingSource.DataMember = "Претенденты";
            this.претендентыBindingSource.DataSource = this.деденко_курсачDataSet;
            // 
            // претендентыTableAdapter
            // 
            this.претендентыTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.ДолжностиTableAdapter = this.должностиTableAdapter;
            this.tableAdapterManager.ЗаявкиTableAdapter = null;
            this.tableAdapterManager.ОбразованияTableAdapter = null;
            this.tableAdapterManager.ПоискTableAdapter = null;
            this.tableAdapterManager.ПредприятияTableAdapter = null;
            this.tableAdapterManager.ПретендентыTableAdapter = this.претендентыTableAdapter;
            this.tableAdapterManager.СферыTableAdapter = null;
            this.tableAdapterManager.ТрудоустройствоTableAdapter = null;
            // 
            // претендентыBindingNavigator
            // 
            this.претендентыBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.претендентыBindingNavigator.BindingSource = this.претендентыBindingSource;
            this.претендентыBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.претендентыBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.претендентыBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.претендентыBindingNavigatorSaveItem});
            this.претендентыBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.претендентыBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.претендентыBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.претендентыBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.претендентыBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.претендентыBindingNavigator.Name = "претендентыBindingNavigator";
            this.претендентыBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.претендентыBindingNavigator.Size = new System.Drawing.Size(984, 25);
            this.претендентыBindingNavigator.TabIndex = 0;
            this.претендентыBindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 22);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
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
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // претендентыBindingNavigatorSaveItem
            // 
            this.претендентыBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.претендентыBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("претендентыBindingNavigatorSaveItem.Image")));
            this.претендентыBindingNavigatorSaveItem.Name = "претендентыBindingNavigatorSaveItem";
            this.претендентыBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.претендентыBindingNavigatorSaveItem.Text = "Сохранить данные";
            this.претендентыBindingNavigatorSaveItem.Click += new System.EventHandler(this.претендентыBindingNavigatorSaveItem_Click_1);
            // 
            // претендентыDataGridView
            // 
            this.претендентыDataGridView.AutoGenerateColumns = false;
            this.претендентыDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.претендентыDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.претендентыDataGridView.DataSource = this.претендентыBindingSource;
            this.претендентыDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.претендентыDataGridView.Location = new System.Drawing.Point(0, 25);
            this.претендентыDataGridView.Name = "претендентыDataGridView";
            this.претендентыDataGridView.Size = new System.Drawing.Size(984, 636);
            this.претендентыDataGridView.TabIndex = 1;
            // 
            // образованияBindingSource
            // 
            this.образованияBindingSource.DataMember = "Образования";
            this.образованияBindingSource.DataSource = this.деденко_курсачDataSet;
            // 
            // образованияTableAdapter
            // 
            this.образованияTableAdapter.ClearBeforeFill = true;
            // 
            // сферыBindingSource
            // 
            this.сферыBindingSource.DataMember = "Сферы";
            this.сферыBindingSource.DataSource = this.деденко_курсачDataSet;
            // 
            // сферыTableAdapter
            // 
            this.сферыTableAdapter.ClearBeforeFill = true;
            // 
            // должностиBindingSource
            // 
            this.должностиBindingSource.DataMember = "Должности";
            this.должностиBindingSource.DataSource = this.деденко_курсачDataSet;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Фамилия";
            this.dataGridViewTextBoxColumn2.HeaderText = "Фамилия";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Имя";
            this.dataGridViewTextBoxColumn3.HeaderText = "Имя";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Отчетство";
            this.dataGridViewTextBoxColumn4.HeaderText = "Отчетство";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Адрес";
            this.dataGridViewTextBoxColumn5.HeaderText = "Адрес";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 260;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Образование";
            this.dataGridViewTextBoxColumn6.DataSource = this.образованияBindingSource;
            this.dataGridViewTextBoxColumn6.DisplayMember = "Образование";
            this.dataGridViewTextBoxColumn6.HeaderText = "Образование";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn6.ValueMember = "ID";
            this.dataGridViewTextBoxColumn6.Width = 160;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Сфера деятельноти";
            this.dataGridViewTextBoxColumn7.DataSource = this.сферыBindingSource;
            this.dataGridViewTextBoxColumn7.DisplayMember = "Сфера";
            this.dataGridViewTextBoxColumn7.HeaderText = "Сфера деятельноти";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn7.ValueMember = "ID";
            this.dataGridViewTextBoxColumn7.Width = 160;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Должность";
            this.dataGridViewTextBoxColumn8.DataSource = this.должностиBindingSource;
            this.dataGridViewTextBoxColumn8.DisplayMember = "Должности";
            this.dataGridViewTextBoxColumn8.HeaderText = "Должность";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn8.ValueMember = "ID";
            this.dataGridViewTextBoxColumn8.Width = 160;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ЗП";
            this.dataGridViewTextBoxColumn9.HeaderText = "ЗП";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Стаж";
            this.dataGridViewTextBoxColumn10.HeaderText = "Стаж";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // Претенденты
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.претендентыDataGridView);
            this.Controls.Add(this.претендентыBindingNavigator);
            this.Name = "Претенденты";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Претенденты";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Претенденты_Load);
            ((System.ComponentModel.ISupportInitialize)(this.деденко_курсачDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.претендентыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.претендентыBindingNavigator)).EndInit();
            this.претендентыBindingNavigator.ResumeLayout(false);
            this.претендентыBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.претендентыDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.образованияBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.сферыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.должностиBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Деденко_курсачDataSet деденко_курсачDataSet;
        private Деденко_курсачDataSetTableAdapters.ДолжностиTableAdapter должностиTableAdapter;
        private System.Windows.Forms.BindingSource претендентыBindingSource;
        private Деденко_курсачDataSetTableAdapters.ПретендентыTableAdapter претендентыTableAdapter;
        private Деденко_курсачDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator претендентыBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton претендентыBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView претендентыDataGridView;
        private System.Windows.Forms.BindingSource образованияBindingSource;
        private Деденко_курсачDataSetTableAdapters.ОбразованияTableAdapter образованияTableAdapter;
        private System.Windows.Forms.BindingSource сферыBindingSource;
        private Деденко_курсачDataSetTableAdapters.СферыTableAdapter сферыTableAdapter;
        private System.Windows.Forms.BindingSource должностиBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    }
}