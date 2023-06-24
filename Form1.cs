using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using CourseWork_Kryzhevska;


namespace CourseWork_Kryzhevska
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void tb_A1_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Отмена обработки события
            }

            // Проверка, является ли текущее значение текстового поля числом
            if (int.TryParse(tb_A1_2.Text, out int value))
            {
                // Проверка, находится ли число в диапазоне от 0 до 255
                if (value < 0 || value > 255)
                {
                    e.Handled = true; // Отмена обработки события
                }
            }
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            RegisterOperations r = new RegisterOperations();
            int d1 = Convert.ToInt32(data1n.Text);
            int d2 = Convert.ToInt32(data1m.Text);
            r.SE_REG(0, d1); 
            r.SE_REG(1, d2);
            textBox1.Text = "SE_MEM";
            textBox2.Text = "SE_MEM";
            tb_A1_1.Text = "R0"; tb_A2_1.Text = Convert.ToString(r.LoadFromMemory(0)); R0.Text = tb_A2_1.Text;
            tb_A1_2.Text = "R1"; tb_A2_2.Text = Convert.ToString(r.LoadFromMemory(1)); R1.Text = tb_A2_2.Text;
            DataProcessing data = new DataProcessing();
            r.SE_REG(2,data.DIV(Convert.ToInt32( r.LoadFromMemory(1)),10)); textBox3.Text = "DIV"; 
            r.SE_REG(3,data.MOD(Convert.ToInt32(r.LoadFromMemory(1)),10)); textBox4.Text = "MOD";
            tb_A1_3.Text = "R2";  tb_A2_3.Text = tb_A2_2.Text;  tb_A3_3.Text = "10"; R2.Text = Convert.ToString(r.LoadFromMemory(2));
            tb_A1_4.Text = "R3";  tb_A2_4.Text = tb_A2_2.Text;  tb_A3_4.Text = "10"; R3.Text = Convert.ToString(r.LoadFromMemory(3));
            textBox5.Text = "JE";
            tb_A1_5.Text = "009";    tb_A2_5.Text = R0.Text;  tb_A3_5.Text = R2.Text;
            textBox6.Text = "OUT";   tb_A3_6.Text = "0";  output.Text = "0";
            if (data.JE(R0.Text, R2.Text)) { output.Text = "1"; }
            textBox7.Text = "EXIT";
            textBox8.Text = "JE";
            tb_A1_8.Text = "009"; tb_A2_8.Text = R0.Text; tb_A3_8.Text = R3.Text;
            textBox9.Text = "OUT";
            tb_A1_9.Text = " "; tb_A2_9.Text = ""; tb_A3_9.Text = "0";
            if (data.JE(R0.Text, R3.Text)) { output.Text = "1"; }
            textBox10.Text = "OUT"; tb_A3_10.Text = "1";
            textBox11.Text = "EXIT";
        }
        private void btn_Task2_Click(object sender, EventArgs e)
        {
            RegisterOperations r = new RegisterOperations();
            DataProcessing data = new DataProcessing();
            int n = Convert.ToInt32(data2n.Text); textBox1.Text = "SE_MEM"; r.SE_REG(0, n);
            int a = Convert.ToInt32(data2a.Text); textBox2.Text = "SE_MEM"; r.SE_REG(1, a);
            int b = Convert.ToInt32(data2b.Text); textBox3.Text = "SE_MEM"; r.SE_REG(2, b);
            tb_A1_1.Text = "R0"; tb_A2_1.Text = Convert.ToString(r.LoadFromMemory(0)); R0.Text = tb_A2_1.Text;
            tb_A1_2.Text = "R1"; tb_A2_2.Text = Convert.ToString(r.LoadFromMemory(1)); R1.Text = tb_A2_2.Text;
            tb_A1_3.Text = "R2"; tb_A2_3.Text = Convert.ToString(r.LoadFromMemory(2)); R2.Text = tb_A2_3.Text;
            tb_A1_4.Text = "R3"; tb_A2_4.Text = "0"; R3.Text = tb_A2_4.Text; textBox4.Text = "SE_MEM"; r.SE_REG(3, 1);
            textBox5.Text = "MUL";
            r.SE_REG(4, data.MUL(r.LoadFromMemory(1), r.LoadFromMemory(1))); R4.Text = Convert.ToString(r.LoadFromMemory(4));
            tb_A1_5.Text = "R4"; tb_A2_5.Text = "R1"; tb_A3_5.Text = "R1";
            textBox6.Text = "MUL";
            r.SE_REG(5, data.MUL(r.LoadFromMemory(2), r.LoadFromMemory(2))); R5.Text = Convert.ToString(r.LoadFromMemory(5));
            tb_A1_6.Text = "R5"; tb_A2_6.Text = "R2"; tb_A3_6.Text = "R2";
            textBox7.Text = "SUB";
            r.SE_REG(4, data.SUB(r.LoadFromMemory(4), r.LoadFromMemory(5))); R4.Text = Convert.ToString(r.LoadFromMemory(4));
            tb_A1_7.Text = "R4"; tb_A2_7.Text = "R4"; tb_A3_7.Text = "R5";
            textBox8.Text = "ADD";
            r.SE_REG(5, data.ADD(r.LoadFromMemory(1), r.LoadFromMemory(3))); R5.Text = Convert.ToString(r.LoadFromMemory(5));
            tb_A1_8.Text = "R5"; tb_A2_8.Text = "R1"; tb_A3_8.Text = "R3";
            textBox9.Text = "DIV";
            double g = data.DIVF(Convert.ToDouble(r.LoadFromMemory(5)), Convert.ToDouble(r.LoadFromMemory(4)));
            r.SE_REG(5, g); R5.Text = Convert.ToString(r.LoadFromMemory(5));
            tb_A1_9.Text = "R5"; tb_A2_9.Text = "R5"; tb_A3_9.Text = "R4";
            textBox10.Text = "MUL";
            r.SE_REG(5, data.MUL(r.LoadFromMemory(5), r.LoadFromMemory(3))); R5.Text = Convert.ToString(r.LoadFromMemory(5));
            tb_A1_10.Text = "R5"; tb_A2_10.Text = "R5"; tb_A3_10.Text = "R3";
            textBox11.Text = "INC";
            r.SE_REG(3, data.INC(r.LoadFromMemory(3))); R3.Text = Convert.ToString(r.LoadFromMemory(3));
            tb_A1_11.Text = "R3";
            textBox12.Text = "ADD";
            r.SE_REG(6, data.ADD(r.LoadFromMemory(6), r.LoadFromMemory(5)));
            tb_A1_12.Text = "R6"; tb_A2_12.Text = "R6"; tb_A3_12.Text = "R5";
            textBox13.Text = "JL";
            tb_A1_13.Text = "007"; tb_A2_13.Text = "R3"; tb_A3_13.Text = "R0";
            double s = 0;
            for (int i = 0; i <= r.LoadFromMemory(0);i++)
            {
                s += ((r.LoadFromMemory(1) + i) / (r.LoadFromMemory(4))) * i;
            }
            r.SE_REG(6, s);
            R6.Text = Convert.ToString(r.LoadFromMemory(6));
            textBox14.Text = "OUT";
            tb_A3_14.Text = "R6";
            output.Text = R6.Text;
            textBox15.Text = "EXIT";
        }

        private void btn_Task3_Click(object sender, EventArgs e)
        {
            MemoryOperations m = new MemoryOperations();
            RegisterOperations r = new RegisterOperations();
            DataProcessing data = new DataProcessing();
            string input = array_input.Text;
            string[] numbers = input.Split(' ');

            int[] array = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                array[i] = int.Parse(numbers[i]);
            }
            textBox1.Text = "SE_MEM"; m.SE_MEM(100, array);
            tb_A1_1.Text = "100"; tb_A2_1.Text = Convert.ToString(numbers.Length); R0.Text = tb_A2_1.Text;
            int number = Convert.ToInt32(number_input.Text); textBox2.Text = "SE_MEM"; r.SE_REG(1, number);
            tb_A1_2.Text = "R1"; tb_A2_2.Text = Convert.ToString(r.LoadFromMemory(1)); R1.Text = tb_A2_2.Text;
            /*tb_A1_3.Text = "R2"; tb_A2_3.Text = Convert.ToString(r.LoadFromMemory(2)); R2.Text = tb_A2_3.Text;*/
            /*tb_A1_4.Text = "R3"; tb_A2_4.Text = "0"; R3.Text = tb_A2_4.Text; textBox4.Text = "SE_MEM"; r.SE_REG(3, 1);*/
            textBox5.Text = "JL";
            /*r.SE_REG(4,*/ data.JL(Convert.ToDouble( r.LoadFromMemory(1)), r.LoadFromMemory(1)); R4.Text = Convert.ToString(r.LoadFromMemory(4));
            tb_A1_5.Text = "R1"; tb_A2_5.Text = "0"; tb_A3_5.Text = "003";
            textBox6.Text = "JL";
            /*r.SE_REG(5,*/ data.JL(r.LoadFromMemory(2), r.LoadFromMemory(2)); R5.Text = Convert.ToString(r.LoadFromMemory(5));
            tb_A1_6.Text = "R5"; tb_A2_6.Text = "R2"; tb_A3_6.Text = "R2";
            textBox7.Text = "SUB";
            r.SE_REG(4, data.SUB(r.LoadFromMemory(4), r.LoadFromMemory(5))); R4.Text = Convert.ToString(r.LoadFromMemory(4));
            tb_A1_7.Text = "R4"; tb_A2_7.Text = "R4"; tb_A3_7.Text = "R5";
            textBox8.Text = "SUB";
            tb_A1_12.Text = "R1"; tb_A2_12.Text = "1"; tb_A3_12.Text = "R1";
            textBox13.Text = "JL";
            tb_A1_13.Text = "007"; tb_A2_13.Text = "R3"; tb_A3_13.Text = "R0";


            int value = Convert.ToInt32(number_input.Text);                 

            int product = 1;
            bool found = false;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == value)
                {
                    product *= array[i];
                    found = true;
                }
            }

            if (found)
            {
                output.Text = string.Format("Добуток елементів, наступних за елементом зі значенням {0}: {1}", value, product);
            }
            else
            {
                output.Text = string.Format("В масиві немає елемента зі значенням {0}", value);
            }
        }

        private void cop1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {   
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); textBox8.Clear(); textBox9.Clear(); textBox10.Clear(); textBox11.Clear(); textBox12.Clear(); textBox13.Clear(); textBox14.Clear(); tb_A1_14.Clear();
            tb_A1_1.Clear(); tb_A1_2.Clear(); tb_A1_3.Clear(); tb_A1_4.Clear(); tb_A1_5.Clear(); tb_A1_6.Clear(); tb_A1_7.Clear(); tb_A1_8.Clear(); tb_A1_9.Clear(); tb_A1_10.Clear(); tb_A1_11.Clear(); tb_A1_12.Clear(); tb_A1_13.Clear(); /*tb_A1_14.Clear(); tb_A1_15.Clear(); tb_A1_16.Clear();*/
            tb_A2_1.Clear(); tb_A2_2.Clear(); tb_A2_3.Clear(); tb_A2_4.Clear(); tb_A2_5.Clear(); tb_A2_6.Clear(); tb_A2_7.Clear(); tb_A2_8.Clear(); tb_A2_9.Clear(); tb_A2_10.Clear(); tb_A2_11.Clear(); tb_A2_12.Clear(); tb_A2_13.Clear(); tb_A2_14.Clear(); /*tb_A2_15.Clear(); tb_A2_16.Clear(); */
            tb_A3_1.Clear(); tb_A3_2.Clear(); tb_A3_3.Clear(); tb_A3_4.Clear(); tb_A3_5.Clear(); tb_A3_6.Clear(); tb_A3_7.Clear(); tb_A3_8.Clear(); tb_A3_9.Clear(); tb_A3_10.Clear(); tb_A3_11.Clear(); tb_A3_12.Clear(); tb_A3_13.Clear(); tb_A3_14.Clear(); /*tb_A3_15.Clear(); tb_A3_16.Clear();*/
            R0.Clear(); R1.Clear(); R2.Clear(); R3.Clear(); R4.Clear(); R5.Clear(); R6.Clear(); R7.Clear();
            RegisterOperations r = new RegisterOperations(); r.Clear();
            output.Clear();
            data1m.Clear(); data1n.Clear(); data2a.Clear(); data2b.Clear(); data2n.Clear();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            panel1.VerticalScroll.Value = vScrollBar1.Value;
        }
    }
}


    

