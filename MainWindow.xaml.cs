using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace task_reminder_demo_cs
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Placeholder visibility logic
        private void UserInputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceholderTextBlock.Visibility = string.IsNullOrWhiteSpace(UserInputTextBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void UserInputTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderTextBlock.Visibility = Visibility.Collapsed;
        }

        private void UserInputTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserInputTextBox.Text))
            {
                PlaceholderTextBlock.Visibility = Visibility.Visible;
            }
        }

        // Double-click on task: mark done or remove
        private void ChatListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ChatListView.SelectedItem is string selectedTask)
            {
                if (!selectedTask.Contains("[Status: Done]"))
                {
                    int index = ChatListView.Items.IndexOf(selectedTask);
                    ChatListView.Items[index] = $"{selectedTask} [Status: Done]";
                }
                else
                {
                    ChatListView.Items.Remove(selectedTask);
                }
            }
        }

        // Submit button click logic
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInputTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Question field is required!", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (input.ToLower().Contains("add task"))
            {
                string formattedDate = DateTime.Now.ToString("yyyy-MM-dd");
                string formattedTime = DateTime.Now.ToString("HH:mm:ss");

                string taskEntry = $"User: {input}\nDate: {formattedDate} | Time: {formattedTime}";
                ChatListView.Items.Add(taskEntry);
                ChatListView.ScrollIntoView(ChatListView.Items[ChatListView.Items.Count - 1]);
                UserInputTextBox.Clear();
            }
        }
    }
}
