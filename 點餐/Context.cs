using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace 點餐
{
    internal class Context
    {
        
        public void Strategyuse(Cupon cuponuse) 
        {
            cuponuse.Cuponuse();
        }
    }
}
