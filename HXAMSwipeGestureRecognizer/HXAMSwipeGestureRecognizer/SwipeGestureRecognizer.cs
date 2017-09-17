using System;
using Xamarin.Forms;

namespace HXAMSwipeGestureRecognizer
{
	public class SwipeGestureRecognizer : PanGestureRecognizer
	{
		private double translateX = 0, translateY = 0;

		public event EventHandler<EventArgs<Direction>> OnSwipe;

		public SwipeGestureRecognizer()
		{
			this.PanUpdated += HandlePanUpdated;
		}

		private void HandlePanUpdated(object sender, PanUpdatedEventArgs e)
		{
			View Content = (View)sender;

			switch (e.StatusType)
			{
				case GestureStatus.Running:
					try
					{
						translateX = e.TotalX;
						translateY = e.TotalY;
					}
					catch (Exception err)
					{
						System.Diagnostics.Debug.WriteLine("SwipeGestureRecognizer" + err.Message);
					}
					break;
				case GestureStatus.Completed:

					if (translateX < 0 && Math.Abs(translateX) > Math.Abs(translateY))
						OnSwipe?.Invoke(sender, Direction.left);
					else if (translateX > 0 && translateX > Math.Abs(translateY))
						OnSwipe?.Invoke(sender, Direction.right);
					else if (translateY < 0 && Math.Abs(translateY) > Math.Abs(translateX))
						OnSwipe?.Invoke(sender, Direction.up);
					else if (translateY > 0 && translateY > Math.Abs(translateX))
						OnSwipe?.Invoke(sender, Direction.down);

					break;
			}
		}
	}


}
