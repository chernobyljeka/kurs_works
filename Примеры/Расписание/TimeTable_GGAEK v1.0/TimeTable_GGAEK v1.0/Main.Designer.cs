namespace TimeTable_GGAEK_v1._0
{
    partial class Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.занятиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.базаДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.группуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.преподавателяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дисциплинуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.группуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.преподавателяToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.дисциплинуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timetableGGAEKDataSet = new TimeTable_GGAEK_v1._0.TimetableGGAEKDataSet();
            this.расписаниеBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.расписаниеTableAdapter = new TimeTable_GGAEK_v1._0.TimetableGGAEKDataSetTableAdapters.РасписаниеTableAdapter();
            this.tableAdapterManager = new TimeTable_GGAEK_v1._0.TimetableGGAEKDataSetTableAdapters.TableAdapterManager();
            this.расписаниеDataGridView = new System.Windows.Forms.DataGridView();
            this.поДисциплинеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timetableGGAEKDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.расписаниеBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.расписаниеDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.занятиеToolStripMenuItem,
            this.базаДанныхToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(914, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // занятиеToolStripMenuItem
            // 
            this.занятиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.занятиеToolStripMenuItem.Name = "занятиеToolStripMenuItem";
            this.занятиеToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.занятиеToolStripMenuItem.Text = "Занятия";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // базаДанныхToolStripMenuItem
            // 
            this.базаДанныхToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem1,
            this.удалитьToolStripMenuItem1,
            this.сохранитьБДToolStripMenuItem});
            this.базаДанныхToolStripMenuItem.Name = "базаДанныхToolStripMenuItem";
            this.базаДанныхToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.базаДанныхToolStripMenuItem.Text = "База данных";
            // 
            // добавитьToolStripMenuItem1
            // 
            this.добавитьToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.группуToolStripMenuItem,
            this.преподавателяToolStripMenuItem,
            this.дисциплинуToolStripMenuItem});
            this.добавитьToolStripMenuItem1.Name = "добавитьToolStripMenuItem1";
            this.добавитьToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.добавитьToolStripMenuItem1.Text = "Добавить";
            // 
            // группуToolStripMenuItem
            // 
            this.группуToolStripMenuItem.Name = "группуToolStripMenuItem";
            this.группуToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.группуToolStripMenuItem.Text = "Группу";
            this.группуToolStripMenuItem.Click += new System.EventHandler(this.группуToolStripMenuItem_Click);
            // 
            // преподавателяToolStripMenuItem
            // 
            this.преподавателяToolStripMenuItem.Name = "преподавателяToolStripMenuItem";
            this.преподавателяToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.преподавателяToolStripMenuItem.Text = "Преподавателя";
            this.преподавателяToolStripMenuItem.Click += new System.EventHandler(this.преподавателяToolStripMenuItem_Click);
            // 
            // дисциплинуToolStripMenuItem
            // 
            this.дисциплинуToolStripMenuItem.Name = "дисциплинуToolStripMenuItem";
            this.дисциплинуToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.дисциплинуToolStripMenuItem.Text = "Дисциплину";
            this.дисциплинуToolStripMenuItem.Click += new System.EventHandler(this.дисциплинуToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem1
            // 
            this.удалитьToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.группуToolStripMenuItem1,
            this.преподавателяToolStripMenuItem1,
            this.дисциплинуToolStripMenuItem1});
            this.удалитьToolStripMenuItem1.Name = "удалитьToolStripMenuItem1";
            this.удалитьToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.удалитьToolStripMenuItem1.Text = "Удалить";
            // 
            // группуToolStripMenuItem1
            // 
            this.группуToolStripMenuItem1.Name = "группуToolStripMenuItem1";
            this.группуToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.группуToolStripMenuItem1.Text = "Группу";
            this.группуToolStripMenuItem1.Click += new System.EventHandler(this.группуToolStripMenuItem1_Click);
            // 
            // преподавателяToolStripMenuItem1
            // 
            this.преподавателяToolStripMenuItem1.Name = "преподавателяToolStripMenuItem1";
            this.преподавателяToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.преподавателяToolStripMenuItem1.Text = "Преподавателя";
            this.преподавателяToolStripMenuItem1.Click += new System.EventHandler(this.преподавателяToolStripMenuItem1_Click);
            // 
            // дисциплинуToolStripMenuItem1
            // 
            this.дисциплинуToolStripMenuItem1.Name = "дисциплинуToolStripMenuItem1";
            this.дисциплинуToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.дисциплинуToolStripMenuItem1.Text = "Дисциплину";
            this.дисциплинуToolStripMenuItem1.Click += new System.EventHandler(this.дисциплинуToolStripMenuItem1_Click);
            // 
            // сохранитьБДToolStripMenuItem
            // 
            this.сохранитьБДToolStripMenuItem.Name = "сохранитьБДToolStripMenuItem";
            this.сохранитьБДToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.сохранитьБДToolStripMenuItem.Text = "Сохранить БД";
            this.сохранитьБДToolStripMenuItem.Click += new System.EventHandler(this.сохранитьБДToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поДисциплинеToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // timetableGGAEKDataSet
            // 
            this.timetableGGAEKDataSet.DataSetName = "TimetableGGAEKDataSet";
            this.timetableGGAEKDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // расписаниеBindingSource
            // 
            this.расписаниеBindingSource.DataMember = "Расписание";
            this.расписаниеBindingSource.DataSource = this.timetableGGAEKDataSet;
            // 
            // расписаниеTableAdapter
            // 
            this.расписаниеTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = TimeTable_GGAEK_v1._0.TimetableGGAEKDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.ГруппыTableAdapter = null;
            this.tableAdapterManager.ДисциплинаTableAdapter = null;
            this.tableAdapterManager.ПреподавательTableAdapter = null;
            this.tableAdapterManager.РасписаниеTableAdapter = this.расписаниеTableAdapter;
            // 
            // расписаниеDataGridView
            // 
            this.расписаниеDataGridView.AllowUserToAddRows = false;
            this.расписаниеDataGridView.AllowUserToDeleteRows = false;
            this.расписаниеDataGridView.AutoGenerateColumns = false;
            this.расписаниеDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.расписаниеDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.расписаниеDataGridView.DataSource = this.расписаниеBindingSource;
            this.расписаниеDataGridView.Location = new System.Drawing.Point(0, 27);
            this.расписаниеDataGridView.Name = "расписаниеDataGridView";
            this.расписаниеDataGridView.ReadOnly = true;
            this.расписаниеDataGridView.Size = new System.Drawing.Size(913, 448);
            this.расписаниеDataGridView.TabIndex = 2;
            // 
            // поДисциплинеToolStripMenuItem
            // 
            this.поДисциплинеToolStripMenuItem.Name = "поДисциплинеToolStripMenuItem";
            this.поДисциплинеToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.поДисциплинеToolStripMenuItem.Text = "По дисциплине";
            this.поДисциплинеToolStripMenuItem.Click += new System.EventHandler(this.поДисциплинеToolStripMenuItem_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Группа";
            this.dataGridViewTextBoxColumn1.HeaderText = "Группа";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Дисциплина";
            this.dataGridViewTextBoxColumn2.HeaderText = "Дисциплина";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Преподаватель";
            this.dataGridViewTextBoxColumn3.HeaderText = "Преподаватель";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Вид_занятия";
            this.dataGridViewTextBoxColumn4.HeaderText = "Вид_занятия";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 130;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Подгруппа";
            this.dataGridViewTextBoxColumn5.HeaderText = "Подгруппа";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Количество_часов";
            this.dataGridViewTextBoxColumn6.HeaderText = "Количество_часов";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Дата";
            this.dataGridViewTextBoxColumn7.HeaderText = "Дата";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Кабинет";
            this.dataGridViewTextBoxColumn8.HeaderText = "Кабинет";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 476);
            this.Controls.Add(this.расписаниеDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расписание ГГАЭК";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timetableGGAEKDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.расписаниеBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.расписаниеDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem занятиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem базаДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem группуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem преподавателяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дисциплинуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem группуToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem преподавателяToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem дисциплинуToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьБДToolStripMenuItem;
        private TimetableGGAEKDataSet timetableGGAEKDataSet;
        private System.Windows.Forms.BindingSource расписаниеBindingSource;
        private TimetableGGAEKDataSetTableAdapters.РасписаниеTableAdapter расписаниеTableAdapter;
        private TimetableGGAEKDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView расписаниеDataGridView;
        private System.Windows.Forms.ToolStripMenuItem поДисциплинеToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}

