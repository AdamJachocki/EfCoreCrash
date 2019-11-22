using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();

			RegisterLocalDatabase();
		}

		void RegisterLocalDatabase()
		{
			string commonDocs = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string targetDir = Path.Combine(commonDocs, "TestCompany", "AppName");
			if (!Directory.Exists(targetDir))
				Directory.CreateDirectory(targetDir);

			string targetFileName = Path.Combine(targetDir, "data.appname");

			DbInfo db = new DbInfo();
			db.ConnectionString = $"Data Source={targetFileName};";
			db.IsDefault = true;
			db.Name = "Local";
			db.Type = DbType.Sqlite;


			EfCoreHelper.Init(db);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
