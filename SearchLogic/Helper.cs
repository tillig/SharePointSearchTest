using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace SearchTest {
	/// <summary>
	/// Helper methods for SearchLogic.
	/// </summary>
	public class Helper {
		/// <summary>
		/// Serializes an object to a string via XML serialization.
		/// </summary>
		/// <param name="obj">The object to serialize.</param>
		/// <returns>A string representation of the object.</returns>
		public static string SerializeToString(object obj){
			StringBuilder buf = new StringBuilder();
			StringWriter writer = new StringWriter(buf);
			XmlSerializer slzr = new XmlSerializer(obj.GetType());
			slzr.Serialize(writer, obj);
			writer.Close();
			return buf.ToString();
		}
	}
}
