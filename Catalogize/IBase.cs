using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
namespace File_Lib
{
    interface IBase
    {
        bool Add(Book bk);
        bool _exists(Book bk);
        bool Remove(Book bk);
        Book Find(string Value);

    }
}
