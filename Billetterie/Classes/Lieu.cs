namespace Billetterie.Classes;

public class Lieu:Adresse
{
    public int Capacite { get; set; }

    public Lieu()
    {
    }
    
    public Lieu(string rue, string ville, int capacite) : base(rue, ville)
    {
        Capacite = capacite;
    }
}