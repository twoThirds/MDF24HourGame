using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.BaseTypes
{
    class Entity
    {
        static Entity()
        {
            random = new Random();
        }
        static Random random;
        static Random Random
        {
            get
            {
                return random;
            }
        }
    }
}
