using icutech;
using mekashron.backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace mekashron.backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        [HttpPost]
        [Route("Login")]
        [EnableCors("PolicyLocal")]
        public async Task<LoginReturnModel> Login(LoginModel model)
        {
            ICUTechClient client = new ICUTechClient(ICUTechClient.EndpointConfiguration.IICUTechPort);
            var response = await client.LoginAsync(model.Username, model.Password, "");
            //Let's hide details from frontend and return only required data
            dynamic json = JsonConvert.DeserializeObject(response.@return);
            var resultModel = new LoginReturnModel();
            if (json["ResultCode"] != null)
            {
                resultModel.Success = false;
                resultModel.Error = json["ResultMessage"];
            }
            else
            {
                resultModel.Success = true;
                resultModel.LastName = json["LastName"];
                resultModel.FirstName = json["FirstName"];
                resultModel.Company = json["Company"];
                resultModel.Address = json["Address"];
                resultModel.City = json["City"];
                resultModel.Country = json["Country"];
                resultModel.Zip = json["Zip"];
                resultModel.Phone = json["Phone"];
                resultModel.Mobile = json["Mobile"];
            }
            return resultModel;
            
        }
    }
}
