using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appCalculatorSystem
{
    public partial class Form1 : Form
    {
        bool wait = false;
        string wasSelected = "10";
        Convertator convertator = new Convertator();
        char[] values = { '0', '1', '2', '3', '4', '5', '6', '7',
            '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "10";
            comboBox2.SelectedItem = "10";
        }
        // C u <
        private void button12_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == "C")
            {
                textBox1.Text = "";
            }
            else
            {
                if (textBox1.Text.Length > 0)
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1); ;
            }
            textBox1.Focus();
            textBox1.Select(textBox1.Text.Length, 0);
        }
        // все цифры
        private void button6_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text += b.Text;
            }
            else if (b != button6)
                textBox1.Text += b.Text;

            textBox1.Focus();
            textBox1.Select(textBox1.Text.Length, 0);
        }
       
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char c = e.KeyChar;

            if (!Char.IsDigit(c) && !Char.IsControl(c) || (c == '0' && textBox1.Text.Length == 0))
                e.Handled = true;
            
            if ((c >= 65 && c <= 70) || (c >= 97 && c <= 102))
                e.Handled = false;


            char[] values = { '0', '1', '2', '3', '4', '5', '6', '7',
            '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            char[] valuesLowers = { '0', '1', '2', '3', '4', '5', '6', '7',
            '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

            int chosen = Convert.ToInt32(comboBox1.SelectedItem);
            for (int i = chosen; i < 16; i++)
            {
                if (c == values[i] || c == valuesLowers[i])
                    e.Handled |= true;
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.Back))
            {
                (sender as TextBox).Clear();
            }
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                
            }

            

        }
        public void DoConvertation()
        {
            string value = textBox1.Text;
            int base_ = Convert.ToInt32(comboBox1.SelectedItem);

            int tempIn10 = convertator.ConvertTo10(value, base_);

            int base2_ = Convert.ToInt32(comboBox2.SelectedItem);
            string finalResult = "";
            if (base2_ != 0)
                finalResult = convertator.ConvertFrom10(tempIn10, base2_);

            textBox2.Text = finalResult;
        }
        public void DoAllEnabled()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!wait)
                DoConvertation();
            textBox1.Focus();
            textBox1.Select(textBox1.Text.Length, 0);
            
            DoAllEnabled();
            int chosen = Convert.ToInt32(comboBox1.SelectedItem);

            Button[] buttons = { button6, button8, button9, button7,
            button10, button2, button3, button1, button12, button11,
            button17, button16, button18, button14, button13, button15 };

            for (int i = chosen; i < buttons.Length; i++)
            {
                buttons[i].Enabled = false;
            }
            if (isAvailaible() == false)
            {
                comboBox1.SelectedItem = wasSelected;
                MessageBox.Show("Введённое значение больше максимального значения СС.", "Ошибочка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            wasSelected = comboBox1.SelectedItem.ToString();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!wait)
                DoConvertation();
            textBox1.Focus();
            textBox1.Select(textBox1.Text.Length,0);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "\u007f")
                textBox1.Text = string.Empty;
            if (!wait)
                DoConvertation();

            textBox1.Text = textBox1.Text.ToUpper();
            textBox1.Select(textBox1.Text.Length, 0);

            string copyText = Clipboard.GetText();
            int copyTextlength = copyText.Length;
            int indexRemove = textBox1.Text.Length - copyTextlength;
            wasSelected = comboBox1.SelectedItem.ToString();
            if (isAvailaible() == false)
            {
                textBox1.Text = textBox1.Text.Remove(indexRemove, copyTextlength);
                MessageBox.Show("Вставленное значение больше максимального значения СС.", "Ошибочка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Select(textBox1.Text.Length, 0);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            wait = true;
            string temp2 = textBox1.Text;
            textBox1.Text = textBox2.Text;
            textBox2.Text = temp2;

            var temp = comboBox1.SelectedItem;
            comboBox1.SelectedItem = comboBox2.SelectedItem;
            comboBox2.SelectedItem = temp;
            wait = false;
        }

        private void button16_EnabledChanged(object sender, EventArgs e)
        {
            
        }
        public bool isAvailaible()
        {
            // преверка на то, будет ли являтся каждый символ тексбокса меньше макс значения СС
            Dictionary<char, int> dick = new Dictionary<char, int>() { { 'A', 10 }, { 'B', 11}, { 'C', 12 },
            { 'D', 13 }, { 'E', 14 }, { 'F', 15 } };
            foreach (char c in textBox1.Text)
            {
                int number;
                if (c >= 'A' && c <= 'F')
                    number = dick[c];
                else
                    number = int.Parse(c.ToString());
                
                if (number >= Convert.ToInt32(comboBox1.SelectedItem))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

