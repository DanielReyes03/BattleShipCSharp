using System;
using System.IO;
using System.Threading;
namespace Proyecto_Naval
{
    class Program
    {   
        private int contadorJugador = 3;
        private int contadorOponente = 3;
        //Puntaje, Nombre
        private string[] jugador = {"0",""};
        private string[] oponente = {"0",""};
        static void Main(string[] args)
        {        
           //instruccionesOponente();
           Menu();
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
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Hola " + jugadores.jugador[1] + " Tu puntaje inicial es " + jugadores.jugador[0]);
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Hola " + jugadores.oponente[1] + " Tu puntaje inicial es " + jugadores.oponente[0]);
            Console.WriteLine("--------------------------------------------------------------------------------------");
            GenerarJuego(jugadores.jugador[1],jugadores.oponente[1]);
        }
        public static void GenerarJuego(string jugador ,string Oponente){
            Program instancia = new Program();
            ConsoleKeyInfo cki;
            while (instancia.contadorJugador != 0 && instancia.contadorOponente != 0){
                Console.WriteLine("Presiona enter para continuar");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.S){
                    Console.WriteLine("Se presiono la letra S");
                    Environment.Exit(0);
                }
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Turnos restantes para "+ jugador + " " +  instancia.contadorJugador);
                Console.WriteLine("----------------------------------------");
                instruccionesJugador();
                instancia.quitarPuntoJugador();
                instancia.LimpiarPantalla();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Turnos restantes para "+ Oponente + " " +  instancia.contadorJugador);
                Console.WriteLine("----------------------------------------");
                instruccionesOponente();
                instancia.quitarPuntoOponente();
                instancia.LimpiarPantalla();
            }

        } 
        public static void instruccionesJugador(){
                Program instancia = new Program();
                Console.WriteLine("Es tu turno Jugador " + instancia.oponente[1]);
                Console.WriteLine("-------------------------------------- Jugador ----------------------------------------------");
                GenerarTXTJugador();
                Console.WriteLine("-------------------------------------- Oponente ----------------------------------------------");
                matrizInicial();
                Console.WriteLine("Es tu turno Jugador " + instancia.jugador[1]);
                Console.WriteLine("Que cordenada deseas ? ");
                string[] CordenadaAtaqueJugador = Console.ReadLine().Split(",");
                ModificarTXTJugador(CordenadaAtaqueJugador);
        }
        public static void instruccionesOponente(){
                Program instancia = new Program();
                Console.WriteLine("Es tu turno Oponente " + instancia.oponente[1]);
                Console.WriteLine("-------------------------------------- Oponente ----------------------------------------------");
                GenerarTXTOponente();
                Console.WriteLine("-------------------------------------- Jugador ----------------------------------------------");
                matrizInicial();
                Console.WriteLine("Que cordenada deseas ? ");
                string[] CordenadaAtaqueOponente = Console.ReadLine().Split(",");
                ModificarTXTOponente(CordenadaAtaqueOponente);
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
        public static void matrizJugador(string[] dimnesion, string[] barco1,string[] barco2,string[] barco3,string[] barco4,string[] barco5){
            Program instancia = new Program();
            int filas = int.Parse(dimnesion[0]);
            int columnas = int.Parse(dimnesion[1]);
            string[,] matrizJugador =  new string[filas,columnas];   
            for (int f = 1; f < matrizJugador.GetLength(0); f++){
                Console.Write(f + " | ");
                for (int c = 1; c < matrizJugador.GetLength(1); c++){
                    //Valor de la tabla inicial
                    matrizJugador[f,c] = " . ";
                    //Variables de barcos
                    int bx1 = int.Parse(barco1[0]);
                    int by1 = int.Parse(barco1[1]);
                    //Barco 2
                    int bx2 = int.Parse(barco2[0]);
                    int by2 = int.Parse(barco2[1]);
                    //Barco 3
                    int bx3 = int.Parse(barco3[0]);
                    int by3 = int.Parse(barco3[1]);
                    //Barco 4
                    int bx4 = int.Parse(barco4[0]);
                    int by4 = int.Parse(barco4[1]);
                    //Barco 5
                    int bx5 = int.Parse(barco5[0]);
                    int by5 = int.Parse(barco5[1]);
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
                            if(int.Parse(barco1[3]) == 2){
                                //Validacion de horizontal y posiciones
                                if(barco1[2] == "H"){
                                    matrizJugador[bx1,by1] = " B1 ";
                                    for (int i = 1; i < int.Parse(barco1[3]); i++)
                                    {
                                        matrizJugador[bx1,by1+i] = " B1 ";
                                    }
                                }else if(barco1[2] == "V"){
                                    for (int i = 1; i <= int.Parse(barco1[3]); i++)
                                    {
                                        matrizJugador[bx1+i,by1] = " B1 ";
                                    }
                                }
                            }else if(int.Parse(barco1[3]) == 3){
                              if(barco1[2] == "H"){
                                    matrizJugador[bx1,by1] = " B1 ";
                                    for (int i = 1; i < int.Parse(barco1[3]); i++)
                                    {
                                        matrizJugador[bx1,by1+i] = " B1 ";
                                    }
                                }else if(barco1[2] == "V"){
                                    for (int i = 1; i <= int.Parse(barco1[3]); i++)
                                    {
                                        matrizJugador[bx1+i,by1] = " B1 ";
                                    }
                                }
                            }else if(int.Parse(barco1[3]) == 4){
                               if(barco1[2] == "H"){
                                    matrizJugador[bx1,by1] = " B1 ";
                                    for (int i = 1; i < int.Parse(barco1[3]); i++)
                                    {
                                        matrizJugador[bx1,by1+i] = " B1 ";
                                    }
                                }else if(barco1[2] == "V"){
                                    for (int i = 1; i <= int.Parse(barco1[3]); i++)
                                    {
                                        matrizJugador[bx1+i,by1] = " B1 ";
                                    }
                                }
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
                            if(int.Parse(barco2[3]) == 2){
                                //Validacion de horizontal y posiciones
                                if(barco2[2] == "H"){
                                    matrizJugador[bx2,by2]=" B2 ";
                                    for (int i = 1; i < int.Parse(barco2[3]); i++)
                                    {
                                        matrizJugador[bx2,by2+i] = " B2 ";
                                    }
                                }else if(barco2[2] == "V"){
                                    for (int i = 1; i <= int.Parse(barco2[3]); i++)
                                    {
                                        matrizJugador[bx2+i,by2] = " B2 ";
                                    }
                                }
                            }else if(int.Parse(barco2[3]) == 3){
                                //Validacion de horizontal y posiciones
                                if(barco2[2] == "H"){
                                    matrizJugador[bx2,by2]=" B2 ";
                                    for (int i = 1; i < int.Parse(barco2[3]); i++)
                                    {
                                        matrizJugador[bx2,by2+i] = " B2 ";
                                    }
                                }else if(barco2[2] == "V"){
                                    for (int i = 1; i <= int.Parse(barco2[3]); i++)
                                    {
                                        matrizJugador[bx2+i,by2] = " B2 ";
                                    }
                                }
                            }else if(int.Parse(barco2[3]) == 4){
                                //Validacion de horizontal y posiciones
                                if(barco2[2] == "H"){
                                    matrizJugador[bx2,by2]=" B2 ";
                                    for (int i = 1; i < int.Parse(barco2[3]); i++)
                                    {
                                        matrizJugador[bx2,by2+i] = " B2 ";
                                    }
                                }else if(barco2[2] == "V"){
                                    for (int i = 1; i <= int.Parse(barco2[3]); i++)
                                    {
                                        matrizJugador[bx2+i,by2] = " B2 ";
                                    }
                                }
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
                            if(int.Parse(barco3[3]) == 2){
                                //Validacion de horizontal y posiciones
                                if(barco3[2] == "H"){
                                    matrizJugador[bx3,by3]=" B3 ";
                                    for (int i = 1; i < int.Parse(barco3[3]); i++)
                                    {
                                        matrizJugador[bx3,by3+i] = " B3 ";
                                    }
                                }else if(barco3[2] == "V"){
                                    for (int i = 1; i <= int.Parse(barco3[3]); i++)
                                    {
                                        matrizJugador[bx3+i,by3] = " B3 ";
                                    }
                                }
                            }else if(int.Parse(barco3[3]) == 3){
                                //Validacion de horizontal y posiciones
                                 if(barco3[2] == "H"){
                                    matrizJugador[bx3,by3]=" B3 ";
                                    for (int i = 1; i < int.Parse(barco3[3]); i++)
                                    {
                                        matrizJugador[bx3,by3+i] = " B3 ";
                                    }
                                }else if(barco3[2] == "V"){
                                    for (int i = 1; i <= int.Parse(barco3[3]); i++)
                                    {
                                        matrizJugador[bx3+i,by3] = " B3 ";
                                    }
                                }                                                        
                            }else if(int.Parse(barco3[3]) == 4){
                                //Validacion de horizontal y posiciones
                                 if(barco3[2] == "H"){
                                    matrizJugador[bx3,by3]=" B3 ";
                                    for (int i = 1; i < int.Parse(barco3[3]); i++)
                                    {
                                        matrizJugador[bx3,by3+i] = " B3 ";
                                    }
                                }else if(barco3[2] == "V"){
                                    for (int i = 1; i <= int.Parse(barco3[3]); i++)
                                    {
                                        matrizJugador[bx3+i,by3] = " B3 ";
                                    }
                                }
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
                            if(int.Parse(barco4[3]) == 2){
                                //Validacion de horizontal y posiciones
                                if(barco4[2] == "H"){
                                    matrizJugador[bx4,by4]=" B4 ";
                                    for (int i = 1; i < int.Parse(barco4[3]); i++){
                                    matrizJugador[bx4,by4+i] = " B4 ";
                                    }
                                }else if(barco4[2] == "V"){
                                    for (int i = 1; i <= int.Parse(barco4[3]); i++){
                                        matrizJugador[bx4+i,by4] = " B4 ";
                                    }
                                }  
                            }else if(int.Parse(barco4[3]) == 3){
                              //Validacion de horizontal y posiciones  
                              if(barco4[2] == "H"){
                                    matrizJugador[bx4,by4]=" B4 ";
                                    for (int i = 1; i < int.Parse(barco4[3]); i++){
                                    matrizJugador[bx4,by4+i] = " B4 ";
                                    }
                                }else if(barco4[2] == "V"){
                                    for (int i = 1; i <= int.Parse(barco4[3]); i++){
                                        matrizJugador[bx4+i,by4] = " B4 ";
                                    }
                                }                                                     
                            }else if(int.Parse(barco4[3]) == 4){
                                if(barco4[2] == "H"){
                                    matrizJugador[bx4,by4]=" B4 ";
                                    for (int i = 1; i < int.Parse(barco4[3]); i++){
                                    matrizJugador[bx4,by4+i] = " B4 ";
                                    }
                                }else if(barco4[2] == "V"){
                                    for (int i = 1; i <= int.Parse(barco4[3]); i++){
                                        matrizJugador[bx4+i,by4] = " B4 ";
                                    }
                                }  
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
                            if(int.Parse(barco5[3]) == 2){
                                if(barco5[2] == "H"){
                                    matrizJugador[bx5,by5]=" B5 ";
                                    for (int i = 1; i < int.Parse(barco5[3]); i++){
                                    matrizJugador[bx5,by5+i] = " B5 ";
                                    }
                                }else if(barco5[2] == "V"){
                                    for (int i = 1; i <= int.Parse(barco5[3]); i++){
                                        matrizJugador[bx5+i,by5] = " B5 ";
                                    }
                                }  
                            }else if(int.Parse(barco5[3]) == 3){
                            if(barco5[2] == "H"){
                                    matrizJugador[bx5,by5]=" B5 ";
                                    for (int i = 1; i < int.Parse(barco5[3]); i++){
                                    matrizJugador[bx5,by5+i] = " B5 ";
                                    }
                                }else if(barco5[2] == "V"){
                                    for (int i = 1; i <= int.Parse(barco5[3]); i++){
                                        matrizJugador[bx5+i,by5] = " B5 ";
                                    }
                                }                                               
                            }else if(int.Parse(barco5[3]) == 4){
                            if(barco5[2] == "H"){
                                    matrizJugador[bx5,by5]=" B5 ";
                                    for (int i = 1; i < int.Parse(barco5[3]); i++){
                                    matrizJugador[bx5,by5+i] = " B5 ";
                                    }
                                }else if(barco5[2] == "V"){
                                    for (int i = 1; i <= int.Parse(barco5[3]); i++){
                                        matrizJugador[bx5+i,by5] = " B5 ";
                                    }
                                }
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
        public static void matrizOponente(string[] dimnesionOponente, string[] barcoO1,string[] barcoO2,string[] barcoO3,string[] barcoO4,string[] barcoO5){
            Program instancia = new Program();
            string db = "/Users/jose/Desktop/Jose/Tutorias/Andres c#/Proyecto_Naval/AtaquesJugador.txt";
            string cox1 = barcoO1[0];
            string coy2 = barcoO1[1];
            string cobx2 = barcoO2[0];
            string coby2 =  barcoO2[1];
            string cobx3 = barcoO3[0];
            string coby3 = barcoO3[1];
            string cobx4 = barcoO4[0];
            string coby4 = barcoO4[1];
            string cobx5 = barcoO5[0];
            string coby5 = barcoO5[1];
            string cordenadasBarco1 = cox1+","+coy2;
            string cordenadasBarco2 = cobx2+","+coby2;
            string cordenadasBarco3 = cobx3+","+coby3;
            string cordenadasBarco4 = cobx4+","+coby4;
            string cordenadasBarco5 = cobx5+","+coby5;
            int filas = int.Parse(dimnesionOponente[0]);
            int columnas = int.Parse(dimnesionOponente[1]);
            string[,] matrizOponente =  new string[filas,columnas];   
            for (int f = 1; f < matrizOponente.GetLength(0); f++){
                Console.Write(f + " | ");
                for (int c = 1; c < matrizOponente.GetLength(1); c++){
                    //Valor de la tabla inicial
                    matrizOponente[f,c] = " . ";
                    //Variables de barcos
                    int bxo1 = int.Parse(barcoO1[0]);
                    int byo1 = int.Parse(barcoO1[1]);
                    //Barco 2
                    int bxo2 = int.Parse(barcoO2[0]);
                    int byo2 = int.Parse(barcoO2[1]);
                    //Barco 3
                    int bxo3 = int.Parse(barcoO3[0]);
                    int byo3 = int.Parse(barcoO3[1]);
                    //Barco 4
                    int bxo4 = int.Parse(barcoO4[0]);
                    int byo4 = int.Parse(barcoO4[1]);
                    //Barco 5
                    int bxo5 = int.Parse(barcoO5[0]);
                    int byo5 = int.Parse(barcoO5[1]);
                    //Validaciones para imprimir los barcos
                        //Validacion barco 1
                            //Validacion de que no quepa
                    if(bxo1 >= matrizOponente.GetLength(0) || byo1 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.2 no cabe en el tablero del oponente");
                    }else{ 
                        //Validacion de que no este repetido
                        if(bxo1 == bxo2 && bxo1 == bxo3 && bxo1 == bxo4 && bxo1 == bxo5 && byo1 == byo2 && byo1 == byo3 && byo1 == byo4 && byo1 == byo5){
                            Console.WriteLine("Parece que el barco no.1 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO1[3]) == 2){
                                //Validacion de horizontal y posiciones
                               if(barcoO1[2] == "H"){
                                   matrizOponente[bxo1,byo1] = " B1 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1;
                                        int b = byo1+i;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1,byo1+i] = " X ";
                                        }else{
                                            matrizOponente[bxo1,byo1+i] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                         matrizOponente[bxo1+1,byo1] = " X ";
                                     }
                                }else if(barcoO1[2] == "V"){
                                    //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1+i;
                                        int b = byo1;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1+i,byo1] = " X ";
                                        }else{
                                            matrizOponente[bxo1+i,byo1] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                        matrizOponente[bxo1,byo1] = " X ";
                                    }
                                }
                            }else if(int.Parse(barcoO1[3]) == 3){
                               if(barcoO1[2] == "H"){
                                   matrizOponente[bxo1,byo1] = " B1 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1;
                                        int b = byo1+i;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1,byo1+i] = " X ";
                                        }else{
                                            matrizOponente[bxo1,byo1+i] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                         matrizOponente[bxo1+1,byo1] = " X ";
                                     }
                                }else if(barcoO1[2] == "V"){
                                    //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1+i;
                                        int b = byo1;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1+i,byo1] = " X ";
                                        }else{
                                            matrizOponente[bxo1+i,byo1] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                        matrizOponente[bxo1,byo1] = " X ";
                                    }
                                }
                            }else if(int.Parse(barcoO1[3]) == 4){
                                if(barcoO1[2] == "H"){
                                   matrizOponente[bxo1,byo1] = " B1 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1;
                                        int b = byo1+i;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1,byo1+i] = " X ";
                                        }else{
                                            matrizOponente[bxo1,byo1+i] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                         matrizOponente[bxo1,byo1] = " X ";
                                     }
                                }else if(barcoO1[2] == "V"){
                                    //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1+i;
                                        int b = byo1;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1+i,byo1] = " X ";
                                        }else{
                                            matrizOponente[bxo1+i,byo1] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                        matrizOponente[bxo1,byo1] = " X ";
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 1 del oponente del oponente");
                            }
                        }
                    }
                    //Validacion barco 2
                        //Validacion de que no quepa
                    if(bxo2 >= matrizOponente.GetLength(0) || byo2 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.2 no cabe en el tablero del oponente");
                    }else{
                        //Validacion de que no este repetido
                         if(bxo2 == bxo1 && bxo2 == bxo3 && bxo2 == bxo4 && bxo2 == bxo5 && byo2 == byo1 && byo2 == byo3 && byo2 == byo4 && byo2 == byo5){
                            Console.WriteLine("Parece que el barco no.2 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO2[3]) == 2){
                                if(barcoO2[2] == "H"){
                                    matrizOponente[bxo2,byo2] = " B2 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2;
                                        int b2 = byo2+i;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2,byo2+i] = " X ";
                                        }else{
                                            matrizOponente[bxo2,byo2+i] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                         matrizOponente[bxo2+1,byo2] = " X ";
                                     }
                                }else if(barcoO2[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2+i;
                                        int b2 = byo2;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2+i,byo2] = " X ";
                                        }else{
                                            matrizOponente[bxo2+i,byo2] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                        matrizOponente[bxo1,byo1] = " X ";
                                    }
                                }
                            }else if(int.Parse(barcoO2[3]) == 3){
                                 if(barcoO2[2] == "H"){
                                    matrizOponente[bxo2,byo2] = " B2 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2;
                                        int b2 = byo2+i;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2,byo2+i] = " X ";
                                        }else{
                                            matrizOponente[bxo2,byo2+i] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                         matrizOponente[bxo2,byo2] = " X ";
                                     }
                                }else if(barcoO2[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2+i;
                                        int b2 = byo2;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2+i,byo2] = " X ";
                                        }else{
                                            matrizOponente[bxo2+i,byo2] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                        matrizOponente[bxo2,byo2] = " X ";
                                    }
                                }
                            }else if(int.Parse(barcoO2[3]) == 4){
                                 if(barcoO2[2] == "H"){
                                    matrizOponente[bxo2,byo2] = " B2 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2;
                                        int b2 = byo2+i;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2,byo2+i] = " X ";
                                        }else{
                                            matrizOponente[bxo2,byo2+i] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                         matrizOponente[bxo2,byo2] = " X ";
                                     }
                                }else if(barcoO2[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2+i;
                                        int b2 = byo2;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2+i,byo2] = " X ";
                                        }else{
                                            matrizOponente[bxo2+i,byo2] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                        matrizOponente[bxo2,byo2] = " X ";
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 2 del oponente del oponente");
                            }
                        }
                    }
                    //Validacion barco 3
                        //Validacion de que no quepa
                    if(bxo3 >= matrizOponente.GetLength(0) || byo3 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.3 no cabe en el tablero del oponente");
                    }else{
                            //Validacion de que no este repetido
                         if(bxo3 == bxo1 && bxo3 == bxo2 && bxo3 == bxo4 && bxo3 == bxo5 && byo3 == byo1 && byo3 == byo2 && byo3 == byo4 && byo3 == byo5){
                            Console.WriteLine("Parece que el barco no.3 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO3[3]) == 2){
                                if(barcoO3[2] == "H"){
                                    matrizOponente[bxo3,byo3] = " B3 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO3[3]); i++)
                                    {
                                        int a3 = bxo3;
                                        int b3 = byo3+i;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3,byo3+i] = " X ";
                                        }else{
                                            matrizOponente[bxo3,byo3+i] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                         matrizOponente[bxo3,byo3] = " X ";
                                     }
                                }else if(barcoO3[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a3 = bxo3+i;
                                        int b3 = byo3;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3+i,byo3] = " X ";
                                        }else{
                                            matrizOponente[bxo3+i,byo3] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                        matrizOponente[bxo3,byo3] = " X ";
                                    }
                                }
                            }else if(int.Parse(barcoO3[3]) == 3){
                                if(barcoO3[2] == "H"){
                                    matrizOponente[bxo3,byo3] = " B3 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO3[3]); i++)
                                    {
                                        int a3 = bxo3;
                                        int b3 = byo3+i;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3,byo3+i] = " X ";
                                        }else{
                                            matrizOponente[bxo3,byo3+i] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                         matrizOponente[bxo3,byo3] = " X ";
                                     }
                                }else if(barcoO3[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a3 = bxo3+i;
                                        int b3 = byo3;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3+i,byo3] = " X ";
                                        }else{
                                            matrizOponente[bxo3+i,byo3] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                        matrizOponente[bxo3,byo3] = " X ";
                                    }
                                }                                                       
                            }else if(int.Parse(barcoO3[3]) == 4){
                                if(barcoO3[2] == "H"){
                                    matrizOponente[bxo3,byo3] = " B3 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO3[3]); i++)
                                    {
                                        int a3 = bxo3;
                                        int b3 = byo3+i;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3,byo3+i] = " X ";
                                        }else{
                                            matrizOponente[bxo3,byo3+i] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                         matrizOponente[bxo3,byo3] = " X ";
                                     }
                                }else if(barcoO3[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a3 = bxo3+i;
                                        int b3 = byo3;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3+i,byo3] = " X ";
                                        }else{
                                            matrizOponente[bxo3+i,byo3] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                        matrizOponente[bxo3,byo3] = " X ";
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 3 del oponente");
                            }
                        }
                    }
                    //Validacion barco 4
                        //Validacion de que no quepa
                    if(bxo4 >= matrizOponente.GetLength(0) || byo4 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.4 no cabe en el tablero del oponente");
                    }else{
                            //Validacion de que no este repetido
                         if(bxo4 == bxo1 && bxo4 == bxo2 && bxo4 == bxo3 && bxo4 == bxo5 && byo4 == byo1 && byo4 == byo2 && byo4 == byo3 && byo4 == byo5){
                            Console.WriteLine("Parece que el barco no.4 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO4[3]) == 2){
                                if(barcoO4[2] == "H"){
                                    matrizOponente[bxo4,byo4] = " B4 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4;
                                        int b4 = byo4+i;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4,byo4+i] = " X ";
                                        }else{
                                            matrizOponente[bxo4,byo4+i] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                         matrizOponente[bxo4,byo4] = " X ";
                                     }
                                }else if(barcoO4[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4+i;
                                        int b4 = byo4;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4+i,byo4] = " X ";
                                        }else{
                                            matrizOponente[bxo4+i,byo4] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                        matrizOponente[bxo4,byo4] = " X ";
                                    }
                                }
                            }else if(int.Parse(barcoO4[3]) == 3){
                            if(barcoO4[2] == "H"){
                                    matrizOponente[bxo4,byo4] = " B4 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4;
                                        int b4 = byo4+i;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4,byo4+i] = " X ";
                                        }else{
                                            matrizOponente[bxo4,byo4+i] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                         matrizOponente[bxo4,byo4] = " X ";
                                     }
                                }else if(barcoO4[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4+i;
                                        int b4 = byo4;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4+i,byo4] = " X ";
                                        }else{
                                            matrizOponente[bxo4+i,byo4] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                        matrizOponente[bxo4,byo4] = " X ";
                                    }
                                }                                                      
                            }else if(int.Parse(barcoO4[3]) == 4){
                            if(barcoO4[2] == "H"){
                                    matrizOponente[bxo4,byo4] = " B4 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4;
                                        int b4 = byo4+i;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4,byo4+i] = " X ";
                                        }else{
                                            matrizOponente[bxo4,byo4+i] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                         matrizOponente[bxo4,byo4] = " X ";
                                     }
                                }else if(barcoO4[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4+i;
                                        int b4 = byo4;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4+i,byo4] = " X ";
                                        }else{
                                            matrizOponente[bxo4+i,byo4] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                        matrizOponente[bxo4,byo4] = " X ";
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 4 del oponente");
                            }
                        }
                    }
                    //Validacion barco 5
                        //Validacion de que no quepa
                    if(bxo5 >= matrizOponente.GetLength(0) || byo5 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.5 no cabe en el tablero del oponente");
                    }else{
                        //Validacion de que no este repetido
                        if(bxo5 == bxo1 && bxo5 == bxo2 && bxo5 == bxo3 && bxo5 == bxo4 && byo5 == byo1 && byo5 == byo2 && byo5 == byo3 && byo5 == byo4){
                            Console.WriteLine("Parece que el barco no.5 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO5[3]) == 2){
                                if(barcoO5[2] == "H"){
                                    matrizOponente[bxo5,byo5] = " B5 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5;
                                        int b5 = byo5+i;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5,byo5+i] = " X ";
                                        }else{
                                            matrizOponente[bxo5,byo5+i] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                         matrizOponente[bxo5,byo5] = " X ";
                                     }
                                }else if(barcoO5[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5+i;
                                        int b5 = byo5;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5+i,byo5] = " X ";
                                        }else{
                                            matrizOponente[bxo5+i,byo5] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                        matrizOponente[bxo5,byo5] = " X ";
                                    }
                                }
                            }else if(int.Parse(barcoO5[3]) == 3){
                            if(barcoO5[2] == "H"){
                                    matrizOponente[bxo5,byo5] = " B5 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5;
                                        int b5 = byo5+i;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5,byo5+i] = " X ";
                                        }else{
                                            matrizOponente[bxo5,byo5+i] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                         matrizOponente[bxo5,byo5] = " X ";
                                     }
                                }else if(barcoO5[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5+i;
                                        int b5 = byo5;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5+i,byo5] = " X ";
                                        }else{
                                            matrizOponente[bxo5+i,byo5] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                        matrizOponente[bxo5,byo5] = " X ";
                                    }
                                }                                            
                            }else if(int.Parse(barcoO5[3]) == 4){
                            if(barcoO5[2] == "H"){
                                    matrizOponente[bxo5,byo5] = " B5 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5;
                                        int b5 = byo5+i;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5,byo5+i] = " X ";
                                        }else{
                                            matrizOponente[bxo5,byo5+i] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                         matrizOponente[bxo5,byo5] = " X ";
                                     }
                                }else if(barcoO5[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5+i;
                                        int b5 = byo5;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5+i,byo5] = " X ";
                                        }else{
                                            matrizOponente[bxo5+i,byo5] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                        matrizOponente[bxo5,byo5] = " X ";
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 5 del oponente");
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
        public void quitarPuntoJugador(){
            this.contadorJugador = this.contadorJugador - 1;
        }
        public void quitarPuntoOponente(){
            this.contadorOponente = this.contadorOponente - 1;
        }

        public static void GenerarTXTJugador(){
            string nombre = "/Users/jose/Desktop/Jose/Tutorias/Andres c#/Proyecto_Naval/jugador.txt";            
            StreamReader reader = new StreamReader(nombre);
            string linea1 = reader.ReadLine(); 
            string[] dimnesion; 
            dimnesion = linea1.Split(",");
            reader.ReadLine();
            string barco1s = reader.ReadLine();
            string barco2s = reader.ReadLine();
            string barco3s = reader.ReadLine();
            string barco4s = reader.ReadLine();
            string barco5s = reader.ReadLine();
            string[] barco1 = barco1s.Split(",");
            string[] barco2 = barco2s.Split(",");
            string[] barco3 = barco3s.Split(",");
            string[] barco4 = barco4s.Split(",");
            string[] barco5 = barco5s.Split(",");
            reader.ReadLine();
            matrizJugador(dimnesion,barco1,barco2,barco3,barco4,barco5);
        }
        public static void GenerarTXTOponente(){
            string nombre = "/Users/jose/Desktop/Jose/Tutorias/Andres c#/Proyecto_Naval/oponente.txt";            
            StreamReader reader = new StreamReader(nombre);
            string linea1 = reader.ReadLine(); 
            string[] dimnesion; 
            dimnesion = linea1.Split(",");
            reader.ReadLine();
            string barco1s = reader.ReadLine();
            string barco2s = reader.ReadLine();
            string barco3s = reader.ReadLine();
            string barco4s = reader.ReadLine();
            string barco5s = reader.ReadLine();
            string[] barco1 = barco1s.Split(",");
            string[] barco2 = barco2s.Split(",");
            string[] barco3 = barco3s.Split(",");
            string[] barco4 = barco4s.Split(",");
            string[] barco5 = barco5s.Split(",");
            reader.ReadLine();
            Thread.Sleep(5000);
            matrizOponente(dimnesion,barco1,barco2,barco3,barco4,barco5);
        }

        public static void ModificarTXTOponente(string[] ataque){
            try{
            string Npath = "/Users/jose/Desktop/Jose/Tutorias/Andres c#/Proyecto_Naval/AtaquesOponente.txt";
            string path = "/Users/jose/Desktop/Jose/Tutorias/Andres c#/Proyecto_Naval/oponente.txt";       
                 using(StreamWriter writer = new StreamWriter(Npath,true)){
                     string a = string.Join(",",ataque);
                     writer.WriteLine(a);
                 }     
                // using (StreamWriter writer = new StreamWriter(path,true)){
                // writer.WriteLine();
                // writer.WriteLine("-----------Ataques realizados hacia el Jugador-----------");
                // string a = string.Join(",",ataque);
                // writer.WriteLine(a);
                // }
            }
            catch (Exception exp){
                Console.Write(exp);
                throw;
            }
        }
        public static void ModificarTXTJugador(string[] ataqueOponente){
            try{
            string path = "/Users/jose/Desktop/Jose/Tutorias/Andres c#/Proyecto_Naval/jugador.txt"; 
            string Npath = "/Users/jose/Desktop/Jose/Tutorias/Andres c#/Proyecto_Naval/AtaquesJugador.txt";           
                 using(StreamWriter writer = new StreamWriter(Npath,true)){
                     string a = string.Join(",",ataqueOponente);
                     writer.WriteLine(a);
                 }    
                // using (StreamWriter writer = new StreamWriter(path,true)){
                // writer.WriteLine();
                // writer.WriteLine("-----------Ataques realizados-----------");
                // string a = string.Join(",",ataqueOponente);
                // writer.WriteLine(a);
                // }    
            }
            catch (Exception exp){
                Console.Write(exp);
                throw;
            }
        }
        
    }
}
