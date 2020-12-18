using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ClientForm
{
    public partial class Form1 : Form
    {
        // Creo il socket client
        Socket client;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Connetti_Click(object sender, EventArgs e)
        {
            // Assegno il socket al client
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Creo le variabili per inserire l'indirizzo IP del server
            IPAddress ipAddress = null;
            int nPort = 0;

            // Provo a convertire l'indirizzo IP
            if (!IPAddress.TryParse(txt_ipserver.Text, out ipAddress))
            {
                MessageBox.Show("Indirizzo IP errato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); // Avviso all'utente dell'errore
                return;
                txt_ipserver.Text = null; // Pulisco la textbox
                txt_ipserver.Focus();
            }

            // Provo a convertire il numero di porta
            if (!int.TryParse(txt_porta.Text, out nPort))
            {
                MessageBox.Show("Numeri porta errato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); // Avviso all'utente dell'errore
                return;
                txt_porta.Focus();
                txt_porta.Text = null; // Pulisco la textbox
            }
            
            // Controllo se il numero di porta è errato
            if (nPort <= 0 || nPort >= 65535)
            {
                MessageBox.Show("Numero porta errato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error); // Avviso all'utente dell'errore
                return;
                txt_porta.Focus();
                txt_porta.Text = null; // Pulisco la textbox
            }

            try // Faccio la try/catch per evitare che l'errore mi fa chiudere il programma
            {
                // Connetto il client con il server
                client.Connect(ipAddress, nPort);

                // Controllo se il client si è connesso definivamente
                if (client.Connected)
                {
                    btn_Connetti.Text = "Connesso"; // Cambio il testo del button
                    txt_messaggio.Focus();

                    // Abilito la textbox e il button
                    txt_messaggio.Enabled = true;
                    btn_invia.Enabled = true;
                    btn_disconnetti.Enabled = true;

                    // Disabilito le textbox e il button
                    txt_ipserver.Enabled = false;
                    txt_porta.Enabled = false;
                    btn_Connetti.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Server non trovato", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information); // Avviso all'utente dell'errore
            }
        }

        private void btn_invia_Click(object sender, EventArgs e)
        {
            // Dichiarazione delle variabili
            byte[] sendbuffer = new byte[128]; // array di byte da inviare al server
            byte[] recvbuffer = new byte[128]; // array di byte da ricevere dal server
            string recvString = ""; // string per avere il testo del messaggio dal server
            int recvBytes = 0; // quantità di byte che contiene un messaggio dal server

            // Controllo se il client è connesso
            if (client.Connected)
            {
                // Controllo se la casella di testo non è vuota
                if (txt_messaggio.Text != "")
                {
                    // Controllo se nella casella di testo non contiene la parola "quit"
                    if (txt_messaggio.Text.ToUpper().Trim() != "QUIT")
                    {
                        // Invio il messaggio al server
                        sendbuffer = Encoding.ASCII.GetBytes(txt_messaggio.Text); // Converto il messaggio in byte per poi trasferirli nel buffer
                        client.Send(sendbuffer); // Invio il buffer al server
                        txt_messaggio.Focus();
                        Array.Clear(recvbuffer, 0, recvbuffer.Length); // Pulisco l'array di byte inviati al server

                        // Ricevo il messaggio dal server
                        recvBytes = client.Receive(recvbuffer); // Ricevo il buffer dal server e trasferisco la quantità di bytes nella variabile
                        recvString = Encoding.ASCII.GetString(recvbuffer, 0, recvBytes); // Converto il messaggio del server da byte in string
                        lst_messaggi.Items.Add("S: " + recvString); // Stampo la stringa del server
                        txt_messaggio.Text = null; // Pulisco la textbox
                    }
                    else
                    {
                        // Chiamo il metodo pr chiudere la connessione
                        ChiusuraConnessione();
                    }
                }
                else
                {
                    MessageBox.Show("Devi inserire un messaggio", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information); // Avviso all'utente dell'errore
                    txt_messaggio.Focus();
                }
            }
            else
            {
                MessageBox.Show("Client non è connesso", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information); // Avviso all'utente dell'errore
            }
        }

        private void btn_disconnetti_Click(object sender, EventArgs e)
        {
            // Chiamo il metodo pr chiudere la connessione
            ChiusuraConnessione();
        }

        public void ChiusuraConnessione()
        {
            client.Shutdown(SocketShutdown.Both); // Disabilito la connessione del client
            client.Close(); // Chiudo la connessione
            client.Dispose(); // Rilascia le risorse non gestite
            lst_messaggi.Items.Clear(); // Pulisco la listbox
            txt_ipserver.Text = null; // Pulisco la textbox
            txt_messaggio.Text = null; // Pulisco la textbox
            txt_porta.Text = null; // Pulisco la textbox
            txt_ipserver.Focus();
            btn_Connetti.Text = "Connetti";

            // Disabilito la textbox e il button
            txt_messaggio.Enabled = false;
            btn_invia.Enabled = false;
            btn_disconnetti.Enabled = false;

            // Abilito le textbox e il button
            txt_ipserver.Enabled = true;
            txt_porta.Enabled = true;
            btn_Connetti.Enabled = true;
        }
    }
}
