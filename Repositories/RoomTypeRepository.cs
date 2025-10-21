using BusinessObject;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        public List<RoomType> GetRoomTypes() => RoomTypeDAO.GetRoomTypes();
        public RoomType? GetRoomTypeById(int id) => RoomTypeDAO.GetRoomTypeById(id);
        public void SaveRoomType(RoomType roomType) => RoomTypeDAO.SaveRoomType(roomType);
        public void UpdateRoomType(RoomType roomType) => RoomTypeDAO.UpdateRoomType(roomType);
        public void DeleteRoomType(int id) => RoomTypeDAO.DeleteRoomType(id);
    }
}