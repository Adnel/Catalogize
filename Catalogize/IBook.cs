using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Catalogize
{
     interface IBook
    {
        string Name { get; set; }

        string Author { get; set; }

        int PublicationDate { get; set; }

        int Raiting { get; set; }

        string Path { get; set; }

        int _Id { get; set; }

        bool Check();
    }
}

