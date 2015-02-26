using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using KnyttX;

namespace KnyttX
{
	public class Sprite
	{
		public Vector2 Origin { get; set; }
		public Texture2D Texture { get; set; }
		public float Rotation { get; set; }
		public SpriteEffects Effect { get; set; }
		public Color Color { get; set; }
		public Vector2 TopLeft {
			get {
				return -Origin;
			}
		}
			

		public Sprite(Texture2D texture, Vector2 origin, float rotation)
		{
			Texture = texture;
			Origin = origin;
			Rotation = rotation;
			Color = Color.White;
		}

		public Sprite() : this(null, Vector2.Zero, 0f)
		{}

		public Sprite(Texture2D texture) : this(texture, Vector2.Zero, 0f)
		{}

		public Sprite(Texture2D texture, Vector2 origin) : this(texture, origin, 0f)
		{}

		public void Draw(SpriteBatch sb, Vector2 position)
		{
			sb.Draw(
				Texture,
				position,
				null,
				null,
				Origin,
				Rotation,
				null,
				this.Color,
				Effect
			);
		}
	}
}
