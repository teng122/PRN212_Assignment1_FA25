using BusinessObject;
using Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp.Helpers;

namespace WPFApp.ViewModels
{
    public class RoomTypeViewModel : BaseViewModel
    {
        private readonly RoomTypeService _service = new RoomTypeService();

        public ObservableCollection<RoomType> RoomTypes { get; set; }

        private RoomType _selectedRoomType;
        public RoomType SelectedRoomType
        {
            get => _selectedRoomType;
            set { _selectedRoomType = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public RoomTypeViewModel()
        {
            RoomTypes = new ObservableCollection<RoomType>(_service.GetAllRoomTypes());

            AddCommand = new RelayCommand(_ => AddRoomType());
            UpdateCommand = new RelayCommand(_ => UpdateRoomType(), _ => SelectedRoomType != null);
            DeleteCommand = new RelayCommand(_ => DeleteRoomType(), _ => SelectedRoomType != null);
        }

        private void RefreshData()
        {
            RoomTypes.Clear();
            foreach (var rt in _service.GetAllRoomTypes())
                RoomTypes.Add(rt);
        }

        private void AddRoomType()
        {
            try
            {
                var newType = new RoomType
                {
                    RoomTypeName = "New Type",
                    TypeDescription = "Mô tả loại phòng",
                    TypeNote = "Ghi chú"
                };
                _service.AddRoomType(newType);
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateRoomType()
        {
            if (SelectedRoomType == null) return;
            try
            {
                _service.UpdateRoomType(SelectedRoomType);
                MessageBox.Show("Cập nhật loại phòng thành công!");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteRoomType()
        {
            if (SelectedRoomType == null) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa loại phòng này?", "Xác nhận", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                _service.DeleteRoomType(SelectedRoomType.RoomTypeID);
                RefreshData();
            }
        }
    }
}
