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

        public int FillImageInfo(ImageUploadResult model)
        {
            var name = model.PublicId;
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
            var command = CreateCommand(query);
            var result = command.ExecuteNonQuery();
            return result;
        }

    }
}
