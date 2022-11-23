using Domain.Basic.Interfaces;
using Domain.Primitives.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cykloidy
{
    public interface ISimManager
    {
        public void DrawSetup();
        public void DrawScenery();
        public void Start();

    }
}
