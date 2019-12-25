namespace Paint
{
    partial class FileUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SaveAsB = new MetroFramework.Controls.MetroButton();
            this.SaveB2 = new MetroFramework.Controls.MetroButton();
            this.OpenB = new MetroFramework.Controls.MetroButton();
            this.NewB = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // SaveAsB
            // 
            this.SaveAsB.Location = new System.Drawing.Point(4, 222);
            this.SaveAsB.Margin = new System.Windows.Forms.Padding(4);
            this.SaveAsB.Name = "SaveAsB";
            this.SaveAsB.Size = new System.Drawing.Size(285, 65);
            this.SaveAsB.TabIndex = 7;
            this.SaveAsB.Text = "Save as....";
            this.SaveAsB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveAsB.UseSelectable = true;
            this.SaveAsB.Click += new System.EventHandler(this.SaveAsB_Click);
            // 
            // SaveB2
            // 
            this.SaveB2.Location = new System.Drawing.Point(4, 149);
            this.SaveB2.Margin = new System.Windows.Forms.Padding(4);
            this.SaveB2.Name = "SaveB2";
            this.SaveB2.Size = new System.Drawing.Size(285, 65);
            this.SaveB2.TabIndex = 6;
            this.SaveB2.Text = "Save";
            this.SaveB2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveB2.UseSelectable = true;
            this.SaveB2.Click += new System.EventHandler(this.SaveB2_Click);
            // 
            // OpenB
            // 
            this.OpenB.Location = new System.Drawing.Point(4, 76);
            this.OpenB.Margin = new System.Windows.Forms.Padding(4);
            this.OpenB.Name = "OpenB";
            this.OpenB.Size = new System.Drawing.Size(285, 65);
            this.OpenB.TabIndex = 5;
            this.OpenB.Text = "Open";
            this.OpenB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OpenB.UseSelectable = true;
            this.OpenB.Click += new System.EventHandler(this.OpenB_Click);
            // 
            // NewB
            // 
            this.NewB.Location = new System.Drawing.Point(4, 4);
            this.NewB.Margin = new System.Windows.Forms.Padding(4);
            this.NewB.Name = "NewB";
            this.NewB.Size = new System.Drawing.Size(285, 65);
            this.NewB.TabIndex = 4;
            this.NewB.Text = "New";
            this.NewB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NewB.UseSelectable = true;
            this.NewB.Click += new System.EventHandler(this.NewB_Click);
            // 
            // FileUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SaveAsB);
            this.Controls.Add(this.SaveB2);
            this.Controls.Add(this.OpenB);
            this.Controls.Add(this.NewB);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FileUC";
            this.Size = new System.Drawing.Size(293, 615);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton SaveAsB;
        private MetroFramework.Controls.MetroButton SaveB2;
        private MetroFramework.Controls.MetroButton OpenB;
        private MetroFramework.Controls.MetroButton NewB;
    }
}
