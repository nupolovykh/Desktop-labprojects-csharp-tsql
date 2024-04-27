using Lab7.Models.Database.Entity;
using System;

namespace Lab7.Services.Authorization
{
	public interface IAuthorization
	{
		void Login(string login, string password);
		void SignIn(string login, string password);
		void LogOut();
		User CurrentUser { get; }
	}
}
