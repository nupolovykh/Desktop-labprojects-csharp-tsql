namespace application_win_form_db.Services
{
	public enum statesForClosingWindow
	{
		ClosingByTheReturn,
		ClosingByTheShutDownWindow,
		PassingToAnotherPage
	}

	//string userInput = Interaction.InputBox("Please enter your input:", "User Input", "");
	//MessageBox.Show("You entered: " + userInput);	//create the stupid dialog form

	public static class GlobalData
	{
		public static string? Propery { get; set; }

		public static string? Search { get; set; }

		public static string? Table { get; set; }

		public static statesForClosingWindow? State { get; set; }

		public static int PaginationTake = 20;
	}
}
