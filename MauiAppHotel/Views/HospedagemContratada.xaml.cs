using System.Globalization;
using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
	private readonly int adultos;
	private readonly int criancas;
	private readonly DateTime checkin;
	private readonly DateTime checkout;
	private readonly Quarto quarto;

	public HospedagemContratada(int adultos, int criancas, DateTime checkin, DateTime checkout, Quarto quarto)
	{
		InitializeComponent();

		this.adultos = adultos;
		this.criancas = criancas;
		this.checkin = checkin;
		this.checkout = checkout;
		this.quarto = quarto;

		TimeSpan periodo = checkout - checkin;
		double valorTotal = periodo.Days *
			((adultos * quarto.ValorDiariaAdulto) + (criancas * quarto.ValorDiariaCrianca));

		lbl_suite.Text = quarto.Descricao;
		lbl_adultos.Text = adultos.ToString();
		lbl_criancas.Text = criancas.ToString();
		lbl_checkin.Text = checkin.ToString("dd/MM/yyyy");
		lbl_checkout.Text = checkout.ToString("dd/MM/yyyy");
		lbl_estadia.Text = $"{periodo.Days} dia(s)";
		lbl_valor_total.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
	}

    private void Voltar_Inicio_Click(object sender, EventArgs e)
    {
		try
		{
			Navigation.PopAsync();
		} catch (Exception ex)
		{
			DisplayAlertAsync("Ops", ex.Message, "OK");
		}
    }

	private async void ConfReserva_Click(object sender, EventArgs e)
	{
		try
		{
			await Navigation.PushAsync(new ReservaConfirmada());
		}
		catch (Exception ex)
		{
			await DisplayAlertAsync("Ops", ex.Message, "OK");
		}
	}
}