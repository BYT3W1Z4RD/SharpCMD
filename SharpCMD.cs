using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
namespace SharpCMD
{
    public partial class SharpCMD : Form
    {
        public SharpCMD()
        {
            InitializeComponent();
        }

        private void CommandPromptForm_Load(object sender, EventArgs e)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string welcomeMessage = $"Microsoft Windows [Version {Environment.OSVersion.Version}]"
                + Environment.NewLine
                + $"(c) Microsoft Corporation. All rights reserved."
                + Environment.NewLine
                + Environment.NewLine
                + $"{currentDirectory}>";
            outputTextBox.AppendText(welcomeMessage);
            outputTextBox.ScrollToCaret();
            inputTextBox.Focus();
        }

        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExecuteCommand(inputTextBox.Text.Trim());
                inputTextBox.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private string ExecuteCommand(string command)
        {
            // Append command to output textbox
            outputTextBox.AppendText(Environment.NewLine);
            outputTextBox.AppendText(command);
            outputTextBox.AppendText(Environment.NewLine);

            // Create process info
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + command;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.WorkingDirectory = Directory.GetCurrentDirectory();

            // Start the process
            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();

                // Create stream readers for output and error streams
                using (StreamReader outputReader = process.StandardOutput)
                using (StreamReader errorReader = process.StandardError)
                {
                    // Read output and error streams asynchronously
                    Task<string> outputTask = outputReader.ReadToEndAsync();
                    Task<string> errorTask = errorReader.ReadToEndAsync();

                    // Wait for both tasks to complete
                    Task.WaitAll(outputTask, errorTask);

                    // Display output and error
                    string output = outputTask.Result;
                    string error = errorTask.Result;

                    if (command.Equals("cls", StringComparison.OrdinalIgnoreCase))
                    {
                        // Clear the output textbox
                        outputTextBox.Clear();

                        // Append current working directory to output textbox
                        outputTextBox.AppendText(Directory.GetCurrentDirectory() + ">");

                        return "";
                    }

                    if (command.StartsWith("cd ", StringComparison.OrdinalIgnoreCase))
                    {
                        // Extract the new directory from the command
                        string newDirectory = command.Substring(3).Trim();

                        // Check if the user entered a special folder name like "temp" or "appdata"
                        if (newDirectory.Equals("temp", StringComparison.OrdinalIgnoreCase))
                        {
                            // If the user entered "temp", change to the %temp% special folder
                            string specialFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                            specialFolderPath = Path.Combine(specialFolderPath, "Temp");

                            try
                            {
                                // Attempt to change the current directory
                                Directory.SetCurrentDirectory(specialFolderPath);

                                // Update the prompt to show the new directory
                                string prompt = $"{Directory.GetCurrentDirectory()}> ";
                                output = output.Replace($"{Directory.GetCurrentDirectory()}> ", prompt);
                            }
                            catch (Exception ex)
                            {
                                // Display an error message if changing the directory fails
                                output = ex.Message;
                            }
                        }
                        else if (newDirectory.Equals("appdata", StringComparison.OrdinalIgnoreCase))
                        {
                            // If the user entered "appdata", change to the %appdata% special folder
                            string specialFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                            try
                            {
                                // Attempt to change the current directory
                                Directory.SetCurrentDirectory(specialFolderPath);

                                // Update the prompt to show the new directory
                                string prompt = $"{Directory.GetCurrentDirectory()}> ";
                                output = output.Replace($"{Directory.GetCurrentDirectory()}> ", prompt);
                            }
                            catch (Exception ex)
                            {
                                // Display an error message if changing the directory fails
                                output = ex.Message;
                            }
                        }
                        else if (newDirectory.Equals("startup", StringComparison.OrdinalIgnoreCase))
                        {
                            // If the user entered "startup", change to the %appdata%\Microsoft\Windows\Start Menu\Programs\Startup special folder
                            string specialFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                            specialFolderPath = Path.Combine(specialFolderPath, "Microsoft\\Windows\\Start Menu\\Programs\\Startup");

                            try
                            {
                                // Attempt to change the current directory
                                Directory.SetCurrentDirectory(specialFolderPath);

                                // Update the prompt to show the new directory
                                string prompt = $"{Directory.GetCurrentDirectory()}> ";
                                output = output.Replace($"{Directory.GetCurrentDirectory()}> ", prompt);
                            }
                            catch (Exception ex)
                            {
                                // Display an error message if changing the directory fails
                                output = ex.Message;
                            }
                        }
                        else
                        {
                            try
                            {
                                // Attempt to change the current directory
                                Directory.SetCurrentDirectory(newDirectory);

                                // Update the prompt to show the new directory
                                string prompt = $"{Directory.GetCurrentDirectory()}> ";
                                output = output.Replace($"{Directory.GetCurrentDirectory()}> ", prompt);
                            }
                            catch (Exception ex)
                            {
                                // Display an error message if changing the directory fails
                                output = ex.Message;
                            }
                        }
                    }


                    // Append output and error to output textbox
                    outputTextBox.AppendText(output);
                    outputTextBox.AppendText(error);

                    // Append current working directory to output textbox
                    outputTextBox.AppendText(Environment.NewLine);
                    outputTextBox.AppendText(Directory.GetCurrentDirectory() + ">");

                    return output + error;
                }
            }
        }

    }
}
