using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using scrubby_webapi.Models.DTO;
using scrubby_webapi.Services.Context;

namespace scrubby_webapi.Services
{
    public class SpaceInfoService
    {
        private readonly DataContext _context;
        private readonly SelectedTasksService _selectedTasks;
        private readonly AssignedTasksUsersService _assignedTasksUsers;

        public SpaceInfoService(DataContext context, SelectedTasksService selectedTasks, AssignedTasksUsersService assignedTasksUsers)
        {
            _context = context;
            _selectedTasks = selectedTasks;
            _assignedTasksUsers = assignedTasksUsers;
        }

        public bool AddNewSpace(SpaceInfoModel newSpace)
        {
            _context.Add(newSpace);
            return _context.SaveChanges() != 0;
        }
        
        public IEnumerable<SpaceInfoModel> GetAllSpaces()
        {
            return _context.SpaceInfo;
        }

         public IEnumerable<SpaceInfoModel> GetSpacesByCollectionID(int id)
        {
            return _context.SpaceInfo.Where(space => space.CollectionId==id);
        }

        public List<SpacesDTO> GetRoomsByCollectionID(int id)
        {
            List<SpacesDTO> spaceByCollectionIdDTO = new List<SpacesDTO>();
            List<SpaceInfoModel> spaces = _context.SpaceInfo.Where(space => space.CollectionId == id).ToList();

            if (spaces != null)
            {
                for (int i = 0; i < spaces.Count; i++)
                {
                    SpacesDTO oneSpace = new SpacesDTO();
                    oneSpace.Id = spaces[i].Id;
                    oneSpace.SpaceName = spaces[i].SpaceName;
                    oneSpace.SpaceCategory = spaces[i].SpaceCategory;
                    oneSpace.Tasks = _selectedTasks.GetTasksBySpaceId(spaces[i].Id);
                    oneSpace.TasksAssigned = _assignedTasksUsers.GetAllAssignedTasksBySpaceId(spaces[i].Id);

                    spaceByCollectionIdDTO.Add(oneSpace);
                }
            }

            return spaceByCollectionIdDTO;
        }


         public SpacesDTO GetSpacesDTOByID(int id)
        {
            SpacesDTO spaceByCollectionIdDTO = new SpacesDTO();
            SpaceInfoModel spaces = _context.SpaceInfo.SingleOrDefault(space => space.Id == id);

                    SpacesDTO oneSpace = new SpacesDTO();
                    oneSpace.Id = spaces.Id;
                    oneSpace.SpaceName = spaces.SpaceName;
                    oneSpace.SpaceCategory = spaces.SpaceCategory;
                    oneSpace.Tasks = _selectedTasks.GetTasksBySpaceId(spaces.Id);
                    oneSpace.TasksAssigned = _assignedTasksUsers.GetAllAssignedTasksBySpaceId(spaces.Id);

            return oneSpace;
        }


        

    }
}