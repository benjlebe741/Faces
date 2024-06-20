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
            this.surfaceLightsToggleLabel = new System.Windows.Forms.Label();
            this.rectangleModeLabel = new System.Windows.Forms.Label();
            this.polygonModeLabel = new System.Windows.Forms.Label();
            this.currentAssetLabel = new System.Windows.Forms.Label();
            this.loadAssetLabel = new System.Windows.Forms.Label();
            this.currentColorLabel = new System.Windows.Forms.Label();
            this.nextColorLabel = new System.Windows.Forms.Label();
            this.lightsToggleLabel = new System.Windows.Forms.Label();
            this.selectModeLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.menuLabel = new System.Windows.Forms.Label();
            this.collisionsLabel = new System.Windows.Forms.Label();
            this.artLabel = new System.Windows.Forms.Label();
            this.currentLevelLabel = new System.Windows.Forms.Label();
            this.loadLevelLabel = new System.Windows.Forms.Label();
            this.saveLevelLabel = new System.Windows.Forms.Label();
            this.paralaxLabel = new System.Windows.Forms.Label();
            this.planeCountLabel = new System.Windows.Forms.Label();
            this.currentPlaneLabel = new System.Windows.Forms.Label();
            this.outlineLabel = new System.Windows.Forms.Label();
            this.fadeColorLabel = new System.Windows.Forms.Label();
            this.screenBoundsLabel = new System.Windows.Forms.Label();
            this.toggleHelpLabel = new System.Windows.Forms.Label();
            this.helpTextLabel2 = new System.Windows.Forms.Label();
            this.helpTextLabel = new System.Windows.Forms.Label();
            this.helpTextLabel3 = new System.Windows.Forms.Label();
            this.helpTextLabel4 = new System.Windows.Forms.Label();
            this.helpTextLabel10 = new System.Windows.Forms.Label();
            this.helpTextLabel9 = new System.Windows.Forms.Label();
            this.helpTextLabel12 = new System.Windows.Forms.Label();
            this.helpTextLabel11 = new System.Windows.Forms.Label();
            this.helpTextLabel13 = new System.Windows.Forms.Label();
            this.helpTextLabel14 = new System.Windows.Forms.Label();
            this.helpTextLabel5 = new System.Windows.Forms.Label();
            this.helpTextLabel7 = new System.Windows.Forms.Label();
            this.helpTextLabel8 = new System.Windows.Forms.Label();
            this.setPlayerPlaneLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // surfaceLightsToggleLabel
            // 
            this.surfaceLightsToggleLabel.BackColor = System.Drawing.Color.LightGray;
            this.surfaceLightsToggleLabel.Location = new System.Drawing.Point(356, 3);
            this.surfaceLightsToggleLabel.Name = "surfaceLightsToggleLabel";
            this.surfaceLightsToggleLabel.Size = new System.Drawing.Size(106, 52);
            this.surfaceLightsToggleLabel.TabIndex = 26;
            this.surfaceLightsToggleLabel.Text = "Surface Lights (Frame Drops)";
            this.surfaceLightsToggleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.surfaceLightsToggleLabel.Click += new System.EventHandler(this.SurfaceLightsToggle_Click);
            // 
            // rectangleModeLabel
            // 
            this.rectangleModeLabel.BackColor = System.Drawing.Color.SlateGray;
            this.rectangleModeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rectangleModeLabel.Location = new System.Drawing.Point(3, 117);
            this.rectangleModeLabel.Name = "rectangleModeLabel";
            this.rectangleModeLabel.Size = new System.Drawing.Size(97, 52);
            this.rectangleModeLabel.TabIndex = 25;
            this.rectangleModeLabel.Text = "Rectangle Mode";
            this.rectangleModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rectangleModeLabel.Click += new System.EventHandler(this.RectangleMode_Click);
            // 
            // polygonModeLabel
            // 
            this.polygonModeLabel.BackColor = System.Drawing.Color.SlateGray;
            this.polygonModeLabel.Location = new System.Drawing.Point(3, 58);
            this.polygonModeLabel.Name = "polygonModeLabel";
            this.polygonModeLabel.Size = new System.Drawing.Size(97, 52);
            this.polygonModeLabel.TabIndex = 24;
            this.polygonModeLabel.Text = "Polygon Mode";
            this.polygonModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.polygonModeLabel.Click += new System.EventHandler(this.PolygonMode_Click);
            // 
            // currentAssetLabel
            // 
            this.currentAssetLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.currentAssetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentAssetLabel.Location = new System.Drawing.Point(1085, 32);
            this.currentAssetLabel.Name = "currentAssetLabel";
            this.currentAssetLabel.Size = new System.Drawing.Size(82, 25);
            this.currentAssetLabel.TabIndex = 23;
            this.currentAssetLabel.Text = "0";
            this.currentAssetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadAssetLabel
            // 
            this.loadAssetLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.loadAssetLabel.Location = new System.Drawing.Point(1173, 32);
            this.loadAssetLabel.Name = "loadAssetLabel";
            this.loadAssetLabel.Size = new System.Drawing.Size(93, 25);
            this.loadAssetLabel.TabIndex = 22;
            this.loadAssetLabel.Text = "Load Asset";
            this.loadAssetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loadAssetLabel.Click += new System.EventHandler(this.loadLabel_Click);
            // 
            // currentColorLabel
            // 
            this.currentColorLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.currentColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentColorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.currentColorLabel.Location = new System.Drawing.Point(1272, 3);
            this.currentColorLabel.Name = "currentColorLabel";
            this.currentColorLabel.Size = new System.Drawing.Size(117, 52);
            this.currentColorLabel.TabIndex = 20;
            this.currentColorLabel.Text = "Current Color";
            this.currentColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nextColorLabel
            // 
            this.nextColorLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.nextColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextColorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.nextColorLabel.Location = new System.Drawing.Point(1395, 3);
            this.nextColorLabel.Name = "nextColorLabel";
            this.nextColorLabel.Size = new System.Drawing.Size(117, 52);
            this.nextColorLabel.TabIndex = 19;
            this.nextColorLabel.Text = "Next Color";
            this.nextColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lightsToggleLabel
            // 
            this.lightsToggleLabel.BackColor = System.Drawing.Color.White;
            this.lightsToggleLabel.Location = new System.Drawing.Point(252, 3);
            this.lightsToggleLabel.Name = "lightsToggleLabel";
            this.lightsToggleLabel.Size = new System.Drawing.Size(98, 52);
            this.lightsToggleLabel.TabIndex = 18;
            this.lightsToggleLabel.Text = "Toggle Lights";
            this.lightsToggleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lightsToggleLabel.Click += new System.EventHandler(this.LightsToggle_Click);
            // 
            // selectModeLabel
            // 
            this.selectModeLabel.BackColor = System.Drawing.Color.SlateGray;
            this.selectModeLabel.Location = new System.Drawing.Point(3, 175);
            this.selectModeLabel.Name = "selectModeLabel";
            this.selectModeLabel.Size = new System.Drawing.Size(97, 52);
            this.selectModeLabel.TabIndex = 33;
            this.selectModeLabel.Text = "Select Mode";
            this.selectModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.selectModeLabel.Click += new System.EventHandler(this.SelectMode_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 10;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // menuLabel
            // 
            this.menuLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuLabel.Location = new System.Drawing.Point(3, 3);
            this.menuLabel.Name = "menuLabel";
            this.menuLabel.Size = new System.Drawing.Size(243, 52);
            this.menuLabel.TabIndex = 35;
            this.menuLabel.Text = "Menu";
            this.menuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.menuLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // collisionsLabel
            // 
            this.collisionsLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.collisionsLabel.Location = new System.Drawing.Point(3, 424);
            this.collisionsLabel.Name = "collisionsLabel";
            this.collisionsLabel.Size = new System.Drawing.Size(65, 24);
            this.collisionsLabel.TabIndex = 41;
            this.collisionsLabel.Text = "Collision";
            this.collisionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.collisionsLabel.Click += new System.EventHandler(this.regionCollisions_Click);
            // 
            // artLabel
            // 
            this.artLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.artLabel.Location = new System.Drawing.Point(3, 391);
            this.artLabel.Name = "artLabel";
            this.artLabel.Size = new System.Drawing.Size(54, 24);
            this.artLabel.TabIndex = 42;
            this.artLabel.Text = "Art";
            this.artLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.artLabel.Click += new System.EventHandler(this.regionArt_Click);
            // 
            // currentLevelLabel
            // 
            this.currentLevelLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.currentLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentLevelLabel.Location = new System.Drawing.Point(983, 3);
            this.currentLevelLabel.Name = "currentLevelLabel";
            this.currentLevelLabel.Size = new System.Drawing.Size(82, 25);
            this.currentLevelLabel.TabIndex = 45;
            this.currentLevelLabel.Text = "0";
            this.currentLevelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadLevelLabel
            // 
            this.loadLevelLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.loadLevelLabel.Location = new System.Drawing.Point(1173, 3);
            this.loadLevelLabel.Name = "loadLevelLabel";
            this.loadLevelLabel.Size = new System.Drawing.Size(93, 25);
            this.loadLevelLabel.TabIndex = 44;
            this.loadLevelLabel.Text = "Load Level";
            this.loadLevelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loadLevelLabel.Click += new System.EventHandler(this.loadLevel_Click);
            // 
            // saveLevelLabel
            // 
            this.saveLevelLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.saveLevelLabel.Location = new System.Drawing.Point(1071, 3);
            this.saveLevelLabel.Name = "saveLevelLabel";
            this.saveLevelLabel.Size = new System.Drawing.Size(96, 25);
            this.saveLevelLabel.TabIndex = 46;
            this.saveLevelLabel.Text = "Save Level";
            this.saveLevelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.saveLevelLabel.Click += new System.EventHandler(this.saveLevel_Click);
            // 
            // paralaxLabel
            // 
            this.paralaxLabel.BackColor = System.Drawing.Color.LightGray;
            this.paralaxLabel.Location = new System.Drawing.Point(468, 3);
            this.paralaxLabel.Name = "paralaxLabel";
            this.paralaxLabel.Size = new System.Drawing.Size(92, 28);
            this.paralaxLabel.TabIndex = 47;
            this.paralaxLabel.Text = "Paralax";
            this.paralaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.paralaxLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // planeCountLabel
            // 
            this.planeCountLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.planeCountLabel.Location = new System.Drawing.Point(3, 235);
            this.planeCountLabel.Name = "planeCountLabel";
            this.planeCountLabel.Size = new System.Drawing.Size(115, 24);
            this.planeCountLabel.TabIndex = 48;
            this.planeCountLabel.Text = "Planes:";
            this.planeCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // currentPlaneLabel
            // 
            this.currentPlaneLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.currentPlaneLabel.Location = new System.Drawing.Point(3, 267);
            this.currentPlaneLabel.Name = "currentPlaneLabel";
            this.currentPlaneLabel.Size = new System.Drawing.Size(115, 24);
            this.currentPlaneLabel.TabIndex = 49;
            this.currentPlaneLabel.Text = "CurrentPlane:";
            this.currentPlaneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outlineLabel
            // 
            this.outlineLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.outlineLabel.Location = new System.Drawing.Point(468, 35);
            this.outlineLabel.Name = "outlineLabel";
            this.outlineLabel.Size = new System.Drawing.Size(92, 20);
            this.outlineLabel.TabIndex = 50;
            this.outlineLabel.Text = "Outline";
            this.outlineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.outlineLabel.Click += new System.EventHandler(this.outlineLable_Click);
            // 
            // fadeColorLabel
            // 
            this.fadeColorLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.fadeColorLabel.Location = new System.Drawing.Point(566, 35);
            this.fadeColorLabel.Name = "fadeColorLabel";
            this.fadeColorLabel.Size = new System.Drawing.Size(116, 20);
            this.fadeColorLabel.TabIndex = 51;
            this.fadeColorLabel.Text = "Set Fade Color";
            this.fadeColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fadeColorLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // screenBoundsLabel
            // 
            this.screenBoundsLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.screenBoundsLabel.Location = new System.Drawing.Point(3, 457);
            this.screenBoundsLabel.Name = "screenBoundsLabel";
            this.screenBoundsLabel.Size = new System.Drawing.Size(115, 24);
            this.screenBoundsLabel.TabIndex = 52;
            this.screenBoundsLabel.Text = "Screen Bounds";
            this.screenBoundsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.screenBoundsLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // toggleHelpLabel
            // 
            this.toggleHelpLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toggleHelpLabel.Location = new System.Drawing.Point(4, 517);
            this.toggleHelpLabel.Name = "toggleHelpLabel";
            this.toggleHelpLabel.Size = new System.Drawing.Size(98, 40);
            this.toggleHelpLabel.TabIndex = 53;
            this.toggleHelpLabel.Text = "Toggle Help Text";
            this.toggleHelpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toggleHelpLabel.Click += new System.EventHandler(this.toggleHelpLabel_Click);
            // 
            // helpTextLabel2
            // 
            this.helpTextLabel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel2.Location = new System.Drawing.Point(1272, 59);
            this.helpTextLabel2.Name = "helpTextLabel2";
            this.helpTextLabel2.Size = new System.Drawing.Size(240, 68);
            this.helpTextLabel2.TabIndex = 55;
            this.helpTextLabel2.Text = "Change color with the \'r, g, b\' keys. Color depends on your cursors x coordinate";
            this.helpTextLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel
            // 
            this.helpTextLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel.Location = new System.Drawing.Point(3, 764);
            this.helpTextLabel.Name = "helpTextLabel";
            this.helpTextLabel.Size = new System.Drawing.Size(509, 32);
            this.helpTextLabel.TabIndex = 54;
            this.helpTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel3
            // 
            this.helpTextLabel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel3.Location = new System.Drawing.Point(518, 764);
            this.helpTextLabel3.Name = "helpTextLabel3";
            this.helpTextLabel3.Size = new System.Drawing.Size(1013, 32);
            this.helpTextLabel3.TabIndex = 56;
            this.helpTextLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel4
            // 
            this.helpTextLabel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel4.Location = new System.Drawing.Point(124, 235);
            this.helpTextLabel4.Name = "helpTextLabel4";
            this.helpTextLabel4.Size = new System.Drawing.Size(122, 66);
            this.helpTextLabel4.TabIndex = 57;
            this.helpTextLabel4.Text = "\' ~ \' Key to move through planes. \' + \' Key to add new plane";
            this.helpTextLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel10
            // 
            this.helpTextLabel10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel10.Location = new System.Drawing.Point(252, 58);
            this.helpTextLabel10.Name = "helpTextLabel10";
            this.helpTextLabel10.Size = new System.Drawing.Size(210, 32);
            this.helpTextLabel10.TabIndex = 58;
            this.helpTextLabel10.Text = "Toggle between Flat colors, and colors changed from lights";
            this.helpTextLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel9
            // 
            this.helpTextLabel9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel9.Location = new System.Drawing.Point(106, 58);
            this.helpTextLabel9.Name = "helpTextLabel9";
            this.helpTextLabel9.Size = new System.Drawing.Size(140, 52);
            this.helpTextLabel9.TabIndex = 59;
            this.helpTextLabel9.Text = "\' Y \' Key to add light of Current Color on Current Plane";
            this.helpTextLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel12
            // 
            this.helpTextLabel12.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel12.Location = new System.Drawing.Point(566, 3);
            this.helpTextLabel12.Name = "helpTextLabel12";
            this.helpTextLabel12.Size = new System.Drawing.Size(396, 28);
            this.helpTextLabel12.TabIndex = 60;
            this.helpTextLabel12.Text = "Paralax shows in game perspective, not advised for editing";
            this.helpTextLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel11
            // 
            this.helpTextLabel11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel11.Location = new System.Drawing.Point(468, 58);
            this.helpTextLabel11.Name = "helpTextLabel11";
            this.helpTextLabel11.Size = new System.Drawing.Size(123, 32);
            this.helpTextLabel11.TabIndex = 61;
            this.helpTextLabel11.Text = "Outlines faces on your current layer";
            this.helpTextLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel13
            // 
            this.helpTextLabel13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel13.Location = new System.Drawing.Point(688, 35);
            this.helpTextLabel13.Name = "helpTextLabel13";
            this.helpTextLabel13.Size = new System.Drawing.Size(274, 20);
            this.helpTextLabel13.TabIndex = 62;
            this.helpTextLabel13.Text = "Set Background Fade to Current Color";
            this.helpTextLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel14
            // 
            this.helpTextLabel14.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel14.Location = new System.Drawing.Point(985, 59);
            this.helpTextLabel14.Name = "helpTextLabel14";
            this.helpTextLabel14.Size = new System.Drawing.Size(281, 32);
            this.helpTextLabel14.TabIndex = 63;
            this.helpTextLabel14.Text = "Up - Down arrows to move between different levels and assets";
            this.helpTextLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel5
            // 
            this.helpTextLabel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel5.Location = new System.Drawing.Point(63, 391);
            this.helpTextLabel5.Name = "helpTextLabel5";
            this.helpTextLabel5.Size = new System.Drawing.Size(122, 24);
            this.helpTextLabel5.TabIndex = 64;
            this.helpTextLabel5.Text = "Art / Assets";
            this.helpTextLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel7
            // 
            this.helpTextLabel7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel7.Location = new System.Drawing.Point(74, 424);
            this.helpTextLabel7.Name = "helpTextLabel7";
            this.helpTextLabel7.Size = new System.Drawing.Size(172, 24);
            this.helpTextLabel7.TabIndex = 65;
            this.helpTextLabel7.Text = "Collisions for the player";
            this.helpTextLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel8
            // 
            this.helpTextLabel8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel8.Location = new System.Drawing.Point(124, 457);
            this.helpTextLabel8.Name = "helpTextLabel8";
            this.helpTextLabel8.Size = new System.Drawing.Size(322, 24);
            this.helpTextLabel8.TabIndex = 66;
            this.helpTextLabel8.Text = "The bounds of where the camera can be inside";
            this.helpTextLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // setPlayerPlaneLabel
            // 
            this.setPlayerPlaneLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.setPlayerPlaneLabel.Location = new System.Drawing.Point(3, 302);
            this.setPlayerPlaneLabel.Name = "setPlayerPlaneLabel";
            this.setPlayerPlaneLabel.Size = new System.Drawing.Size(122, 20);
            this.setPlayerPlaneLabel.TabIndex = 67;
            this.setPlayerPlaneLabel.Text = "Set Player Plane";
            this.setPlayerPlaneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.setPlayerPlaneLabel.Click += new System.EventHandler(this.setPlayerPlaneLabel_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(4, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 38);
            this.label6.TabIndex = 68;
            this.label6.Text = "Sets the current plane you are on to contain the player";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LevelCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.setPlayerPlaneLabel);
            this.Controls.Add(this.helpTextLabel8);
            this.Controls.Add(this.helpTextLabel7);
            this.Controls.Add(this.helpTextLabel5);
            this.Controls.Add(this.helpTextLabel14);
            this.Controls.Add(this.helpTextLabel13);
            this.Controls.Add(this.helpTextLabel11);
            this.Controls.Add(this.helpTextLabel12);
            this.Controls.Add(this.helpTextLabel9);
            this.Controls.Add(this.helpTextLabel10);
            this.Controls.Add(this.helpTextLabel4);
            this.Controls.Add(this.helpTextLabel3);
            this.Controls.Add(this.helpTextLabel2);
            this.Controls.Add(this.helpTextLabel);
            this.Controls.Add(this.toggleHelpLabel);
            this.Controls.Add(this.screenBoundsLabel);
            this.Controls.Add(this.fadeColorLabel);
            this.Controls.Add(this.outlineLabel);
            this.Controls.Add(this.currentPlaneLabel);
            this.Controls.Add(this.planeCountLabel);
            this.Controls.Add(this.paralaxLabel);
            this.Controls.Add(this.saveLevelLabel);
            this.Controls.Add(this.currentLevelLabel);
            this.Controls.Add(this.loadLevelLabel);
            this.Controls.Add(this.artLabel);
            this.Controls.Add(this.collisionsLabel);
            this.Controls.Add(this.menuLabel);
            this.Controls.Add(this.selectModeLabel);
            this.Controls.Add(this.surfaceLightsToggleLabel);
            this.Controls.Add(this.rectangleModeLabel);
            this.Controls.Add(this.polygonModeLabel);
            this.Controls.Add(this.currentAssetLabel);
            this.Controls.Add(this.loadAssetLabel);
            this.Controls.Add(this.currentColorLabel);
            this.Controls.Add(this.nextColorLabel);
            this.Controls.Add(this.lightsToggleLabel);
            this.DoubleBuffered = true;
            this.Name = "LevelCreator";
            this.Size = new System.Drawing.Size(1534, 796);
            this.Load += new System.EventHandler(this.LevelCreator_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LevelCreator_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LevelCreator_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LevelCreator_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LevelCreator_MouseUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.LevelCreator_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label surfaceLightsToggleLabel;
        private System.Windows.Forms.Label rectangleModeLabel;
        private System.Windows.Forms.Label polygonModeLabel;
        private System.Windows.Forms.Label currentAssetLabel;
        private System.Windows.Forms.Label loadAssetLabel;
        private System.Windows.Forms.Label currentColorLabel;
        private System.Windows.Forms.Label nextColorLabel;
        private System.Windows.Forms.Label lightsToggleLabel;
        private System.Windows.Forms.Label selectModeLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label menuLabel;
        private System.Windows.Forms.Label collisionsLabel;
        private System.Windows.Forms.Label artLabel;
        private System.Windows.Forms.Label currentLevelLabel;
        private System.Windows.Forms.Label loadLevelLabel;
        private System.Windows.Forms.Label saveLevelLabel;
        private System.Windows.Forms.Label paralaxLabel;
        private System.Windows.Forms.Label planeCountLabel;
        private System.Windows.Forms.Label currentPlaneLabel;
        private System.Windows.Forms.Label outlineLabel;
        private System.Windows.Forms.Label fadeColorLabel;
        private System.Windows.Forms.Label screenBoundsLabel;
        private System.Windows.Forms.Label toggleHelpLabel;
        private System.Windows.Forms.Label helpTextLabel2;
        private System.Windows.Forms.Label helpTextLabel;
        private System.Windows.Forms.Label helpTextLabel3;
        private System.Windows.Forms.Label helpTextLabel4;
        private System.Windows.Forms.Label helpTextLabel10;
        private System.Windows.Forms.Label helpTextLabel9;
        private System.Windows.Forms.Label helpTextLabel12;
        private System.Windows.Forms.Label helpTextLabel11;
        private System.Windows.Forms.Label helpTextLabel13;
        private System.Windows.Forms.Label helpTextLabel14;
        private System.Windows.Forms.Label helpTextLabel5;
        private System.Windows.Forms.Label helpTextLabel7;
        private System.Windows.Forms.Label helpTextLabel8;
        private System.Windows.Forms.Label setPlayerPlaneLabel;
        private System.Windows.Forms.Label label6;
    }
}
