using Assignment.BL;
using Assignment.Dal.Checks;

IPEmployeeMethod iPEmployeeMethod = new IPEmployeeMethod();
IPCustomerMethod iPCustomer = new IPCustomerMethod();

Login();

void MenuCustomer()
{

	int choice;
	do
	{
		string[] _menu = { "Exit", " Add Customer", " Find Room", " Booking Room", " Update Customer", " Delete Customer", " Display Customer" };
		string _name = "            Hotel              ";

		int _choice = ShowMenuAndGetChoice(_menu, _name);
		choice = _choice;
		switch (_choice)
		{
			case 0:
				{

				}
				break;
			case 1:
				{

					Checks check = new Checks();

					Console.Clear();

					Console.WriteLine("|═══════════════════════════════|");
					TextColor(ConsoleColor.DarkBlue, "             Login               ");
					Console.WriteLine("|═══════════════════════════════|");
					Console.Write(" ID : ");
					string id = Console.ReadLine() ?? "";
					Console.Write(" Password : ");
					string? pass = Console.ReadLine() ?? "";
					if (check.CheckLoginEmployees(id, pass))
					{
						if (!(id == "1000" && pass == "Admin"))
						{
							check.TextColor(ConsoleColor.Green, " Logged in successfully");
							check.TextColor(ConsoleColor.Yellow, " Press Enter Key To Continue");
							Console.ReadKey();
							iPCustomer.AddCustomer();
						}
						else
						{
							check.TextColor(ConsoleColor.Yellow, " You need to enter the correct password and account");
						}

					}
					else
					{
						TextColor(ConsoleColor.DarkYellow, " You need to enter the correct password and account ");
					}
					Console.ReadKey();
				}
				break;
			case 2:

				{
					Console.WriteLine(" Do you want to search by name or room id?");
					Console.WriteLine(" 1.Find Room By ID");
					Console.WriteLine(" 2.Find Room By Name");
					Console.Write(" Choose : ");
					int choose = int.Parse(Console.ReadLine() ?? "");
					if (choose == 1)
					{
						iPCustomer.FindRoomsCustomers();
					}
					else
					{
						iPCustomer.FindNameRooms();
					}
				}
				break;
			case 3:
				{
					iPCustomer.BookRooms();
				}
				break;
			case 4:
				{

					Checks check = new Checks();

					Console.Clear();

					Console.WriteLine("|═══════════════════════════════|");
					TextColor(ConsoleColor.DarkBlue, "             Login               ");
					Console.WriteLine("|═══════════════════════════════|");
					Console.Write(" ID : ");
					string id = Console.ReadLine() ?? "";
					Console.Write(" Password : ");
					string? pass = Console.ReadLine() ?? "";
					if (check.CheckLoginEmployees(id, pass))
					{
						if (!(id == "1000" && pass == "Admin"))
						{
							check.TextColor(ConsoleColor.Green, " Logged in successfully");
							check.TextColor(ConsoleColor.Yellow, " Press Enter Key To Continue");
							Console.ReadKey();
							iPCustomer.UpDateCustomer();
						}
					}
					else
					{
						TextColor(ConsoleColor.DarkYellow, " You need to enter the correct password and account");
					}
					Console.ReadKey();
				}
				break;
			case 5:
				{

					Checks check = new Checks();

					Console.Clear();

					Console.WriteLine("|═══════════════════════════════|");
					TextColor(ConsoleColor.DarkBlue, "             Login               ");
					Console.WriteLine("|═══════════════════════════════|");
					Console.Write(" ID : ");
					string id = Console.ReadLine() ?? "";
					Console.Write(" Password : ");
					string? pass = Console.ReadLine() ?? "";
					if (check.CheckLoginEmployees(id, pass))
					{
						if (!(id == "1000" && pass == "Admin"))
						{
							check.TextColor(ConsoleColor.Green, " Logged in successfully");
							check.TextColor(ConsoleColor.Yellow, " Press Enter Key To Continue");
							Console.ReadKey();
							iPCustomer.DeleteCustomer();
						}
						else
						{
							TextColor(ConsoleColor.Red, " You need to enter the correct password and account");
						}
					}
					else
					{
						TextColor(ConsoleColor.Red, " You need to enter the correct password and account");
					}
					Console.ReadKey();
				}
				break;
			case 6:
				{
					iPCustomer.DisplayCustomer();
					Console.ReadKey();
				}
				break;
			default:
				{
					TextColor(ConsoleColor.Red, " You entered it wrong");
				}
				break;
		}
	} while (choice != 0);
}

void MenuEmployees()
{

	int choice;
	do
	{
		string[] _menu = { "Exit", " More Employee Information", " Payment", " Update Employee", " Delete Employee", " Watch Information Employee" };
		string _name = "            Hotel              ";

		int _choice = ShowMenuAndGetChoice(_menu, _name);
		choice = _choice;
		switch (_choice)
		{
			case 0:
				{

				}
				break;
			case 1:
				{

					Checks check = new Checks();

					Console.Clear();

					Console.WriteLine("|═══════════════════════════════|");
					TextColor(ConsoleColor.DarkBlue, "             Login               ");
					Console.WriteLine("|═══════════════════════════════|");
					Console.Write(" ID : ");
					string id = Console.ReadLine() ?? "";
					Console.Write(" Password : ");
					string? pass = Console.ReadLine() ?? "";
					if (check.CheckLoginEmployees(id, pass))
					{
						if ((id == "1000" && pass == "Admin"))
						{
							check.TextColor(ConsoleColor.Green, " Logged in successfully");
							check.TextColor(ConsoleColor.Yellow, " Press Enter Key To Continue");
							Console.ReadKey();
							iPEmployeeMethod.AddEmployee();
						}
					}
					else
					{
						check.TextColor(ConsoleColor.DarkYellow, " You need to enter the correct password and account");
						Console.ReadKey();
					}
				}
				break;
			case 2:

				{
					Console.Write(" ID Customers : ");
					string? id = Console.ReadLine() ?? "";
					Checks checks = new Checks();
					checks.TotalMoney(id);
					Console.ReadKey();
					iPEmployeeMethod.Receipt();
					Console.ReadKey();
				}
				break;
			case 3:

				{
					Checks check = new Checks();

					Console.Clear();

					Console.WriteLine("|═══════════════════════════════|");
					TextColor(ConsoleColor.DarkBlue, "             Login               ");
					Console.WriteLine("|═══════════════════════════════|");
					Console.Write(" ID : ");
					string id = Console.ReadLine() ?? "";
					Console.Write(" Password : ");
					string? pass = Console.ReadLine() ?? "";
					if (check.CheckLoginEmployees(id, pass))
					{
						if ((id == "1000" && pass == "Admin"))
						{
							check.TextColor(ConsoleColor.Green, " Logged in successfully");
							check.TextColor(ConsoleColor.Yellow, " Press Enter Key To Continue");
							Console.ReadKey();
							Console.WriteLine();
							iPEmployeeMethod.UpdateEmployee();
						}

					}
					else
					{
						check.TextColor(ConsoleColor.DarkYellow, " You need to enter the correct password and account");
					}
					Console.ReadKey();
				}
				break;
			case 4:

				{

					Checks check = new Checks();
					Console.Clear();

					Console.WriteLine("|═══════════════════════════════|");
					TextColor(ConsoleColor.DarkBlue, "             Login               ");
					Console.WriteLine("|═══════════════════════════════|");
					Console.Write(" ID : ");
					string id = Console.ReadLine() ?? "";
					Console.Write(" Password : ");
					string? pass = Console.ReadLine() ?? "";
					if (check.CheckLoginEmployees(id, pass))
					{
						if ((id == "1000" && pass == "Admin"))
						{
							check.TextColor(ConsoleColor.Green, " Logged in successfully");
							check.TextColor(ConsoleColor.Yellow, " Press Enter Key To Continue");
							Console.ReadKey();
							iPEmployeeMethod.DeleteEmployee();
						}
					}
					else
					{
						check.TextColor(ConsoleColor.DarkYellow, " You need to enter the correct password and account");
					}

					Console.ReadKey();
				}
				break;
			case 5:

				{
					iPEmployeeMethod.DisplayEmployee();
					Console.ReadKey();
				}
				break;
			default:
				{
					TextColor(ConsoleColor.Red, " You entered it wrong");
				}
				break;
		}
	} while (choice != 0);
}

int ShowMenuAndGetChoice(string[] menu, string name)
{
	Console.Clear();
	Console.WriteLine("═══════════════════════════════");
	Console.WriteLine(name);
	Console.WriteLine("═══════════════════════════════");
	int count = menu.Length;
	for (int i = 1; i < count; i++)
	{
		Console.WriteLine("{0}. {1}", i, menu[i]);
	}
	Console.WriteLine("0. {0}", menu[0]);

	int choice;
	Console.WriteLine("═══════════════════════════════");

	do
	{
		Console.Write("#Your Choice: ");
		int.TryParse(Console.ReadLine(), out choice);
		if (choice < 0 || choice > count)
		{
			TextColor(ConsoleColor.Red, " *Input invalid!");
		}
	} while (choice < 0 || choice > count);

	return choice;
}

void Login()
{
T:
	int choice = 0;

	Checks check = new Checks();

	Console.Clear();

	Console.WriteLine("|═══════════════════════════════|");
	TextColor(ConsoleColor.DarkBlue, "             Login               ");
	Console.WriteLine("|═══════════════════════════════|");
	Console.Write(" ID : ");
	string id = Console.ReadLine() ?? "";
	Console.Write(" Password : ");
	string? pass = Console.ReadLine() ?? "";


	if ((!(check.CheckLoginCustomer(id, pass))) && (!(check.CheckLoginEmployees(id, pass))))
	{
		CheckInput(id, pass);
	}

	if (check.CheckLoginCustomer(id, pass))
	{
		TextColor(ConsoleColor.Green, "|═════════════════════════|");
		TextColor(ConsoleColor.Green, "| Logged In Successfully  |");
		TextColor(ConsoleColor.Green, "|═════════════════════════|");
		TextColor(ConsoleColor.Yellow, " Press Enter Key To Continue");
		Console.ReadKey();
		Console.Clear();
		MenuCustomer();
	}
	else
	{
		if (check.CheckLoginEmployees(id, pass))
		{
			TextColor(ConsoleColor.Green, "|═════════════════════════|");
			TextColor(ConsoleColor.Green, "| Logged In Successfully  |");
			TextColor(ConsoleColor.Green, "|═════════════════════════|");
			TextColor(ConsoleColor.Yellow, " Press Enter Key To Continue");
			Console.ReadKey();
			Console.Clear();
			MenuEmployees();
		}
	}

	if (choice == 0)
	{
		Console.Clear();
		TextColor(ConsoleColor.Yellow, " Do you really want to escape? ");
		TextColor(ConsoleColor.Gray, " 0.Exit");
		TextColor(ConsoleColor.DarkCyan, " 1.Continue Login");
		Console.Write(" Choice: ");
		int.TryParse(Console.ReadLine(), out choice);
		if (choice == 1)
		{
			goto T;
		}
		else
		{
			TextColor(ConsoleColor.Gray, " Exit");
			return;
		}
	}

}

void CheckInput(string id, string pass)
{
	Checks check = new Checks();
	int t = 1, y = 3;
	var IsTrue = true;

	string choose;

	while (!check.CheckLoginCustomer(id, pass))
	{
		if (!IsTrue)
		{
			check.TextColor(ConsoleColor.Red, $" You Entered Your ID Wrong, You Have {y - 1} More Tries(errors {t})");
			y--;
			t++;
			Console.Write(" ID : ");
			id = (Console.ReadLine() ?? "");
			Console.Write(" Password : ");
			pass = Console.ReadLine() ?? "";
		}
		IsTrue = false;

		if (check.CheckLoginCustomer(id, pass))
		{
			TextColor(ConsoleColor.Green, "|═════════════════════════|");
			TextColor(ConsoleColor.Green, "| Logged In Successfully  |");
			TextColor(ConsoleColor.Green, "|═════════════════════════|");
			TextColor(ConsoleColor.Yellow, " Press Enter Key To Continue");
			Console.ReadKey();
			Console.Clear();
			MenuCustomer();
		}
		else if (check.CheckLoginEmployees(id, pass))
		{
			TextColor(ConsoleColor.Green, "|═════════════════════════|");
			TextColor(ConsoleColor.Green, "| Logged In Successfully  |");
			TextColor(ConsoleColor.Green, "|═════════════════════════|");
			TextColor(ConsoleColor.Yellow, " Press Enter Key To Continue");
			Console.ReadKey();
			Console.Clear();
			MenuEmployees();
		}
		else
		{
			if (t == 4)
			{
				Console.Write(" Do you want to register another account?(Y/N) : ");
				choose = Console.ReadLine() ?? "";
				if (choose == "Y" || choose == "y")
				{
					Console.Clear();
					iPCustomer.AddCustomer();
					Console.WriteLine(" You need to login,Press any key to login");
					Console.ReadLine();
					Console.Clear();
					Console.WriteLine("|═══════════════════════════════|");
					TextColor(ConsoleColor.DarkBlue, "             Login               ");
					Console.WriteLine("|═══════════════════════════════|");
					Console.Write(" ID : ");
					id = (Console.ReadLine() ?? "");
					Console.Write(" Password : ");
					pass = Console.ReadLine() ?? "";
				}
				else
				{
					if (choose == "n" || choose == "N")
					{
						Console.WriteLine(" Exit");
					}
				}
				break;
			}
		}

	}
}

void TextColor(ConsoleColor color, string str)
{
	Console.ForegroundColor = color;
	Console.WriteLine(str);
	Console.ResetColor();
}

