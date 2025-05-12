using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Model.Utils
{
    public class ApiResponseConstants
    {
        //public const int SuSuccessCode = 200;

        //public const string SuccessMessage = "Success";


        public string GetResponceMessage (int ApiResponseStatus)
        {
            var responceMessage = this.ApiResponceMessage(ApiResponseStatus);
            return responceMessage;
        }

        public string ApiResponceMessage(int ApiResponseStatus)
        {

            switch (ApiResponseStatus)
            {
                case 200:
                    return "Success";
                case 404:
                    return "Not Found";
                case 400:
                    return "Bad Request";
                case 401:
                    return "Unauthorized";
                case 403:
                    return "Forbidden";
                case 500:
                    return "Internal Server Error";
                default:
                    break;

            }
            return "Unknown Status";

        }

    }

    public enum ApiResponseStatus
    {
        Success = 200,
        NotFound = 404,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        InternalServerError = 500
    }


    public class ApiResponse
    {
        public object? Data { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }




}
