
namespace Cronometro.App;

partial class Cronometro
{

    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private Button botonInicio;
    private Boolean estoyDetenido = true;



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

        Label label = new Label();
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

    private void IniciarDetenerCronometro(object sender, EventArgs e)
    {


        if (estoyDetenido)
        {
            estoyDetenido = false;
            this.botonInicio.Text = "Detener";

        }
        else
        {
            estoyDetenido = true;
            this.botonInicio.Text = "Iniciar";
        }
    }

    #endregion
}
