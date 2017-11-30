#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Reflection;
using System.Collections;
using UIKit;
using CoreGraphics;
using SampleBrowser;
using SampleBrowser_Forms.iOS;

[assembly: ExportRenderer(typeof(ViewExt), typeof(ViewExtRenderer))]
namespace SampleBrowser_Forms.iOS
{
	public class ViewExtRenderer : ViewRenderer<ViewExt, UIView>
	{
		
		protected override void OnElementChanged (ElementChangedEventArgs<ViewExt> e)
		{
			base.OnElementChanged (e);

			IList items = e.NewElement.ItemsSource;

			var layout = new UIView ();

			Point point = new Point (20,20);

			foreach (var item in items)
			{
				var templateLayout = e.NewElement.ItemTemplate.CreateContent() as Xamarin.Forms.View;
				templateLayout.BindingContext = item;

				var renderer = Convert(templateLayout, (VisualElement)e.NewElement.Parent);
				var native = renderer as UIView ;

				var size = templateLayout.GetSizeRequest(0, 0);

				var width = size.Request.Width;
				var height = size.Request.Height;

				templateLayout.Layout(new Rectangle(0, 0, width, height));

				native.Frame = new CGRect (point.X, point.Y, width, height);

				point.X += width;

				layout.AddSubview (native);
			}

			SetNativeControl(layout);
		}

		public IVisualElementRenderer Convert(Xamarin.Forms.View source, Xamarin.Forms.VisualElement valid) 
		{
			IVisualElementRenderer render = (IVisualElementRenderer) source.GetValue(RendererProperty);

			if (render == null)
			{
				render = RendererFactory.GetRenderer(source);
				source.SetValue(RendererProperty, render);
				if (valid != null) {
					var p = PlatformProperty.GetValue(valid);
					if (p != null) {
						//PlatformProperty.SetValue(source, p);
						//IsPlatformEnabledProperty.SetValue(source, true);
					}
				}
			}

			return render;
		}


		private static Type _platformType = Type.GetType("Xamarin.Forms.Platform.iOS.Platform, Xamarin.Forms.Platform.iOS", true);
		private static BindableProperty _rendererProperty;
		public static BindableProperty RendererProperty
		{
			get { return _rendererProperty ?? (_rendererProperty = (BindableProperty)_platformType.GetField("RendererProperty", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public).GetValue(null)); }
		}

		private static PropertyInfo _isplatformenabledprop;
		public static PropertyInfo IsPlatformEnabledProperty {
			get { return _isplatformenabledprop ?? (
				_isplatformenabledprop = typeof(VisualElement).GetProperty("IsPlatformEnabled", BindingFlags.NonPublic | BindingFlags.Instance));
			}
		}

		private static PropertyInfo _platform;
		public static PropertyInfo PlatformProperty
		{
			get
			{
				return _platform ?? (
					_platform = typeof(VisualElement).GetProperty("Platform", BindingFlags.NonPublic | BindingFlags.Instance));
			}
		}
	}
}

