using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Data.HttpServices
{
    public class FamilyWebService : IFamilyService
    {
        private readonly WebDbContext _fileContext;
        private readonly IList<Family> _families;

        public FamilyWebService()
        {
            _fileContext = new WebDbContext();
            _families = _fileContext.Families.ToList();
        }

        public async Task<IList<Family>> GetAllFamiliesAsync()
        {
            Console.WriteLine("Get families");
            return await _fileContext.Families.Include(f => f.Adults).Include(f => f.Children)
                .ThenInclude(c => c.Interests).Include(f => f.Children).ThenInclude(c => c.Pets).Include(f => f.Pets)
                .ToListAsync();
        }
        
        // public async Task<Family> GetFamilyAsync(int id)
        // {
        //     Console.WriteLine("Get family");
        //     return await _fileContext.Families.Include(f => f.Adults).Include(f => f.Children)
        //         .ThenInclude(c => c.Interests).Include(f => f.Children).ThenInclude(c => c.Pets).Include(f => f.Pets)
        //         .FirstOrDefaultAsync(f => f.Id == id);
        // }

        // public async Task<IList<Family>> GetAllFamiliesAsync()
        // {
        //     // IList<Family> tmp = new List<Family>(_families);
        //     // return tmp;
        //     Console.WriteLine("Get Families");
        //     return _fileContext.Families.Include(f => f.Adults).Include(f => f.Children)
        // }

        public async Task<Family> GetFamilyAsync(int id)
        {
            return _families.FirstOrDefault(t => t.Id == id);
        }

        public async Task<Family> AddFamilyAsync(Family family)
        {
            _families.Add(family);
            _fileContext.Families.Add(family);
            _fileContext.SaveChanges();
            Console.WriteLine("Added");
            return family;
        }

        public async Task RemoveFamilyAsync(int familyId)
        {
            Family ToRemove = _fileContext.Families.Include(family => family.Adults).Include(family => family.Children)
                .Include(family => family.Pets).First(f => f.Id == familyId);
            _families.Remove(ToRemove);
            _fileContext.Families.Remove(ToRemove);
            //_fileContext.removeFamily(toRemove);
            _fileContext.SaveChanges();
        }

        public async Task<Family> UpdateAsync(Family family)
        {
            Family toUpdate = _families.First(f => f.Id == family.Id);
            toUpdate.Adults = family.Adults;
            toUpdate.Children = family.Children;
            toUpdate.Pets = family.Pets;
            toUpdate.Photo = family.Photo;
            toUpdate.HouseNumber = family.HouseNumber;
            toUpdate.StreetName = family.StreetName;

            _fileContext.Families.Update(toUpdate);
            _fileContext.SaveChanges();
            return toUpdate;
        }
    }
}