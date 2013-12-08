using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.Components.Weapons
{
    class DummyWeaponFactory
    {
        public static Weapon GeneratePistol(Game1 game)
        {
            Weapon w = new Weapon(game);
            w.Initialize(@"Textures\Player\weapons\pistol-tomten\pistolStill", @"Textures\Player\weapons\pistol-tomten\pistolShooting", 19);
            w.Grip = Weapon.GripType.Pistol;
            w.Description = "Tomten gun is best gun";
            w.PlayerOffset = new Microsoft.Xna.Framework.Vector2(0, 0);
            return w;
        }
    }
}
