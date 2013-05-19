using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Timers;
using System.Drawing;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Clase encargada de establecer la comunicacion entre la logica y la visual, asi como de hacer ciertas funcionas comunes
    /// Genera los objetos de las demas clases relacionadas y crea una nueva comida cada vez que la serpiente colisiona con una comida
    /// Tambien es la encargada de comprobar si existen colisiones
    /// comidaCoor, n e y son variables temporales
    ///
    /// </summary>
    class Juego
    {
        // Genera todas los objetos 
        private Nodo n;
        private Tablero tablero;
        private Serpiente serpiente;
        private Comida comida;
        private int _tamaño=40;
        private int[] comidaCoor;
        private Boolean _hayFin;
        private int _contadorComida=100;
        private int _velocidad = 100;
        private int _nivel = 0;
       
 
        public Juego()
        {
            comidaCoor = new int[2];
       
            tablero = new Tablero(_tamaño,1);
            serpiente = new Serpiente(tablero.Mapa, _tamaño);
            generarComida();
        }

        //Transmite a serpiente la direccion actual
        public void cambiardireccion(int direccion)
        {
            serpiente.CambiarDireccion(direccion);
        }

        //Genera un nuevo objeto comida  y actualiza las coordenadas
        private void generarComida()
        {
            comida = new Comida(tablero.Mapa, serpiente. Cuerpo, _tamaño, serpiente.X, serpiente.Y);
            comidaCoor[0] = comida.X;
            comidaCoor[1] = comida.Y;
       
        }

        //Metodo llamado en cada tick del timer, mueve la serpiente y comprueba si hay colisiones
        public void actualizar(object sender, EventArgs e)
        {

            if (_contadorComida == 0)
            {
                generarComida();
                _contadorComida = 10;
            }
            else
                _contadorComida--;
            serpiente.Mover();
            colision();
        }
        //Busca si la posicion de la cabeza coincide con un nodo de la misma, del tablero o comida y acaba el juego o crea una nueva comida y crece
        private void colision() {
            System.Collections.IEnumerator ent = tablero.Mapa.GetEnumerator();
            System.Collections.IEnumerator ens = serpiente.Cuerpo.GetEnumerator();

            int[] coordenadas = new int[2];
            
            Boolean estaChocado = false;
            int numNodos = serpiente.Cuerpo.Count;

            
            while (ens.MoveNext() && !estaChocado && numNodos>1 )
            {
                numNodos--;
                n = (Nodo)ens.Current;
                if (n.X == serpiente.X && n.Y == serpiente.Y)
                    estaChocado = true;
                else
                    estaChocado = false;
            }

            while (ent.MoveNext() && !estaChocado)
                {
                    coordenadas = (int[])ent.Current;
                    if (coordenadas[0] == serpiente.X && coordenadas[1] == serpiente.Y)
                        estaChocado = true;
                    else
                        estaChocado = false;
                }
         
      
            
                if (serpiente.X == comida.X && serpiente.Y == comida.Y)
                {
                    serpiente.crecer(comida.Cantidad);
                    generarComida();
               
                }

                if (estaChocado)
                { 
                _hayFin=true;
                }
 
        }

        public Brush marcarComida() {

            if (_contadorComida > 8)
                return Brushes.Black;
            else
                return Brushes.Blue;
               
        }


        private void cambiarNivel() {
            _nivel++;
            _velocidad =+ 10;
        
        }

        public Boolean Fin
        {
            get { return _hayFin; }
            set { _hayFin = value; }
        }


        public Queue Tablero
        {
            get { return tablero.Mapa; }
            set { tablero.Mapa = value; }
        }


        public Queue CuerpoSerpiente
        {
            get { return serpiente.Cuerpo; }
            set { serpiente.Cuerpo = value; }
        }

        public int[] Comida
        {
            get { return comidaCoor; }
            set { comidaCoor = value; }
        }

        public int cantidadComida
        {
            get { return comida.Cantidad; }
            set { comida.Cantidad = value; }
        }

        public int Tamaño
        {
            get { return _tamaño; }
            set { _tamaño = value; }
        }

        public int Velocidad
        {
            get { return _velocidad; }
            set { _velocidad = value; }
        }


        public int Nivel
        {
            get { return _nivel; }
            set { _nivel = value; }
        }
    }
}
