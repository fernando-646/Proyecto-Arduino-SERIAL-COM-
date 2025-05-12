using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq.Expressions;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Proyecto_de_arduino

{
    public partial class Form1 : Form
    {
        SerialPort puertoSerial = new SerialPort();
        //string humedadTierra, humedadGeneral, agua, temperatura;
        private DateTime ultimaRespuesta = DateTime.Now;
        private bool arduinoActivo = false, arduinoOcupado = false; // Para evitar múltiples mensajes
        string humedadTierra = null, humedadGeneral = null, agua = null, temperatura = null, estado = null, conexion = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Contains("Selecciona puerto COM"))
            {
                MessageBox.Show("No se ha seleccionado ningun puerto COM.", "Sin puerto COM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (comboBox1.SelectedItem != null && !puertoSerial.IsOpen)
            {
                puertoSerial.PortName = ExtraerPuertoCOM(comboBox1.SelectedItem.ToString());
                puertoSerial.BaudRate = 9600; // Igual que en el Arduino
                if (!puertoSerial.IsOpen)
                {
                    try { puertoSerial.Open(); arduinoActivo = true; timer1.Enabled = true; }
                    catch (Exception serial)
                    {
                        MessageBox.Show("Error, el arduino se ha desconectado, porfavor intente de nuevo ");
                    }
                }
                //puertoSerial.Open();
                //timer1.Start(); // Empieza a leer datos
            }
        }


        /* private void timer(object sender, EventArgs e)
         {

             try
             {
                 if (puertoSerial.IsOpen && comboBox1.SelectedItem != null && puertoSerial.BytesToRead > 0)
                 {
                     //Debug.WriteLine("Puerto serial abierto, esperando lineas del arduino ");
                     ProcesarLinea(puertoSerial.ReadLine(), ref humedadTierra, ref humedadGeneral, ref agua, ref temperatura);
                     aguaBox.Clear(); humedadAmbienteBox.Clear(); humedadTierraBox.Clear(); temperaturaBox.Clear(); // Limpia los TextBox antes de actualizar
                     aguaBox.Text = agua; humedadAmbienteBox.Text = humedadGeneral; humedadTierraBox.Text = humedadTierra; temperaturaBox.Text = temperatura; // Actualiza los TextBox con los valores leídos
                 }
             }
             catch (IOException)
             {
                 MessageBox.Show("El dispositivo se ha desconectado.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 puertoSerial.Close();
                 // Aquí puedes desactivar botones, limpiar campos, etc.
             }
         }
        */
        private void timer(object sender, EventArgs e)
        {
            /*string linea = puertoSerial.ReadLine();
             // <- actualiza cuando recibe datos
            ; // <- reactivamos si antes estaba en "error"
            ProcesarLinea(linea, ref humedadTierra, ref humedadGeneral, ref agua, ref temperatura);*/
            if (puertoSerial.IsOpen && comboBox1.SelectedItem != null)
            {
                try
                {
                    Debug.Print("HOLA");
                    puertoSerial.Write("x");
                    // if (puertoSerial.BytesToRead > 0)
                    //{
                    string linea = puertoSerial.ReadLine();
                    ProcesarLinea(linea, ref humedadTierra, ref humedadGeneral, ref agua, ref temperatura, ref estado, ref conexion);

                    // Limpia y actualiza TextBoxes
                    aguaBox.Clear(); humedadAmbienteBox.Clear(); humedadTierraBox.Clear(); temperaturaBox.Clear();
                    label7.Text = "";
                    label8.Text = "";
                    label8.Text = "Estado de la conexión: " + conexion;
                    aguaBox.Text = agua; humedadAmbienteBox.Text = humedadGeneral;
                    humedadTierraBox.Text = humedadTierra; temperaturaBox.Text = temperatura;
                    label7.Text = "Estado del arduino: " + estado;
                    ultimaRespuesta = DateTime.Now;
                    arduinoActivo = true;

                    //}
                }
                catch (IOException)
                {
                    /*MessageBox.Show("El dispositivo se ha desconectado.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    puertoSerial.Close();*/
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("El puerto serial ya no está disponible.", "Puerto cerrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            /*if ((DateTime.Now - ultimaRespuesta).TotalSeconds > 7 && arduinoActivo)
            {
                arduinoActivo = false; // Solo mostramos una vez
                MessageBox.Show("El Arduino ha dejado de responder.", "Sin respuesta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Items.Clear();
                comboBox1.Text = "Selecciona puerto COM";
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string[] puertos = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            comboBox1.Text = "Selecciona puerto COM";
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%(COM%'"))
            {
                foreach (var device in searcher.Get())
                {
                    string nombre = device["Name"]?.ToString();
                    if (nombre != null && nombre.ToLower().Contains("usb"))
                    {
                        comboBox1.Items.Add(nombre);
                    }

                }
            }

        }
        public static string ExtraerPuertoCOM(string texto)
        {
            Match match = Regex.Match(texto, @"\bCOM\d+\b");
            return match.Success ? match.Value : null;
        }

        public static void ProcesarLinea(string linea, ref string humedadTierrax, ref string humedadGeneralx, ref string aguax, ref string temperaturax, ref string estado, ref string conexion)
        {
            var regex = new Regex(@"Sensor de (.+?):\s*(.+)");
            Match match = regex.Match(linea);

            if (match.Success)
            {
                //Debug.WriteLine("Hoal");
                string nombre = match.Groups[1].Value.Trim().ToLower();
                string valor = match.Groups[2].Value.Trim();
                //Debug.WriteLine(nombre);
                if (nombre.Equals("tierra"))
                    humedadTierrax = valor;
                else if (nombre.Equals("humedad general"))
                    humedadGeneralx = valor;
                else if (nombre.Equals("agua"))
                    aguax = valor;
                else if (nombre.Contains("temperatura"))
                    temperaturax = valor;
                else if (nombre.Contains("estado"))
                    estado = valor;
                else if (nombre.Contains("conexion"))
                    conexion = valor;

            }
        }
        private void button3_Click(object sender, EventArgs e) //Boton de paro manual 
        {
            if (puertoSerial.IsOpen && comboBox1.SelectedItem != null)
            {
                try
                {
                    //timer1.Enabled = false; // Detiene el temporizador
                    //puertoSerial.DiscardOutBuffer();
                    // puertoSerial.DiscardInBuffer();
                    timer1.Enabled = false; // Detiene el temporizador
                    puertoSerial.Close();
                    puertoSerial.Open();
                    puertoSerial.DiscardOutBuffer();
                    puertoSerial.DiscardInBuffer();
                    puertoSerial.Write("y");
                    timer1.Enabled = true; // Reactiva el temporizador

                    // LINEA DE PRUEBA ANRES DE VEREDICTO FINAL
                    //timer1.Enabled = true; // Reactiva el temporizador
                    //arduinoOcupado = false; // Desbloquea el puerto después de recibir la respuesta
                }
                catch (IOException)
                {
                    /*MessageBox.Show("El dispositivo se ha desconectado.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    puertoSerial.Close();*/
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("El puerto serial ya no está disponible.", "Puerto cerrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bombaManual_Click(object sender, EventArgs e) // Boton inicio manual
        {
            if (puertoSerial.IsOpen && comboBox1.SelectedItem != null)
            {
                try
                {
                    timer1.Enabled = false; // Detiene el temporizador
                    puertoSerial.Close();
                    puertoSerial.Open();
                    puertoSerial.DiscardOutBuffer();
                    puertoSerial.DiscardInBuffer();
                    puertoSerial.Write("z");
                    timer1.Enabled = true; /* Reactiva el temporizador  */
                }
                catch (IOException)
                {
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("El puerto serial ya no está disponible.", "Puerto cerrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void botonReincio_Click(object sender, EventArgs e)
        {
            /*if (puertoSerial.IsOpen && comboBox1.SelectedItem != null)
            {
                try
                {
                    arduinoOcupado = true;
                    puertoSerial.Write("a");
                    string linea = puertoSerial.ReadLine();
                    MessageBox.Show(linea, "Respuesta del arduino", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    arduinoOcupado = false; // Desbloquea el puerto después de recibir la respuesta
                }
                catch (IOException)
                {
                    /*MessageBox.Show("El dispositivo se ha desconectado.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    puertoSerial.Close();
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("El puerto serial ya no está disponible.", "Puerto cerrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
            if (puertoSerial.IsOpen && comboBox1.SelectedItem != null)
            {
                try
                {
                    timer1.Enabled = false; // Detiene el temporizador
                    puertoSerial.Close();
                    puertoSerial.Open();
                    puertoSerial.DiscardOutBuffer();
                    puertoSerial.DiscardInBuffer();
                    puertoSerial.Write("a");
                    timer1.Enabled = true;
                } // Reactiva el temporizador                }
                catch (IOException)
                {
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("El puerto serial ya no está disponible.", "Puerto cerrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}