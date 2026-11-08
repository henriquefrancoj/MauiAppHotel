namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
	App PropriedadesApp;
	public ContratacaoHospedagem()
	{
		InitializeComponent();

		PropriedadesApp = (App)Application.Current;

		pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

		DateTime hoje = DateTime.Today;

		dtpck_checkin.MinimumDate = hoje;
		dtpck_checkin.MaximumDate = hoje.AddMonths(2);

		DateTime dataCheckin = dtpck_checkin.Date ?? DateTime.Today;

		dtpck_checkout.Date = dataCheckin.AddDays(1);
		dtpck_checkout.MinimumDate = dataCheckin.AddDays(1);
		dtpck_checkout.MaximumDate = dataCheckin.AddMonths(3);
	}
	private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			if (pck_quarto.SelectedItem is not Models.Quarto quarto)
			{
				await DisplayAlertAsync("Atenção", "Selecione uma suíte.", "OK");
				return;
			}

			if (stp_adultos.Value + stp_criancas.Value <= 0)
			{
				await DisplayAlertAsync("Atenção", "Informe pelo menos um hóspede.", "OK");
				return;
			}

			if (dtpck_checkout.Date <= dtpck_checkin.Date)
			{
				await DisplayAlertAsync("Atenção", "A data de checkout deve ser posterior ao check-in.", "OK");
				return;
			}

			DateTime dataCheckin = dtpck_checkin.Date ?? DateTime.Today;
			DateTime dataCheckout = dtpck_checkout.Date ?? dataCheckin.AddDays(1);

			await Navigation.PushAsync(new Views.HospedagemContratada(
				(int)stp_adultos.Value,
				(int)stp_criancas.Value,
				dataCheckin,
				dataCheckout,
				quarto));
		}	catch (Exception ex)
		{
			await DisplayAlertAsync("Ops", ex.Message, "OK");
		}

    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
		try
		{
			Navigation.PushAsync(new Views.SobreDev());

		}	catch (Exception ex)
		{
			DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

	private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
		DateTime dataSelecionadaCheckin = e.NewDate ?? DateTime.Today;
		dtpck_checkout.Date = dataSelecionadaCheckin.AddDays(1);
		dtpck_checkout.MinimumDate = dataSelecionadaCheckin.AddDays(1);
		dtpck_checkout.MaximumDate = dataSelecionadaCheckin.AddMonths(3);

    }
}