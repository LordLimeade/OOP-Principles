namespace StudentSystem
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
            this.StudentDataGrid = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assignment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Possible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Earned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Letter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddStudentBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.DeleteStudentBtn = new System.Windows.Forms.Button();
            this.NewAssignmentBtn = new System.Windows.Forms.Button();
            this.DeleteAssignmentBtn = new System.Windows.Forms.Button();
            this.StudentsDropDown = new System.Windows.Forms.ComboBox();
            this.BtnDeleteAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.StuNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StuDormLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StuMealLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SaveAssignmentBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.HiddenStudent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StudentDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentDataGrid
            // 
            this.StudentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Assignment,
            this.Possible,
            this.Earned,
            this.Percentage,
            this.Letter});
            this.StudentDataGrid.Location = new System.Drawing.Point(205, 16);
            this.StudentDataGrid.Name = "StudentDataGrid";
            this.StudentDataGrid.RowTemplate.Height = 24;
            this.StudentDataGrid.Size = new System.Drawing.Size(656, 311);
            this.StudentDataGrid.TabIndex = 1;
            this.StudentDataGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentDataGrid_CellEnter);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MaxInputLength = 10;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // Assignment
            // 
            this.Assignment.HeaderText = "Assignment Name";
            this.Assignment.MaxInputLength = 30;
            this.Assignment.Name = "Assignment";
            this.Assignment.Width = 120;
            // 
            // Possible
            // 
            this.Possible.HeaderText = "Points Possible";
            this.Possible.MaxInputLength = 5;
            this.Possible.Name = "Possible";
            this.Possible.Width = 70;
            // 
            // Earned
            // 
            this.Earned.HeaderText = "Points Earned";
            this.Earned.MaxInputLength = 5;
            this.Earned.Name = "Earned";
            this.Earned.Width = 70;
            // 
            // Percentage
            // 
            this.Percentage.HeaderText = "Percent Grade";
            this.Percentage.MaxInputLength = 6;
            this.Percentage.Name = "Percentage";
            this.Percentage.ReadOnly = true;
            this.Percentage.Width = 70;
            // 
            // Letter
            // 
            this.Letter.HeaderText = "Letter Grade";
            this.Letter.MaxInputLength = 3;
            this.Letter.Name = "Letter";
            this.Letter.ReadOnly = true;
            this.Letter.Width = 70;
            // 
            // AddStudentBtn
            // 
            this.AddStudentBtn.Location = new System.Drawing.Point(254, 374);
            this.AddStudentBtn.Name = "AddStudentBtn";
            this.AddStudentBtn.Size = new System.Drawing.Size(121, 43);
            this.AddStudentBtn.TabIndex = 6;
            this.AddStudentBtn.Text = "Add - Edit Student";
            this.AddStudentBtn.UseVisualStyleBackColor = true;
            this.AddStudentBtn.Click += new System.EventHandler(this.AddStudentBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(738, 374);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(121, 43);
            this.ExitBtn.TabIndex = 8;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // DeleteStudentBtn
            // 
            this.DeleteStudentBtn.Location = new System.Drawing.Point(12, 236);
            this.DeleteStudentBtn.Name = "DeleteStudentBtn";
            this.DeleteStudentBtn.Size = new System.Drawing.Size(146, 26);
            this.DeleteStudentBtn.TabIndex = 2;
            this.DeleteStudentBtn.Text = "Delete Student";
            this.DeleteStudentBtn.UseVisualStyleBackColor = true;
            this.DeleteStudentBtn.Click += new System.EventHandler(this.DeleteStudentBtn_Click);
            // 
            // NewAssignmentBtn
            // 
            this.NewAssignmentBtn.Location = new System.Drawing.Point(12, 374);
            this.NewAssignmentBtn.Name = "NewAssignmentBtn";
            this.NewAssignmentBtn.Size = new System.Drawing.Size(121, 43);
            this.NewAssignmentBtn.TabIndex = 5;
            this.NewAssignmentBtn.Text = "Add New Assignment";
            this.NewAssignmentBtn.UseVisualStyleBackColor = true;
            this.NewAssignmentBtn.Click += new System.EventHandler(this.NewAssignmentBtn_Click);
            // 
            // DeleteAssignmentBtn
            // 
            this.DeleteAssignmentBtn.Location = new System.Drawing.Point(12, 300);
            this.DeleteAssignmentBtn.Name = "DeleteAssignmentBtn";
            this.DeleteAssignmentBtn.Size = new System.Drawing.Size(146, 26);
            this.DeleteAssignmentBtn.TabIndex = 4;
            this.DeleteAssignmentBtn.Text = "Delete Assignment";
            this.DeleteAssignmentBtn.UseVisualStyleBackColor = true;
            this.DeleteAssignmentBtn.Click += new System.EventHandler(this.DeleteAssignmentBtn_Click);
            // 
            // StudentsDropDown
            // 
            this.StudentsDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StudentsDropDown.FormattingEnabled = true;
            this.StudentsDropDown.Location = new System.Drawing.Point(12, 29);
            this.StudentsDropDown.Name = "StudentsDropDown";
            this.StudentsDropDown.Size = new System.Drawing.Size(146, 24);
            this.StudentsDropDown.TabIndex = 0;
            this.StudentsDropDown.SelectedValueChanged += new System.EventHandler(this.StudentsDropDown_SelectedValueChanged);
            // 
            // BtnDeleteAll
            // 
            this.BtnDeleteAll.Location = new System.Drawing.Point(12, 268);
            this.BtnDeleteAll.Name = "BtnDeleteAll";
            this.BtnDeleteAll.Size = new System.Drawing.Size(146, 26);
            this.BtnDeleteAll.TabIndex = 3;
            this.BtnDeleteAll.Text = "Delete All Students";
            this.BtnDeleteAll.UseVisualStyleBackColor = true;
            this.BtnDeleteAll.Click += new System.EventHandler(this.BtnDeleteAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name";
            // 
            // StuNameLabel
            // 
            this.StuNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StuNameLabel.Location = new System.Drawing.Point(12, 83);
            this.StuNameLabel.Name = "StuNameLabel";
            this.StuNameLabel.Size = new System.Drawing.Size(146, 26);
            this.StuNameLabel.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Dorm";
            // 
            // StuDormLabel
            // 
            this.StuDormLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StuDormLabel.Location = new System.Drawing.Point(12, 133);
            this.StuDormLabel.Name = "StuDormLabel";
            this.StuDormLabel.Size = new System.Drawing.Size(146, 26);
            this.StuDormLabel.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "ID";
            // 
            // StuMealLabel
            // 
            this.StuMealLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StuMealLabel.Location = new System.Drawing.Point(12, 183);
            this.StuMealLabel.Name = "StuMealLabel";
            this.StuMealLabel.Size = new System.Drawing.Size(146, 26);
            this.StuMealLabel.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "MealPlan";
            // 
            // SaveAssignmentBtn
            // 
            this.SaveAssignmentBtn.Location = new System.Drawing.Point(496, 374);
            this.SaveAssignmentBtn.Name = "SaveAssignmentBtn";
            this.SaveAssignmentBtn.Size = new System.Drawing.Size(121, 43);
            this.SaveAssignmentBtn.TabIndex = 7;
            this.SaveAssignmentBtn.Text = "Save Changes";
            this.SaveAssignmentBtn.UseVisualStyleBackColor = true;
            this.SaveAssignmentBtn.Click += new System.EventHandler(this.SaveAssignmentBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(523, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "***Make Sure to Press the Save Changes Button When Editting Student Grades***";
            // 
            // HiddenStudent
            // 
            this.HiddenStudent.AutoSize = true;
            this.HiddenStudent.Location = new System.Drawing.Point(63, 6);
            this.HiddenStudent.Name = "HiddenStudent";
            this.HiddenStudent.Size = new System.Drawing.Size(0, 17);
            this.HiddenStudent.TabIndex = 17;
            this.HiddenStudent.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 429);
            this.Controls.Add(this.HiddenStudent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StuMealLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StuDormLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StuNameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnDeleteAll);
            this.Controls.Add(this.StudentsDropDown);
            this.Controls.Add(this.SaveAssignmentBtn);
            this.Controls.Add(this.DeleteAssignmentBtn);
            this.Controls.Add(this.NewAssignmentBtn);
            this.Controls.Add(this.DeleteStudentBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.AddStudentBtn);
            this.Controls.Add(this.StudentDataGrid);
            this.Name = "MainForm";
            this.Text = "Students System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StudentDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView StudentDataGrid;
        private System.Windows.Forms.Button AddStudentBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button DeleteStudentBtn;
        private System.Windows.Forms.Button NewAssignmentBtn;
        private System.Windows.Forms.Button DeleteAssignmentBtn;
        private System.Windows.Forms.ComboBox StudentsDropDown;
        private System.Windows.Forms.Button BtnDeleteAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label StuNameLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assignment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Possible;
        private System.Windows.Forms.DataGridViewTextBoxColumn Earned;
        private System.Windows.Forms.DataGridViewTextBoxColumn Percentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Letter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label StuDormLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label StuMealLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SaveAssignmentBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label HiddenStudent;
    }
}

