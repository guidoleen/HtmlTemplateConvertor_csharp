using System;

namespace HtmlParser
{
	public class HtmlObjectAttribute : Attribute
	{
		public string MappingName { get; set; }
		public HtmlObjectAttribute(){}
		public HtmlObjectAttribute(string mappingName) 
		{
			this.MappingName = mappingName;
		}
	}
}
