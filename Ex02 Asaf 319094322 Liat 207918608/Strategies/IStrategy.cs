using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public interface IStrategy
    {
        Move GetMove(Board i_Board);
    }

}
