using BusinessObject;
using System.Collections.Generic;

namespace Repositories
{
    public interface IRoomTypeRepository
    {
        List<RoomType> GetRoomTypes();
        RoomType? GetRoomTypeById(int id);
        void SaveRoomType(RoomType roomType);
        void UpdateRoomType(RoomType roomType);
        void DeleteRoomType(int id);
    }
}