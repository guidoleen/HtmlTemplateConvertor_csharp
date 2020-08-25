using System;
using System.Text;
using HtmlParser;

namespace HtmlTemplateConvertor
{
	public class Program
	{
		static void Main(string[] args)
		{
			TestObject testObject = new TestObject();
			// new HtmlParser.MapAttributeManager<TestObject>(testObject).DisplayPropertyValues();
			Console.WriteLine(
				new HtmlParserService<TestObject>().ParseHtml(testObject, new HtmlMock().GenerateHtml())
				);
		}
	}

	public class HtmlMock
	{
		public string GenerateHtml()
		{
			StringBuilder html = new StringBuilder();
			html.Append("<html><head></head><title>");
			html.Append($"{HtmlParserConstants.MarkUpOpen}name{HtmlParserConstants.MarkUpClose}");
			html.Append("</title><body>");
			html.Append($"{HtmlParserConstants.MarkUpOpen}fullname{HtmlParserConstants.MarkUpClose}");
			html.Append("</body></html>");

			return html.ToString();
		}
	}
}
