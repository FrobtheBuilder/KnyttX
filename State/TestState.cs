using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KnyttX
{
	public class TestState : GameState
	{
		public Entity Test1;
		public Entity Test2;

		public TestState(Game game) : base(game)
		{
			Test1 = new Entity(Game, new Sprite(Game.Content.Load<Texture2D>("Img/sprites/juni")), new Vector2(300, 0));
			Components.Add(Test1);

			Test2 = new Entity(Game, new Sprite(Game.Content.Load<Texture2D>("Img/sprites/juni")), ComponentsAsEntityList);
			Components.Add(Test2);

			Test2.Collide += (source, e) => Console.WriteLine("Collided with " + e.Other);
			Test2.StopCollide += (source, e) => Console.WriteLine("Stopped colliding with " + e.Other);
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			Test2.Position += new Vector2(1, 0);
		}

		public override void Initialize() 
		{
			base.Initialize();
			Console.WriteLine("Initialized");
		}
	}
}
