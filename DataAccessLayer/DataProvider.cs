using BusinessObject;

namespace DAO
{
    public class DataProvider
    {
        private static DataProvider? _instance;
        private static readonly object _lock = new object();

        public List<Customer> Customers { get; set; }
        public List<RoomType> RoomTypes { get; set; }
        public List<RoomInformation> Rooms { get; set; }
        public List<BookingReservation> BookingReservations { get; set; }
        public List<BookingDetail> BookingDetails { get; set; }

        private DataProvider()
        {
            // Initialize data
            InitializeData();
        }

        public static DataProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DataProvider();
                        }
                    }
                }
                return _instance;
            }
        }

        private void InitializeData()
        {
            // Initialize RoomTypes
            RoomTypes = new List<RoomType>
            {
                new RoomType { RoomTypeID = 1, RoomTypeName = "Standard", TypeDescription = "Standard Room", TypeNote = "Basic amenities" },
                new RoomType { RoomTypeID = 2, RoomTypeName = "Deluxe", TypeDescription = "Deluxe Room", TypeNote = "Premium amenities" },
                new RoomType { RoomTypeID = 3, RoomTypeName = "Suite", TypeDescription = "Suite Room", TypeNote = "Luxury amenities" }
            };

            // Initialize Customers
            Customers = new List<Customer>
            {
                new Customer
                {
                    CustomerID = 1,
                    CustomerFullName = "Nguyen Van A",
                    Telephone = "0901234567",
                    EmailAddress = "nguyenvana@gmail.com",
                    CustomerBirthday = new DateTime(1990, 5, 15),
                    CustomerStatus = 1,
                    Password = "123456"
                },
                new Customer
                {
                    CustomerID = 2,
                    CustomerFullName = "Tran Thi B",
                    Telephone = "0912345678",
                    EmailAddress = "tranthib@gmail.com",
                    CustomerBirthday = new DateTime(1995, 8, 20),
                    CustomerStatus = 1,
                    Password = "123456"
                }
            };

            // Initialize Rooms
            Rooms = new List<RoomInformation>
            {
                new RoomInformation
                {
                    RoomID = 1,
                    RoomNumber = "101",
                    RoomDescription = "Standard room with city view",
                    RoomMaxCapacity = 2,
                    RoomStatus = 1,
                    RoomPricePerDate = 500000,
                    RoomTypeID = 1
                },
                new RoomInformation
                {
                    RoomID = 2,
                    RoomNumber = "102",
                    RoomDescription = "Deluxe room with sea view",
                    RoomMaxCapacity = 3,
                    RoomStatus = 1,
                    RoomPricePerDate = 800000,
                    RoomTypeID = 2
                },
                new RoomInformation
                {
                    RoomID = 3,
                    RoomNumber = "201",
                    RoomDescription = "Suite with balcony",
                    RoomMaxCapacity = 4,
                    RoomStatus = 1,
                    RoomPricePerDate = 1200000,
                    RoomTypeID = 3
                }
            };

            BookingReservations = new List<BookingReservation>();
            BookingDetails = new List<BookingDetail>();
        }
    }
}