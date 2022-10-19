namespace Assignment.Entities
{
	public class BookRooms
	{
		public int id { get; set; }
		public DateTime checkOutDate { get; set; }
		public DateTime roomRentalDate { get; set; }
		public DateTime dateBook{get;set;}
		public string? customers{get;set;}
		public int rooms{get;set;}
		public int receipts{get;set;}
		public string? states{get;set;}
	}
}