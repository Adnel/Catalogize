using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace Catalogize
{
    public class Initialize
    {
        public Initialize(string path)
        {
            if (!File.Exists(path))
            {
                XDocument doc = new XDocument(new XElement("Library"));
                doc.Save(path);
            }
        }

    }
}
