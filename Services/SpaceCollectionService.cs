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
        public bool CreateSpaceCollection(CreateSpaceCollectionModel SpaceCollectionToCreate)
        {
            _context.Add(newCreatedAssignedTaskChild);
            return _context.SaveChanges() !=0;
        }
        //edit or update
        
        public SpaceCollectionModel GetSpaceCollectionById(int CollectionId)
        {
            return _data.GetSpaceCollectionInfo.SingleOrDefault(item => item.Id == CollectionId);
        }

        public SpaceCollectionModel GetSpaceCollectionByUserId(int UserId)
        {
            return _data.GetSpaceCollectionInfo.Where(item => item.Id == CollectionId);
        }
        public bool DeleteSpaceCollectionByCollectionId(int CollectionId)
        {
            SpaceCollectionModel SpaceCollection = GetSpaceCollectionById(CollectionId);

            SpaceCollection.IsDeleted = !SpaceCollection.IsDeletedIsDeleted;
            _context.Update<SpaceCollectionModel>(SpaceCollection);
            return _context.SaveChanges() != 0;
        }

        //update space collection name
        public bool UpdateSpaceCollectionNameByUserId(int UserId, string CollectionName)
        {
            bool result = false;
            SpaceCollectionModel SpaceCollection = GetSpaceCollectionByUserId(UserId);
            if(SpaceCollection !=null)
            {
                SpaceCollection.CollectionName= CollectionName;
                _context.Update<SpaceCollectionModel>(founSpaceCollectiondUser);
                result = _context.SaveChanges()!=0;
            }
            return result;
        }
    }
}