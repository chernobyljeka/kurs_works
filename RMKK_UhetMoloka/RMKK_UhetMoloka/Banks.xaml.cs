using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RMKK_UhetMoloka
{
    /// <summary>
    /// Логика взаимодействия для Banks.xaml
    /// </summary>
    public partial class Banks : Window
    {
        public Banks()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            RMKK_UhetMoloka.RMKK_TTNDataSet rMKK_TTNDataSet = ((RMKK_UhetMoloka.RMKK_TTNDataSet)(this.FindResource("rMKK_TTNDataSet")));
            // Загрузить данные в таблицу Банк. Можно изменить этот код как требуется.
            RMKK_UhetMoloka.RMKK_TTNDataSetTableAdapters.БанкTableAdapter rMKK_TTNDataSetБанкTableAdapter = new RMKK_UhetMoloka.RMKK_TTNDataSetTableAdapters.БанкTableAdapter();
            rMKK_TTNDataSetБанкTableAdapter.Fill(rMKK_TTNDataSet.Банк);
            System.Windows.Data.CollectionViewSource банкViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("банкViewSource")));
            банкViewSource.View.MoveCurrentToFirst();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.MessageBoxButton buttons = System.Windows.MessageBoxButton.YesNo;
            MessageBoxResult result;
            result = MessageBox.Show("Сохранить изменения?", "Сохранение данных", buttons);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    RMKK_UhetMoloka.RMKK_TTNDataSet rMKK_TTNDataSet = ((RMKK_UhetMoloka.RMKK_TTNDataSet)(this.FindResource("rMKK_TTNDataSet")));

                    RMKK_UhetMoloka.RMKK_TTNDataSetTableAdapters.БанкTableAdapter rMKK_TTNDataSetБанкTableAdapter = new RMKK_UhetMoloka.RMKK_TTNDataSetTableAdapters.БанкTableAdapter();
                    rMKK_TTNDataSetБанкTableAdapter.Update(rMKK_TTNDataSet.Банк);
                    MessageBox.Show("Сохранение прошло успешно", "Сохранение");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Сохранение прошло с ошибкой", "Сохранение");
                }
            }

           
        }

        private void Button_Click_otmena(object sender, RoutedEventArgs e)
        {
            
            System.Windows.MessageBoxButton buttons = System.Windows.MessageBoxButton.YesNo;
            MessageBoxResult result;
            result = MessageBox.Show("Закрыть без изменений?", "Закрытие окна", buttons);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

      
    }
}
