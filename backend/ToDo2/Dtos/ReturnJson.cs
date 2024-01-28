using Microsoft.Data.SqlClient.Server;

namespace ToDo2.Dtos
{
    public class ReturnJson
    {
        public dynamic Data { get; set; }
        public int HttpCode { get; set; }
        public string ErrorMessage { get; set; }
        
        public dynamic Error { get; set; }
    }
}
