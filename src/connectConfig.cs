using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;


public class DatabaseController : Controller
{
	private readonly IConfiguration _configuration;
	
	
	public DatabaseController( IConfiguration configuration)
	{
		_configuration = configuration;
	}


	public connect()
	{
		var connString = _configuration.GetConnectionString("DefaultConnection");
	}
}
