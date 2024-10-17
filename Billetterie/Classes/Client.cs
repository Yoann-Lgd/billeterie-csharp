namespace Billetterie.Classes;

public class Client:Personne
{
    public string NumTel { get; set; }
    public List<Billet> Billets { get; set; }

    public Client()
    {
        Billets = new List<Billet>();
    }

    public Client(string nom, string prenom, Adresse adresse, int age, string numTel) : base(nom, prenom, adresse, age)
    {
        NumTel = numTel;
        Billets = new List<Billet>();
    }

    public void AjouterBillet(Billet billet)
    {
        Billets.Add(billet);
    }
    
    public void ReserverBillet(Evenement evenement, int numeroPlace, TypePlace typePlace)
    {
        if (evenement.PlacesDisponibles())
        {
            Billet billet = new Billet(this, evenement, typePlace);
            evenement.AjouterBillet(billet);
            AjouterBillet(billet);
        }
        else
        {
            throw new InvalidOperationException("Aucune place disponible pour cet événement.");
        }
    }

    public override string ToString()
    {
        return $"{Nom} {Prenom} {age} ans - Habite à {Adresse.Ville}";
    }
}