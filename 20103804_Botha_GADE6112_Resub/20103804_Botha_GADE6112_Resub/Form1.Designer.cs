namespace _20103804_Botha_GADE6112_Resub
{
    partial class frmGame
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
            this.lblMap = new System.Windows.Forms.Label();
            this.lblBattleInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMap
            // 
            this.lblMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMap.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMap.Location = new System.Drawing.Point(12, 9);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(340, 388);
            this.lblMap.TabIndex = 0;
            this.lblMap.Text = "NO MAP";
            this.lblMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBattleInfo
            // 
            this.lblBattleInfo.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBattleInfo.Location = new System.Drawing.Point(358, 9);
            this.lblBattleInfo.Name = "lblBattleInfo";
            this.lblBattleInfo.Size = new System.Drawing.Size(156, 342);
            this.lblBattleInfo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(358, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Save[Press 1] Load[Press 2]";
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 406);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBattleInfo);
            this.Controls.Add(this.lblMap);
            this.Name = "frmGame";
            this.Text = "Let\'s Play!";
            this.Load += new System.EventHandler(this.frmGame_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmGame_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblBattleInfo;
        private System.Windows.Forms.Label label1;
    }
}

