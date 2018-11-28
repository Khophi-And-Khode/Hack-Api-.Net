using System.Collections.Generic;
using System.Data;
using CloudinaryDotNet.Actions;
using HackApi.Model;
using MySql.Data.MySqlClient;

namespace HackApi.Data
{
    public class HackContext
    {
        public string ConnectionStr { get; set; }

        public HackContext(string connectionString)
        {
            ConnectionStr = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionStr);
        }

        public MySqlCommand CreateCommand(string commText)
        {
            MySqlConnection conn = GetConnection();

            conn.Open();

            MySqlCommand command = new MySqlCommand(commText, conn)
            {
                CommandType = CommandType.Text
            };
            return command;

        }

        public int FillImageInfo(ImageUploadResult model, string name)
        {

            var height = model.Height;
            var width = model.Width;
            var sign = model.Signature;
            var pubId = model.PublicId;
            var url = model.Uri;
            var secureUrl = model.SecureUri;
            var format = model.Format;
            var resType = model.ResourceType;

            var query = "INSERT INTO `ImageData`(`Name`, `Height`, `Width`, `Signature`, `PublicId`, `Url`, `SecureUrl`, `Format`, `ResourceType`) " +
                "VALUES('" + name + "','" + height + "','" + width + "','" + sign + "','" + pubId + "','" + url + "','" + secureUrl + "','" + format + "','" + resType + "');";
            //var prodQuery = "";
            var command = CreateCommand(query);
            var result = command.ExecuteNonQuery();
            return result;
        }

        public int FillImageWithProduct(ImageUploadResult model, string name,double price,string content, string implication,string review)
        {

            var height = model.Height;
            var width = model.Width;
            var sign = model.Signature;
            var pubId = model.PublicId;
            var url = model.Uri;
            var secureUrl = model.SecureUri;
            var format = model.Format;
            var resType = model.ResourceType;
            var keyword = $"{name}-{price}-{content}-{implication}-{pubId}";

            var query = "INSERT INTO `ImageData`(`Name`, `Height`, `Width`, `Signature`, `PublicId`, `Url`, `SecureUrl`, `Format`, `ResourceType`) " +
                "VALUES('" + name + "','" + height + "','" + width + "','" + sign + "','" + pubId + "','" + url + "','" + secureUrl + "','" + format + "','" + resType + "');";

            var command = CreateCommand(query);
            var result = command.ExecuteNonQuery();
            var fill =FillProduct(name, price, secureUrl.ToString(), content, implication, review, pubId, keyword);
            
            return result;
        }

        public int FillVideoInfo(VideoUploadResult model, string name)
        {
            var height = model.Height;
            var width = model.Width;
            var sign = model.Signature;
            var pubId = model.PublicId;
            var url = model.Uri;
            var secureUrl = model.SecureUri;
            var format = model.Format;
            var resType = model.ResourceType;
            var duration = model.Duration;

            var query = "INSERT INTO `VideoData`(`Name`, `Height`, `Width`, `Signature`, `PublicId`, `Url`, `SecureUrl`, `Format`, `ResourceType`,`Duration`) " +
                "VALUES('" + name + "','" + height + "','" + width + "','" + sign + "','" + pubId + "','" + url + "','" + secureUrl + "','" + format + "','" + resType + "','" + duration + "');";
            var command = CreateCommand(query);
            var result = command.ExecuteNonQuery();
            return result;
        }

        public Product FillProduct(string name, double price, string img, string content, string implications, string reviews, string publicId, string keyword)
        {
            var query = "insert into products" +
                " (Name, Price, ImgUrl, Content, Implication, Reviews, PublicId, Keyword)" +
                " values ('" + name + "','" + price + "','" + img + "','" + content + "','" + implications + "','" + reviews + "','" + publicId + "','" + keyword + "');";
            var command = CreateCommand(query);
            command.ExecuteNonQuery();
            return new Product() {
                Name = name,
                Price=price,
                ImageUrl=img,
                Content=content,
                Implication=implications,
                Reviews=reviews,
                PublicId=publicId,
                Keyword=keyword
            };
        }
    }
}
