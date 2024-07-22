using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiceInfo
{
    public abstract class Pice
    {
        public abstract PiceColor Color { get; set; }
        public abstract PiceType Type { get; }
        public abstract int[,] Moves();
        public abstract string ImagePath();
        public abstract int Cost { get; }

        public abstract Position position { get;  }
    }
}
