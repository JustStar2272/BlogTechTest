using BlogTechTest.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogTechTest.Data.Repository
{
    public interface IRepository
    {
        public Topic GetTopic(int id);
        List <Topic> GetAllTopics();
        List<Topic> GetAllTopics(string Category);
        void AddTopic(Topic topic);
        void DeleteTopic (int id);
        void UpdateTopic(Topic topic);

        Task<bool> SaveChangesAsync();
    }
}