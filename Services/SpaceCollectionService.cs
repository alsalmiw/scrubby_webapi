using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using scrubby_webapi.Services.Context;

namespace scrubby_webapi.Services
{
    public class SpaceCollectionService
    {
        private readonly DataContext _context;
        public SpaceCollectionService(DataContext context)
        {
            _context = context;
        }
        public bool CreateSpaceCollection(SpaceCollectionModel SpaceCollectionToCreate)
        {
            _context.Add(SpaceCollectionToCreate);
            return _context.SaveChanges() !=0;
        }
        //edit or update
        
        public SpaceCollectionModel GetSpaceCollectionById(int Id)
        {
            return _context.SpaceCollectionInfo.SingleOrDefault(item => item.Id == Id);
        }

        public IEnumerable<SpaceCollectionModel> GetSpaceCollectionByUserId(int UserId)
        {
            return _context.SpaceCollectionInfo.Where(item => item.Id == UserId);
        }
        public bool DeleteSpaceCollectionById(int Id)
        {
            SpaceCollectionModel foundSpaceCollection = GetSpaceCollectionById(Id);
            bool result = false;
            if(foundSpaceCollection != null)
            {
                foundSpaceCollection.IsDeleted = !foundSpaceCollection.IsDeleted;
                _context.Update<SpaceCollectionModel>(foundSpaceCollection);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }

        //update space collection name
        public bool UpdateSpaceCollectionNameByUserId(int UserId, string CollectionName)
        {
            bool result = false;
            SpaceCollectionModel SpaceCollection = GetSpaceCollectionById(UserId);
            if(SpaceCollection !=null)
            {
                SpaceCollection.CollectionName= CollectionName;
                _context.Update<SpaceCollectionModel>(SpaceCollection);
                result = _context.SaveChanges()!=0;
            }
            return result;
        }
    }
}