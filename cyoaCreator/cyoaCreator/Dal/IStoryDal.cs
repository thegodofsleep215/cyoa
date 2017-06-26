using System.Collections.Generic;

namespace cyoaCreator
{
    public interface IStoryDal
    {
        List<Story> GetAll();

        int Insert(Story story);

        void Update(Story story);

        Story Get(int id);
    }
}
