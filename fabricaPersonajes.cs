namespace Juego
{
    class fabricaDePersonajes
    {
        public List<Pastelero> crearPasteleros()
        {
            var semilla = Environment.TickCount;
            var rnd = new Random();
            List<Pastelero> Pasteleros= new List<Pastelero>();
            Pastelero pasteleroCreativo = new Pastelero(new Api().NombrePastelero(), rnd.Next(0, 4), 4, rnd.Next(0, 3), rnd.Next(0, 2), "Creatividad");
            Pastelero pasteleroEstetico = new Pastelero(new Api().NombrePastelero(), 4, rnd.Next(0, 4), rnd.Next(0, 2), rnd.Next(0, 3), "Presentacion");
            Pastelero pasteleroRapido = new Pastelero(new Api().NombrePastelero(), rnd.Next(0, 2), rnd.Next(0, 3) , 4, rnd.Next(0, 4), "Rapidez");
            Pastelero pasteleroSabroso = new Pastelero(new Api().NombrePastelero(), rnd.Next(0, 3), rnd.Next(0, 2), rnd.Next(0, 4), 4, "Combinacion de sabores");
            Pasteleros.Add(pasteleroCreativo);
            Pasteleros.Add(pasteleroEstetico);
            Pasteleros.Add(pasteleroRapido);
            Pasteleros.Add(pasteleroSabroso);
            return Pasteleros;
        }

        public List<Juez> crearJueces()
        {
            List<Juez> jueces= new List<Juez>();
            Juez JuezRapido = new Juez("Maru Botana", 1);
            Juez JuezCreativo = new Juez("Pamela Villar", 2);
            Juez JuezEstetico = new Juez("Eva Arguinano", 3);
            Juez JuezSabroso = new Juez("Dolly Irigoyen", 4);
            jueces.Add(JuezCreativo);
            jueces.Add(JuezEstetico);
            jueces.Add(JuezRapido);
            jueces.Add(JuezSabroso);
            return jueces;
        }
    }
}