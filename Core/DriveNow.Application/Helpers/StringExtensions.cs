
using System.Text.RegularExpressions; 

namespace DriveNow.Application.Helpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// Verilen metni URL'ye uygun bir slug formatına dönüştürür.
        /// </summary>
        /// <param name="phrase">Slug'a dönüştürülecek metin.</param>
        /// <returns>URL dostu slug.</returns>
        public static string GenerateSlug(this string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                return "";

            // Türkçe karakter dönüşümü
            string str = phrase.ToLowerInvariant(); // Küçük harfe çevir
            str = Regex.Replace(str, @"ş", "s");
            str = Regex.Replace(str, @"ı", "i");
            str = Regex.Replace(str, @"ü", "u");
            str = Regex.Replace(str, @"ö", "o");
            str = Regex.Replace(str, @"ç", "c");
            str = Regex.Replace(str, @"ğ", "g");

            // Alfanümerik karakterler, boşluklar ve tireler dışındaki her şeyi kaldır
            str = Regex.Replace(str, @"[^\w\s-]", "");

            // Boşlukları tire ile değiştir
            str = Regex.Replace(str, @"\s+", "-");

            // Birden fazla tireyi tek tire yap
            str = Regex.Replace(str, @"-+", "-");

            // Başlangıç ve sondaki tireleri kaldır
            str = str.Trim('-');

            return str;
        }
    }
}