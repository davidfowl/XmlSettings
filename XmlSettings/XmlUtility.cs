namespace XmlSettings {
    using System.IO;
    using System.Xml.Linq;

    internal static class XmlUtility {
        internal static XDocument GetOrCreateDocument(XName rootName, string path) {
            if (File.Exists(path)) {
                try {
                    return GetDocument(path);
                }
                catch (FileNotFoundException) {
                    return CreateDocument(rootName, path);
                }
            }
            return CreateDocument(rootName, path);
        }

        private static XDocument CreateDocument(XName rootName, string path) {
            XDocument document = new XDocument(new XElement(rootName));
            // Add it to the file system
            document.Save(path);
            return document;
        }

        internal static XDocument GetDocument(string path) {
            using (Stream configStream = File.OpenRead(path)) {
                return XDocument.Load(configStream);
            }
        }
    }
}
