namespace AlarmClock
{
    partial class AddEditForm
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.setButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.onCheckBox = new System.Windows.Forms.CheckBox();
            this.snoozeTimer = new System.Windows.Forms.NumericUpDown();
            this.soundList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.snoozeTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker.Location = new System.Drawing.Point(46, 11);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker.TabIndex = 0;
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(26, 131);
            this.setButton.Margin = new System.Windows.Forms.Padding(2);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(56, 32);
            this.setButton.TabIndex = 2;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(199, 131);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(56, 32);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // onCheckBox
            // 
            this.onCheckBox.AutoSize = true;
            this.onCheckBox.Location = new System.Drawing.Point(215, 16);
            this.onCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.onCheckBox.Name = "onCheckBox";
            this.onCheckBox.Size = new System.Drawing.Size(40, 17);
            this.onCheckBox.TabIndex = 4;
            this.onCheckBox.Text = "On";
            this.onCheckBox.UseVisualStyleBackColor = true;
            // 
            // snoozeTimer
            // 
            this.snoozeTimer.Location = new System.Drawing.Point(46, 89);
            this.snoozeTimer.Name = "snoozeTimer";
            this.snoozeTimer.Size = new System.Drawing.Size(48, 20);
            this.snoozeTimer.TabIndex = 5;
            // 
            // soundList
            // 
            this.soundList.FormattingEnabled = true;
            this.soundList.Location = new System.Drawing.Point(46, 49);
            this.soundList.Name = "soundList";
            this.soundList.Size = new System.Drawing.Size(121, 21);
            this.soundList.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select an Alarm Sound:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Set a snooze time:";
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 174);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.soundList);
            this.Controls.Add(this.snoozeTimer);
            this.Controls.Add(this.onCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.dateTimePicker);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddEditForm";
            this.Text = "Add/Edit Alarm";
            ((System.ComponentModel.ISupportInitialize)(this.snoozeTimer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox onCheckBox;
        private System.Windows.Forms.NumericUpDown snoozeTimer;
        private System.Windows.Forms.ComboBox soundList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}