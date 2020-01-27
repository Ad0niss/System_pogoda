using System;
using System.Runtime.Serialization;

namespace System_Pogoda___Projekt
{
    /// <summary>
    /// Klasa obsługująca wyjątek WrongDataException
    /// </summary>
    internal class WrongDataException : Exception
    {
        public WrongDataException()
        {
        }

        public WrongDataException(string message) : base(message)
        {
        }

        public WrongDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}