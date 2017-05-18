namespace cyoaCreator
{
    static class StoryFactory
    {
        static IStoryDal storyDal = new InMemoryStoryDal();

        public static IStoryDal CreateStoryDal()
        {
            return storyDal;
        }
    }
}
