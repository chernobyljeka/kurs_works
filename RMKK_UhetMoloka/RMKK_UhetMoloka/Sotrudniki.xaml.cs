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
    /// Логика взаимодействия для Sotrudniki.xaml
    /// </summary>
    public partial class Sotrudniki : Window
    {
        public Sotrudniki()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            RMKK_UhetMoloka.RMKK_TTNDataSet rMKK_TTNDataSet = ((RMKK_UhetMoloka.RMKK_TTNDataSet)(this.FindResource("rMKK_TTNDataSet")));
            // Загрузить данные в таблицу Сотрудники. Можно изменить этот код как требуется.
            RMKK_UhetMoloka.RMKK_TTNDataSetTableAdapters.СотрудникиTableAdapter rMKK_TTNDataSetСотрудникиTableAdapter = new RMKK_UhetMoloka.RMKK_TTNDataSetTableAdapters.СотрудникиTableAdapter();
            rMKK_TTNDataSetСотрудникиTableAdapter.Fill(rMKK_TTNDataSet.Сотрудники);
            System.Windows.Data.CollectionViewSource сотрудникиViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("сотрудникиViewSource")));
            сотрудникиViewSource.View.MoveCurrentToFirst();
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

                    RMKK_UhetMoloka.RMKK_TTNDataSetTableAdapters.СотрудникиTableAdapter rMKK_TTNDataSetСотрTableAdapter = new RMKK_UhetMoloka.RMKK_TTNDataSetTableAdapters.СотрудникиTableAdapter();
                    rMKK_TTNDataSetСотрTableAdapter.Update(rMKK_TTNDataSet.Сотрудники);
                    MessageBox.Show("Сохранение прошло успешно", "Сохранение");
                   
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
