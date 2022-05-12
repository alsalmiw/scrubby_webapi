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
            return _context.DependentInfo.Where(d => d.UserId == userId && d.IsDeleted==false);
        }

        public DependentModel GetDependentById (int id)
        {
            return _context.DependentInfo.SingleOrDefault(d => d.Id == id);
        }
        public DependentModel NewCoinAmount(DependentModel newAmount)
        {
                DependentModel childInfo = GetDependentById(newAmount.Id);
              
            bool result = false;
            if (childInfo != null)
            {
                //A user was foundUser
                childInfo.DependentCoins = newAmount.DependentCoins;
                _context.Update<DependentModel>(childInfo);
                result = _context.SaveChanges() != 0;

               
            }
            return result? childInfo : null;
        }

        public DependentModel UpdatedChildPassCode(DependentModel passCodeUpdate)
        {
            DependentModel childInfo = GetDependentById(passCodeUpdate.Id);

            bool result = false;
            if(childInfo !=null)
            {
                childInfo.DependentPassCode = passCodeUpdate.DependentPassCode;
                _context.Update<DependentModel>(childInfo);
                result = _context.SaveChanges()!=0;
            }
            return result? childInfo :null;
        }
    }
}