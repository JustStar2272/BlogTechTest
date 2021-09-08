using BlogTechTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace BlogTechTest.Data.Repository
{
    public class Repository : IRepository
    {
        private ApplicationDbContext _ctx;
        public Repository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public void AddTopic(Topic topic)
        {
            _ctx.Topics.Add(topic);
        }

        public List<Topic> GetAllTopics()
        {
            return _ctx.Topics.ToList();
        }
        public List<Topic> GetAllTopics(string category)
        {
            return _ctx.Topics.Where(topic => topic.Category.ToLower().Equals(category.ToLower())).ToList();
        }


        public Topic GetTopic(int id)
        {
            return _ctx.Topics.FirstOrDefault(t => t.Id == id);
        }

        public void DeleteTopic(int id)
        {
            _ctx.Topics.Remove(GetTopic(id));
        }

        public void UpdateTopic(Topic topic)
        {
            _ctx.Topics.Update(topic);
        }  
       
        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

    }
}