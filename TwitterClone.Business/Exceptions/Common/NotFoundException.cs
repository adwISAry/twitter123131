using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Entities.Common;

namespace TwitterClone.Business.Exceptions.Common
{
    public class NotFoundException<T> : Exception where T : BaseEntity
    {
        public NotFoundException() : base(typeof(T).Name + "Not Found")
        {
            
        }
        public NotFoundException(string? message) : base(message) 
        {

        }
    }
}
