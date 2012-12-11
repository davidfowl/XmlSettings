namespace XmlSettings
{
    using System.IO;
    using System.Xml.Linq;

    internal static class XmlUtility
    {
        internal static XDocument GetDocument(XName rootName, string path, bool createIfNotExists)
        {
            if (File.Exists(path))
            {
                try
                {
                    return GetDocument(path);
                }
                catch (FileNotFoundException)
                {
                    if (createIfNotExists)
                    {
                        return CreateDocument(rootName, path);
                    }
                }
            }
            if (createIfNotExists)
            {
                return CreateDocument(rootName, path);
            }
            return null;
        }

        private static XDocument CreateDocument(XName rootName, string path)
        {
            XDocument document = new XDocument(new XElement(rootName));
            // Add it to the file system
            // Note: document.Save internally opens file for FileAccess.Write 
            // but does allow other dirty read (FileShare.Read).   it is the most
            // optimal where write is infrequent and dirty read is acceptable.
            document.Save(path);
            return document;
        }

        internal static XDocument GetDocument(string path)
        {
            // opens file for FileAccess.Read but does allow other read/write (FileShare.ReadWrite).   
            // it is the most optimal where write is infrequent and dirty read is acceptable.
            using (var configStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                return XDocument.Load(configStream);
            }
        }
    }
}
