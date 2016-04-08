namespace RenameFolder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.pictureBoxStatus = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.comboUserList = new System.Windows.Forms.ComboBox();
            this.btnListMemberFolders = new System.Windows.Forms.Button();
            this.txtFolderList = new System.Windows.Forms.Label();
            this.comboFolderList = new System.Windows.Forms.ComboBox();
            this.txtTargetAccount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(106, 12);
            this.txtToken.Name = "txtToken";
            this.txtToken.PasswordChar = '*';
            this.txtToken.Size = new System.Drawing.Size(382, 20);
            this.txtToken.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Access Token";
            // 
            // btnConnect
            // 
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(106, 38);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(382, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect to Dropbox";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // pictureBoxStatus
            // 
            this.pictureBoxStatus.Location = new System.Drawing.Point(494, 12);
            this.pictureBoxStatus.Name = "pictureBoxStatus";
            this.pictureBoxStatus.Size = new System.Drawing.Size(37, 22);
            this.pictureBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStatus.TabIndex = 3;
            this.pictureBoxStatus.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Network-Connected-icon.png");
            this.imageList1.Images.SetKeyName(1, "Network-Disconnected-icon.png");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Target Account";
            // 
            // comboUserList
            // 
            this.comboUserList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboUserList.FormattingEnabled = true;
            this.comboUserList.Location = new System.Drawing.Point(106, 69);
            this.comboUserList.Name = "comboUserList";
            this.comboUserList.Size = new System.Drawing.Size(382, 21);
            this.comboUserList.TabIndex = 5;
            this.comboUserList.SelectedIndexChanged += new System.EventHandler(this.comboUserList_SelectedIndexChanged);
            // 
            // btnListMemberFolders
            // 
            this.btnListMemberFolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListMemberFolders.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListMemberFolders.Location = new System.Drawing.Point(106, 97);
            this.btnListMemberFolders.Name = "btnListMemberFolders";
            this.btnListMemberFolders.Size = new System.Drawing.Size(382, 23);
            this.btnListMemberFolders.TabIndex = 6;
            this.btnListMemberFolders.Text = "List Member Folders";
            this.btnListMemberFolders.UseVisualStyleBackColor = true;
            this.btnListMemberFolders.Click += new System.EventHandler(this.btnListMemberFolders_Click);
            // 
            // txtFolderList
            // 
            this.txtFolderList.AutoSize = true;
            this.txtFolderList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolderList.Location = new System.Drawing.Point(5, 130);
            this.txtFolderList.Name = "txtFolderList";
            this.txtFolderList.Size = new System.Drawing.Size(98, 13);
            this.txtFolderList.TabIndex = 7;
            this.txtFolderList.Text = "Folder to Rename";
            // 
            // comboFolderList
            // 
            this.comboFolderList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFolderList.FormattingEnabled = true;
            this.comboFolderList.Location = new System.Drawing.Point(106, 126);
            this.comboFolderList.Name = "comboFolderList";
            this.comboFolderList.Size = new System.Drawing.Size(382, 21);
            this.comboFolderList.TabIndex = 8;
            // 
            // txtTargetAccount
            // 
            this.txtTargetAccount.Location = new System.Drawing.Point(106, 69);
            this.txtTargetAccount.Name = "txtTargetAccount";
            this.txtTargetAccount.Size = new System.Drawing.Size(382, 20);
            this.txtTargetAccount.TabIndex = 9;
            this.txtTargetAccount.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 261);
            this.Controls.Add(this.txtTargetAccount);
            this.Controls.Add(this.comboFolderList);
            this.Controls.Add(this.txtFolderList);
            this.Controls.Add(this.btnListMemberFolders);
            this.Controls.Add(this.comboUserList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBoxStatus);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtToken);
            this.Name = "Form1";
            this.Text = "Rename Dropbox Folder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.PictureBox pictureBoxStatus;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox comboUserList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnListMemberFolders;
        private System.Windows.Forms.Label txtFolderList;
        private System.Windows.Forms.ComboBox comboFolderList;
        private System.Windows.Forms.TextBox txtTargetAccount;
    }
}

