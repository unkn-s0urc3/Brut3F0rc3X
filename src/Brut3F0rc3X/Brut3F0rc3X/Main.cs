using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brut3F0rc3X
{
    public partial class Main : Form
    {
        private readonly List<CheckBox> _checkBoxes = new List<CheckBox>();
        private readonly HashSet<string> _selectedTasks = new HashSet<string>();
        private readonly Dictionary<string, Func<Task>> _attackMethods;

        public Main()
        {
            InitializeComponent();
            InitializeCheckBoxes();

            _attackMethods = new Dictionary<string, Func<Task>>
            {
                { "All digits same", AllDigitsSame },
                { "Alternation", Alternation },
            };
        }

        private void InitializeCheckBoxes()
        {
            _checkBoxes.AddRange(GetAllCheckBoxes(tabPage1));
        }

        private IEnumerable<CheckBox> GetAllCheckBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    yield return checkBox;
                }
                else if (control.HasChildren)
                {
                    foreach (var child in GetAllCheckBoxes(control))
                    {
                        yield return child;
                    }
                }
            }
        }

        private async void StartAttackButton_Click(object sender, EventArgs e)
        {
            TextBoxLog.Clear();
            _selectedTasks.Clear();

            // Collect all selected attack methods
            foreach (var checkBox in _checkBoxes)
            {
                if (checkBox.Checked && checkBox.Tag is string methodName)
                {
                    _selectedTasks.Add(methodName);
                }
            }

            if (_selectedTasks.Count == 0)
            {
                MessageBox.Show("Please select at least one method!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var methodName in _selectedTasks)
            {
                if (_attackMethods.TryGetValue(methodName, out var attack))
                {
                    await attack();
                }
                else
                {
                    MessageBox.Show($"Method {methodName} not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("All methods completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearLogButton_Click(object sender, EventArgs e)
        {
            TextBoxLog.Clear();
        }

        private void StopAttackButton_Click(object sender, EventArgs e)
        {
            // Add your stop logic if needed
        }

        private async void RandomAttackButton_Click(object sender, EventArgs e)
        {
            TextBoxLog.Clear();
            await ExecuteAttack("[Random]", async () =>
            {
                if (int.TryParse(TextBoxNumberOfPasswords.Text, out int numberOfPasswords))
                {
                    var uniquePasswords = GenerateRandomPasswords(numberOfPasswords);
                    foreach (var password in uniquePasswords)
                    {
                        AppendText($"[Random] {password}\r\n");
                    }
                }
                else
                {
                    ShowErrorMessage("Please enter a valid number of passwords!");
                }
            });
        }

        private IEnumerable<string> GenerateRandomPasswords(int numberOfPasswords)
        {
            var uniquePasswords = new HashSet<string>();
            var random = new Random();

            while (uniquePasswords.Count < numberOfPasswords)
            {
                string password = GenerateRandomPassword(random);
                uniquePasswords.Add(password);
            }

            return uniquePasswords;
        }

        private string GenerateRandomPassword(Random random)
        {
            return string.Concat(Enumerable.Range(0, 7).Select(_ => random.Next(0, 10).ToString()));
        }

        private async void SubsequenceAttackButton_Click(object sender, EventArgs e)
        {
            TextBoxLog.Clear();
            await ExecuteAttack("[Subsequence]", async () =>
            {
                if (int.TryParse(TextBoxNumberOfPasswords.Text, out int numberOfPasswords))
                {
                    numberOfPasswords += 1000000; // Offset for subsequence attack
                    for (int i = 1000000; i < numberOfPasswords; i++)
                    {
                        AppendText($"[Subsequence] {i}\r\n");
                    }
                }
                else
                {
                    ShowErrorMessage("Please enter a valid number of passwords!");
                }
            });
        }

        private async Task AllDigitsSame()
        {
            await ExecuteAttack("[AllDigitsSame]", () =>
            {
                for (int i = 1; i <= 9; i++)
                {
                    string password = new string(Convert.ToChar(i.ToString()), 7);
                    AppendText($"[AllDigitsSame] {password}\r\n");
                }
            });
        }

        private async Task Alternation()
        {
            await ExecuteAttack("[Alternation]", () =>
            {
                for (int firstDigit = 1; firstDigit <= 9; firstDigit++)
                {
                    for (int secondDigit = 0; secondDigit <= 9; secondDigit++)
                    {
                        if (firstDigit == secondDigit) continue;

                        string password = string.Concat(Enumerable.Range(0, 7).Select(i => (i % 2 == 0 ? firstDigit : secondDigit).ToString()));
                        AppendText($"[Alternation] {password}\r\n");
                    }
                }
            });
        }

        private async Task ExecuteAttack(string attackName, Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Invoke((Action)(() => TextBoxLog.AppendText($"{attackName} Started\r\n")));

            await Task.Run(action);

            stopwatch.Stop();
            Invoke((Action)(() => TextBoxLog.AppendText($"{attackName} Finished!\r\n")));

            Invoke((Action)(() =>
            {
                LabelTime.Text = $"Time: {stopwatch.Elapsed:hh\\:mm\\:ss\\.fff}";
            }));
        }

        private void AppendText(string text)
        {
            Invoke((Action)(() => TextBoxLog.AppendText(text)));
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}