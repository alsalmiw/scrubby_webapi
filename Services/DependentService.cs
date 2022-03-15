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
        //private readonly DataContext _context;
        // public DependentService(DataContext context)
        // {
        //    // _context = context; 
        // }

        public bool AddDependent(DependentModel newDependent)
        {
            // _context.Add(newDependent);
            // return _context.SaveChanges() !=0;
            return false;
            
        }                                                               
        public bool UpdateDependent(DependentModel dependentUpdate)
        {
            // _context.Update<DependentModel>(DependentUpdate);
            // return _context.SaveChanges() != 0;
            return false;
        }
    }
}