namespace WypozyczalniaAut
{
    internal class Kalkulator
    {

        public static void WypozyczalniaKalkulator()
        {
            Console.Clear();
            Console.WriteLine("PROSZĘ PODAĆ ID KLIENTA, KTÓRY WYPOŻYCZA SAMOCHÓD:");
            Client WybranyKlient = null;
            Klienciwypozyczalni clients = new();
            autawypozyczalni cars = new();
            while (true)
            {
                string input = Console.ReadLine();
                int value;
                if (int.TryParse(input, out value))
                {
                    WybranyKlient = clients.getClientById(value);
                    if (WybranyKlient != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("KLIENT O TAKIM ID NIE ISTNIEJE.");
                        Thread.Sleep(6000);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("PROSZĘ PODAĆ ID KLIENTA, KTÓRY WYPOŻYCZA SAMOCHÓD:");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("NIEPOPRAWNY INPUT.");
                    Thread.Sleep(6000);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine("PROSZĘ PODAĆ ID KLIENTA, KTÓRY WYPOŻYCZA SAMOCHÓD:");
                    Thread.Sleep(10000);
                }
            }
            Console.Clear();
            Console.WriteLine("1. Mini");
            Console.WriteLine("2. Kompakt");
            string Segment = "";
            var someDate = DateTime.Now;
            var someDate1 = WybranyKlient.PrawoJazdy.Date;
            int difference = someDate.Year - someDate1.Year;
            if (difference >= 4)
            {
                Console.WriteLine("3. Premium");
            }
            Console.WriteLine("PODAJ SEGMENT SAMOCHODU: ");
            bool dobryInput = false;
            while (!dobryInput)
            {
                string input1 = Console.ReadLine();
                int value;
                if (int.TryParse(input1, out value))
                {
                    switch (value)
                    {
                        case 1:
                            Segment = "mini";
                            dobryInput = true;
                            break;
                        case 2:
                            Segment = "kompakt";
                            dobryInput = true;
                            break;
                        case 3:
                            {
                                if (difference >= 4)
                                {
                                    Segment = "premium";
                                    dobryInput = true;
                                    break;
                                }
                                goto default;
                            }
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("WYBRANO NIEPRAWIDŁOWY SEGMENT");
                            Thread.Sleep(6000);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            printOpcjeSegment(WybranyKlient);
                            break;

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("NIEPOPRAWNY INPUT");
                    Thread.Sleep(6000);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    printOpcjeSegment(WybranyKlient);
                }
            }
            Console.Clear();
            Console.WriteLine("1. Benzyna");
            Console.WriteLine("2. Elektryczny");
            Console.WriteLine("3. Diesel");
            Console.WriteLine("PODAJ PREFEROWANY RODZAJ PALIWA: ");
            string TypPaliwa = "";
            dobryInput = false;
            while (!dobryInput)
            {
                string input2 = Console.ReadLine();
                int value;
                if (int.TryParse(input2, out value))
                {
                    switch (value)
                    {
                        case 1:
                            TypPaliwa = "benzyna";
                            dobryInput = true;
                            break;
                        case 2:
                            TypPaliwa = "elektryczny";
                            dobryInput = true;
                            break;
                        case 3:
                            TypPaliwa = "diesel";
                            dobryInput = true;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("OPCJA O DANYM NUMERZE NIE ISTNIEJE.");
                            Thread.Sleep(6000);
                            Console.ForegroundColor = ConsoleColor.White;
                            printOpcjePaliwo();
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("NIEPOPRAWNY INPUT");
                    Thread.Sleep(6000);
                    Console.ForegroundColor = ConsoleColor.White;
                    printOpcjePaliwo();
                }
            }
            Console.Clear();
            int dniWynajmu = 1;
            Console.WriteLine("PODAJ ILOŚĆ DNI WYNAJMU POJAZDU: ");
            dobryInput = false;
            while (!dobryInput)
            {
                string input3 = Console.ReadLine();
                int value;
                if (int.TryParse(input3, out value))
                {
                    dniWynajmu = value;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("NIEPOPRAWNY INPUT");
                    Thread.Sleep(6000);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine("PODAJ ILOŚĆ DNI WYNAJMU POJAZDU: ");
                }
            }
            Car WybraneAuto = null;
            while (true)
            {
                WybraneAuto = cars.getCarBySegmentPaliwo(Segment, TypPaliwa);
                if (WybraneAuto == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Console.WriteLine("AUTO O DANYCH PARAMETRACH NIE ZNAJDUJĘ SIĘ W NASZEJ WYPOZYCZALNI, PROSZE WYBRAĆ PONOWNIE: ");
                    Thread.Sleep(6000);
                    Console.ForegroundColor = ConsoleColor.White;
                    printWyborSegment(WybranyKlient, ref Segment);
                    printWyborPaliwo(ref TypPaliwa);

                }
                else
                {
                    break;
                }
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            DateTime today = DateTime.Now;
            Console.WriteLine("UMOWA WYNAJMU POJAZDU");
            Console.WriteLine($"Data zawarcia: {today.ToShortDateString()}");
            Console.WriteLine($"Wynajmujący/a: {WybranyKlient.FullName}");
            Console.WriteLine($"Rodzaj pojazdu: {WybraneAuto.Marka}");
            Console.WriteLine($"Rodzaj pojazdu: {WybraneAuto.Marka}");
            Console.WriteLine($"Rodzaj paliwa: {TypPaliwa}");
            Console.WriteLine($"Segment: {Segment}");


            int dniWynajmuGratis = 1;
            if (dniWynajmu > 30)
            {
                dniWynajmuGratis = dniWynajmu + 3;
            }
            else if (dniWynajmu > 7)
            {
                dniWynajmuGratis = dniWynajmu + 1;
            }
            DateTime zwrot = today.AddDays(dniWynajmuGratis);
            Console.WriteLine($"Data zwrotu pojazdu: {zwrot.ToString("dd/MM/yyyy")}");
            Console.WriteLine();
            decimal opłata = WybraneAuto.Cena * dniWynajmu;
            decimal dopłata = 1.2m;
            if (difference > 4)
                opłata = Decimal.Multiply(opłata, dopłata);
            Console.WriteLine($"Opłata: {opłata} PLN");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Ekran.PokazOpcje();

        }
        public static void printOpcjeSegment(Client WybranyKlient)
        {
            Console.Clear();
            Console.WriteLine("1. Mini");
            Console.WriteLine("2. Kompakt");
            var someDate = DateTime.Now;
            var someDate1 = WybranyKlient.PrawoJazdy.Date;
            int difference = someDate.Year - someDate1.Year;
            if (difference >= 4)
            {
                Console.WriteLine("3. Premium");
            }
            Console.WriteLine("PODAJ SEGMENT SAMOCHODU: ");
        }

        public static void printOpcjePaliwo()
        {
            Console.Clear();
            Console.WriteLine("1. Benzyna");
            Console.WriteLine("2. Elektryczny");
            Console.WriteLine("3. Diesel");
            Console.WriteLine("PODAJ PREFEROWANY RODZAJ PALIWA: ");
        }

        public static void printWyborSegment(Client WybranyKlient, ref string Segment)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("1. Mini");
            Console.WriteLine("2. Kompakt");
            var someDate = DateTime.Now;
            var someDate1 = WybranyKlient.PrawoJazdy.Date;
            int difference = someDate.Year - someDate1.Year;
            if (difference >= 4)
            {
                Console.WriteLine("3. Premium");
            }

            Console.WriteLine("PODAJ SEGMENT SAMOCHODU: ");
            bool dobryInput = false;
            while (!dobryInput)
            {
                string input1 = Console.ReadLine();
                int value;
                if (int.TryParse(input1, out value))
                {
                    switch (value)
                    {
                        case 1:
                            Segment = "mini";
                            dobryInput = true;
                            break;
                        case 2:
                            Segment = "kompakt";
                            dobryInput = true;
                            break;
                        case 3:
                            {
                                if (difference >= 4)
                                {
                                    Segment = "premium";
                                    dobryInput = true;
                                    break;
                                }
                                goto default;
                            }
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("WYBRANO NIEPRAWIDŁOWY SEGMENT");
                            Thread.Sleep(6000);
                            Console.ForegroundColor = ConsoleColor.White;
                            printOpcjeSegment(WybranyKlient);
                            return;

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("NIEPOPRAWNY INPUT");
                    Thread.Sleep(6000);
                    Console.ForegroundColor = ConsoleColor.White;
                    printOpcjeSegment(WybranyKlient);
                    return;
                }
            }
        }
        public static void printWyborPaliwo(ref string TypPaliwa)
        {
            Console.Clear();
            Console.WriteLine("1. Benzyna");
            Console.WriteLine("2. Elektryczny");
            Console.WriteLine("3. Diesel");
            Console.WriteLine("PODAJ PREFEROWANY RODZAJ PALIWA:");
            bool dobryInput = false;
            while (!dobryInput)
            {
                string input2 = Console.ReadLine();
                int value;
                if (int.TryParse(input2, out value))
                {
                    switch (value)
                    {
                        case 1:
                            TypPaliwa = "benzyna";
                            dobryInput = true;
                            break;
                        case 2:
                            TypPaliwa = "elektryczny";
                            dobryInput = true;
                            break;
                        case 3:
                            TypPaliwa = "diesel";
                            dobryInput = true;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("WYBRANO NIEPRAWIDŁOWY RODZAJ PALIWA");
                            Thread.Sleep(10000);
                            Console.ForegroundColor = ConsoleColor.White;
                            printOpcjePaliwo();
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("NIEPOPRAWNY INPUT");
                    Thread.Sleep(10000);
                    Console.ForegroundColor = ConsoleColor.White;
                    printOpcjePaliwo();
                }
            }
            Console.Clear();
            int dniWynajmu = 1;
            Console.WriteLine("PODAJ ILOŚĆ DNI WYNAJMU POJAZDU:");
            dobryInput = false;
            while (!dobryInput)
            {
                string input3 = Console.ReadLine();
                int value;
                if (int.TryParse(input3, out value))
                {
                    dniWynajmu = value;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("NIEPOPRAWNY INPUT");
                    Thread.Sleep(10000);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine("PODAJ ILOŚĆ DNI WYNAJMU POJAZDU:");
                }
            }
        }
    }
}
