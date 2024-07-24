namespace Juego
{
    
    public class Pastelero
    {
        private string nombre;
        private int presentacion;
        private int creatividad;
        private int rapidez;
        private int sabor;
        private string especialidad;
        private float puntuacionUltimaRonda;
        public string Nombre {get => nombre; set => nombre = value;}
        public int Presentacion {get => presentacion; set => presentacion = value;}
        public int Creatividad {get => creatividad; set => creatividad = value;}
        public int Rapidez {get => rapidez; set => rapidez = value;}
        public int Sabor {get => sabor; set => sabor = value;}
        public string Especialidad {get => especialidad; set => especialidad = value;}
        public float PuntuacionUltimaRonda {get => puntuacionUltimaRonda; set => puntuacionUltimaRonda = value;}

        public Pastelero(string nombre, int presentacion, int creatividad, int rapidez, int sabor, string especialidad)
        {
            Nombre = nombre;
            Presentacion = presentacion;
            Creatividad = creatividad;
            Rapidez = rapidez;
            Sabor = sabor;
            Especialidad = especialidad;
        }

        /// <summary>
        /// Muestra por pantalla el nombre y la especialidad del pastelero.
        /// </summary>
        public void MostrarInfoPastelero()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Especialidad: {Especialidad}");
        }
    }

    class Juez
    {
        private string nombre;
        private int ecuacionPuntua;
        public string Nombre {get => nombre; set => nombre = value;}
        public int EcuacionPuntua {get => ecuacionPuntua; set => ecuacionPuntua = value;}

        public Juez(string nombre, int ec)
        {
            Nombre = nombre;
            ecuacionPuntua = ec;
        }

        /// <summary>
        /// Calcula la puntuación total que recibe un pastelero basada en sus atributos y el juez que evalúa.
        /// </summary>
        /// <param name="creatividad">La puntuación de creatividad.</param>
        /// <param name="presentacion">La puntuación de presentación.</param>
        /// <param name="rapidez">La puntuación de rapidez.</param>
        /// <param name="sabor">La puntuación de sabor.</param>
        /// <param name="plato">La puntuación del plato.</param>
        /// <returns>La puntuación total calculada según la ecuación seleccionada.</returns>
        public float CalcularPuntuacion(int creatividad, int presentacion, int rapidez, int sabor, float plato)
        {
            float puntuacion = 0;
            switch (ecuacionPuntua)
            {
                case 1:
                {
                    puntuacion = (float)(0.6 * plato + 0.2*rapidez + 0.1*sabor + 0.05*presentacion + 0.05*creatividad);
                    break;
                }
                case 2:
                {
                    puntuacion = (float)(0.6 * plato + 0.1*rapidez + 0.05*sabor + 0.05*presentacion + 0.2*creatividad);
                    break;
                }
                case 3:
                {
                    puntuacion = (float)(0.6 * plato + 0.05*rapidez + 0.05*sabor + 0.2*presentacion + 0.1*creatividad);
                    break;
                }
                case 4:
                {
                    puntuacion = (float)(0.6 * plato + 0.05*rapidez + 0.2*sabor + 0.05*presentacion + 0.1*creatividad);
                    break;
                }
            }
            return puntuacion;
        }
    }
}