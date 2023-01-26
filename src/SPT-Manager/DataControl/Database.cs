using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SPT_Manager.Models;

namespace SPT_Manager.DataControl
{
    public class Database
    {
        private DataStorage<ClientData> DataStorage { get; set; }

        public ClientData Data { get; private set; }

        public Database()
        {
            DataStorage = new DataStorage<ClientData>(AppContext.BaseDirectory, "clientdata.json");
        }

        public void Reload()
        {
            Data = DataStorage.Read();
            if (Data == null)
            {
                Data = new ClientData
                {
                    SptDir = "",
                    DefaultUserId = "",
                    Users = new List<User>(),
                    ModPacks = new List<ModPack>()
                };
                DataStorage.Save(Data);
            }
        }

        public void SetSptDir(string dir)
        {
            Data.SptDir = dir;
            DataStorage.Save(Data);
        }

        public string GetUserIdFromUsername(string username)
        {
            var user = Data.Users.FindIndex(x => x.Username == username);
            return Data.Users[user].UserId;
        }

        public void SetUsers(List<User> users)
        {
            Data.Users = users;
            DataStorage.Save(Data);
        }

        public void SetDefaultUser(string userId)
        {
            Data.DefaultUserId = userId;
            DataStorage.Save(Data);
        }
        
        public string GetDefaultUser()
            => Data.DefaultUserId;

        public void SetModpacks(List<ModPack> modPacks)
        {
            Data.ModPacks = modPacks;
            DataStorage.Save(Data);
        }

        public void CreateModpack(ModPack modPack)
        {
            Data.ModPacks.Add(modPack);
            DataStorage.Save(Data);
        }

        public void AddModToPack(ModPack modPack, Mod mod)
        {
            var pack = Data.ModPacks.FirstOrDefault(x => x.Name == modPack.Name);
            
            pack.Mods.Add(mod);
            DataStorage.Save(Data);
        }

        public ModPack GetModpack(string name)
        {
            var pack = Data.ModPacks.FirstOrDefault(x => x.Name == name);
            return pack;
        }

        public List<ModPack> GetModpacks() 
            => Data.ModPacks;

        public void SetModToggle(string modPack, string mod, bool enabled)
        {
            var pack = Data.ModPacks.FirstOrDefault(x => x.Name == modPack);
            var ourMod = pack.Mods.FirstOrDefault(x => x.Name == mod);

            ourMod.Enabled = enabled;
            DataStorage.Save(Data);
        }
        public void SetModConfig(string modPack, string mod, string config)
        {
            var pack = Data.ModPacks.FirstOrDefault(x => x.Name == modPack);
            var ourMod = pack.Mods.FirstOrDefault(x => x.Name == mod);

            ourMod.ConfigLocation = config;
            DataStorage.Save(Data);
        }
        
        public void ChangeModConfig(string modPack, string mod, string config)
        {
            var pack = Data.ModPacks.FirstOrDefault(x => x.Name == modPack);
            var ourMod = pack.Mods.FirstOrDefault(x => x.Name == mod);

            File.WriteAllText(ourMod.ConfigLocation, config);
            
            DataStorage.Save(Data);
        }
        
    }
}