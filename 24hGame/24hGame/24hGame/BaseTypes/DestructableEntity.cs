using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.BaseTypes
{
    class DestructableEntity : SmartEntity
    {
        int hitPoints;
        public int HitPoints
        {

            get
            {
                return hitPoints;
            }
            set
            {
                hitPoints = value;
            }
        }
        
    }
}
