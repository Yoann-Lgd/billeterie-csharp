using Billetterie.Classes;
using Billetterie.Utils;

namespace Billetterie;

public class IHM
{
    private List<Evenement> evenements = new List<Evenement>();
    private List<Client> clients = new List<Client>();

    static Adresse adresseArnaud = new Adresse("1 rue de la Paix","Paris");
    static Adresse adresseBeatrice = new Adresse("2 rue Du Barre","Chantilly");

    static Lieu lieuCinema = new Lieu("2 rue Mollinel","Lille", 20);
    static Lieu lieuTheatre = new Lieu("3 rue de la Paix","Paris", 40);

    private static Client clientArnaud = new Client("Arnaud", "Bernard", adresseArnaud, 23, "084343443");
    private static Client clientBeatrice = new Client("Gatrile", "Beatrice", adresseBeatrice, 32, "093723232");
    private Evenement evenementCinema = new Evenement("Roi lion", lieuCinema, "12/12/2024", "20h30", 2, new List<Billet>());
    private Evenement evenementTheatre = new Evenement("Sherlock holmes", lieuTheatre, "13/12/2024", "20h30", 40, new List<Billet>());


    public IHM()
    {
        evenements.Add(evenementCinema);
        evenements.Add(evenementTheatre);
        clients.Add(clientArnaud);
        clients.Add(clientBeatrice);
    }


    public void Program()
    {
        while (true)
        {
            AfficherMenu();
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    CreerEvenement();
                    break;
                case "2":
                    CreerClient();
                    break;
                case "3":
                    ReserverBillet();
                    break;
                case "4":
                    AfficherEvenements();
                    break;
                case "5":
                    AfficherClients();
                    break;
                case "6":
                    AfficherReservationsEvenement();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Option invalide");
                    break;
            }
        }
    }

    public void AfficherMenu()
    {
        Console.WriteLine("1. Créer un événement");
        Console.WriteLine("2. Créer un client");
        Console.WriteLine("3. Réserver un billet");
        Console.WriteLine("4. Afficher les événements");
        Console.WriteLine("5. Afficher les clients");
        Console.WriteLine("6. Voir les réservations d'un événement");
        Console.WriteLine("7. Quitter");
        Console.Write("Choisissez une option: ");
    }

    public void CreerClient()
    {
        Console.WriteLine("Le nom du client: ");
        string nom = Console.ReadLine();
        Console.WriteLine("Le prénom du client: ");
        string prenom = Console.ReadLine();
        Console.WriteLine("L'âge du client: ");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Le numéro de téléphone du client: ");
        string numTel = Console.ReadLine();
        Console.WriteLine("La rue du client: ");
        string rue = Console.ReadLine();
        Console.WriteLine("La ville du client: ");
        string ville = Console.ReadLine();
        Adresse adresse = new Adresse(rue, ville);
        Client client = new Client(nom, prenom, adresse, age, numTel);
        clients.Add(client);
    }

    public void CreerEvenement()
    {
        Console.Write("Nom de l'événement: ");
        string nom = Console.ReadLine();
        Console.Write("Date de l'événement: ");
        string date = Console.ReadLine();
        Console.Write("Heure de l'événement: ");
        string heure = Console.ReadLine();
        Console.Write("Quelle est la capacité de la salle : ");
        int capaciteLieu = int.Parse(Console.ReadLine());
        Console.Write("Nombre de places: ");
        int nbPlace = int.Parse(Console.ReadLine());
        Console.Write("Rue du lieu: ");
        string rueLieu = Console.ReadLine();
        Console.Write("Ville du lieu: ");
        string villeLieu = Console.ReadLine();
        Lieu lieu = new Lieu(rueLieu, villeLieu, capaciteLieu);
        Evenement evenement = new Evenement(nom, lieu, date, heure, nbPlace, new List<Billet>());
        evenements.Add(evenement);
    }

    public void ReserverBillet()
    {
        Console.WriteLine("Sélectionner un événement\n");
        Dictionary<int, Evenement> collectionEvement = ConverterList.ConvertListToDictionary(evenements);
        foreach (KeyValuePair<int, Evenement> ligneKVP in collectionEvement)
        {
            Console.WriteLine(ligneKVP.Key + " : " + ligneKVP.Value.ToString());
        }

        int indexChoixDictionnaire = int.Parse(Console.ReadLine());
        Evenement evenementChoisi = collectionEvement[indexChoixDictionnaire];

        if (!evenementChoisi.PlacesDisponibles())
        {
            Console.WriteLine("Désolé, il n'y a plus de place disponible pour cet événement");
            return;
        }

        Console.WriteLine("Sélectionner un client\n");
        Dictionary<int, Client> collectionClients = ConverterList.ConvertListToDictionary(clients);
        foreach (KeyValuePair<int, Client> ligneKVP in collectionClients)
        {
            Console.WriteLine(ligneKVP.Key + " : " + ligneKVP.Value.ToString());
        }

        int indexChoixClient = int.Parse(Console.ReadLine());
        Client clientChoisi = collectionClients[indexChoixClient];

        Console.WriteLine("Sélectionner un type de place");
        Console.WriteLine("1. Normal");
        Console.WriteLine("2. Gold");
        Console.WriteLine("3. Prenium");
        int typePlace = int.Parse(Console.ReadLine());
        TypePlace typePlaceChoisi = GetTypePlace(typePlace);

        Billet billet = new Billet(clientChoisi, evenementChoisi, typePlaceChoisi);
        evenementChoisi.AjouterBillet(billet);
        clientChoisi.AjouterBillet(billet);
    }

    public TypePlace GetTypePlace(int type)
    {
        switch (type)
        {
            case 1:
                return TypePlace.Standard;
            case 2:
                return TypePlace.Gold;
            case 3:
                return TypePlace.Prenium;
            default:
                throw new InvalidOperationException("Type de place invalide.");
        }
    }
    public void AfficherClients()
    {
        string lignesClient = "";
        foreach (Client client in clients)
        {
            lignesClient += client.ToString() + "\n";
        }
        Console.WriteLine("\n--- Liste des Clients ---\n");
        Console.WriteLine(lignesClient);
        Console.WriteLine("-------------------------");
    }
    public void AfficherEvenements()
    {
        string lignesEvenement = "";
        foreach (Evenement evenement in evenements)
        {
            lignesEvenement += evenement.ToString() + "\n";
        }
        Console.WriteLine("\n--- Liste des Clients ---\n");
        Console.WriteLine(lignesEvenement);
        Console.WriteLine("-------------------------");
    }

    public void AfficherReservationsEvenement()
    {
        Console.WriteLine("Sélectionner un événement\n");
        Dictionary<int, Evenement> collectionEvement = ConverterList.ConvertListToDictionary(evenements);
        foreach (KeyValuePair<int, Evenement> ligneKVP in collectionEvement)
        {
            Console.WriteLine(ligneKVP.Key + " : " + ligneKVP.Value.ToString());
        }

        int indexChoixDictionnaire = int.Parse(Console.ReadLine());
        Evenement evenementChoisi = collectionEvement[indexChoixDictionnaire];
        string lignesBillets = "";
        foreach (Billet billet in evenementChoisi.Billets)
        {
            lignesBillets += billet.ToString() + "\n";
        }
        Console.WriteLine("\n--- Liste des Billets ---\n");
        Console.WriteLine(lignesBillets);
        Console.WriteLine("-------------------------");
    }

}