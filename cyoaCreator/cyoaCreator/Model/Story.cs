using System.Collections.Generic;

namespace cyoaCreator
{
    public class Story
    {
        public int Id { get; set; }

        public string Title { get; set; } 

        public string Author { get; set; }

        Dictionary<int, Page> Pages { get; set; }
    }
}
