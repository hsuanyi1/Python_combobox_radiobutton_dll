using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Python_combobox_radiobutton_dll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add(new MyItem("第一號", "1"));
            comboBox1.Items.Add(new MyItem("第二號", "2"));
            comboBox1.Items.Add(new MyItem("第三號", "3"));
            comboBox1.Items.Add(new MyItem("第四號", "4"));
            comboBox1.Items.Add(new MyItem("第五號", "5"));

            comboBox2.Items.Add(new MyItem("第一號", "6"));
            comboBox2.Items.Add(new MyItem("第二號", "7"));
            comboBox2.Items.Add(new MyItem("第三號", "8"));
            comboBox2.Items.Add(new MyItem("第四號", "9"));
            comboBox2.Items.Add(new MyItem("第五號", "10"));
        }
       struct MyItem
        {
            public MyItem(string displayName, string realValue)
            {
                DisplayName = displayName;
                RealValue = realValue;
            }
            public string DisplayName { get; set; }
            public string RealValue { get; set; }
            // must have this override method to display the right string.
            public override string ToString()
            {
                return DisplayName;
            }
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = ((MyItem)comboBox1.SelectedItem).RealValue;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = ((MyItem)comboBox2.SelectedItem).RealValue;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //label1.ForeColor = Color.Black;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //label1.ForeColor = Color.Black;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ScriptRuntime pyRuntime = Python.CreateRuntime(); //建立一下執行環境
            dynamic obj = pyRuntime.UseFile("C:/Users/hsuanyi/Documents/Pycharm/add.py");
            int num1 = int.Parse(textBox1.Text);
            int num2 = int.Parse(textBox2.Text);
            int sum = obj.add(num1, num2); //呼叫python檔案中的求和函式
            int mp = obj.mp(num1, num2); //呼叫python檔案中的求和函式
            if (radioButton1.Checked)
                label1.Text = sum.ToString();
            else
                label1.Text = mp.ToString();

        }
    }
}
