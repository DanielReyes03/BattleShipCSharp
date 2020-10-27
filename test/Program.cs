using System;

namespace test
{
    class Program
    {
            private string[] barcoj1 = {"2","2","H","4"};
            static void Main(string[] args)
            {
                matrizInicial();
            }
           public static void matrizInicial(){
            Program instancia = new Program();
            string[,] tablero = new string[10,10];
            //tablero[2, 5] = instancia.barco;
            //Comienza la construccion de la tabla
            for (int f = 0; f < tablero.GetLength(0); f++){
                Console.Write(f + " | ");
                for (int c = 0; c < tablero.GetLength(1); c++){
                    //Valor de la tabla inicial
                    tablero[f,c] = " . ";
                    //Como se separara los caracteres
                    int bx1 = int.Parse(instancia.barcoj1[0]);
                    int by1 = int.Parse(instancia.barcoj1[1]);

                    if(bx1 >= tablero.GetLength(0) || by1 >= tablero.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.1 no cabe en el tablero");
                    }else{
                        if(instancia.barcoj1[2] == "H"){
                            tablero[bx1,by1] = " Barco ";
                            for (int i = 1; i <= int.Parse(instancia.barcoj1[3]); i++)
                            {
                                tablero[bx1,by1+i] = " Barco ";
                            }
                        }else if(instancia.barcoj1[2] == "V"){
                            for (int i = 1; i <= int.Parse(instancia.barcoj1[3]); i++)
                            {
                                tablero[bx1+i,by1] = " Barco ";
                            }
                        }
                    }
                    Console.Write(tablero[f,c]);
                }
                Console.WriteLine();
            }
            //Termina construccion de tabla
        } 
    }
}
