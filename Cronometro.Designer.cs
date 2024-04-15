
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
    private int Milisegundo;

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
        botonRestablecer.Location = new System.Drawing.Point(200, 150);
        this.Controls.Add(botonRestablecer);

    }

    private void ContadorSec(object sender, ElapsedEventArgs e)
    {
        Milisegundo++;
        if (Milisegundo == 100)
        {
            segundos++;
            Milisegundo = 0;
        }
        if (segundos == 60)
        {
            minutos++;
            segundos = 0;
        }
        label.Text = minutos + ":" + segundos + ":" + Milisegundo;

    }

    private void IniciarDetenerCronometro(object sender, EventArgs e)
    {
        estoyDetenido = !estoyDetenido;
        //this.botonInicio.Text = estoyDetenido? "Detener" : "Iniciar";

        // string ui = if (estoyDetenido) return "DEt" else return "INI";
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
    #endregion
}
