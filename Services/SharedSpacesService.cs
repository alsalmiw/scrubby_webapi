using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using scrubby_webapi.Services.Context;

namespace scrubby_webapi.Services
{
    public class SharedSpacesService
    {
        private readonly DataContext _context;
        public SharedSpacesService(DataContext context)
        {
            _context = context; 
        }

        public bool CreateSharedSpaces(SharedSpacesModel spaceToCreate)
        {
            _context.Add(spaceToCreate);
            return _context.SaveChanges() !=0;
        }
        public bool DeleteSharedSpacesById(int Id)
        {
            SharedSpacesModel foundSharedSpaces = GetSharedSpacesById(Id);
            bool result = false;
            if(foundSharedSpaces != null)
            {
                foundSharedSpaces.isDeleted = !SpaceCollection.isDeleted;;
                _context.Update<SharedSpacesModel>(foundSharedSpaces);
               result =  _context.SaveChanges() != 0;
            }
            return result;
        }
        public SharedSpacesModel GetSharedSpacesById(int Id)
        {
            return  _context.SharedSpacesInfo.SingleOrDefault(item => item.Id == Id);
        }
        public IEnumerable<SharedSpacesModel> GetSharedSpacesByUserId(int UserId)
        {
           return  _context.SharedSpacesInfo.Where(item => item.Id == UserId);
        }
    }
        
    }
}