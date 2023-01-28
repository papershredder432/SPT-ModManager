using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SPT_Manager.API;
using SPT_Manager.DataControl;
using SPT_Manager.Models;

namespace SPT_Manager
{
    public partial class SPTManager : Form
    {
        public string SptDir;
        public static SPTManager Instance { get; set; }
        public Database Database = new Database();
        private ModManager _modManager = new ModManager();
        private UserManager _userManager = new UserManager();
        
        public SPTManager()
        {
            InitializeComponent();
            Instance = this;
            Database.Reload();
            
            SptDir = AppContext.BaseDirectory;

            btn_addMods.Enabled = false;
            btn_createPack.Enabled = false;
            btn_saveMod.Enabled = false;
            btn_loadServerMods.Enabled = false;
            btn_addConfig.Enabled = false;
            btn_loadPack.Enabled = false;

            cmb_modpack.Enabled = false;
            cmb_users.Enabled = false;

            prg_loadPack.Visible = false;
            
            Initialize();
        }
        
        private void Initialize()
        {
            var users = _userManager.InitUsers();
            foreach (var user in users)
            {
                cmb_users.Items.Add(user.Username);
            }

            
            var mods = Database.Data.ModPacks;
            if (mods != null)
            {
                foreach (var mod in mods)
                {
                    cmb_modpack.Items.Add(mod.Name);
                }
            }
            
            
            var defaultUser = Database.GetDefaultUser();
            if (!string.IsNullOrWhiteSpace(defaultUser))
            {
                foreach (var user in users.Where(user => user.UserId == defaultUser))
                {
                    cmb_users.SelectedItem = user.Username;

                    if (!string.IsNullOrWhiteSpace(user.DefaultPack))
                    {
                        cmb_modpack.SelectedItem = user.DefaultPack;
                    }

                    break;
                }
            }

            cmb_modpack.Enabled = true;
            cmb_users.Enabled = true;
            
            btn_createPack.Enabled = true;
            btn_loadServerMods.Enabled = true;
        }
        
        private void btn_loadServerMods_Click(object sender, EventArgs e)
        {
            if (Database.GetModpack("Default") != null) return;
            
            var folders = new DirectoryInfo($@"{SptDir}user\mods\").GetDirectories();
            var mods = new List<Mod>();

            var configJson = "";
            
            foreach (var mod in folders)
            {
                var children = mod.GetFiles("config.json", SearchOption.AllDirectories);
                if (children.Length != 0)
                {
                    var directoryInfo = children.FirstOrDefault(x => x.Name == "config.json").Directory;
                    configJson = directoryInfo != null ? $@"{directoryInfo.FullName}\config.json" : "";
                }

                var newMod = new Mod
                {
                    Name = mod.Name,
                    Enabled = true,
                    ConfigLocation = configJson
                };
                mods.Add(newMod);

                configJson = "";
            }

            var modPack = new ModPack
            {
                Name = "Default",
                Mods = mods
            };
            
            cmb_modpack.Items.Add(modPack.Name);
            Database.CreateModpack(modPack);
            //RefreshTable();
        }

        private void btn_saveMod_Click(object sender, EventArgs e)
        {
            foreach (var p in tab_Mods.TabPages)
            {
                var page = p as TabPage;
                foreach (var c in page.Controls)
                {
                    switch (c)
                    {
                        case CheckBox box:
                        {
                            Database.SetModToggle(cmb_modpack.Text, page.Text, box.Checked);
                            break;
                        }
                        case TextBox box:
                        {
                            Database.ChangeModConfig(cmb_modpack.Text, page.Text, box.Text);
                            break;
                        }
                    }
                }
            }
        }

        private void cmb_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_addMods_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            var dirInf = new DirectoryInfo(fbd.SelectedPath);

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                var configJson = "";
                
                var children = dirInf.GetFiles("config.json", SearchOption.AllDirectories);
                if (children.Length == 0)
                {
                    var directoryInfo = children.FirstOrDefault(x => x.Name == "config.json").Directory;
                    configJson = directoryInfo != null ? $@"{directoryInfo.FullName}\config.json" : "";
                }

                _modManager.AddMod(dirInf.Name, cmb_modpack.Text, configJson);
            }

            var newPage = new TabPage($"page_{dirInf.Name}");
            newPage.Text = dirInf.Name;
            
            tab_Mods.TabPages.Add(newPage);

            var chkBox = new CheckBox();
            chkBox.Name = $"chk_{dirInf.Name}";
            chkBox.Text = "Enabled";
            chkBox.Checked = false;
            
            newPage.Controls.Add(chkBox);

            btn_addConfig.Enabled = true;
        }

        private void cmb_modpack_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_addMods.Enabled = true;
            btn_saveMod.Enabled = true;
            btn_addConfig.Enabled = true;
            btn_loadPack.Enabled = true;
            
            RefreshTable();
        }

        private void RefreshTable()
        {
            tab_Mods.TabPages.Clear();

            var ourPack = Database.GetModpack(cmb_modpack.Text);
            var mods = ourPack.Mods;

            foreach (var mod in mods)
            {
                var newPage = new TabPage($"page_{mod.Name}");
                newPage.Text = mod.Name;
            
                tab_Mods.TabPages.Add(newPage);

                var chkBox = new CheckBox();
                chkBox.Name = $"chk_{mod.Name}";
                chkBox.Text = "Enabled";
                chkBox.Checked = mod.Enabled;

                newPage.Controls.Add(chkBox);

                if (string.IsNullOrWhiteSpace(mod.ConfigLocation)) continue;
                var streamReader = new StreamReader(mod.ConfigLocation).ReadToEnd();

                var txt = new TextBox();
                txt.Name = $"txt_{mod.Name}";
                txt.Multiline = true;
                txt.Location = new Point(0, txt.Location.Y + chkBox.Height);
                txt.Width = newPage.Width;
                txt.Height = newPage.Height;
                txt.ScrollBars = ScrollBars.Vertical;
                txt.Text = streamReader;
                
                newPage.Controls.Add(txt);
            }
        }

        private void btn_createPack_Click(object sender, EventArgs e)
        {
            tab_Mods.TabPages.Clear();
            
            if (string.IsNullOrWhiteSpace(cmb_modpack.Text))
            {
                MessageBox.Show("Please type what you want this pack to be named!", "Input a Name",
                    MessageBoxButtons.OK);
                return;
            }
            
            if (cmb_modpack.Items.Cast<object>().Any(i => i.ToString().ToLower() == cmb_modpack.Text.ToLower()))
            {
                MessageBox.Show("There is already a pack with that name, please specify a new one!", "Item Already Exists",
                    MessageBoxButtons.OK);
                return;
            }

            cmb_modpack.Items.Add(cmb_modpack.Text);
            btn_addMods.Enabled = true;
            btn_saveMod.Enabled = true;
            btn_loadPack.Enabled = true;
            
            _modManager.CreatePack(cmb_modpack.Text);
        }

        private void btn_addConfig_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();
            ofd.Multiselect = false;

            var height = 0;
            
            foreach (var c in tab_Mods.SelectedTab.Controls)
            {
                var component = c as CheckBox;
                if (component == null) continue;

                height = component.Height;
            }
            
            switch (result)
            {
                case DialogResult.OK when !string.IsNullOrWhiteSpace(ofd.FileName):
                {
                    var streamReader = new StreamReader(ofd.OpenFile()).ReadToEnd();
                    //var json = new JsonTextReader(streamReader);

                    var txt = new TextBox();
                    txt.Name = $"txt_{tab_Mods.SelectedTab.Name}";
                    txt.Multiline = true;
                    txt.Location = new Point(0, txt.Location.Y + height);
                    txt.Height = tab_Mods.SelectedTab.Size.Height;
                    txt.Width = tab_Mods.SelectedTab.Size.Width;
                    txt.Text = streamReader;
                    txt.ScrollBars = ScrollBars.Vertical;
                
                    tab_Mods.SelectedTab.Controls.Add(txt);
                    
                    Database.SetModConfig(cmb_modpack.SelectedItem.ToString(), tab_Mods.SelectedTab.Text, ofd.FileName);
                    break;
                }
                case DialogResult.Cancel:
                    return;
            }
        }

        private void btn_loadPack_Click(object sender, EventArgs e)
        {
            if (tab_Mods.TabPages.Count == 0) return;
            prg_loadPack.Visible = true;

            var mods = new DirectoryInfo($@"{SptDir}user\mods\").GetDirectories();
            var newMods = Database.GetModpack(cmb_modpack.SelectedItem.ToString()).Mods;

            prg_loadPack.Maximum = mods.Length + newMods.Count + 1;
            prg_loadPack.Step = 1;
            prg_loadPack.Minimum = 1;
            
            if (mods.Length > 1)
            {
                foreach (var m in mods)
                {
                    prg_loadPack.PerformStep();
                    _modManager.DisableMod(m.Name);
                }
            }
            
            foreach (var m in newMods)
            {
                switch (m.Enabled)
                {
                    case true:
                    {
                        prg_loadPack.PerformStep();
                        _modManager.EnableMod(m.Name);
                        break;
                    }

                    case false:
                    {
                        prg_loadPack.PerformStep();
                        _modManager.DisableMod(m.Name);
                        break;
                    }
                }
            }

            prg_loadPack.Value = 1;
            prg_loadPack.Visible = false;
        }

        private void lblGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/papershredder432");
        }

        private void lblDiscord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/ydjYVJ2");
        }
    }
}