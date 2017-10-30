using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinCP.WebApi.Models
{
	public class Company
	{
	    public int Id { get; set; }
	    public string Name { get; set; }
	    public string Address { get; set; }
	    public string ImageUrl { get; set; }
    }
}