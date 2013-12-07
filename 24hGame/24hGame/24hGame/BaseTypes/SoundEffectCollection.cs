using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.BaseTypes
{
    class SoundEffectCollection : Entity
    {
        public SoundEffectCollection()
        {
            sounds = new List<SoundEffect>();
        }
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

        /// <summary>
        /// Not yet impemented
        /// </summary>
        public void PlayRandom()
        {
            if (sounds.Count > 0)
                sounds[Game1.Random.Next() % sounds.Count].Play();
        }
    }
}
