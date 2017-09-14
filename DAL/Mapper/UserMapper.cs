using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapper
{
    public static class UserMapper
    {
        private static AutoMapper.IMapper user_DbToModel;
        private static AutoMapper.IMapper user_ModelToDb;
        private static AutoMapper.IMapper userToken_DbToUserModel;

        static UserMapper()
        {
            /* user_DbToModel */
            var config_user_DbToModel = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<db_CO01UT, UserModel>());
            user_DbToModel = config_user_DbToModel.CreateMapper();

            /* user_DbToModel */
            var config_user_ModelToDb = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<UserModel, db_CO01UT>());
            user_ModelToDb = config_user_ModelToDb.CreateMapper();

            /* userToken_DbToUserModel */
            var config_userToken_DbToUserModel = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<db_VW_USER_TOKEN, UserModel>());
            userToken_DbToUserModel = config_userToken_DbToUserModel.CreateMapper();
        }

        public static UserModel UserMapper_DbToModel(db_CO01UT db_rqtItem)
        {            
            return user_DbToModel.Map<UserModel>(db_rqtItem);
        }

        public static db_CO01UT UserMapper_ModelToDb(UserModel db_rqtItem)
        {
            return user_ModelToDb.Map<db_CO01UT>(db_rqtItem);
        }
        
        public static UserModel UserToken_DbUserToken(db_VW_USER_TOKEN db_rqtItem)
        {
            return userToken_DbToUserModel.Map<UserModel>(db_rqtItem);
        }        
    }
}
