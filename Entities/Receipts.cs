namespace Assignment.Entities
{
	public class Receipts
	{
		public int id { get; set; }
		public DateTime checkOutDate { get; set; }
		public DateTime roomRentalDate { get; set; }
		public DateTime dateBook{get;set;}
		public double totalMoney { get; set; }
		public string? customers{get;set;}
	}
}