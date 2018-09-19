using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca2_Zadatak2
{
    public class KlasaIzuzetak: Exception
    {
        public KlasaIzuzetak() { } 
        public KlasaIzuzetak(string poruka) : base(poruka) { }
        public KlasaIzuzetak(string poruka, Exception uzrok) : base(poruka, uzrok) { }
    }
}
