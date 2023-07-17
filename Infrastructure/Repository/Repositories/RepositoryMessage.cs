using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryMessage : RepositoryGenerics<Message>, IMessage
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        //TODO:
        //Vericar se está correto https://www.youtube.com/watch?v=VsSVGVAxh0E&list=PLP8qOphXwRnIOzXzoviI5xwxcc4-dV_pd&index=3 min 28
        public RepositoryMessage(DbContextOptions<ContextBase> optionsBuilder) : base(optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }
    }
}
