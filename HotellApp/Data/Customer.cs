namespace HotellApp.Data;

public class Customer
{
    public int CustomerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }


    public void ChangeCustomer(string firstname, string lastname, string phonenmbr)
    {
        FirstName = firstname;
        LastName = lastname;
        PhoneNumber = phonenmbr;
    }
}