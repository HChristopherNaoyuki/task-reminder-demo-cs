# Task Reminder Application

## Overview

The Task Reminder application is a simple WPF (Windows Presentation Foundation) 
application that allows users to add tasks and manage them through a user-friendly 
interface. Users can input tasks, view them in a list, and mark them as done or 
remove them with a double-click.

## Features

- **Task Input**: Users can type tasks into an input box with a placeholder.
- **Task List**: A list view displays all added tasks.
- **Task Management**: Users can double-click on tasks to mark them as done or remove them from the list.
- **Date and Time Stamping**: Each task is timestamped with the current date and time when added.

## Technologies Used

- **C#**: The application is built using C# as the programming language.
- **WPF**: The user interface is created using Windows Presentation Foundation (WPF).
- **XAML**: The layout and design of the application are defined using XAML.

## Getting Started

### Prerequisites

- .NET Framework (version compatible with WPF)
- Visual Studio (or any compatible IDE)

### Installation

1. Clone the repository or download the source code.
2. Open the solution file (`.sln`) in Visual Studio.
3. Build the solution to restore any dependencies.
4. Run the application.

## Code Structure

### XAML Code

The main window is defined in XAML, which includes:

- A `ListView` for displaying tasks.
- A `TextBox` for user input with a placeholder.
- A `Button` to submit tasks.

```xml
<Window x:Class="task_reminder_demo_cs.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Task Reminder" Height="450" Width="800">

    <Grid Margin="10">
        <ListView x:Name="ChatListView" Width="760" Margin="10,0,10,115" MouseDoubleClick="ChatListView_MouseDoubleClick" />
        <Grid Height="30" Width="760" Margin="0,300,0,80" VerticalAlignment="Bottom">
            <TextBox x:Name="User InputTextBox" FontSize="14" VerticalContentAlignment="Center" 
                     TextChanged="User InputTextBox_TextChanged" GotFocus="User InputTextBox_GotFocus" 
                     LostFocus="User InputTextBox_LostFocus"/>
            <TextBlock x:Name="PlaceholderTextBlock" Text="Type 'add task' followed by your task..." 
                       FontStyle="Italic" Foreground="Gray" IsHitTestVisible="False" 
                       Margin="5,0,0,0" VerticalAlignment="Center" Visibility="Visible" />
        </Grid>
        <Button x:Name="SubmitButton" Content="Ask Question" Height="40" Width="760" 
                Margin="0,0,0,20" VerticalAlignment="Bottom" FontSize="16" Click="SubmitButton_Click" />
    </Grid>
</Window>
```

### C# Code

The logic for handling user interactions is implemented in the `MainWindow.xaml.cs` file, which includes:

- Event handlers for text changes, focus events, and button clicks.
- Logic for adding tasks and managing their status.

```csharp
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

                string taskEntry = $":User  {input}\nDate: {formattedDate} | Time: {formattedTime}";
                ChatListView.Items.Add(taskEntry);
                ChatListView.ScrollIntoView(ChatListView.Items[ChatListView.Items.Count - 1]);
                UserInputTextBox.Clear();
            }
        }
    }
}
```

## Usage

1. Launch the application.
2. Type a task in the input box, starting with "add task".
3. Click the "Ask Question" button or press Enter to add the task.
4. Double-click on a task in the list to mark it as done or remove it.

## Conclusion

The Task Reminder application is a straightforward tool for managing tasks. It provides a simple interface and essential features for task management, making it a useful utility for users looking to keep track of their tasks efficiently.

---
