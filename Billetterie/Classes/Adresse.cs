namespace Billetterie.Classes;

public class Adresse
{
    public string Rue { get; set; }
    public string Ville  { get; set; }

    public Adresse()
    {
        
    }
    public Adresse(string rue, string ville)
    {
        Rue = rue;
        Ville = ville;
    }

}