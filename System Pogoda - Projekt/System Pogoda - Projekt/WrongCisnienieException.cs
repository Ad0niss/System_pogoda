using System;
using System.Runtime.Serialization;

namespace System_Pogoda___Projekt
{
    [Serializable]
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