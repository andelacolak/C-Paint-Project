using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Projekt
{
    class Olovka
    {
        private int velicina;

        public int Velicina
        {
            get { return velicina; }
            set 
            {
                if (value < 30 && value > 5)
                    velicina = value;
                else
                {
                    if (value >= 30)
                        velicina = 30;
                    else  if(value<=5)
                        velicina = 5;
                }
            }
        }
        private bool olovka;

        public bool Olovka1
        {
            get { return olovka; }
            set { olovka = value; }
        }
        public Olovka(int v,bool b)
        {
            Velicina = v;
            Olovka1 = b;
        }
    }
}
