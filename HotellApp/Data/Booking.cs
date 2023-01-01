using System.ComponentModel.DataAnnotations.Schema;

namespace HotellApp.Data;

public class Booking
{
    public int BookingID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime BookingDate { get; set; }

    public int RoomID { get; set; }

    [ForeignKey("RoomID")] public Room Room { get; set; }

    public int CustomerID { get; set; }

    [ForeignKey("CustomerID")] public Customer Customer { get; set; }

    public void UpdatedReservationDate(DateTime _dateStart, DateTime _dateEnd)
    {
        StartDate = _dateStart;
        EndDate = _dateEnd;
    }

    public void UpdatedReservationRoom(Room room)
    {
        Room = room;
    }
}