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
     interface IBase
    {
        List<Book> _bookBase { get; set; }

        bool Add(Book book);

        Book Find(string valueType, string value);

        bool Remove(Book book);

        bool Change(Book book);

    }
}
