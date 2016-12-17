namespace KeyboardStatus
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gbSet = new System.Windows.Forms.GroupBox();
            this.cbStartWithSystem = new System.Windows.Forms.CheckBox();
            this.cbShowNumberLock = new System.Windows.Forms.CheckBox();
            this.cbShowCapslock = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSet
            // 
            this.gbSet.Controls.Add(this.cbStartWithSystem);
            this.gbSet.Controls.Add(this.cbShowNumberLock);
            this.gbSet.Controls.Add(this.cbShowCapslock);
            this.gbSet.Location = new System.Drawing.Point(12, 12);
            this.gbSet.Name = "gbSet";
            this.gbSet.Size = new System.Drawing.Size(242, 63);
            this.gbSet.TabIndex = 0;
            this.gbSet.TabStop = false;
            this.gbSet.Text = "Set";
            // 
            // cbStartWithSystem
            // 
            this.cbStartWithSystem.AutoSize = true;
            this.cbStartWithSystem.Location = new System.Drawing.Point(6, 42);
            this.cbStartWithSystem.Name = "cbStartWithSystem";
            this.cbStartWithSystem.Size = new System.Drawing.Size(114, 16);
            this.cbStartWithSystem.TabIndex = 0;
            this.cbStartWithSystem.Text = "StartWithSystem";
            this.cbStartWithSystem.UseVisualStyleBackColor = true;
            this.cbStartWithSystem.CheckedChanged += new System.EventHandler(this.cbStartWithSystem_CheckedChanged);
            // 
            // cbShowNumberLock
            // 
            this.cbShowNumberLock.AutoSize = true;
            this.cbShowNumberLock.Location = new System.Drawing.Point(108, 20);
            this.cbShowNumberLock.Name = "cbShowNumberLock";
            this.cbShowNumberLock.Size = new System.Drawing.Size(108, 16);
            this.cbShowNumberLock.TabIndex = 0;
            this.cbShowNumberLock.Text = "ShowNumberLock";
            this.cbShowNumberLock.UseVisualStyleBackColor = true;
            this.cbShowNumberLock.CheckedChanged += new System.EventHandler(this.cbShowNumberLock_CheckedChanged);
            // 
            // cbShowCapslock
            // 
            this.cbShowCapslock.AutoSize = true;
            this.cbShowCapslock.Location = new System.Drawing.Point(6, 20);
            this.cbShowCapslock.Name = "cbShowCapslock";
            this.cbShowCapslock.Size = new System.Drawing.Size(96, 16);
            this.cbShowCapslock.TabIndex = 0;
            this.cbShowCapslock.Text = "ShowCapslock";
            this.cbShowCapslock.UseVisualStyleBackColor = true;
            this.cbShowCapslock.CheckedChanged += new System.EventHandler(this.cbShowCapslock_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "查看/更改设置需要以管理员身份运行；以上为默认设置。";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 118);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "KeyboradStatus";
            this.gbSet.ResumeLayout(false);
            this.gbSet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSet;
        private System.Windows.Forms.CheckBox cbStartWithSystem;
        private System.Windows.Forms.CheckBox cbShowNumberLock;
        private System.Windows.Forms.CheckBox cbShowCapslock;
        private System.Windows.Forms.Label label1;
    }
}