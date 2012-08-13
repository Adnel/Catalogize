using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Catalogize
{
     class Base : IBase
    {
       public List<Book> _bookBase { get; set; }
        XDocument xmlData { get; set; }
        int Id { get; set; }
        string _path { get; set; }
        public Base(string path)
        {
            _bookBase = new List<Book>();
            this._path = path;
            Id = -1;
            xmlData = XDocument.Load(path);
            try
            {
                foreach (XElement el in xmlData.Root.Elements("Book"))
                {
                    _bookBase.Add(new Book(el.Attribute("Name").Value, el.Attribute("Author").Value, el.Attribute("Path").Value, Int32.Parse(el.Attribute("PublicationDate").Value), Int32.Parse(el.Attribute("Raiting").Value), Int32.Parse(el.Attribute("Id").Value)));
                    Id = Int32.Parse(el.Attribute("Id").Value);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public virtual bool Add(Book book)
        {
            book._Id = ++Id;
            if (book.Check())
            {
                _bookBase.Add(book);
                return true;
            }
            else
                return false;
            
        }

        public virtual Book Find(string valueType, string value)
        {
            var findedBook = from bk in _bookBase
                       where bk.Name.Contains(value) ||
                       bk.Author.Contains(value) ||
                       bk.Raiting == Int32.Parse(value) ||
                       bk.PublicationDate == Int32.Parse(value)
                       select bk;
            foreach (Book l in findedBook)
                return l;

            return null;
        }

        public virtual bool Remove(Book book)
        {
            var bookToDel = from bk in _bookBase
                            where bk._Id == book._Id
                            select bk;

            foreach (Book l in bookToDel)
                _bookBase.Remove(l);
            return true;
        }

        public virtual bool Change(Book book)
        {
            _bookBase[book._Id] = book;
            return true;
        }


        public virtual bool Save()
        {
            xmlData = new XDocument(new XElement("Library"));
            foreach(Book bk in _bookBase)
            {
                xmlData.Root.Add (new XElement("Book",
                    new XAttribute("Name", bk.Name),
                    new XAttribute("Author", bk.Author),
                    new XAttribute("PublicationDate", bk.PublicationDate),
                    new XAttribute("Path", bk.Path),
                    new XAttribute("Raiting", bk.Raiting),
                    new XAttribute("Id", bk._Id)));
                
            }
            xmlData.Save(this._path);
            return true;
        }
    }
}

