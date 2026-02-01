namespace TFTManager
{
    partial class TFTManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFTManager));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PowerLevel = new System.Windows.Forms.Label();
            this.ResilienceLevel = new System.Windows.Forms.Label();
            this.SynergyLevel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BonusPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SelectedTraitsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.CommonTraits = new System.Windows.Forms.Label();
            this.PossibleAdditionalTraitsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.OriginPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ClassPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.divide = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.AttackLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.MagicLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ResilienceBar = new TFTCustomControls.FillBar();
            this.PowerBar = new TFTCustomControls.FillBar();
            this.ResetSelected = new System.Windows.Forms.Button();
            this.ResetContested = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Traits:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Selected traits (Max 3):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(514, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Resilience:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(514, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Power:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(514, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Synergy:";
            // 
            // PowerLevel
            // 
            this.PowerLevel.AutoSize = true;
            this.PowerLevel.BackColor = System.Drawing.Color.Transparent;
            this.PowerLevel.Location = new System.Drawing.Point(733, 214);
            this.PowerLevel.Name = "PowerLevel";
            this.PowerLevel.Size = new System.Drawing.Size(13, 13);
            this.PowerLevel.TabIndex = 9;
            this.PowerLevel.Text = "0";
            this.PowerLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResilienceLevel
            // 
            this.ResilienceLevel.AutoSize = true;
            this.ResilienceLevel.BackColor = System.Drawing.Color.Transparent;
            this.ResilienceLevel.Location = new System.Drawing.Point(733, 173);
            this.ResilienceLevel.Name = "ResilienceLevel";
            this.ResilienceLevel.Size = new System.Drawing.Size(13, 13);
            this.ResilienceLevel.TabIndex = 11;
            this.ResilienceLevel.Text = "0";
            this.ResilienceLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SynergyLevel
            // 
            this.SynergyLevel.BackColor = System.Drawing.Color.Red;
            this.SynergyLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SynergyLevel.Location = new System.Drawing.Point(579, 245);
            this.SynergyLevel.Name = "SynergyLevel";
            this.SynergyLevel.Size = new System.Drawing.Size(36, 25);
            this.SynergyLevel.TabIndex = 12;
            this.SynergyLevel.Text = "0";
            this.SynergyLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(380, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Bonuses:";
            // 
            // BonusPanel
            // 
            this.BonusPanel.AutoSize = true;
            this.BonusPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BonusPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.BonusPanel.Location = new System.Drawing.Point(383, 292);
            this.BonusPanel.MaximumSize = new System.Drawing.Size(528, 500);
            this.BonusPanel.Name = "BonusPanel";
            this.BonusPanel.Size = new System.Drawing.Size(0, 0);
            this.BonusPanel.TabIndex = 14;
            // 
            // SelectedTraitsPanel
            // 
            this.SelectedTraitsPanel.ColumnCount = 2;
            this.SelectedTraitsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.SelectedTraitsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.SelectedTraitsPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.SelectedTraitsPanel.Location = new System.Drawing.Point(378, 39);
            this.SelectedTraitsPanel.Name = "SelectedTraitsPanel";
            this.SelectedTraitsPanel.RowCount = 3;
            this.SelectedTraitsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.SelectedTraitsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.SelectedTraitsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.SelectedTraitsPanel.Size = new System.Drawing.Size(528, 89);
            this.SelectedTraitsPanel.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(493, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Compatible traits:";
            // 
            // CommonTraits
            // 
            this.CommonTraits.AutoSize = true;
            this.CommonTraits.Location = new System.Drawing.Point(380, 147);
            this.CommonTraits.Name = "CommonTraits";
            this.CommonTraits.Size = new System.Drawing.Size(135, 13);
            this.CommonTraits.TabIndex = 20;
            this.CommonTraits.Text = "Possible Add\' Active Traits:";
            // 
            // PossibleAdditionalTraitsPanel
            // 
            this.PossibleAdditionalTraitsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PossibleAdditionalTraitsPanel.Location = new System.Drawing.Point(378, 162);
            this.PossibleAdditionalTraitsPanel.Name = "PossibleAdditionalTraitsPanel";
            this.PossibleAdditionalTraitsPanel.Size = new System.Drawing.Size(125, 99);
            this.PossibleAdditionalTraitsPanel.TabIndex = 15;
            // 
            // OriginPanel
            // 
            this.OriginPanel.Location = new System.Drawing.Point(12, 39);
            this.OriginPanel.Name = "OriginPanel";
            this.OriginPanel.Size = new System.Drawing.Size(160, 380);
            this.OriginPanel.TabIndex = 0;
            // 
            // ClassPanel
            // 
            this.ClassPanel.Location = new System.Drawing.Point(178, 39);
            this.ClassPanel.Name = "ClassPanel";
            this.ClassPanel.Size = new System.Drawing.Size(160, 380);
            this.ClassPanel.TabIndex = 1;
            // 
            // divide
            // 
            this.divide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.divide.BackColor = System.Drawing.Color.Black;
            this.divide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divide.Location = new System.Drawing.Point(348, 5);
            this.divide.Name = "divide";
            this.divide.Size = new System.Drawing.Size(2, 461);
            this.divide.TabIndex = 22;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(17, 440);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(99, 23);
            this.ResetButton.TabIndex = 23;
            this.ResetButton.Text = "Reset All";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // AttackLabel
            // 
            this.AttackLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(123)))), ((int)(((byte)(47)))));
            this.AttackLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AttackLabel.Location = new System.Drawing.Point(694, 245);
            this.AttackLabel.Name = "AttackLabel";
            this.AttackLabel.Size = new System.Drawing.Size(36, 25);
            this.AttackLabel.TabIndex = 33;
            this.AttackLabel.Text = "0";
            this.AttackLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(632, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Attack:";
            // 
            // MagicLabel
            // 
            this.MagicLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(95)))), ((int)(((byte)(217)))));
            this.MagicLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MagicLabel.Location = new System.Drawing.Point(813, 244);
            this.MagicLabel.Name = "MagicLabel";
            this.MagicLabel.Size = new System.Drawing.Size(36, 25);
            this.MagicLabel.TabIndex = 35;
            this.MagicLabel.Text = "0";
            this.MagicLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(744, 249);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Magic:";
            // 
            // ResilienceBar
            // 
            this.ResilienceBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResilienceBar.Location = new System.Drawing.Point(579, 162);
            this.ResilienceBar.MaxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            this.ResilienceBar.MaxValue = 100D;
            this.ResilienceBar.MinColor = System.Drawing.Color.Red;
            this.ResilienceBar.MinValue = 0D;
            this.ResilienceBar.Name = "ResilienceBar";
            this.ResilienceBar.Padding = new System.Windows.Forms.Padding(2);
            this.ResilienceBar.Size = new System.Drawing.Size(327, 35);
            this.ResilienceBar.TabIndex = 36;
            this.ResilienceBar.Value = 0D;
            // 
            // PowerBar
            // 
            this.PowerBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PowerBar.Location = new System.Drawing.Point(579, 203);
            this.PowerBar.MaxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            this.PowerBar.MaxValue = 100D;
            this.PowerBar.MinColor = System.Drawing.Color.Red;
            this.PowerBar.MinValue = 0D;
            this.PowerBar.Name = "PowerBar";
            this.PowerBar.Padding = new System.Windows.Forms.Padding(2);
            this.PowerBar.Size = new System.Drawing.Size(327, 35);
            this.PowerBar.TabIndex = 37;
            this.PowerBar.Value = 0D;
            // 
            // ResetSelected
            // 
            this.ResetSelected.Location = new System.Drawing.Point(122, 440);
            this.ResetSelected.Name = "ResetSelected";
            this.ResetSelected.Size = new System.Drawing.Size(99, 23);
            this.ResetSelected.TabIndex = 38;
            this.ResetSelected.Text = "Reset Selected";
            this.ResetSelected.UseVisualStyleBackColor = true;
            this.ResetSelected.Click += new System.EventHandler(this.ResetSelected_Click);
            // 
            // ResetContested
            // 
            this.ResetContested.Location = new System.Drawing.Point(227, 440);
            this.ResetContested.Name = "ResetContested";
            this.ResetContested.Size = new System.Drawing.Size(99, 23);
            this.ResetContested.TabIndex = 39;
            this.ResetContested.Text = "Reset Contested";
            this.ResetContested.UseVisualStyleBackColor = true;
            this.ResetContested.Click += new System.EventHandler(this.ResetContested_Click);
            // 
            // TFTManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(918, 471);
            this.Controls.Add(this.ResetContested);
            this.Controls.Add(this.ResetSelected);
            this.Controls.Add(this.MagicLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.AttackLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PowerLevel);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.divide);
            this.Controls.Add(this.ClassPanel);
            this.Controls.Add(this.OriginPanel);
            this.Controls.Add(this.PossibleAdditionalTraitsPanel);
            this.Controls.Add(this.CommonTraits);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SelectedTraitsPanel);
            this.Controls.Add(this.BonusPanel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SynergyLevel);
            this.Controls.Add(this.ResilienceLevel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResilienceBar);
            this.Controls.Add(this.PowerBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFTManager";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "TFT Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label PowerLevel;
        private System.Windows.Forms.Label ResilienceLevel;
        private System.Windows.Forms.Label SynergyLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel BonusPanel;
        private System.Windows.Forms.TableLayoutPanel SelectedTraitsPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label CommonTraits;
        private System.Windows.Forms.FlowLayoutPanel PossibleAdditionalTraitsPanel;
        private System.Windows.Forms.FlowLayoutPanel OriginPanel;
        private System.Windows.Forms.FlowLayoutPanel ClassPanel;
        private System.Windows.Forms.Label divide;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label AttackLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label MagicLabel;
        private System.Windows.Forms.Label label11;
        private TFTCustomControls.FillBar ResilienceBar;
        private TFTCustomControls.FillBar PowerBar;
        private System.Windows.Forms.Button ResetSelected;
        private System.Windows.Forms.Button ResetContested;
    }
}

