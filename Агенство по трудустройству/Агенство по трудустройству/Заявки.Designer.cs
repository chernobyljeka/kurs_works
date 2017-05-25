namespace Агенство_по_трудустройству
{
    partial class Заявки
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Заявки));
            this.деденко_курсачDataSet = new Агенство_по_трудустройству.Деденко_курсачDataSet();
            this.заявкиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.заявкиTableAdapter = new Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.ЗаявкиTableAdapter();
            this.tableAdapterManager = new Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.TableAdapterManager();
            this.должностиTableAdapter = new Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.ДолжностиTableAdapter();
            this.образованияTableAdapter = new Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.ОбразованияTableAdapter();
            this.предприятияTableAdapter = new Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.ПредприятияTableAdapter();
            this.сферыTableAdapter = new Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.СферыTableAdapter();
            this.заявкиBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.заявкиBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.заявкиDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.предприятияBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.сферыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.должностиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.образованияBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.претендентыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.претендентыTableAdapter = new Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.ПретендентыTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.деденко_курсачDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.заявкиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.заявкиBindingNavigator)).BeginInit();
            this.заявкиBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.заявкиDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.предприятияBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.сферыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.должностиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.образованияBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.претендентыBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // деденко_курсачDataSet
            // 
            this.деденко_курсачDataSet.DataSetName = "Деденко_курсачDataSet";
            this.деденко_курсачDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // заявкиBindingSource
            // 
            this.заявкиBindingSource.DataMember = "Заявки";
            this.заявкиBindingSource.DataSource = this.деденко_курсачDataSet;
            // 
            // заявкиTableAdapter
            // 
            this.заявкиTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.ДолжностиTableAdapter = this.должностиTableAdapter;
            this.tableAdapterManager.ЗаявкиTableAdapter = this.заявкиTableAdapter;
            this.tableAdapterManager.ОбразованияTableAdapter = this.образованияTableAdapter;
            this.tableAdapterManager.ПоискTableAdapter = null;
            this.tableAdapterManager.ПредприятияTableAdapter = this.предприятияTableAdapter;
            this.tableAdapterManager.ПретендентыTableAdapter = null;
            this.tableAdapterManager.СферыTableAdapter = this.сферыTableAdapter;
            this.tableAdapterManager.ТрудоустройствоTableAdapter = null;
            // 
            // должностиTableAdapter
            // 
            this.должностиTableAdapter.ClearBeforeFill = true;
            // 
            // образованияTableAdapter
            // 
            this.образованияTableAdapter.ClearBeforeFill = true;
            // 
            // предприятияTableAdapter
            // 
            this.предприятияTableAdapter.ClearBeforeFill = true;
            // 
            // сферыTableAdapter
            // 
            this.сферыTableAdapter.ClearBeforeFill = true;
            // 
            // заявкиBindingNavigator
            // 
            this.заявкиBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.заявкиBindingNavigator.BindingSource = this.заявкиBindingSource;
            this.заявкиBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.заявкиBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.заявкиBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.заявкиBindingNavigatorSaveItem});
            this.заявкиBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.заявкиBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.заявкиBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.заявкиBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.заявкиBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.заявкиBindingNavigator.Name = "заявкиBindingNavigator";
            this.заявкиBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.заявкиBindingNavigator.Size = new System.Drawing.Size(984, 25);
            this.заявкиBindingNavigator.TabIndex = 0;
            this.заявкиBindingNavigator.Text = "bindingNavigator1";
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
            // заявкиBindingNavigatorSaveItem
            // 
            this.заявкиBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.заявкиBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("заявкиBindingNavigatorSaveItem.Image")));
            this.заявкиBindingNavigatorSaveItem.Name = "заявкиBindingNavigatorSaveItem";
            this.заявкиBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.заявкиBindingNavigatorSaveItem.Text = "Сохранить данные";
            this.заявкиBindingNavigatorSaveItem.Click += new System.EventHandler(this.заявкиBindingNavigatorSaveItem_Click_1);
            // 
            // заявкиDataGridView
            // 
            this.заявкиDataGridView.AutoGenerateColumns = false;
            this.заявкиDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.заявкиDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.заявкиDataGridView.DataSource = this.заявкиBindingSource;
            this.заявкиDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.заявкиDataGridView.Location = new System.Drawing.Point(0, 25);
            this.заявкиDataGridView.Name = "заявкиDataGridView";
            this.заявкиDataGridView.Size = new System.Drawing.Size(984, 636);
            this.заявкиDataGridView.TabIndex = 1;
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
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Предприятие";
            this.dataGridViewTextBoxColumn2.DataSource = this.предприятияBindingSource;
            this.dataGridViewTextBoxColumn2.DisplayMember = "Предприятие";
            this.dataGridViewTextBoxColumn2.HeaderText = "Предприятие";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn2.ValueMember = "ID";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // предприятияBindingSource
            // 
            this.предприятияBindingSource.DataMember = "Предприятия";
            this.предприятияBindingSource.DataSource = this.деденко_курсачDataSet;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Сфера";
            this.dataGridViewTextBoxColumn3.DataSource = this.сферыBindingSource;
            this.dataGridViewTextBoxColumn3.DisplayMember = "Сфера";
            this.dataGridViewTextBoxColumn3.HeaderText = "Сфера";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.ValueMember = "ID";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // сферыBindingSource
            // 
            this.сферыBindingSource.DataMember = "Сферы";
            this.сферыBindingSource.DataSource = this.деденко_курсачDataSet;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Должность";
            this.dataGridViewTextBoxColumn4.DataSource = this.должностиBindingSource;
            this.dataGridViewTextBoxColumn4.DisplayMember = "Должности";
            this.dataGridViewTextBoxColumn4.HeaderText = "Должность";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn4.ValueMember = "ID";
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // должностиBindingSource
            // 
            this.должностиBindingSource.DataMember = "Должности";
            this.должностиBindingSource.DataSource = this.деденко_курсачDataSet;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Образование";
            this.dataGridViewTextBoxColumn5.DataSource = this.образованияBindingSource;
            this.dataGridViewTextBoxColumn5.DisplayMember = "Образование";
            this.dataGridViewTextBoxColumn5.HeaderText = "Образование";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn5.ValueMember = "ID";
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // образованияBindingSource
            // 
            this.образованияBindingSource.DataMember = "Образования";
            this.образованияBindingSource.DataSource = this.деденко_курсачDataSet;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ЗП";
            this.dataGridViewTextBoxColumn6.HeaderText = "ЗП";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Стаж";
            this.dataGridViewTextBoxColumn7.HeaderText = "Стаж";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 200;
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
            // Заявки
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.заявкиDataGridView);
            this.Controls.Add(this.заявкиBindingNavigator);
            this.Name = "Заявки";
            this.Text = "Заявки";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Заявки_Load);
            ((System.ComponentModel.ISupportInitialize)(this.деденко_курсачDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.заявкиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.заявкиBindingNavigator)).EndInit();
            this.заявкиBindingNavigator.ResumeLayout(false);
            this.заявкиBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.заявкиDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.предприятияBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.сферыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.должностиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.образованияBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.претендентыBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Деденко_курсачDataSet деденко_курсачDataSet;
        private System.Windows.Forms.BindingSource заявкиBindingSource;
        private Деденко_курсачDataSetTableAdapters.ЗаявкиTableAdapter заявкиTableAdapter;
        private Деденко_курсачDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator заявкиBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton заявкиBindingNavigatorSaveItem;
        private Деденко_курсачDataSetTableAdapters.ПредприятияTableAdapter предприятияTableAdapter;
        private System.Windows.Forms.DataGridView заявкиDataGridView;
        private System.Windows.Forms.BindingSource предприятияBindingSource;
        private Деденко_курсачDataSetTableAdapters.СферыTableAdapter сферыTableAdapter;
        private System.Windows.Forms.BindingSource сферыBindingSource;
        private Деденко_курсачDataSetTableAdapters.ДолжностиTableAdapter должностиTableAdapter;
        private System.Windows.Forms.BindingSource должностиBindingSource;
        private Деденко_курсачDataSetTableAdapters.ОбразованияTableAdapter образованияTableAdapter;
        private System.Windows.Forms.BindingSource образованияBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.BindingSource претендентыBindingSource;
        private Деденко_курсачDataSetTableAdapters.ПретендентыTableAdapter претендентыTableAdapter;
    }
}