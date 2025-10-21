using BusinessObject;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repositories
{
    public class RoomInformationRepository : IRoomInformationRepository
    {
        public List<RoomInformation> GetRooms() => RoomInformationDAO.GetRooms();
        public RoomInformation? GetRoomById(int id) => RoomInformationDAO.GetRoomById(id);
        public void SaveRoom(RoomInformation room) => RoomInformationDAO.SaveRoom(room);
        public void UpdateRoom(RoomInformation room) => RoomInformationDAO.UpdateRoom(room);
        public void DeleteRoom(int id) => RoomInformationDAO.DeleteRoom(id);
    }
}