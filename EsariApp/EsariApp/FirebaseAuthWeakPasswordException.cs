using System;
using System.Runtime.Serialization;

namespace EsariApp
{
    [Serializable]
    internal class FirebaseAuthWeakPasswordException : Exception
    {
        public FirebaseAuthWeakPasswordException()
        {
        }

        public FirebaseAuthWeakPasswordException(string message) : base(message)
        {
        }

        public FirebaseAuthWeakPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FirebaseAuthWeakPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}