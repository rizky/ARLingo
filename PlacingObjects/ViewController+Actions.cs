using System;
using System.Linq;
using System.Threading.Tasks;
using CoreFoundation;
using Foundation;
using SceneKit;
using UIKit;

namespace ARLingo
{
	public partial class ViewController : IUIPopoverPresentationControllerDelegate
	{
        public IVirtualObjectSelectionViewControllerDelegate Delegate { get; set; }

		static class SegueIdentifier
		{
			public static readonly NSString ShowSettings = new NSString("showSettings");
			public static readonly NSString ShowObjects = new NSString("showObjects");
		}

		[Export("adaptivePresentationStyleForPresentationController:")]
		public UIModalPresentationStyle GetAdaptivePresentationStyle(UIPresentationController forPresentationController)
		{
			return UIModalPresentationStyle.None;
		}

		[Export("adaptivePresentationStyleForPresentationController:traitCollection:")]
		public UIModalPresentationStyle GetAdaptivePresentationStyle(UIPresentationController controller, UITraitCollection traitCollection)
		{
			return UIModalPresentationStyle.None;
		}

		[Action("RestartExperience:")]
		public void RestartExperience(NSObject sender)
		{
			if (!RestartExperienceButton.Enabled || IsLoadingObject) 
			{
				return;
			}

			RestartExperienceButton.Enabled = false;

			UserFeedback.CancelAllScheduledMessages();
			UserFeedback.DismissPresentedAlert();
			UserFeedback.ShowMessage("STARTING A NEW SESSION");

			virtualObjectManager.RemoveAllVirtualObjects();
			AddObjectButton.SetImage(UIImage.FromBundle("add"), UIControlState.Normal);
			AddObjectButton.SetImage(UIImage.FromBundle("addPressed"), UIControlState.Highlighted);
			if (FocusSquare != null)
			{
				FocusSquare.Hidden = true;
			}
			ResetTracking();

			RestartExperienceButton.SetImage(UIImage.FromBundle("restart"), UIControlState.Normal);

			// Disable Restart button for a second in order to give the session enough time to restart.
			var when = new DispatchTime(DispatchTime.Now, new TimeSpan(0, 0, 1));
			DispatchQueue.MainQueue.DispatchAfter(when, () => SetupFocusSquare());
		}

        public void AddText()
        {
            if (Session == null || ViewController.CurrentFrame == null)
            {
                return;
            }
            var position = FocusSquare != null ? FocusSquare.LastPosition : new SCNVector3(0, 0, -1.0f);

            position.Z -= 0.05f; 
            String txt = "ARLingo";
            var scnText = SCNText.Create(txt, 1);
            var txtMaterial = SCNMaterial.Create();
            var bckgndMaterial = SCNMaterial.Create();
            txtMaterial.Diffuse.Contents = UIColor.Red;
            scnText.FirstMaterial = txtMaterial;

            var scnNode = SCNNode.Create();
            scnNode.Position = position;
            scnNode.Scale = new SCNVector3(0.005f, 0.005f, 0.015f);
            scnNode.Geometry = scnText;

            SceneView.Scene.RootNode.AddChildNode(scnNode);
        }

        MachineLearningModel model;

        void ClassifyImageAsync(UIImage img)
        {
            model = new MachineLearningModel();
            model.PredictionsUpdated += (s, e) => ShowPrediction(e.Value);
            Task.Run(() => model.Classify(img));
        }

        void ShowPrediction(ImageDescriptionPrediction imageDescriptionPrediction)
        {
            //Grab the first 5 predictions, format them for display, and show 'em
            InvokeOnMainThread(() =>
            {
                var message = $"{imageDescriptionPrediction.ModelName} thinks:\n";
                var topFive = imageDescriptionPrediction.predictions.Take(5);
                foreach (var prediction in topFive)
                {
                    var prob = prediction.Item1;
                    var desc = prediction.Item2;
                    message += $"{desc} : {prob.ToString("P") }\n";
                }

            });
        }

		[Action("chooseObject:")]
		public void ChooseObject(UIButton button)
		{
			// Abort if we are about to load another object to avoid concurrent modifications of the scene.
			if (IsLoadingObject)
			{
				return;
			}

			UserFeedback.CancelScheduledMessage(MessageType.ContentPlacement);
            AddText();
			//PerformSegue(SegueIdentifier.ShowObjects, button);
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			// All popover segues should be popovers even on iPhone.
			var popoverController = segue.DestinationViewController?.PopoverPresentationController;
			if (popoverController == null)
			{
				return;
			}
			var button = (UIButton)sender;
			popoverController.Delegate = this;
			popoverController.SourceRect = button.Bounds;
			var identifier = segue.Identifier;
			if (identifier == SegueIdentifier.ShowObjects)
			{
				var objectsViewController = segue.DestinationViewController as VirtualObjectSelectionViewController;
				objectsViewController.Delegate = this;
			}
		}
	}
}
