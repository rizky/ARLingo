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
    [Register ("ObjectCell")]
    partial class ObjectCell
    {
        void ReleaseDesignerOutlets ()
        {
            if (objectImageView != null) {
                objectImageView.Dispose ();
                objectImageView = null;
            }

            if (objectTitleLabel != null) {
                objectTitleLabel.Dispose ();
                objectTitleLabel = null;
            }
        }
    }
}