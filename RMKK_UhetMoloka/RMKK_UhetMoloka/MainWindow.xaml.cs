using System;
using System.Windows;
using System.Windows.Data;
using System.Data.OleDb;
using Microsoft.Win32;
using Word = Microsoft.Office.Interop.Word;

namespace RMKK_UhetMoloka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            RMKK_UhetMoloka.RMKK_TTNDataSet1 rMKK_TTNDataSet1 = ((RMKK_UhetMoloka.RMKK_TTNDataSet1)(this.FindResource("rMKK_TTNDataSet1")));
            // Загрузить данные в таблицу Отгрузка_молока. Можно изменить этот код как требуется.
            RMKK_UhetMoloka.RMKK_TTNDataSetTableAdapters.Отгрузка_молокаTableAdapter rMKK_TTNDataSetОтгрузка_молокаTableAdapter = new RMKK_UhetMoloka.RMKK_TTNDataSetTableAdapters.Отгрузка_молокаTableAdapter();
            rMKK_TTNDataSetОтгрузка_молокаTableAdapter.Fill(rMKK_TTNDataSet1.Отгрузка_молока);
            CollectionViewSource отгрузка_молокаViewSource = ((CollectionViewSource)(this.FindResource("отгрузка_молокаViewSource")));
            отгрузка_молокаViewSource.View.MoveCurrentToFirst();
            отгрузка_молокаDataGrid.IsReadOnly = true;
            this.ResizeMode = ResizeMode.CanMinimize;
        }

        private void export_d(string stubToReplace, string text, Word.Document wordDос)
        {
            var r = wordDос.Content;
            r.Find.ClearFormatting();
            r.Find.Execute(FindText: stubToReplace, ReplaceWith: text);

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            SaveFileDialog saveD = new SaveFileDialog();
            saveD.Filter = "Файл MS Word 2007-2013 (*.docx)|*.docx";
            if (saveD.ShowDialog() != Convert.ToBoolean(System.Windows.Forms.DialogResult.OK))
            {
                try
                {
                    var wordApp = new Word.Application();
                    wordApp.Visible = false;
                    var wordDoc = wordApp.Documents.Open(AppDomain.CurrentDomain.BaseDirectory + @".\Report\Шаблон.docx");
                    System.Data.DataRowView rowView = отгрузка_молокаDataGrid.SelectedValue as System.Data.DataRowView;
                    export_d("{TTN}", rowView[0].ToString(), wordDoc);
                    export_d("{DATE}", rowView[8].ToString().Remove(10), wordDoc);
                    export_d("{Post}", rowView[1].ToString(), wordDoc);
                    export_d("{ot}", rowView[4].ToString(), wordDoc);
                    export_d("{p1}", rowView[5].ToString(), wordDoc);
                    export_d("{vod}", rowView[2].ToString(), wordDoc);
                    export_d("{reg}", rowView[3].ToString(), wordDoc);
                    export_d("{pr}", rowView[7].ToString(), wordDoc);
                    export_d("{p2}", rowView[6].ToString(), wordDoc);
                    export_d("{zen}", rowView[9].ToString(), wordDoc);
                    export_d("{kol}", rowView[10].ToString(), wordDoc);
                    export_d("{vsego}", rowView[11].ToString(), wordDoc);

                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source='|DataDirectory|\RMKK_TTN.accdb';OLE DB Services=-1";
                    OleDbConnection connection = new OleDbConnection(connectionString);
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT Банк.Наименование, Организации.[Основной РС], Марка, Модель FROM Банк, Организации, Автомобили WHERE Банк.Код=Организации.[Код обслуживающего банка] AND  [Наименование организации]='" + rowView[1].ToString() + "' AND Автомобили.[Регистрациионный номер]='" + rowView[3].ToString() + "';";
                    connection.Open();
                OleDbDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        export_d("{mar}", dr["Марка"].ToString() +" "+ dr["Модель"].ToString(), wordDoc);
                        export_d("{rs}", dr["Основной РС"].ToString(), wordDoc);
                        export_d("{bank}", dr["Наименование"].ToString(), wordDoc);
                    }
                }
                connection.Close();

                    wordDoc.SaveAs2(saveD.FileName);
                    wordApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("При экспортировании в файл MS Word произошла ошибка. Содержимое ошибки: " + Environment.NewLine + ex.ToString(), "Ошибка экспорта");
                }
            }

        }

        private void MenuItem_Click_banks(object sender, RoutedEventArgs e)
        {
            Banks banks = new  Banks();
            banks.Show();
        }

        private void MenuItem_Click_org(object sender, RoutedEventArgs e)
        {
            Organisation org = new Organisation();
            org.Show();
        }

        private void MenuItem_Click_sotr(object sender, RoutedEventArgs e)
        {
            Sotrudniki sotr = new Sotrudniki();
            sotr.Show();
        }

        private void MenuItem_Click_auto(object sender, RoutedEventArgs e)
        {
            Auto auto = new Auto();
            auto.Show();
        }

        private void MenuItem_Click_about(object sender, RoutedEventArgs e)
        {
            About n = new About();
            n.Show();
        }

        private void Button_Click_delete(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBoxButton buttons = System.Windows.MessageBoxButton.YesNo;
            MessageBoxResult result;
            System.Data.DataRowView rowView = отгрузка_молокаDataGrid.SelectedValue as System.Data.DataRowView;
            if (rowView != null)
            {
            result = MessageBox.Show("Удалить выбраную запись?", "Удаление записи", buttons);

            if (result == MessageBoxResult.Yes)
            {
                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source='|DataDirectory|\RMKK_TTN.accdb';OLE DB Services=-1";
                    OleDbConnection connection = new OleDbConnection(connectionString);
                    OleDbCommand command = new OleDbCommand();
                    command.CommandText = "DELETE FROM [Отгрузка молока] WHERE [Отгрузка молока].[Код ТТН]=" + rowView[0].ToString() + ";";
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    System.Threading.Thread.Sleep(500);
                    Window_Loaded(sender, e);
            }

            }
            else
            { MessageBox.Show("Не выбрана или отсутвует удаляемая запись!", "Ошибка удаления!"); }
        }

        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
            add_edit n = new add_edit();
            n.Title = "Добавить запись о приходе молока";
            n.Show();

            n.cancel_button.Click += (sender1, e1) =>
            {
                n.Close();
            };

            n.save_button.Click += (sender2, e2) =>
                {
                      try
                    {

                      DateTime d = new System.DateTime();  
                      int stoim =  Convert.ToInt32(n.tb_z.Text) * Convert.ToInt32(n.tb_kol.Text); RMKK_TTNDataSetTableAdapters.Отгрузка_молокаTableAdapter otg = new RMKK_TTNDataSetTableAdapters.Отгрузка_молокаTableAdapter();
                     d = DateTime.Parse(n.tb_data.Text);
                    otg.Insert(Convert.ToInt32(n.tb_kod.Text), n.tb_post.Text, n.tb_vod.Text, n.tb_av.Text, n.tb_ot.Text, n.tb_p1.Text, n.tb_p2.Text, n.tb_pr.Text, d, Convert.ToInt32(n.tb_z.Text), Convert.ToInt32(n.tb_kol.Text), stoim);
      
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка ввода. Проверте правильность введенных данных.", "Ошибка ввода");
                    }
                    finally
                    {
                        Window_Loaded(sender, e);
                        n.Close();
                    }
                };
        }

        private void Button_Click_edit(object sender, RoutedEventArgs e)
        {
            System.Data.DataRowView rowView = отгрузка_молокаDataGrid.SelectedValue as System.Data.DataRowView;
            if (rowView != null)
            {
                add_edit n = new add_edit();
                n.Title = "Изменить запись о приходе молока";
                n.tb_kod.IsReadOnly = true;
                n.tb_kod.Text = rowView[0].ToString();
                n.tb_post.Text = rowView[1].ToString();
                n.tb_vod.Text = rowView[2].ToString();
                n.tb_av.Text = rowView[3].ToString();
                n.tb_ot.Text = rowView[4].ToString();
                n.tb_p1.Text = rowView[5].ToString();
                n.tb_p2.Text = rowView[6].ToString();
                n.tb_pr.Text = rowView[7].ToString();
                n.tb_data.Text = rowView[8].ToString();
                n.tb_z.Text = rowView[9].ToString();
                n.tb_kol.Text = rowView[10].ToString();
                n.Show();

                n.save_button.Click += (sender2, e2) =>
                    {
                        System.Windows.MessageBoxButton buttons = System.Windows.MessageBoxButton.YesNo;
                        MessageBoxResult result;
                        result = MessageBox.Show("Применить внесенные изменения?", "Изменение записи", buttons);
                        if (result == MessageBoxResult.Yes)
                        {
                            try
                            {
                                string s = n.tb_data.Text;
                                int x = Convert.ToInt32(n.tb_kol.Text) * Convert.ToInt32(n.tb_z.Text);
                                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source='|DataDirectory|\RMKK_TTN.accdb';OLE DB Services=-1";
                                OleDbConnection connection = new OleDbConnection(connectionString);
                                OleDbCommand command = new OleDbCommand();
                                command.CommandText = "UPDATE [Отгрузка молока] SET Поставщик ='" + n.tb_post.Text + "', Водитель ='" + n.tb_vod.Text + "', Автомобиль ='" + n.tb_av.Text + "', [Отпуск произвел] ='" + n.tb_ot.Text + "', [Пункт погрузки] ='" + n.tb_p1.Text + "', [Пункт разгрузки] ='" + n.tb_p2.Text + "', [Товар принял] = '" + n.tb_pr.Text + "', Дата =#" + s.Replace(".", "/") + "#, Цена ='" + n.tb_z.Text + "', [Количество продукции] = '" + n.tb_kol.Text + "', Всего ='" + x.ToString() + "'  WHERE [Отгрузка молока].[Код ТТН]=" + rowView[0].ToString() + ";";
                                command.Connection = connection;
                                connection.Open();
                                command.ExecuteNonQuery();
                                connection.Close();
                                System.Threading.Thread.Sleep(500);
                                Window_Loaded(sender, e);
                            }
                            catch
                            {
                                MessageBox.Show("В ходе изменения возникла ошибка!", "Ошибка изменения");
                            }
                        }

                    };

                n.cancel_button.Click += (sender1, e1) =>
                {
                    n.Close();
                };
            }
            else
            {
                MessageBox.Show("Не выбрана или отсутвует изменения запись!", "Ошибка изменения!");
            }
        }

       
        
    }
}
