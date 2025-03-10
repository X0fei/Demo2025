using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Demo2025.Context;
using Demo2025.Models;
using Demo2025;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Numerics;
using Tmds.DBus.Protocol;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Demo2025;

public partial class AddEditWindow : Window
{
    private List<PartnerType> displayList = Utils.Context.PartnerTypes;
    int partnerID;
    public AddEditWindow()
    {
        InitializeComponent();
        Type.ItemsSource = displayList;
        EditButton.IsVisible = false;
    }
    public AddEditWindow(int partnerID)
    {
        InitializeComponent();
        this.partnerID = partnerID;
        Type.ItemsSource = displayList;
        AddButton.IsVisible = false;

        using (var context = new User21Context())
        {
            var partner = context.Partners.Find(this.partnerID);

            Name.Text = partner.Name;
            Type.SelectedIndex = partner.PartnerType - 1;
            Rating.Text = partner.Rating.ToString();
            Adress.Text = partner.Adress;
            Director.Text = partner.Director;
            Phone.Text = partner.Phone;
            Email.Text = partner.Email;
            TIN.Text = partner.Tin;
        }
    }

    private void AddPartnerButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (Check())
        {
            Partner partner = new Partner()
            {
                Name = Name.Text,
                PartnerType = Type.SelectedIndex + 1,
                Director = Director.Text,
                Email = Email.Text,
                Phone = Phone.Text,
                Adress = Adress.Text,
                Rating = Int32.Parse(Rating.Text),
                Tin = TIN.Text
            };
            using (var context = new User21Context())
            {
                context.Add(partner);
                context.SaveChanges();
            }
            Utils.Context.Partners = new List<Partner>(Utils.Context.DbContext.Partners.Include(partner => partner.PartnerTypeNavigation).Include(partner => partner.PartnersProducts));
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }

    private void GoBackButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new();
        mainWindow.Show();
        Close();
    }
    private bool Check()
    {
        int check;
        if (Type.SelectedIndex == -1)
        {
            ErrorTextBlock.IsVisible = true;
            return false;
        }
        if (!Int32.TryParse(Rating.Text, out check))
        {
            ErrorTextBlock.IsVisible = true;
            return false;
        }
        return true;
    }

    private void EditPartnerButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (Check())
        {
            using (var context = new User21Context())
            {
                var partner = context.Partners.Find(partnerID);

                partner.Name = Name.Text;
                partner.PartnerType = Type.SelectedIndex + 1;
                partner.Director = Director.Text;
                partner.Email = Email.Text;
                partner.Phone = Phone.Text;
                partner.Adress = Adress.Text;
                partner.Rating = Int32.Parse(Rating.Text);
                partner.Tin = TIN.Text;

                context.Update(partner);
                context.SaveChanges();
            }
            Utils.Context.Partners = new List<Partner>(Utils.Context.DbContext.Partners.Include(partner => partner.PartnerTypeNavigation).Include(partner => partner.PartnersProducts));
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }
}