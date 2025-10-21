namespace BusinessObject
{
    public class RoomInformation
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public string RoomDescription { get; set; }
        public int RoomMaxCapacity { get; set; }
        public decimal RoomPricePerDate { get; set; }
        public int RoomStatus { get; set; } // 1 = Active, 2 = Deleted
        public int RoomTypeID { get; set; }

        // Navigation property (optional)
        public RoomType? RoomType { get; set; }

        public override string ToString()
        {
            return $"{RoomNumber} - {RoomPricePerDate:C}";
        }
    }
}
