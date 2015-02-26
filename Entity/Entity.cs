using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KnyttX
{
	public delegate void CollisionHandler(object source, CollideEventArgs e);

	public class Entity : SBDGameComponent
	{
		public Sprite Sprite { get; set; }
		public Vector2 Position { get; set; }
		public Rectangle Hitbox { get; set; }
		public Rectangle PositionedHitbox {
			get {
				return new Rectangle((int)Position.X, (int)Position.Y, Hitbox.Width, Hitbox.Height);
			}
		}

		public List<Entity> CollidesWith { get; set; }
		private List<Entity> collidingWith;

		public event CollisionHandler Collide;
		public event CollisionHandler StopCollide;

		public Entity(Game game, Sprite sprite, Vector2 position, Rectangle hitbox, List<Entity> collidesWith) : base(game)
		{
			Sprite = sprite;
			Position = position;
			Hitbox = hitbox;
			CollidesWith = collidesWith;
			collidingWith = new List<Entity>();
		}

		public Entity(Game game, Sprite sprite, Vector2 position) : this(game, sprite, position, sprite.Texture.Bounds, new List<Entity>()) 
		{}

		public Entity(Game game, Sprite sprite) : this(game, sprite, Vector2.Zero, sprite.Texture.Bounds, new List<Entity>())
		{}

		public Entity(Game game, Sprite sprite, List<Entity> collidesWith) : this(game, sprite, Vector2.Zero, sprite.Texture.Bounds, collidesWith)
		{}

		public Entity(Game game, Sprite sprite, Vector2 position, List<Entity> collidesWith) : this(game, sprite, position, sprite.Texture.Bounds, collidesWith)
		{}

		public override void Update(GameTime gameTime)
		{
			List<Entity> toRemove = new List<Entity>();
			foreach (Entity e in collidingWith) {
				if (!PositionedHitbox.Intersects(e.PositionedHitbox)) {

					if (StopCollide != null)
						StopCollide(this, new CollideEventArgs(e));

					toRemove.Add(e);
				}
			}

			foreach (Entity e in toRemove) {
				collidingWith.Remove(e);
			}

			foreach (Entity e in CollidesWith) {
				if (PositionedHitbox.Intersects(e.PositionedHitbox)) {
					if (!collidingWith.Contains(e) && e != this) {

						if (Collide != null)
							Collide(this, new CollideEventArgs(e));

						collidingWith.Add(e);
					}
				}
			}
		}

		public override void Draw(SpriteBatch sb)
		{
			Sprite.Draw(sb, Position);
		}
	}
}

