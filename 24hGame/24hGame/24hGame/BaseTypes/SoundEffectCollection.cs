using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.BaseTypes
{
    class SoundEffectCollection : Entity
    {
        List<SoundEffect> sounds;
        public List<SoundEffect> Sounds
        {
            get
            {
                return sounds;
            }
            set
            {
                sounds = value;
            }
        }

        public void PlayRandom()
        {

        }
    }
}
