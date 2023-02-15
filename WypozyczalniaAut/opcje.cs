namespace WypozyczalniaAut
{
    internal class Opcje
    {
        public static void Jeden()
        {
            Console.Clear();
            Ekran.PokazKlientow();

            Ekran.PokazOpcje();
        }
        public static void Dwa()
        {
            Kalkulator.WypozyczalniaKalkulator();
        }
        public static void Trzy()
        {
            Console.Clear();
            Ekran.PokazOpcje();
        }
        public static void Cztery()
        {
            Console.Clear();
            Environment.Exit(0);
        }
    }
}