using System;
using System.Runtime.Serialization;

namespace System_Pogoda___Projekt
{
    /// <summary>
    /// Klasa obsługująca wyjątek WrongTemperaturaException
    /// </summary>
    internal class WrongTemperaturaException : Exception
    {
        public WrongTemperaturaException()
        {
        }

        public WrongTemperaturaException(string message) : base(message)
        {
        }
    }
}