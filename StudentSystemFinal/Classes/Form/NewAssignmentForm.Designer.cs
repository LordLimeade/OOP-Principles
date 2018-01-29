namespace StudentSystem
{
    partial class NewAssignmentForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AssignmentNameTxtBox = new System.Windows.Forms.TextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.PointsPossibleTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Assignment Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Points Possible";
            // 
            // AssignmentNameTxtBox
            // 
            this.AssignmentNameTxtBox.Location = new System.Drawing.Point(15, 29);
            this.AssignmentNameTxtBox.Name = "AssignmentNameTxtBox";
            this.AssignmentNameTxtBox.Size = new System.Drawing.Size(152, 22);
            this.AssignmentNameTxtBox.TabIndex = 0;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(12, 128);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(123, 43);
            this.AddBtn.TabIndex = 2;
            this.AddBtn.Text = "Add Assignment";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(148, 128);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(123, 43);
            this.ClearBtn.TabIndex = 3;
            this.ClearBtn.Text = "Clear Form";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.Location = new System.Drawing.Point(284, 128);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(123, 43);
            this.ReturnBtn.TabIndex = 4;
            this.ReturnBtn.Text = "Return";
            this.ReturnBtn.UseVisualStyleBackColor = true;
            this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
            // 
            // PointsPossibleTxtBox
            // 
            this.PointsPossibleTxtBox.Location = new System.Drawing.Point(15, 76);
            this.PointsPossibleTxtBox.Name = "PointsPossibleTxtBox";
            this.PointsPossibleTxtBox.Size = new System.Drawing.Size(152, 22);
            this.PointsPossibleTxtBox.TabIndex = 1;
            this.PointsPossibleTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PointsPossibleTxtBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(273, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "*** Add an Assignment to Each Student ***";
            // 
            // NewAssignmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 206);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PointsPossibleTxtBox);
            this.Controls.Add(this.ReturnBtn);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.AssignmentNameTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewAssignmentForm";
            this.Text = "New Assignment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AssignmentNameTxtBox;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button ReturnBtn;
        private System.Windows.Forms.TextBox PointsPossibleTxtBox;
        private System.Windows.Forms.Label label3;
    }
}