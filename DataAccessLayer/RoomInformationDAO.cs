using BusinessObject;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class RoomInformationDAO
    {
        private static List<RoomInformation> rooms = new List<RoomInformation>();

        static RoomInformationDAO()
        {
            rooms = new List<RoomInformation>
            {
                new RoomInformation { RoomID = 1, RoomNumber = "101", RoomDescription = "Phòng đơn tiêu chuẩn", RoomMaxCapacity = 1, RoomPricePerDate = 300000, RoomStatus = 1, RoomTypeID = 1 },
                new RoomInformation { RoomID = 2, RoomNumber = "202", RoomDescription = "Phòng đôi có ban công", RoomMaxCapacity = 2, RoomPricePerDate = 500000, RoomStatus = 1, RoomTypeID = 2 },
                new RoomInformation { RoomID = 3, RoomNumber = "VIP1", RoomDescription = "Phòng VIP sang trọng view biển", RoomMaxCapacity = 2, RoomPricePerDate = 1200000, RoomStatus = 1, RoomTypeID = 3 }
            };
        }

        public static List<RoomInformation> GetRooms() => rooms;

        public static RoomInformation? GetRoomById(int id)
            => rooms.FirstOrDefault(r => r.RoomID == id);

        public static void SaveRoom(RoomInformation room)
        {
            int nextId = rooms.Any() ? rooms.Max(x => x.RoomID) + 1 : 1;
            room.RoomID = nextId;
            rooms.Add(room);
        }

        public static void UpdateRoom(RoomInformation room)
        {
            var existing = GetRoomById(room.RoomID);
            if (existing != null)
            {
                existing.RoomNumber = room.RoomNumber;
                existing.RoomDescription = room.RoomDescription;
                existing.RoomMaxCapacity = room.RoomMaxCapacity;
                existing.RoomPricePerDate = room.RoomPricePerDate;
                existing.RoomStatus = room.RoomStatus;
                existing.RoomTypeID = room.RoomTypeID;
            }
        }

        public static void DeleteRoom(int id)
        {
            var existing = GetRoomById(id);
            if (existing != null)
            {
                // Xóa mềm
                existing.RoomStatus = 2;
            }
        }
    }
}
