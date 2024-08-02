using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses
{
    public sealed class ResponseVm
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; } = "";
        public dynamic ResponseData { get; set; }
        public string ErrorMessages { get; set; } = "";


        private static ResponseVm Instance = null;
        private ResponseVm()
        {
        }
        public static ResponseVm GetResponseVmInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new ResponseVm();
                }
                return Instance;
            }
        }
    }
}
