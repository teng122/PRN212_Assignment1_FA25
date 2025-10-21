using BusinessObject;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class RoomTypeDAO
    {
        private static List<RoomType> roomTypes = new List<RoomType>();

        static RoomTypeDAO()
        {
            roomTypes = new List<RoomType>
            {
                new RoomType { RoomTypeID = 1, RoomTypeName = "Single", TypeDescription = "Phòng 1 người", TypeNote = "Có giường đơn" },
                new RoomType { RoomTypeID = 2, RoomTypeName = "Double", TypeDescription = "Phòng 2 người", TypeNote = "Có giường đôi" },
                new RoomType { RoomTypeID = 3, RoomTypeName = "VIP", TypeDescription = "Phòng VIP sang trọng", TypeNote = "View biển" }
            };
        }

        public static List<RoomType> GetRoomTypes() => roomTypes;

        public static RoomType? GetRoomTypeById(int id)
            => roomTypes.FirstOrDefault(r => r.RoomTypeID == id);

        public static void SaveRoomType(RoomType type)
        {
            int nextId = roomTypes.Any() ? roomTypes.Max(x => x.RoomTypeID) + 1 : 1;
            type.RoomTypeID = nextId;
            roomTypes.Add(type);
        }

        public static void UpdateRoomType(RoomType type)
        {
            var existing = GetRoomTypeById(type.RoomTypeID);
            if (existing != null)
            {
                existing.RoomTypeName = type.RoomTypeName;
                existing.TypeDescription = type.TypeDescription;
                existing.TypeNote = type.TypeNote;
            }
        }

        public static void DeleteRoomType(int id)
        {
            var existing = GetRoomTypeById(id);
            if (existing != null)
            {
                roomTypes.Remove(existing);
            }
        }
    }
}
