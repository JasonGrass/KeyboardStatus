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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbShowCapslock = new System.Windows.Forms.CheckBox();
            this.cbShowNumberLock = new System.Windows.Forms.CheckBox();
            this.cbStartWithSystem = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbStartWithSystem);
            this.groupBox1.Controls.Add(this.cbShowNumberLock);
            this.groupBox1.Controls.Add(this.cbShowCapslock);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set";
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
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 109);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "KeyboradStatus";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbStartWithSystem;
        private System.Windows.Forms.CheckBox cbShowNumberLock;
        private System.Windows.Forms.CheckBox cbShowCapslock;
    }
}