using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;

namespace XmlSettings
{
    internal static class XElementExtensions
    {
        public static string GetOptionalAttributeValue(this XElement element, string localName, string namespaceName = null)
        {
            XAttribute attr = null;
            if (String.IsNullOrEmpty(namespaceName))
            {
                attr = element.Attribute(localName);
            }
            else
            {
                attr = element.Attribute(XName.Get(localName, namespaceName));
            }
            return attr != null ? attr.Value : null;
        }

        public static string GetOptionalElementValue(this XElement element, string localName, string namespaceName = null)
        {
            XElement child;
            if (String.IsNullOrEmpty(namespaceName))
            {
                child = element.Element(localName);
            }
            else
            {
                child = element.Element(XName.Get(localName, namespaceName));
            }
            return child != null ? child.Value : null;
        }
    }
}
