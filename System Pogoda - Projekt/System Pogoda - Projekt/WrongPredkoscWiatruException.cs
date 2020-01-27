using System;
using System.Runtime.Serialization;

namespace System_Pogoda___Projekt
{
    /// <summary>
    /// Klasa obsługująca wyjątek WrongPredkoscWiatruException
    /// </summary>
    internal class WrongPredkoscWiatruException : Exception
    {
        public WrongPredkoscWiatruException()
        {
        }

        public WrongPredkoscWiatruException(string message) : base(message)
        {
        }
    }
}