using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MiniCompiladorXconsola
{
    class Program
    {
        private static List<string> listaRespuestas = new List<string>();
        private static string[] palabrasReservadas = new string[] { "ENTERO", "DECIMAL", "CADENA", "BUCLE", "CASO", "SI", "ENTONCES", 
        "SINO", "FIN", "CAMBIAR", "ROMPER", "MIENTRAS", "HACER", "VERDADERO", "FALSO", "NUEVO", "NULO" };        

        private static bool ValidacionAZ(String str)
        {
            return Regex.IsMatch(str, @"^[a-z]+$");
        }

        private static bool ValidacionNUM(String str)
        {
            return Regex.IsMatch(str, @"^[0-9]+$");
        }

        private static bool Min(String str)
        {
            bool tieneMinusculas = str.Any(c => char.IsLower(c));
            return tieneMinusculas;
        }

        private static bool May(String str)
        {
            bool tieneMayusculas = str.Any(c => char.IsUpper(c));
            return tieneMayusculas;
        }

        private static bool Dig(String str)
        {
            bool tieneNumeros = str.Any(c => char.IsDigit(c));
            return tieneNumeros;
        }

        static void VerificacionInicio(string [] x)
        {
            string[] cadena = x;
            string texto = "";
            string variable = "";


            for (int i = 0; i < palabrasReservadas.Length; i++)
            {
                if ((palabrasReservadas[i].Equals(cadena[0])))
                {
                    texto = "PALABRA RESERVADA...........\t\t\t" + cadena[0] + "\tPALABRA RESERVADA VALIDA \n";
                    i = palabrasReservadas.Length;
                    variable = cadena[0];
                }
                else if ((cadena[0].Equals(palabrasReservadas[i].ToLower())) || ((Min(cadena[0]) == true) && (palabrasReservadas[i].Equals(cadena[0].ToUpper()))))
                {
                    texto = "ERROR SEMANTICO.............\t\t\t" + cadena[0]+ "\tPALABRA RESERVADA NO VALIDA\n";
                    i = palabrasReservadas.Length;
                }
                else
                {
                    texto = "ERROR LEXICO................\t\t\t" + cadena[0] + "\tPALABRA RESERVADA VALIDA\n";
                }
            }
            listaRespuestas.Add(texto);

            //Obtenemos el ultimo caracter de la ultima posicion de la cadena
            string ultimoCaracter = cadena[3].Substring(cadena[3].Length - 1);
            string dato = "";

            //verificamos si es ';' y si, si lo es, se elimina
            if (ultimoCaracter.Equals(";"))
            {
                dato = cadena[3].Substring(0, cadena[3].Length - 1);
            }
            else
            {
                dato = cadena[3];
            }

            if (variable.Equals("ENTERO") || variable.Equals("DECIMAL") || variable.Equals("CADENA"))
            {

                Identificador(cadena);              
              
                switch (variable)
                {
                    case "ENTERO":

                        //Validamos si el valor contenido en la variable dato solo contiene numeros
                        if (ValidacionNUM(dato) == true && ultimoCaracter.Equals(";"))
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";

                        }
                        else if (ValidacionNUM(dato) == false)
                        {
                            if (!ultimoCaracter.Equals(";") && ValidacionAZ(ultimoCaracter) == true || !ultimoCaracter.Equals(";") && Dig(ultimoCaracter) == true)
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                            }
                            else if (ultimoCaracter.Equals(";"))
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";
                            }
                            else
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                            }
                            
                        }
                        else if (ValidacionNUM(dato) == true && !ultimoCaracter.Equals(";"))
                        {
                            if (!ultimoCaracter.Equals(";") && ValidacionAZ(ultimoCaracter) == true || !ultimoCaracter.Equals(";") && Dig(ultimoCaracter) == true)
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                            }                           
                            else
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                            }

                        }

                        listaRespuestas.Add(texto);
                        foreach (var item in listaRespuestas)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "DECIMAL":
                        //Validamos si el valor contenido en la variable dato solo contiene numeros 
                        if (Dig(dato) == true && ultimoCaracter.Equals(";") && dato.Contains(".") && Min(dato) == false && May(dato) == false)
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";

                        }
                        else if (Dig(dato) == false)
                        {
                            if (!ultimoCaracter.Equals(";") && ValidacionAZ(ultimoCaracter) == true)
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                            }
                            else if (ultimoCaracter.Equals(";"))
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";
                            }
                            else
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                            }

                        }
                        else if (Min(dato) == true || May(dato) == true)
                        {
                            if (ValidacionAZ(ultimoCaracter) == true || Dig(ultimoCaracter) == true)
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                            }
                            else if (ultimoCaracter.Equals(";"))
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";
                            }                            
                            else
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                            }

                        }
                        else if (ValidacionNUM(dato) == true)
                        {
                            if (ultimoCaracter.Equals(";"))
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";
                            }
                            else if (!ultimoCaracter.Equals(";") && Dig(ultimoCaracter) == true)
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                            }
                            else
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                            }

                        }
                        else if (Dig(dato) == true && !ultimoCaracter.Equals(";") && dato.Contains(".") && Min(dato) == false && May(dato) == false)
                        {
                            
                            if (Dig(ultimoCaracter) == true)
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                            }
                            else
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                            }

                        }

                        listaRespuestas.Add(texto);
                        foreach (var item in listaRespuestas)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "CADENA":
                        if (Dig(dato) == false && ultimoCaracter.Equals(";") && dato.Contains("'") && Min(dato) == true && May(dato) == true)
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";

                        }
                        else if (ValidacionNUM(dato) == true)
                        {
                            if (!ultimoCaracter.Equals(";") && ValidacionNUM(ultimoCaracter) == true)
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                            }
                            else if (ultimoCaracter.Equals(";"))
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";
                            }
                            else
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                            }

                        }
                        else if (Dig(dato) == true)
                        {
                            if (!ultimoCaracter.Equals(";") && ValidacionNUM(ultimoCaracter) == true || !ultimoCaracter.Equals(";") && ValidacionAZ(ultimoCaracter) == true)
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                            }
                            else if (ultimoCaracter.Equals(";"))
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";
                            }
                            else
                            {
                                texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                        "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                            }

                        }

                        listaRespuestas.Add(texto);
                        foreach (var item in listaRespuestas)
                        {
                            Console.WriteLine(item);
                        }

                        break;
                    


                }


            }
            else
            {
                if (!ultimoCaracter.Equals(";") && ValidacionNUM(ultimoCaracter) == true || !ultimoCaracter.Equals(";") && ValidacionAZ(ultimoCaracter) == true || May(ultimoCaracter) == true)
                {
                    texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO - NO SE DEFINIO UN TIPO DE DATO\n" +
                            "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                }
                else if (ultimoCaracter.Equals(";"))
                {
                    texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO - NO SE DEFINIO UN TIPO DE DATO\n" +
                            "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";
                }
                else
                {
                    texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO - NO SE DEFINIO UN TIPO DE DATO\n" +
                            "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                }

                listaRespuestas.Add(texto);
                foreach (var item in listaRespuestas)
                {
                    Console.WriteLine(item);
                }
            }

        }
        

        static void esDigito(string x)
        {
            string[] palabrasReservadas = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            int contador = 0;
            string cadena_r = "";

            for (int i = 0; i < x.Length; i++)
            {
                if ((x[i].Equals('0')) | (x[i].Equals('1')) | (x[i].Equals('2')) | (x[i].Equals('3')) | (x[i].Equals('4')) | (x[i].Equals('5'))
                    | (x[i].Equals('6')) | (x[i].Equals('7')) | (x[i].Equals('8')) | (x[i].Equals('9')))
                {
                    contador++;
                    cadena_r += x[i] + " ";
                }
            }
            Console.WriteLine("hay " + contador.ToString() + " digitos: " + cadena_r);
        }

        static void Token(string x, int opc)
        {   

            string[] simbolos = new string[] { "=", "(", ")", "+", "-", "*", "/", ";", "<", ">", "=="};
            string cadena = x;
            int posicion = opc;
            string texto = "";

            //Validamos si el dato de la variable cadena es igual al operador que se espera 
            if (cadena.Equals(simbolos[posicion]))
            {
                texto = "OPERADOR...................\t\t\t" + cadena + "\tOPERADOR VALIDO\n";
            }
            else if (ValidacionAZ(cadena) == true || Dig(cadena) == true)
            {
                texto = "ERROR SEMANTICO.............\t\t\t" + cadena + "\tOPERADOR OMITIDO\n";
            }
            else
            {
                texto = "ERROR SEMANTICO.............\t\t\t" + cadena + "\tOPERADOR NO VALIDO\n";

            }

            //agregamos la respuesta a nuestra lista para mostrarlo posteriormente 
            listaRespuestas.Add(texto);

        }

        static void Identificador(string [] x)
        {
            string[] cadena = x;
            string texto = "";
            
            //validamos en la posicion 1 porque es la posicion donde tendria que estar el identificador
            if (ValidacionAZ(cadena[1]) == true)
            {
                texto = "IDENTIFICADOR...............\t\t\t" + cadena[1] + "\tIDENTIFICADOR VALIDO\n";
            }            
            else if (May(cadena[1]) == true)
            {
                texto = "ERROR SEMANTICO.............\t\t\t" + cadena[1] + "\tIDENTIFICADOR NO VALIDO\n";
            }
            else
            {
                texto = "ERROR LEXICO................\t\t\t" + cadena[1] + "\tIDENTIFICADOR NO VALIDO\n";

            }
            
            //agregamos la respuesta a nuestra lista para mostrarlo posteriormente 
            listaRespuestas.Add(texto);

            //Mandamos 0 porque es la pocision donde se encuentra el simbolo =
            Token(cadena[2], 0);

        }

        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\t||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("\t\t\t\t\t----------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\t\t////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("\t\t\t\t\t----------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\t\t-----------------------------MINI COMPILADOR PERSONAL-----------------------------------");
            Console.WriteLine("\t\t\t\t\t----------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\t\t////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("\t\t\t\t\t----------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\t\t||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");

            Console.WriteLine("\n\n\n\t\tIngrese una expresion a analizar: ");
            string cadena = Console.ReadLine();


            string[] vector = cadena.Split(' ');


            VerificacionInicio(vector);
        }

    }
}
