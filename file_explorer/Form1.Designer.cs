namespace file_explorer
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
            this.LeftList = new System.Windows.Forms.ListBox();
            this.RightList = new System.Windows.Forms.ListBox();
            this.MoveToleftBtn = new System.Windows.Forms.Button();
            this.MoveToRightBtn = new System.Windows.Forms.Button();
            this.CopyToTheOtherSide = new System.Windows.Forms.Button();
            this.DeleteLastSelected = new System.Windows.Forms.Button();
            this.LeftDirectory = new System.Windows.Forms.TextBox();
            this.RightDirectory = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LeftList
            // 
            this.LeftList.FormattingEnabled = true;
            this.LeftList.ItemHeight = 16;
            this.LeftList.Location = new System.Drawing.Point(197, 126);
            this.LeftList.Name = "LeftList";
            this.LeftList.Size = new System.Drawing.Size(153, 164);
            this.LeftList.TabIndex = 0;
            // 
            // RightList
            // 
            this.RightList.FormattingEnabled = true;
            this.RightList.ItemHeight = 16;
            this.RightList.Location = new System.Drawing.Point(469, 126);
            this.RightList.Name = "RightList";
            this.RightList.Size = new System.Drawing.Size(153, 164);
            this.RightList.TabIndex = 1;
            // 
            // MoveToleftBtn
            // 
            this.MoveToleftBtn.Location = new System.Drawing.Point(387, 217);
            this.MoveToleftBtn.Name = "MoveToleftBtn";
            this.MoveToleftBtn.Size = new System.Drawing.Size(46, 34);
            this.MoveToleftBtn.TabIndex = 2;
            this.MoveToleftBtn.Text = "<<";
            this.MoveToleftBtn.UseVisualStyleBackColor = true;
            // 
            // MoveToRightBtn
            // 
            this.MoveToRightBtn.Location = new System.Drawing.Point(387, 172);
            this.MoveToRightBtn.Name = "MoveToRightBtn";
            this.MoveToRightBtn.Size = new System.Drawing.Size(46, 34);
            this.MoveToRightBtn.TabIndex = 3;
            this.MoveToRightBtn.Text = ">>";
            this.MoveToRightBtn.UseVisualStyleBackColor = true;
            // 
            // CopyToTheOtherSide
            // 
            this.CopyToTheOtherSide.Location = new System.Drawing.Point(279, 326);
            this.CopyToTheOtherSide.Name = "CopyToTheOtherSide";
            this.CopyToTheOtherSide.Size = new System.Drawing.Size(100, 23);
            this.CopyToTheOtherSide.TabIndex = 4;
            this.CopyToTheOtherSide.Text = "Copy";
            this.CopyToTheOtherSide.UseVisualStyleBackColor = true;
            this.CopyToTheOtherSide.Click += new System.EventHandler(this.CopyToTheOtherSide_Click);
            // 
            // DeleteLastSelected
            // 
            this.DeleteLastSelected.Location = new System.Drawing.Point(446, 326);
            this.DeleteLastSelected.Name = "DeleteLastSelected";
            this.DeleteLastSelected.Size = new System.Drawing.Size(100, 23);
            this.DeleteLastSelected.TabIndex = 5;
            this.DeleteLastSelected.Text = "Delete";
            this.DeleteLastSelected.UseVisualStyleBackColor = true;
            this.DeleteLastSelected.Click += new System.EventHandler(this.DeleteLastSelected_Click);
            // 
            // LeftDirectory
            // 
            this.LeftDirectory.Location = new System.Drawing.Point(197, 96);
            this.LeftDirectory.Name = "LeftDirectory";
            this.LeftDirectory.Size = new System.Drawing.Size(153, 24);
            this.LeftDirectory.TabIndex = 6;
            this.LeftDirectory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDownTextBox);
            // 
            // RightDirectory
            // 
            this.RightDirectory.Location = new System.Drawing.Point(469, 96);
            this.RightDirectory.Name = "RightDirectory";
            this.RightDirectory.Size = new System.Drawing.Size(153, 24);
            this.RightDirectory.TabIndex = 7;
            this.RightDirectory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDownTextBox);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RightDirectory);
            this.Controls.Add(this.LeftDirectory);
            this.Controls.Add(this.DeleteLastSelected);
            this.Controls.Add(this.CopyToTheOtherSide);
            this.Controls.Add(this.MoveToRightBtn);
            this.Controls.Add(this.MoveToleftBtn);
            this.Controls.Add(this.RightList);
            this.Controls.Add(this.LeftList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LeftList;
        private System.Windows.Forms.ListBox RightList;
        private System.Windows.Forms.Button MoveToleftBtn;
        private System.Windows.Forms.Button MoveToRightBtn;
        private System.Windows.Forms.Button CopyToTheOtherSide;
        private System.Windows.Forms.Button DeleteLastSelected;
        private System.Windows.Forms.TextBox LeftDirectory;
        private System.Windows.Forms.TextBox RightDirectory;
    }
}

