namespace HotellApp.Data;

public class Room
{
    public int RoomID { get; set; }

    public int RoomSize { get; set; }

    //public int RoomNumber { get; set; }
    public string RoomType { get; set; }
    public int RoomPrice { get; set; }
    public int AmountOfBeds { get; set; }


    public void ChangeRooms(int roomsize, string roomtype, int roomprice, int beds)
    {
        RoomSize = roomsize;
        RoomType = roomtype;
        RoomPrice = roomprice;
        AmountOfBeds = beds;
    }
}