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
    /// Логика взаимодействия для add_edit.xaml
    /// </summary>
    public partial class add_edit : Window
    {
        public add_edit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void insert_p_Click(object sender, RoutedEventArgs e)
        {
            Organisation org = new Organisation();
            org.Add_button.Visibility = Visibility.Visible;
            org.Show();

            org.Add_button.Click += (sender1, e1) =>
            {
                System.Data.DataRowView rowView = org.организацииDataGrid.SelectedValue as System.Data.DataRowView;
                if (rowView != null)
                {
                    tb_post.Text = rowView[1].ToString();
                    org.Close();
                }
                else
                {
                    MessageBox.Show("Не выбран поставщик", "Выбор поставщика");
                }
            };

        }


        private void insert_v_Click(object sender, RoutedEventArgs e)
        {
            Sotrudniki st = new Sotrudniki();
            st.Add_button.Visibility = Visibility.Visible;
            st.Show();

            st.Add_button.Click += (sender1, e1) =>
            {
                System.Data.DataRowView rowView = st.сотрудникиDataGrid.SelectedValue as System.Data.DataRowView;
                if (rowView != null)
                {
                    tb_vod.Text = rowView[1].ToString();
                    st.Close();
                }
                else
                {
                    MessageBox.Show("Не выбран поставщик", "Выбор поставщика");
                }
            };
        }

        private void insert_a_Click(object sender, RoutedEventArgs e)
        {
            Auto av = new Auto();
            av.Add_button.Visibility = Visibility.Visible;
            av.Show();

            av.Add_button.Click += (sender1, e1) =>
            {
                System.Data.DataRowView rowView = av.автомобилиDataGrid.SelectedValue as System.Data.DataRowView;
                if (rowView != null)
                {
                    tb_av.Text = rowView[0].ToString();
                    av.Close();
                }
                else
                {
                    MessageBox.Show("Не выбран поставщик", "Выбор поставщика");
                }
            };
        }
    }
}
