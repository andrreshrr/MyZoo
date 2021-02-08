//Оськин Андрей А-08-18 вариант 18
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZoo
{
   abstract class size_and_tr
    {     
        private int size; //занимаемый объём животным в кубических метрах
        private double tr; //Celsius
        public void SetTr(double tr) { this.tr = tr; }
        public double GetTr() { return this.tr; }

        public void SetSize(int size) { this.size = size; }
        public int GetSize() { return this.size; }

    }

    class ANIMAL : size_and_tr
    {
       //Поле размера, наследуемое из класса вольер будет определятся по параметрам
       // 1 - совсем маленький, 2 - маленький, 3 - средний, 4 - большой, 5 - огромный
      
        private int age;
        private string name, family;
        private bool gender, charact, predator, fish_on, fly_on, water; // 1 - boy , 0 - girl; 1 - angry, 0 - peacful
                                                                        // 1 - пресная, 0 - солёная вода 
        public ANIMAL(string GENDER, string NAME, int AGE, string FAMILY)
        {
            family = FAMILY;
            if (GENDER == "самец")
            { SetGender(true);}
            else if (GENDER == "самка"){ SetGender(false); }
            SetWater(false);
            Set(NAME);
            Set(AGE);
            //определение хищник ли или мирный, установка характера, мирные животные - по умолчанию имеют мирный характер
            if ((FAMILY == "Сайгак") || (FAMILY == "Тушканчик") || (FAMILY == "Бурундук") || (FAMILY == "Тушканчик")
            || (FAMILY == "Ёж") || (FAMILY == "Заяц") || (FAMILY == "Обезьяна") || (FAMILY == "Окапи")
            || (FAMILY == "Пингвин") || (FAMILY == "Тюлень") || (FAMILY == "Осьминог") || (FAMILY == "Утка")
            || (FAMILY == "Лещ") || (FAMILY == "Сом") || (FAMILY == "Курица/Петух"))
            {   
                SetCharact(false);
                SetPredator(false);
            } else { 
                Random random = new Random();
                
                SetCharact(random.Next(11) % 2 == 0);
                SetPredator(true);
            }
            if (FAMILY == "Сайгак")
            {
                SetFly(false);
                SetFish(false);
                SetSize(4);
                SetTr(30);

            }
            else if (FAMILY == "Корсак")
            {
                SetFly(false);
                SetFish(false);
                SetSize(3);
                SetTr(30);

            }
            else if (FAMILY == "Тушканчик")
            {
                SetFly(false);
                SetFish(false);
                SetSize(2);
                SetTr(30);
            }
            else if (FAMILY == "Рысь")
            {
                SetFly(false);
                SetFish(false);
                SetSize(4);
                SetTr(-30);
            }
            else if (FAMILY == "Бурундук")
            {
                SetFly(false);
                SetFish(false);
                SetSize(1);
                SetTr(-30);
            }
            else if (FAMILY == "Бурый медведь")
            {
                SetFly(false);
                SetFish(false);
                SetSize(5);
                SetTr(-10);
            }
            if (FAMILY == "Волк")
            {
                SetFly(false);
                SetFish(false);
                SetSize(4);
                SetTr(10);
            }
            else if (FAMILY == "Лиса")
            {
                SetFly(false);
                SetFish(false);
                SetSize(3);
                SetTr(10);

            }
            else if (FAMILY == "Ёж")
            {
                SetFly(false);
                SetFish(false);
                SetSize(2);
                SetTr(10);
            }
            else if (FAMILY == "Заяц")
            {
                SetFly(false);
                SetFish(false);
                SetSize(2);
                SetTr(10);
            }
            else if (FAMILY == "Ягуар")
            {
                SetFly(false);
                SetFish(false);
                SetSize(4);
                SetTr(25);
            }
            else if (FAMILY == "Обезьяна")
            {
                SetFly(false);
                SetFish(false);
                SetSize(3);
                SetTr(25);
            }
            else if (FAMILY == "Окапи")
            {
                SetFly(false);
                SetFish(false);
                SetSize(4);
                SetTr(25);
            }
            else if (FAMILY == "Пингвин")
            {
                SetFly(false);
                SetFish(false);
                SetSize(3);
                SetTr(-55);
            }
            else if (FAMILY == "Белый медведь")
            {
                SetFly(false);
                SetFish(false);
                SetSize(5);
                SetTr(-55);
            }
            else if (FAMILY == "Тюлень")
            {
                SetFly(false);
                SetFish(true);
                SetSize(5);
                SetTr(-55);
            }
            else if (FAMILY == "Акула")
            {
                SetFly(false);
                SetFish(true);
                SetSize(5);
                SetTr(13);
            }
            else if (FAMILY == "Осьминог")
            {
                SetFly(false);
                SetFish(true);
                SetSize(3);
                SetTr(13);
            }
            else if (FAMILY == "Скат")
            {
                SetFly(false);
                SetFish(true);
                SetSize(3);
                SetTr(13);
            }
            else if (FAMILY == "Щука")
            {
                SetFly(false);
                SetFish(true);
                SetSize(2);
                SetTr(0);
                SetWater(true);
            }
            else if (FAMILY == "Лещ")
            {
                SetWater(true);
                SetFly(false);
                SetFish(true);
                SetSize(2);
                SetTr(0);
            }
            else if (FAMILY == "Сом")
            {
                this.SetWater(true);
                SetFly(false);
                SetFish(true);
                SetSize(3);
                SetTr(0);
            }
            else if (FAMILY == "Утка")
            {
                SetFly(true);
                SetFish(true);
                this.SetWater(true);
                SetSize(2);
                SetTr(10);
            }
            else if (FAMILY == "Курица/Петух")
            {
                SetFly(false);
                SetFish(false);
                SetSize(2);
                SetTr(10);
            }
            else if (FAMILY == "Фазан")
            {
                SetFly(true);
                SetFish(false);
                SetSize(3);
                SetTr(10);
            }
            else if (FAMILY == "Сова")
            {
                SetFly(true);
                SetFish(false);
                SetSize(2);
                SetTr(10);
            }
        }
        public void SetGender(bool gender) { this.gender = gender;}
        public void SetPredator(bool predator) { this.predator = predator; }
        public void SetCharact(bool charact) { this.charact = charact;}
        public void SetFish(bool fish_on) { this.fish_on = fish_on; }
        public void SetWater(bool water) { this.water = water; }
        public void SetFly(bool fly_on) { this.fly_on = fly_on; }
        public void Set(int age) { this.age = age; }
        public void Set(string name) { this.name = name; }       
        public bool GetGender() { return this.gender; }
        public bool GetPredator() { return this.predator; }
        public bool GetCharact() { return this.charact; }
        public int GetAge() { return this.age; }
        public string GetName() { return this.name; }

        public string GetFamily() { return this.family;}

        public bool GetFish() { return this.fish_on; }
        public bool GetWater() { return this.water; }
        public bool GetFly() { return this.fly_on; }
    }

    class VOLIER : size_and_tr
    {
        private string type;
        public VOLIER(string vol)
        {
            Set(vol);
      
            if (vol == "Арктика") { SetTr(-55); SetSize(40); }
            else if (vol == "Степь") { SetTr(30); SetSize(45); }
            else if (vol == "Тайга") { SetTr(-30); SetSize(45); }
            else if (vol == "Тропики") { SetTr(26); SetSize(40); }
            else if (vol == "Широколиственные леса") { SetTr(10); SetSize(40); }
            else if (vol == "Аквариум океанический") { SetTr(13); SetSize(30); }
            else if (vol == "Аквариум пресный") { SetTr(0); SetSize(30); }
            else if (vol == "Птичий двор") { SetTr(10); SetSize(20); }
        }
       
        public void Set(string type)
        {
            this.type = type;
        }
        public string Get()
        {
            return this.type;
        }
    }



}
