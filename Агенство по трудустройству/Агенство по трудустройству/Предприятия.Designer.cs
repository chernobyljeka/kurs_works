namespace Агенство_по_трудустройству
{
    partial class Предприятия
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Предприятия));
            this.деденко_курсачDataSet = new Агенство_по_трудустройству.Деденко_курсачDataSet();
            this.предприятияBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.предприятияTableAdapter = new Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.ПредприятияTableAdapter();
            this.tableAdapterManager = new Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.TableAdapterManager();
            this.предприятияBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.предприятияDataGridView = new System.Windows.Forms.DataGridView();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.предприятияBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.деденко_курсачDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.предприятияBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.предприятияBindingNavigator)).BeginInit();
            this.предприятияBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.предприятияDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // деденко_курсачDataSet
            // 
            this.деденко_курсачDataSet.DataSetName = "Деденко_курсачDataSet";
            this.деденко_курсачDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // предприятияBindingSource
            // 
            this.предприятияBindingSource.DataMember = "Предприятия";
            this.предприятияBindingSource.DataSource = this.деденко_курсачDataSet;
            // 
            // предприятияTableAdapter
            // 
            this.предприятияTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.ДолжностиTableAdapter = null;
            this.tableAdapterManager.ЗаявкиTableAdapter = null;
            this.tableAdapterManager.ОбразованияTableAdapter = null;
            this.tableAdapterManager.ПоискTableAdapter = null;
            this.tableAdapterManager.ПредприятияTableAdapter = this.предприятияTableAdapter;
            this.tableAdapterManager.ПретендентыTableAdapter = null;
            this.tableAdapterManager.СферыTableAdapter = null;
            this.tableAdapterManager.ТрудоустройствоTableAdapter = null;
            // 
            // предприятияBindingNavigator
            // 
            this.предприятияBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.предприятияBindingNavigator.BindingSource = this.предприятияBindingSource;
            this.предприятияBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.предприятияBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.предприятияBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.предприятияBindingNavigatorSaveItem});
            this.предприятияBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.предприятияBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.предприятияBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.предприятияBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.предприятияBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.предприятияBindingNavigator.Name = "предприятияBindingNavigator";
            this.предприятияBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.предприятияBindingNavigator.Size = new System.Drawing.Size(593, 25);
            this.предприятияBindingNavigator.TabIndex = 0;
            this.предприятияBindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 22);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // предприятияDataGridView
            // 
            this.предприятияDataGridView.AutoGenerateColumns = false;
            this.предприятияDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.предприятияDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.предприятияDataGridView.DataSource = this.предприятияBindingSource;
            this.предприятияDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.предприятияDataGridView.Location = new System.Drawing.Point(0, 25);
            this.предприятияDataGridView.Name = "предприятияDataGridView";
            this.предприятияDataGridView.Size = new System.Drawing.Size(593, 292);
            this.предприятияDataGridView.TabIndex = 1;
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
            // предприятияBindingNavigatorSaveItem
            // 
            this.предприятияBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.предприятияBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("предприятияBindingNavigatorSaveItem.Image")));
            this.предприятияBindingNavigatorSaveItem.Name = "предприятияBindingNavigatorSaveItem";
            this.предприятияBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.предприятияBindingNavigatorSaveItem.Text = "Сохранить данные";
            this.предприятияBindingNavigatorSaveItem.Click += new System.EventHandler(this.предприятияBindingNavigatorSaveItem_Click);
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
            this.dataGridViewTextBoxColumn2.HeaderText = "Предприятие";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 450;
            // 
            // Предприятия
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 317);
            this.Controls.Add(this.предприятияDataGridView);
            this.Controls.Add(this.предприятияBindingNavigator);
            this.Name = "Предприятия";
            this.Text = "Предприятия";
            this.Load += new System.EventHandler(this.Предприятия_Load);
            ((System.ComponentModel.ISupportInitialize)(this.деденко_курсачDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.предприятияBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.предприятияBindingNavigator)).EndInit();
            this.предприятияBindingNavigator.ResumeLayout(false);
            this.предприятияBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.предприятияDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Деденко_курсачDataSet деденко_курсачDataSet;
        private System.Windows.Forms.BindingSource предприятияBindingSource;
        private Деденко_курсачDataSetTableAdapters.ПредприятияTableAdapter предприятияTableAdapter;
        private Деденко_курсачDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator предприятияBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton предприятияBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView предприятияDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}