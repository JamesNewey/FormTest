namespace FormsTest.Models
{
    public class Property
    {
        public string Address { get; set; }

        public List<Resident> Residents { get; set; } = new List<Resident>();
    }
}
