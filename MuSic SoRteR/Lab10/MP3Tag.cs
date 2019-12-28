using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab10
{
    class MP3Tag
    {
        public string Name;
        public string   Size;
        public string Title;
        public string Album;
        public string Artist;
        public string Year;
        public string Genere;
        public string Comment;
      
        public void displayTag()
        {

            Console.Write("Title is: " + Title);
            Console.Write(" - Album is: " + Album);
            Console.Write(" - Artist is: " + Artist);
            Console.Write(" - Year is: " + Year);
            Console.WriteLine();
        }
    }
}
