using System.Reflection.Emit;

namespace WypozyczalniaAut
{
    internal static class Ekran
    {
        public static void PokazOpcje()
        {
            Console.WriteLine("WYBIERZ OPCJĘ ");
            Console.WriteLine(" ");
            Console.WriteLine("1 => LISTA KLIENTÓW I SAMOCHODÓW");
            Console.WriteLine(" ");
            Console.WriteLine("2 => WYPOŻYCZENIE SAMOCHODÓW");
            Console.WriteLine(" ");
            Console.WriteLine("3 => ZAKOŃCZ PROGRAM");
            Console.WriteLine(" ");
            Console.WriteLine("WYBIERZ 1,2 LUB 3: ");
            /*
            Console.WriteLine("---------------------");
            Console.WriteLine("Michał Nowakowski 113806");
            Console.WriteLine("Jakub Nawrocki 99762");
            Console.WriteLine("Konrad Pietrzyk 116901");
            Console.WriteLine("Bartosz Omiotek 113969");
            Console.WriteLine("Praca na zaliczenie");
            Console.WriteLine("---------------------");
            */
            WybierzOpcje();
        }
        public static void WybierzOpcje()
        {

            string klawisz = Console.ReadLine();
            while (true)
            {
                int value;
                if (int.TryParse(klawisz, out value))
                {
                    switch (value)
                    {
                        case 1:
                            Opcje.Jeden();
                            break;
                        case 2:
                            Opcje.Dwa();
                            break;
                        case 3:
                            Opcje.Trzy();
                            break;
                        case 4:
                            Opcje.Cztery();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Wybierz prawidłową cyfrę");
                            PokazOpcje();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Podaj liczbę!");
                    PokazOpcje();
                }
            }
        }
        public static void PokazKlientow()
        {
            Console.WriteLine("LISTA KLIENTÓW:");
            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------");
            Console.WriteLine(string.Format("", "Id", "Imię i nazwisko", "Data wydania prawa jazdy"));
            Klienciwypozyczalni clients = new Klienciwypozyczalni();
            foreach (var client in clients.Clients)
            {
                Console.WriteLine(string.Format($"{client.ClientId} " + $"| {client.FullName} " + $"| {client.PrawoJazdy.ToShortDateString()}"));
            }
            Console.WriteLine(" ");
            Console.WriteLine("LISTA SAMOCHODOW:");
            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------");
            Console.WriteLine(string.Format("Id |" + "Model |" + "Segment |" + "Rodzaj Paliwa |" + "Cena za dobę"));
            autawypozyczalni cars = new autawypozyczalni();
            foreach (var Car in cars.Cars)
            {
                Console.WriteLine(string.Format($" {Car.CarId}" + $" | {Car.Marka}" + $" | {Car.Segment}" + $" | {Car.Paliwo}" + $" | {Car.Cena} PLN"));
            }
            Console.WriteLine(" ");
        }
    }
}



