﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан инструментальным средством
//     В случае повторного создания кода изменения, внесенные в этот файл, будут потеряны.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Catalogize
{
    public class Book : IBook
    {
        

        public Book(string Name, string Author, string Path, int PublicationDate, int Raiting, int id=0)
        {
            this.Name = Name;
            this.Author = Author;
            this.Path = Path;
            this.PublicationDate = PublicationDate;
            this.Raiting = Raiting;
            this._Id = id;
        }
        

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Author
        {
            get;
            set;
        }

        public virtual string Path
        {
            get;
            set;
        }

        public virtual int PublicationDate
        {
            get;
            set;
        }

        public virtual int Raiting
        {
            get;
            set;
        }

        public virtual int _Id
        {
            get;
            set;
        }

        public virtual bool Check()
        {
            bool isOk;
            if (Name != "" && Author != "" && Path != "" && PublicationDate != 0 && Raiting >= 0 && _Id >= 0)
                isOk = true;
            else
                isOk = false;
            return isOk;
        }
    }

}