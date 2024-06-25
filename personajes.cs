namespace Juego
{
    
    class Pastelero
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

        public void mostrarInfoPastelero()
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

        public float calcularPuntuacion(int creatividad, int presentacion, int rapidez, int sabor, float plato)
        {
            float puntuacion = 0;
            switch (ecuacionPuntua)
            {
                case 1:
                {
                    puntuacion = (float)(0.5 * plato + 0.2*rapidez + 0.1*sabor + 0.1*presentacion + 0.1*creatividad);
                    break;
                }
                case 2:
                {
                    puntuacion = (float)(0.5 * plato + 0.2*rapidez + 0.1*sabor + 0.1*presentacion + 0.1*creatividad);
                    break;
                }
                case 3:
                {
                    puntuacion = (float)(0.5 * plato + 0.2*rapidez + 0.1*sabor + 0.1*presentacion + 0.1*creatividad);
                    break;
                }
                case 4:
                {
                    puntuacion = (float)(0.5 * plato + 0.2*rapidez + 0.1*sabor + 0.1*presentacion + 0.1*creatividad);
                    break;
                }
            }
            return puntuacion;
        }
    }
}