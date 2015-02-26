using System;

namespace KnyttX
{
	public class CollideEventArgs : EventArgs
	{
		public Entity Other { get; set; }

		public CollideEventArgs(Entity other)
		{
			Other = other;
		}
	}
}