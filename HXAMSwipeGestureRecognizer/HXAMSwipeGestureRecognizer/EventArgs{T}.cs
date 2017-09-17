using System;
namespace HXAMSwipeGestureRecognizer
{
	public class EventArgs<T> : EventArgs
	{
		public EventArgs(T value)
		{
			this.Value = value;
		}

		/// <summary>
		/// Gets the value of the event argument
		/// </summary>
		public T Value { get; private set; }
	}

}
