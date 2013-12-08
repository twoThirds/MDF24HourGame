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
		public static void FixCollision(ControlledEntity e1, DrawableEntity e2)
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
				//entity1 left or right edge is within object left/right edges
				if (((e1py > e2py) && (e1py < (e2py + e2sy))) || (((e1py + e1sy) > e2py) && ((e1py + e1sy) < (e2py + e2sy))))
				{
					//entity1 top or bottom edge is within object top/bottom edges
					//We officially have collided! Now fix it...

					//if(e1.Velocity.X != 0 && e1.Velocity.Y != 0)
					//{
					//	//Diagonally
					//}
					///
					if (e1.Velocity.X > 0)
					{
						//Moving Right
						e1.Position = new Vector2(e2px - e1sx, e1py);
					}
					else if (e1.Velocity.X < 0)
					{
						//Moving Left
						e1.Position = new Vector2(e2px + e2sx, e1py);
					}
					if (e1.Velocity.Y > 0)
					{
						//Moving down
						e1.Position = new Vector2(e1px, e2py - e1sy);
					}
					else if(e1.Velocity.Y < 0)
					{
						//Moving up
						e1.Position = new Vector2(e1px, e2py + e2sy);
					}

					e1.Velocity = new Vector2(0,0);
					return;
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

        }
	}
}
