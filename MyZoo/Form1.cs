using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyZoo
{
    public partial class Form1 : Form
    {
        public string loc_volier;

        public void SetVolier(MyZoo frm)
        {
            frm.volier = this.loc_volier;
        }

        public Form1()
        {
            InitializeComponent();
            comboBox1.Text = comboBox1.Items[2].ToString();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        
                   

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loc_volier = comboBox1.Text;
            MyZoo ChooseAnimal = new MyZoo();
            this.SetVolier(ChooseAnimal);
            ChooseAnimal.ShowDialog();
            
            
            this.Close();



        }
    }
}
