using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public class Move
    {
        private readonly Position r_From;
        private readonly Position r_To;

        public Move(Position i_From, Position i_To)
        {
            r_From = i_From;
            r_To = i_To;
        }

        public Position From
        {
            get { return r_From; }
        }

        public Position To
        {
            get { return r_To; }
        }

        public override string ToString()
        {
            return $"{r_From} to {r_To}";
        }
    }

}
