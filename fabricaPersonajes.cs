namespace Juego
{
    class FabricaDePersonajes
    {

        public static List<Juez> CrearJueces()
        {
            var jueces= new List<Juez>();
            string[] nombres = ["Maru Botana", "Pamela Villar", "Eva Arguinano", "Dolli Irigoyen"];
            for (int i = 1; i <= nombres.Length; i++)
            {
                var nuevoJuez = new Juez(nombres[i], i);
                jueces.Add(nuevoJuez);
            }
            return jueces;
        }

        public static List<Pastelero> CrearPasteleros()
        {
            string[] tipos = ["Creativo", "Estetico", "Sabroso", "Rapido"];
            string[] listaNombres = Api.NombresPasteleros();
            var Pasteleros = new List<Pastelero>();

            for (int i = 0; i < tipos.Length; i++)
            {
                Pastelero NuevoPastelero = CrearPasteleroSegunTipo(listaNombres[i], tipos[i]);
                Pasteleros.Add(NuevoPastelero);
            }

            return Pasteleros;
        }

        public static Pastelero CrearPasteleroSegunTipo(string nombre, string tipo)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            Pastelero NuevoPastelero = null;

            if (tipo == "Creativo")
            {
                NuevoPastelero = new Pastelero(nombre, rnd.Next(0, 4), 4, rnd.Next(0, 3), rnd.Next(0, 2), "Creatividad");
            }
            else if (tipo == "Estetico")
            {
                NuevoPastelero = new Pastelero(nombre, 4, rnd.Next(0, 4), rnd.Next(0, 2), rnd.Next(0, 3), "Presentacion");
            }
            else if (tipo == "Rapido")
            {
                NuevoPastelero = new Pastelero(nombre, rnd.Next(0, 2), rnd.Next(0, 3), 4, rnd.Next(0, 4), "Rapidez");
            }
            else if (tipo == "Sabroso")
            {
                NuevoPastelero = new Pastelero(nombre, rnd.Next(0, 3), rnd.Next(0, 2), rnd.Next(0, 4), 4, "Combinacion de sabores");
            }

            return NuevoPastelero;
        }
    }
}