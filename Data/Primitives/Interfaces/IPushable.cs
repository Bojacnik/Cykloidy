using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives.Interfaces
{
    public interface IPushable
    {
        public void Push(double x, double y);
    }
}
