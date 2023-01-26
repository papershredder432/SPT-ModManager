using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SPT_Manager.DataControl;
using SPT_Manager.Models;

namespace SPT_Manager.API
{
    public class ModManager
    {
        private Database _database => SPTManager.Instance.Database;

        public void AddMod(string modName, string modPack, string configDir)
        {

            var ourPack = _database.GetModpack(modPack);
            
            var newMod = new Mod
            {
                Enabled = false,
                Name = modName,
                ConfigLocation = configDir
            };

            _database.AddModToPack(ourPack, newMod);
            
            //CopyFilesRecursively(dir, $@"{SPTManager.Instance.SptDir}\user\disabled_mods\{modName}");
        }

        public void CreatePack(string name)
        {
            var packs = _database.GetModpacks() ?? new List<ModPack>();
            var modPacks = packs.ToList();

            var newPack = new ModPack
            {
                Name = name,
                Mods = new List<Mod>{ }
            };
            
            modPacks.Add(newPack);
            
            _database.SetModpacks(modPacks);
        }
        
        public void DisableMod(string modName)
        {
            if (!Directory.Exists($@"{SPTManager.Instance.SptDir}user\disabled_mods\"))
            {
                Directory.CreateDirectory($@"{SPTManager.Instance.SptDir}user\disabled_mods\");
            }

            if (!Directory.Exists($@"{SPTManager.Instance.SptDir}user\mods\{modName}"))
            {
                return;
            }

            CopyFilesRecursively($@"{SPTManager.Instance.SptDir}user\mods\{modName}", $@"{SPTManager.Instance.SptDir}user\disabled_mods\{modName}");
            Directory.Delete($@"{SPTManager.Instance.SptDir}user\mods\{modName}", true);
        }
        
        public void EnableMod(string modName)
        {
            if (!Directory.Exists($@"{SPTManager.Instance.SptDir}user\disabled_mods\{modName}"))
            {
                return;
            }

            if (!Directory.Exists($@"{SPTManager.Instance.SptDir}user\mods\{modName}"))
            {
                Directory.CreateDirectory($@"{SPTManager.Instance.SptDir}user\mods\{modName}");
            }
            
            CopyFilesRecursively($@"{SPTManager.Instance.SptDir}user\disabled_mods\{modName}", $@"{SPTManager.Instance.SptDir}user\mods\{modName}");
        }

        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*",SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }
    }
}