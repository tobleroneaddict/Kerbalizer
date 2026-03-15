using System.Collections;
using System.Text;
using UnityEngine;

public class ResultLogger : Object
{
	public static void logObject(object result)
	{
		if (result.GetType() == typeof(ArrayList))
		{
			logArraylist((ArrayList)result);
		}
		else if (result.GetType() == typeof(Hashtable))
		{
			logHashtable((Hashtable)result);
		}
	}

	public static void logArraylist(ArrayList result)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (Hashtable item in result)
		{
			addHashtableToString(stringBuilder, item);
			stringBuilder.Append("\n--------------------\n");
		}
	}

	public static void logHashtable(Hashtable result)
	{
		StringBuilder builder = new StringBuilder();
		addHashtableToString(builder, result);
	}

	public static void addHashtableToString(StringBuilder builder, Hashtable item)
	{
		foreach (DictionaryEntry item2 in item)
		{
			if (item2.Value is Hashtable)
			{
				builder.AppendFormat("{0}: ", item2.Key);
				addHashtableToString(builder, (Hashtable)item2.Value);
			}
			else if (item2.Value is ArrayList)
			{
				builder.AppendFormat("{0}: ", item2.Key);
				addArraylistToString(builder, (ArrayList)item2.Value);
			}
			else
			{
				builder.AppendFormat("{0}: {1}\n", item2.Key, item2.Value);
			}
		}
	}

	public static void addArraylistToString(StringBuilder builder, ArrayList result)
	{
		foreach (object item in result)
		{
			if (item is Hashtable)
			{
				addHashtableToString(builder, (Hashtable)item);
			}
			else if (item is ArrayList)
			{
				addArraylistToString(builder, (ArrayList)item);
			}
			builder.Append("\n--------------------\n");
		}
	}
}
