namespace MauiAppHotel.Views;

public partial class ReservaConfirmada : ContentPage
{
    public ReservaConfirmada()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PopToRootAsync();
        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }
}
