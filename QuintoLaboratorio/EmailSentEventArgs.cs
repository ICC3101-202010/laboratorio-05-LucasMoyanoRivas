using System;
namespace QuintoLaboratorio
{
    public class EmailSentEventArgs : EventArgs
    {
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
