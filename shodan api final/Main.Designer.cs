﻿namespace shodan_api_final
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.apikey = new System.Windows.Forms.Label();
            this.Changeapi = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "SHODAN";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(111, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(295, 63);
            this.button1.TabIndex = 1;
            this.button1.Text = "search with query";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(111, 175);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(295, 63);
            this.button2.TabIndex = 2;
            this.button2.Text = "search with ip";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(111, 262);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(295, 63);
            this.button3.TabIndex = 3;
            this.button3.Text = "list ports";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // apikey
            // 
            this.apikey.AutoSize = true;
            this.apikey.Location = new System.Drawing.Point(28, 374);
            this.apikey.Name = "apikey";
            this.apikey.Size = new System.Drawing.Size(0, 13);
            this.apikey.TabIndex = 4;
            // 
            // Changeapi
            // 
            this.Changeapi.AutoSize = true;
            this.Changeapi.Location = new System.Drawing.Point(415, 395);
            this.Changeapi.Name = "Changeapi";
            this.Changeapi.Size = new System.Drawing.Size(83, 13);
            this.Changeapi.TabIndex = 5;
            this.Changeapi.TabStop = true;
            this.Changeapi.Text = "Change Api Key";
            this.Changeapi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Changeapi_LinkClicked);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 417);
            this.Controls.Add(this.Changeapi);
            this.Controls.Add(this.apikey);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label apikey;
        private System.Windows.Forms.LinkLabel Changeapi;
    }
}

