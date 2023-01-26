using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SPT_Manager.Models;

namespace SPT_Manager.API
{
    public class UserManager
    {
        public List<User> InitUsers()
        {
            var profiles = Directory.GetFiles($@"{SPTManager.Instance.SptDir}\user\profiles");

            var users = new List<User>();
            
            foreach (var p in profiles)
            {
                var streamReader = new StreamReader(p).ReadToEnd();
                var r = JsonConvert.DeserializeObject<dynamic>(streamReader);

                var username = r.info.username;
                var userid = r.info.id;

                var user = new User
                {
                    Username = username,
                    UserId = userid,
                    DefaultPack = ""
                };
                users.Add(user);
                
                SPTManager.Instance.Database.SetUsers(users);
            }

            return users;
        }
    }
}