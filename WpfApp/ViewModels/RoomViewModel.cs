using BusinessObject;
using Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp.Helpers;

namespace WPFApp.ViewModels
{
    public class RoomViewModel : BaseViewModel
    {
        private readonly RoomInformationService _roomService = new RoomInformationService();
        private readonly RoomTypeService _roomTypeService = new RoomTypeService();

        public ObservableCollection<RoomInformation> Rooms { get; set; }
        public ObservableCollection<RoomType> RoomTypes { get; set; }

        private RoomInformation _selectedRoom;
        public RoomInformation SelectedRoom
        {
            get => _selectedRoom;
            set { _selectedRoom = value; OnPropertyChanged(); }
        }

        private string _searchKeyword;
        public string SearchKeyword
        {
            get => _searchKeyword;
            set { _searchKeyword = value; OnPropertyChanged(); SearchRooms(); }
        }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SortAscCommand { get; }
        public ICommand SortDescCommand { get; }

        public RoomViewModel()
        {
            Rooms = new ObservableCollection<RoomInformation>(_roomService.GetAllRooms());
            RoomTypes = new ObservableCollection<RoomType>(_roomTypeService.GetAllRoomTypes());

            AddCommand = new RelayCommand(_ => AddRoom());
            UpdateCommand = new RelayCommand(_ => UpdateRoom(), _ => SelectedRoom != null);
            DeleteCommand = new RelayCommand(_ => DeleteRoom(), _ => SelectedRoom != null);
            SortAscCommand = new RelayCommand(_ => SortRooms(true));
            SortDescCommand = new RelayCommand(_ => SortRooms(false));
        }

        private void RefreshData()
        {
            Rooms.Clear();
            foreach (var r in _roomService.GetAllRooms())
                Rooms.Add(r);
        }

        private void AddRoom()
        {
            try
            {
                var newRoom = new RoomInformation
                {
                    RoomNumber = "New Room",
                    RoomDescription = "Phòng mới tạo",
                    RoomMaxCapacity = 2,
                    RoomPricePerDate = 400000,
                    RoomTypeID = 1,
                    RoomStatus = 1
                };
                _roomService.AddRoom(newRoom);
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateRoom()
        {
            if (SelectedRoom == null) return;
            try
            {
                _roomService.UpdateRoom(SelectedRoom);
                MessageBox.Show("Cập nhật phòng thành công!");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteRoom()
        {
            if (SelectedRoom == null) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa phòng này?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _roomService.DeleteRoom(SelectedRoom.RoomID);
                RefreshData();
            }
        }

        private void SearchRooms()
        {
            Rooms.Clear();
            foreach (var r in _roomService.SearchRooms(SearchKeyword))
                Rooms.Add(r);
        }

        private void SortRooms(bool asc)
        {
            Rooms.Clear();
            foreach (var r in _roomService.SortRoomsByPrice(asc))
                Rooms.Add(r);
        }
    }
}
