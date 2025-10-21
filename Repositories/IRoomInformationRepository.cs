using BusinessObject;
using System.Collections.Generic;

namespace Repositories
{
    public interface IRoomInformationRepository
    {
        List<RoomInformation> GetRooms();
        RoomInformation? GetRoomById(int id);
        void SaveRoom(RoomInformation room);
        void UpdateRoom(RoomInformation room);
        void DeleteRoom(int id);
    }
}