using System;

namespace BE_U1_W1_D5
{
    internal class Contribuente
    {
        // Proprietà del contribuente
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public string Sesso { get; set; }
        public string ComuneResidenza { get; set; }
        public double RedditoAnnuale { get; set; }
        public double Imposta { get; private set; }
        public double RedditoAnnualeNetto { get; private set; }
        // Metodo per calcolare l'aliquota
        public double CalcolaAliquota()
        {
            // Calcolo dell'imposta
            switch (RedditoAnnuale)
            {
                // Calcolo dell'imposta in base al reddito annuale
                case var reddito when reddito < 15000:
                    Imposta = RedditoAnnuale * 23 / 100;
                    break;
                case var reddito when reddito < 28000:
                    Imposta = 3450 + ((RedditoAnnuale - 15000) * 27 / 100);
                    break;
                case var reddito when reddito < 55000:
                    Imposta = 6960 + ((RedditoAnnuale - 28000) * 38 / 100);
                    break;
                case var reddito when reddito < 75000:
                    Imposta = 17220 + ((RedditoAnnuale - 55000) * 41 / 100);
                    break;
                case var reddito when reddito > 75000:
                    Imposta = 25420 + ((RedditoAnnuale - 75900) * 43 / 100);
                    break;
                // Messaggio di errore
                default:
                    Console.WriteLine("Reddito annuale non inserito. Riprova ad inserire");
                    Console.WriteLine("il tuo reddito annuale per effettuare il calcolo.");
                    break;
            }
            return RedditoAnnualeNetto = RedditoAnnuale - Imposta;
        }
    }
}
