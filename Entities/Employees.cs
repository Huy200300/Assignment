namespace Assignment.Entities
{
	public class Employees
	{
		public string? id { get; set; }
		public Positions? positions;
		public string? firstName { get; set; }
		public string? lastName { get; set; }
		public string? address { get; set; }
		public string? phone { get; set; }
		public DateTime birth { get; set; }
		public string? gender { get; set; }
		public string? pass { get; set; }
		public string? states{get;set;}
	}
}