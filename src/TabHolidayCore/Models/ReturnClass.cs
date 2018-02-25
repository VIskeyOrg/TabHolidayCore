using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TabHolidayCore.Models
{
    public class ReturnClass
    {
        public ReturnClass()
        {
            isSuccess = true;
        }

        public bool isSuccess { get; set; }
        public object ChangedData { get; set; }
        public string Message { get; set; }

        public string GetSaveMessage()
        {
            return "Record saved successfully.";
        }

        public string GetDeleteMessage()
        {
            return "Record deleted successfully.";
        }

        public string GetEditMessage()
        {
            return "Record updated successfully.";
        }

        public string GetErrorMessage(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            if (ex.InnerException == null)
            {
                return "Unable to process request, Error-" + ex.Message;
            }

            return "Unable to process request";
        }

        public string GetResponse()
        {
            //            return JsonConvert.SerializeObject(this, Formatting.Indented,
            //new JsonSerializerSettings
            //{
            //    PreserveReferencesHandling = PreserveReferencesHandling.Objects
            //});

            return JsonConvert.SerializeObject(this);
        }

    }
}
