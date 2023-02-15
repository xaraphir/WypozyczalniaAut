namespace WypozyczalniaAut
{
    internal class Klienciwypozyczalni
    {
        public Klienciwypozyczalni()
        {
            CreateClients();
        }
        public List<Client> Clients { get; set; } = new List<Client>();
        private void CreateClients()
        {
            Clients.Add(new Client(1, "Jan Nowak", new DateTime(2021, 03, 04)));
            Clients.Add(new Client(2, "Agnieszka Kowalska", new DateTime(1999, 01, 15)));
            Clients.Add(new Client(3, "Robert Lewandowski", new DateTime(2010, 12, 18)));
            Clients.Add(new Client(4, "Zofia Plucińska", new DateTime(2020, 04, 29)));
            Clients.Add(new Client(5, "Grzegorz Braun", new DateTime(2015, 07, 12)));
        }
        public Client getClientById(int id)
        {
            foreach (var client in this.Clients)
            {
                if (id == client.ClientId)
                    return client;
            }
            return null;
        }

    }
    public class autawypozyczalni
    {
        public autawypozyczalni()
        {
            CreateCars();
        }
        public List<Car> Cars { get; set; } = new List<Car>();
        private void CreateCars()
        {
            Cars.Add(new Car(1, "Škoda Citigo", "mini", "benzyna", 70m));
            Cars.Add(new Car(2, "Toyota Aygo", "mini", "benzyna", 90m));
            Cars.Add(new Car(3, "Fiat 500", "mini", "elektryczny", 110m));
            Cars.Add(new Car(4, "Ford Focus", "kompakt", "diesel", 160m));
            Cars.Add(new Car(5, "Kia Ceed", "kompakt", "benzyna", 150m));
            Cars.Add(new Car(6, "Volkswagen Golf", "kompakt", "benzyna", 160m));
            Cars.Add(new Car(7, "Hyundai Kona Electric", "kompakt", "elektryczny", 180m));
            Cars.Add(new Car(8, "Audi A6 Allroad", "premium", "diesel ", 290m));
            Cars.Add(new Car(9, "Mercedes E270 AMG", "premium", "benzyna", 320m));
            Cars.Add(new Car(10, "Tesla Model S", "premium", "elektryczny", 350m));
        }
        public Car getCarBySegmentPaliwo(string Segment, string TypPaliwa)
        {
            foreach (var car in this.Cars)
            {
                if (Segment == car.Segment)
                {
                    if (TypPaliwa == car.Paliwo)
                        return car;
                }
            }
            return null;
        }
    }
}
