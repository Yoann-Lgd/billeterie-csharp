namespace Billetterie.Classes;

public class Billet
{
    public int NumPlace { get;  set; }
    public Client Client { get; set; }
    public Evenement Evenement { get; set; }
    public TypePlace TypePlace { get; set; }

    public Billet()
    {
    }

    public Billet(Client client, Evenement evenement, TypePlace typePlace)
    {
        NumPlace = evenement.Billets.Count + 1;
        Client = client;
        Evenement = evenement;
        TypePlace = typePlace;
    }

    public override string ToString()
    {
        return $"Billet n°{NumPlace} - {Client.Nom} {Client.Prenom} - {Evenement.Nom} - {TypePlace}";
    }
}