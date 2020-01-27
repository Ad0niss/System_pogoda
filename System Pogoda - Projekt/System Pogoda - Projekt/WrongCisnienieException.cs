using System;
using System.Runtime.Serialization;

namespace System_Pogoda___Projekt
{
    /// <summary>
    /// Klasa obsługująca wyjątek WrongCisnienieException
    /// </summary>
    internal class WrongCisnienieException : Exception
    {
        public WrongCisnienieException()
        {
        }

        public WrongCisnienieException(string message) : base(message)
        {
        }
    }
}