namespace SPT_Manager
{
    partial class SPTManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SPTManager));
            this.tab_Mods = new System.Windows.Forms.TabControl();
            this.btn_saveMod = new System.Windows.Forms.Button();
            this.btn_loadServerMods = new System.Windows.Forms.Button();
            this.cmb_users = new System.Windows.Forms.ComboBox();
            this.btn_addMods = new System.Windows.Forms.Button();
            this.cmb_modpack = new System.Windows.Forms.ComboBox();
            this.lbl_user = new System.Windows.Forms.Label();
            this.lbl_modpack = new System.Windows.Forms.Label();
            this.btn_createPack = new System.Windows.Forms.Button();
            this.btn_addConfig = new System.Windows.Forms.Button();
            this.btn_loadPack = new System.Windows.Forms.Button();
            this.prg_loadPack = new System.Windows.Forms.ProgressBar();
            this.lblContext = new System.Windows.Forms.Label();
            this.lblDiscord = new System.Windows.Forms.LinkLabel();
            this.lblGitHub = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // tab_Mods
            // 
            this.tab_Mods.Location = new System.Drawing.Point(126, 61);
            this.tab_Mods.Multiline = true;
            this.tab_Mods.Name = "tab_Mods";
            this.tab_Mods.SelectedIndex = 0;
            this.tab_Mods.Size = new System.Drawing.Size(652, 377);
            this.tab_Mods.TabIndex = 1;
            // 
            // btn_saveMod
            // 
            this.btn_saveMod.Location = new System.Drawing.Point(12, 401);
            this.btn_saveMod.Name = "btn_saveMod";
            this.btn_saveMod.Size = new System.Drawing.Size(108, 37);
            this.btn_saveMod.TabIndex = 2;
            this.btn_saveMod.Text = "Save Mod Settings";
            this.btn_saveMod.UseVisualStyleBackColor = true;
            this.btn_saveMod.Click += new System.EventHandler(this.btn_saveMod_Click);
            // 
            // btn_loadServerMods
            // 
            this.btn_loadServerMods.Location = new System.Drawing.Point(12, 98);
            this.btn_loadServerMods.Name = "btn_loadServerMods";
            this.btn_loadServerMods.Size = new System.Drawing.Size(108, 37);
            this.btn_loadServerMods.TabIndex = 3;
            this.btn_loadServerMods.Text = "Load Server Mods";
            this.btn_loadServerMods.UseVisualStyleBackColor = true;
            this.btn_loadServerMods.Click += new System.EventHandler(this.btn_loadServerMods_Click);
            // 
            // cmb_users
            // 
            this.cmb_users.FormattingEnabled = true;
            this.cmb_users.Location = new System.Drawing.Point(197, 12);
            this.cmb_users.Name = "cmb_users";
            this.cmb_users.Size = new System.Drawing.Size(155, 21);
            this.cmb_users.TabIndex = 4;
            this.cmb_users.SelectedIndexChanged += new System.EventHandler(this.cmb_users_SelectedIndexChanged);
            // 
            // btn_addMods
            // 
            this.btn_addMods.Location = new System.Drawing.Point(12, 315);
            this.btn_addMods.Name = "btn_addMods";
            this.btn_addMods.Size = new System.Drawing.Size(108, 37);
            this.btn_addMods.TabIndex = 5;
            this.btn_addMods.Text = "Add Mod";
            this.btn_addMods.UseVisualStyleBackColor = true;
            this.btn_addMods.Click += new System.EventHandler(this.btn_addMods_Click);
            // 
            // cmb_modpack
            // 
            this.cmb_modpack.FormattingEnabled = true;
            this.cmb_modpack.Location = new System.Drawing.Point(197, 34);
            this.cmb_modpack.Name = "cmb_modpack";
            this.cmb_modpack.Size = new System.Drawing.Size(155, 21);
            this.cmb_modpack.TabIndex = 6;
            this.cmb_modpack.SelectedIndexChanged += new System.EventHandler(this.cmb_modpack_SelectedIndexChanged);
            // 
            // lbl_user
            // 
            this.lbl_user.Location = new System.Drawing.Point(127, 15);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(64, 23);
            this.lbl_user.TabIndex = 7;
            this.lbl_user.Text = "User";
            // 
            // lbl_modpack
            // 
            this.lbl_modpack.Location = new System.Drawing.Point(127, 38);
            this.lbl_modpack.Name = "lbl_modpack";
            this.lbl_modpack.Size = new System.Drawing.Size(64, 23);
            this.lbl_modpack.TabIndex = 8;
            this.lbl_modpack.Text = "Mod Pack";
            // 
            // btn_createPack
            // 
            this.btn_createPack.Location = new System.Drawing.Point(12, 12);
            this.btn_createPack.Name = "btn_createPack";
            this.btn_createPack.Size = new System.Drawing.Size(108, 37);
            this.btn_createPack.TabIndex = 9;
            this.btn_createPack.Text = "Create Pack";
            this.btn_createPack.UseVisualStyleBackColor = true;
            this.btn_createPack.Click += new System.EventHandler(this.btn_createPack_Click);
            // 
            // btn_addConfig
            // 
            this.btn_addConfig.Location = new System.Drawing.Point(12, 358);
            this.btn_addConfig.Name = "btn_addConfig";
            this.btn_addConfig.Size = new System.Drawing.Size(108, 37);
            this.btn_addConfig.TabIndex = 10;
            this.btn_addConfig.Text = "Add Config";
            this.btn_addConfig.UseVisualStyleBackColor = true;
            this.btn_addConfig.Click += new System.EventHandler(this.btn_addConfig_Click);
            // 
            // btn_loadPack
            // 
            this.btn_loadPack.Location = new System.Drawing.Point(12, 55);
            this.btn_loadPack.Name = "btn_loadPack";
            this.btn_loadPack.Size = new System.Drawing.Size(108, 37);
            this.btn_loadPack.TabIndex = 11;
            this.btn_loadPack.Text = "Load Selected Pack";
            this.btn_loadPack.UseVisualStyleBackColor = true;
            this.btn_loadPack.Click += new System.EventHandler(this.btn_loadPack_Click);
            // 
            // prg_loadPack
            // 
            this.prg_loadPack.Location = new System.Drawing.Point(12, 141);
            this.prg_loadPack.Name = "prg_loadPack";
            this.prg_loadPack.Size = new System.Drawing.Size(108, 23);
            this.prg_loadPack.TabIndex = 12;
            // 
            // lblContext
            // 
            this.lblContext.Location = new System.Drawing.Point(640, 9);
            this.lblContext.Name = "lblContext";
            this.lblContext.Size = new System.Drawing.Size(138, 15);
            this.lblContext.TabIndex = 14;
            this.lblContext.Text = "Made by papershredder432";
            this.lblContext.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDiscord
            // 
            this.lblDiscord.Location = new System.Drawing.Point(710, 24);
            this.lblDiscord.Name = "lblDiscord";
            this.lblDiscord.Size = new System.Drawing.Size(68, 14);
            this.lblDiscord.TabIndex = 15;
            this.lblDiscord.TabStop = true;
            this.lblDiscord.Text = "Dev Discord";
            this.lblDiscord.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDiscord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDiscord_LinkClicked);
            // 
            // lblGitHub
            // 
            this.lblGitHub.Location = new System.Drawing.Point(710, 38);
            this.lblGitHub.Name = "lblGitHub";
            this.lblGitHub.Size = new System.Drawing.Size(68, 15);
            this.lblGitHub.TabIndex = 16;
            this.lblGitHub.TabStop = true;
            this.lblGitHub.Text = "GitHub";
            this.lblGitHub.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblGitHub_LinkClicked);
            // 
            // SPTManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(790, 455);
            this.Controls.Add(this.lblGitHub);
            this.Controls.Add(this.lblDiscord);
            this.Controls.Add(this.lblContext);
            this.Controls.Add(this.prg_loadPack);
            this.Controls.Add(this.btn_loadPack);
            this.Controls.Add(this.btn_addConfig);
            this.Controls.Add(this.btn_createPack);
            this.Controls.Add(this.lbl_modpack);
            this.Controls.Add(this.lbl_user);
            this.Controls.Add(this.cmb_modpack);
            this.Controls.Add(this.btn_addMods);
            this.Controls.Add(this.cmb_users);
            this.Controls.Add(this.btn_loadServerMods);
            this.Controls.Add(this.btn_saveMod);
            this.Controls.Add(this.tab_Mods);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "SPTManager";
            this.Text = "SPT Mod Manager";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.LinkLabel lblGitHub;

        private System.Windows.Forms.Label lblContext;
        private System.Windows.Forms.LinkLabel lblDiscord;

        private System.Windows.Forms.ProgressBar prg_loadPack;

        private System.Windows.Forms.Button btn_loadPack;

        private System.Windows.Forms.Button btn_addConfig;

        private System.Windows.Forms.Button btn_createPack;

        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.Label lbl_modpack;

        private System.Windows.Forms.ComboBox cmb_modpack;

        private System.Windows.Forms.Button btn_addMods;

        private System.Windows.Forms.ComboBox cmb_users;

        private System.Windows.Forms.Button btn_loadServerMods;

        private System.Windows.Forms.Button btn_saveMod;

        private System.Windows.Forms.TabControl tab_Mods;

        #endregion
    }
}