using System;
using System.Windows.Forms;
using Parcial2.Modelos;

namespace Parcial2
{
    internal class CFormPrincipal : Form
    {
        private CControladora controladora = new CControladora();

        private TextBox txtLegajo = new TextBox();
        private TextBox txtApellido = new TextBox();
        private TextBox txtNombre = new TextBox();
        private ComboBox cmbCategoria = new ComboBox();

        private ComboBox cmbTipoMaquina = new ComboBox();
        private TextBox txtCodigoMaquina = new TextBox();
        private TextBox txtMarca = new TextBox();
        private TextBox txtModelo = new TextBox();
        private TextBox txtCapacidad = new TextBox();

        private TextBox txtCodigoObra = new TextBox();
        private TextBox txtNombreObra = new TextBox();
        private TextBox txtUbicacion = new TextBox();

        private DateTimePicker dtpFecha = new DateTimePicker();
        private TextBox txtMaquinaAsignacion = new TextBox();
        private TextBox txtObraAsignacion = new TextBox();
        private TextBox txtOperadorAsignacion = new TextBox();
        private TextBox txtSalida = new TextBox();

        public CFormPrincipal()
        {
            Text = "AlquiObras S.A.";
            Width = 900;
            Height = 610;
            StartPosition = FormStartPosition.CenterScreen;

            CrearControles();
        }

        private void CrearControles()
        {
            GroupBox grupoOperador = CrearGrupo("Operador", 10, 10, 410, 145);
            AgregarCampo(grupoOperador, "Legajo", txtLegajo, 10, 25);
            AgregarCampo(grupoOperador, "Apellido", txtApellido, 210, 25);
            AgregarCampo(grupoOperador, "Nombre", txtNombre, 10, 75);
            AgregarCampo(grupoOperador, "Categoría", cmbCategoria, 210, 75);
            cmbCategoria.Items.AddRange(new object[] { "A", "B", "C" });
            cmbCategoria.SelectedIndex = 0;
            AgregarBoton(grupoOperador, "Registrar operador", 280, 105, RegistrarOperador);

            GroupBox grupoMaquina = CrearGrupo("Máquina", 440, 10, 430, 190);
            AgregarCampo(grupoMaquina, "Tipo", cmbTipoMaquina, 10, 25);
            cmbTipoMaquina.Items.AddRange(new object[] { "Básica", "Pesada", "Grúa" });
            cmbTipoMaquina.SelectedIndex = 0;
            AgregarCampo(grupoMaquina, "Código", txtCodigoMaquina, 220, 25);
            AgregarCampo(grupoMaquina, "Marca", txtMarca, 10, 75);
            AgregarCampo(grupoMaquina, "Modelo", txtModelo, 220, 75);
            AgregarCampo(grupoMaquina, "Capacidad", txtCapacidad, 10, 125);
            AgregarBoton(grupoMaquina, "Registrar máquina", 255, 150, RegistrarMaquina);

            GroupBox grupoObra = CrearGrupo("Obra", 10, 170, 410, 145);
            AgregarCampo(grupoObra, "Código", txtCodigoObra, 10, 25);
            AgregarCampo(grupoObra, "Nombre", txtNombreObra, 210, 25);
            AgregarCampo(grupoObra, "Ubicación", txtUbicacion, 10, 75);
            AgregarBoton(grupoObra, "Registrar obra", 280, 105, RegistrarObra);

            GroupBox grupoAsignacion = CrearGrupo("Asignación", 440, 215, 430, 145);
            AgregarCampo(grupoAsignacion, "Fecha", dtpFecha, 10, 25);
            AgregarCampo(grupoAsignacion, "Máquina", txtMaquinaAsignacion, 220, 25);
            AgregarCampo(grupoAsignacion, "Obra", txtObraAsignacion, 10, 75);
            AgregarCampo(grupoAsignacion, "Legajo", txtOperadorAsignacion, 220, 75);
            AgregarBoton(grupoAsignacion, "Registrar asignación", 245, 105, RegistrarAsignacion);

            Button btnOperadores = new Button();
            btnOperadores.Text = "Listar operadores";
            btnOperadores.SetBounds(10, 335, 160, 30);
            btnOperadores.Click += ListarOperadores;
            Controls.Add(btnOperadores);

            Button btnMaquinas = new Button();
            btnMaquinas.Text = "Listar máquinas";
            btnMaquinas.SetBounds(180, 335, 160, 30);
            btnMaquinas.Click += ListarMaquinas;
            Controls.Add(btnMaquinas);

            txtSalida.Multiline = true;
            txtSalida.ReadOnly = true;
            txtSalida.ScrollBars = ScrollBars.Vertical;
            txtSalida.SetBounds(10, 380, 860, 170);
            Controls.Add(txtSalida);
        }

        private GroupBox CrearGrupo(string titulo, int x, int y, int ancho, int alto)
        {
            GroupBox grupo = new GroupBox();
            grupo.Text = titulo;
            grupo.SetBounds(x, y, ancho, alto);
            Controls.Add(grupo);
            return grupo;
        }

        private void AgregarCampo(Control padre, string texto, Control campo, int x, int y)
        {
            Label etiqueta = new Label();
            etiqueta.Text = texto + ":";
            etiqueta.SetBounds(x, y, 90, 20);
            padre.Controls.Add(etiqueta);

            campo.SetBounds(x + 90, y, 100, 23);
            padre.Controls.Add(campo);
        }

        private void AgregarBoton(Control padre, string texto, int x, int y, EventHandler evento)
        {
            Button boton = new Button();
            boton.Text = texto;
            boton.SetBounds(x, y, 120, 25);
            boton.Click += evento;
            padre.Controls.Add(boton);
        }

        private void RegistrarOperador(object? sender, EventArgs e)
        {
            ulong legajo;
            if (!ulong.TryParse(txtLegajo.Text, out legajo))
            {
                Mostrar("El legajo debe ser numérico.");
                return;
            }

            COperador operador = new COperador(legajo, txtApellido.Text, txtNombre.Text, cmbCategoria.Text);
            Mostrar(controladora.RegistrarOperador(operador) ? "Operador registrado." : "Legajo duplicado.");
        }

        private void RegistrarMaquina(object? sender, EventArgs e)
        {
            IMaquina maquina;

            if (cmbTipoMaquina.Text == "Básica")
            {
                maquina = new CMaquinas(txtCodigoMaquina.Text, txtMarca.Text, txtModelo.Text, true);
            }
            else if (cmbTipoMaquina.Text == "Pesada")
            {
                maquina = new CMaquinas(txtCodigoMaquina.Text, txtMarca.Text, txtModelo.Text, false);
            }
            else
            {
                double capacidad;
                if (!double.TryParse(txtCapacidad.Text, out capacidad) || capacidad <= 0)
                {
                    Mostrar("La capacidad debe ser un número mayor a cero.");
                    return;
                }
                maquina = new CGrua(txtCodigoMaquina.Text, txtMarca.Text, txtModelo.Text, capacidad);
            }

            Mostrar(controladora.RegistrarMaquina(maquina) ? "Máquina registrada." : "Código duplicado.");
        }

        private void RegistrarObra(object? sender, EventArgs e)
        {
            CObra obra = new CObra(txtCodigoObra.Text, txtNombreObra.Text, txtUbicacion.Text);
            Mostrar(controladora.RegistrarObra(obra) ? "Obra registrada." : "Código duplicado.");
        }

        private void RegistrarAsignacion(object? sender, EventArgs e)
        {
            try
            {
                ulong legajo = ulong.Parse(txtOperadorAsignacion.Text);
                controladora.RegistrarAsignacion(dtpFecha.Value, txtMaquinaAsignacion.Text,
                    txtObraAsignacion.Text, legajo);
                Mostrar("Asignación registrada.");
            }
            catch (Exception ex)
            {
                Mostrar("Error: " + ex.Message);
            }
        }

        private void ListarOperadores(object? sender, EventArgs e)
        {
            txtSalida.Clear();
            foreach (IOperador operador in controladora.ObtenerOperadores())
            {
                txtSalida.AppendText(operador.Legajo + " - " + operador.Apellido + ", " +
                                      operador.Nombre + " - Categoría " + operador.Categoria + Environment.NewLine);
            }
        }

        private void ListarMaquinas(object? sender, EventArgs e)
        {
            txtSalida.Clear();
            foreach (IMaquina maquina in controladora.ObtenerMaquinas())
            {
                txtSalida.AppendText(maquina.Codigo + " - " + maquina.Marca + " " + maquina.Modelo +
                                      " (" + maquina.GetType().Name + ")" + Environment.NewLine);
            }
        }

        private void Mostrar(string mensaje)
        {
            txtSalida.AppendText(mensaje + Environment.NewLine);
        }
    }
}
