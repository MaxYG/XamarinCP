using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web.Http;
using System.Web.Routing;
using XamarinCP.WebApi.Models;

namespace XamarinCP.WebApi.Controllers
{
    public class CompanyController : BaseController
    {
        // GET api/company
        [Route("api/companies")]
        [HttpGet]
        public List<Company> Get()
        {
            return GetCompanies();
        }

        [Route("api/companies")]
        [HttpGet]
        public List<Company> Get([FromUri]string companyName)
        {
            var companies= GetCompanies();
            return companies.Where(x => x.Name.Contains(companyName)).ToList();
        }

        private List<Company> GetCompanies()
        {
            var companies = new List<Company>() {
                new Company(){
                    Id = 1,
                    Name = "company1",
                    Address = "description 1",
                    ImageUrl = "company1.png",
                },
                new Company(){
                    Id = 2,
                    Name = "company2",
                    Address = "description 2",
                    ImageUrl = "company2.png",
                },
                new Company(){
                    Id = 3,
                    Name = "company3",
                    Address = "description 3",
                    ImageUrl = "company3.png",
                }
            };

            return companies;
        }
    }
}