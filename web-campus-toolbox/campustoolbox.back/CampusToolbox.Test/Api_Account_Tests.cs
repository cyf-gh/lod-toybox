using CampusToolbox.Model.Back.Account;
using CampusToolbox.Model.Security;
using CampusToolbox.Test;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CampusToolbox.Tests.Api {
    public class Account {

        [Fact]
        public async Task Register_An_Exsited_Account_Will_Get_ConflictStatusCode() {            
            var response = await TestHelper.TestPost<AccountRegisterModel>( 
                $"/api/account/register/new" , 
                "{\"sys\":{\"id\":0,\"passwordEncrypted\":\"\"},\"absVisiable\":{\"id\":0,\"nickName\":\"cyf\",\"college\":\"dhu\"},\"relieable\":{\"id\":0,\"city\":\"sh\",\"name\":\"cyf\",\"district\":\"pd\",\"email\":\"cyf-ms@hotmail.com\",\"phone\":\"453245252345\",\"grade\":0,\"isConfirmed\":false},\"plainPassword\":123456}" );

            Assert.Equal( HttpStatusCode.BadRequest, response.StatusCode );
        }

        [Fact]
        public async Task Account_Login_Works() {
            // 重新登陆，获取新的token
            var response = await TestHelper.TestPost(
                $"/api/account/login",
                new AccountLoginModel { 
                    LoginBy = AccountLoginBy.Email,
                    Password = "123456",
                    LoginName = "1026279833@qq.com"
                } );
            Assert.Equal( HttpStatusCode.OK, response.StatusCode );
            var token = JsonConvert.DeserializeObject<FrontTokenModel>( await response.Content.ReadAsStringAsync() );
            Assert.NotNull( token );
        }
    }
}
