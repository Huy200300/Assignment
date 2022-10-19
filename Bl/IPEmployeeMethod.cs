using Assignment.Entities;
using System.Text.RegularExpressions;
using Assignment.Dal.Checks;

namespace Assignment.BL
{
	public class IPEmployeeMethod : EmployeeMethod
	{
		private readonly EmployeeRepo repo;

		public IPEmployeeMethod()
		{
			repo = new EmployeeRepo();
		}
		
		Receipts receipts = new Receipts();
		Employees employees = new Employees();
		Positions positions = new Positions();
		Customer customers = new Customer();
		BookRooms bookRooms = new BookRooms();
		Checks check = new Checks();
		IPCustomerMethod ipCus = new IPCustomerMethod();

		public void AddEmployee()
		{
			Console.Clear();
			Console.WriteLine("|═══════════════════════════════|");
			Console.WriteLine("|          Add Employee         |");
			Console.WriteLine("|_______________________________|");
			var isFirst = true;

			Console.Write(" ID : ");
			string id = (Console.ReadLine() ?? "");
			while (!(Regex.IsMatch(id, "((?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[&!@#$%]).{4,5})")))
			{

				check.TextColor(ConsoleColor.Red, " You need to capitalize the first character");
				check.TextColor(ConsoleColor.Red, " The second character to be lowercase");
				check.TextColor(ConsoleColor.Red, " The third character to be a number");
				check.TextColor(ConsoleColor.Red, " And the last character to be a special character(only 4-5 characters total).");
				Console.Write(" ID : ");
				id = (Console.ReadLine() ?? "");

			}
			while (check.CheckEmployee(id))
			{
				Console.Write(" ID Exist,ID : ");
				id = (Console.ReadLine() ?? "");
			}
			employees.id = id;
			Console.Write(" First Name : ");
			var fName = Console.ReadLine() ?? "";
			while (!(Regex.IsMatch(fName, "^[a-z]{3,15}$")))
			{

				check.TextColor(ConsoleColor.Red, " Can only enter text (total 15 characters)");
				Console.Write(" First Name : ");
				fName = (Console.ReadLine() ?? "");

			}
			check.CheckInputEmpty(fName);
			employees.firstName = fName;
			Console.Write(" Last Name : ");
			var lName = Console.ReadLine() ?? "";
			while (!(Regex.IsMatch(lName, "^[a-z]{3,15}$")))
			{

				check.TextColor(ConsoleColor.Red, " Can only enter text (total 15 characters)");
				Console.Write(" Last Name : ");
				lName = (Console.ReadLine() ?? "");

			}
			check.CheckInputEmpty(lName);
			employees.lastName = lName;
			Console.Write(" Address : ");
			var address = Console.ReadLine() ?? "";
			check.CheckInputEmpty(address);
			employees.address = address;
			Console.Write(" Phone : ");
			var phone = Console.ReadLine() ?? "";
			do
			{
				if (!Regex.Match(phone, "(84|0[3|5|7|8|9])+([0-9]{8})").Success)
				{
					check.TextColor(ConsoleColor.Red, " You can only enter numbers");
					Console.Write(" Phone: ");
					phone = Console.ReadLine() ?? "";
				}
				if ((phone.Length != 10))
				{
					check.TextColor(ConsoleColor.Red, " This Information You Entered Wrong ");
					check.TextColor(ConsoleColor.Red, " Only 10 Numbers Are Allowed");
					Console.Write(" Phone: ");
					phone = Console.ReadLine() ?? "";
				}
			} while ((phone.Length != 10) && Regex.Match(phone, "(84|0[3|5|7|8|9])+([0-9]{8})").Success);
			employees.phone = phone;
			Console.Write(" Birth : ");
			var birthDateInput = "";
			var birthDate = DateTime.MinValue;
			do
			{
				if (!isFirst)
				{
					check.TextColor(ConsoleColor.Red, " This Information Was Entered Incorrectly");
					Console.Write(" Birth : ");
				}

				birthDateInput = Console.ReadLine();

				isFirst = false;
			}
			while (!DateTime.TryParse(birthDateInput, out birthDate));
			employees.birth = birthDate;
			isFirst = true;
			Console.Write(" Gender : ");
			var gen = "";
			do
			{
				if (!isFirst)
				{
					if (string.IsNullOrWhiteSpace(gen))
					{
						check.TextColor(ConsoleColor.Red, " This Information Cannot Be Left Blank.");
						Console.Write(" Please re-enter : ");
					}
					else
					{
						if (!"M".Equals(gen) || !"F".Equals(gen))
						{
							check.TextColor(ConsoleColor.Yellow, " This Information Is Only For M and F Inputs.");
							Console.Write(" Please re-enter : ");
						}
					}
				}

				gen = Console.ReadLine();

				isFirst = false;
			}
			while (string.IsNullOrWhiteSpace(gen) || (!"M".Equals(gen) && !"F".Equals(gen)));
			employees.gender = gen;
			employees.positions = positions;
			Console.Write(" Password : ");
			var pass = Console.ReadLine() ?? "";
			while (!Regex.Match(pass, "((?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{6,20})").Success)
			{
				check.TextColor(ConsoleColor.Red, " You need to capitalize the first character");
				check.TextColor(ConsoleColor.Red, " The second character to be lowercase");
				check.TextColor(ConsoleColor.Red, " The third character to be a number(max to 20 characters)");
				Console.Write(" Password : ");
				pass = Console.ReadLine() ?? "";
			}
			check.CheckInputEmpty(pass);
			employees.pass = pass;
			string? states = "Add";
			employees.states = states;
			if (repo.AddEmployees(employees))
			{
				check.TextColor(ConsoleColor.Green, " Add Successfully ");
				Console.ReadKey();
			}
		}
		public void DeleteEmployee()
		{
			Console.Clear();
			Console.WriteLine("|═══════════════════════════════|");
			Console.WriteLine("|         Delete Employee       |");
			Console.WriteLine("|_______________________________|");
			Console.Write(" ID Delete : ");
			employees.id = (Console.ReadLine() ?? "");
			if (employees.id == "1000")
			{
				check.TextColor(ConsoleColor.DarkYellow, " You can't do this");
			}
			else
			{
				if (!check.CheckEmployee(employees.id))
				{
					check.TextColor(ConsoleColor.Red, " ID Not Exist");
					Console.ReadKey();
				}
				else
				{
					string states = "Delete";
					employees.states = states;
					check.TextColor(ConsoleColor.Green, " ID Exist");
					Console.ReadKey();
					if (repo.DeleteEmployees(employees))
					{

						check.TextColor(ConsoleColor.Green, " Delete Successfully");

					}
				}
			}
		}
		public void UpdateEmployee()
		{
			Console.Clear();
			Console.WriteLine("|═══════════════════════════════|");
			Console.WriteLine("|         Update Employee       |");
			Console.WriteLine("|_______________________________|");
			Console.Write(" ID Update: ");
			employees.id = (Console.ReadLine() ?? "");
			if (employees.id == "1000")
			{
				check.TextColor(ConsoleColor.DarkYellow, " You can't do this");
			}
			else
			{
				if (check.CheckEmployee(employees.id))
				{
					var isFirst = true;
					Console.Write(" First Name : ");
					var fName = Console.ReadLine() ?? "";
					check.CheckInputEmpty(fName);
					employees.firstName = fName;
					Console.Write(" Last Name : ");
					var lName = Console.ReadLine() ?? "";
					check.CheckInputEmpty(lName);
					employees.lastName = lName;
					Console.Write(" Address : ");
					var address = Console.ReadLine() ?? "";
					check.CheckInputEmpty(address);
					employees.address = address;
					Console.Write(" Phone : ");
					var phone = Console.ReadLine() ?? "";
					do
					{
						if (!Regex.Match(phone, "(84|0[3|5|7|8|9])+([0-9]{8})").Success)
						{
							check.TextColor(ConsoleColor.Red, " You can only enter numbers");
							Console.Write(" Phone: ");
							phone = Console.ReadLine() ?? "";
						}
						if ((phone.Length != 10))
						{
							check.TextColor(ConsoleColor.Red, " This Information You Entered Wrong ");
							check.TextColor(ConsoleColor.Red, " Only 10 Numbers Are Allowed");
							Console.Write(" Phone: ");
							phone = Console.ReadLine() ?? "";
						}
					} while ((phone.Length != 10) && !Regex.Match(phone, "(84|0[3|5|7|8|9])+([0-9]{8})").Success);
					employees.phone = phone;
					Console.Write(" Birth : ");
					var birthDateInput = "";
					var birthDate = DateTime.MinValue;
					do
					{
						if (!isFirst)
						{
							check.TextColor(ConsoleColor.Red, " This Information Was Entered Incorrectly");
							Console.Write(" Birth : ");
						}
						birthDateInput = Console.ReadLine();

						isFirst = false;
					}
					while (!DateTime.TryParse(birthDateInput, out birthDate));
					employees.birth = birthDate;
					isFirst = true;
					Console.Write(" Gender : ");
					var gen = "";
					do
					{
						if (!isFirst)
						{
							if (string.IsNullOrWhiteSpace(gen))
							{
								check.TextColor(ConsoleColor.Red, " This Information Cannot Be Left Blank.");
								Console.Write(" Please re-enter : ");
							}
							else
							{
								if (!"M".Equals(gen) || !"F".Equals(gen))
								{
									check.TextColor(ConsoleColor.Yellow, " This Information Is Only For M and F Inputs.");
									Console.Write(" Please re-enter : ");
								}
							}
						}

						gen = Console.ReadLine();

						isFirst = false;
					}
					while (string.IsNullOrWhiteSpace(gen) || (!"M".Equals(gen) && !"F".Equals(gen)));
					employees.gender = gen;
					employees.positions = positions;
					Console.Write(" Password : ");
					var pass = Console.ReadLine() ?? "";
					check.CheckInputEmpty(pass);
					employees.pass = pass;
					string? states = "Update";
					employees.states = states;
					if (repo.UpdateEmployees(employees))
					{
						check.TextColor(ConsoleColor.Green, " UpDate Successfully");
					}
					else
					{
						check.TextColor(ConsoleColor.Red, " Update UnSuccessfully");
					}
				}
			}
		}
		public void DisplayEmployee()
		{
			Console.Write(" ID : ");
			employees.id = (Console.ReadLine() ?? "");
			check.CheckEmployee(employees.id);

			Console.Clear();
			Console.WriteLine();
			Console.WriteLine(string.Format("| {0,5} | {1,10} | {2,11} | {3,10} | {4,10} | {5,15} | {6,23} | {7,7} | {8,10} | {9,5} | {10,8}", "ID", "Staff Code", "First Name ", "Last Name", "Address", "Phone", "Birth Day", "Gender", "Password", "States"));
			Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

			repo.DisplayEmployees(employees.id);
		}
		public void Receipt()
		{
			Console.Clear();
			Console.WriteLine("|═══════════════════════════════|");
			Console.WriteLine("|            Receipt            |");
			Console.WriteLine("|_______________________________|");
			int t = 1, y = 3; var isFirst = true;
			Console.Write(" ID Customers : ");
			customers.id = (Console.ReadLine() ?? "");
			while (!check.CheckIDCus(customers.id))
			{

				if (!isFirst)
				{
					Console.WriteLine(" You Entered Your ID Wrong, You Have {0} More Tries(errors {1})", y - 1, t);
					t++;
					y--;
					Console.Write(" ID Customers : ");
					customers.id = (Console.ReadLine() ?? "");
				}
				isFirst = false;

				if (t == 4)
				{
					Console.Write(" Do you want to register another account?(Y/N) : ");
					string choose = Console.ReadLine() ?? "";
					if (choose == "Y" || choose == "y")
					{
						ipCus.AddCustomer();
					}
				}

			}
			if (check.CheckIDCus(customers.id))
			{
				Console.WriteLine(" Customer ID : {0} ", customers.id);
				receipts.customers = customers.id;

				check.Invoice(customers.id);
				check.TextColor(ConsoleColor.DarkYellow, " You need to re-enter the date for us to save the information ");
				Console.WriteLine(" Press Enter Key To Continue");
				Console.ReadKey();
				DateTime roomRentalDate = DateTime.Now;
				Console.WriteLine(" Room Rental Date : {0}", roomRentalDate);
				receipts.roomRentalDate = roomRentalDate;

				Console.Write(" Check-Out Date : ");
				var outDate = "";
				var Date = DateTime.MinValue;
				do
				{
					if (!isFirst)
					{
						check.TextColor(ConsoleColor.Red, " Enter Incorrect Information");
						Console.Write(" Check-Out Date : ");
					}

					outDate = Console.ReadLine();

					isFirst = false;
				}
				while (!DateTime.TryParse(outDate, out Date));

				receipts.checkOutDate = Date;

				var IsDate = true;
				Console.Write(" Date Booking : ");
				var dateBook = "";
				var dateBooking = DateTime.MinValue;
				do
				{
					if (!IsDate)
					{
						check.TextColor(ConsoleColor.Red, " Enter Incorrect Information");
						Console.Write(" Date Booking : ");
					}

					dateBook = Console.ReadLine();

					isFirst = false;
				}
				while (!DateTime.TryParse(dateBook, out dateBooking));

				receipts.dateBook = dateBooking;

				check.TotalMoney(customers.id);
				// Console.Write(" Total Money : ");
				// double total = double.Parse(Console.ReadLine()??"");
				var IsTrue = true;
				while (!check.Invoices(receipts))
				{
					Console.Write(" Check-Out Date : ");
					outDate = "";
					Date = DateTime.MinValue;
					do
					{
						if (!IsTrue)
						{
							check.TextColor(ConsoleColor.Red, " Enter Incorrect Information");
							Console.Write(" Check-Out Date : ");
						}

						outDate = Console.ReadLine();

						isFirst = false;
					}
					while (!DateTime.TryParse(outDate, out Date));

					receipts.checkOutDate = Date;

					var IsDates = true;
					Console.Write(" Date Booking : ");
					dateBook = "";
					dateBooking = DateTime.MinValue;
					do
					{
						if (!IsDates)
						{
							check.TextColor(ConsoleColor.Red, " Enter Incorrect Information");
							Console.Write(" Date Booking : ");
						}

						dateBook = Console.ReadLine();

						isFirst = false;
					}
					while (!DateTime.TryParse(dateBook, out dateBooking));

					receipts.dateBook = dateBooking;

				}
				if (check.Invoices(receipts))
				{
					if (repo.AddPay(receipts))
					{
						check.TextColor(ConsoleColor.Green, " Successful Invoice Writing ");
						Console.ReadKey();
					}
				}
				else
				{

				}
			}
		}
	}
}