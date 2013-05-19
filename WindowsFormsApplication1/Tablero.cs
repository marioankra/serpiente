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
        private int _nivel;
        public Tablero(int tamaño,int nivel)
        {
            _nivel=nivel;
            _tamaño = tamaño;
            _mapa = new Queue();
            
            generarNivelBase();

            switch (_nivel)
            {
                case 1:
                    generarNivel1();
                    break;
               case 2:
                    generarNivel2();
                    break;
               case 3:
                    generarNivel1();
                    generarNivel2();
                    break;
               case 4:
                    generarNivel4();
                    break;
          }




        }

        public Queue Mapa
        {
            get { return _mapa; }
            set { _mapa = value; }
        }




        //Genera las paredes bases 
        private void generarNivelBase()
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

        private void generarNivel1() {
            Random r = new Random(DateTime.Now.Millisecond);
            int[] coordenadas;
            for (int i = 0; i < 10; i++) {
                coordenadas = new int[2];
                coordenadas[0] = r.Next(1, _tamaño - 1);
                coordenadas[1] = r.Next(1, _tamaño - 1);
                _mapa.Enqueue(coordenadas);
            
            } 
        }

        private void generarNivel2()
        {
            int[] rectaH;
            
            Random r = new Random(DateTime.Now.Millisecond);
            int[] coordenadas;
            for (int i = 0; i < 3; i++)
            {
                rectaH= new int[3];
                rectaH[0] = r.Next(2, _tamaño - 2);
                rectaH[1] = r.Next(2, _tamaño - 2);
                rectaH[2] = r.Next(2, _tamaño - 2);

                if(rectaH[0] > rectaH[1]){
                    int aux=rectaH[0];
                    rectaH[0]=rectaH[1];
                    rectaH[1]=aux;
                }
                for (int j = rectaH[0]; j <= rectaH[1]; j++) { 
                coordenadas = new int[2];
                coordenadas[0] = j;
                coordenadas[1] = rectaH[2];
                _mapa.Enqueue(coordenadas);
                
                }
            }

            for (int i = 0; i < 3; i++)
            {
                rectaH = new int[3];
                rectaH[0] = r.Next(2, _tamaño - 2);
                rectaH[1] = r.Next(2, _tamaño - 2);
                rectaH[2] = r.Next(2, _tamaño - 2);

                if (rectaH[0] > rectaH[1])
                {
                    int aux = rectaH[0];
                    rectaH[0] = rectaH[1];
                    rectaH[1] = aux;
                }
                for (int j = rectaH[0]; j <= rectaH[1]; j++)
                {
                    coordenadas = new int[2];
                    coordenadas[1] = j;
                    coordenadas[0] = rectaH[2];
                    _mapa.Enqueue(coordenadas);

                }
            }


        }

        private void generarNivel4()
        {
            int[] coordenadas = new int[2];

            for (int i = 0; i < _tamaño; i++)
            {
                for (int j = 0; j < _tamaño; j++)
                {
                    if (i%2 !=0 && j%2 !=0)
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
    

