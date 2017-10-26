using System.Collections.Generic;
using XamarinCP.Model;

namespace XamarinCP.Service
{
    public class CompanyService
    {
        public static List<Company> GetCompanyies()
        {
            var companies= new List<Company>() {
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