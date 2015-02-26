using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KnyttX
{
	public abstract class SBDGameComponent : GameComponent, ISBDrawable
	{
		protected SBDGameComponent(Game game) : base(game)	
		{}

		public abstract void Draw(SpriteBatch sb);
	}
}

