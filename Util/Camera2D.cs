using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KnyttX
{
	public class Camera2D
	{
		protected float zoom;
		public float Zoom {
			get { return zoom; }
			set { 
				zoom = value;
				if (zoom < 0.1f) zoom = 0.1f;
			}
		}

		public Matrix transform;

		public Vector2 position;
		public Vector2 Position {
			get { return position; }
			set { position = value; }
		}

		protected float rotation;
		public float Rotation {
			get { return rotation; }
			set { rotation = value; }
		}

		public Camera2D()
		{
			zoom = 1.0f;
			rotation = 0.0f;
			position = Vector2.Zero;

		}

		public void Move(Vector2 amount) {
			position += amount;
		}

		public Matrix GetTransformation(GraphicsDevice gd)
		{
			transform = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) *
														Matrix.CreateRotationZ(Rotation) *
														Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
														Matrix.CreateTranslation(new Vector3(gd.Viewport.Width * 0.5f, gd.Viewport.Height * 0.5f, 0));
			return transform;
		}
	}
}

