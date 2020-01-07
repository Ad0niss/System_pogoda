using System;
using System.Runtime.Serialization;

namespace System_Pogoda___Projekt
{
    [Serializable]
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