using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;




namespace DogsCenter
{
    public enum MyEnum { Бульдок = 1, Амстаф = 2, Бультерьер = 3, Пудель = 4, Такса = 5, Шарпей = 6, Хаски = 7, Дог = 8 }
    public partial class Form1 : Form
    {
        DogsCenter[] mas;
        public int size = 513;
        public class DogsCenter
        {
            public MyEnum poroda;
            public string klichka;
            public int min_rost;
            public int max_rost;
            public int fact_rost;
            public DogsCenter(string klichka, MyEnum poroda, int min_rost, int max_rost, int fact_rost)
            {
                this.klichka = klichka;
                this.poroda = poroda;
                this.min_rost = min_rost;
                this.max_rost = max_rost;
                this.fact_rost = fact_rost;
            }
            public DogsCenter()
            { 
            
            }
            public static DogsCenter operator ++(DogsCenter op)
            {
                op.fact_rost++;
                return op;
            }
            public static DogsCenter operator --(DogsCenter op)
            {
                op.fact_rost--;
                return op;
            }
            public static DogsCenter operator >>(DogsCenter op, int s)
            {
                op.fact_rost += s;
                return op;
            }
            public static DogsCenter operator <<(DogsCenter op, int s)
            {
                op.fact_rost -= s;
                return op;
            }
            public static int operator +(DogsCenter op1, DogsCenter op2)
            {
                int sum = op1.fact_rost + op2.fact_rost;
                return sum;
            }
        }
        public int hash(string x)
        {
            int i, hash = 0, result = 0;
            for (i = 0; i < x.Length; i++)
            {
                hash = ((hash * 17) + Convert.ToInt32(x[i])) % (size);
                result = hash;
                if (result < 0)
                {
                    result += size;
                }
            }
            if (result == size) result--;
            return result;
        }

        public int hash2(int data)
        {
            int key;
            key = data;
            key += ~(key << 16);
            key ^= (key >> 5);
            key += (key << 3);
            key ^= (key >> 13);
            key += ~(key << 9);
            key ^= (key >> 17);
            return key%size;
        }

        public void Add(string klichka, MyEnum poroda, int min_rost, int max_rost, int fact_rost)
        {
            string str = klichka;
            int index = hash(str);
            while (mas[index] != null)
            {
                index = hash2(index);
            }
            mas[index] = new DogsCenter(klichka, poroda, min_rost, max_rost, fact_rost);
        }

        public void update()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            int k = 0;
            if (mas != null)
            {
                for (int i = 0; i < size; i++)
                {
                    dataGridView2.Rows.Add(1);
                    dataGridView2.Rows[i].Cells[0].Value = i;
                    if (mas[i] != null)
                    {
                        dataGridView1.Rows.Add(1);
                        dataGridView1.Rows[k].Cells[0].Value = k + 1;
                        dataGridView1.Rows[k].Cells[1].Value = mas[i].poroda.ToString("G");
                        dataGridView1.Rows[k].Cells[2].Value = mas[i].klichka;
                        dataGridView1.Rows[k].Cells[3].Value = mas[i].min_rost;
                        dataGridView1.Rows[k].Cells[4].Value = mas[i].max_rost;
                        dataGridView1.Rows[k].Cells[5].Value = mas[i].fact_rost;
                        dataGridView2.Rows[i].Cells[1].Value = mas[i].klichka;
                        k++;
                    }
                }
            }
        }

        public void sredn_rost(string poroda)
        {
            try
            {
                int s = 0, i = 0, j = 0;
                while (i < mas.Length)
                {
                    if (mas[i] != null && mas[i].poroda.ToString("G") == poroda)
                    {
                        j++;
                    }
                    i++;
                }
                int[] mas2 = new int[j];
                j = 0; i = 0;
                while (i < mas.Length)
                {
                    if (mas[i] != null && mas[i].poroda.ToString("G") == poroda)
                    {
                        mas2[j] = i;
                        j++;
                    }
                    i++;
                }
                for (i = 0; i < mas2.Length; i += 2)
                {
                    if (mas2.Length % 2 != 0)
                    {
                        if (i == mas2.Length - 1)
                        {
                            s += mas[mas2[i]].fact_rost;
                        }
                        else
                        {
                            s += mas[mas2[i]] + mas[mas2[i + 1]];
                        }
                    }
                    else
                    {
                        s += mas[mas2[i]] + mas[mas2[i + 1]];
                    }
                }
                label2.Text = "Средний рост собак выбранной породы " + (int)s / mas2.Length;
                label2.Visible = true;
            }
            catch
            {
                label2.Visible = true;
                label2.Text = "Ошибка ввода породы собаки!"; 
            }
        }

        public void SaviInFile()
        {
            FileStream stream = new FileStream(Program.way, FileMode.Create, FileAccess.Write);
            if (stream != null)
            {
                StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.Unicode);
                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i] != null)
                    {
                        writer.WriteLine(mas[i].klichka);
                        writer.WriteLine(mas[i].poroda.ToString("D"));
                        writer.WriteLine(mas[i].min_rost);
                        writer.WriteLine(mas[i].max_rost);
                        writer.WriteLine(mas[i].fact_rost);
                    }
                }
                writer.Close();
                stream.Close();
            }
        }
               
        public Form1()
        {
            InitializeComponent();
        }

        public List<string> dogs_name = new List<string>();
        
        public void readfile() // функция чтения файла и переноса в таблицу 1;
        {
            mas = new DogsCenter[size];
            StreamReader f = new StreamReader(Program.way);
            int j; string[] buf = new string[5];
            buf[0] = f.ReadLine();
            for (j = 0; j < 5; j++)
            {
                if (j == 0 && buf[0] != null)
                {
                    buf[j + 1] = f.ReadLine();
                }
                if (j == 1)
                {
                    buf[j + 1] = f.ReadLine();
                }
                if (j == 2)
                {
                    buf[j + 1] = f.ReadLine();
                }
                if (j == 3)
                {
                    buf[j + 1] = f.ReadLine();
                }
                if (j == 4 && buf[0] != null)
                {
                    try
                    {
                        int test;
                        test = Convert.ToInt32(buf[2]);
                        test = Convert.ToInt32(buf[3]);
                        test = Convert.ToInt32(buf[4]);
                        test = Convert.ToInt32(buf[1]);
                        if (test > 0 && test < 9)
                        {
                            MyEnum k = (MyEnum)Convert.ToInt32(buf[1]);
                            Add(buf[0], k, Convert.ToInt32(buf[2]), Convert.ToInt32(buf[3]), Convert.ToInt32(buf[4]));
                        }
                    }
                    catch (FormatException)
                    {

                    }
                    j = -1;
                    buf[j + 1] = f.ReadLine();
                }
            }
            f.Close();
            update();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("http://chernobyljeka.wix.com/godscenter");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DogsCenterAdd f = new DogsCenterAdd();
            this.Hide();
            f.Show();
            f.label3.Text = "Добавление записи";
            f.button2.Text = "Добавить";
            f.comboBox1.Items.Add(MyEnum.Амстаф);
            f.comboBox1.Items.Add(MyEnum.Бульдок);
            f.comboBox1.Items.Add(MyEnum.Бультерьер);
            f.comboBox1.Items.Add(MyEnum.Дог);
            f.comboBox1.Items.Add(MyEnum.Пудель);
            f.comboBox1.Items.Add(MyEnum.Такса);
            f.comboBox1.Items.Add(MyEnum.Хаски);
            f.comboBox1.Items.Add(MyEnum.Шарпей);
            f.button2.MouseDown += (sender1, e1) =>
                {
                    f.label8.Visible = false;
                    if (f.comboBox1.Text == "" || f.textBox2.Text == "" || f.textBox3.Text == "" || f.textBox4.Text == "" || f.textBox5.Text == "")
                    {
                        f.label7.Visible = true;
                    }
                    else
                    {
                        f.label7.Visible = false;
                        try
                        {
                            int test;
                            test = Convert.ToInt32(f.textBox3.Text);
                            test = Convert.ToInt32(f.textBox4.Text);
                            test = Convert.ToInt32(f.textBox5.Text);
                            MyEnum t = (MyEnum)f.comboBox1.SelectedItem;
                            Add(f.textBox2.Text, t, Convert.ToInt32(f.textBox3.Text), Convert.ToInt32(f.textBox4.Text), test);
                            SaviInFile();
                        }
                        catch (FormatException)
                        {
                            f.label8.Visible = true;
                        }
                    }
                };
            f.button1.MouseDown += (sender2, e2) =>
                {
                    f.Close();
                    this.Show();
                    update();
                };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            readfile();  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DogsCenterSettings s = new DogsCenterSettings();
            s.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DogCenterAbout a = new DogCenterAbout();
            a.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + @"\\DogsCenter.chm");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Visible == false)
            {
                dataGridView2.Visible = true;
                dataGridView1.Visible = false;
                panel2.Visible = false;
            }
            else
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
                panel2.Visible = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                int num_row = dataGridView1.SelectedCells[0].RowIndex;
                string key = dataGridView1.Rows[num_row].Cells[2].Value.ToString();
                int index = hash(key);
                bool g = false;
                while (g != true)
                {
                    if (mas[index].klichka == key && mas[index].poroda.ToString("G") == Convert.ToString(dataGridView1.Rows[num_row].Cells["Column2"].Value) && mas[index].min_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column4"].Value) && mas[index].max_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column5"].Value) && mas[index].fact_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column6"].Value))
                    {
                        mas[index]++;
                        g = true;
                    }
                    else
                    {
                        hash2(index);
                    }
                }
                update();
                SaviInFile();
            }
            catch
            {
                label2.Visible = true;
                label2.Text = "Ошибка выделения строки!";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                int num_row = dataGridView1.SelectedCells[0].RowIndex;
                string key = dataGridView1.Rows[num_row].Cells[2].Value.ToString();
                int index = hash(key);
                bool g = false;
                while (g != true)
                {
                    if (mas[index].klichka == key && mas[index].poroda.ToString("G") == Convert.ToString(dataGridView1.Rows[num_row].Cells["Column2"].Value) && mas[index].min_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column4"].Value) && mas[index].max_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column5"].Value) && mas[index].fact_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column6"].Value))
                    {
                        --mas[index];
                        g = true;
                    }
                    else
                    {
                        hash2(index);
                    }
                }
                update();
                SaviInFile();
            }
            catch
            {
                label2.Visible = true;
                label2.Text = "Ошибка выделения строки!";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                label2.Visible = false;
                int num_row = dataGridView1.SelectedCells[0].RowIndex;
                string key = dataGridView1.Rows[num_row].Cells[2].Value.ToString();
                int index = hash(key);
                bool g = false;
                while (g != true)
                {
                    if (mas[index].klichka == key && mas[index].poroda.ToString("G") == Convert.ToString(dataGridView1.Rows[num_row].Cells["Column2"].Value) && mas[index].min_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column4"].Value) && mas[index].max_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column5"].Value) && mas[index].fact_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column6"].Value))
                    {
                        mas[index] = mas[index] >> Convert.ToInt32(textBox1.Text);
                        g = true;
                    }
                    else
                    {
                        hash2(index);
                    }
                }
                update();
                SaviInFile();
            }
            catch
            { 
                label2.Visible = true;
                label2.Text = "Не корректно введены данные!";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                label2.Visible = false;
                int num_row = dataGridView1.SelectedCells[0].RowIndex;
                string key = dataGridView1.Rows[num_row].Cells[2].Value.ToString();
                int index = hash(key);
                bool g = false;
                while (g != true)
                {
                    if (mas[index].klichka == key && mas[index].poroda.ToString("G") == Convert.ToString(dataGridView1.Rows[num_row].Cells["Column2"].Value) && mas[index].min_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column4"].Value) && mas[index].max_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column5"].Value) && mas[index].fact_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column6"].Value))
                    {
                        mas[index] = mas[index] << Convert.ToInt32(textBox1.Text);
                        g = true;
                    }
                    else
                    {
                        hash2(index);
                    }
                }
                update();
                SaviInFile();
            }
            catch
            {
                label2.Visible = true;
                label2.Text = "Не корректно введены данные!";
            }
   
        }

        private void button14_Click(object sender, EventArgs e)
        {
            sredn_rost(textBox1.Text);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
            f.button1.MouseDown += (sender1, e1) =>
            {
                string search = f.textBox1.Text;
                f.dataGridView1.Rows.Clear();
                if (mas[hash(search)] != null)
                {
                    int i = hash(search), j = 0;
                    f.dataGridView1.Rows.Add(1);
                    f.dataGridView1.Rows[j].Cells["Column1"].Value = mas[i].klichka;
                    f.dataGridView1.Rows[j].Cells["Column2"].Value = mas[i].poroda.ToString("G");
                    f.dataGridView1.Rows[j].Cells["Column3"].Value = mas[i].min_rost;
                    f.dataGridView1.Rows[j].Cells["Column4"].Value = mas[i].max_rost;
                    f.dataGridView1.Rows[j].Cells["Column5"].Value = mas[i].fact_rost;
                    i = hash2(i); j++;
                    while (mas[i] != null)
                    {
                        if (mas[i].klichka == search)
                        {
                            f.dataGridView1.Rows.Add(1);
                            f.dataGridView1.Rows[j].Cells["Column1"].Value = mas[i].klichka;
                            f.dataGridView1.Rows[j].Cells["Column2"].Value = mas[i].poroda.ToString("G");
                            f.dataGridView1.Rows[j].Cells["Column3"].Value = mas[i].min_rost;
                            f.dataGridView1.Rows[j].Cells["Column4"].Value = mas[i].max_rost;
                            f.dataGridView1.Rows[j].Cells["Column5"].Value = mas[i].fact_rost;
                            i = hash2(i); j++;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Поиск не дал результатов");
                }
            };
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                int num_row = dataGridView1.SelectedCells[0].RowIndex;
                string key = dataGridView1.Rows[num_row].Cells[2].Value.ToString();
                int index = hash(key);
                bool g = false;
                while (g != true)
                {
                    if (mas[index] != null && mas[index].klichka == key && mas[index].poroda.ToString("G") == Convert.ToString(dataGridView1.Rows[num_row].Cells["Column2"].Value) && mas[index].min_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column4"].Value) && mas[index].max_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column5"].Value) && mas[index].fact_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column6"].Value))
                    {
                        mas[index] = null;
                        g = true;
                    }
                    else
                    {
                        index = hash2(index);
                    }
                }
                update();
                SaviInFile();
            }
            catch
            {
                label2.Visible = true;
                label2.Text = "Ошибка выделения строки!";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
            f.button1.MouseDown += (sender1, e1) =>
            {
                string delete = f.textBox2.Text;
                int index = hash(delete);
                if (mas[index] != null)
                {
                    while (mas[index] != null)
                    {
                        if (mas[index].klichka == delete)
                        {
                            mas[index] = null;
                        }
                        index = hash2(index);
                    }
                }
                else
                {
                    MessageBox.Show("Собак с такой кличкой нет в системе");
                }
                update();
                SaviInFile();
            };
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                DogsCenterAdd f = new DogsCenterAdd();
                this.Hide();
                f.Show();
                f.label3.Text = "Замена записи";
                f.button2.Text = "Заменить";
                f.comboBox1.Items.Add(MyEnum.Амстаф);
                f.comboBox1.Items.Add(MyEnum.Бульдок);
                f.comboBox1.Items.Add(MyEnum.Бультерьер);
                f.comboBox1.Items.Add(MyEnum.Дог);
                f.comboBox1.Items.Add(MyEnum.Пудель);
                f.comboBox1.Items.Add(MyEnum.Такса);
                f.comboBox1.Items.Add(MyEnum.Хаски);
                f.comboBox1.Items.Add(MyEnum.Шарпей);
                f.button2.MouseDown += (sender1, e1) =>
                {
                    f.label8.Visible = false;
                    if (f.comboBox1.Text == "" || f.textBox2.Text == "" || f.textBox3.Text == "" || f.textBox4.Text == "" || f.textBox5.Text == "")
                    {
                        f.label7.Visible = true;
                    }
                    else
                    {
                        f.label7.Visible = false;
                        try
                        {
                            int test;
                            test = Convert.ToInt32(f.textBox3.Text);
                            test = Convert.ToInt32(f.textBox4.Text);
                            test = Convert.ToInt32(f.textBox5.Text);
                            MyEnum t = (MyEnum)f.comboBox1.SelectedItem;
                            int num_row = dataGridView1.SelectedCells[0].RowIndex;
                            string key = dataGridView1.Rows[num_row].Cells[2].Value.ToString();
                            int index = hash(key);
                            bool g = false;
                            while (g != true)
                            {
                                if (mas[index] != null && mas[index].klichka == key && mas[index].poroda.ToString("G") == Convert.ToString(dataGridView1.Rows[num_row].Cells["Column2"].Value) && mas[index].min_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column4"].Value) && mas[index].max_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column5"].Value) && mas[index].fact_rost == Convert.ToInt32(dataGridView1.Rows[num_row].Cells["Column6"].Value))
                                {
                                    mas[index] = null;
                                    g = true;
                                }
                                else
                                {
                                    index = hash2(index);
                                }
                            }
                            Add(f.textBox2.Text, t, Convert.ToInt32(f.textBox3.Text), Convert.ToInt32(f.textBox4.Text), test);
                            SaviInFile();
                        }
                        catch (FormatException)
                        {
                            f.label8.Visible = true;
                        }
                    }
                };
                f.button1.MouseDown += (sender2, e2) =>
                {
                    f.Close();
                    this.Show();
                    update();
                };
            }
            catch
            {
                label2.Visible = true;
                label2.Text = "Ошибка выделения строки!";
            }
        }
    }
}
