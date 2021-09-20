using System.Linq;
namespace KudosShop.Models
{
    public class Response
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public Response ResponseBuild(int errorcode){
            ResponseDictionary responDict = new ResponseDictionary();
            Response respon = new Response { Code = errorcode };

            respon.Message = responDict.Codes.FirstOrDefault(s => s.Key == errorcode).Value;
            
            return respon;
        }

      
    }
}