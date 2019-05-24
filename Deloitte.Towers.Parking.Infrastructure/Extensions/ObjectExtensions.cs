using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Deloitte.Towers.Parking.Infrastructure.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToXml(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            using (var writer = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(writer, new XmlWriterSettings { OmitXmlDeclaration = true }))
                {
                    var ser = new XmlSerializer(obj.GetType());
                    ser.Serialize(xmlWriter, obj, ns);
                    return writer.ToString();
                }
            }
        }

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        /// <summary>
        /// Turns a dictionary of string and object to an ExpandoObject
        /// </summary>
        public static ExpandoObject ToExpando(this IDictionary<string, object> dictionary)
        {
            var expando = new ExpandoObject();
            var expandoDic = (IDictionary<string, object>)expando;

            // go through the items in the dictionary and copy over the key value pairs)
            foreach (var kvp in dictionary)
            {
                // if the value can also be turned into an ExpandoObject, then do it!
                if (kvp.Value is IDictionary<string, object>)
                {
                    var expandoValue = ((IDictionary<string, object>)kvp.Value).ToExpando();
                    expandoDic.Add(kvp.Key, expandoValue);
                }
                else if (kvp.Value is ICollection)
                {
                    // iterate through the collection and convert any strin-object dictionaries
                    // along the way into expando objects
                    var itemList = new List<object>();
                    foreach (var item in (ICollection)kvp.Value)
                    {
                        var itemDict = item as IDictionary<string, object>;
                        if (itemDict != null)
                        {
                            var expandoItem = itemDict.ToExpando();
                            itemList.Add(expandoItem);
                        }
                        else
                        {
                            itemList.Add(item);
                        }
                    }

                    expandoDic.Add(kvp.Key, itemList);
                }
                else
                {
                    expandoDic.Add(kvp);
                }
            }

            return expando;
        }
    }
}
