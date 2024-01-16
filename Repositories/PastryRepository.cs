using BakeryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace BakeryAPI.Repositories
{
    public class PastryRepository : IBakeryRepository
    {
        private readonly PastryContext _context;

        public PastryRepository(PastryContext context)
        {
            _context = context;
        }
        public async Task<Pastry> Create(Pastry pastry)
        {
            _context.pastries.Add(pastry);
            await _context.SaveChangesAsync();
            return pastry;
        }

        public async Task Delete(int PastryId)
        {
            var pastryToDelete = await _context.pastries.FindAsync(PastryId);
            _context.pastries.Remove(pastryToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pastry>> Get()
        {
            return await _context.pastries.ToListAsync();
        }

        public async Task<Pastry> Get(int PastryId)
        {
            return await _context.pastries.FindAsync(PastryId);
        }
      
        public async Task<Pastry> Update(Pastry pastry)
        {
            _context.Entry(pastry).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return pastry;
        }
       


    }
}
