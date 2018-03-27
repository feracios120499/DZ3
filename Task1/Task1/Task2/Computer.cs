using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Computer
    {
        public string Name { get; set; }
        public string Characteristic { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Computer(string Name,string Characteristic,string Description, double Price)
        {
            this.Name = Name;
            this.Characteristic = Characteristic;
            this.Description = Description;
            this.Price = Price;
        }
        public override string ToString()
        {
            return $"{Name},{Characteristic},{Description}";
        }
        public static bool Eqauls(Computer comp1,Computer comp2)
        {
            return (comp1.Name == comp2.Name && comp1.Characteristic == comp2.Characteristic && comp1.Description == comp2.Description && comp1.Price == comp2.Price);
        }
    }
}
