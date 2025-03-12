using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace Brut3F0rc3X
{
    public partial class Main : Form
    {
        private bool isBruteForceMethod = true;
        private bool isSearching = false; // Flag for controlling search process
        private List<string> dictionaryPasswords = new List<string>(); // List to store dictionary passwords

        public Main()
        {
            InitializeComponent();
            InitializeControls();
        }

        // Initialize the initial state of the controls
        private void InitializeControls()
        {
            btnSelectDictionary.Enabled = false;
            btnSearch.Enabled = false;

            txtBruteForceStart.Enabled = false;
            txtBruteForceEnd.Enabled = false;
            txtDictionaryPath.Enabled = false;
        }

        // Handle the Brute Force method selection
        private void rbBruteForce_CheckedChanged(object sender, EventArgs e)
        {
            isBruteForceMethod = true;
            txtBruteForceStart.Enabled = true;
            txtBruteForceEnd.Enabled = true;
            txtDictionaryPath.Enabled = false;

            btnSelectDictionary.Enabled = false;
            btnSearch.Enabled = true;
        }

        // Handle the Dictionary method selection
        private void rbDictionary_CheckedChanged(object sender, EventArgs e)
        {
            isBruteForceMethod = false;
            txtBruteForceStart.Enabled = false;
            txtBruteForceEnd.Enabled = false;

            btnSelectDictionary.Enabled = true;
            btnSearch.Enabled = true;
        }

        // Open file dialog to select dictionary file
        private void btnSelectDictionary_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(selectedFilePath);
                txtDictionaryPath.Text = fileName;

                // Load passwords from the selected file
                LoadPasswordsFromFile(selectedFilePath);
            }
        }

        // Load passwords from CSV file into the dictionary list
        private void LoadPasswordsFromFile(string filePath)
        {
            try
            {
                dictionaryPasswords.Clear();
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    dictionaryPasswords.Add(line.Trim());
                }

                ShowMessage("Successfully loaded " + dictionaryPasswords.Count + " passwords.", MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowMessage("Error while loading file: " + ex.Message, MessageBoxIcon.Error);
            }
        }

        // Show unified error or informational messages
        private void ShowMessage(string message, MessageBoxIcon icon)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, icon);
        }

        // Start the search process when the Search button is clicked
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Check if Brute Force method and fields are not empty
            if (isBruteForceMethod && (string.IsNullOrWhiteSpace(txtBruteForceStart.Text) || string.IsNullOrWhiteSpace(txtBruteForceEnd.Text)))
            {
                ShowMessage("Both 'Start' and 'End' fields must be filled.", MessageBoxIcon.Error);
                return;
            }

            // Check if Dictionary method is selected and dictionary path is empty
            if (!isBruteForceMethod && string.IsNullOrWhiteSpace(txtDictionaryPath.Text))
            {
                ShowMessage("Please select a dictionary file.", MessageBoxIcon.Error);
                return;
            }

            // Prevent multiple searches from being started
            if (isSearching)
                return;

            isSearching = true;
            btnSearch.Enabled = false; // Disable search button during search process

            // Delay before starting the search
            Thread.Sleep(5000);

            // Start the respective method based on selection
            if (isBruteForceMethod)
            {
                Task.Run(() => StartBruteForce());
            }
            else
            {
                Task.Run(() => StartWithDictionary());
            }
        }

        // Method for Brute Force search
        private void StartBruteForce()
        {
            try
            {
                int startValue = int.Parse(txtBruteForceStart.Text);
                int endValue = int.Parse(txtBruteForceEnd.Text);

                // Loop through all possible password combinations
                for (int i = startValue; i <= endValue; i++)
                {
                    SendPassword(i.ToString()); // Send the password
                    Thread.Sleep(100); // Delay between attempts
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error during Brute Force search: " + ex.Message, MessageBoxIcon.Error);
            }
            finally
            {
                CompleteSearch();
            }
        }

        // Method for searching with dictionary passwords
        private void StartWithDictionary()
        {
            try
            {
                if (dictionaryPasswords.Count == 0)
                {
                    ShowMessage("Dictionary is empty. Please load a valid file.", MessageBoxIcon.Error);
                    return;
                }

                // Loop through dictionary passwords
                foreach (var password in dictionaryPasswords)
                {
                    SendPassword(password); // Send the password
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error during Dictionary search: " + ex.Message, MessageBoxIcon.Error);
            }
            finally
            {
                CompleteSearch();
            }
        }

        // Send password input to another application
        private void SendPassword(string password)
        {
            Invoke((Action)(() =>
            {
                SendKeys.Send(password);
                SendKeys.Send("{TAB}");
                SendKeys.Send("{ENTER}");
                SendKeys.Send("{ENTER}");
                SendKeys.Send("{TAB}");
                SendKeys.Send("{TAB}");
            }));
        }

        // Complete the search process and enable the Search button again
        private void CompleteSearch()
        {
            isSearching = false;
            Invoke((Action)(() =>
            {
                btnSearch.Enabled = true; // Enable the search button
            }));
        }

        // Validate input to allow only digits, no leading zeros, and restrict to 7 digits
        private void ValidateInput(KeyPressEventArgs e, TextBox sender)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            // Prevent leading zeroes
            if (sender.Text.Length == 0 && e.KeyChar == '0')
            {
                e.Handled = true;
            }

            // Restrict the number of digits to 7
            if (sender.Text.Length >= 7 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        // Handle the 'Start' field key press event
        private void txtBruteForceStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateInput(e, txtBruteForceStart);
        }

        // Handle the 'End' field key press event
        private void txtBruteForceEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateInput(e, txtBruteForceEnd);
        }
    }
}