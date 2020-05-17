using System.ComponentModel;

namespace LanguageLoR
{
    partial class AboutWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.titleLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.issuesLink = new System.Windows.Forms.LinkLabel();
            this.websiteLink = new System.Windows.Forms.LinkLabel();
            this.iconCreditsLabel = new System.Windows.Forms.Label();
            this.licenseLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(260, 21);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "label1";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // versionLabel
            // 
            this.versionLabel.Location = new System.Drawing.Point(12, 30);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(260, 21);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "label1";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // authorLabel
            // 
            this.authorLabel.Location = new System.Drawing.Point(12, 51);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(260, 21);
            this.authorLabel.TabIndex = 2;
            this.authorLabel.Text = "label1";
            this.authorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // issuesLink
            // 
            this.issuesLink.Location = new System.Drawing.Point(12, 144);
            this.issuesLink.Name = "issuesLink";
            this.issuesLink.Size = new System.Drawing.Size(260, 19);
            this.issuesLink.TabIndex = 5;
            this.issuesLink.TabStop = true;
            this.issuesLink.Text = "linkLabel1";
            this.issuesLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.issuesLink.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.IssuesLinkClick);
            // 
            // websiteLink
            // 
            this.websiteLink.Location = new System.Drawing.Point(12, 115);
            this.websiteLink.Name = "websiteLink";
            this.websiteLink.Size = new System.Drawing.Size(260, 19);
            this.websiteLink.TabIndex = 6;
            this.websiteLink.TabStop = true;
            this.websiteLink.Text = "linkLabel1";
            this.websiteLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.websiteLink.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WebsiteLinkClick);
            // 
            // iconCreditsLabel
            // 
            this.iconCreditsLabel.Location = new System.Drawing.Point(12, 85);
            this.iconCreditsLabel.Name = "iconCreditsLabel";
            this.iconCreditsLabel.Size = new System.Drawing.Size(260, 21);
            this.iconCreditsLabel.TabIndex = 7;
            this.iconCreditsLabel.Text = "label1";
            this.iconCreditsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // licenseLink
            // 
            this.licenseLink.Location = new System.Drawing.Point(12, 173);
            this.licenseLink.Name = "licenseLink";
            this.licenseLink.Size = new System.Drawing.Size(260, 19);
            this.licenseLink.TabIndex = 8;
            this.licenseLink.TabStop = true;
            this.licenseLink.Text = "linkLabel1";
            this.licenseLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.licenseLink.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LicenseLinkClick);
            // 
            // AboutWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 201);
            this.Controls.Add(this.licenseLink);
            this.Controls.Add(this.iconCreditsLabel);
            this.Controls.Add(this.websiteLink);
            this.Controls.Add(this.issuesLink);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.titleLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutWindow";
            this.ShowIcon = false;
            this.Text = "About";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label iconCreditsLabel;
        private System.Windows.Forms.LinkLabel websiteLink;
        private System.Windows.Forms.LinkLabel issuesLink;
        private System.Windows.Forms.LinkLabel licenseLink;
    }
}