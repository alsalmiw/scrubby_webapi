using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using scrubby_webapi.Services.Context;

namespace scrubby_webapi.Services
{
    public class DependentService
    {
        private readonly DataContext _context;
        public DependentService(DataContext context)
        {
            _context = context; 
        }

        public bool AddDependent(DependentModel newDependent)
        {
            _context.Add(newDependent);
            return _context.SaveChanges() !=0;
            
            
        }                                                               
        public bool UpdateDependent(DependentModel dependentUpdate)
        {
            _context.Update<DependentModel>(dependentUpdate);
            return _context.SaveChanges() != 0;
            
        }

       public IEnumerable<DependentModel> GetDependantByUserId (int userId)
        {
            return _context.DependentInfo.Where(d => d.UserId == userId);
        }
    }
}