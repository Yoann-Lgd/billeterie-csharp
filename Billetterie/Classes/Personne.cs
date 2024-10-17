namespace Billetterie.Classes;

public abstract class Personne
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public Adresse Adresse { get; set; }
    public int age { get; set; }

    protected Personne()
    {
    }

    public Personne(string nom, string prenom, Adresse adresse, int age)
    {
        Nom = nom;
        Prenom = prenom;
        Adresse = adresse;
        this.age = age;
    }
}