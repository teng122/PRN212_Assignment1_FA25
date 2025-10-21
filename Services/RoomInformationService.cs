using BusinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class RoomInformationService
    {
        private readonly IRoomInformationRepository _repo;
        private readonly IRoomTypeRepository _typeRepo;

        public RoomInformationService()
        {
            _repo = new RoomInformationRepository();
            _typeRepo = new RoomTypeRepository();
        }

        public List<RoomInformation> GetAllRooms()
        {
            var rooms = _repo.GetRooms().Where(r => r.RoomStatus == 1).ToList();

            // gắn RoomType để hiển thị dễ hơn trong UI
            foreach (var r in rooms)
                r.RoomType = _typeRepo.GetRoomTypeById(r.RoomTypeID);

            return rooms;
        }

        public void AddRoom(RoomInformation room)
        {
            if (string.IsNullOrWhiteSpace(room.RoomNumber))
                throw new Exception("Số phòng không được để trống.");
            if (room.RoomPricePerDate <= 0)
                throw new Exception("Giá phòng phải lớn hơn 0.");

            _repo.SaveRoom(room);
        }

        public void UpdateRoom(RoomInformation room)
        {
            if (string.IsNullOrWhiteSpace(room.RoomNumber))
                throw new Exception("Số phòng không được để trống.");
            _repo.UpdateRoom(room);
        }

        public void DeleteRoom(int id) => _repo.DeleteRoom(id);

        // 🔎 Tìm kiếm phòng theo mô tả hoặc loại
        public List<RoomInformation> SearchRooms(string keyword)
        {
            var data = GetAllRooms();
            if (string.IsNullOrWhiteSpace(keyword)) return data;

            return data.Where(r =>
                r.RoomDescription.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                (r.RoomType?.RoomTypeName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ?? false))
                .ToList();
        }

        // 📊 Sắp xếp phòng theo giá
        public List<RoomInformation> SortRoomsByPrice(bool ascending = true)
        {
            var data = GetAllRooms();
            return ascending
                ? data.OrderBy(r => r.RoomPricePerDate).ToList()
                : data.OrderByDescending(r => r.RoomPricePerDate).ToList();
        }
    }
}
