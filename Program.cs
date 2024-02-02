using System;

namespace BE_U1_W1_D5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // inizio del programma
            Console.WriteLine("======AGENZIA DELLE ENTRATE ======\n");
            Console.WriteLine("Ti diamo il benvenuto all'agenzia delle entrate.\n" +
                "Vorresti procedere con il calcolo dell'aliquota? (y/n)");
            string sceltaRegistrazione = Console.ReadLine();
            if (sceltaRegistrazione?.ToLower() == "y")
            {
                Registrazione(); // Registrazione del contribuente
            }
            else // Messaggio di uscita
            {
                Console.WriteLine("\nArrivederci, premi un tasto per chiudere lo sportello.");
                Console.ReadKey();
            }
        }
        // Registrazione del contribuente
        private static void Registrazione()
        {

            // Creazione di un nuovo contribuente
            Contribuente newContribuente = new Contribuente();

            // Inserimento dei dati del contribuente
            Console.WriteLine("\nInserisci il tuo nome:");
            newContribuente.Nome = Console.ReadLine();

            Console.WriteLine("\nInserisci il tuo cognome:");
            newContribuente.Cognome = Console.ReadLine();

            // Verifica che la data sia antecedente o uguale alla data attuale
            DateTime dataNascita;
            DateTime dataMinima = new DateTime(1890, 1, 1);


            while (true)
            {
                Console.WriteLine("\nInserisci la tua data di nascita (formato: dd/MM/yyyy):");

                if (DateTime.TryParse(Console.ReadLine(), out dataNascita))
                {
                    if (dataMinima <= dataNascita && dataNascita <= DateTime.Now.AddYears(-18)) // Verifica che la data sia antecedente o uguale alla data attuale
                    {
                        break;
                    }
                    else if (dataNascita > DateTime.Now) // Verifica che la data sia antecedente o uguale alla data attuale
                    {
                        Console.WriteLine("\nErrore! la data di nascita non può essere nel futuro. Riprova.\n");
                    }
                    else if (dataNascita > DateTime.Now.AddYears(-18)) // Verifica che la data sia antecedente o uguale alla data attuale
                    {
                        Console.WriteLine("\nErrore! Deve avere almeno 18 anni. Riprova.\n");
                    }
                    else // Verifica che la data sia antecedente o uguale alla data attuale
                    {
                        Console.WriteLine("\nERRORE: La data di nascita deve essere superiore a " + dataMinima.ToString("dd/MM/yyyy") + ". Riprova.\n");
                    }
                }
                else //
                {
                    Console.WriteLine("\nERRORE: Formato data non valido. Inserisci la data nel formato dd/MM/yyyy.\n");
                }
            }

            newContribuente.DataNascita = dataNascita;

            // Verifica che il codice fiscale sia di 16 caratteri
            string codiceFiscale;

            do
            {
                Console.WriteLine("\nInserisci il Codice Fiscale:");
                codiceFiscale = Console.ReadLine();

                if (codiceFiscale.Length != 16)
                {
                    Console.WriteLine("\nERRORE: Il Codice Fiscale deve essere di 16 caratteri.");
                }
            }
            while (codiceFiscale.Length != 16);

            newContribuente.CodiceFiscale = codiceFiscale;


            // richiesta del sesso
            Console.WriteLine("\nInserire il Sesso:");
            newContribuente.Sesso = Console.ReadLine();

            // richiesta del comune di residenza
            Console.WriteLine("\nInserire il Comune di Residenza:");
            newContribuente.ComuneResidenza = Console.ReadLine();

            // richiesta del reddito annuale
            while (true)
            {
                Console.WriteLine("\nInserire il Reddito Annuale:");
                if (double.TryParse(Console.ReadLine(), out double redditoAnnuale))
                {
                    newContribuente.RedditoAnnuale = redditoAnnuale;
                    break;
                }
                Console.WriteLine("ERRORE: Inserire un numero valido. ( CARATTERE INVALIDO ) ");
                Console.WriteLine("CONSIGLIO: Utilizzare il punto al posto della virgola.\n ");
            }

            Console.WriteLine("======REGISTRAZIONE EFFETUATA======\n");

            CalcolaRedditoNetto(newContribuente);
        }
        // Calcola l'aliquota e l'imposta da versare
        public static void CalcolaRedditoNetto(Contribuente contribuente)
        {
            Console.WriteLine("\nVorresti calcolare il tuo Reddito Netto? Y/n");
            string calcolareRedditoNetto = Console.ReadLine();
            if (calcolareRedditoNetto?.ToLower() == "y")
            {
                contribuente.CalcolaAliquota();
            }
            else
            {
                Console.WriteLine("\nArrivederci, premi un tasto per chiudere lo sportello.");
                Console.ReadLine();
                return; // Add return statement to exit the method
            }

            // Stampa dei risultati
            Console.WriteLine("\n======CALCOLO IMPOSTA DA VERSARE======");

            Console.WriteLine(">>> DATI PERSONALI <<<");
            Console.WriteLine($"Nome: {contribuente.Nome}");
            Console.WriteLine($"Cognome: {contribuente.Cognome}");
            Console.WriteLine($"Data di Nascita: {contribuente.DataNascita.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Luogo di Residenza: {contribuente.ComuneResidenza}");
            Console.WriteLine($"Codice Fiscale: {contribuente.CodiceFiscale}\n");

            Console.WriteLine(">>> REDDITO <<<");
            Console.WriteLine($"Reddito Lordo Dichiarato: {contribuente.RedditoAnnuale}");
            Console.WriteLine($"Reddito Netto: {contribuente.RedditoAnnualeNetto}\n");

            Console.WriteLine(">>> IMPOSTA DA VERSARE <<<");
            Console.WriteLine($"Importo dell'Imposta: {contribuente.Imposta}\n");

            Console.WriteLine("======ARRIVEDERCI======\n");

            Console.WriteLine("Grazie per aver completato la registrazione.");
            Console.WriteLine("Premi un tasto per chiudere lo sportello.");
            Console.ReadKey();
        }
    }
}
