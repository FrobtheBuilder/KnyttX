using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using OpenTK.Graphics.ES20;
using System.Threading;
using System.Collections.Generic;

namespace KnyttX
{
	public struct Animation {

		public Point Start;
		public int Length;
		public int Speed;

		public Animation(Point start, int length, int speed)
		{
			Start = start;
			Length = length;
			Speed = speed;
		}
	}

	public class AnimatedSprite : Sprite
	{
		public Point CurrentFrame;
		//public Rectangle[,] Frames { get; }

		public Point FrameDimensions { get; set; }
		public Point Frames { get; set; }

		public bool Playing { get; set; }

		public Dictionary<string, Animation> Animations { get; set; }
		private FrameTimer timer;

		private Animation currentAnimation;
		public Animation CurrentAnimation {
			get {
				return currentAnimation;
			}
			set {
				timer.Length = value.Length-1;
				timer.FramesPerTick = value.Speed;

				if (value.Speed == 0) {
					Stop();
				}
				else {
					Play();
				}
				currentAnimation = value;
				timer.Reset();
			}
		}


		private AnimatedSprite(Texture2D texture, Vector2 origin, float rotation) : base(texture, origin, rotation)
		{

		}

		public AnimatedSprite(Texture2D texture, Point frameDimensions, Point frameCounts) : base(texture, new Vector2(0, 0), 0f)
		{
			FrameDimensions = frameDimensions;
			Frames = frameCounts;
			CurrentFrame = new Point(0, 0);
			Animations = new Dictionary<string, Animation>();
			timer = new FrameTimer(1, 1);


			timer.Tick += (sender, e) => {
				CurrentFrame = new Point(
					((e.Current % frameCounts.X) + CurrentAnimation.Start.X),
					(int)Math.Floor((double)e.Current / (double)frameCounts.X) + CurrentAnimation.Start.Y
				);
			};
		}

		public void Update(GameTime gameTime)
		{
			timer.Update(gameTime);
		}

		public override void Draw(SpriteBatch sb, Vector2 position)
		{
			sb.Draw(
				Texture,
				position,
				new Rectangle(
					CurrentFrame.X * FrameDimensions.X,
					CurrentFrame.Y * FrameDimensions.Y, 
					FrameDimensions.X, 
					FrameDimensions.Y
				),
				Color,
				Rotation,
				Origin,
				1f,
				Effect,
				0f
			);
		}

		public void Play() 
		{
			timer.Start();
		}

		public void Stop()
		{
			timer.Stop();
		}
	}
}

