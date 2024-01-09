using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Repositories.Interfaces;
using TwitterClone.Core.Entities;
using TwitterClone.DatabaseAccessLayer.Contexts;

namespace TwitterClone.Business.Repositories.Implements
{
    internal class TopicRepository : GenericRepository<Topic>, ITopicRepository
    {
        public TopicRepository(TwitterCloneDbContext context) : base(context)
        {
        }
    }
}
