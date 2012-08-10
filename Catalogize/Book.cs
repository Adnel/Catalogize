using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace File_Lib
{
    class Book : IBook
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public int _publDate { get; set; }
        public int _raiting { get; set; }
        public string _theme { get; set; }
        public string _path { get; set; }
        public Book(string _author, string _name, int _pubDate, int _rate, string _theme, string _path)
        {
            this.Author = _author;
            this.Name = _name;
            this._publDate = _pubDate;
            this._raiting = _rate;
            this._theme = _theme;
            this._path = _path;
        }

        public Book(string _author, string _name)
            : this(_author, _name, 0, 0, "", "")
        { }

        public Book(string _author, string _name, int _pubDate)
            : this(_author, _name, _pubDate, 0, "", "")
        { }

        public override string ToString()
        {
            return string.Format("Name: {0}\nAuthor: {1}\nPublication Date: {2}\nTheme: {3}\nRaiting: {4}\nPath: {5}\n", this.Name, this.Author, this._publDate, this._theme, this._raiting, this._path);
        }
    }
}
