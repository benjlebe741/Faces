namespace Faces
{
    partial class LevelCreator
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
            this.components = new System.ComponentModel.Container();
            this.SurfaceLightsToggle = new System.Windows.Forms.Label();
            this.RectangleMode = new System.Windows.Forms.Label();
            this.PolygonMode = new System.Windows.Forms.Label();
            this.currentAssetLabel = new System.Windows.Forms.Label();
            this.loadLabel = new System.Windows.Forms.Label();
            this.currentColor = new System.Windows.Forms.Label();
            this.nextColor = new System.Windows.Forms.Label();
            this.LightsToggle = new System.Windows.Forms.Label();
            this.scaleLabel1 = new System.Windows.Forms.Label();
            this.scaleLabel2 = new System.Windows.Forms.Label();
            this.scaleLabel3 = new System.Windows.Forms.Label();
            this.scaleLabel4 = new System.Windows.Forms.Label();
            this.scaleLabel5 = new System.Windows.Forms.Label();
            this.SelectMode = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.scaleLabel6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.regionBackground = new System.Windows.Forms.Label();
            this.regionForeground = new System.Windows.Forms.Label();
            this.regionMidground = new System.Windows.Forms.Label();
            this.regionCollisions = new System.Windows.Forms.Label();
            this.regionArt = new System.Windows.Forms.Label();
            this.describeCurrent = new System.Windows.Forms.Label();
            this.currentLevelLabel = new System.Windows.Forms.Label();
            this.loadLevel = new System.Windows.Forms.Label();
            this.saveLevel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SurfaceLightsToggle
            // 
            this.SurfaceLightsToggle.BackColor = System.Drawing.Color.LightGray;
            this.SurfaceLightsToggle.Location = new System.Drawing.Point(356, 3);
            this.SurfaceLightsToggle.Name = "SurfaceLightsToggle";
            this.SurfaceLightsToggle.Size = new System.Drawing.Size(106, 52);
            this.SurfaceLightsToggle.TabIndex = 26;
            this.SurfaceLightsToggle.Text = "Surface Lights (Frame Drops)";
            this.SurfaceLightsToggle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SurfaceLightsToggle.Click += new System.EventHandler(this.SurfaceLightsToggle_Click);
            // 
            // RectangleMode
            // 
            this.RectangleMode.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RectangleMode.Location = new System.Drawing.Point(3, 117);
            this.RectangleMode.Name = "RectangleMode";
            this.RectangleMode.Size = new System.Drawing.Size(97, 52);
            this.RectangleMode.TabIndex = 25;
            this.RectangleMode.Text = "Rectangle Mode";
            this.RectangleMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RectangleMode.Click += new System.EventHandler(this.RectangleMode_Click);
            // 
            // PolygonMode
            // 
            this.PolygonMode.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PolygonMode.Location = new System.Drawing.Point(3, 58);
            this.PolygonMode.Name = "PolygonMode";
            this.PolygonMode.Size = new System.Drawing.Size(97, 52);
            this.PolygonMode.TabIndex = 24;
            this.PolygonMode.Text = "Polygon Mode";
            this.PolygonMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PolygonMode.Click += new System.EventHandler(this.PolygonMode_Click);
            // 
            // currentAssetLabel
            // 
            this.currentAssetLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.currentAssetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentAssetLabel.Location = new System.Drawing.Point(773, 32);
            this.currentAssetLabel.Name = "currentAssetLabel";
            this.currentAssetLabel.Size = new System.Drawing.Size(82, 25);
            this.currentAssetLabel.TabIndex = 23;
            this.currentAssetLabel.Text = "0";
            this.currentAssetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadLabel
            // 
            this.loadLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.loadLabel.Location = new System.Drawing.Point(861, 32);
            this.loadLabel.Name = "loadLabel";
            this.loadLabel.Size = new System.Drawing.Size(93, 25);
            this.loadLabel.TabIndex = 22;
            this.loadLabel.Text = "Load Asset";
            this.loadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loadLabel.Click += new System.EventHandler(this.loadLabel_Click);
            // 
            // currentColor
            // 
            this.currentColor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.currentColor.ForeColor = System.Drawing.Color.DarkMagenta;
            this.currentColor.Location = new System.Drawing.Point(960, 3);
            this.currentColor.Name = "currentColor";
            this.currentColor.Size = new System.Drawing.Size(117, 52);
            this.currentColor.TabIndex = 20;
            this.currentColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nextColor
            // 
            this.nextColor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.nextColor.Location = new System.Drawing.Point(1083, 3);
            this.nextColor.Name = "nextColor";
            this.nextColor.Size = new System.Drawing.Size(117, 52);
            this.nextColor.TabIndex = 19;
            this.nextColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LightsToggle
            // 
            this.LightsToggle.BackColor = System.Drawing.Color.LightGray;
            this.LightsToggle.Location = new System.Drawing.Point(252, 3);
            this.LightsToggle.Name = "LightsToggle";
            this.LightsToggle.Size = new System.Drawing.Size(98, 52);
            this.LightsToggle.TabIndex = 18;
            this.LightsToggle.Text = "Toggle Lights";
            this.LightsToggle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LightsToggle.Click += new System.EventHandler(this.LightsToggle_Click);
            // 
            // scaleLabel1
            // 
            this.scaleLabel1.BackColor = System.Drawing.Color.RosyBrown;
            this.scaleLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleLabel1.Location = new System.Drawing.Point(1082, 151);
            this.scaleLabel1.Name = "scaleLabel1";
            this.scaleLabel1.Size = new System.Drawing.Size(118, 23);
            this.scaleLabel1.TabIndex = 28;
            this.scaleLabel1.Text = "r: set red";
            this.scaleLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scaleLabel2
            // 
            this.scaleLabel2.BackColor = System.Drawing.Color.RosyBrown;
            this.scaleLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleLabel2.Location = new System.Drawing.Point(1082, 180);
            this.scaleLabel2.Name = "scaleLabel2";
            this.scaleLabel2.Size = new System.Drawing.Size(118, 23);
            this.scaleLabel2.TabIndex = 29;
            this.scaleLabel2.Text = "g: set green";
            this.scaleLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scaleLabel3
            // 
            this.scaleLabel3.BackColor = System.Drawing.Color.RosyBrown;
            this.scaleLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleLabel3.Location = new System.Drawing.Point(1082, 209);
            this.scaleLabel3.Name = "scaleLabel3";
            this.scaleLabel3.Size = new System.Drawing.Size(118, 23);
            this.scaleLabel3.TabIndex = 30;
            this.scaleLabel3.Text = "b: set blue";
            this.scaleLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scaleLabel4
            // 
            this.scaleLabel4.BackColor = System.Drawing.Color.RosyBrown;
            this.scaleLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleLabel4.Location = new System.Drawing.Point(1082, 238);
            this.scaleLabel4.Name = "scaleLabel4";
            this.scaleLabel4.Size = new System.Drawing.Size(118, 23);
            this.scaleLabel4.TabIndex = 31;
            this.scaleLabel4.Text = "a: set \'a\'";
            this.scaleLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scaleLabel5
            // 
            this.scaleLabel5.BackColor = System.Drawing.Color.RosyBrown;
            this.scaleLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleLabel5.Location = new System.Drawing.Point(1082, 268);
            this.scaleLabel5.Name = "scaleLabel5";
            this.scaleLabel5.Size = new System.Drawing.Size(118, 23);
            this.scaleLabel5.TabIndex = 32;
            this.scaleLabel5.Text = "s: scale";
            this.scaleLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectMode
            // 
            this.SelectMode.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SelectMode.Location = new System.Drawing.Point(3, 175);
            this.SelectMode.Name = "SelectMode";
            this.SelectMode.Size = new System.Drawing.Size(97, 52);
            this.SelectMode.TabIndex = 33;
            this.SelectMode.Text = "Select Mode";
            this.SelectMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SelectMode.Click += new System.EventHandler(this.SelectMode_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 10;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // scaleLabel6
            // 
            this.scaleLabel6.BackColor = System.Drawing.Color.RosyBrown;
            this.scaleLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleLabel6.Location = new System.Drawing.Point(1082, 297);
            this.scaleLabel6.Name = "scaleLabel6";
            this.scaleLabel6.Size = new System.Drawing.Size(118, 23);
            this.scaleLabel6.TabIndex = 34;
            this.scaleLabel6.Text = "f: rotate";
            this.scaleLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 52);
            this.label1.TabIndex = 35;
            this.label1.Text = "Menu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // regionBackground
            // 
            this.regionBackground.BackColor = System.Drawing.SystemColors.ControlLight;
            this.regionBackground.Location = new System.Drawing.Point(3, 265);
            this.regionBackground.Name = "regionBackground";
            this.regionBackground.Size = new System.Drawing.Size(97, 24);
            this.regionBackground.TabIndex = 36;
            this.regionBackground.Text = "Background";
            this.regionBackground.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.regionBackground.Click += new System.EventHandler(this.regionBackground_Click);
            // 
            // regionForeground
            // 
            this.regionForeground.BackColor = System.Drawing.SystemColors.ControlLight;
            this.regionForeground.Location = new System.Drawing.Point(3, 327);
            this.regionForeground.Name = "regionForeground";
            this.regionForeground.Size = new System.Drawing.Size(97, 24);
            this.regionForeground.TabIndex = 37;
            this.regionForeground.Text = "Foreground";
            this.regionForeground.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.regionForeground.Click += new System.EventHandler(this.regionForeground_Click);
            // 
            // regionMidground
            // 
            this.regionMidground.BackColor = System.Drawing.SystemColors.ControlLight;
            this.regionMidground.Location = new System.Drawing.Point(3, 296);
            this.regionMidground.Name = "regionMidground";
            this.regionMidground.Size = new System.Drawing.Size(97, 24);
            this.regionMidground.TabIndex = 38;
            this.regionMidground.Text = "Middleground";
            this.regionMidground.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.regionMidground.Click += new System.EventHandler(this.regionMidground_Click);
            // 
            // regionCollisions
            // 
            this.regionCollisions.BackColor = System.Drawing.SystemColors.ControlLight;
            this.regionCollisions.Location = new System.Drawing.Point(3, 409);
            this.regionCollisions.Name = "regionCollisions";
            this.regionCollisions.Size = new System.Drawing.Size(65, 24);
            this.regionCollisions.TabIndex = 41;
            this.regionCollisions.Text = "Collision";
            this.regionCollisions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.regionCollisions.Click += new System.EventHandler(this.regionCollisions_Click);
            // 
            // regionArt
            // 
            this.regionArt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.regionArt.Location = new System.Drawing.Point(3, 376);
            this.regionArt.Name = "regionArt";
            this.regionArt.Size = new System.Drawing.Size(54, 24);
            this.regionArt.TabIndex = 42;
            this.regionArt.Text = "Art";
            this.regionArt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.regionArt.Click += new System.EventHandler(this.regionArt_Click);
            // 
            // describeCurrent
            // 
            this.describeCurrent.BackColor = System.Drawing.Color.RosyBrown;
            this.describeCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.describeCurrent.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.describeCurrent.Location = new System.Drawing.Point(1082, 59);
            this.describeCurrent.Name = "describeCurrent";
            this.describeCurrent.Size = new System.Drawing.Size(118, 86);
            this.describeCurrent.TabIndex = 43;
            this.describeCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentLevelLabel
            // 
            this.currentLevelLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.currentLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentLevelLabel.Location = new System.Drawing.Point(671, 3);
            this.currentLevelLabel.Name = "currentLevelLabel";
            this.currentLevelLabel.Size = new System.Drawing.Size(82, 25);
            this.currentLevelLabel.TabIndex = 45;
            this.currentLevelLabel.Text = "0";
            this.currentLevelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadLevel
            // 
            this.loadLevel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.loadLevel.Location = new System.Drawing.Point(861, 3);
            this.loadLevel.Name = "loadLevel";
            this.loadLevel.Size = new System.Drawing.Size(93, 25);
            this.loadLevel.TabIndex = 44;
            this.loadLevel.Text = "Load Level";
            this.loadLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loadLevel.Click += new System.EventHandler(this.loadLevel_Click);
            // 
            // saveLevel
            // 
            this.saveLevel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.saveLevel.Location = new System.Drawing.Point(759, 3);
            this.saveLevel.Name = "saveLevel";
            this.saveLevel.Size = new System.Drawing.Size(96, 25);
            this.saveLevel.TabIndex = 46;
            this.saveLevel.Text = "Save Level";
            this.saveLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.saveLevel.Click += new System.EventHandler(this.saveLevel_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(468, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 52);
            this.label2.TabIndex = 47;
            this.label2.Text = "Paralax";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // LevelCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saveLevel);
            this.Controls.Add(this.currentLevelLabel);
            this.Controls.Add(this.loadLevel);
            this.Controls.Add(this.describeCurrent);
            this.Controls.Add(this.regionArt);
            this.Controls.Add(this.regionCollisions);
            this.Controls.Add(this.regionMidground);
            this.Controls.Add(this.regionForeground);
            this.Controls.Add(this.regionBackground);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scaleLabel6);
            this.Controls.Add(this.SelectMode);
            this.Controls.Add(this.scaleLabel5);
            this.Controls.Add(this.scaleLabel4);
            this.Controls.Add(this.scaleLabel3);
            this.Controls.Add(this.scaleLabel2);
            this.Controls.Add(this.scaleLabel1);
            this.Controls.Add(this.SurfaceLightsToggle);
            this.Controls.Add(this.RectangleMode);
            this.Controls.Add(this.PolygonMode);
            this.Controls.Add(this.currentAssetLabel);
            this.Controls.Add(this.loadLabel);
            this.Controls.Add(this.currentColor);
            this.Controls.Add(this.nextColor);
            this.Controls.Add(this.LightsToggle);
            this.DoubleBuffered = true;
            this.Name = "LevelCreator";
            this.Size = new System.Drawing.Size(1203, 833);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LevelCreator_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LevelCreator_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LevelCreator_MouseUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.LevelCreator_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label SurfaceLightsToggle;
        private System.Windows.Forms.Label RectangleMode;
        private System.Windows.Forms.Label PolygonMode;
        private System.Windows.Forms.Label currentAssetLabel;
        private System.Windows.Forms.Label loadLabel;
        private System.Windows.Forms.Label currentColor;
        private System.Windows.Forms.Label nextColor;
        private System.Windows.Forms.Label LightsToggle;
        private System.Windows.Forms.Label scaleLabel1;
        private System.Windows.Forms.Label scaleLabel2;
        private System.Windows.Forms.Label scaleLabel3;
        private System.Windows.Forms.Label scaleLabel4;
        private System.Windows.Forms.Label scaleLabel5;
        private System.Windows.Forms.Label SelectMode;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label scaleLabel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label regionBackground;
        private System.Windows.Forms.Label regionForeground;
        private System.Windows.Forms.Label regionMidground;
        private System.Windows.Forms.Label regionCollisions;
        private System.Windows.Forms.Label regionArt;
        private System.Windows.Forms.Label describeCurrent;
        private System.Windows.Forms.Label currentLevelLabel;
        private System.Windows.Forms.Label loadLevel;
        private System.Windows.Forms.Label saveLevel;
        private System.Windows.Forms.Label label2;
    }
}
