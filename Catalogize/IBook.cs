using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace File_Lib
{
    interface IBook
    {
        string Author { get; set; }
        string Name { get; set; }
        int _publDate { get; set; }
        int _raiting { get; set; }
        string _theme { get; set; }
        string _path { get; set; }
    }
}
