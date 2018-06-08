﻿namespace OmniMIDIConfigurator
{
    partial class MaskSynthAsAnother
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
            this.Names = new System.Windows.Forms.ComboBox();
            this.OK = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.DefName = new System.Windows.Forms.Button();
            this.SynthType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.VIDPIDList = new System.Windows.Forms.LinkLabelEx();
            this.PIDValue = new OmniMIDIConfigurator.HexNumericUpDown();
            this.VIDValue = new OmniMIDIConfigurator.HexNumericUpDown();
            this.AddNewNamePl0x = new System.Windows.Forms.LinkLabelEx();
            ((System.ComponentModel.ISupportInitialize)(this.PIDValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VIDValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(461, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "Some apps might be hardwired to a specific synthesizer.\r\nYou can try and fool the" +
    "m by renaming OmniMIDI to another synthesizer/driver.\r\n\r\nSelect a mask in the li" +
    "st below:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mask name:";
            // 
            // Names
            // 
            this.Names.FormattingEnabled = true;
            this.Names.Items.AddRange(new object[] {
            "AWE64 MIDI Synth",
            "BASSMIDI Driver",
            "BASSMIDI Driver (Port A)",
            "BASSMIDI Driver (Port B)",
            "CoolSoft VirtualMIDISynth",
            "Creative OPL3 FM",
            "Microsoft GS Wavetable Synth",
            "Microsoft Synthesizer",
            "NVIDIA® Wavetable Synthesizer",
            "OmniMIDI",
            "SB AWE32 MIDI Synth",
            "SB Live! Synth A",
            "SB Live! Synth B",
            "SoundMAX Wavetable Synth",
            "Timidity++ Driver",
            "USB Audio Device",
            "VirtualMIDISynth #1",
            "VirtualMIDISynth #2",
            "VirtualMIDISynth #3",
            "VirtualMIDISynth #4",
            "Windows OPL3 Synth",
            "YMF262 Synth Emulator",
            "Yamaha S-YXG50 SoftSynthesizer"});
            this.Names.Location = new System.Drawing.Point(151, 78);
            this.Names.Name = "Names";
            this.Names.Size = new System.Drawing.Size(241, 21);
            this.Names.TabIndex = 3;
            this.Names.Text = " ";
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.Location = new System.Drawing.Point(398, 189);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 4;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.Location = new System.Drawing.Point(317, 189);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // DefName
            // 
            this.DefName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DefName.Location = new System.Drawing.Point(236, 189);
            this.DefName.Name = "DefName";
            this.DefName.Size = new System.Drawing.Size(75, 23);
            this.DefName.TabIndex = 7;
            this.DefName.Text = "Default";
            this.DefName.UseVisualStyleBackColor = true;
            this.DefName.Click += new System.EventHandler(this.DefName_Click);
            // 
            // SynthType
            // 
            this.SynthType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SynthType.FormattingEnabled = true;
            this.SynthType.Items.AddRange(new object[] {
            "FM internal synthesizer",
            "Generic internal synthesizer",
            "Hardware MIDI output port",
            "Hardware wavetable synthesizer",
            "Microsoft MIDI Mapper",
            "Software synthesizer",
            "Square wave internal synthesizer"});
            this.SynthType.Location = new System.Drawing.Point(151, 102);
            this.SynthType.Name = "SynthType";
            this.SynthType.Size = new System.Drawing.Size(241, 21);
            this.SynthType.TabIndex = 9;
            this.SynthType.SelectedIndexChanged += new System.EventHandler(this.SynthType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mask type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "PID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "VID:";
            // 
            // VIDPIDList
            // 
            this.VIDPIDList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VIDPIDList.AutoSize = true;
            this.VIDPIDList.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(0)))), ((int)(((byte)(119)))));
            this.VIDPIDList.Location = new System.Drawing.Point(7, 185);
            this.VIDPIDList.Name = "VIDPIDList";
            this.VIDPIDList.Size = new System.Drawing.Size(167, 13);
            this.VIDPIDList.TabIndex = 15;
            this.VIDPIDList.TabStop = true;
            this.VIDPIDList.Text = "Vendor and product IDs database";
            this.VIDPIDList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.VIDPIDList_LinkClicked);
            // 
            // PIDValue
            // 
            this.PIDValue.Hexadecimal = true;
            this.PIDValue.Location = new System.Drawing.Point(151, 151);
            this.PIDValue.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PIDValue.Name = "PIDValue";
            this.PIDValue.Size = new System.Drawing.Size(241, 20);
            this.PIDValue.TabIndex = 14;
            this.PIDValue.Value = new decimal(new int[] {
            45067,
            0,
            0,
            0});
            this.PIDValue.ValueChanged += new System.EventHandler(this.PIDValue_ValueChanged);
            // 
            // VIDValue
            // 
            this.VIDValue.Hexadecimal = true;
            this.VIDValue.Location = new System.Drawing.Point(151, 127);
            this.VIDValue.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.VIDValue.Name = "VIDValue";
            this.VIDValue.Size = new System.Drawing.Size(241, 20);
            this.VIDValue.TabIndex = 13;
            this.VIDValue.Value = new decimal(new int[] {
            51966,
            0,
            0,
            0});
            this.VIDValue.ValueChanged += new System.EventHandler(this.VIDValue_ValueChanged);
            // 
            // AddNewNamePl0x
            // 
            this.AddNewNamePl0x.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddNewNamePl0x.AutoSize = true;
            this.AddNewNamePl0x.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(0)))), ((int)(((byte)(119)))));
            this.AddNewNamePl0x.Location = new System.Drawing.Point(7, 201);
            this.AddNewNamePl0x.Name = "AddNewNamePl0x";
            this.AddNewNamePl0x.Size = new System.Drawing.Size(186, 13);
            this.AddNewNamePl0x.TabIndex = 6;
            this.AddNewNamePl0x.TabStop = true;
            this.AddNewNamePl0x.Text = "Can you add another name to the list?";
            this.AddNewNamePl0x.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddNewNamePl0x_LinkClicked);
            // 
            // MaskSynthAsAnother
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(485, 224);
            this.Controls.Add(this.VIDPIDList);
            this.Controls.Add(this.PIDValue);
            this.Controls.Add(this.VIDValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SynthType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DefName);
            this.Controls.Add(this.AddNewNamePl0x);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Names);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaskSynthAsAnother";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mask synthesizer as another";
            this.Load += new System.EventHandler(this.MaskSynthAsAnother_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PIDValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VIDValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Names;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.LinkLabelEx AddNewNamePl0x;
        private System.Windows.Forms.Button DefName;
        private System.Windows.Forms.ComboBox SynthType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private HexNumericUpDown VIDValue;
        private HexNumericUpDown PIDValue;
        private System.Windows.Forms.LinkLabelEx VIDPIDList;
    }
}