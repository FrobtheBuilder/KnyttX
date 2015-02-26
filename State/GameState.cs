using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace KnyttX
{
	public class GameState : SBDGameComponent
	{
		public GameComponentCollection components;
		public GameComponentCollection Components {
			get { return components; }
		}

		public List<Entity> ComponentsAsEntityList {
			get {
				var toReturn = new List<Entity>();
				foreach (IGameComponent g in Components) {
					if (g is Entity)
						toReturn.Add((Entity)g);
				}
				return toReturn;
			}
		}


		public GameState(Game game) : base(game)
		{
			components = new GameComponentCollection();
		}

		public override void Initialize() 
		{
			components.ComponentAdded += (sender, e) => {
				e.GameComponent.Initialize();
				((GameComponent)e.GameComponent).Enabled = true;
			};

			Components.ComponentRemoved += (sender, e) => 
				((GameComponent)e.GameComponent).Enabled = false;
		}

		public override void Update(GameTime gameTime) {
			foreach (GameComponent c in components)
				c.Update(gameTime);
		}

		public override void Draw(SpriteBatch sb)
		{
			foreach (ISBDrawable d in components)
				d.Draw(sb);
		}

		public void Swap(GameState to)
		{
			((KnyttGame)Game).Components.Remove(this);
			((KnyttGame)Game).Components.Add(to);
		}
	}
}
