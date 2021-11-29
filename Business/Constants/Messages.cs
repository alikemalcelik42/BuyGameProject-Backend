using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcud";
        public static string AccessTokenCreated = "Bağlantı jetonu oluşturuldu";

        public static string GameDeleted = "Oyun silindi";
        public static string GamesListed = "Oyunlar listelendi";
        public static string GameUpdated = "Oyun güncellendi";
        public static string GameAdded = "Oyun eklendi";

        public static string GamerAdded = "Oyuncu eklendi";
        public static string GamerDeleted = "Oyuncu silindi";
        public static string GamersListed = "Oyuncular listelendi";
        public static string GamerUpdated = "Oyuncu güncellendi";
        public static string InfosWrong = "Bilgiler hatalı";

        public static string CampaignAdded = "Kampanya eklendi";
        public static string CampaignDeleted = "Kampanya silindi";
        public static string CampaignsListed = "Kampanyalar listlendi";
        public static string CampaignUpdated = "Kampanya güncellendi";

        public static string SalesListed = "Satışlar listelendi";
        public static string SaleUpdated = "Satış güncellendi";
        public static string SaleDeleted = "Satış silindi";
        public static string SaleAdded = "Satış eklendi";
    }
}
