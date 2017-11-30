#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace SampleBrowser
{
	public class AgricultureData
	{
		public AgricultureData(string name,string type,int count)
		{
			Name = name;
			Type = type;
			index = count;
		}

		public string Name {
			get;
			set;
		}

		public string Type {
			get;
			set;
		}

		public int index {
			get;
			set;
		}
	}
}

