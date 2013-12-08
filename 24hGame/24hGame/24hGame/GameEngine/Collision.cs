using _24hGame.BaseTypes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.GameEngine
{
	class Collision
	{
		public bool DetectCollision(ControlledEntity e1, DrawableEntity e2)
		{
			float e1px = e1.Position.X;
			float e1py = e1.Position.Y;
			float e1sx = e1.Size.X;
			float e1sy = e1.Size.Y;
			float e2px = e2.Position.X;
			float e2py = e2.Position.Y;
			float e2sx = e2.Size.X;
			float e2sy = e2.Size.Y;

			if (((e1px > e2px) && (e1px < (e2px + e2sx))) || (((e1px + e1sx) > e2px) && ((e1px + e1sx) < (e2px + e2sx))))
			{
				//entity1 left or right side is within object
				if (((e1py > e2py) && (e1py < (e2py + e2sy))) || (((e1py + e1sy) > e2py) && ((e1py + e1sy) < (e2py + e2sy))))
				{
					//entity1 top or bottom side is also within object

					return true;
				}
			}
			


			//else if (((e1px + e1sx) > e2px) && ((e1px + e1sx) < (e2px + e2sx)))
			//{
			//	//entity1 right side is within object
			//}
			//else if (((e1py + e1sy) > e2py) && ((e1py + e1sy) < (e2py + e2sy)))
			//{
			//	//entity1 bottom side is within object
			//}	

			//c1.Add()

			return true;
        }
	}
}
