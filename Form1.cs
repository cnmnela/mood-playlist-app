using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SpotifyMoodLauncher
{
    public partial class MainForm : Form
    {
        // Spotify playlist URLs for different moods
        private const string SAD_PLAYLIST = "https://open.spotify.com/playlist/37i9dQZF1DX3YSRoSdA634";
        private const string CALM_PLAYLIST = "https://open.spotify.com/playlist/37i9dQZF1DWU0ScTcjJBdj";
        private const string HAPPY_PLAYLIST = "https://open.spotify.com/playlist/37i9dQZF1DXdPec7aLTmlC";
        private const string ENERGETIC_PLAYLIST = "https://open.spotify.com/playlist/37i9dQZF1DX76Wlfdnj7AP";
        private const string MAIN_CHARACTER_PLAYLIST = "https://open.spotify.com/playlist/37i9dQZF1DX4OzrY981I1W";
        private const string GAMING_PLAYLIST = "https://open.spotify.com/playlist/37i9dQZF1DWTyiBJ6yEqeu";
        private const string IN_LOVE_PLAYLIST = "https://open.spotify.com/playlist/37i9dQZF1DX50QitC6Oqtn";
        private const string FALL_ASLEEP_PLAYLIST = "https://open.spotify.com/playlist/37i9dQZF1DWZd79rJ6a7lp";

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Form settings
            this.Text = "🎵 Mood-Based Spotify Playlist Launcher";
            this.Size = new Size(700, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(30, 30, 30); // Dark background
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Title Label
            Label titleLabel = new Label();
            titleLabel.Text = "How are you feeling today?";
            titleLabel.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(120, 20);
            this.Controls.Add(titleLabel);

            // Subtitle Label
            Label subtitleLabel = new Label();
            subtitleLabel.Text = "Choose your mood and let the music play!";
            subtitleLabel.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            subtitleLabel.ForeColor = Color.LightGray;
            subtitleLabel.AutoSize = true;
            subtitleLabel.Location = new Point(170, 60);
            this.Controls.Add(subtitleLabel);

            // Row 1 - Original Moods
            Button btnSad = CreateMoodButton("😢 Sad", Color.FromArgb(100, 120, 180), 50, 110);
            btnSad.Click += BtnSad_Click;
            this.Controls.Add(btnSad);

            Button btnCalm = CreateMoodButton("😌 Calm", Color.FromArgb(100, 180, 150), 270, 110);
            btnCalm.Click += BtnCalm_Click;
            this.Controls.Add(btnCalm);

            Button btnHappy = CreateMoodButton("😊 Happy", Color.FromArgb(255, 200, 87), 490, 110);
            btnHappy.Click += BtnHappy_Click;
            this.Controls.Add(btnHappy);

            // Row 2 - More Moods
            Button btnEnergetic = CreateMoodButton("⚡ Energetic", Color.FromArgb(255, 100, 100), 50, 230);
            btnEnergetic.Click += BtnEnergetic_Click;
            this.Controls.Add(btnEnergetic);

            Button btnMainCharacter = CreateMoodButton("✨ Main Character", Color.FromArgb(255, 105, 180), 270, 230);
            btnMainCharacter.Click += BtnMainCharacter_Click;
            this.Controls.Add(btnMainCharacter);

            Button btnGaming = CreateMoodButton("🎮 Gaming", Color.FromArgb(138, 43, 226), 490, 230);
            btnGaming.Click += BtnGaming_Click;
            this.Controls.Add(btnGaming);

            // Row 3 - New Moods
            Button btnInLove = CreateMoodButton("💕 In Love", Color.FromArgb(255, 20, 147), 160, 350);
            btnInLove.Click += BtnInLove_Click;
            this.Controls.Add(btnInLove);

            Button btnFallAsleep = CreateMoodButton("😴 Fall Asleep", Color.FromArgb(72, 61, 139), 380, 350);
            btnFallAsleep.Click += BtnFallAsleep_Click;
            this.Controls.Add(btnFallAsleep);

            // Status Label
            Label statusLabel = new Label();
            statusLabel.Name = "statusLabel";
            statusLabel.Text = "Select a mood to start listening!";
            statusLabel.Font = new Font("Segoe UI", 11, FontStyle.Italic);
            statusLabel.ForeColor = Color.LightGray;
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(210, 490);
            this.Controls.Add(statusLabel);

            // Credit Label
            Label creditLabel = new Label();
            creditLabel.Text = "Made with 💖 by Angiela Canaman";
            creditLabel.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            creditLabel.ForeColor = Color.Gray;
            creditLabel.AutoSize = true;
            creditLabel.Location = new Point(240, 560);
            this.Controls.Add(creditLabel);
        }

        // Method to create styled mood buttons
        private Button CreateMoodButton(string text, Color backgroundColor, int x, int y)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Size = new Size(200, 100);
            btn.Location = new Point(x, y);
            btn.BackColor = backgroundColor;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;

            // Add hover effect
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = ControlPaint.Light(backgroundColor, 0.2f);
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = backgroundColor;
            };

            return btn;
        }

        // Event handlers for original moods
        private void BtnSad_Click(object sender, EventArgs e)
        {
            OpenSpotifyPlaylist(SAD_PLAYLIST, "Sad");
        }

        private void BtnCalm_Click(object sender, EventArgs e)
        {
            OpenSpotifyPlaylist(CALM_PLAYLIST, "Calm");
        }

        private void BtnHappy_Click(object sender, EventArgs e)
        {
            OpenSpotifyPlaylist(HAPPY_PLAYLIST, "Happy");
        }

        private void BtnEnergetic_Click(object sender, EventArgs e)
        {
            OpenSpotifyPlaylist(ENERGETIC_PLAYLIST, "Energetic");
        }

        // Event handlers for new moods
        private void BtnMainCharacter_Click(object sender, EventArgs e)
        {
            OpenSpotifyPlaylist(MAIN_CHARACTER_PLAYLIST, "Main Character");
        }

        private void BtnGaming_Click(object sender, EventArgs e)
        {
            OpenSpotifyPlaylist(GAMING_PLAYLIST, "Gaming");
        }

        private void BtnInLove_Click(object sender, EventArgs e)
        {
            OpenSpotifyPlaylist(IN_LOVE_PLAYLIST, "In Love");
        }

        private void BtnFallAsleep_Click(object sender, EventArgs e)
        {
            OpenSpotifyPlaylist(FALL_ASLEEP_PLAYLIST, "Fall Asleep");
        }

        // Method to open Spotify playlist
        private void OpenSpotifyPlaylist(string playlistUrl, string mood)
        {
            try
            {
                // Update status label
                Label statusLabel = this.Controls.Find("statusLabel", false)[0] as Label;
                statusLabel.Text = $"Opening {mood} playlist... 🎵";
                statusLabel.ForeColor = Color.LightGreen;

                // Open the Spotify playlist URL
                Process.Start(new ProcessStartInfo
                {
                    FileName = playlistUrl,
                    UseShellExecute = true
                });

                // Show success message
                MessageBox.Show(
                    $"Enjoy your {mood} playlist! 🎶",
                    "Playlist Opened",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Reset status after a delay
                System.Threading.Tasks.Task.Delay(3000).ContinueWith(_ =>
                {
                    this.Invoke(new Action(() =>
                    {
                        statusLabel.Text = "Select a mood to start listening!";
                        statusLabel.ForeColor = Color.LightGray;
                    }));
                });
            }
            catch (Exception ex)
            {
                // Handle any errors
                MessageBox.Show(
                    $"Error opening playlist: {ex.Message}\n\nMake sure you have a web browser or Spotify installed!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
