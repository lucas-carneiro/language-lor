using System.Diagnostics;
using System.Windows.Forms;

namespace LanguageLoR
{
    public partial class AboutWindow : Form
    {
        private const string TitleText = "Language LoR";
        private const string VersionText = "Version " + Program.Version;
        private const string AuthorText = "Made by Lucas Rodrigues Carneiro";
        private const string WebsiteText = "Website";
        private const string WebsiteLink = "https://google.com/search?q=test1";
        private const string IssuesText = "Any issues? Report here";
        private const string IssuesLink = "https://google.com/search?q=test2";
        private const string IconCreditsText = "Icon made by Freepik from www.flaticon.com";
        private const string LicenseText = "MIT License";
        private const string LicenseLink = "https://google.com/search?q=test3";
        public AboutWindow()
        {
            InitializeComponent();
            titleLabel.Text = TitleText;
            versionLabel.Text = VersionText;
            authorLabel.Text = AuthorText;
            websiteLink.Text = WebsiteText;
            issuesLink.Text = IssuesText;
            iconCreditsLabel.Text = IconCreditsText;
            licenseLink.Text = LicenseText;
        }

        private void WebsiteLinkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            websiteLink.LinkVisited = true;
            Process.Start(WebsiteLink);
        }

        private void IssuesLinkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            issuesLink.LinkVisited = true;
            Process.Start(IssuesLink);
        }

        private void LicenseLinkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            licenseLink.LinkVisited = true;
            Process.Start(LicenseLink);
        }
    }
}