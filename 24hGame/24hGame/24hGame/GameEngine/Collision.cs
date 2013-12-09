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
			//Entity1's sides & size
			float e1width = e1.Size.X;
			float e1height = e1.Size.Y;
			float e1left = e1.Position.X;
			float e1right = e1.Position.X + e1width;
			float e1top = e1.Position.Y;
			float e1bottom = e1.Position.Y + e1height;

			//Entity2's sides & size
			float e2width = e2.Size.X;
			float e2height = e2.Size.Y;
			float e2left = e2.Position.X;
			float e2right = e2.Position.X + e2width;
			float e2top = e2.Position.Y;
			float e2bottom = e2.Position.Y + e2height;

			//Check horizontal "collision"
			if (e1right > e2left && e1right < e2right) ;	//"Collision" on right side
			else if (e1left > e2left && e1left < e2right) ; //"Collision" on left side
			else return; //Requires collision on both horizontal and vertical for a true collision
			
			//Check vertical "collision"
			if (e1top > e2top && e1top < e2bottom) ;			//"Collision" on top side.
			else if (e1bottom > e2top && e1bottom < e2bottom) ;	//"Collision" on bottom side.
			else return; //Requires collision on both horizontal and vertical for a true collision
				
			//Todo: check for collisions when e2 is smaller than e1

			//if we got here, a collision has occured. Apply counter-measures
			if (e1.Heading.X > 0) //Moving right
				if (e1.Heading.Y == 0) //Moving straight right.
					//Touching e2's left side. Push back e1's right side to e2's left side.
					e1.Position = new Vector2(e2left - e1width, e1top);
				else if (e1.Heading.Y < 0) //Moving Up-Right
					if ((e1right - e2left) < (e2bottom - e1top))
						//Touching e2's left side. Push back e1's right side to e2's left side. Keep up movement.
						e1.Position = new Vector2(e2left - e1width, e1top);
					else 
						//Touching e2's bottom side. Push back e1's up side to e2's bottom side. Keep right movement.
						e1.Position = new Vector2(e1left, e2bottom);
				else //(e1.Heading.Y > 0) //Moving Down-Right
					if ((e1right - e2left) < (e1bottom - e2top))
						//Touching e2's left side. Push back e1's right side to e2's left side. Keep down movement.
						e1.Position = new Vector2(e2left - e1width, e1top);
					else
						//Touching e2's top side. Push back e1's bottom side to e2's top side. Keep right movement.
						e1.Position = new Vector2(e1left, e2top - e1height);
			else if (e1.Heading.X < 0) //Moving left
				if (e1.Heading.Y == 0) //Moving straight left.
					//Push back e1's left side to e2's right side.
					e1.Position = new Vector2(e2right, e1top);
				else if (e1.Heading.Y < 0) //Moving Up-Left
					if ((e2right - e1left) < (e2bottom - e1top))
						//Touching e2's right side. Push back e1's left side to e2's right side. Keep up movement
						e1.Position = new Vector2(e2right, e1top);
					else
						//Touching e2's bottom side. Push back e1's top side to e2's bottom side. Keep left movement
						e1.Position = new Vector2(e1left, e2bottom);
				else // (e1.Heading.Y > 0) //Moving Down-Left
					if ((e2right - e1left) < (e1bottom - e2top))
						//Touching e2's right side. Push back e1's left side to e2's right side. Keep down movement
						e1.Position = new Vector2(e2right, e1top);
					else
						//Touching e2's top side. Push back e1's bottom side to e2's top side. Keep left movement
						e1.Position = new Vector2(e1left, e2top - e1height);
			else //e1.Heading.X == 0  //Moving up/down
				if (e1.Heading.Y > 0) //Moving down
					//Touching e2's top side. Push back e1's bottom side to e2's top side.
					e1.Position = new Vector2(e1left, e2top - e1height);
				else// (e1.Heading.Y < 0) //Moving up
					//Touching e2's bottom side.  Push back e1's top side to e2's bottom side.
					e1.Position = new Vector2(e1left, e2bottom);
			//else e1.Heading.X == 0 AND e1.Heading.Y == 0. <--- should not be possible

			e1.Velocity = new Vector2(0, 0); //Not sure if this is needed

			return;
		}
	}
}