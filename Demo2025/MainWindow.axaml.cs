using Avalonia.Controls;
using Demo2025.Models;
using System.Collections.Generic;

namespace Demo2025;

public partial class MainWindow : Window
{
    private List<Partner> displayList = Utils.Context.Partners;
    public MainWindow()
    {
        InitializeComponent();
        PartnersListBox.ItemsSource = displayList;
    }

    private void AddEditPartnerButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new AddEditWindow().Show();
        Close();
    }

    private void Border_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        new AddEditWindow(int.Parse((sender as Border).Tag.ToString())).Show();
        Close();
    }
}