using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Text;

namespace BIPIT07
{
  
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        static string connectionString = @"Data Source=DESKTOP-R9245SG\SQLEXPRESS;Initial Catalog=chat;Integrated Security=True";
        static SqlConnection cnn = new SqlConnection(connectionString);

        List<ServerUser> users = new List<ServerUser>();

        public int Connect(string name)
        {
            cnn.Open();

            SqlCommand command = new SqlCommand("SELECT user_id FROM[Peoples] WHERE user_name=@name", cnn);
            command.Parameters.AddWithValue("name", name);
            command.ExecuteNonQuery();

            int id = 0;

            if(command.ExecuteScalar() == null)
            {
                SqlCommand createUserCommand  = new SqlCommand("INSERT INTO[Peoples] (user_name, first_time_conn) VALUES (@name, @time)", cnn);
                createUserCommand.Parameters.AddWithValue("name", name);
                string format = "yyyy-MM-dd HH:mm:ss";
                createUserCommand.Parameters.AddWithValue("time", DateTime.Now.ToString(format));
                createUserCommand.ExecuteNonQuery();


                SqlCommand selectUserCommand = new SqlCommand("SELECT user_id FROM[Peoples] WHERE user_name=@name", cnn);
                selectUserCommand.Parameters.AddWithValue("name", name);
                selectUserCommand.ExecuteNonQuery();

                int.TryParse(selectUserCommand.ExecuteScalar().ToString(), out id);
            }
            else
            {
                int.TryParse(command.ExecuteScalar().ToString(), out id);
            }
  
            cnn.Close();

            ServerUser user = new ServerUser()
            {
                ID = id,
                Name = name,
                operationContext = OperationContext.Current
            };

            SendMsg(": " + user.Name + " подключился к чату", 0);
            users.Add(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(i => i.ID == id);
            if(user != null)
            {
                users.Remove(user);
                SendMsg(": " + user.Name + " покинул чат", 0);
            }
        }

        public Message[] GetPrevMessages(int id)
        {
            cnn.Open();

            SqlCommand getFirstConn = new SqlCommand("SELECT first_time_conn FROM[Peoples] WHERE user_id=@id", cnn);
            getFirstConn.Parameters.AddWithValue("id", id);
            getFirstConn.ExecuteNonQuery();

            DateTime first_conn = DateTime.Parse(getFirstConn.ExecuteScalar().ToString());

            SqlCommand getPrevMessages = new SqlCommand("SELECT * FROM[Messages] WHERE send_time >= @first_conn", cnn);
            getPrevMessages.Parameters.Add("@first_conn", System.Data.SqlDbType.Date).Value = first_conn;
            SqlDataReader reader = getPrevMessages.ExecuteReader();

            List<Message> prevMessages = new List<Message>();

            while (reader.Read())
            {
                Message prevMessage = new Message
                {
                    UserId = int.Parse(reader["user_id"].ToString()),
                    UserName = reader["user_name"].ToString(),
                    Text = reader["text"].ToString(),
                    SendTime = DateTime.Parse(reader["send_time"].ToString())
                };
                prevMessages.Add(prevMessage);
            }
            reader.Close();
            cnn.Close();
            return prevMessages.ToArray();
        }

        public void SendMsg(string msg, int id)
        {
            if(id != 0)
            {
                cnn.Open();

                SqlCommand saveMessage = new SqlCommand("INSERT INTO [Messages] (user_id, user_name, text, send_time) VALUES (@user_id, @user_name, @text, @time)", cnn);
                saveMessage.Parameters.AddWithValue("user_id", id);
                saveMessage.Parameters.AddWithValue("user_name", users.First(i => i.ID == id).Name);
                saveMessage.Parameters.AddWithValue("text", msg);
                saveMessage.Parameters.Add("@time", System.Data.SqlDbType.Date).Value = DateTime.Now;
                saveMessage.ExecuteNonQuery();

                cnn.Close();
            }

            foreach(var item in users)
            {
                string answer = DateTime.Now.ToShortTimeString();

                var user = users.FirstOrDefault(i => i.ID == id);
                if (user != null)
                {
                    answer += ": " + user.Name + " ";
                }
                answer += msg;
                item.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);
            }
        }
    }
}
