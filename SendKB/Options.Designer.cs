namespace SendKB
{
    partial class Options
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Timer_On_Off_chbx = new System.Windows.Forms.CheckBox();
            this.txbx_OptionsInterval = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_OutFolderSend = new System.Windows.Forms.Button();
            this.tb_OutFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Timer_On_Off_chbx);
            this.groupBox1.Controls.Add(this.txbx_OptionsInterval);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_Cancel);
            this.groupBox1.Controls.Add(this.btn_Save);
            this.groupBox1.Controls.Add(this.btn_OutFolderSend);
            this.groupBox1.Controls.Add(this.tb_OutFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 215);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "settings.xml";
            // 
            // Timer_On_Off_chbx
            // 
            this.Timer_On_Off_chbx.AutoSize = true;
            this.Timer_On_Off_chbx.Location = new System.Drawing.Point(19, 130);
            this.Timer_On_Off_chbx.Name = "Timer_On_Off_chbx";
            this.Timer_On_Off_chbx.Size = new System.Drawing.Size(263, 17);
            this.Timer_On_Off_chbx.TabIndex = 12;
            this.Timer_On_Off_chbx.Text = "Таймер при загрузке программы (Вкл./Выкл.)";
            this.Timer_On_Off_chbx.UseVisualStyleBackColor = true;
            // 
            // txbx_OptionsInterval
            // 
            this.txbx_OptionsInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbx_OptionsInterval.Location = new System.Drawing.Point(19, 88);
            this.txbx_OptionsInterval.Mask = "00000";
            this.txbx_OptionsInterval.Name = "txbx_OptionsInterval";
            this.txbx_OptionsInterval.Size = new System.Drawing.Size(37, 23);
            this.txbx_OptionsInterval.TabIndex = 11;
            this.txbx_OptionsInterval.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Интервал в сек.";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(261, 169);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(82, 28);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Отмена";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Save.Location = new System.Drawing.Point(173, 169);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(82, 28);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "Сохранить";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_OutFolderSend
            // 
            this.btn_OutFolderSend.Location = new System.Drawing.Point(316, 43);
            this.btn_OutFolderSend.Name = "btn_OutFolderSend";
            this.btn_OutFolderSend.Size = new System.Drawing.Size(27, 23);
            this.btn_OutFolderSend.TabIndex = 2;
            this.btn_OutFolderSend.Text = "...";
            this.btn_OutFolderSend.UseVisualStyleBackColor = true;
            this.btn_OutFolderSend.Click += new System.EventHandler(this.btn_OutFolderSend_Click);
            // 
            // tb_OutFolder
            // 
            this.tb_OutFolder.Location = new System.Drawing.Point(19, 43);
            this.tb_OutFolder.Name = "tb_OutFolder";
            this.tb_OutFolder.Size = new System.Drawing.Size(291, 20);
            this.tb_OutFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Исходящий каталог отправки для клиентов";
            // 
            // Options
            // 
            this.AcceptButton = this.btn_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(375, 240);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_OutFolder;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_OutFolderSend;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.MaskedTextBox txbx_OptionsInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox Timer_On_Off_chbx;
    }
}