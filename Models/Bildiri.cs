using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogify.Models
{
    public class Bildiri
    {
        public int Id {get;set;}
        public int WriterId {get;set;}
        public string WriterName {get;set;}
        public string Mesaj {get;set;}
        public bool Okundumu {get;set;}
    }
}