using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlParser
{
	public class TestObject
	{
		[HtmlObjectAttribute("name")]
		public string FirstName { get; } = "Dus";
		[HtmlObjectAttribute("age")]
		public int Age { get; } = 10;
		[HtmlObjectAttribute("lastname")]
		public string LastName { get; } = "dan";
		[HtmlObjectAttribute("fullname")]
		public string FullName 
		{
			get 
			{
				if (!String.IsNullOrEmpty(this.FirstName) && !String.IsNullOrEmpty(this.LastName))
					return $"{this.FirstName} - {this.LastName}";

				return "";
			}
		}
	}
}
