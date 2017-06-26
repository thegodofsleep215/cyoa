using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace cyoaCreator
{
    public class JsonFileDal : IStoryDal
    {
        Regex fileRegex = new Regex(@"(?<id>\d+).json");
        private string dir;

        public JsonFileDal(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            this.dir = dir;
        }

        public Story Get(int id)
        {
            lock (dir)
            {
                var path = Path.Combine(dir, $"{id}.json");
                if (!File.Exists(path))
                {
                    return null;
                }

                return JsonConvert.DeserializeObject<Story>(File.ReadAllText(path));
            }
        }

        public List<Story> GetAll()
        {
            lock (dir)
            {
                return Directory.GetFiles(dir, "*.json").Select(f => JsonConvert.DeserializeObject<Story>(File.ReadAllText(f))).ToList();
            }
        }

        public int Insert(Story story)
        {
            lock (dir)
            {
                var files = Directory.GetFiles(dir, "*.json");
                int nextId = 0;
                if (files.Any())
                {
                    nextId = files.Select(f => fileRegex.Match(f)).Where(m => m.Success).Select(m => Convert.ToInt32(m.Groups["id"].Value)).Max() + 1;
                }
                story.Id = nextId;
                WriteStory(nextId, story);
                return nextId;
            }
        }

        private void WriteStory(int ident, Story story)
        {
            using (var sw = new StreamWriter(new FileStream(Path.Combine(dir, $"{ident}.json"), FileMode.Create)))
            {
                sw.WriteLine(JsonConvert.SerializeObject(story));
            }
        }

        public void Update(Story story)
        {
            lock (dir)
            {
                WriteStory(story.Id, story);
            }
        }
    }
}
