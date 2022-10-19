using Assignment.Entities;
using System.Text.RegularExpressions;
using Assignment.Dal.Checks;

namespace Assignment.BL
{
	public class IPCustomerMethod : CustomerMethod
	{
		private readonly CustomerRepo repo;

		public IPCustomerMethod()
		{
			repo = new CustomerRepo();
		}
		Customer customers = new Customer();
		Employees employees = new Employees();
		Rooms rooms = new Rooms();
		Receipts receipts = new Receipts();
		BookRooms bookRooms = new BookRooms();
		Positions positions = new Positions();
		TypePrices typePrices = new TypePrices();
		TypeRooms typeRooms = new TypeRooms();
		Checks check = new Checks();

		public void AddCustomer()
		{
			Console.Clear();
			Console.WriteLine("|═══════════════════════════════|");
			Console.WriteLine("|          Add Customer         |");
			Console.WriteLine("|_______________________________|");
			var IsTrue = true;
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
			while (check.CheckIDCus(id))
			{
				check.TextColor(ConsoleColor.Red, " ID Exits ");
				Console.Write(" ID : ");
				id = (Console.ReadLine() ?? "");
			}
			customers.id = id;
			Console.Write(" First Name : ");
			string fName = Console.ReadLine() ?? "";
			while (!(Regex.IsMatch(fName, "^[a-z]{3,15}$")))
			{

				check.TextColor(ConsoleColor.Red, " Can only enter text (total 15 characters)");
				Console.Write(" First Name : ");
				fName = (Console.ReadLine() ?? "");

			}
			check.CheckInputEmpty(fName);
			customers.firstName = fName;

			Console.Write(" Last Name : ");
			string lName = Console.ReadLine() ?? "";
			while (!(Regex.IsMatch(lName, "^[a-z]{3,15}$")))
			{

				check.TextColor(ConsoleColor.Red, " Can only enter text (total 15 characters)");
				Console.Write(" Last Name : ");
				lName = (Console.ReadLine() ?? "");

			}
			check.CheckInputEmpty(lName);
			customers.lastName = lName;
			Console.Write(" Address : ");
			string? address = Console.ReadLine() ?? "";
			check.CheckInputEmpty(address);
			customers.address = address;
			Console.Write(" Phone : ");
			string phone = Console.ReadLine() ?? "";
			do
			{
				if (!Regex.Match(phone, "(84|0[2|3|5|7|8|9])+([0-9]{8})").Success)
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
			} while ((phone.Length != 10) && !Regex.Match(phone, "(84|0[2|3|5|7|8|9])+([0-9]{8})").Success);
			customers.phone = phone;
			Console.Write(" Birth : ");
			var birthDateInput = "";
			var birthDate = DateTime.MinValue;
			do
			{
				if (!IsTrue)
				{
					check.TextColor(ConsoleColor.Red, " This Information Was Entered Incorrectly");
					Console.Write(" Birth : ");
				}

				birthDateInput = Console.ReadLine();

				IsTrue = false;
			}
			while (!DateTime.TryParse(birthDateInput, out birthDate));
			customers.birth = birthDate;
			var IsTrues = true;
			Console.Write(" Gender : ");
			var gender = "";
			do
			{
				if (!IsTrues)
				{
					if (string.IsNullOrWhiteSpace(gender))
					{
						check.TextColor(ConsoleColor.Red, " This Information Cannot Be Left Blank.");
						Console.Write(" Please re-enter : ");
					}
					else
					{
						if ((!"M".Equals(gender)) || (!"F".Equals(gender)))
						{
							check.TextColor(ConsoleColor.Yellow, " This Information Is Only For M and F Inputs.");
							Console.Write(" Gender : ");
						}
					}
				}

				gender = Console.ReadLine();

				IsTrue = false;
			}
			while (string.IsNullOrWhiteSpace(gender) || (!"M".Equals(gender) && !"F".Equals(gender)));
			customers.gender = gender;
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
			customers.password = pass;
			string? states = "Add";
			customers.states = states;
			if (repo.AddCustomer(customers))
			{
				check.TextColor(ConsoleColor.Green, "Add Successfully ");
			}

		}
		public void BookRooms()
		{
			int t = 1, id;
			int y = 3;
			var isFirst = true;
			Console.Write(" ID : ");
			int.TryParse(Console.ReadLine() ?? "", out id);
			while (check.CheckIDBRoom(id))
			{
				check.TextColor(ConsoleColor.Red, " ID Exist");
				Console.Write(" ID : ");
				id = int.Parse(Console.ReadLine() ?? "");
			}
			bookRooms.id = id;
			DateTime roomRentalDate = DateTime.Now;
			Console.WriteLine(" Room Rental Date : {0}", roomRentalDate);
			bookRooms.roomRentalDate = roomRentalDate;

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

			bookRooms.checkOutDate = Date;

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

			bookRooms.dateBook = dateBooking;

			isFirst = true;
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
						Console.Clear();
						AddCustomer();
					}
				}

			}
			bookRooms.customers = customers.id;

			int idr;
			Console.Write(" ID Rooms : ");
			int.TryParse(Console.ReadLine() ?? "", out idr);
			DBHelper.CloseConnection();
			while (check.CheckIDRoom(idr))
			{
				check.TextColor(ConsoleColor.Red, " Room Used");
				Console.Write(" ID Rooms : ");
				int.TryParse(Console.ReadLine() ?? "", out idr);
			}


			if (!check.CheckIDRoom(idr))
			{
				check.TextColor(ConsoleColor.DarkYellow, " Empty Room");
				Console.Write(" Would you like to use this room?(Y/N) : ");
				string choose = Console.ReadLine() ?? "";
				if (choose == "Y" || choose == "y")
				{
					Console.Clear();
					Rooms();
				}
				bookRooms.rooms = idr;
			}
			string? states = "Add";
			bookRooms.states = states;
			Console.Clear();
			Console.WriteLine($" ID : {id}\n Room Rental Date : {roomRentalDate}\n Check-Out Date : {outDate}\n Date Booking : {dateBook}\n Customers_ID : {customers.id}");
			Console.WriteLine($"| {"Rooms_ID",5} | {"Rooms_Name",13} | {"Rooms_Price",10} | {"Rooms_MaxPeople",13} | {"Rooms_Floor",14} | {"Customers_ID",20} | {"TypeRooms_ID",13} | {"TypePrices_ID",10} | {"Rooms_States",10} |");
			repo.DisplayRoom(idr);
			if (repo.AddBookRoom(bookRooms))
			{
				check.TextColor(ConsoleColor.Green, "Add BookRooms Successfully ");
				Console.ReadKey();
			}

			Receipt();

		}
		public void Receipt()
		{
			Console.Clear();
			Console.WriteLine("|═══════════════════════════════|");
			Console.WriteLine("|            Receipt            |");
			Console.WriteLine("|_______________________________|");
			int t = 1, y = 3; var isFirst = true; double total;
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
						AddCustomer();
					}
				}

			}
			if (check.CheckIDCus(customers.id))
			{
				Console.WriteLine(" Customer ID : {0} ", customers.id);
				receipts.customers = customers.id;

				check.Invoice(customers.id);
				check.TextColor(ConsoleColor.DarkYellow, " You need to re-enter the date for us to save the information ");

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
				Console.Write(" Total Money : ");
				double.TryParse(Console.ReadLine(), out total);
				receipts.totalMoney = total;

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
					else
					{
						check.TextColor(ConsoleColor.Red, " UnSuccessful Invoice Writing ");
					}
				}
				
			}
		}
		public void Rooms()
		{
			int t = 0, y = 3, id;
			var isFirst = true;
			Console.Write(" ID : ");
			int.TryParse(Console.ReadLine() ?? "", out id);
			while (check.CheckIDRoom(id))
			{
				check.TextColor(ConsoleColor.Red, " Rooms Exist");
				Console.Write(" ID : ");
				int.TryParse(Console.ReadLine() ?? "", out id);
			}
			rooms.id = id;
			Console.Write(" Name : ");
			var name = Console.ReadLine() ?? "";
			while (!(Regex.IsMatch(name, "^[a-z]{3,15}$")))
			{
				check.TextColor(ConsoleColor.Red, " Can only enter text (total 15 characters)");
				Console.Write(" Name : ");
				name = (Console.ReadLine() ?? "");
			}
			check.CheckInputEmpty(name);
			rooms.name = name;
			Console.Write(" Price : ");
			double price = double.Parse(Console.ReadLine() ?? "");
			do
			{
				if (price < 50000)
				{
					check.TextColor(ConsoleColor.Red, " Please Enter More Than 50000 ");
					Console.Write(" Price :  ");
					double.TryParse(Console.ReadLine(), out price);
				}
			} while (price < 50000);
			rooms.price = price;

			Console.Write(" Max People : ");
			int max = int.Parse(Console.ReadLine() ?? "");
			do
			{
				if (max == 0 && max > 4)
				{
					check.TextColor(ConsoleColor.Red, " No Room 0 and > 4 People Stay");
					Console.Write(" Max People : ");
					max = int.Parse(Console.ReadLine() ?? "");
				}
			} while (max == 0 && max > 4);
			rooms.maxPeople = max;
			Console.Write(" Floor : ");
			int floor = int.Parse(Console.ReadLine() ?? "");
			do
			{
				if (floor > 8 && floor == 1)
				{
					check.TextColor(ConsoleColor.Red, " The hotel has only 7 floors");
					Console.Write(" Floor : ");
					floor = int.Parse(Console.ReadLine() ?? "");
				}
			} while (floor > 8 && floor == 1);
			rooms.floor = floor;

			isFirst = true;
			Console.Write(" ID Customers : ");
			customers.id = (Console.ReadLine() ?? "");
			while (!check.CheckIDCus(customers.id))
			{

				if (!isFirst)
				{
					check.TextColor(ConsoleColor.Red, $" You Entered Your ID Wrong, You Have {y - 1} More Tries(errors {t})");
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
						AddCustomer();
					}
				}
			}
			rooms.customers = customers.id;
			int idTR;
			check.TextColor(ConsoleColor.Magenta, " There are 2 types vip and regular !");
			check.TextColor(ConsoleColor.Magenta, " 201 : Type Vip");
			check.TextColor(ConsoleColor.Magenta, " 301 : Type Regular");
			Console.Write(" Choose : ");
			int.TryParse(Console.ReadLine() ?? "", out idTR);

			while (!check.CheckTypeRooms(idTR))
			{
				check.TextColor(ConsoleColor.Red, " You have entered the wrong value");
				check.TextColor(ConsoleColor.Magenta, " There are 2 types vip and regular !");
				check.TextColor(ConsoleColor.Magenta, " 201 : Type Vip");
				check.TextColor(ConsoleColor.Magenta, " 301 : Type Regular");
				Console.Write(" Choose : ");
				idTR = int.Parse(Console.ReadLine() ?? "");
			}
			rooms.typeRooms = idTR;
			int idTP;
			check.TextColor(ConsoleColor.Magenta, " There are 3 types of prices !");
			check.TextColor(ConsoleColor.Magenta, " 1 : Type by hours");
			check.TextColor(ConsoleColor.Magenta, " 2 : Type by date");
			check.TextColor(ConsoleColor.Magenta, " 3 : Type by out time");
			Console.Write(" Choose : ");
			int.TryParse(Console.ReadLine() ?? "", out idTP);
			while (!check.CheckTypePrice(idTP))
			{
				check.TextColor(ConsoleColor.Red, " You have entered the wrong value");
				check.TextColor(ConsoleColor.Magenta, " There are 3 types of prices !");
				check.TextColor(ConsoleColor.Magenta, " 1 : Type by hours");
				check.TextColor(ConsoleColor.Magenta, " 2 : Type by date");
				check.TextColor(ConsoleColor.Magenta, " 3 : Type by out time");
				Console.Write(" Choose : ");
				int.TryParse(Console.ReadLine() ?? "", out idTP);
			}
			rooms.typePrices = idTP;
			string? states = "Add";
			rooms.states = states;
			if (repo.AddRoom(rooms))
			{
				check.TextColor(ConsoleColor.Green, " Add Rooms Successfully ");
				Console.ReadKey();
			}


		}
		public void DeleteCustomer()
		{
			Console.Clear();
			Console.WriteLine("|═══════════════════════════════|");
			Console.WriteLine("|        Delete Customer        |");
			Console.WriteLine("|_______________________________|");
			Console.Write(" ID Delete : ");
			customers.id = (Console.ReadLine() ?? "");
			if (!check.CheckIDCus(customers.id))
			{
				check.TextColor(ConsoleColor.Red, " ID Not Exist");
				Console.ReadKey();
			}
			else
			{
				check.TextColor(ConsoleColor.Green, " ID Exist");
				Console.ReadKey();
				string? states = "Delete";
				customers.states = states;
				if (repo.DeleteCustomer(customers))
				{
					check.TextColor(ConsoleColor.Green, " Delete Successfully");

				}
			}

		}
		public void UpDateCustomer()
		{
			Console.Clear();
			Console.WriteLine("|═══════════════════════════════|");
			Console.WriteLine("|         Update Customer       |");
			Console.WriteLine("|_______________________________|");

			Console.Write(" ID Update: ");
			customers.id = (Console.ReadLine() ?? "");
			while (!check.CheckEmployee(customers.id))
			{
				check.TextColor(ConsoleColor.Red, " ID does not exist");
				Console.Write(" ID Update: ");
				customers.id = (Console.ReadLine() ?? "");
			}
			if (check.CheckEmployee(customers.id))
			{
				var isFirst = true;

				Console.Write(" First Name : ");
				var fName = Console.ReadLine() ?? "";
				while (!(Regex.IsMatch(fName, "^[a-z]{3,15}$")))
				{

					check.TextColor(ConsoleColor.Red, " Can only enter text (total 15 characters)");
					Console.Write(" First Name : ");
					fName = (Console.ReadLine() ?? "");

				}
				check.CheckInputEmpty(fName);
				customers.firstName = fName;
				Console.Write(" Last Name : ");
				var lName = Console.ReadLine() ?? "";
				while (!(Regex.IsMatch(lName, "^[a-z]{3,15}$")))
				{

					check.TextColor(ConsoleColor.Red, " Can only enter text (total 15 characters)");
					Console.Write(" Last Name : ");
					lName = (Console.ReadLine() ?? "");

				}
				check.CheckInputEmpty(lName);
				customers.lastName = lName;
				Console.Write(" Address : ");
				string address = Console.ReadLine() ?? "";
				check.CheckInputEmpty(address);
				customers.address = address;
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
				customers.phone = phone;
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
				customers.birth = birthDate;
				isFirst = true;
				Console.Write(" Gender : ");
				var gen = Console.ReadLine() ?? "";
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

					isFirst = false;
				}
				while (string.IsNullOrWhiteSpace(gen) || (!"M".Equals(gen) && !"F".Equals(gen)));
				customers.gender = gen;
				Console.Write(" Password : ");
				var pass = Console.ReadLine() ?? "";
				check.CheckInputEmpty(pass);
				while (!Regex.Match(pass, "((?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{6,20})").Success)
				{
					check.TextColor(ConsoleColor.Red, " You need to capitalize the first character");
					check.TextColor(ConsoleColor.Red, " The second character to be lowercase");
					check.TextColor(ConsoleColor.Red, " The third character to be a number(max to 20 characters)");
					Console.Write(" Password : ");
					pass = Console.ReadLine() ?? "";
				}
				customers.password = pass;
				string? states = "Update";
				customers.states = states;
				if (repo.UpdateCustomer(customers))
				{
					check.TextColor(ConsoleColor.Green, " UpDate Successfully");
				}
			}
		}
		public void DisplayCustomer()
		{
			Console.Write(" ID : ");
			string id = (Console.ReadLine() ?? "");
			if (check.CheckIDCus(id))
			{
				Console.WriteLine(" ID Exist");
				Console.ReadKey();
			}
			Console.Clear();
			Console.WriteLine();
			Console.WriteLine(string.Format("| {0,6} | {1,13} | {2,10} | {3,13} | {4,14} | {5,22} | {6,13} | {7,10} | {8,10} |", "ID", "First Name ", "Last Name", "Address", "Phone", "Birth Day", "Gender", "Password", "States"));
			Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

			repo.DisplayCustomer(id);
		}
		public void FindRoomsCustomers()
		{
			int id;
		T:
			Console.Write(" ID Rooms Find : ");
			int.TryParse(Console.ReadLine(), out id);
			while (repo.FindRooms(id))
			{
				check.TextColor(ConsoleColor.Red, " The Room Has Been Used");
				Console.Write(" Please Choose Another Room : ");
				int.TryParse(Console.ReadLine(), out id);
			}
			DBHelper.CloseConnection();
			if (!repo.FindRooms(id))
			{
				check.TextColor(ConsoleColor.Green, " Empty Room");

				Console.Write(" Would You Like To Use This Room?(Y/N) : ");
				string choose = Console.ReadLine() ?? "";
				if (choose == "N" || choose == "n")
				{
					Console.Write(" Do you want to find another room ?(Y/N) : ");
					choose = Console.ReadLine() ?? "";
					DBHelper.CloseConnection();
					if (choose == "Y" || choose == "y")
					{
						goto T;
					}
				}
				if (choose == "Y" || choose == "y")
				{
					Rooms();
				}
			}

		}
		public void FindNameRooms()
		{

		T:
			Console.Write(" Name Rooms Find : ");
			string name = Console.ReadLine() ?? "";
			while (!repo.FindNameRooms(name))
			{
				check.TextColor(ConsoleColor.Red, " The Room Has Been Used");
				Console.Write(" Please Choose Another Room : ");
				name = Console.ReadLine() ?? "";
			}
			DBHelper.CloseConnection();
			if (repo.FindNameRooms(name))
			{
				check.TextColor(ConsoleColor.Green, " Empty Room");

				Console.Write(" Would You Like To Use This Room?(Y/N) : ");
				string choose = Console.ReadLine() ?? "";
				if (choose == "N" || choose == "n")
				{
					Console.Write(" Do you want to find another room ?(Y/N) : ");
					choose = Console.ReadLine() ?? "";
					DBHelper.CloseConnection();
					if (choose == "Y" || choose == "y")
					{
						goto T;
					}
				}
				if (choose == "Y" || choose == "y")
				{
					Rooms();
				}
			}

		}
	}
}