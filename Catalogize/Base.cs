using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using System.IO;

namespace File_Lib
{
    class Base : IBase
    {
        public string _path { get; set; }
        private XDocument _myBase { get; set; }
        public Base(string path)
        {
            this._path = path;
        }

        public bool _exists(Book bk)
        {
            _myBase = XDocument.Load(_path);
            foreach (XElement el in _myBase.Root.Elements("Book"))
            {
                if (el.Attribute("Name").Value == bk.Name)
                    return true;
                
            }
            return false;
            
        }


        public bool Add(Book bk)
        {
            if (File.Exists(_path))
            {
                _myBase = XDocument.Load(_path);
                XElement book = 
                    new XElement("Book",
                    new XAttribute("Name", bk.Name),
                    new XAttribute("Author", bk.Author),
                    new XAttribute("PublicationDate", bk._publDate),
                    new XAttribute("Path", bk._path),
                    new XAttribute("Raiting", bk._raiting),
                    new XAttribute("Theme", bk._theme)
                    );
                if (!_exists(bk))
                {
                    _myBase.Root.Add(book);
                    _myBase.Save(_path);
                    return true;
                }
                return false;
            }
            if(!File.Exists(_path))
            {
                _myBase = new XDocument(new XElement("Library", new XElement("Book",
                    new XAttribute("Name", bk.Name),
                    new XAttribute("Author", bk.Author),
                    new XAttribute("PublicationDate", bk._publDate),
                    new XAttribute("Path", bk._path),
                    new XAttribute("Raiting", bk._raiting),
                    new XAttribute("Theme", bk._theme))));
                _myBase.Save(_path);
                return true;
            }
            return false;
                
        }

        public bool Remove(Book bk)
        {
            if (!_exists(bk))
                return true;
            if (_exists(bk))
            {
                foreach (XElement el in _myBase.Root.Elements("Book"))
                {
                    if (el.Attribute("Name").Value == bk.Name)
                    {
                        el.Remove();
                        _myBase.Save(_path);
                        return true;
                    }
                        

                }

            }
            return false;
        }


        public Book Find(string val)
        {
            _myBase = XDocument.Load(_path);
            if (val == "")
                return null;
            foreach (XElement el in _myBase.Root.Elements())
            {

                if (el.Attribute("Name").Value.Contains(val))
                {
                    Book bk = new Book(
                        el.Attribute("Author").Value,
                        el.Attribute("Name").Value,
                        Int32.Parse(el.Attribute("PublicationDate").Value),
                        Int32.Parse(el.Attribute("Raiting").Value),
                        el.Attribute("Theme").Value,
                        el.Attribute("Path").Value);
                    return bk;

                }
            }
            return null;
        }

        public bool Change(Book bk)
        {
            _myBase = XDocument.Load(_path);
            if (bk == null)
                return false;
            if (!this._exists(bk))
                return false;
            foreach (XElement el in _myBase.Root.Elements())
            {
                if (el.Attribute("Name").Value.ToString() == bk.Name || el.Attribute("Path").ToString() == bk._path)
                {
                    this.Remove(bk);
                }
            }
            this.Add(bk);
            return true;
        }

    }
}
