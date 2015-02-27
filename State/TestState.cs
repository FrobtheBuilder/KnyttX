using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KnyttX
{
	public class TestState : GameState
	{
		public Juni Juni1;
		public FrameTimer ft;

		public TestState(Game game) : base(game)
		{
			Juni1 = new Juni(Game, new Vector2(100, 100), ComponentsAsEntityList);
			Components.Add(Juni1);
			ft = new FrameTimer(9, 10);
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			ft.Update(gameTime);
		}

		public override void Initialize() 
		{
			base.Initialize();
			Console.WriteLine("Initialized");
		}
	}
}
