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
    public partial class Simulation : Form
    { 
        List<ANIMAL> animals;
        public Simulation()
        {
            InitializeComponent();
            animals = new  List<ANIMAL>();
        }
        public void AddAnimal(string GENDER, string NAME, int AGE, string FAMILY)
        {
            ANIMAL animal = new ANIMAL(GENDER, NAME, AGE, FAMILY);
            animals.Add(animal);
        }
        public string volier;
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            VOLIER myv = new VOLIER(volier);
            textBox1.Text = "Вольер: \"" + myv.Get() + "\"\r\n";
            
           

          
            for (int iter = 0; iter < 6; ++iter)
            {
               
                textBox1.Text += (iter + 1) + " день:\r\n";

                //во всех вольерах кроме птичьего двора нет крыш, и птицы с некоторой вероятностью улетят
                //из аквариумов птицы улетают сразу
                if (myv.Get() != "Птичий двор")
                {
                    for (int i = 0; i < animals.Count; ++i)
                    {
                        if ((animals[i].GetFly()) && ((myv.Get() == "Аквариум океанический") || (myv.Get() == "Аквариум пресный")))
                        {
                            textBox1.Text += "Птица " + animals[i].GetName() + " улетела, дальнейшая судьба неизвестна\r\n";
                            animals.RemoveAt(i);
                            --i;
                        }
                        else if ((animals[i].GetFly()) && (random.Next(13) % 3 == 0))
                        {
                            textBox1.Text += "Птица " + animals[i].GetName() + " улетела, дальнейшая судьба неизвестна\r\n";
                            animals.RemoveAt(i);
                            --i;
                        }
                    }
                }
                //в аквариумах тонут все, кто не умеет плавать
                for (int i = 0; i < animals.Count; ++i)
                {
                    if ((!animals[i].GetFish()) && ((myv.Get() == "Аквариум океанический") || (myv.Get() == "Аквариум пресный")))
                    {
                        textBox1.Text += "Животное " + animals[i].GetName() + " утонуло, так как не умеет плавать\r\n";
                        animals.RemoveAt(i);
                        --i;
                    }
                }



                //случайное просыпание   
                if ((iter > 0)&&(animals.Count>0))
                    {
                        textBox1.Text += animals[random.Next(animals.Count)].GetName() + " проснулся первым\r\n";                        
                    }                
                

                //если вольер не водный, то все рыбы усохнут
                if ((myv.Get() != "Аквариум океанический") && (myv.Get() != "Аквариум пресный"))
                {
                    for (int i = 0; i < animals.Count; ++i)
                    {
                        if ((animals[i].GetFish())&&(animals[i].GetFamily() != "Утка"))
                        {
                            textBox1.Text += "Животное " + animals[i].GetName() + " не может существовать без воды, оно умерло\r\n";
                            animals.RemoveAt(i);
                            --i;
                        }
                    }

                }

                //сперва хищники с агрессивным характером поедают млекопитающих
                for (int i = 0; i < animals.Count; ++i)
                {

                    if ((animals[i].GetPredator()) && (animals[i].GetCharact()) && (!animals[i].GetFish()))
                    {
                        ANIMAL example = animals[i];
                        double i_need_in = 0; //нужно для регуялтора "сытости" животное не съест больше, чем нужно
                        for (int j = 0; j < animals.Count; ++j)
                        {

                            if ((animals[j].GetPredator() == false) && (animals[j].GetSize() <= example.GetSize() && (i != j)
                                && (example.GetSize() > i_need_in)) && (random.Next(10) != 9))
                            {
                                textBox1.Text += "Животное " + example.GetName() + " съело " + animals[j].GetName() + "\r\n";
                                i_need_in += animals[j].GetSize();
                                animals.RemoveAt(j);
                                --j;


                            }
                            else if (example.GetSize() <= i_need_in)
                            {
                                break;
                            }
                        }

                    }

                }

                //хищники с трусливым характером поедают после агрессивных
                for (int i = 0; i < animals.Count; ++i)
                {
                    if ((animals[i].GetPredator()) && (animals[i].GetCharact() == false))
                    {
                        ANIMAL example = animals[i];
                        double i_need_in = 0; //нужно для регуялтора "сытости" животное не съест больше, чем нужно
                        for (int j = 0; j < animals.Count; ++j)
                        {
                            if ((animals[j].GetPredator() == false) && (animals[j].GetSize() <= example.GetSize()) && (i != j)
                                && (example.GetSize() > i_need_in) && (random.Next(1) == 0))
                            {
                                textBox1.Text += "Животное " + example.GetName() + " съело " + animals[j].GetName() + "\r\n";

                                i_need_in += animals[j].GetSize();
                                animals.RemoveAt(j);
                                --j;


                            }
                            else if (example.GetSize() <= i_need_in)
                            {
                                break;
                            }
                        }

                    }

                }

    
               

                //затем в ход вступают погодные условия
                for (int i = 0; i < animals.Count; ++i)
                {

                    if (Math.Abs(myv.GetTr() - animals[i].GetTr()) > 20)
                    {
                        if (iter != 2)
                        {
                            textBox1.Text += "Животное " + animals[i].GetName() + " не приспособлено к таким природным условием, ему не хорошо..." + "\r\n";
                            
                        }
                        else if ((iter >= 2) && (random.Next(13) % 3 == 0))
                        {
                            textBox1.Text += "Животное " + animals[i].GetName() + " погибло из-за температуры..." + "\r\n";
                            animals.RemoveAt(i);
                            --i;
                        }
                    }

                }
                //Случайные события, ни на что не влияющие
                if (animals.Count > 1) {
                    for (int i = 0; i < animals.Count; ++i)
                    {
                        if (random.Next(16) % 5 == 0)
                        {
                            textBox1.Text += animals[i].GetName() + " играется с ";
                            for (int j = 0; j < animals.Count; ++j)
                            {
                                if (i != j) 
                                {
                                    textBox1.Text += animals[j].GetName() + "\r\n";
                                    break;
                                }
                            }
                            break;
                        } else if ((random.Next(11) % 2 == 0) && (animals[i].GetPredator()))
                        {
                           
                            for (int j = 0; j< animals.Count; ++j)
                            {
                                if ((i != j) && (!animals[j].GetPredator()))
                                {
                                    textBox1.Text += animals[i].GetName() + " гоняется за ";
                                    textBox1.Text += animals[j].GetName() + "\r\n";
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                //если рыба из озера, то в океане ей плохо и она умрет с некоторой вероятностью
                if (myv.Get() == "Аквариум океанический")
                {
                    for (int i = 0; i < animals.Count; ++i)
                    {
                        if ((animals[i].GetWater())&&(random.Next(3)==0))
                        {
                            textBox1.Text += "Рыба " + animals[i].GetName() + " не может жить в солёной воде и умирает от этого\r\n";
                            animals.RemoveAt(i);
                            --i;
                        }
                    }
                }
                //если рыба из океана, то в озере ей плохо и она умрет с некоторой вероятностью
                if (myv.Get() == "Аквариум пресный")
                {
                    for (int i = 0; i < animals.Count; ++i)
                    {
                        if ((!animals[i].GetWater()) && (random.Next(3)  == 0))
                        {
                            textBox1.Text += "Рыба " + animals[i].GetName() + " не может жить в пресной воде и умирает от этого\r\n";
                            animals.RemoveAt(i);
                            --i;
                        }
                    }
                }
                //размонжение
                
                if (animals.Count > 1)
                {
                    List<ANIMAL> female = animals.FindAll(item => !item.GetGender());
                    List<ANIMAL> male = animals.FindAll(item => item.GetGender());                  
                    for (int i = 0; i < female.Count; ++i)
                    {
                       for (int j = 0; j < male.Count; ++j)
                        { 
                            if ((female[i].GetFamily() == male[j].GetFamily())&&(random.Next(4)==3))
                            {
                                textBox1.Text += female[i].GetName() + " делает потомство с " + male[j].GetName() + "\r\n";
                            }
                        }
                    }                   
                }
                //случ смерть из за болезни
                if ((random.Next(12) == 5)&&(animals.Count!=0))
                {
                    int i = random.Next(animals.Count);
                    textBox1.Text += "Животное " + animals[i].GetName() + " умерло из-за внезапной болезни\r\n";
                    animals.RemoveAt(i);

                }
                //случ событие - залезть на дерево
                if ((random.Next(11)==1) && (animals.Count > 0) && (myv.Get()!="Аквариум океанический") && (myv.Get()!= "Аквариум пресный")
                    &&(myv.Get()!="Птичий двор"))
                {   
                    textBox1.Text += animals[random.Next(animals.Count)].GetName() + " пытается залезть на дерево\r\n";
                }
                //случ событие - страх
                if (animals.Count > 1)
                {
                    List<ANIMAL> predators = animals.FindAll(animal => animal.GetPredator());
                    List<ANIMAL> primitivs = animals.FindAll(animal => !animal.GetPredator());
                    if ((predators.Count > 0) && (primitivs.Count > 0) && (random.Next(4)==2))
                    {
                        textBox1.Text += "Животное " + predators[random.Next(predators.Count)].GetName() + " охотилось за животным " +
                            primitivs[random.Next(primitivs.Count)].GetName() + ", но не смогло поймать\r\n"; 
                    }
                }

                //волка забирают в космос
                for (int i = 0; i<animals.Count; ++i)
                {
                    if (animals[i].GetFamily() == "Волк"   && iter >=4 && random.Next(99)<=4 )
                    {
                        textBox1.Text += "Волк(волчица) " + animals[i].GetName() + " так хорошо показал(а) себя, что его(её) забирают из зоопарка и собираются отправить в космос!\r\n";
                        animals.RemoveAt(i);
                        --i;
                    }
                }




            }
        }
    }
}
