using System;
namespace QuintoLaboratorio
{
    public class User
    {
        public delegate void EmailVerifiedEventHandler(object source, EventArgs args);
        public event EmailVerifiedEventHandler EmailVerified;
        protected virtual void OnEmailVerified()
        {
            if (EmailVerified != null)
            {
                EmailVerified(this, EventArgs.Empty);
            }
        }
        public DataBase Data { get; }
        public User(DataBase data)
        {
            this.Data = data;
        }
        public void OnEmailSent()
        {
            Console.WriteLine("Desea verificar su cuenta?si/no");
            string answer = Console.ReadLine();
            if (answer == "si")
            {
                Console.WriteLine("Ingresa tu nombre de usuario: ");
                string usr = Console.ReadLine();
                Console.WriteLine("Ingresa tu contrasena: ");
                string pswd = Console.ReadLine();
                string result = Data.LogIn(usr, pswd);
                if (result == null)
                {
                    OnEmailVerified();
                }
                else
                {
                    Console.WriteLine("[!] ERROR: " + result + "\n");
                }
            }
            else
            {
                Console.WriteLine("De vuelta al menu principal...");
            }
            
        }

    }
}
