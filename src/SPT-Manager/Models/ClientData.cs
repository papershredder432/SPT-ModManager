using System.Collections.Generic;

namespace SPT_Manager.Models
{
    public class ClientData
    {
        public string SptDir { get; set; }
        
        public string DefaultUserId { get; set; }
        
        public List<User> Users { get; set; }
        
        public List<ModPack> ModPacks { get; set; }
    }
}