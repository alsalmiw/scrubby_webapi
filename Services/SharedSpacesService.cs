using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using scrubby_webapi.Models.DTO;
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
                foundSharedSpaces.IsDeleted = !foundSharedSpaces.IsDeleted;
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

        public IEnumerable<SharedSpacesModel> GetSharedSpacesByInvitedAndInviterUsername(string InvitedUsername, string InviterUsername)
        {
            return _context.SharedSpacesInfo.Where(item => item.InvitedUsername == InvitedUsername && item.InviterUsername == InviterUsername);
        }

         public List<SharedSpacesDTO> GetSharedCollectionWithByCollectionId(int id)
        {

            List<SharedSpacesDTO> sharedSpacesDTO = new List<SharedSpacesDTO>();

            List<SharedSpacesModel> sharedCollection = _context.SharedSpacesInfo.Where(collection => collection.CollectionId == id && (collection.IsDeleted == false && collection.IsAccepted == true)).ToList();

            for (int i = 0; i < sharedCollection.Count; i++)
            {
                SharedSpacesDTO sharedSpaceWith = new SharedSpacesDTO();
                sharedSpaceWith.Id = sharedCollection[i].Id;
                UserModel findInvited = _context.UserInfo.SingleOrDefault(user=> user.Username==sharedCollection[i].InvitedUsername);
                sharedSpaceWith.InvitedId = findInvited.Id;
                sharedSpaceWith.InvitedUsername = findInvited.Username;
                sharedSpaceWith.InvitedName = findInvited.Name;

                sharedSpacesDTO.Add(sharedSpaceWith);
            }

            return sharedSpacesDTO;

        }
    }
        
    
}