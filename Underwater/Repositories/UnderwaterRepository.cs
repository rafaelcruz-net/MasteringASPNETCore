using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Underwater.Data;
using Underwater.Models;

namespace Underwater.Repositories
{
    public class UnderwaterRepository : IUnderwaterRepository
    {
        private UnderwaterContext _context;
        private IConfiguration _configuration;

        public UnderwaterRepository(UnderwaterContext context, IConfiguration configuration)
        {
            _context = context;

        }

        public IEnumerable<Fish> Getfishes()
        {
            return _context.Fishes.ToList();
        }

        public Fish GetFishById(int id)
        {
            return _context.Fishes.Include(a => a.Aquarium)
                 .SingleOrDefault(f => f.FishId == id);
        }

        public void AddFish(Fish fish)
        {
            _context.Add(fish);
            _context.SaveChanges();

        }

        public void RemoveFish(int id)
        {
            var fish = _context.Fishes.SingleOrDefault(f => f.FishId == id);
           
            _context.Fishes.Remove(fish);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IQueryable<Aquarium> PopulateAquariumsDropDownList()
        {
            var aquariumsQuery = from a in _context.Aquariums
                                 orderby a.Name
                                 select a;
            return aquariumsQuery;
        }

    }

    public interface IUnderwaterRepository
    {
        IEnumerable<Fish> Getfishes();
        Fish GetFishById(int id);
        void AddFish(Fish fish);
        void RemoveFish(int id);
        void SaveChanges();
        IQueryable<Aquarium> PopulateAquariumsDropDownList();
    }
}
