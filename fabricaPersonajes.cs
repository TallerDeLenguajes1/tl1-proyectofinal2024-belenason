using ProyectoTaller;

namespace gestionPersonajes
{
    class fabricaDePersonajes
    {
        public List<Chef> crearChefs()
        {
            var semilla = Environment.TickCount;
            var rnd = new Random();
            List<Chef> chefs= new List<Chef>();
            Chef chefCreativo = new Chef(new Api().obtenerNombreChefs(), rnd.Next(0, 3), 4, rnd.Next(0, 2), rnd.Next(0, 1), "Creatividad"); // presentacion, creatividad, rapidez, sabor
            Chef chefEstetico = new Chef(new Api().obtenerNombreChefs(), 4, rnd.Next(0, 3), rnd.Next(0, 1), rnd.Next(0, 2), "Presentacion");
            Chef chefRapido = new Chef(new Api().obtenerNombreChefs(), rnd.Next(0, 1), rnd.Next(0, 2) , 4, rnd.Next(0, 3), "Rapidez");
            Chef chefSabroso = new Chef(new Api().obtenerNombreChefs(), rnd.Next(0, 2), 1, rnd.Next(0, 3), 4, "Combinacion de sabores");
            chefs.Add(chefCreativo);
            chefs.Add(chefEstetico);
            chefs.Add(chefRapido);
            chefs.Add(chefSabroso);
            return chefs;
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