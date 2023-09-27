using Week_3_Assignment_Simple_Text_File_and_Linked_Lists;

namespace Wk3_UnitTesting
{
    [TestClass]
    public class Wk3_UnitTesting
    {
        string UnitTesting_DataDirectory = "../../../data";
        DataHandler data = new DataHandler();

        private List<Room> TestRooms
        {
            get { return data.CreateRooms(UnitTesting_DataDirectory, "UnitTestingData/UnitTesting_room", "UnitTesting-Room-data/Room"); }
        } 


        #region Player Unit Testing
        /**/
        [TestMethod]
        [TestCategory("Player")]
        public void Player_MovePlayer()
        {
            List<Room> rooms = TestRooms;
            Player player = new Player("Nobody", rooms[1]);

            Assert.IsTrue(player.Move(rooms[2]) == $"Player in {rooms[2].GetName}");
        }

        [TestMethod]
        [TestCategory("Player")]
        public void Player_Instantiate()
        {
            List<Room> rooms = TestRooms;
            Player player = new Player("Nobody", rooms[1]);

            Assert.IsNotNull(player);
            Assert.IsTrue(player.Name == "Nobody");
            Assert.IsNotNull(player.Inventory);
        }
        /**/
        #endregion

        #region DataHandler Unit Testing
        [TestMethod]
        [TestCategory("DataHandler")]
        public void DataHandler_CreateRooms()
        {
            List<Room> rooms = data.CreateRooms(UnitTesting_DataDirectory, "UnitTestingData/UnitTesting_room", "UnitTesting-Room-data/Room");

            Assert.IsTrue(rooms.Count > 0);
        }
        [TestMethod]
        [TestCategory("DataHandler")]
        public void DataHandler_FindRoom()
        {
            int[] testingRoomIDs = { 0, 0, 0, 0 };
            List<Room> rooms = new List<Room>();
            rooms.Add(new Room(1, "Room 1", "Room 1", testingRoomIDs));
            rooms.Add(new Room(2, "Room 2", "Room 2", testingRoomIDs));
            rooms.Add(new Room(3, "Room 3", "Room 3", testingRoomIDs));
            rooms.Add(new Room(4, "Room 4", "Room 4", testingRoomIDs));

            Room targetRoom = data.FindRoom(3, rooms);

            Assert.IsTrue(targetRoom.GetDescription == "Room 3");
        }
        [TestMethod]
        [TestCategory("DataHandler")]
        public void DataHandler_CreateItems()
        {
            List<Item> items = new List<Item>();
            items = data.CreateItems(UnitTesting_DataDirectory, "UnitTestingData/Item_Data", "Item-data/Item",TestRooms);

            Assert.IsTrue(items.Count > 0);
        }
        
        #endregion

        #region Room Unit Testing
        [TestMethod]
        [TestCategory("Room")]
        public void Room_GetAdjacentRoom()
        {
            List<Room> rooms = TestRooms;

            Assert.IsTrue(TestRooms[2].GetID == TestRooms[1].GiveAdjRoomID(UIUtility.Directions.North)); //North
            Assert.IsTrue(TestRooms[3].GetID == TestRooms[1].GiveAdjRoomID(UIUtility.Directions.South)); //South
            Assert.IsTrue(TestRooms[4].GetID == TestRooms[1].GiveAdjRoomID(UIUtility.Directions.East)); //East
            Assert.IsTrue(TestRooms[5].GetID == TestRooms[1].GiveAdjRoomID(UIUtility.Directions.West)); //West
        }
        [TestMethod]
        [TestCategory("Room")]
        public void Room_InstatiationCorrect()
        {
            Assert.IsNotNull(TestRooms[0]); ;
        }
        [TestMethod]
        [TestCategory("Room")]
        public void Room_GetData()
        {
            int[] tempIDs = { 0, 0, 0, 0 };
            Room r = new Room(0, "Center", "Center Room", tempIDs);

            Assert.IsTrue(r.GetID == 0);
            Assert.IsTrue(r.GetName == "Center");
            Assert.IsTrue(r.GetDescription == "Center Room");
        }
        #endregion

        #region Item Unit Testing
        [TestMethod]
        [TestCategory("Item")]
        public void Item_Instantiation()
        {
            Item item = new Item("Item", "An Item", 4);

            Assert.IsNotNull(item);
        }
        [TestMethod]
        [TestCategory("Item")]
        public void Item_GetData()
        {
            Item item = new Item("Item", "An Item", 4);

            Assert.IsTrue(item.Name == "Item");
            Assert.IsTrue(item.Description == "An Item");
            Assert.IsTrue(item.Damage == 4);
        }
        #endregion





    }
}