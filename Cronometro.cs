using System.Timers;

namespace Cronometro.App;

public partial class Cronometro : Form
{
    private int milisegundo;

    private System.Timers.Timer timer;
    private int segundos;
    private int minutos;
    private const int tiempoDormido = 10;
    private bool estoyDetenido;


    public Cronometro()
    {
        InitializeComponent();
        //timer
        timer = new System.Timers.Timer(tiempoDormido);
        timer.Elapsed += ContadorSec;
    }


    private void ContadorSec(object? sender, ElapsedEventArgs e)
    {
        milisegundo++;
        if (milisegundo == 100)
        {
            segundos++;
            milisegundo = 0;
        }
        if (segundos == 60)
        {
            minutos++;
            segundos = 0;
        }
        //Devolver(segundos);
        label.Text = Devolver(minutos) + ":" + Devolver(segundos) + "." + Devolver(milisegundo);
    }

    private void IniciarDetenerCronometro(object? sender, EventArgs e)
    {
        estoyDetenido = !estoyDetenido;
        if (estoyDetenido)
        {
            timer.Start();
            botonInicio.Text = "Detener";
        }
        else
        {
            timer.Stop();
            botonInicio.Text = "Iniciar";
        }
    }

    // codigo para concatenar y mantener el orden de los segundos y minutos
    private string Devolver(int numero)
    {
        if (numero <= 9)
        {
            return "0" + numero.ToString();
        }
        else
        {
            return numero.ToString();
        }
    }
    private void DetenerCronometro(object? sender, EventArgs e)
    {
        timer.Stop();
        minutos = 0;
        segundos = 0;
        milisegundo = 0;
        label.Text = "00:00.00";

        botonInicio.Text = "Iniciar";
        estoyDetenido = false;
    }

}
