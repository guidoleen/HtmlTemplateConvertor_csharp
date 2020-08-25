using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;

namespace HtmlParser
{
	public class MapAttributeManager<T>
	{
		private readonly T Obj;
		public MapAttributeManager(T obj)
		{
			this.Obj = obj;
		}

		private Dictionary<string, object> PropertyValuesAndAttributes()
		{
			Type t = this.Obj.GetType();
			Dictionary<string, object> propvaluesAttributes = new Dictionary<string, object>();
			PropertyInfo[] propertyInfo = t.GetProperties();

			foreach (var property in propertyInfo)
			{
				object[] propAttributes = (object[])property.GetCustomAttributes(typeof(HtmlObjectAttribute));
				for (int i = 0; i < propAttributes.Length; i++)
				{
					if (propAttributes[i].GetType().Equals(typeof(HtmlObjectAttribute)))
					{
						var name = propAttributes[i] as HtmlObjectAttribute;
						var propertyValue = property.GetValue(this.Obj);
						propvaluesAttributes.Add(name.MappingName, (object)propertyValue);
					}
				}
			}
			return propvaluesAttributes;
		}

		public Dictionary<string, object> MapPropertyToAttribute()
		{
			return this.PropertyValuesAndAttributes();
		}

		public void DisplayPropertyValues()
		{
			string values = "";
			IEnumerator propertyValues = PropertyValuesAndAttributes().GetEnumerator();

			while (propertyValues.MoveNext())
			{
				values += propertyValues.Current.ToString();
			}
			Console.WriteLine($"values: {values}");
		}
	}
}
