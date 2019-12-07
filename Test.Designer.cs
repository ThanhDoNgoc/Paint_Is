namespace Paint
{
    partial class Test
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
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Test));
            this.FileB = new MetroFramework.Controls.MetroButton();
            this.PenB = new MetroFramework.Controls.MetroButton();
            this.UndoB = new MetroFramework.Controls.MetroButton();
            this.RedoB = new MetroFramework.Controls.MetroButton();
            this.ShapesB = new MetroFramework.Controls.MetroButton();
            this.SaveB = new MetroFramework.Controls.MetroButton();
            this.EraserB = new MetroFramework.Controls.MetroButton();
            this.Transition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.fileUC1 = new Paint.FileUC();
            this.penUC1 = new Paint.PenUC();
            this.drawPanel1 = new Paint.DrawPanel();
            this.SuspendLayout();
            // 
            // FileB
            // 
            this.FileB.BackColor = System.Drawing.Color.White;
            this.FileB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Transition1.SetDecoration(this.FileB, BunifuAnimatorNS.DecorationType.None);
            this.FileB.ForeColor = System.Drawing.SystemColors.Control;
            this.FileB.Location = new System.Drawing.Point(0, 7);
            this.FileB.Name = "FileB";
            this.FileB.Size = new System.Drawing.Size(70, 50);
            this.FileB.TabIndex = 10;
            this.FileB.Text = "File";
            this.FileB.UseSelectable = true;
            this.FileB.Click += new System.EventHandler(this.FileB_Click);
            // 
            // PenB
            // 
            this.PenB.BackgroundImage = global::Paint.Properties.Resources._050_pencil;
            this.PenB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Transition1.SetDecoration(this.PenB, BunifuAnimatorNS.DecorationType.None);
            this.PenB.Location = new System.Drawing.Point(473, 7);
            this.PenB.Name = "PenB";
            this.PenB.Size = new System.Drawing.Size(50, 50);
            this.PenB.TabIndex = 9;
            this.PenB.UseSelectable = true;
            this.PenB.Click += new System.EventHandler(this.PenB_Click);
            // 
            // UndoB
            // 
            this.UndoB.BackgroundImage = global::Paint.Properties.Resources.icons8_undo_96;
            this.UndoB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Transition1.SetDecoration(this.UndoB, BunifuAnimatorNS.DecorationType.None);
            this.UndoB.Location = new System.Drawing.Point(247, 7);
            this.UndoB.Name = "UndoB";
            this.UndoB.Size = new System.Drawing.Size(50, 50);
            this.UndoB.TabIndex = 8;
            this.UndoB.UseSelectable = true;
            // 
            // RedoB
            // 
            this.RedoB.BackgroundImage = global::Paint.Properties.Resources.icons8_redo_96;
            this.RedoB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Transition1.SetDecoration(this.RedoB, BunifuAnimatorNS.DecorationType.None);
            this.RedoB.Location = new System.Drawing.Point(303, 7);
            this.RedoB.Name = "RedoB";
            this.RedoB.Size = new System.Drawing.Size(50, 50);
            this.RedoB.TabIndex = 7;
            this.RedoB.UseSelectable = true;
            // 
            // ShapesB
            // 
            this.ShapesB.BackgroundImage = global::Paint.Properties.Resources.star;
            this.ShapesB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Transition1.SetDecoration(this.ShapesB, BunifuAnimatorNS.DecorationType.None);
            this.ShapesB.Location = new System.Drawing.Point(585, 7);
            this.ShapesB.Name = "ShapesB";
            this.ShapesB.Size = new System.Drawing.Size(50, 50);
            this.ShapesB.TabIndex = 6;
            this.ShapesB.UseSelectable = true;
            // 
            // SaveB
            // 
            this.SaveB.BackgroundImage = global::Paint.Properties.Resources.save;
            this.SaveB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Transition1.SetDecoration(this.SaveB, BunifuAnimatorNS.DecorationType.None);
            this.SaveB.Location = new System.Drawing.Point(85, 7);
            this.SaveB.Name = "SaveB";
            this.SaveB.Size = new System.Drawing.Size(50, 50);
            this.SaveB.TabIndex = 5;
            this.SaveB.UseSelectable = true;
            // 
            // EraserB
            // 
            this.EraserB.BackgroundImage = global::Paint.Properties.Resources._027_eraser;
            this.EraserB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Transition1.SetDecoration(this.EraserB, BunifuAnimatorNS.DecorationType.None);
            this.EraserB.Location = new System.Drawing.Point(529, 7);
            this.EraserB.Name = "EraserB";
            this.EraserB.Size = new System.Drawing.Size(50, 50);
            this.EraserB.TabIndex = 3;
            this.EraserB.UseSelectable = true;
            this.EraserB.Click += new System.EventHandler(this.EraserB_Click_1);
            // 
            // Transition1
            // 
            this.Transition1.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide;
            this.Transition1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.Transition1.DefaultAnimation = animation1;
            // 
            // fileUC1
            // 
            this.Transition1.SetDecoration(this.fileUC1, BunifuAnimatorNS.DecorationType.None);
            this.fileUC1.Location = new System.Drawing.Point(0, 66);
            this.fileUC1.Name = "fileUC1";
            this.fileUC1.Size = new System.Drawing.Size(220, 500);
            this.fileUC1.TabIndex = 1;
            // 
            // penUC1
            // 
            this.Transition1.SetDecoration(this.penUC1, BunifuAnimatorNS.DecorationType.None);
            this.penUC1.Location = new System.Drawing.Point(0, 63);
            this.penUC1.Name = "penUC1";
            this.penUC1.Size = new System.Drawing.Size(220, 500);
            this.penUC1.TabIndex = 2;
            // 
            // drawPanel1
            // 
            this.Transition1.SetDecoration(this.drawPanel1, BunifuAnimatorNS.DecorationType.None);
            this.drawPanel1.Location = new System.Drawing.Point(247, 63);
            this.drawPanel1.Name = "drawPanel1";
            this.drawPanel1.Size = new System.Drawing.Size(1020, 500);
            this.drawPanel1.TabIndex = 0;
            this.drawPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.drawPanel1_Paint);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 589);
            this.Controls.Add(this.fileUC1);
            this.Controls.Add(this.penUC1);
            this.Controls.Add(this.FileB);
            this.Controls.Add(this.PenB);
            this.Controls.Add(this.UndoB);
            this.Controls.Add(this.RedoB);
            this.Controls.Add(this.ShapesB);
            this.Controls.Add(this.SaveB);
            this.Controls.Add(this.EraserB);
            this.Controls.Add(this.drawPanel1);
            this.Transition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Name = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private DrawPanel drawPanel1;
        private MetroFramework.Controls.MetroButton EraserB;
        private MetroFramework.Controls.MetroButton SaveB;
        private MetroFramework.Controls.MetroButton ShapesB;
        private MetroFramework.Controls.MetroButton RedoB;
        private MetroFramework.Controls.MetroButton UndoB;
        private MetroFramework.Controls.MetroButton PenB;
        private MetroFramework.Controls.MetroButton FileB;
        private BunifuAnimatorNS.BunifuTransition Transition1;
        private FileUC fileUC1;
        private PenUC penUC1;
    }
}