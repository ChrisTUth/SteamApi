namespace SteamApi
{
    partial class Form1
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.labNothing = new System.Windows.Forms.Label();
            this.labPersonaName = new System.Windows.Forms.Label();
            this.txtSteamID = new System.Windows.Forms.TextBox();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.labSteamID = new System.Windows.Forms.Label();
            this.btnAddRecord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(185, 97);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labNothing
            // 
            this.labNothing.AutoSize = true;
            this.labNothing.Location = new System.Drawing.Point(6, 102);
            this.labNothing.Name = "labNothing";
            this.labNothing.Size = new System.Drawing.Size(52, 13);
            this.labNothing.TabIndex = 1;
            this.labNothing.Text = "Steam Id:";
            // 
            // labPersonaName
            // 
            this.labPersonaName.AutoSize = true;
            this.labPersonaName.Location = new System.Drawing.Point(82, 12);
            this.labPersonaName.Name = "labPersonaName";
            this.labPersonaName.Size = new System.Drawing.Size(52, 13);
            this.labPersonaName.TabIndex = 2;
            this.labPersonaName.Text = "Waiting...";
            // 
            // txtSteamID
            // 
            this.txtSteamID.Location = new System.Drawing.Point(64, 99);
            this.txtSteamID.Name = "txtSteamID";
            this.txtSteamID.Size = new System.Drawing.Size(115, 20);
            this.txtSteamID.TabIndex = 3;
            // 
            // picAvatar
            // 
            this.picAvatar.Location = new System.Drawing.Point(12, 12);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(64, 64);
            this.picAvatar.TabIndex = 4;
            this.picAvatar.TabStop = false;
            // 
            // labSteamID
            // 
            this.labSteamID.AutoSize = true;
            this.labSteamID.Location = new System.Drawing.Point(82, 63);
            this.labSteamID.Name = "labSteamID";
            this.labSteamID.Size = new System.Drawing.Size(52, 13);
            this.labSteamID.TabIndex = 5;
            this.labSteamID.Text = "Waiting...";
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Location = new System.Drawing.Point(85, 29);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(112, 31);
            this.btnAddRecord.TabIndex = 6;
            this.btnAddRecord.Text = "Add User";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 126);
            this.Controls.Add(this.btnAddRecord);
            this.Controls.Add(this.labSteamID);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.txtSteamID);
            this.Controls.Add(this.labPersonaName);
            this.Controls.Add(this.labNothing);
            this.Controls.Add(this.btnSearch);
            this.Name = "Form1";
            this.Text = "SteamApi";
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label labNothing;
        private System.Windows.Forms.Label labPersonaName;
        private System.Windows.Forms.TextBox txtSteamID;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label labSteamID;
        private System.Windows.Forms.Button btnAddRecord;
    }
}

