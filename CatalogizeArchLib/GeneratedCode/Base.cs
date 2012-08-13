using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Catalogize
{
    public class Base : IBase
    {
        List<Book> bookData { get; set; }
        XDocument xmlData { get; set; }
        int Id { get; set; }
        public Base(string path)
        {
            Id = 0;
            xmlData = XDocument.Load(path);
            try
            {
                foreach (XElement el in xmlData.Root.Elements("Book"))
                {
                    bookData.Add(new Book(el.Attribute("Name").Value, el.Attribute("Author").Value, el.Attribute("Path").Value, Int32.Parse(el.Attribute("PublicationDate").Value), Int32.Parse(el.Attribute("Raiting").Value), Id));
                    Id++;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public virtual bool Add(Book Book)
        {
            throw new System.NotImplementedException();
        }

        public virtual Book Find(string valueType, string value)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool Remove(Book book)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool Change(Book book)
        {
            throw new System.NotImplementedException();
        }

    }
}

