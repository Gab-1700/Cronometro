
using System.Reflection.Metadata.Ecma335;
using System.Timers;

namespace Cronometro.App;

partial class Cronometro
{

    private System.ComponentModel.IContainer components = null;
    private Button botonInicio;
    private Boolean estoyDetenido;
    private int segundos;
    private int minutos;
    private const int tiempoDormido = 10;

    private Label label;
    private int milisegundo;

    private System.Timers.Timer timer;


    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(400, 200);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Cronometro";

        //timer
        timer = new System.Timers.Timer(tiempoDormido);
        timer.Elapsed += ContadorSec;


        label = new Label();
        label.Text = "00:00.00";
        label.Font = new Font("Arial", 20, FontStyle.Bold);
        label.Location = new System.Drawing.Point(130, 80);
        label.AutoSize = true;
        this.Controls.Add(label);

        botonInicio = new Button();
        botonInicio.Text = "Iniciar";
        botonInicio.Click += IniciarDetenerCronometro;
        botonInicio.Location = new System.Drawing.Point(100, 150);
        this.Controls.Add(botonInicio);

        Button botonRestablecer = new Button();
        botonRestablecer.Text = "Restablecer";
        botonRestablecer.Click += DetenerCronometro;
        botonRestablecer.Location = new System.Drawing.Point(200, 150);
        this.Controls.Add(botonRestablecer);

    }

    private void ContadorSec(object sender, ElapsedEventArgs e)
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

    private void IniciarDetenerCronometro(object sender, EventArgs e)
    {
        estoyDetenido = !estoyDetenido;
        if (estoyDetenido)
        {
            timer.Start();
            this.botonInicio.Text = "Detener";
        }
        else
        {
            timer.Stop();
            this.botonInicio.Text = "Iniciar";
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
    private void DetenerCronometro(object sender, EventArgs e)
    {
        timer.Stop();
        this.minutos = 0;
        this.segundos = 0;
        this.milisegundo = 0;
        label.Text = "00:00.00";

        botonInicio.Text = "Iniciar";
        estoyDetenido = false;

    }

    #endregion
}
