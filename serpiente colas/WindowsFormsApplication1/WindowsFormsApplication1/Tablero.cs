using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WindowsFormsApplication1
{
    class Tablero
    {

        /// <summary>
        /// Clase tablero que genera la cola donde almacena los puntos donde (Podria usarse Nodos para almacenar los puntos pero se usan arrays de pares)
        /// Se relaciona con juego  en 1 a 1
        /// 
        /// </summary>
        private Queue _mapa;
        private int _tamaño;
        public Tablero(int tamaño)
        {
            _tamaño = tamaño;
            _mapa = new Queue();
            
            generarNivelBase();
        }

        public Queue Mapa
        {
            get { return _mapa; }
            set { _mapa = value; }
        }




        //Genera las paredes bases 
        public void generarNivelBase()
        {
            int[] coordenadas = new int[2];

            for (int i = 0; i <_tamaño; i++)
            {
                for (int j = 0; j < _tamaño; j++)
                {
                    if (j == 0 || i == 0 || j == _tamaño -1 || i == _tamaño -1 )
                    {
                        coordenadas = new int[2];
                        coordenadas[0] = i;
                        coordenadas[1] = j;
                        _mapa.Enqueue(coordenadas);
                    }
                }
            }
        }
    }
}
    

