using System;
using System.Security.Cryptography.X509Certificates;

namespace IfStatementsHerausforderung
{
    class Program
    {
        // Benutzername
        static string username;
        // Passwort - static, damit es in einer Methode verwendet werden kann
        static string password;
        static void Main(string[] args)
        {
            Register();
            Login();
            Console.ReadKey();
        }

        public static void Register()
        {
            Console.WriteLine("Bitte trage Deinen Benutzernamen ein");
            username = Console.ReadLine();
            Console.WriteLine("Bitte trage Dein Passwort ein");
            password = Console.ReadLine();
            Console.WriteLine("Regestrierung abgeschlossen!");
            Console.WriteLine("-----------------------------------------------------");
        }
        public static void Login()
        { 
            Console.WriteLine("Bitte Benutzername eingeben:");
            if (username == Console.ReadLine())
            {
                Console.WriteLine("Bitte Passwort eingeben:");
                if (password == Console.ReadLine())
                {
                    Console.WriteLine("Einlogge war erfolgreich");
                }
                else
                {
                    Console.WriteLine("Login schiefgegangen, falsches Passwort. Starte das Programm neu.");
                }

            }
            else
            {
                Console.WriteLine("Benutzername exsestiert nicht. Bitte versuche es mit einem anderen Benutzernamen");
            }
            
        }   
    }
}


