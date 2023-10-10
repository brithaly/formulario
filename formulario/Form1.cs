using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formulario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tbnombre.TextChanged += validarNombre;
            tbapellido.TextChanged += validarApellido;
            tbedad.TextChanged += validarEdad;
            tbestatura.TextChanged += validarEstatura;
            tbtelefono.TextChanged += validarTelefono;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            tbnombre.Clear();
            tbapellido.Clear();
            tbtelefono.Clear();
            tbedad.Clear();
            tbestatura.Clear();
            hombre.Checked =
                false;
            mujer.Checked =
                false;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            string nombre = tbnombre.Text;
            string apellido = tbapellido.Text;
            string edad = tbedad.Text;
            string estatura = tbestatura.Text;
            string telefono = tbtelefono.Text;

            string genero = "";
            if (hombre.Checked)
            {
                genero = "hombre";
            }
            else if (mujer.Checked)
            {
                genero = "mujer";
            }
            if (EsEnteroValido(edad) && EsDecimalValido(estatura) && EsEnteroValidode10Digitos(telefono) && EsTextoValido(nombre) && EsTextoValido(apellido))
            {
                string informacion = $"NOMBRE: {nombre}\r\nAPELLIDO: {apellido}\r\nTELEFONO: {telefono} \r\nESTATURA: {estatura} cm\r\nEDAD: {edad} años\r\nGENERO: {genero}";

                string rutaArchivo = "C:/Users/JBalv/britha/C#/formulario.txt";

                bool archivoExiste = File.Exists(rutaArchivo);

                if (archivoExiste == false) //CONDICIONALES PARA QUE GUARDE MULTIPLES DATOS EN EL ARCHIVO
                {
                    File.WriteAllText(rutaArchivo, informacion);
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(rutaArchivo, true)) //GUARDA LOS DATOS
                    {
                        if (archivoExiste)
                        {
                            writer.WriteLine("\n");
                        }
                        writer.WriteLine(informacion);
                    }
                }
                MessageBox.Show("datos guardados con exito!:\n\n" + informacion, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("PORFAVOR INGRESE INFORMACION EN LOS CAMPOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool EnteroValido(string valor)
        {
            int resultado;
            return int.TryParse(valor, out resultado);
        }
        private bool DecimalValido(string valor)
        {
            decimal resultado;
            return decimal.TryParse(valor, out resultado);
        }
        private bool EnteroValidode10Digitos(string valor)
        {
            long resultado;
            return long.TryParse(valor, out resultado) && valor.Length == 10;
        }
        private bool TextoValido(string valor)
        {
            return Regex.IsMatch(valor, @"^[a-zA-Z\s]+$");
        }

        private void validarEdad(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!EnteroValido(textBox.Text))
            {
                MessageBox.Show("Porfavor ingrese un valor valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Clear();
            }
        }
        private void validarEstatura(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!DecimalValido(textBox.Text))
            {
                MessageBox.Show("Porfavor ingrese un valor valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Clear();
            }
        }
        private void validarTelefono(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;

            if (input.Length > 10)
            {
                if (!EnteroValidode10Digitos(input))
                {
                    MessageBox.Show("Porfavor ingrese un valor valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Clear();
                }
                //} else if (!EsEnteroValidode10Digitos(input))
                //{
                //   MessageBox.Show("Porfavor ingrese un valor valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            private void validarNombre(object sender, EventArgs e)
            {
                TextBox textBox = (TextBox)sender;
                if (!TextoValido(textBox.Text))
                {
                    MessageBox.Show("Porfavor ingrese un valor valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Clear();
                }
            }
            private void validarApellido(object sender, EventArgs e)
            {
                TextBox textBox = (TextBox)sender;
                if (!TextoValido(textBox.Text))
                {
                    MessageBox.Show("Porfavor ingrese un valor valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Clear();
                }
            }
       
     }
}
    

