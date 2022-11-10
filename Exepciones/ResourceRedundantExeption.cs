using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
    public class ResourceRedundantExeption : Exception
    {
        public ResourceRedundantExeption(string? message) : base(message)
        {
        }
    }
}
