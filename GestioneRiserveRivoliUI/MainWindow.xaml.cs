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

        string[] nomiVolontari = new string[2] { "Lorem Ipsum", "Pietro Negro" };
        int[] giorniRiserva = new int[2] { 0, 0 };


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
                MessageBox.Show("Errore! La data inserita non è valida, riprova.");
            }
            catch(System.FormatException)
            {
                MessageBox.Show("Errore! Inserisci una data valida.");
            }

            string volontarioDaCercare = TxTNomeUtente.Text;
            int indiceVolontario = 0;

            for (int i = 0; i < nomiVolontari.Length; i++)
            {
                if (nomiVolontari[i] == volontarioDaCercare)
                {
                    giorniRiserva[i] += numeroGiorni;
                    indiceVolontario = i;
                }
            }

            giorniRiserva[indiceVolontario] += numeroGiorni;
            MessageBox.Show("Il Volontario " + volontarioDaCercare + " ha usato in totale " + giorniRiserva[indiceVolontario] + " giorni di riserva!");

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