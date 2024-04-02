namespace application_win_form_db.Services
{
	public enum statesForClosingWindow
	{
		ClosingByTheReturn,
		ClosingByTheShutDownWindow,
		PassingToAnotherPage
	}

	public static class AvailableTables
	{
		public static List<string> Admin = new List<string> 
		{ "Users", "Operators", "SurveyLines", "Terrains", "Equipment", "Pickets", "Projects", "Customers", "Measurements", "Data" };

		public static List<string> Operator = new List<string>
		{ "Users", "SurveyLines", "Terrains", "Equipment", "Pickets", "Measurements" };

		public static List<string> Scientist = new List<string>
		{ "Measurements", "Data" };

		public static List<string> Analyst = new List<string>
		{ "Operators", "SurveyLines", "Terrains", "Equipment", "Pickets", "Projects", "Customers", "Measurements", "Data" };
	}

	//string userInput = Interaction.InputBox("Please enter your input:", "User Input", "");
	//MessageBox.Show("You entered: " + userInput);	//create the stupid dialog form

}
