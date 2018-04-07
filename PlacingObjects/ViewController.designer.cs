// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ARLingo
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        public ARKit.ARSCNView SceneView { get; set; }


        [Outlet]
        public UIKit.UIButton AddObjectButton { get; set; }


        [Outlet]
        public UIKit.UIButton SettingsButton { get; set; }


        [Outlet]
        public UIKit.UIButton RestartExperienceButton { get; set; }


        [Outlet]
        public UIKit.UILabel MessageLabel { get; set; }


        [Outlet]
        public UIKit.UIView MessagePanel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AddObjectButton != null) {
                AddObjectButton.Dispose ();
                AddObjectButton = null;
            }

            if (MessageLabel != null) {
                MessageLabel.Dispose ();
                MessageLabel = null;
            }

            if (MessagePanel != null) {
                MessagePanel.Dispose ();
                MessagePanel = null;
            }

            if (RestartExperienceButton != null) {
                RestartExperienceButton.Dispose ();
                RestartExperienceButton = null;
            }

            if (SceneView != null) {
                SceneView.Dispose ();
                SceneView = null;
            }

            if (SettingsButton != null) {
                SettingsButton.Dispose ();
                SettingsButton = null;
            }
        }
    }
}