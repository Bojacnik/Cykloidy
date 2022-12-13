using Domain.Primitives.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Basic.Interfaces
{
    public interface IBasicPusher
    {
        public void Step();
    }
}
