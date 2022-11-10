using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
    public class ResourceNotFoudExeption : Exception
    {
        public ResourceNotFoudExeption(string? message) : base(message)
        {
        }
    }
}
