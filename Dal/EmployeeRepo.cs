using Assignment.Entities;
using MySql.Data.MySqlClient;

namespace Assignment.Dal.Checks
{

	public class EmployeeRepo
	{
		Checks check = new Checks();
		Employees employees = new Employees();
		Customer customers = new Customer();
		Positions positions = new Positions();
		public bool AddEmployees(Employees employees)
		{
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("sp_createEmployees", DBHelper.OpenConnection());

			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@id", employees.id);

			cmd.Parameters.AddWithValue("@firstName", employees.firstName);

			cmd.Parameters.AddWithValue("@lastName", employees.lastName);

			cmd.Parameters.AddWithValue("@address", employees.address);

			cmd.Parameters.AddWithValue("@phone", employees.phone);

			cmd.Parameters.AddWithValue("@birth", employees.birth);

			cmd.Parameters.AddWithValue("@gender", employees.gender);

			if (employees.positions != null)
			{
				cmd.Parameters.AddWithValue("@staffCode", employees.positions.id);
			}

			cmd.Parameters.AddWithValue("@pass", employees.pass);

			cmd.Parameters.AddWithValue("@states", employees.states);

			cmd.Parameters.Add(new MySqlParameter("@empID", MySqlDbType.Text));
			cmd.Parameters["@empID"].Direction = System.Data.ParameterDirection.Output;
			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			cmd.ExecuteNonQuery();

			return cmd.Parameters["@empID"].Value != DBNull.Value;

		}
		public bool DeleteEmployees(Employees employees)
		{

			var detail = true;
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("sp_deleteEmployees", DBHelper.OpenConnection());
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.Add(new MySqlParameter("@empId", employees.id));

			cmd.Parameters.AddWithValue("@states", employees.states);

			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			cmd.ExecuteNonQuery();
			return detail;
		}
		public void DisplayEmployees(string id)
		{
			DBHelper.CloseConnection();
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("Select * from Employees where Employees_ID = @empId", DBHelper.OpenConnection());

			cmd.Parameters.AddWithValue("@empId", id);

			using (MySqlDataReader reader = cmd.ExecuteReader())
			{
				while (reader.Read())
				{
					string row = string.Format($"| {reader[0].ToString(),5} | {reader["Employees_StaffCode"].ToString(),10} | {reader["Employees_FirstName"].ToString(),11} | {reader["Employees_LastName"].ToString(),10} | {reader["Employees_Address"].ToString(),10} | {reader["Employees_Phone"].ToString(),15} | {reader["Employees_Birth"].ToString(),23} | {reader["Employees_Gender"].ToString(),7} | {reader["Password"],10} | {reader["Employees_States"]} |");
					Console.WriteLine(row);
				}
			}
			DBHelper.CloseConnection();
		}
		public bool UpdateEmployees(Employees employees)
		{

			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("sp_upDateEmployees", DBHelper.OpenConnection());
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.Add(new MySqlParameter("@empId", employees.id));

			cmd.Parameters.Add(new MySqlParameter("@ln", employees.lastName));

			cmd.Parameters.Add(new MySqlParameter("@fn", employees.firstName));

			if (employees.positions == null)
			{
				return false;
			}
			else
			{
				cmd.Parameters.Add(new MySqlParameter("@sc", employees.positions.id));
			}

			cmd.Parameters.Add(new MySqlParameter("@address", employees.address));

			cmd.Parameters.Add(new MySqlParameter("@phone", employees.phone));

			cmd.Parameters.Add(new MySqlParameter("@birth", employees.birth));

			cmd.Parameters.Add(new MySqlParameter("@genders", employees.gender));

			cmd.Parameters.Add(new MySqlParameter("@pass", employees.pass));

			cmd.Parameters.AddWithValue("@states", employees.states);

			DBHelper.CloseConnection();
			DBHelper.OpenConnection();
			cmd.ExecuteNonQuery();

			return true;
		}
		public bool AddPay(Receipts receipts)
		{
			DBHelper.OpenConnection();

			MySqlCommand cmd = new MySqlCommand("sp_createReceipts", DBHelper.OpenConnection());

			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@id", receipts.id);

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
	}
}
