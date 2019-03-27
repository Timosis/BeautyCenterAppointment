using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Infra
{
    public class ErrorMessages
    {
        public static Dictionary<string, string> Messages { get; set; }

        static ErrorMessages()
        {            
            Messages = new Dictionary<string, string>();
            Messages.Add(ErrorCodes.Personnel_NewPersonnel_ErrorOccurdWhileAddingCompanyPersonnel, "Personelin profil bilgileri getirilirken bir hata oluştu.");
            Messages.Add(ErrorCodes.Customer_Common_CustomerAlreadyExistWithEmailAdress, "Email Adresi ile zaten bir kişi kayıtlıdır.");

        }
        public static bool ContainsKey(string key)
        {
            if (Messages == null || Messages.Count == 0)
                return false;

            return Messages.ContainsKey(key);
        }

        public static string Get(string key)
        {
            if (ContainsKey(key))
                return Messages[key];

            return string.Empty;
        }
    }
}
