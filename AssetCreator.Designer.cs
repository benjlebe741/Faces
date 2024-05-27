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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nextColor = new System.Windows.Forms.Label();
            this.currentColor = new System.Windows.Forms.Label();
            this.saveLabel = new System.Windows.Forms.Label();
            this.loadLabel = new System.Windows.Forms.Label();
            this.currentAssetLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 52);
            this.label1.TabIndex = 7;
            this.label1.Text = "Menu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(252, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 52);
            this.label2.TabIndex = 8;
            this.label2.Text = "Toggle Lights";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // nextColor
            // 
            this.nextColor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.nextColor.Location = new System.Drawing.Point(902, 3);
            this.nextColor.Name = "nextColor";
            this.nextColor.Size = new System.Drawing.Size(117, 52);
            this.nextColor.TabIndex = 10;
            this.nextColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentColor
            // 
            this.currentColor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.currentColor.ForeColor = System.Drawing.Color.DarkMagenta;
            this.currentColor.Location = new System.Drawing.Point(779, 3);
            this.currentColor.Name = "currentColor";
            this.currentColor.Size = new System.Drawing.Size(117, 52);
            this.currentColor.TabIndex = 11;
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
            // AssetCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.currentAssetLabel);
            this.Controls.Add(this.loadLabel);
            this.Controls.Add(this.saveLabel);
            this.Controls.Add(this.currentColor);
            this.Controls.Add(this.nextColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "AssetCreator";
            this.Size = new System.Drawing.Size(1022, 710);
            this.Load += new System.EventHandler(this.AssetCreator_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AssetCreator_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AssetCreator_MouseClick);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.AssetCreator_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nextColor;
        private System.Windows.Forms.Label currentColor;
        private System.Windows.Forms.Label saveLabel;
        private System.Windows.Forms.Label loadLabel;
        private System.Windows.Forms.Label currentAssetLabel;
    }
}
