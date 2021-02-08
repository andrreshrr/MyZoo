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
    public partial class MyZoo : Form
    {
        List<ANIMAL> loc_animals = new List<ANIMAL>();
        public string loc_name;
        public string loc_family;
        public string loc_gender;
        public string loc_age;
        public string simulation_textbox ;
        public double full = 0 ; //заполненонсть вольера
        Simulation simulation = new Simulation();
        public string volier;
       

        public MyZoo()
        {
            InitializeComponent();
            comboBox1.Text = comboBox1.Items[2].ToString();
            comboBox2.Text = comboBox2.Items[0].ToString();
        }
        

        public void Set(Simulation frm,string GENDER, string NAME, int AGE, string FAMILY)
        {
            frm.AddAnimal(GENDER, NAME, AGE, FAMILY);
        }

        public void SetVolier (Simulation frm)
        {
            frm.volier = this.volier;
        }

        private void MyZoo_Load(object sender, EventArgs e)
        {
            VOLIER v = new VOLIER(volier);
            textBox3.Text += v.Get() + "\r\n";
            simulation_textbox += v.Get() + "\r\n";
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                textBox3.Text += "Одно из полей пустое\r\n";
                return;

            }
            loc_name = textBox1.Text;
           loc_family = comboBox1.Text;
           loc_gender = comboBox2.Text;
           loc_age = textBox2.Text;

            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "Волк";
            comboBox2.Text = "самец";
            string lol_name ="";
            for (int i = 0; i <loc_name.Length; ++i)
            {
                if (i == 0)
                {
                    lol_name += Char.ToUpper(loc_name[0]);
                } else
                {
                    lol_name += loc_name[i];
                }

            }
           
            if (Convert.ToInt32(loc_age) <= 20)
            {
                VOLIER v = new VOLIER(volier);
                ANIMAL an = new ANIMAL(loc_gender, lol_name, Convert.ToInt32(loc_age), loc_family);
                full += an.GetSize();
                if (full <= v.GetSize())
                {
                    simulation_textbox += loc_family + ", " + loc_gender + ", по кличке " + lol_name + ", возрастом " + loc_age + " полных лет(года)\r\n";
                    textBox3.Text += loc_family + ", " + loc_gender + ", по кличке " + lol_name + ", возрастом " + loc_age + " полных лет(года)\r\n";
                    this.Set(simulation, loc_gender, lol_name, Convert.ToInt32(loc_age), loc_family);
                } else
                {
                    textBox3.Text += "Вольер полностью заполнен, больше нет мест!\r\n";
                }
            } else
            {
                textBox3.Text += "Неправильно введён возраст животного, ему не может быть больше 20\r\n";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = simulation_textbox;
            this.SetVolier(simulation);
            simulation.ShowDialog();
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (Char.IsDigit(ch))
            {
                e.Handled = true;
            }

        }
    }
}
