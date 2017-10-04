using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travels.dto.Dto.Request;

namespace travels.templates.Model
{
    public class EnrollInfoModel
    {
        public string Program { get; set; }
        public string ParentName { get; set; }
        public string ParentCity { get; set; }
        public string ParentState { get; set; }
        public string ParentCountry { get; set; }
        public string ParentPostalCode { get; set; }
        public string ParentAddress { get; set; }
        public string PassportNumber { get; set; }
        public string PassportExpDate { get; set; }
        public string ParentEmail { get; set; }
        public string ParentHomePhoneNumber { get; set; }
        public string ParentMobilePhoneNumber { get; set; }
        public string ParentWorkPhoneNumber { get; set; }
        public string ParentWorkAddress { get; set; }
        public string FullName { get; set; }
        public string Age { get; set; }
        public string TShirt { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string TravelDate { get; set; }
        public bool DrugsAllergies { get; set; }
        public string DrugsAllergiesDescription { get; set; }
        public bool FoodAllergies { get; set; }
        public string FoodAllergiesDescription { get; set; }
        public bool EmotionalProblems { get; set; }
        public string EmotionalProblemsDescription { get; set; }
        public string OtherAllergies { get; set; }
        public string TreatmentForDeseases { get; set; }
        public string OtherInterestInfo { get; set; }
        public bool HospitalImmediately { get; set; }
        public string RegistrationDate { get; set; }
        public ContactEmergency ContactEmergency1 { get; set; }
        public ContactEmergency ContactEmergency2 { get; set; }
    }
}
