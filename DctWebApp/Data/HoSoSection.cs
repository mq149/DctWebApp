using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DctWebApp.Data
{
    public class HoSoSection
    {
        public bool generalInformation = true;
        public bool profilePicture = false;
        public bool identity = false;
        public bool driverLicense = false;
        public bool bankAccount = false;
        public bool otherInformation = false;
        public bool agreements = false;
        public bool vehiclePictures = false;
        public bool vehicleRegistration = false;
        public bool vehicleInsurance = false;

        public HoSoSection() { }

        public void ToggleVisibleSection(string section)
        {
            switch (section)
            {
                case Section.GeneralInformation:
                    generalInformation = !generalInformation;
                    break;
                case Section.ProfilePicture:
                    profilePicture = !profilePicture;
                    break;
                case Section.Identity:
                    identity = !identity;
                    break;
                case Section.DriverLicense:
                    driverLicense = !driverLicense;
                    break;
                case Section.BankAccount:
                    bankAccount = !bankAccount;
                    break;
                case Section.OtherInformation:
                    otherInformation = !otherInformation;
                    break;
                case Section.Agreements:
                    agreements = !agreements;
                    break;
                case Section.VehiclePictures:
                    vehiclePictures = !vehiclePictures;
                    break;
                case Section.VehicleRegistration:
                    vehicleRegistration = !vehicleRegistration;
                    break;
                case Section.VehicleInsurance:
                    vehicleInsurance = !vehicleInsurance;
                    break;
            }

        }

        public static class Section
        {
            public const string GeneralInformation = "general-information";
            public const string ProfilePicture = "profile-picture";
            public const string Identity = "identity";
            public const string DriverLicense = "driver-license";
            public const string BankAccount = "bank-account";
            public const string OtherInformation = "other-information";
            public const string Agreements = "agreements";
            public const string VehiclePictures = "vehicle-pictures";
            public const string VehicleRegistration = "vehicle-registration";
            public const string VehicleInsurance = "vehicle-insurance";
        }

        public static class ImageInput
        {
            public const string Avatar = "avatar";
            public const string CMNDTruoc = "cmnd-truoc";
            public const string CMNDSau = "cmnd-sau";
            public const string BLXTruoc = "bang-lai-xe-truoc";
            public const string BLXSau = "bang-lai-xe-sau";
            public const string HinhDauXe = "hinh-dau-xe";
            public const string HinhDuoiXe = "hinh-duoi-xe";
            public const string GiayKTXe = "giay-kiem-tra-xe";
            public const string GiayDKXTruoc = "giay-dang-ky-xe-truoc";
            public const string GiayDKXSau = "giay-dang-ky-xe-sau";
            public const string BHXeTruoc = "bao-hiem-xe-truoc";
            public const string BHXeSau = "bao-hiem-xe-sau";
        }

    }
}
