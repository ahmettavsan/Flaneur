using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskEtkinlik.Core.DTOs
{
    #region MyRegion
    //endpointlerden geriye tek bir model dçncez 
    //    başarılıda olsa olmasada
    //tek bir model dönmek iyidir

    //bir endpointe istek yaptığımızda geriye mutlaka status code almak zorundayız



    #endregion
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        //dönceğimiz responsın bodysinde status coda gerek yok
        //zaten head kısmında olur bodysinde error varsa error ve data dönelim

        [JsonIgnore]
        public int StatusCode { get; set; } 

        //static factory metotlar yazcaz bu metotlar sayesinden newleyerek nesne üretmek zorunda değiliz

        public static CustomResponseDto<T> Succes(int statuscode,T data)
        {
            return new CustomResponseDto<T> { Data = data ,StatusCode=statuscode,Errors=null};
        }
        public static CustomResponseDto<T> Success(int statuscode)
        {
            return new CustomResponseDto<T> { StatusCode = statuscode };
        }
        public static CustomResponseDto<T> Fails(int statuscode,List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode=statuscode,Errors=errors};
        }
        public static CustomResponseDto<T> Fail(int statuscode,string error)
        {
            return new CustomResponseDto<T> { StatusCode = statuscode,Errors=new List<string> { error} };
        }

        //herhangi bir  classın içerisinde geriye instence dönen static metotlarımız
        //varsa bu metotlara static factory metot denir
        #region factory
        //factory design patternda aynı class interfaceler oluşturmak yerine
        //diretk hangi sınıfı dönmek istiyorsak o sınıfın içerisinde static metotlar tanımlayark geriye instencelar dönüyoruz
        //new anahtar kelimesini kullanmak yerine  bu metotları kullanarak
        //nesne üretme olayını
        //bu sınıf içerisinde gerçekleşitiryoruz
        #endregion





    }
}
