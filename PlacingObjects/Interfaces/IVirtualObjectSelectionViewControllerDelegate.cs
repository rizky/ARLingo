using System;
using Foundation;
using UIKit;
using CoreGraphics;
using SceneKit;
using ARKit;

namespace ARLingo
{
	public interface IVirtualObjectSelectionViewControllerDelegate
	{
		void DidSelectObjectAt(int index);
		void DidDeselectObjectAt(int index);
	}
}
