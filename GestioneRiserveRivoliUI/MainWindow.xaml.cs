using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestioneRiserveRivoliUI
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string ScrivoValoriGG = "GG";
        string ScrivoValoriMM = "MM";
        string ScrivoValoriAAAA = "AA";


        private void BtnDati_Click(object sender, RoutedEventArgs e)
        {
            int giornoIniziaRiserva = 0;
            int meseInizioRiserva = 0;
            int annoInizioRiserva = 0;

            int giornoFineRiserva = 0; 
            int meseFineRiserva = 0;
            int annoFineRiserva = 0;
            int numeroGiorni = 0; 

            try
            {
             giornoIniziaRiserva = int.Parse(giornoInizio.Text); 
             meseInizioRiserva = int.Parse(MeseInizio.Text);
             annoInizioRiserva = int.Parse(AnnoInizio.Text);

             giornoFineRiserva = int.Parse(GiornoFine.Text);
             meseFineRiserva = int.Parse(MeseFine.Text);
             annoFineRiserva = int.Parse(AnnoFine.Text);

            DateTime dataInizioRiserva = new DateTime(annoInizioRiserva, meseInizioRiserva, giornoIniziaRiserva);
            DateTime dataFineRiserva = new DateTime(annoFineRiserva, meseFineRiserva, giornoFineRiserva);

            TimeSpan differenza = dataFineRiserva - dataInizioRiserva;
            numeroGiorni = differenza.Days;

            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Errore! Inserisci una data valida.");
            }
            catch(System.FormatException)
            {
                MessageBox.Show("Errore! Inserisci una data valida.");
            }

            string volontarioDaCercare = TxTNomeUtente.Text;

            


            // LAVORO CON IL DATABASE SQLITE

            // Faccio il setup del database
            var connectionStringMemory = "Data Source=:memory:";
            var connectionStringFile = "Data Source=dati.db";

            using var connection = new SQLiteConnection(connectionStringMemory);
            connection.Open();

            // Creo la tabella e inserisco i dati nella stessa transazione
            using var transaction = connection.BeginTransaction();
            using var cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Dati" +
                                              "(ID INTEGER PRIMARY KEY, nome TEXT, GiorniRiserva INTEGER)", connection);
            cmd.ExecuteNonQuery();

            using var paracmd = new SQLiteCommand("INSERT INTO Dati (nome) VALUES (@nome)", connection);
            paracmd.Parameters.AddWithValue("@nome", "Pietro Negro");
            paracmd.Parameters.AddWithValue("@GiorniRiserva", "15");
            paracmd.ExecuteNonQuery();
            transaction.Commit();

            using var readcmd = new SQLiteCommand("SELECT * FROM Dati", connection);
            using var reader = readcmd.ExecuteReader();


        }

        private void giornoInizio_GotFocus(object sender, RoutedEventArgs e)
        {
            if (giornoInizio.Text == "" || giornoInizio.Text == ScrivoValoriGG)
            {
                giornoInizio.Text = "";
            }
        }

        private void MeseInizio_GotFocus(object sender, RoutedEventArgs e)
        {
            if (MeseInizio.Text == "" || MeseInizio.Text == ScrivoValoriMM)
            {
            MeseInizio.Text = "";
            }
        }

        private void AnnoInizio_GotFocus(object sender, RoutedEventArgs e)
        {
            if (AnnoInizio.Text == "" || AnnoInizio.Text == ScrivoValoriAAAA)
            {
            AnnoInizio.Text = "";
            }
        }

        private void GiornoFine_GotFocus(object sender, RoutedEventArgs e)
        {
            if (GiornoFine.Text == "" || GiornoFine.Text == ScrivoValoriGG)
            {
            GiornoFine.Text = "";
            }
        }
        private void MeseFine_GotFocus(object sender, RoutedEventArgs e)
        {
            if (MeseFine.Text == "" || MeseFine.Text == ScrivoValoriMM)
            {
            MeseFine.Text = "";
            }

        }
        private void AnnoFine_GotFocus(object sender, RoutedEventArgs e)
        {
            if (AnnoFine.Text == "" || AnnoFine.Text == ScrivoValoriAAAA)
            {
                AnnoFine.Text = "";
            }
        }


        // INIZIO LOST FOCUS

        private void giornoInizio_LostFocus(object sender, RoutedEventArgs e)
        {
            if (giornoInizio.Text == "")
            {
                giornoInizio.Text = ScrivoValoriGG;
            }
        }

        private void MeseInizio_LostFocus(object sender, RoutedEventArgs e)
        {
            if (MeseInizio.Text == "")
            {
            MeseInizio.Text = ScrivoValoriMM;
            }
        }

        private void AnnoInizio_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AnnoInizio.Text == "")
            {
            AnnoInizio.Text = ScrivoValoriAAAA;
            }
        }

        private void GiornoFine_LostFocus(object sender, RoutedEventArgs e)
        {
            if (GiornoFine.Text == "")
            {
            GiornoFine.Text = ScrivoValoriGG;
            }
        }

        private void MeseFine_LostFocus(object sender, RoutedEventArgs e)
        {
            if (MeseFine.Text == "")
            {
            MeseFine.Text = ScrivoValoriMM;

            }
        }

        private void AnnoFine_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AnnoFine.Text == "")
            {
            AnnoFine.Text = ScrivoValoriAAAA;
            }
        }
    }

}