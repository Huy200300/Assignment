using Assignment.Entities;
using MySql.Data.MySqlClient;

namespace Assignment.Dal.Checks
{
	public class Checks
	{
		public bool CheckLoginCustomer(string id, string pass)
		{
			Employees employees = new Employees();

			DBHelper.OpenConnection();
			MySqlCommand cmd = new MySqlCommand("Select * from Customers where Customers_ID = @id and Password = @pass", DBHelper.OpenConnection());
			cmd.Parameters.AddWithValue("@id", id);

			cmd.Parameters.AddWithValue("@pass", pass);

			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			MySqlDataReader reader = cmd.ExecuteReader();


			if (reader.Read())
			{
				return true;
			}
			DBHelper.CloseConnection();

			return false;
		}
		public bool CheckEmployee(string id)
		{
			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			MySqlCommand cmd = new MySqlCommand("Select * from Employees where Employees_ID = @id ", DBHelper.OpenConnection());
			cmd.Parameters.AddWithValue("@id", id);

			MySqlDataReader reader = cmd.ExecuteReader();


			if (reader.Read())
			{
				return true;
			}
			DBHelper.CloseConnection();

			return false;
		}
		public bool CheckIDCus(string id)
		{
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("Select * from Customers where Customers_ID = @id ", DBHelper.OpenConnection());

			cmd.Parameters.AddWithValue("@id", id);
			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			MySqlDataReader reader = cmd.ExecuteReader();


			if (reader.Read())
			{
				return true;
			}
			DBHelper.CloseConnection();
			return false;
		}
		public bool CheckIDBRoom(int id)
		{
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("Select * from BookRooms where BookRooms_ID = @id ", DBHelper.OpenConnection());

			cmd.Parameters.AddWithValue("@id", id);
			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			MySqlDataReader reader = cmd.ExecuteReader();


			if (reader.Read())
			{
				return true;
			}
			return false;
		}
		public bool CheckIDRoom(int id)
		{
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("Select * from Rooms where Rooms_ID = @id ", DBHelper.OpenConnection());

			cmd.Parameters.AddWithValue("@id", id);
			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			MySqlDataReader reader = cmd.ExecuteReader();


			if (reader.Read())
			{
				return true;
			}
			return false;
		}
		public bool CheckLoginEmployees(string id, string pass)
		{
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("Select * from Employees where Employees_ID = @id and Password = @pass", DBHelper.OpenConnection());

			cmd.Parameters.AddWithValue("@id", id);

			cmd.Parameters.AddWithValue("@pass", pass);
			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			MySqlDataReader reader = cmd.ExecuteReader();


			if (reader.Read())
			{
				return true;
			}
			DBHelper.CloseConnection();

			return false;
		}
		public bool CheckTypeRooms(int id)
		{
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("Select * from TypeRooms where TypeRooms_ID = @id", DBHelper.OpenConnection());

			cmd.Parameters.AddWithValue("@id", id);

			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			MySqlDataReader reader = cmd.ExecuteReader();


			if (reader.Read())
			{
				return true;
			}
			DBHelper.CloseConnection();

			return false;
		}
		public bool CheckTypePrice(int id)
		{
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("Select * from TypePrices where TypePrices_ID = @id", DBHelper.OpenConnection());

			cmd.Parameters.AddWithValue("@id", id);

			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			MySqlDataReader reader = cmd.ExecuteReader();


			if (reader.Read())
			{
				return true;
			}
			DBHelper.CloseConnection();

			return false;
		}
		public bool CheckEmptyEmployees(string id)
		{
			Employees employees = new Employees();
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("Select * from Employees where Employees_ID = @id ", DBHelper.OpenConnection());

			cmd.Parameters.AddWithValue("@id", id);

			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			MySqlDataReader reader = cmd.ExecuteReader();

			if (id.ToString() == null || !reader.Read())
			{
				return true;
			}
			else
			{
				DBHelper.CloseConnection();
				return false;
			}

		}
		public bool CheckNoEmptyEmployees(string id)
		{
			Employees employees = new Employees();
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("Select * from Employees where Employees_ID = @id ", DBHelper.OpenConnection());

			cmd.Parameters.AddWithValue("@id", id);

			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			MySqlDataReader reader = cmd.ExecuteReader();


			if (reader.Read())
			{
				return true;
			}
			else
			{
				DBHelper.CloseConnection();
				return false;
			}

		}
		public void CheckInputEmpty(string type)
		{
			do
			{
				if (string.IsNullOrWhiteSpace(type))
				{
					TextColor(ConsoleColor.Red, " This Information Cannot Be Left Blank");
					Console.Write(" Please re-enter : ");
					type = Console.ReadLine() ?? "";
				}
			} while (string.IsNullOrWhiteSpace(type));
		}
		public void TextColor(ConsoleColor color, string str)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(str);
			Console.ResetColor();
		}
		public void Invoice(string id)
		{
			DBHelper.OpenConnection();
			MySqlCommand cmd = new MySqlCommand("Select BookRooms_CheckOutDate,BookRooms_DateBooking,BookRooms_RoomRentalDate from BookRooms where Customers_ID = @id  ", DBHelper.OpenConnection());

			cmd.Parameters.AddWithValue("@id", id);

			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			MySqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				Console.WriteLine("| {0,22} | {1,21} | {2,22} |", "Check Out Date", "Room Rental Date", "Date Booking");
				string row = $"| {reader["BookRooms_CheckOutDate"].ToString(),5} | {reader["BookRooms_RoomRentalDate"].ToString(),13} | {reader["BookRooms_DateBooking"].ToString(),10} |";
				Console.WriteLine(row);
			}
			DBHelper.CloseConnection();
		}
		public bool Invoices(Receipts receipts)
		{
			DBHelper.OpenConnection();
			MySqlCommand cmd = new MySqlCommand("select BookRooms_CheckOutDate,BookRooms_DateBooking,BookRooms_RoomRentalDate from BookRooms where BookRooms_CheckOutDate = @out and BookRooms_DateBooking = @date ", DBHelper.OpenConnection());

			cmd.Parameters.AddWithValue("@out", receipts.checkOutDate);

			cmd.Parameters.AddWithValue("@date", receipts.dateBook);

			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			MySqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				return true;
			}
			DBHelper.CloseConnection();
			return false;
		}
		public void TotalMoney(string id)
		{
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("sp_totalMoney", DBHelper.OpenConnection());

			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@cusId", id);


			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			MySqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				string row = $" Amount you have to pay : {reader["Total Money"].ToString(),6} ";
				Console.WriteLine(row);
			}
			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			cmd.ExecuteNonQuery();

		}
	}
}