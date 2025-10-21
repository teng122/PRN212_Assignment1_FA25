using BusinessObject;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class RoomTypeService
    {
        private readonly IRoomTypeRepository _repo;

        public RoomTypeService()
        {
            _repo = new RoomTypeRepository();
        }

        public List<RoomType> GetAllRoomTypes() => _repo.GetRoomTypes();

        public void AddRoomType(RoomType type)
        {
            if (string.IsNullOrWhiteSpace(type.RoomTypeName))
                throw new Exception("Tên loại phòng không được để trống.");
            _repo.SaveRoomType(type);
        }

        public void UpdateRoomType(RoomType type)
        {
            if (string.IsNullOrWhiteSpace(type.RoomTypeName))
                throw new Exception("Tên loại phòng không được để trống.");
            _repo.UpdateRoomType(type);
        }

        public void DeleteRoomType(int id) => _repo.DeleteRoomType(id);
    }
}
