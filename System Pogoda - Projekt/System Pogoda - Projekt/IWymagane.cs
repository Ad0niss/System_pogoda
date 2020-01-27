using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Pogoda___Projekt
{
    interface IWymagane
    {
        void DodajStacje(Stacja_pomiarowa s);
        void UsunStacje(Stacja_pomiarowa sp);
        Stacja_pomiarowa Znajdz(string nazwa);
        Stacja_pomiarowa ZnajdzStacjePoZjawisku(Zjawisko_pogodowe zp);
    }
}
