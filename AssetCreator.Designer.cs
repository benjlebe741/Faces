namespace Faces
{
    partial class AssetCreator
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuLabel = new System.Windows.Forms.Label();
            this.toggleLightsLabel = new System.Windows.Forms.Label();
            this.nextColor = new System.Windows.Forms.Label();
            this.currentColor = new System.Windows.Forms.Label();
            this.saveLabel = new System.Windows.Forms.Label();
            this.loadLabel = new System.Windows.Forms.Label();
            this.currentAssetLabel = new System.Windows.Forms.Label();
            this.polygonModeLabel = new System.Windows.Forms.Label();
            this.rectangleModeLabel = new System.Windows.Forms.Label();
            this.surfaceLightsLabel = new System.Windows.Forms.Label();
            this.helpTextLabel = new System.Windows.Forms.Label();
            this.helpTextLabel2 = new System.Windows.Forms.Label();
            this.helpTextLabel3 = new System.Windows.Forms.Label();
            this.helpTextLabel4 = new System.Windows.Forms.Label();
            this.toggleHelpLabel = new System.Windows.Forms.Label();
            this.helpTextLabel5 = new System.Windows.Forms.Label();
            this.helpTextLabel7 = new System.Windows.Forms.Label();
            this.helpTextLabel8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuLabel
            // 
            this.menuLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuLabel.Location = new System.Drawing.Point(3, 3);
            this.menuLabel.Name = "menuLabel";
            this.menuLabel.Size = new System.Drawing.Size(243, 52);
            this.menuLabel.TabIndex = 7;
            this.menuLabel.Text = "Menu";
            this.menuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.menuLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // toggleLightsLabel
            // 
            this.toggleLightsLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toggleLightsLabel.Location = new System.Drawing.Point(252, 3);
            this.toggleLightsLabel.Name = "toggleLightsLabel";
            this.toggleLightsLabel.Size = new System.Drawing.Size(98, 52);
            this.toggleLightsLabel.TabIndex = 8;
            this.toggleLightsLabel.Text = "Toggle Lights";
            this.toggleLightsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toggleLightsLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // nextColor
            // 
            this.nextColor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.nextColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.nextColor.Location = new System.Drawing.Point(902, 3);
            this.nextColor.Name = "nextColor";
            this.nextColor.Size = new System.Drawing.Size(117, 52);
            this.nextColor.TabIndex = 10;
            this.nextColor.Text = "Next Color RGB Value";
            this.nextColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentColor
            // 
            this.currentColor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.currentColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.currentColor.Location = new System.Drawing.Point(779, 3);
            this.currentColor.Name = "currentColor";
            this.currentColor.Size = new System.Drawing.Size(117, 52);
            this.currentColor.TabIndex = 11;
            this.currentColor.Text = "Current Color";
            this.currentColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveLabel
            // 
            this.saveLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.saveLabel.Location = new System.Drawing.Point(581, 3);
            this.saveLabel.Name = "saveLabel";
            this.saveLabel.Size = new System.Drawing.Size(93, 52);
            this.saveLabel.TabIndex = 12;
            this.saveLabel.Text = "Save Asset";
            this.saveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.saveLabel.Click += new System.EventHandler(this.saveLabel_Click);
            // 
            // loadLabel
            // 
            this.loadLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.loadLabel.Location = new System.Drawing.Point(680, 3);
            this.loadLabel.Name = "loadLabel";
            this.loadLabel.Size = new System.Drawing.Size(93, 52);
            this.loadLabel.TabIndex = 13;
            this.loadLabel.Text = "Load Asset";
            this.loadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loadLabel.Click += new System.EventHandler(this.loadLabel_Click);
            // 
            // currentAssetLabel
            // 
            this.currentAssetLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.currentAssetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentAssetLabel.Location = new System.Drawing.Point(493, 3);
            this.currentAssetLabel.Name = "currentAssetLabel";
            this.currentAssetLabel.Size = new System.Drawing.Size(82, 52);
            this.currentAssetLabel.TabIndex = 14;
            this.currentAssetLabel.Text = "0";
            this.currentAssetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.currentAssetLabel.Click += new System.EventHandler(this.currentAssetLabel_Click);
            // 
            // polygonModeLabel
            // 
            this.polygonModeLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.polygonModeLabel.Location = new System.Drawing.Point(3, 64);
            this.polygonModeLabel.Name = "polygonModeLabel";
            this.polygonModeLabel.Size = new System.Drawing.Size(97, 52);
            this.polygonModeLabel.TabIndex = 15;
            this.polygonModeLabel.Text = "Polygon Mode";
            this.polygonModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.polygonModeLabel.Click += new System.EventHandler(this.PolygoneMode_Click);
            // 
            // rectangleModeLabel
            // 
            this.rectangleModeLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rectangleModeLabel.Location = new System.Drawing.Point(3, 125);
            this.rectangleModeLabel.Name = "rectangleModeLabel";
            this.rectangleModeLabel.Size = new System.Drawing.Size(97, 52);
            this.rectangleModeLabel.TabIndex = 16;
            this.rectangleModeLabel.Text = "Rectangle Mode";
            this.rectangleModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rectangleModeLabel.Click += new System.EventHandler(this.RectangleMode_Click);
            // 
            // surfaceLightsLabel
            // 
            this.surfaceLightsLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.surfaceLightsLabel.Location = new System.Drawing.Point(356, 3);
            this.surfaceLightsLabel.Name = "surfaceLightsLabel";
            this.surfaceLightsLabel.Size = new System.Drawing.Size(106, 52);
            this.surfaceLightsLabel.TabIndex = 17;
            this.surfaceLightsLabel.Text = "Surface Lights (Frame Drops)";
            this.surfaceLightsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.surfaceLightsLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // helpTextLabel
            // 
            this.helpTextLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel.Location = new System.Drawing.Point(0, 678);
            this.helpTextLabel.Name = "helpTextLabel";
            this.helpTextLabel.Size = new System.Drawing.Size(509, 32);
            this.helpTextLabel.TabIndex = 18;
            this.helpTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel2
            // 
            this.helpTextLabel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel2.Location = new System.Drawing.Point(513, 678);
            this.helpTextLabel2.Name = "helpTextLabel2";
            this.helpTextLabel2.Size = new System.Drawing.Size(509, 32);
            this.helpTextLabel2.TabIndex = 19;
            this.helpTextLabel2.Text = "Change color with the \'r, g, b\' keys. Color depends on your cursors x coordinate";
            this.helpTextLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel3
            // 
            this.helpTextLabel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel3.Location = new System.Drawing.Point(680, 55);
            this.helpTextLabel3.Name = "helpTextLabel3";
            this.helpTextLabel3.Size = new System.Drawing.Size(194, 61);
            this.helpTextLabel3.TabIndex = 20;
            this.helpTextLabel3.Text = "\'Y\' key to add a static light to the screen (at your cursor). \'X\' key to clear al" +
    "l lights";
            this.helpTextLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel4
            // 
            this.helpTextLabel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel4.Location = new System.Drawing.Point(492, 55);
            this.helpTextLabel4.Name = "helpTextLabel4";
            this.helpTextLabel4.Size = new System.Drawing.Size(182, 32);
            this.helpTextLabel4.TabIndex = 21;
            this.helpTextLabel4.Text = "Up/Down arrows to change Asset Number.";
            this.helpTextLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toggleHelpLabel
            // 
            this.toggleHelpLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toggleHelpLabel.Location = new System.Drawing.Point(3, 187);
            this.toggleHelpLabel.Name = "toggleHelpLabel";
            this.toggleHelpLabel.Size = new System.Drawing.Size(98, 40);
            this.toggleHelpLabel.TabIndex = 22;
            this.toggleHelpLabel.Text = "Toggle Help Text";
            this.toggleHelpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toggleHelpLabel.Click += new System.EventHandler(this.toggleHelpLabel_Click);
            // 
            // helpTextLabel5
            // 
            this.helpTextLabel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel5.Location = new System.Drawing.Point(492, 89);
            this.helpTextLabel5.Name = "helpTextLabel5";
            this.helpTextLabel5.Size = new System.Drawing.Size(182, 32);
            this.helpTextLabel5.TabIndex = 23;
            this.helpTextLabel5.Text = "Save/Load corresponds to the number above!";
            this.helpTextLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel7
            // 
            this.helpTextLabel7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel7.Location = new System.Drawing.Point(880, 55);
            this.helpTextLabel7.Name = "helpTextLabel7";
            this.helpTextLabel7.Size = new System.Drawing.Size(142, 61);
            this.helpTextLabel7.TabIndex = 24;
            this.helpTextLabel7.Text = "Lights and Faces will be created using \"Current Color\"";
            this.helpTextLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpTextLabel8
            // 
            this.helpTextLabel8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpTextLabel8.Location = new System.Drawing.Point(252, 60);
            this.helpTextLabel8.Name = "helpTextLabel8";
            this.helpTextLabel8.Size = new System.Drawing.Size(210, 56);
            this.helpTextLabel8.TabIndex = 25;
            this.helpTextLabel8.Text = "Change the color of faces depending on your cursor light + Added lights";
            this.helpTextLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AssetCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.helpTextLabel8);
            this.Controls.Add(this.helpTextLabel7);
            this.Controls.Add(this.helpTextLabel5);
            this.Controls.Add(this.toggleHelpLabel);
            this.Controls.Add(this.helpTextLabel4);
            this.Controls.Add(this.helpTextLabel3);
            this.Controls.Add(this.helpTextLabel2);
            this.Controls.Add(this.helpTextLabel);
            this.Controls.Add(this.surfaceLightsLabel);
            this.Controls.Add(this.rectangleModeLabel);
            this.Controls.Add(this.polygonModeLabel);
            this.Controls.Add(this.currentAssetLabel);
            this.Controls.Add(this.loadLabel);
            this.Controls.Add(this.saveLabel);
            this.Controls.Add(this.currentColor);
            this.Controls.Add(this.nextColor);
            this.Controls.Add(this.toggleLightsLabel);
            this.Controls.Add(this.menuLabel);
            this.DoubleBuffered = true;
            this.Name = "AssetCreator";
            this.Size = new System.Drawing.Size(1022, 710);
            this.Load += new System.EventHandler(this.AssetCreator_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AssetCreator_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AssetCreator_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AssetCreator_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AssetCreator_MouseUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.AssetCreator_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label menuLabel;
        private System.Windows.Forms.Label toggleLightsLabel;
        private System.Windows.Forms.Label nextColor;
        private System.Windows.Forms.Label currentColor;
        private System.Windows.Forms.Label saveLabel;
        private System.Windows.Forms.Label loadLabel;
        private System.Windows.Forms.Label currentAssetLabel;
        private System.Windows.Forms.Label polygonModeLabel;
        private System.Windows.Forms.Label rectangleModeLabel;
        private System.Windows.Forms.Label surfaceLightsLabel;
        private System.Windows.Forms.Label helpTextLabel;
        private System.Windows.Forms.Label helpTextLabel2;
        private System.Windows.Forms.Label helpTextLabel3;
        private System.Windows.Forms.Label helpTextLabel4;
        private System.Windows.Forms.Label toggleHelpLabel;
        private System.Windows.Forms.Label helpTextLabel5;
        private System.Windows.Forms.Label helpTextLabel7;
        private System.Windows.Forms.Label helpTextLabel8;
    }
}
