using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using CoreGraphics;
using CoreAnimation;
using SceneKit;
using ARKit;
using CoreFoundation;

namespace ARLingo
{
	public partial class SettingsViewController : UITableViewController
	{
		public SettingsViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			PopulateSettings();
		}

		private void PopulateSettings() {
			dragOnInfinitePlanesSwitch.On = AppSettings.DragOnInfinitePlanes;
			scaleWithPinchGestureSwitch.On = AppSettings.ScaleWithPinchGesture;
		}
		[Action("didChangeSetting:")]
		public void SettingChanged(UISwitch sender)
		{
			if (sender == dragOnInfinitePlanesSwitch)
			{
				AppSettings.DragOnInfinitePlanes = dragOnInfinitePlanesSwitch.On;
			}
			if (sender == scaleWithPinchGestureSwitch)
			{
				AppSettings.ScaleWithPinchGesture = scaleWithPinchGestureSwitch.On;
			}
		}
	}
}
