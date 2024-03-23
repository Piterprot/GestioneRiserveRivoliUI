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
        string ScrivoValoriAAAA = "AAAA";

        string IndirizzoFile = @"F:\GestioneRiserveRivoliUI\GestioneRiserveRivoliUI\dati.csv";


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

            // LAVORO CON IL DATABASE
            try
            {
                StreamReader leggoDatabase = new StreamReader(IndirizzoFile);
                string LeggoStringa = leggoDatabase.ReadLine();
                string giorniRiservaVolontari = "";

                while (LeggoStringa != null)
                {
                    int primaVirgola = LeggoStringa.IndexOf(",");
                    string nomeVolontario = LeggoStringa.Substring(0, primaVirgola);

                    if (nomeVolontario == volontarioDaCercare)
                    {
                        giorniRiservaVolontari = LeggoStringa.Substring(primaVirgola + 1);
                        break; // Esci dal ciclo se il volontario è stato trovato
                    }

                    LeggoStringa = leggoDatabase.ReadLine(); // Leggi la prossima riga
                }


                MessageBox.Show(giorniRiservaVolontari);

                leggoDatabase.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Errore! Non trovo il DataBase!");
            }
            catch (IOException)
            {
                MessageBox.Show("Errore! Non riesco a trovare il file!");
            }
            // FINISCO IL LAVORO CON IL DB


        }

        private void giornoInizio_GotFocus(object sender, RoutedEventArgs e)
        {
            giornoInizio.Text = "";
        }

        private void MeseInizio_GotFocus(object sender, RoutedEventArgs e)
        {
            MeseInizio.Text = "";
        }

        private void AnnoInizio_GotFocus(object sender, RoutedEventArgs e)
        {
            AnnoInizio.Text = "";
        }

        private void GiornoFine_GotFocus(object sender, RoutedEventArgs e)
        {
            GiornoFine.Text = "";
        }
        private void MeseFine_GotFocus(object sender, RoutedEventArgs e)
        {
            MeseFine.Text = "";

        }
        private void AnnoFine_GotFocus(object sender, RoutedEventArgs e)
        {
            AnnoFine.Text = "";
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