using System;

namespace Proyecto_Naval
{
    class Program
    {   
        private int contadorJugador = 3;
        private int contadorOponente = 3;
        //Puntaje, Nombre
        private string[] jugador = {"0",""};
        private string[] oponente = {"0",""};
        private string[] barcoj1 = {"2","2","H","4"};
        private string[] barcoj2 = {"6","1","H","4"};
        private string[] barcoj3 = {"8","5","H","2"};
        private string[] barcoj4 = {"2","8","V","3"};
        private string[] barcoj5 = {"6","9","V","4"};
        private string[] barcoO1 = {"3","2","H","2"};
        private string[] barcoO2 = {"5","1","H","3"};
        private string[] barcoO3 = {"4","5","H","4"};
        private string[] barcoO4 = {"1","8","V","2"};
        private string[] barcoO5 = {"3","9","V","2"};

        static void Main(string[] args)
        {
            matrizJugador();
        }
        public static void Menu(){
            Program instancia = new Program();
            Console.WriteLine("Hola bienvenido a Battle Ship");
            Console.WriteLine("Que deseas hacer hoy ?");
            Console.WriteLine("1. Jugar");
            Console.WriteLine("2. Como jugar");
            Console.WriteLine("3. Salir");
            int decision = int.Parse(Console.ReadLine());
            switch (decision)
            {
                case 1:
                    ObtenerDatos();
                break;
                case 2:
                    Console.WriteLine("Lorem");
                    Console.WriteLine("Deseas jugar ?");
                    string jugar = Console.ReadLine().ToLower();
                    if(jugar == "si"){
                        ObtenerDatos();
                    }else{
                        instancia.LimpiarPantalla();
                        Menu();
                    }
                break;
                case 3:
                    Environment.Exit(0);
                break;
                default:
                    Console.WriteLine("Esta opcion no es valida :(");
                    instancia.LimpiarPantalla();
                    Menu();
                break;
            }
        }
        
        public static void ObtenerDatos(){
            Program jugadores = new Program();
            Console.Clear();
            Console.WriteLine("Dime tu nombre, tu seras el jugador");
            jugadores.jugador[1] = Console.ReadLine().ToLower();
            Console.WriteLine("Dime tu nombre, tu seras el oponente");
            jugadores.oponente[1] = Console.ReadLine().ToLower();
            Console.Clear();
            Console.WriteLine("Listo, Bienvendidos ");
            Console.WriteLine("Hola " + jugadores.jugador[1] + " Tu puntaje inicial es " + jugadores.jugador[0]);
            Console.WriteLine("Hola " + jugadores.oponente[1] + " Tu puntaje inicial es " + jugadores.oponente[0]);
            GenerarJuego();
        }
        public static void GenerarJuego(){
            Program instancia = new Program();
            ConsoleKeyInfo cki;
            while (instancia.contadorJugador != 0 && instancia.contadorOponente != 0){
                Console.WriteLine("Presiona enter para continuar");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.S){
                    Console.WriteLine("Se presiono la letra S");
                    Environment.Exit(0);
                }
                instruccionesJugador();
                instancia.quitarPuntoJugador();
                instancia.LimpiarPantalla();
                instruccionesOponente();
                instancia.quitarPuntoOponente();
                Console.WriteLine("contador oponente "+  instancia.obtenerTurnoOponente());
                instancia.LimpiarPantalla();
            }

        } 
        public static void instruccionesJugador(){
                Program instancia = new Program();
                Console.WriteLine("Es tu turno Jugador " + instancia.jugador[1]);
                Console.WriteLine("-------------------------------------- Jugador ----------------------------------------------");
                matrizJugador();
                Console.WriteLine("-------------------------------------- Oponente ----------------------------------------------");
                matrizInicial();
                Console.WriteLine("Que cordenada deseas ? ");
                Console.ReadLine();
        }
        public static void instruccionesOponente(){
                Program instancia = new Program();
                Console.WriteLine("-------------------------------------- "+ instancia.oponente[1] + " ----------------------------------------------");
                matrizOponente();
                Console.WriteLine("-------------------------------------- "+ instancia.jugador[1] + " ----------------------------------------------");
                matrizInicial();
                Console.WriteLine("Que cordenada deseas ? ");
                Console.ReadLine();
        }
        public static void matrizInicial(){
            Program instancia = new Program();
            string[,] tablero = new string[10,9];
            //tablero[2, 5] = instancia.barco;
            //Comienza la construccion de la tabla
            for (int f = 0; f < tablero.GetLength(0); f++){
                Console.Write(f+1 + " | ");
                for (int c = 0; c < tablero.GetLength(1); c++){
                    //Valor de la tabla inicial
                    tablero[f,c] = " . ";
                    //Como se separara los caracteres
                    Console.Write(tablero[f,c]);
                }
                Console.WriteLine();
            }
            //Termina construccion de tabla
        } 
        public static void matrizJugador(){
            Program instancia = new Program();
            int filas = 10;
            int columnas = 9;
            string[,] matrizJugador =  new string[filas+1,columnas+1];   
            for (int f = 1; f < matrizJugador.GetLength(0); f++){
                Console.Write(f + " | ");
                for (int c = 1; c < matrizJugador.GetLength(1); c++){
                    //Valor de la tabla inicial
                    matrizJugador[f,c] = " . ";
                    //Variables de barcos
                    int bx1 = int.Parse(instancia.barcoj1[0]);
                    int by1 = int.Parse(instancia.barcoj1[1]);
                    //Barco 2
                    int bx2 = int.Parse(instancia.barcoj2[0]);
                    int by2 = int.Parse(instancia.barcoj2[1]);
                    //Barco 3
                    int bx3 = int.Parse(instancia.barcoj3[0]);
                    int by3 = int.Parse(instancia.barcoj3[1]);
                    //Barco 4
                    int bx4 = int.Parse(instancia.barcoj4[0]);
                    int by4 = int.Parse(instancia.barcoj4[1]);
                    //Barco 5
                    int bx5 = int.Parse(instancia.barcoj5[0]);
                    int by5 = int.Parse(instancia.barcoj5[1]);
                    //Validaciones para imprimir los barcos
                        //Validacion barco 1
                            //Validacion de que no quepa
                    if(bx1 >= matrizJugador.GetLength(0) || by1 >= matrizJugador.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.1 no cabe en el tablero");
                    }else{ 
                        //Validacion de que no este repetido
                        if(bx1 == bx2 && bx1 == bx3 && bx1 == bx4 && bx1 == bx5 && by1 == by2 && by1 == by3 && by1 == by4 && by1 == by5){
                            Console.WriteLine("Parece que el barco no.1 esta duplicado");

                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(instancia.barcoj1[3]) == 2){
                               matrizJugador[bx1,by1]=" B ";
                            }else if(int.Parse(instancia.barcoj1[3]) == 3){
                               matrizJugador[bx1,by1]=" B ";
                            }else if(int.Parse(instancia.barcoj1[3]) == 4){
                                matrizJugador[bx1,by1]=" B ";
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 1");
                            }
                        }
                    }
                    //Validacion barco 2
                        //Validacion de que no quepa
                    if(bx2 >= matrizJugador.GetLength(0) || by2 >= matrizJugador.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.2 no cabe en el tablero");
                    }else{
                        //Validacion de que no este repetido
                         if(bx2 == bx1 && bx2 == bx3 && bx2 == bx4 && bx2 == bx5 && by2 == by1 && by2 == by3 && by2 == by4 && by2 == by5){
                            Console.WriteLine("Parece que el barco no.2 esta duplicado");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(instancia.barcoj2[3]) == 2){
                                matrizJugador[bx2,by2]=" B ";
                            }else if(int.Parse(instancia.barcoj2[3]) == 3){
                                matrizJugador[bx2,by2]=" B ";
                            }else if(int.Parse(instancia.barcoj2[3]) == 4){
                                matrizJugador[bx2,by2]=" B ";
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 2");
                            }
                        }
                    }
                    //Validacion barco 3
                        //Validacion de que no quepa
                    if(bx3 >= matrizJugador.GetLength(0) || by3 >= matrizJugador.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.3 no cabe en el tablero");
                    }else{
                            //Validacion de que no este repetido
                         if(bx3 == bx1 && bx3 == bx2 && bx3 == bx4 && bx3 == bx5 && by3 == by1 && by3 == by2 && by3 == by4 && by3 == by5){
                            Console.WriteLine("Parece que el barco no.3 esta duplicado");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(instancia.barcoj3[3]) == 2){
                                matrizJugador[bx3,by3]=" B ";
                            }else if(int.Parse(instancia.barcoj3[3]) == 3){
                                matrizJugador[bx3,by3]=" B ";                                                        
                            }else if(int.Parse(instancia.barcoj3[3]) == 4){
                                matrizJugador[bx3,by3]=" B ";
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 3");
                            }
                        }
                    }
                    //Validacion barco 4
                        //Validacion de que no quepa
                    if(bx4 >= matrizJugador.GetLength(0) || by4 >= matrizJugador.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.4 no cabe en el tablero");
                    }else{
                            //Validacion de que no este repetido
                         if(bx4 == bx1 && bx4 == bx2 && bx4 == bx3 && bx4 == bx5 && by4 == by1 && by4 == by2 && by4 == by3 && by4 == by5){
                            Console.WriteLine("Parece que el barco no.4 esta duplicado");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(instancia.barcoj4[3]) == 2){
                            matrizJugador[bx4,by4]=" B ";
                            }else if(int.Parse(instancia.barcoj4[3]) == 3){
                            matrizJugador[bx4,by4]=" B ";                                                      
                            }else if(int.Parse(instancia.barcoj4[3]) == 4){
                            matrizJugador[bx4,by4]=" B ";
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 4");
                            }
                        }
                    }
                    //Validacion barco 5
                        //Validacion de que no quepa
                    if(bx5 >= matrizJugador.GetLength(0) || by5 >= matrizJugador.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.5 no cabe en el tablero");
                    }else{
                        //Validacion de que no este repetido
                        if(bx5 == bx1 && bx5 == bx2 && bx5 == bx3 && bx5 == bx4 && by5 == by1 && by5 == by2 && by5 == by3 && by5 == by4){
                            Console.WriteLine("Parece que el barco no.5 esta duplicado");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(instancia.barcoj4[3]) == 2){
                            matrizJugador[bx5,by5]=" B ";
                            }else if(int.Parse(instancia.barcoj4[3]) == 3){
                            matrizJugador[bx5,by5]=" B ";                                               
                            }else if(int.Parse(instancia.barcoj4[3]) == 4){
                            matrizJugador[bx5,by5]=" B ";
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 5");
                            }
                        }
                    }
                    Console.Write(matrizJugador[f,c]);
                }
                Console.WriteLine();
            }
        }
        public static void matrizOponente(){
            Program instancia = new Program();
            int filas = 10;
            int columnas = 9;
            string[,] matrizOponente =  new string[filas+1,columnas+1];   
            for (int f = 1; f < matrizOponente.GetLength(0); f++){
                Console.Write(f + " | ");
                for (int c = 1; c < matrizOponente.GetLength(1); c++){
                    //Valor de la tabla inicial
                    matrizOponente[f,c] = " . ";
                    //Variables de barcos
                    int bxo1 = int.Parse(instancia.barcoO1[0]);
                    int byo1 = int.Parse(instancia.barcoO1[1]);
                    //Barco 2
                    int bxo2 = int.Parse(instancia.barcoO2[0]);
                    int byo2 = int.Parse(instancia.barcoO2[1]);
                    //Barco 3
                    int bxo3 = int.Parse(instancia.barcoO3[0]);
                    int byo3 = int.Parse(instancia.barcoO3[1]);
                    //Barco 4
                    int bxo4 = int.Parse(instancia.barcoO4[0]);
                    int byo4 = int.Parse(instancia.barcoO4[1]);
                    //Barco 5
                    int bxo5 = int.Parse(instancia.barcoO5[0]);
                    int byo5 = int.Parse(instancia.barcoO5[1]);
                    //Validaciones para imprimir los barcos
                        //Validacion barco 1
                            //Validacion de que no quepa
                    if(bxo1 >= matrizOponente.GetLength(0) || byo1 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.2 no cabe en el tablero");
                    }else{ 
                        //Validacion de que no este repetido
                        if(bxo1 == bxo2 && bxo1 == bxo3 && bxo1 == bxo4 && bxo1 == bxo5 && byo1 == byo2 && byo1 == byo3 && byo1 == byo4 && byo1 == byo5){
                            Console.WriteLine("Parece que el barco no.1 esta duplicado");

                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(instancia.barcoj1[3]) == 2){
                               matrizOponente[bxo1,byo1]=" B ";
                            }else if(int.Parse(instancia.barcoj1[3]) == 3){
                               matrizOponente[bxo1,byo1]=" B ";
                            }else if(int.Parse(instancia.barcoj1[3]) == 4){
                                matrizOponente[bxo1,byo1]=" B ";
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 1");
                            }
                        }
                    }
                    //Validacion barco 2
                        //Validacion de que no quepa
                    if(bxo2 >= matrizOponente.GetLength(0) || byo2 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.2 no cabe en el tablero");
                    }else{
                        //Validacion de que no este repetido
                         if(bxo2 == bxo1 && bxo2 == bxo3 && bxo2 == bxo4 && bxo2 == bxo5 && byo2 == byo1 && byo2 == byo3 && byo2 == byo4 && byo2 == byo5){
                            Console.WriteLine("Parece que el barco no.2 esta duplicado");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(instancia.barcoj2[3]) == 2){
                                matrizOponente[bxo2,byo2]=" B ";
                            }else if(int.Parse(instancia.barcoj2[3]) == 3){
                                matrizOponente[bxo2,byo2]=" B ";
                            }else if(int.Parse(instancia.barcoj2[3]) == 4){
                                matrizOponente[bxo2,byo2]=" B ";
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 2");
                            }
                        }
                    }
                    //Validacion barco 3
                        //Validacion de que no quepa
                    if(bxo3 >= matrizOponente.GetLength(0) || byo3 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.3 no cabe en el tablero");
                    }else{
                            //Validacion de que no este repetido
                         if(bxo3 == bxo1 && bxo3 == bxo2 && bxo3 == bxo4 && bxo3 == bxo5 && byo3 == byo1 && byo3 == byo2 && byo3 == byo4 && byo3 == byo5){
                            Console.WriteLine("Parece que el barco no.3 esta duplicado");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(instancia.barcoj3[3]) == 2){
                                matrizOponente[bxo3,byo3]=" B ";
                            }else if(int.Parse(instancia.barcoj3[3]) == 3){
                                matrizOponente[bxo3,byo3]=" B ";                                                        
                            }else if(int.Parse(instancia.barcoj3[3]) == 4){
                                matrizOponente[bxo3,byo3]=" B ";
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 3");
                            }
                        }
                    }
                    //Validacion barco 4
                        //Validacion de que no quepa
                    if(bxo4 >= matrizOponente.GetLength(0) || byo4 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.4 no cabe en el tablero");
                    }else{
                            //Validacion de que no este repetido
                         if(bxo4 == bxo1 && bxo4 == bxo2 && bxo4 == bxo3 && bxo4 == bxo5 && byo4 == byo1 && byo4 == byo2 && byo4 == byo3 && byo4 == byo5){
                            Console.WriteLine("Parece que el barco no.4 esta duplicado");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(instancia.barcoj4[3]) == 2){
                            matrizOponente[bxo4,byo4]=" B ";
                            }else if(int.Parse(instancia.barcoj4[3]) == 3){
                            matrizOponente[bxo4,byo4]=" B ";                                                      
                            }else if(int.Parse(instancia.barcoj4[3]) == 4){
                            matrizOponente[bxo4,byo4]=" B ";
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 4");
                            }
                        }
                    }
                    //Validacion barco 5
                        //Validacion de que no quepa
                    if(bxo5 >= matrizOponente.GetLength(0) || byo5 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.5 no cabe en el tablero");
                    }else{
                        //Validacion de que no este repetido
                        if(bxo5 == bxo1 && bxo5 == bxo2 && bxo5 == bxo3 && bxo5 == bxo4 && byo5 == byo1 && byo5 == byo2 && byo5 == byo3 && byo5 == byo4){
                            Console.WriteLine("Parece que el barco no.5 esta duplicado");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(instancia.barcoj4[3]) == 2){
                            matrizOponente[bxo5,byo5]=" B ";
                            }else if(int.Parse(instancia.barcoj4[3]) == 3){
                            matrizOponente[bxo5,byo5]=" B ";                                               
                            }else if(int.Parse(instancia.barcoj4[3]) == 4){
                            matrizOponente[bxo5,byo5]=" B ";
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 5");
                            }
                        }
                    }
                    Console.Write(matrizOponente[f,c]);
                }
                Console.WriteLine();
            }
        }
    
        public void LimpiarPantalla(){
            Console.Clear();
        }
        //Getter y setters para los jugadores
        public int obtenerTurnoJugador(){
            return this.contadorJugador;
        }
        public int obtenerTurnoOponente(){
            return this.contadorOponente;
        }
    
        public void quitarPuntoJugador(){
            this.contadorJugador = this.contadorJugador - 1;
        }
        public void quitarPuntoOponente(){
            this.contadorOponente = this.contadorOponente - 1;
        }

    }
}
