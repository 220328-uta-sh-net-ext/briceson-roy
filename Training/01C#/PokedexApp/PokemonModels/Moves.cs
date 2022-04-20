using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonModels
{
    internal class Moves
    {
        public string Name { get; set; }
        private int _PP;
        public int PP { get
            {
                return _PP;
            } set
            {
                if (value > 0)
                    _PP = value;
                else
                    throw new Exception("PP can go no lower than zero");
            }
        }
        public int Power { get; set; }

        public int Accuracy { get; set; }

       public Moves()
        {
            Name = "Tackle";
            PP = 35;
            Power = 40;
            Accuracy = 100;
        }


        }
   }

