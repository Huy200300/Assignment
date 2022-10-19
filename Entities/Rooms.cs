namespace Assignment.Entities
{
	public class Rooms
	{
		public int id { get; set; }
		public string? name { get; set; }
		public double price { get; set; }
		public int maxPeople { get; set; }
		public int floor { get; set; }
		public string? customers{get;set;}
		public int typeRooms{get;set;}
		public int typePrices{get;set;}
		public string? states{get;set;}
	}
}