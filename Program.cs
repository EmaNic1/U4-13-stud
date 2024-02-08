using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OPP3_bandymas
{
    //Paprasta ir konteinerine studentu duomenu saugojimui
    /// <summary>
    /// KLASE STUDENTO DUOMENIMS SAUGOTI
    /// </summary>
    class Studentas
    {
        private string pavarde;//studento pavarde
        private string vardas;//studento vardas
        private string grupe;//studento grupe
        private int pazymiuKiekis;//studento pazymiu kiekis
        private ArrayList turimiPazymiai;//studento turimi pazymiai

        /// <summary>
        /// Ivedami duomenys
        /// </summary>
        public Studentas()
        {
            pavarde = "";
            vardas = "";
            grupe = "";
            pazymiuKiekis = 0;
            turimiPazymiai = new ArrayList();
        }

        /// <summary>
        /// Ivedami duomenys
        /// </summary>
        /// <param name="pavarde">Studento pavarde</param>
        /// <param name="vardas">Studento vardas</param>
        /// <param name="grupe">Studento grupe</param>
        /// <param name="pazymiuKiekis">Studento pazymiu kiekis</param>
        /// <param name="turimiPazymiai">Studento turimi pazymiai</param>
        public void Deti(string pavarde, string vardas, string grupe,
            int pazymiuKiekis, ArrayList turimiPazymiai)
        {
            this.pavarde = pavarde;
            this.vardas = vardas;
            this.grupe = grupe;
            this.pazymiuKiekis = pazymiuKiekis;
            foreach (int sk in turimiPazymiai)
                this.turimiPazymiai.Add(sk);
        }

        public string ImtiPavarde() { return pavarde; }

        public string ImtiVarda() { return vardas; }

        public string ImtiGrupe() { return grupe; }

        public int ImtiPazymiuKieki() { return pazymiuKiekis; }

        public ArrayList ImtiPazymius() { return turimiPazymiai; }

        //Uzkloti metodai
        /// <summary>
        /// Užklotas metodas Equals()
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Užklotas metodas GetHashCode()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Spausdina duomenu eilute
        /// </summary>
        /// <returns>Duomenu eilute</returns>
        public override string ToString()
        {
            string line;
            line = string.Format("|{0,-11}|{1,-10}|{2,-9}|{3,18:d}|",
                pavarde, vardas, grupe, pazymiuKiekis);
            foreach (int sk in turimiPazymiai)
                line += string.Format(" {0,3:d}", sk);
            return line;
        }
    }


    /// <summary>
    /// KONTEINERINE KLASE STUDENTO DUOMENIMS SAUGOTI
    /// </summary>
    class Stipendija
    {
        const int CMax = 100;
        private Studentas[] S;
        private int kiek;

        /// <summary>
        /// Iveda duomenis
        /// </summary>
        public Stipendija()
        {
            S = new Studentas[CMax];
            kiek = 0;
        }

        public int Imti() { return kiek; }

        public Studentas Imti(int i) { return S[i]; }

        public void Deti(Studentas st) { S[kiek++] = st; }
    }

    /// <summary>
    /// Klase atitinkamu studentu duomenims saugoti
    /// </summary>
    class Atitinkami
    {
        private string pavarde;//studento pavarde
        private string vardas;//studento vardas
        private string grupe;//studento grupe
        private double vidurkis;//visu pazymiu vidurkis
        private string arStipendija;//ar studentas gauna stipendija
        private string arPirmunas;//ar studentas yra pirmunas
        private double kiekStipendijos;//kiek gauna stipendijos

        public Atitinkami()
        {
            pavarde = "";
            vardas = "";
            grupe = "";
            vidurkis = 0;
            arStipendija = "";
            arPirmunas = "";
            kiekStipendijos = 0;
        }

        /// <summary>
        /// Idedami duomenys
        /// </summary>
        /// <param name="pavarde">Studento pavarde</param>
        /// <param name="vardas">Studento vardas</param>
        /// <param name="grupe">Studento grupe</param>
        /// <param name="vidurkis">Pazymiu vidurkis</param>
        /// <param name="arStipendija">Ar gaus stipendija</param>
        /// <param name="arPirmunas">Ar yra pirmunas</param>
        /// <param name="kiekStipendijos">Kiek gaus stipendijos</param>
        public void Deti(string pavarde, string vardas, string grupe,
            double vidurkis, string arStipendija, string arPirmunas,
            double kiekStipendijos)
        {
            this.pavarde = pavarde;
            this.vardas = vardas;
            this.grupe = grupe;
            this.vidurkis = vidurkis;
            this.arStipendija = arStipendija;
            this.arPirmunas = arPirmunas;
            this.kiekStipendijos = kiekStipendijos;
        }

        public string ImtiStipendija() { return arStipendija; }

        //Uzkloti metodai
        /// <summary>
        /// Užklotas metodas Equals()
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Užklotas metodas GetHashCode()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Spausdina duomenu eilute
        /// </summary>
        /// <returns>Duomenu eilute</returns>
        public override string ToString()
        {
            string line;
            line = string.Format("|{0,-11}|{1,-10}|{2,-9}|{3,12:f2}" +
                "|{4,-23}|{5,-15}|{6,25:f2}e|",
                pavarde, vardas, grupe, vidurkis,
                arStipendija, arPirmunas, kiekStipendijos);
            return line;
        }

        public static bool operator <=(Atitinkami at1, Atitinkami at2)
        {
            int p = String.Compare(at1.pavarde, at2.pavarde,
                StringComparison.CurrentCulture);
            int v = String.Compare(at1.vardas, at2.vardas,
                StringComparison.CurrentCulture);
            if (at1.kiekStipendijos < at2.kiekStipendijos &&
                 (p < 0 || v > 0))
                return true;
            else
                return false;
        }

        public static bool operator >=(Atitinkami at1, Atitinkami at2)
        {
            int p = String.Compare(at1.pavarde, at2.pavarde,
               StringComparison.CurrentCulture);
            int v = String.Compare(at1.vardas, at2.vardas,
                StringComparison.CurrentCulture);
            if (at1.kiekStipendijos > at2.kiekStipendijos &&
                (p > 0 || v < 0))
                return true;
            else
                return false;
        }
    }

    /// <summary>
    /// Konteinerine klase atitinkamu studentu duomenims saugoti
    /// </summary>
    class AtitinkamuMasyvas
    {
        const int CMax = 100;
        private Atitinkami[] AT;
        private int kiek;

        public AtitinkamuMasyvas()
        {
            AT = new Atitinkami[CMax];
            kiek = 0;
        }

        public int Imti() { return kiek; }

        public Atitinkami Imti(int i) { return AT[i]; }

        public void Deti(Atitinkami at) { AT[kiek++] = at; }

        /// <summary>
        /// Surikiuoja sarasa mazejimo tvarka
        /// </summary>
        public void Rykiuoti()
        {
            for (int i = 0; i < kiek; i++)
            {
                Atitinkami min = AT[i];
                int im = i;
                for (int j = i + 1; j < kiek; j++)
                    if (AT[j] >= min)
                    {
                        min = AT[j];
                        im = j;
                    }
                AT[im] = AT[i];
                AT[i] = min;
            }
        }

        /// <summary>
        /// Pasalina studentus, kurie negauna stipendijos
        /// </summary>
        public void Salinti()
        {
            int m = 0;
            for (int i = 0; i < kiek; i++)
                if (AT[i].ImtiStipendija() == "Taip")
                    AT[m++] = AT[i];
            kiek = m;
        }
    }

    internal class Program
    {
        const int Cn = 100;
        const string PD = "Stipendija.txt";
        const string RZ = "Rezultatai.txt";

        static void Main(string[] args)
        {
            //Skaitomi ir spausdinami pradiniai duomenys
            Stipendija Pradiniai = new Stipendija();
            if (File.Exists(RZ))
                File.Delete(RZ);
            int fondas;//turimi pinigai stipendijoms
            double vidurkis;//minimalus pazymiu vidurkis stipendijai gauti
            Skaityti(ref Pradiniai, PD, out fondas, out vidurkis);
            Spausdinti(Pradiniai, RZ, "Studentu duomenys:", fondas,
                vidurkis);

            //Atrenka, kurie studentai gauna stipendija,
            //kurie yra pirmunai ir kiek kuris studentas gauna stipendijos
            AtitinkamuMasyvas ArTinkami = new AtitinkamuMasyvas();
            ArAtitinkaReikalavimus(Pradiniai, ref ArTinkami, vidurkis,
                fondas);
            SpausdintiAtrinktus(ArTinkami, RZ, "Studentai paskirstyti " +
                "pagal reikalavimus:");

            //Surikiuoja nauja sarasa mazejimo tvarka
            ArTinkami.Rykiuoti();
            SpausdintiAtrinktus(ArTinkami, RZ, "Surikiuotas naujas sarasas:");

            //Spausdinamas naujas sarasas su pasalintais studentais
            ArTinkami.Salinti();
            if (ArTinkami.Imti() > 0)
                SpausdintiAtrinktus(ArTinkami, RZ, "Pasalinti visi studentai, " +
                    "kurie negauna stipendijos:");
            else
                using (var fr = File.AppendText(RZ))
                {
                    fr.WriteLine("Pasalinti visi studentai, " +
                        "kurie negauna stipendijos.");
                    fr.WriteLine("");
                }

            //Ivedama norima grupe
            string grupe;
            Console.WriteLine("Iveskite, kurios grupes pirmunus " +
                "norite isspausdinti:");
            grupe = Console.ReadLine();
            using (var fr = File.AppendText(RZ))
            {
                fr.WriteLine("Jusu pasirinkta grupe: {0}", grupe);
                fr.WriteLine("");
            }

            //Formuojamas naujas sarasas
            Stipendija pirmunai = new Stipendija();
            Formuoti(Pradiniai, grupe, ref pirmunai);
            if (pirmunai.Imti() > 0)
                SpausdintiPirmunus(pirmunai, RZ, "Pirmunu sarasas:");
            else
                using (var fr = File.AppendText(RZ))
                {
                    fr.WriteLine("Pirmunu, su nurodyta grupe, nera.");
                }
        }

        /// <summary>
        /// Skaito duomenis is failo
        /// </summary>
        /// <param name="S">Studento konteinerine klase</param>
        /// <param name="fv">Failo vardas</param>
        /// <param name="fondas">Stipendijos fondas</param>
        /// <param name="vidurkis">Pazymiu vidurkis</param>
        static void Skaityti(ref Stipendija S, string fv,
            out int fondas, out double vidurkis)
        {
            ArrayList turimiPazymiai = new ArrayList();
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                int i = 0;
                line = reader.ReadLine();
                string[] part = line.Split(' ');
                fondas = int.Parse(part[0]);
                vidurkis = double.Parse(part[1]);
                while ((line = reader.ReadLine()) != null && (i < Cn))
                {
                    string[] parts = line.Split(';');
                    string pavarde = parts[0];
                    string vardas = parts[1];
                    string grupe = parts[2];
                    int pazymiuKiekis = int.Parse(parts[3]);
                    //skaitomi turimi pazymiai
                    string[] lines = parts[4].Trim().Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                    turimiPazymiai.Clear();
                    foreach (string eilute in lines)
                    {
                        int paz = int.Parse(eilute);
                        turimiPazymiai.Add(paz);
                    }
                    Studentas st = new Studentas();
                    st.Deti(pavarde, vardas, grupe,
                        pazymiuKiekis, turimiPazymiai);
                    S.Deti(st);
                }
            }
        }

        /// <summary>
        /// Spausdina pradinius duomenis is konteinerio i faila
        /// </summary>
        /// <param name="S">Studento konteinerine klase</param>
        /// <param name="fv">failo vardas</param>
        /// <param name="antraste">Lenteles pavadinimas</param>
        /// <param name="fondas">Stipendijos fondas</param>
        /// <param name="vidurkis">Pazymiu vidurkis</param>
        static void Spausdinti(Stipendija S, string fv, string antraste,
            int fondas, double vidurkis)
        {
            string top =
                "|------------------------------------------------" +
                "----------------------------\r\n" +
                "|  Pavarde  |  Vardas  |  Grupe  |  Pazymiu kiekis  " +
                "|        Pazymiai        \r\n" +
                "|------------------------------------------------" +
                "----------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Turimas fondas stipendijai: {0} euru", fondas);
                fr.WriteLine("Stipendijai gauti butinas" +
                    " pazymiu vidurkis: {0,2:f2}"
                    , vidurkis);
                fr.WriteLine("");
                fr.WriteLine(antraste);
                fr.WriteLine(top);
                for (int i = 0; i < S.Imti(); i++)
                    fr.WriteLine("{0}", S.Imti(i).ToString());
                fr.WriteLine("|-----------------------------------" +
                    "-----------------------------------------");
                fr.WriteLine("");
            }
        }

        /// <summary>
        /// Suranda studentus, kuriu pazymiai didesni uz 4
        /// </summary>
        /// <param name="S">Studento konteinerine klase</param>
        /// <returns>Studentai neturintys skolu</returns>
        static bool ArTeigiami(Stipendija S)
        {
            bool visiTeigiami = true;
            int i = 0;
            foreach (int skaicius in S.Imti(i).ImtiPazymius())
            {
                i++;
                if (skaicius < 4)
                {
                    visiTeigiami = false;
                    break;
                }

            }
            return visiTeigiami;
        }

        /// <summary>
        /// Tikrina ar studentai gaus stipendija
        /// </summary>
        /// <param name="reikalavimai">Reikalavimas stipendijai gauti</param>
        /// <returns>Ar gauna stipendija</returns>
        static bool ArGausStipendija(Stipendija S, double reikalavimai, int k)
        {
            double vidurkis = 0;
            double suma = 0;
            int i = 0;
            if (ArTeigiami(S))
            {
                foreach (int skaicius in S.Imti(k).ImtiPazymius())
                {
                    suma += skaicius;
                    i++;
                }
                vidurkis = suma / i;
                vidurkis = Math.Round(vidurkis, 2);
            }
            if (vidurkis > reikalavimai)
            {
                return true;
            }
            else
                return false;

        }

        /// <summary>
        /// Tikrina ar studentas yra pirmunas
        /// </summary>
        /// <returns>Ar yra pirmunas</returns>
        static bool ArPirmunas(Stipendija S, int k)
        {
            bool pirmunas = true;
            foreach (int skaiciai in S.Imti(k).ImtiPazymius())
                if (skaiciai < 9)
                {
                    pirmunas = false;
                    break;
                }
            return pirmunas;
        }

        /// <summary>
        /// Suskaiciuoja, kiek gauna stipendijos pirmunai ir ne pirmunai
        /// </summary>
        /// <param name="S">Studentu konteinerine klase</param>
        /// <param name="k">Kintamasis</param>
        /// <param name="reikalavimai">Reikalavimas stipendijai gauti</param>
        /// <param name="fondas">Turimas fondas stipendijai</param>
        /// <returns></returns>
        static (double, double) KiekGauna(Stipendija S, int k,
            double reikalavimai, int fondas)
        {
            int kiek = 0;
            int pirmunas = 0;
            for (int i = 0; i < S.Imti(); i++)
            {
                if (ArGausStipendija(S, reikalavimai, i))
                    kiek++;
                if (ArPirmunas(S, i))
                    pirmunas++;
            }
            double min = (double)fondas / kiek;
            double pirmunoMin = min + min * 0.1;
            double likusieji = min - min * 0.1;
            return (likusieji, pirmunoMin);
        }


        /// <summary>
        /// Patikrina, kurie gauna stipendija, kurie yra pirmunai,
        /// ir kiek kievienas studentas gauna stipendijos
        /// </summary>
        /// <param name="S">Studento konteinerine klase</param>
        /// <param name="AT">Atitinkamu konteinerine klase</param>
        /// <param name="vidurkis">Pazymiu vidurkis</param>
        static void ArAtitinkaReikalavimus(Stipendija S, ref AtitinkamuMasyvas AT,
            double vidurkis, int fondas)
        {
            string pavarde, vardas, grupe;
            double pazymiuVidurkis, suma = 0;
            string arGausStipendija, arPirmunas;
            double kiekStipendijos;
            double stipendija, pirmunoStipendija;
            for (int i = 0; i < S.Imti(); i++)
            {
                //suskaiciuoja pazymiu vidurkius
                foreach (int skaicius in S.Imti(i).ImtiPazymius())
                    suma += skaicius;
                pazymiuVidurkis = suma / S.Imti(i).ImtiPazymiuKieki();
                suma = 0;

                //tikrina ar gauna stipendija
                if (ArGausStipendija(S, vidurkis, i))
                    arGausStipendija = "Taip";
                else
                    arGausStipendija = "Ne";

                //tikrina ar yra pirmunas
                if (ArPirmunas(S, i))
                    arPirmunas = "Taip";
                else
                    arPirmunas = "Ne";

                //tikrina, kiek kuris studentas gauna stipendijos
                (stipendija, pirmunoStipendija) =
                    KiekGauna(S, i, vidurkis, fondas);
                if (arGausStipendija == "Taip" && arPirmunas == "Ne")
                    kiekStipendijos = stipendija;
                else
                    if (arGausStipendija == "Taip" && arPirmunas == "Taip")
                    kiekStipendijos = pirmunoStipendija;
                else
                    kiekStipendijos = 0;

                //iveda likusius duomenis
                pavarde = S.Imti(i).ImtiPavarde();
                vardas = S.Imti(i).ImtiVarda();
                grupe = S.Imti(i).ImtiGrupe();

                Atitinkami at = new Atitinkami();
                at.Deti(pavarde, vardas, grupe, pazymiuVidurkis,
                    arGausStipendija, arPirmunas, kiekStipendijos);
                AT.Deti(at);
            }
        }

        /// <summary>
        /// Spausdina duomenis
        /// </summary>
        /// <param name="AT">Atitinkamu konteinerine klase</param>
        /// <param name="fv">Failo vardas</param>
        /// <param name="antraste">Lenteles pavadinimas</param>
        static void SpausdintiAtrinktus(AtitinkamuMasyvas AT,
            string fv, string antraste)
        {
            string top =
        "|-----------------------------------------------------" +
        "-----------------------------------------------------------|\r\n" +
        "|  Pavarde  |  Vardas  |  Grupe  |  Vidurkis  " +
        "|  Ar gauna stipendija  |  Ar pirmunas  |  Kiek gauna stipendijos  |\r\n" +
        "|-----------------------------------------------------" +
        "-----------------------------------------------------------|";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraste);
                fr.WriteLine(top);
                for (int i = 0; i < AT.Imti(); i++)
                    fr.WriteLine("{0}", AT.Imti(i).ToString());
                fr.WriteLine("|--------------------------------" +
                    "------------------------------------------" +
                    "--------------------------------------|");
                fr.WriteLine("");
            }
        }

        /// <summary>
        /// Suformuoja ivestos grupes pirmunu sarasa
        /// </summary>
        /// <param name="S">Studento konteinerine klase</param>
        /// <param name="grupe">Ivesta grupe</param>
        /// <param name="S1">Nauja konteinerine klase</param>
        static void Formuoti(Stipendija S, string grupe, ref Stipendija S1)
        {
            for (int i = 0; i < S.Imti(); i++)
            {
                if (ArPirmunas(S, i) && S.Imti(i).ImtiGrupe().Trim() == grupe)
                    S1.Deti(S.Imti(i));
            }
        }

        /// <summary>
        /// Spausdina pradinius duomenis is konteinerio i faila
        /// </summary>
        /// <param name="S">Studento konteinerine klase</param>
        /// <param name="fv">failo vardas</param>
        /// <param name="antraste">Lenteles pavadinimas</param>
        /// <param name="fondas">Stipendijos fondas</param>
        /// <param name="vidurkis">Pazymiu vidurkis</param>
        static void SpausdintiPirmunus(Stipendija S, string fv, string antraste)
        {
            string top =
                "|------------------------------------------------" +
                "----------------------------\r\n" +
                "|  Pavarde  |  Vardas  |  Grupe  |  Pazymiu kiekis  " +
                "|        Pazymiai        \r\n" +
                "|------------------------------------------------" +
                "----------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraste);
                fr.WriteLine(top);
                for (int i = 0; i < S.Imti(); i++)
                    fr.WriteLine("{0}", S.Imti(i).ToString());
                fr.WriteLine("|-----------------------------------" +
                    "-----------------------------------------");
                fr.WriteLine("");
            }
        }
    }
}