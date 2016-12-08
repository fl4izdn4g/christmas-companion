using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAST_CHRISTMAS.Controllers
{
    public class SecretController : Controller
    {
        class RiddleResponse
        {
            public string BandStatus { get; set; }
            public string SantaStatus { get; set; }
            public string GiftStatus { get; set; }
            public string FinalLink { get; set; }
        }


        // GET: Secret
        
        public ActionResult Status(string bandCode, string santaCode, string giftCode)
        {
            const string ERROR_CODE = "ERROR";
            const string OK_CODE = "OK";

            var response = new RiddleResponse()
            {
                BandStatus = ERROR_CODE,
                GiftStatus = ERROR_CODE,
                SantaStatus = ERROR_CODE
            };

            if(bandCode == "2304")
            {
                response.BandStatus = OK_CODE;
            }

            if(!String.IsNullOrEmpty(giftCode) && giftCode.ToLower() == "csiwykop")
            {
                response.GiftStatus = OK_CODE;
            }

            if(!String.IsNullOrEmpty(santaCode) && santaCode.ToLower() == "wrocław")
            {
                response.SantaStatus = OK_CODE;
            }

            if(response.BandStatus == OK_CODE && response.GiftStatus == OK_CODE && response.SantaStatus == OK_CODE)
            {
                response.FinalLink = Url.Action("tjlcdgr", "Home");
            }


            return Json(response, JsonRequestBehavior.AllowGet);
        }
       
    }
}