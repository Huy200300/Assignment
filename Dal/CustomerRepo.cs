using Assignment.Entities;
using MySql.Data.MySqlClient;
using Assignment.Dal.Checks;
namespace Assignment.Dal.Checks
{
	public class CustomerRepo
	{
		Customer customers = new Customer();
		Employees employees = new Employees();
		TypeRooms typeRooms = new TypeRooms();
		TypePrices typePrices = new TypePrices();
		Rooms rooms = new Rooms();
		Checks check = new Checks();
		public bool AddCustomer(Customer customers)
		{
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("sp_createCustomer", DBHelper.OpenConnection());

			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@id", customers.id);

			cmd.Parameters.AddWithValue("@firstName", customers.firstName);

			cmd.Parameters.AddWithValue("@lastName", customers.lastName);

			cmd.Parameters.AddWithValue("@address", customers.address);

			cmd.Parameters.AddWithValue("@phone", customers.phone);

			cmd.Parameters.AddWithValue("@birth", customers.birth);

			cmd.Parameters.AddWithValue("@gender", customers.gender);

			cmd.Parameters.AddWithValue("@pass", customers.password);

			cmd.Parameters.AddWithValue("@states",customers.states);

			cmd.Parameters.Add(new MySqlParameter("@customerID", MySqlDbType.Text));
			cmd.Parameters["@customerID"].Direction = System.Data.ParameterDirection.Output;
			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			cmd.ExecuteNonQuery();

			return cmd.Parameters["@customerID"].Value != DBNull.Value;

		}
		public bool AddRoom(Rooms rooms)
		{
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("sp_createRoom", DBHelper.OpenConnection());

			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@id", rooms.id);

			cmd.Parameters.AddWithValue("@roomName", rooms.name);

			cmd.Parameters.AddWithValue("@price", rooms.price);

			cmd.Parameters.AddWithValue("@maxPeople", rooms.maxPeople);

			cmd.Parameters.AddWithValue("@floors", rooms.floor);

			cmd.Parameters.AddWithValue("@cus", rooms.customers);

			cmd.Parameters.AddWithValue("@type", rooms.typeRooms);

			cmd.Parameters.AddWithValue("@prices", rooms.typePrices);

			cmd.Parameters.AddWithValue("@states",rooms.states);


			cmd.Parameters.Add(new MySqlParameter("@roomID", MySqlDbType.Int32));
			cmd.Parameters["@roomID"].Direction = System.Data.ParameterDirection.Output;
			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			cmd.ExecuteNonQuery();

			return cmd.Parameters["@roomID"].Value != DBNull.Value;

		}
		public bool AddBookRoom(BookRooms bookRooms)
		{
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("sp_createBookRoom", DBHelper.OpenConnection());

			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@id", bookRooms.id);

			cmd.Parameters.AddWithValue("@checkOutDate", bookRooms.checkOutDate);

			cmd.Parameters.AddWithValue("@roomRentalDate", bookRooms.roomRentalDate);

			cmd.Parameters.AddWithValue("@dateBook", bookRooms.dateBook);

			cmd.Parameters.AddWithValue("@cus", bookRooms.customers);

			cmd.Parameters.AddWithValue("@room", bookRooms.rooms);

			cmd.Parameters.AddWithValue("@states",bookRooms.states);

			cmd.Parameters.Add(new MySqlParameter("@bookRoomID", MySqlDbType.Int32));
			cmd.Parameters["@bookRoomID"].Direction = System.Data.ParameterDirection.Output;
			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			cmd.ExecuteNonQuery();
			return cmd.Parameters["@bookRoomID"].Value != DBNull.Value;
		}
		public bool DeleteCustomer(Customer customers)
		{

			var detail = true;
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("sp_deleteCustomer", DBHelper.OpenConnection());
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.Add(new MySqlParameter("@cusId", customers.id));

			cmd.Parameters.AddWithValue("@states",customers.states);

			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			cmd.ExecuteNonQuery();
			return detail;
		}
		public bool UpdateCustomer(Customer customers)
		{
			var temp = true;
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("sp_upDateCustomers", DBHelper.OpenConnection());
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.Add(new MySqlParameter("@cusId", customers.id));

			cmd.Parameters.Add(new MySqlParameter("@ln", customers.lastName));

			cmd.Parameters.Add(new MySqlParameter("@fn", customers.firstName));

			cmd.Parameters.Add(new MySqlParameter("@address", customers.address));

			cmd.Parameters.Add(new MySqlParameter("@phone", customers.phone));

			cmd.Parameters.Add(new MySqlParameter("@birth", customers.birth));

			cmd.Parameters.Add(new MySqlParameter("@genders", customers.gender));

			cmd.Parameters.Add(new MySqlParameter("@pass", customers.password));

			cmd.Parameters.AddWithValue("@states",customers.states);

			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			cmd.ExecuteNonQuery();
			return temp;
		}
		public void DisplayCustomer(string id)
		{
			DBHelper.CloseConnection();
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("Select * from Customers where Customers_ID = @cusId", DBHelper.OpenConnection());

			cmd.Parameters.AddWithValue("@cusId", id);

			MySqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				string row = $"| {reader[0].ToString(),5} | {reader["Customers_FirstName"].ToString(),13} | {reader["Customers_LastName"].ToString(),10} | {reader["Customers_Address"],13} | {reader["Customers_Phone"].ToString(),14} | {reader["Customers_Birth"].ToString(),20} | {reader["Customers_Gender"].ToString(),13} | {reader["Password"].ToString(),10} | {reader["Customers_States"].ToString(),10} |";
				Console.WriteLine(row);
			}


			DBHelper.CloseConnection();
		}
		public void DisplayRoom(int id)
		{
			DBHelper.CloseConnection();
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("Select * from Rooms where Rooms_ID = @roId", DBHelper.OpenConnection());

			cmd.Parameters.AddWithValue("@roId", id);

			MySqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				string row = $"| {reader[0].ToString(),8} | {reader["Rooms_Name"].ToString(),13} | {reader["Rooms_Price"].ToString(),11} | {reader["Rooms_MaxPeople"],15} | {reader["Rooms_Floor"].ToString(),14} | {reader["Customers_ID"].ToString(),20} | {reader["TypeRooms_ID"].ToString(),13} | {reader["TypePrices_ID"].ToString(),13} | {reader["Rooms_States"].ToString(),12} |";
				Console.WriteLine(row);
			}


			DBHelper.CloseConnection();
		}
		public bool FindRooms(int id)
		{
			DBHelper.OpenConnection();
			MySqlCommand cmd = new MySqlCommand("Select * from BookRooms where Rooms_ID = @id ", DBHelper.OpenConnection());
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
		public bool FindNameRooms(string name)
		{
			DBHelper.OpenConnection();
			MySqlCommand cmd = new MySqlCommand("Select * from Rooms where Rooms_Name like concat('%',@name,'%') ", DBHelper.OpenConnection());
			cmd.Parameters.AddWithValue("@name", name);
			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			MySqlDataReader reader = cmd.ExecuteReader();
			if (!reader.Read())
			{
				return true;
			}
			DBHelper.CloseConnection();
			return false;
		}
		public bool AddPay(Receipts receipts)
		{
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("sp_createReceipts", DBHelper.OpenConnection());

			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@id",receipts.id);

			cmd.Parameters.AddWithValue("@dates", receipts.dateBook);

			cmd.Parameters.AddWithValue("@checks", receipts.checkOutDate);

			cmd.Parameters.AddWithValue("@room", receipts.roomRentalDate);

			cmd.Parameters.AddWithValue("@total", receipts.totalMoney);

			cmd.Parameters.AddWithValue("@cus", receipts.customers);

			cmd.Parameters.Add(new MySqlParameter("@recID", MySqlDbType.Int32));
			cmd.Parameters["@recID"].Direction = System.Data.ParameterDirection.Output;
			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			cmd.ExecuteNonQuery();

			return cmd.Parameters["@recID"].Value != DBNull.Value;

		}
		public void TotalMoney(string id)
		{
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("sp_totalMoney", DBHelper.OpenConnection());

			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@cusId", id);
			MySqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
                        string row = $"| {reader[0].ToString(),5} | {reader["Customers_FirstName"].ToString(),13} | {reader["Customers_LastName"].ToString(),10} | {reader["Customers_Address"],13} | {reader["Customers_Phone"].ToString(),14} | {reader["Customers_Birth"].ToString(),20} | {reader["Customers_Gender"].ToString(),13} | {reader["Password"].ToString(),10} | {reader["Customers_States"].ToString(),10} |";
				Console.WriteLine(row);
			}
			cmd.ExecuteNonQuery();

		}
	}
}