using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //başarılı mesajlar
        public static string CarAdded = "Araba ekleme başarılı";
        public static string BrandAdded = "Marka ekleme başarılı";
        public static string CustomerAdded = "Müşteri ekleme başarılı";
        public static string ColorAdded = "Renk ekleme başarılı";
        public static string UsersAdded = "Kullanıcı ekleme başarılı";
        public static string CarListed = "Arabalar listelendi";
        public static string RentalsAdded = "Araba kiralandı";
        public static string SuccessDeleted = "Silme işlemi başarılı";
        public static string SuccessUpdated = "Güncelleme işlemi başarılı";

        //başarısız mesajlar
        public static string CarNotAdded = "Araba ekleme başarısız";
        public static string BrandNotAdded = "Marka ekleme başarısız";
        public static string CarNotListed = "Araba listeleme başarısız";
        public static string RentalsNotAdded = "Araba kiralanmadı";
        public static string ErrorDeleted = "Silme işlemi başarısız";
        public static string ErrorUpdated = "Güncelleme işlemi başarısız";
    }
}
