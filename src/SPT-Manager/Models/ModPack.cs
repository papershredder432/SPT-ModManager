using System.Collections.Generic;

namespace SPT_Manager.Models
{
    public class ModPack
    {
        public string Name { get; set; }
        
        public List<Mod> Mods { get; set; }
    }
}