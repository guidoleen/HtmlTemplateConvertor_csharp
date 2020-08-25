using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace HtmlParser
{
	public class HtmlParserService<T>
	{
		public string ParseHtml(T obj, string html)
		{
			// new Regex(@"(\{{2})(.*)(\}{2})");
			var inputHtml = html;
			var propsfromObjectDictionary = new MapAttributeManager<T>(obj).MapPropertyToAttribute();
			var propsFromObject = propsfromObjectDictionary.GetEnumerator();

			Regex regex;

			while (propsFromObject.MoveNext())
			{
				// Regex to find occurrence in html string
				regex = new Regex(@"\{{2}" + propsFromObject.Current.Key + @"\}{2}");

				// Change 
				var replacement = propsFromObject.Current.Value.ToString();
				inputHtml = regex.Replace(inputHtml, replacement);
			}

			return inputHtml;
		}
	}
}
