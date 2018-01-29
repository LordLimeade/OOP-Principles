namespace StudentSystem
{
    partial class AddEditStudentForm
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
            this.StudentsListBox = new System.Windows.Forms.ListBox();
            this.DormRadio = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NonDormRadio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.MealPlanCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SaveStudentBtn = new System.Windows.Forms.Button();
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.DormDropDown = new System.Windows.Forms.ComboBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.StudentIDTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StudentsListBox
            // 
            this.StudentsListBox.DisplayMember = "New Student";
            this.StudentsListBox.FormattingEnabled = true;
            this.StudentsListBox.ItemHeight = 16;
            this.StudentsListBox.Items.AddRange(new object[] {
            "New Student"});
            this.StudentsListBox.Location = new System.Drawing.Point(12, 12);
            this.StudentsListBox.Name = "StudentsListBox";
            this.StudentsListBox.Size = new System.Drawing.Size(113, 228);
            this.StudentsListBox.TabIndex = 9;
            this.StudentsListBox.SelectedValueChanged += new System.EventHandler(this.StudentsListBox_SelectedValueChanged);
            // 
            // DormRadio
            // 
            this.DormRadio.AutoSize = true;
            this.DormRadio.Location = new System.Drawing.Point(7, 18);
            this.DormRadio.Name = "DormRadio";
            this.DormRadio.Size = new System.Drawing.Size(116, 21);
            this.DormRadio.TabIndex = 0;
            this.DormRadio.TabStop = true;
            this.DormRadio.Text = "Dorm Student";
            this.DormRadio.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NonDormRadio);
            this.panel1.Controls.Add(this.DormRadio);
            this.panel1.Location = new System.Drawing.Point(183, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 57);
            this.panel1.TabIndex = 2;
            this.panel1.TabStop = true;
            this.panel1.Tag = "";
            // 
            // NonDormRadio
            // 
            this.NonDormRadio.AutoSize = true;
            this.NonDormRadio.Location = new System.Drawing.Point(136, 18);
            this.NonDormRadio.Name = "NonDormRadio";
            this.NonDormRadio.Size = new System.Drawing.Size(94, 21);
            this.NonDormRadio.TabIndex = 1;
            this.NonDormRadio.TabStop = true;
            this.NonDormRadio.Text = "Non-Dorm";
            this.NonDormRadio.UseVisualStyleBackColor = true;
            this.NonDormRadio.CheckedChanged += new System.EventHandler(this.NonDormRadio_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dorm?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Student ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Student Name:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(345, 54);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(120, 22);
            this.NameTextBox.TabIndex = 1;
            // 
            // MealPlanCombo
            // 
            this.MealPlanCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MealPlanCombo.Enabled = false;
            this.MealPlanCombo.FormattingEnabled = true;
            this.MealPlanCombo.Location = new System.Drawing.Point(345, 203);
            this.MealPlanCombo.Name = "MealPlanCombo";
            this.MealPlanCombo.Size = new System.Drawing.Size(121, 24);
            this.MealPlanCombo.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Dorm Location:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(342, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Meal Plan:";
            // 
            // SaveStudentBtn
            // 
            this.SaveStudentBtn.Location = new System.Drawing.Point(12, 246);
            this.SaveStudentBtn.Name = "SaveStudentBtn";
            this.SaveStudentBtn.Size = new System.Drawing.Size(147, 40);
            this.SaveStudentBtn.TabIndex = 6;
            this.SaveStudentBtn.Text = "Save Changes";
            this.SaveStudentBtn.UseVisualStyleBackColor = true;
            this.SaveStudentBtn.Click += new System.EventHandler(this.SaveStudentBtn_Click);
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.Location = new System.Drawing.Point(332, 246);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(147, 40);
            this.ReturnBtn.TabIndex = 8;
            this.ReturnBtn.Text = "Return";
            this.ReturnBtn.UseVisualStyleBackColor = true;
            this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
            // 
            // DormDropDown
            // 
            this.DormDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DormDropDown.FormattingEnabled = true;
            this.DormDropDown.Location = new System.Drawing.Point(154, 203);
            this.DormDropDown.Name = "DormDropDown";
            this.DormDropDown.Size = new System.Drawing.Size(121, 24);
            this.DormDropDown.TabIndex = 4;
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(172, 246);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(147, 40);
            this.ClearBtn.TabIndex = 7;
            this.ClearBtn.Text = "Clear Form";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // StudentIDTextBox
            // 
            this.StudentIDTextBox.Location = new System.Drawing.Point(154, 54);
            this.StudentIDTextBox.Name = "StudentIDTextBox";
            this.StudentIDTextBox.Size = new System.Drawing.Size(120, 22);
            this.StudentIDTextBox.TabIndex = 0;
            this.StudentIDTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StudentIDTextBox_KeyPress);
            // 
            // AddEditStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 298);
            this.Controls.Add(this.StudentIDTextBox);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.DormDropDown);
            this.Controls.Add(this.ReturnBtn);
            this.Controls.Add(this.SaveStudentBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MealPlanCombo);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StudentsListBox);
            this.Name = "AddEditStudentForm";
            this.Text = "Add - Edit Students";
            this.Load += new System.EventHandler(this.AddEditStudentForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox StudentsListBox;
        private System.Windows.Forms.RadioButton DormRadio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton NonDormRadio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.ComboBox MealPlanCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SaveStudentBtn;
        private System.Windows.Forms.Button ReturnBtn;
        private System.Windows.Forms.ComboBox DormDropDown;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.TextBox StudentIDTextBox;
    }
}