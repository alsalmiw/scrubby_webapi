using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scrubby_webapi.Models;
using scrubby_webapi.Services.Context;

namespace scrubby_webapi.Services
{
    public class UserInfoService
    {
        private readonly DataContext _context;
        public UserInfoService(DataContext context)
        {
            _context = context;
        }

        public UserInfoModel GetUserInfo(int? userid)
        {
            return _context.UserInfo.SingleOrDefault(user => user.UserId == userid);
        }
         //public List<UserInfoModel> userList = new List<UserInfoModel>()
        // {
        //     new UserInfoModel()
        //     {
        //         TrackerId  = 1,
        //         UserId = 1,
        //         Photo = "photo of user 1",
        //         Coins = 20
        //     },
        //     new UserInfoModel()
        //     {
        //         TrackerId  = 2,
        //         UserId = 2,
        //         Photo = "photo of user 2",
        //         Coins = 10
        //     },
        //     new UserInfoModel()
        //     {
        //         TrackerId  = 3,
        //         UserId = 3,
        //         Photo = "photo of user 3",
        //         Coins = 15
        //     },
        //     new UserInfoModel()
        //     {
        //         TrackerId  = 4,
        //         UserId = 4,
        //         Photo = "photo of user 4",
        //         Coins = 18
        //     },
        //     new UserInfoModel()
        //     {
        //         TrackerId  = 5,
        //         UserId = 5,
        //         Photo = "photo of user 5",
        //         Coins = 30
        //     }

        

        };

        // public List<UserInfoModel> GetUserInfos()
        // {
        //     return userList;
        // }
    }
