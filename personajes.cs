namespace gestionPersonajes
{
    
    class Chef
    {
        private string nombre; // Dps cambiar para que se obtenga de una API
        private int presentacion;
        private int creatividad;
        private int rapidez;
        private int sabor;
        private string especialidad;
        public string Nombre {get => nombre; set => nombre = value;}
        public int Presentacion {get => presentacion; set => presentacion = value;} // Rango de 1 a 10
        public int Creatividad {get => creatividad; set => creatividad = value;} // Rango de 1 a 10
        public int Rapidez {get => rapidez; set => rapidez = value;} // Rango de 1 a 10
        public int Sabor {get => sabor; set => sabor = value;} // Rango de 1 a 10
        public string Especialidad {get => especialidad; set => especialidad = value;}


        public Chef(string nombre, int presentacion, int creatividad, int rapidez, int sabor, string especialidad)
        {
            Nombre = nombre; // Dps cambiar para que se obtenga de una API
            Presentacion = presentacion;
            Creatividad = creatividad;
            Rapidez = rapidez;
            Sabor = sabor;
            Especialidad = especialidad;
        }

        public void mostrarInfoChef()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Especialidad: {Especialidad}");
        }
    }

    class Juez
    {
        private string nombre; // Dps cambiar para que se obtenga de una API
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