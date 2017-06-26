using System.Collections.Generic;
using System.Linq;

namespace cyoaCreator
{
    public class InMemoryStoryDal : IStoryDal
    {
        private Dictionary<int, Story> stories = new Dictionary<int, Story>();
        private int nextId;

        public List<Story> GetAll()
        {
            lock (stories)
            {
                return stories.Values.ToList();
            }
        }

        public Story Get(int id)
        {
            lock (stories)
            {
                return stories[id];
            }
        }

        public int Insert(Story story)
        {
            lock (stories)
            {
                story.Id = nextId;
                nextId++;
                stories[story.Id] = story;
                return story.Id;
            }
        }

        public void Update(Story story)
        {
            lock (stories)
            {
                stories[story.Id] = story;
            }
        }
    }
}
