using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dolgozok
{
    internal class Dolgozo
    {
        string nev;
        string beosztas;
        string email;
        string telefonszam;
        int fizetes;
        string nem;

        public Dolgozo(string nev, string beosztas, string email, string telefonszam, int fizetes, string nem)
        {
            this.nev = nev;
            this.beosztas = beosztas;
            this.email = email;
            this.telefonszam = telefonszam;
            this.fizetes = fizetes;
            this.nem = nem;
        }

        public string Nev { get => nev; }
        public string Beosztas { get => beosztas; }
        public string Email { get => email; }
        public string Telefonszam { get => telefonszam; }
        public int Fizetes { get => fizetes; }
        public string Nem { get => nem; }
        public override string? ToString()
        {
            return $"{nev} {beosztas} {email} {telefonszam} {fizetes} {nem}";
        }
    }
}
