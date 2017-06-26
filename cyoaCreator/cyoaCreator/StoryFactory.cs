using System.IO;
using System.Reflection;

namespace cyoaCreator
{
    static class StoryFactory
    {
        static IStoryDal storyDal;

        public static IStoryDal CreateStoryDal()
        {
            if(storyDal == null)
            {
                var p = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var dir = Path.Combine(p, "stories");
                storyDal = new JsonFileDal(dir);
            }
            return storyDal;
        }
    }
}
