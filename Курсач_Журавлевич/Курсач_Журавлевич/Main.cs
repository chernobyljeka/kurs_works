using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Linq;

namespace Курсач_Журавлевич
{
    public enum Type_Control { Зачет = 0, Экзамен = 1, Зачет_Экзамен = 2, Тест = 3 }

    public partial class Main : Telerik.WinControls.UI.RadForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private string way = "";

        #region "Класс для организации хранения данных"
        public static int size = 513;
        Prepod [] mas;
        public class Prepod:IComparable
        {
            public Stack<string> Dis = new Stack<string>();
            public Stack<int> vl = new Stack<int>();
            public Stack<int> vlab = new Stack<int>();
            public Stack<Type_Control> type_control = new Stack<Type_Control>();
            public Stack<string> fio = new Stack<string>();

            public Prepod()
            {

            }

            public Prepod(string Dis, int vl, int vlab, Type_Control type_control, string fio)
            {
                this.Dis.Push(Dis);
                this.vl.Push(vl);
                this.vlab.Push(vlab);
                this.type_control.Push(type_control);
                this.fio.Push(fio);
            }


            public static bool operator >(Prepod perem1, Prepod perem2) //Перегрузка оператора отношения >
            {
                for (int i = 0; i < (perem1.Dis.Peek().Length > perem2.Dis.Peek().Length ? perem2.Dis.Peek().Length : perem1.Dis.Peek().Length); i++)
                {
                    if (perem1.Dis.Peek().ToCharArray()[i] < perem2.Dis.Peek().ToCharArray()[i]) return false;
                    if (perem1.Dis.Peek().ToCharArray()[i] > perem2.Dis.Peek().ToCharArray()[i]) return true;
                }
                return false;
            }
            public static bool operator <(Prepod perem1, Prepod perem2) //Перегрузка оператора отношения <
            {
                for (int i = 0; i < (perem1.Dis.Pop().Length > perem2.Dis.Pop().Length ? perem2.Dis.Pop().Length : perem1.Dis.Pop().Length); i++)
                {
                    if (perem1.Dis.Pop().ToCharArray()[i] < perem2.Dis.Pop().ToCharArray()[i]) return true;
                    if (perem1.Dis.Pop().ToCharArray()[i] > perem2.Dis.Pop().ToCharArray()[i]) return false;
                }
                return false;
            }
            public int CompareTo(Object obj) //Метод, реализующий интерфейс IComparable
            {
                Prepod a = obj as Prepod;
                if (this > a)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            public static Prepod operator ++(Prepod op) //Перегрузка оператора инкремента (префикс)
            {
                List<string> Dis = op.Dis.ToList();
                List<int> vl = op.vl.ToList();
                List<int> vlab = op.vlab.ToList();
                List<Type_Control> tp = op.type_control.ToList();
                List<string> fio = op.fio.ToList();
                Main f = new Main();

                if (Dis.Count == 1)
                {
                    vl[0]++;
                }
                else
                {
                    for (int i = 0; i < Dis.Count; i++)
                    {
                        vl[i]++;
                    }
                }

                op = new Prepod();

                for (int i = 0; i < Dis.Count; i++)
                {
                    op.Dis.Push(Dis[i]);
                    op.vl.Push(vl[i]);
                    op.vlab.Push(vlab[i]);
                    op.type_control.Push(tp[i]);
                    op.fio.Push(fio[i]);
                }
                return op;
            }

            public static Prepod operator --(Prepod op) //Перегрузка оператора декремента
            {
                List<string> Dis = op.Dis.ToList();
                List<int> vl = op.vl.ToList();
                List<int> vlab = op.vlab.ToList();
                List<Type_Control> tp = op.type_control.ToList();
                List<string> fio = op.fio.ToList();
                Main f = new Main();
                if (Dis.Count == 1)
                {
                    vl[0]--;
                }
                else
                {
                    for (int i = 0; i < Dis.Count; i++)
                    {
                        vl[i]--;
                    }
                }
                op = new Prepod();
                for (int i = 0; i < Dis.Count; i++)
                {
                    op.Dis.Push(Dis[i]);
                    op.vl.Push(vl[i]);
                    op.vlab.Push(vlab[i]);
                    op.type_control.Push(tp[i]);
                    op.fio.Push(fio[i]);
                }
                return op;
            }

            public static Prepod operator >>(Prepod op, int del) //Перегрузка оператора сдвига >>
            {
                List<string> Dis = op.Dis.ToList();
                List<int> vl = op.vl.ToList();
                List<int> vlab = op.vlab.ToList();
                List<Type_Control> tp = op.type_control.ToList();
                List<string> fio = op.fio.ToList();
                Main f = new Main();
                if (Dis.Count == 1)
                {
                    vl[0] *= del;
                }
                else
                {
                    for (int i = 0; i < Dis.Count; i++)
                    {
                        vl[i] *= del;
                    }
                }
                op = new Prepod();
                for (int i = 0; i < Dis.Count; i++)
                {
                    op.Dis.Push(Dis[i]);
                    op.vl.Push(vl[i]);
                    op.vlab.Push(vlab[i]);
                    op.type_control.Push(tp[i]);
                    op.fio.Push(fio[i]);
                }
                return op;
            }

            public static Prepod operator <<(Prepod op, int del) //Перегрузка оператора сдвига <<
            {
                List<string> Dis = op.Dis.ToList();
                List<int> vl = op.vl.ToList();
                List<int> vlab = op.vlab.ToList();
                List<Type_Control> tp = op.type_control.ToList();
                List<string> fio = op.fio.ToList();
                Main f = new Main();
                if (Dis.Count == 1)
                {
                    vl[0] /= del;
                }
                else
                {
                    for (int i = 0; i < Dis.Count; i++)
                    {
                        vl[i] /= del;
                    }
                }
                op = new Prepod();
                for (int i = 0; i < Dis.Count; i++)
                {
                    op.Dis.Push(Dis[i]);
                    op.vl.Push(vl[i]);
                    op.vlab.Push(vlab[i]);
                    op.type_control.Push(tp[i]);
                    op.fio.Push(fio[i]);
                }
                return op;
            }

            public static int operator +(Prepod op1, Prepod op2) //Перегрузка оператора сложения
            {
                int sum = 0;
                if (op1.vl.Count == 1)
                {
                    sum += op1.vl.Peek();
                }
                else
                {
                    for (int i = 0; i < op1.vl.Count; i++)
                    {
                        sum += op1.vl.ElementAt(i);
                    }
                }
                if (op2.vl.Count == 1)
                {
                    sum += op2.vl.Peek();
                }
                else
                {
                    for (int i = 0; i < op2.vl.Count; i++)
                    {
                        sum += op2.vl.ElementAt(i);
                    }
                }
                return sum;
            }   
        }
        #endregion

        #region "Процедура добавления в массив"
        public int Add(string Dis, int vl, int vlab, Type_Control type_control, string fio)
        {
            string str = Dis;
            int index = hash(Dis); // Хеширование по названию дисциплины
            if (mas[index] == null)
            {
                mas[index] = new Prepod(Dis, vl, vlab, type_control, fio);
            }
            else
            {
                mas[index].Dis.Push(Dis);
                mas[index].vl.Push(vl);
                mas[index].vlab.Push(vlab);
                mas[index].type_control.Push(type_control);
                mas[index].fio.Push(fio);
            }
           
            return index;
        }
        #endregion



        #region "Процедура хеширования"
        public int hash(string x)
        {
            int i, raq = 0; int key=0;
            for (i = 0; i < x.Length; i++)
            {
               key = ((raq * 18) + Convert.ToInt32(x[i])) % (size);
                    key += ~(key << 8);
                    key ^= (key >> 7);
                    key += (key << 3);
                    key ^= (key >> 11);
                    key += ~(key << 9);
                    key ^= (key >> 17);
                raq = key % size;

            }
            return raq;
        }
        #endregion 



        #region "Загрузка в массив из файла"
        private void add_to_datagrid(string str, int i)
        {
            try
            {
                string[] m = new string[5];
                radGridView1.Rows.Add(1);
                m[0] = str.Substring(0, str.IndexOf('|'));

                str = str.Remove(0, str.IndexOf('|') + 1);
                m[1] = str.Substring(0, str.IndexOf('|'));


                str = str.Remove(0, str.IndexOf('|') + 1);
                m[2] = str.Substring(0, str.IndexOf('|'));

                str = str.Remove(0, str.IndexOf('|') + 1);
                m[3] = str.Substring(0, str.IndexOf('|'));
                int buf = Convert.ToInt32(m[3]);

                str = str.Remove(0, str.IndexOf('|') + 1);
                m[4] = str;

                Type_Control k = (Type_Control)Convert.ToInt32(m[3]);
                Add(m[0], Convert.ToInt32(m[1]), Convert.ToInt32(m[2]), k, m[4].ToString());
            }
            catch
            {

            }
            
        }
        #endregion



        #region "Обновление хеш таблицы"
        private void update_hash_table()
        {
            radGridView2.Rows.Clear();
            int i=0; 
            while (i<size)
            {
               
                radGridView2.Rows.Add(1);
                radGridView2.Rows[radGridView2.Rows.Count-1].Cells[0].Value = i;
                if (mas[i] != null)
                {
                    if (mas[i].Dis.Count == 1)
                    {
                        radGridView2.Rows[radGridView2.Rows.Count - 1].Cells[1].Value = mas[i].Dis.Peek();
                    }
                    else
                    {
                        for (int j = 0; j < mas[i].Dis.Count; j++)
                        {
                            int b = j + 1;
                            radGridView2.Rows.Add(1);
                            radGridView2.Rows[radGridView2.Rows.Count - 1].Cells[0].Value = i.ToString() + "." + b;
                            radGridView2.Rows[radGridView2.Rows.Count - 1].Cells[1].Value = mas[i].Dis.ElementAt(j);                  
                        }
                    }
                }
                i++;
            }
        }
        #endregion



        #region "Обновление главной таблицы"
        private void update()
        {
            radButton5.Visible = false;
            radGridView1.Rows.Clear();
            for (int i = 0; i < size; i++)
            {
                if (mas[i] != null)
                {
                    if (mas[i].Dis.Count == 1)
                    {
                        radGridView1.Rows.Add(1);
                        radGridView1.Rows[radGridView1.Rows.Count - 1].Cells[0].Value = mas[i].Dis.Peek();
                        radGridView1.Rows[radGridView1.Rows.Count - 1].Cells[1].Value = Convert.ToInt32(mas[i].vl.Peek());
                        radGridView1.Rows[radGridView1.Rows.Count - 1].Cells[2].Value = Convert.ToInt32(mas[i].vlab.Peek());
                        radGridView1.Rows[radGridView1.Rows.Count - 1].Cells[3].Value = mas[i].type_control.Peek();
                        radGridView1.Rows[radGridView1.Rows.Count - 1].Cells[4].Value = mas[i].fio.Peek();
                    }
                    else
                    {
                        if (mas[i].Dis.Count > 1)
                        {
                            List<string> Dis = mas[i].Dis.ToList();
                            List<int> vl = mas[i].vl.ToList();
                            List<int> vlab = mas[i].vlab.ToList();
                            List<Type_Control> tp = mas[i].type_control.ToList();
                            List<string> fio = mas[i].fio.ToList();
                            for (int k = 0; k < fio.Count; k++)
                            {
                                radGridView1.Rows.Add(1);
                                radGridView1.Rows[radGridView1.Rows.Count - 1].Cells[0].Value = Dis[k];
                                radGridView1.Rows[radGridView1.Rows.Count - 1].Cells[1].Value = vl[k];
                                radGridView1.Rows[radGridView1.Rows.Count - 1].Cells[2].Value = vlab[k];
                                radGridView1.Rows[radGridView1.Rows.Count - 1].Cells[3].Value = tp[k].ToString("G");
                                radGridView1.Rows[radGridView1.Rows.Count - 1].Cells[4].Value = fio[k];
                            }
                        }
                    }
                }
            }
        }
        #endregion



        #region "Загрузка формы"
        private void Main_Load(object sender, EventArgs e)
        {
            #region "TabControl"
            /* Скрытие кнопки для закрытия вкладок */
            (radPageView1.ViewElement as RadPageViewStripElement).ShowItemCloseButton = false;
            (radPageView1.ViewElement as RadPageViewStripElement).StripButtons = StripViewButtons.Scroll;
            #endregion

            mas = new Prepod[size];
        }
        #endregion 


    
        #region "Добавление записи"
        private void radButton1_Click(object sender, EventArgs e)
        {
            update();
            add_and_edit f = new add_and_edit();
            f.Text = "Добавить запись";
            f.label1.Text = "Добавить запись";
            f.Show();
            f.radButton2.MouseDown += (sender1, e1) =>
            {
                try
                {
                    Type_Control k = (Type_Control)f.comboBox1.SelectedIndex;
                    Add(f.radTextBox1.Text, Convert.ToInt32(f.radTextBox2.Text), Convert.ToInt32(f.radTextBox3.Text), k, f.radTextBox4.Text);
                              
                        radGridView1.Rows.Add(1);
                        radGridView1.Rows[radGridView1.RowCount - 1].Cells[0].Value = f.radTextBox1.Text;
                        radGridView1.Rows[radGridView1.RowCount - 1].Cells[1].Value = f.radTextBox2.Text;
                        radGridView1.Rows[radGridView1.RowCount - 1].Cells[2].Value = f.radTextBox3.Text;
                        radGridView1.Rows[radGridView1.RowCount - 1].Cells[3].Value = f.comboBox1.SelectedValue.ToString();
                        radGridView1.Rows[radGridView1.RowCount - 1].Cells[4].Value = f.radTextBox4.Text;
                    
                    f.Close();
                    update_hash_table();
                }
                catch
                {
                    RadMessageBox.SetThemeName("Office2010Blue");
                    RadMessageBox.Show("Ошибка ввода данны:\nОбъем лекций и лабароторных занятий должен быть введн в целочисленном формате!","Ошибка ввода данных");
                    
                }
            };

            f.radButton1.Click += (sender1, e1) =>
            {
                f.Close();
            };
        }
        #endregion



        #region "Поиск"
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (mas[hash(radTextBox2.Text)] != null)
                {
                    radGridView1.Rows.Clear();
                    int index = hash(radTextBox2.Text);
                    if (mas[index] != null)
                    {
                        if (mas[index].Dis.Count == 1)
                        {
                            if (mas[index].Dis.Peek() == radTextBox2.Text)
                            {
                                radGridView1.Rows.Add(1);
                                radGridView1.Rows[0].Cells[0].Value = mas[index].Dis.Peek();
                                radGridView1.Rows[0].Cells[1].Value = mas[index].vl.Peek();
                                radGridView1.Rows[0].Cells[2].Value = mas[index].vlab.Peek();
                                radGridView1.Rows[0].Cells[3].Value = mas[index].type_control.Peek().ToString("G");
                                radGridView1.Rows[0].Cells[4].Value = mas[index].Dis.Peek();
                            }
                        }
                        else
                        {
                            if (mas[index].Dis.Count > 1)
                            {
                                List<string> Dis = mas[index].Dis.ToList();
                                List<int> vl = mas[index].vl.ToList();
                                List<int> vlab = mas[index].vlab.ToList();
                                List<Type_Control> tp = mas[index].type_control.ToList();
                                List<string> fio = mas[index].fio.ToList();
                                int j = 0;
                                for (int k = 0; k < Dis.Count; k++)
                                {
                                    if (Dis[k] == radTextBox2.Text)
                                    {
                                        radGridView1.Rows.Add(1);
                                        radGridView1.Rows[j].Cells[0].Value = Dis[k];
                                        radGridView1.Rows[j].Cells[1].Value = vl[k];
                                        radGridView1.Rows[j].Cells[2].Value = vlab[k];
                                        radGridView1.Rows[j].Cells[3].Value = tp[k].ToString("G");
                                        radGridView1.Rows[j].Cells[4].Value = Dis[k];
                                        j++;
                                    }
                                }
                            }
                        }
                    }
                    radButton5.Visible = true;
                }
                else
                {

                    RadMessageBox.SetThemeName("Office2010Blue");
                    RadMessageBox.Show("Поиск не дал результатов!", "Поиск");
                }
            }
            catch
            {
 
            }
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            update();
        }

        #endregion



        #region "Удаление выбранного элемента"
        private void radButton4_Click(object sender, EventArgs e)
        {
            try
            {
                int num_row = radGridView1.CurrentCell.RowIndex;
                int index = hash(Convert.ToString(radGridView1.Rows[num_row].Cells[0].Value));
                if (mas[index] != null)
                {
                    if (mas[index].Dis.Count == 1)
                    {

                        mas[index] = null;
                    }
                    else
                    {
                        List<string> Dis = mas[index].Dis.ToList();
                        List<int> vl = mas[index].vl.ToList();
                        List<int> vlab = mas[index].vlab.ToList();
                        List<Type_Control> tp = mas[index].type_control.ToList();
                        List<string> fio = mas[index].fio.ToList();
                        for (int i = 0; i < mas[index].Dis.Count; i++)
                        {
                            if (Dis[i] == Convert.ToString(radGridView1.Rows[num_row].Cells[0].Value) && vl[i] == Convert.ToInt32(radGridView1.Rows[num_row].Cells[1].Value) && vlab[i] == Convert.ToInt32(radGridView1.Rows[num_row].Cells[2].Value) && tp[i].ToString("G") == Convert.ToString(radGridView1.Rows[num_row].Cells[3].Value) && fio[i] == Convert.ToString(radGridView1.Rows[num_row].Cells[4].Value))
                            {
                                Dis.RemoveAt(i);
                                vl.RemoveAt(i);
                                vlab.RemoveAt(i);
                                tp.RemoveAt(i);
                                fio.RemoveAt(i);
                                break;
                            }
                        }
                        mas[index] = null;
                        mas[index] = new Prepod();
                        for (int i = 0; i < Dis.Count; i++)
                        {
                            mas[index].Dis.Push(Dis[i]);
                            mas[index].vl.Push(vl[i]);
                            mas[index].vlab.Push(vlab[i]);
                            mas[index].type_control.Push(tp[i]);
                            mas[index].fio.Push(fio[i]);
                        }
                    }
                }
                update();
                update_hash_table();
            }
            catch
            {
                RadMessageBox.SetThemeName("Office2010Blue");
                RadMessageBox.Show("Ошибка удаления\n -Отсутвуют записи для удаления\n -Не выбрана запись для удаления", "Ошибка удаления");
            }
        }
        

        #endregion



        #region "Удаление по названию"
        private void radButton2_Click(object sender, EventArgs e)
        {
            del f = new del();
            f.Show();
            f.radButton1.Click += (sender1, e1) =>
            {
                f.Close();
            };
            f.radButton2.Click += (sender1, e1) =>
            {
                int index = hash(f.radTextBox1.Text);
                if (mas[index] != null)
                {
                    mas[index] = null;
                    update();
                    update_hash_table();
                    f.Close();
                }
                else
                {
                    RadMessageBox.SetThemeName("Office2010Blue");
                    RadMessageBox.Show("Запись с таким ключом отсутствует!", "Ошибка удаления");
                }

            };
        }
        #endregion



        #region "Изменение выбранной"
        private void radButton3_Click(object sender, EventArgs e)
        { 
            
            add_and_edit f = new add_and_edit();
            f.Text = "Изменить запись";
            f.label1.Text = "Изменить запись";
            f.radButton2.Text = "Изменить";
            f.Show();
            f.radButton2.MouseDown += (sender1, e1) =>
            {
                try
                {
                int num_row = radGridView1.CurrentCell.RowIndex;
                int index = hash(Convert.ToString(radGridView1.Rows[num_row].Cells[0].Value));
                if (mas[index] != null)
                {
                    if (mas[index].Dis.Count == 1)
                    {
                        mas[index] = null;
                    }
                    else
                    {
                        List<string> Dis = mas[index].Dis.ToList();
                        List<int> vl = mas[index].vl.ToList();
                        List<int> vlab = mas[index].vlab.ToList();
                        List<Type_Control> tp = mas[index].type_control.ToList();
                        List<string> fio = mas[index].fio.ToList();
                        for (int i = 0; i < mas[index].Dis.Count; i++)
                        {
                            if (Dis[i] == Convert.ToString(radGridView1.Rows[num_row].Cells[0].Value) && vl[i] == Convert.ToInt32(radGridView1.Rows[num_row].Cells[1].Value) && vlab[i] == Convert.ToInt32(radGridView1.Rows[num_row].Cells[2].Value) && tp[i].ToString("G") == Convert.ToString(radGridView1.Rows[num_row].Cells[3].Value) && fio[i] == Convert.ToString(radGridView1.Rows[num_row].Cells[4].Value))
                            {
                                Dis.RemoveAt(i);
                                vl.RemoveAt(i);
                                vlab.RemoveAt(i);
                                tp.RemoveAt(i);
                                fio.RemoveAt(i);
                                break;
                            }
                        }
                        mas[index] = null;
                        mas[index] = new Prepod();
                        for (int i = 0; i < Dis.Count; i++)
                        {
                            mas[index].Dis.Push(Dis[i]);
                            mas[index].vl.Push(vl[i]);
                            mas[index].vlab.Push(vlab[i]);
                            mas[index].type_control.Push(tp[i]);
                            mas[index].fio.Push(fio[i]);
                        }
                    }
                }
                Type_Control k = (Type_Control)f.comboBox1.SelectedIndex;
                Add(f.radTextBox1.Text, Convert.ToInt32(f.radTextBox2.Text), Convert.ToInt32(f.radTextBox3.Text), k, f.radTextBox4.Text);
                update();
                update_hash_table();
                f.Close();
            }
                catch
                {
                    RadMessageBox.SetThemeName("Office2010Blue");
                    RadMessageBox.Show("Ошибка ввода данны:\nОбъем лекций и лабароторных занятий должен быть введн в целочисленном формате!\nИли не выбрана строка для изменения!","Ошибка ввода данных");
                }
               
            };
            f.radButton1.MouseDown += (sender1, e1) =>
           {
               f.Close();
           };
        }
        #endregion



        #region "Реализация перегрузок"
        private void radButton6_Click(object sender, EventArgs e)
        {
            try
            {
                int index = hash(Convert.ToString(radGridView1.Rows[radGridView1.CurrentRow.Index].Cells[0].Value));
                mas[index] = ++mas[index];
                update();
            }
            catch
            {
                RadMessageBox.SetThemeName("Office2010Blue");
                RadMessageBox.Show("Не выбрана строка для изменения", "Ошибка ввода данных");
            }
        }

        private void radButton9_Click(object sender, EventArgs e)
        {
            try
            {
                int index = hash(Convert.ToString(radGridView1.Rows[radGridView1.CurrentRow.Index].Cells[0].Value));
                mas[index] = --mas[index];
                update();
            }
            catch
            {
                RadMessageBox.SetThemeName("Office2010Blue");
                RadMessageBox.Show("Не выбрана строка для изменения", "Ошибка ввода данных");
            }
        }

        private void radButton7_Click(object sender, EventArgs e)
        {
            try
            {
                if (radTextBox1.Text != "")
                {
                    int index = hash(Convert.ToString(radGridView1.Rows[radGridView1.CurrentRow.Index].Cells[0].Value));
                    mas[index] = mas[index] >> Convert.ToInt32(radTextBox1.Text);
                    update();
                }
                else
                {
                    RadMessageBox.SetThemeName("Office2010Blue");
                    RadMessageBox.Show("Не удалось уменьшить обем лекций:\n -Не введен X!", "Ошибка");
                }
            }
            catch
            {
                RadMessageBox.SetThemeName("Office2010Blue");
                RadMessageBox.Show("Не удалось увеличить обем лекций:\n -Не верно введен x или не выбрана строка!", "Ошибка");
            }
        }

        private void radButton8_Click(object sender, EventArgs e)
        {
            try
            {
                if (radTextBox1.Text != "")
                {
                    int index = hash(Convert.ToString(radGridView1.Rows[radGridView1.CurrentRow.Index].Cells[0].Value));
                    mas[index] = mas[index] << Convert.ToInt32(radTextBox1.Text);
                    update();
                }
                else
                {
                    RadMessageBox.SetThemeName("Office2010Blue");
                    RadMessageBox.Show("Не удалось уменьшить обем лекций:\n -Не введен X!", "Ошибка");
                }
            }
            catch
            {
                RadMessageBox.SetThemeName("Office2010Blue");
                RadMessageBox.Show("Не удалось уменьшить обем лекций:\n -Не верно введен x или не выбрана строка! ", "Ошибка");
            }
        }
        #endregion



        #region "Главное меню"

        private void radMenuItem3_Click(object sender, EventArgs e)
        {
            if (way != "")
            {
                save(way);
            }
            else
            {
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    save(saveFileDialog1.FileName);
                    way = saveFileDialog1.FileName;
                    saveFileDialog1.FileName = "";
                }
            }

        }

        private void radMenuItem2_Click_1(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int j = 0; j < size; j++)
                {
                    if (mas[j] != null)
                    {
                        mas[j] = null;
                    }
                }  
                way = openFileDialog1.FileName;
                StreamReader f = new StreamReader(way, System.Text.Encoding.UTF8, false);
                int i = 0;
                while (!f.EndOfStream)
                {
                    add_to_datagrid(f.ReadLine(), i);
                    i++;
                }
                update();
                update_hash_table();
            }
        }

        private void radMenuItem7_Click(object sender, EventArgs e)
        {
            about n = new about();
            n.Show();
        }

        private void radMenuItem8_Click(object sender, EventArgs e)
        {
            Prepod big = new Prepod();
            big.Dis.Push(radGridView1.Rows[0].Cells[0].Value.ToString());
            int row_num = 0;
            for (int i = 0; i < radGridView1.Rows.Count; i++)
            {
                int index = hash(radGridView1.Rows[i].Cells[0].Value.ToString());
                if (mas[index].CompareTo(big) == 1)
                {
                    big.Dis = mas[index].Dis;
                    row_num = i;
                }
            }
            string data = radGridView1.Rows[row_num].Cells[0].Value.ToString();
            for (int i = 0; i < radGridView1.Rows.Count; i++)
            {
                if (radGridView1.Rows[i].Cells[0].Value.ToString() == data)
                {
                    radGridView1.Rows[i].IsSelected = true;
                    radGridView1.CurrentRow = radGridView1.Rows[i];
                }
            }
        }

        private void radMenuItem5_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < size; j++)
            {
                if (mas[j] != null)
                {
                    mas[j] = null;
                }
            }
            way = Application.StartupPath + "/db.txt";
            StreamReader f = new StreamReader(Application.StartupPath + "/db.txt", System.Text.Encoding.UTF8, false);
            int i = 0;
            while (!f.EndOfStream)
            {
                add_to_datagrid(f.ReadLine(), i);
                i++;
            }
            f.Close();
            update();
            update_hash_table();
        }

        private void radMenuItem11_Click(object sender, EventArgs e)
        {
            radButton1_Click(sender, e);
        }

        private void radMenuItem12_Click(object sender, EventArgs e)
        {
            radButton2_Click(sender, e);
        }

        private void radMenuItem13_Click(object sender, EventArgs e)
        {
            radButton4_Click(sender, e);
        }

        private void radMenuItem14_Click(object sender, EventArgs e)
        {
            radButton3_Click(sender, e);
        }

        private void radMenuItem15_Click(object sender, EventArgs e)
        {
            radButton6_Click(sender, e);
        }

        private void radMenuItem16_Click(object sender, EventArgs e)
        {
            radButton9_Click(sender, e);
        }

        private void radMenuItem17_Click(object sender, EventArgs e)
        {
            radButton7_Click(sender, e);
        }

        private void radMenuItem18_Click(object sender, EventArgs e)
        {
            radButton8_Click(sender, e);
        }

        private void radMenuItem19_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                save(saveFileDialog1.FileName);
                way = saveFileDialog1.FileName;
                saveFileDialog1.FileName = "";
            }
        }

        #endregion



        #region "Сохранение в файл"
        private void save(string pathc)
        {
            StreamWriter sr = new StreamWriter(pathc, false);
            for (int i = 0; i < size; i++)
            {
                if (mas[i] != null)
                {
                    if (mas[i].Dis.Count == 1)
                    {
                        sr.WriteLine(mas[i].Dis.Peek().ToString() + "|" + mas[i].vl.Peek().ToString() + "|" + mas[i].vlab.Peek().ToString() + "|" + (int)mas[i].type_control.Peek() + "|" + mas[i].fio.Peek().ToString());
                    }
                    else
                    {
                        if (mas[i].Dis.Count > 1)
                        {
                            List<string> Dis = mas[i].Dis.ToList();
                            List<int> vl = mas[i].vl.ToList();
                            List<int> vlab = mas[i].vlab.ToList();
                            List<Type_Control> tp = mas[i].type_control.ToList();
                            List<string> fio = mas[i].fio.ToList();
                            for (int k = 0; k < fio.Count; k++)
                            {
                                sr.WriteLine(Dis[k] + "|" + vl[k] + "|" + vlab[k] + "|" + (int)tp[k] + "|" + fio[k]);
                            }
                        }
                    }
                }
            }
            sr.Close();
        }
        #endregion 


    }
}
