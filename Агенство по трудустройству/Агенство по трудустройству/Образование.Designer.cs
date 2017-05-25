namespace Агенство_по_трудустройству
{
    partial class Образование
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Образование));
            this.деденко_курсачDataSet = new Агенство_по_трудустройству.Деденко_курсачDataSet();
            this.образованияBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.образованияTableAdapter = new Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.ОбразованияTableAdapter();
            this.tableAdapterManager = new Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.TableAdapterManager();
            this.образованияBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.образованияBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.образованияDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.деденко_курсачDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.образованияBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.образованияBindingNavigator)).BeginInit();
            this.образованияBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.образованияDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // деденко_курсачDataSet
            // 
            this.деденко_курсачDataSet.DataSetName = "Деденко_курсачDataSet";
            this.деденко_курсачDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = Агенство_по_трудустройству.Деденко_курсачDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.ДолжностиTableAdapter = null;
            this.tableAdapterManager.ЗаявкиTableAdapter = null;
            this.tableAdapterManager.ОбразованияTableAdapter = this.образованияTableAdapter;
            this.tableAdapterManager.ПоискTableAdapter = null;
            this.tableAdapterManager.ПредприятияTableAdapter = null;
            this.tableAdapterManager.ПретендентыTableAdapter = null;
            this.tableAdapterManager.СферыTableAdapter = null;
            this.tableAdapterManager.ТрудоустройствоTableAdapter = null;
            // 
            // образованияBindingNavigator
            // 
            this.образованияBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.образованияBindingNavigator.BindingSource = this.образованияBindingSource;
            this.образованияBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.образованияBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.образованияBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.образованияBindingNavigatorSaveItem});
            this.образованияBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.образованияBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.образованияBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.образованияBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.образованияBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.образованияBindingNavigator.Name = "образованияBindingNavigator";
            this.образованияBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.образованияBindingNavigator.Size = new System.Drawing.Size(593, 25);
            this.образованияBindingNavigator.TabIndex = 0;
            this.образованияBindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 15);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
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
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // образованияBindingNavigatorSaveItem
            // 
            this.образованияBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.образованияBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("образованияBindingNavigatorSaveItem.Image")));
            this.образованияBindingNavigatorSaveItem.Name = "образованияBindingNavigatorSaveItem";
            this.образованияBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 23);
            this.образованияBindingNavigatorSaveItem.Text = "Сохранить данные";
            this.образованияBindingNavigatorSaveItem.Click += new System.EventHandler(this.образованияBindingNavigatorSaveItem_Click);
            // 
            // образованияDataGridView
            // 
            this.образованияDataGridView.AutoGenerateColumns = false;
            this.образованияDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.образованияDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.образованияDataGridView.DataSource = this.образованияBindingSource;
            this.образованияDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.образованияDataGridView.Location = new System.Drawing.Point(0, 25);
            this.образованияDataGridView.Name = "образованияDataGridView";
            this.образованияDataGridView.Size = new System.Drawing.Size(593, 292);
            this.образованияDataGridView.TabIndex = 1;
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
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Образование";
            this.dataGridViewTextBoxColumn2.HeaderText = "Образование";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 450;
            // 
            // Образование
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 317);
            this.Controls.Add(this.образованияDataGridView);
            this.Controls.Add(this.образованияBindingNavigator);
            this.MaximizeBox = false;
            this.Name = "Образование";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Образование";
            this.Load += new System.EventHandler(this.Образование_Load);
            ((System.ComponentModel.ISupportInitialize)(this.деденко_курсачDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.образованияBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.образованияBindingNavigator)).EndInit();
            this.образованияBindingNavigator.ResumeLayout(false);
            this.образованияBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.образованияDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Деденко_курсачDataSet деденко_курсачDataSet;
        private System.Windows.Forms.BindingSource образованияBindingSource;
        private Деденко_курсачDataSetTableAdapters.ОбразованияTableAdapter образованияTableAdapter;
        private Деденко_курсачDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator образованияBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton образованияBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView образованияDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}