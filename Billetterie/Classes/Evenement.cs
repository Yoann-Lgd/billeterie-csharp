namespace Billetterie.Classes;

public class Evenement
{
    public string Nom { get; set; }
    public Lieu Lieu { get; set; }
    public string Date { get; set; }
    public string Heure { get; set; }
    private int _nbPlace;
    public List<Billet> Billets { get; set; }

    public Evenement()
    {
        Billets = new List<Billet>();
    }

    public Evenement(string nom, Lieu lieu, string date, string heure, int nbPlace, List<Billet> billets)
    {
        Nom = nom;
        Lieu = lieu;
        Date = date;
        Heure = heure;
        NbPlace = nbPlace;
        Billets = billets;
    }
    
    public void AjouterBillet(Billet billet)
    {
        if (Billets.Count < NbPlace)
        {
            Billets.Add(billet);
        }
        else
        {
            throw new InvalidOperationException("Désolé, il n'y a plus de place disponible pour cet événement");
        }
    }
    
    public int NbPlace
    {
        get => _nbPlace;
        set
        {
            if (Lieu == null)
            {
                throw new InvalidOperationException("Le lieu ne peut pas être null");
            }
            if (value > Lieu.Capacite)
            {
                Console.WriteLine($"{value}");
            }
            _nbPlace = value;
        }
    }

    public bool PlacesDisponibles()
    {
        return Billets.Count < NbPlace;
        
    }
    
    public override string ToString()
    {
        return Lieu != null 
            ? $"{Nom} - {Lieu.Ville} - nombre de places: {NbPlace} - capacité : {Lieu.Capacite} - places disponibles : {NbPlace - Billets.Count} - date: {Date} - heure: {Heure}" 
            : $"{Nom} - Lieu non défini - nombre de places: {NbPlace} - date: {Date} - heure: {Heure}";
    }
    
}