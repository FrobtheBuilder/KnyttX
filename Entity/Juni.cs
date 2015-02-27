using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace KnyttX
{
	public class Juni : Entity
	{
		public Juni(Game game, Sprite sprite, Vector2 position, Rectangle hitbox, List<Entity> collidesWith)
																: base(game, sprite, position, hitbox, collidesWith)
		{

		}

		public Juni(Game game, Vector2 position, List<Entity> collidesWith) 
			: this(game, null, position, new Rectangle(0, 0, 16, 16), collidesWith)
		{
			Sprite = new AnimatedSprite(
				Game.Content.Load<Texture2D>("Img/sprites/juni"),
				new Point(24, 24),
				new Point(10, 10)
			);
			AnimatedSprite = (AnimatedSprite)Sprite;

			AnimatedSprite.Animations.Add("idle", new Animation(new Point(7, 4), 1, 0));
			AnimatedSprite.Animations.Add("walk", new Animation(new Point(0, 0), 10, 2));
			AnimatedSprite.Animations.Add("run", new Animation(new Point(0, 1), 12, 2));

			AnimatedSprite.CurrentAnimation = AnimatedSprite.Animations["run"];
		}
	}
}

