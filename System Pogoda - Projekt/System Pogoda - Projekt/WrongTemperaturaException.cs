using System;
using System.Runtime.Serialization;

namespace System_Pogoda___Projekt
{
    [Serializable]
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