using System;

namespace Proyecto_Naval
{
    class Program
    {
        private string barco = "barco";
        static void Main(string[] args)
        {
            tabla();
        }

        public static void tabla(){
            Program instancia = new Program();
            string[,] tablero = new string[10,9];
            //Comienza la construccion de la tabla
            for (int f = 1; f < tablero.GetLength(0); f++){
                Console.Write(" | " + f + " | ");
                for (int c = 1; c < tablero.GetLength(1); c++){
                    Console.Write(tablero[c,0]);
                    //Valor de la tabla inicial
                    tablero[f,c] =  " " + " - " + " ";
                    //Posicion de barco
                    tablero[2, 5] = instancia.barco;
                    //Como se separara los caracteres
                    Console.Write(" | " +tablero[f,c]+ " | ");
                }
                Console.WriteLine();
            }
            //Termina construccion de tabla
        }
    }
}
