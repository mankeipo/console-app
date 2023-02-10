using System;

namespace HelloWorld
{
    //Interface
    interface HumanActions {
        void introduction();
    }
    //Class
    class Human : HumanActions {
        public string name { get; }
        public int Age { get; set; }
        public decimal Height { get; }
        
        //self introduction
        public void introduction() {
            Console.WriteLine($"This person is {name}, {Age} years old, {Height} lbs");
        }

        public Human(string name_, int Age_number, decimal Height_number) {
            name = name_;
            Age = Age_number;
            Height = Height_number;
        }
    }

    class Event_New_Year {
        //Define a delegate
        public delegate void New_Year_Event_Handler(object source, EventArgs args);
        //Define an event 
        public event New_Year_Event_Handler Entering_New_Year;
        //event trigger
        public void New_Year_Arrive (Human person) {
            Console.WriteLine("Happy new year!");
            On_Entering_New_Year(); //trigger Event
            if(person.Age < 25) {
                Console.WriteLine($"{person.name} is turning {person.Age+1} this year, and he/she is going to grow to {person.Height+10} this year!");
            } else {
                Console.WriteLine($"{person.name} is turning {person.Age+1} this year; however, so sad he/she is not growing anymore :(");
            }
        }
        //virtual method
        protected virtual void On_Entering_New_Year() {
            if(Entering_New_Year != null) {
                Entering_New_Year(this,null);
            }
        }
    }

    public class Wishes {
        public void On_Entering_New_Year(object source, EventArgs args) {
            Console.WriteLine("Wish you have a happy new year!");
        }
    }
  class Program
  {
    static void Main(string[] args)
    {
        Human Alan = new Human("Alan", 19, 170);
        Alan.introduction();
        Human Allen = new Human("Allen", 29, 160);
        Allen.introduction();
        var New_Year_2023 = new Event_New_Year();
        Wishes wish = new Wishes();
        New_Year_2023.Entering_New_Year += wish.On_Entering_New_Year;
        New_Year_2023.New_Year_Arrive(Alan);
        New_Year_2023.New_Year_Arrive(Allen);
    }
  }
}