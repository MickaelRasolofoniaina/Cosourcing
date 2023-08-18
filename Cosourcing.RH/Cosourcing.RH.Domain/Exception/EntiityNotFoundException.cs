using System;

namespace Cosourcing.RH.Domain.Exception
{
    public class EntityNotFoundException : System.Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}

