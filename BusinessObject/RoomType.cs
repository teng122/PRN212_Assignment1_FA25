namespace BusinessObject
{
    public class RoomType
    {
        public int RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
        public string TypeDescription { get; set; }
        public string TypeNote { get; set; }

        public override string ToString()
        {
            return RoomTypeName;
        }
    }
}
