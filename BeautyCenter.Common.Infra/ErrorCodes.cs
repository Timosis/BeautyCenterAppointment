using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.Common.Infra
{
    public class ErrorCodes
    {
        public const string Personnel_NewPersonnel_ErrorOccurdWhileAddingCompanyPersonnel = "Personnel_NewPersonnel_ErrorOccurdWhileAddingCompanyPersonnel";
        public const string Common_IdRequired = "Common_IdRequired";
        public const string Common_ErrorWhileGettingData = "Common_ErrorWhileGettingData";
        public const string Common_PleaseFillAllRequiredFields = "Common_PleaseFillAllRequiredFields";
        public const string Common_UserIdRequired = "Common_UserIdRequired";
        public const string Common_RoleIdRequired = "Common_RoleIdRequired";
        public const string Common_ErrorOccuredWhileUpdatingRecord = "Common_ErrorOccuredWhileUpdatingRecord";
        public const string Common_ErrorOccuredWhileAddingRecord = "Common_ErrorOccuredWhileAddingRecord";
        public const string Common_TheRecordYouWantToDeleteWasNotFound = "Common_TheRecordYouWantToDeleteWasNotFound";
        public const string Common_ErrorOccuredWhileProcessingYourRequest = "Common_ErrorOccuredWhileProcessingYourRequest";

        public const string Customer_Common_ErrorOccuredWhileAddingCustomer = "Customer_Common_ErrorOccuredWhileAddingCustomer";
        public const string Customer_Common_CustomerAlreadyExistWithEmailAdress = "Customer_Common_CustomerAlreadyExistWithEmailAdress";
        public const string Customer_Common_CustomerNotFound = "Customer_Common_CustomerNotFound";
        public const string Customer_TheCustomerYouWantToDeleteWasNotFound = "Customer_TheCustomerYouWantToDeleteWasNotFound";
        public const string Customer_Common_ErrorOccuredWhileUpdatingCustomer = "Customer_Common_ErrorOccuredWhileUpdatingCustomer";



        public const string Identity_Login_EmailCanNotBeEmpty = "Identity_Login_EmailCanNotBeEmpty";
        public const string Identity_Login_PasswordCanNotBeEmpty = "Identity_Login_PasswordCanNotBeEmpty";
        public const string Identity_Login_UserCouldNotFoundWithEmail = "Identity_Login_UserCouldNotFoundWithEmail";
        public const string Identity_Login_ThereAreaMoreThanOneUserWithEmail = "Identity_Login_ThereAreaMoreThanOneUserWithEmail";
        public const string Identity_Login_InvalidPasswordHashAlgorithm = "Identity_Login_InvalidPasswordHashAlgorithm";
        public const string Identity_Login_WrongPassword = "Identity_Login_WrongPassword";
        public const string Identity_UserAlreadyHasRole = "Identity_UserAlreadyHasRole";
        public const string Identity_UserNotFound = "Identity_UserNotFound";

    }
}
