using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

class Program
{
    static List<Produit> inventaire = new List<Produit>();
    private static double prix;

    static void Main()
    {
        AfficherIntroduction();
        ChargerInventaire();

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════╗");
            Console.WriteLine("║       GESTION D'INVENTAIRE       ║");
            Console.WriteLine("╠══════════════════════════════════╣");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("║ 1. Ajouter un produit            ║");
            Console.WriteLine("║ 2. Afficher les produits         ║");
            Console.WriteLine("║ 3. Rechercher un produit         ║");
            Console.WriteLine("║ 4. Supprimer un produit          ║");
            Console.WriteLine("║ 5. Afficher les statistiques     ║");
            Console.WriteLine("║ 6. Sauvegarder et quitter        ║");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚══════════════════════════════════╝");
            Console.ResetColor();

            Console.Write("Choisissez une option : ");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AjouterProduit();
                    break;
                case "2":
                    AfficherProduitsParCategorie();
                    break;
                case "3":
                    RechercherProduit();
                    break;
                case "4":
                    SupprimerProduit();
                    break;
                case "5":
                    AfficherStatistiques();
                    break;
                case "6":
                    SauvegarderInventaire();
                    Console.WriteLine("Fermeture du programme...");
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Option invalide !");
                    Console.ResetColor();
                    break;
            }

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
            Console.ReadKey();
        }
    }

    static void AfficherIntroduction()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(@"
███╗   ███╗██╗   ██╗    ██╗███╗   ██╗██╗   ██╗███╗   ██╗████████╗ ██████╗ ██████╗ ███████╗████████╗
████╗ ████║╚██╗ ██╔╝    ██║████╗  ██║██║   ██║████╗  ██║╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝╚══██╔══╝
██╔████╔██║ ╚████╔╝     ██║██╔██╗ ██║██║   ██║██╔██╗ ██║   ██║   ██║   ██║██████╔╝█████╗     ██║   
██║╚██╔╝██║  ╚██╔╝      ██║██║╚██╗██║██║   ██║██║╚██╗██║   ██║   ██║   ██║██╔══██╗██╔══╝     ██║   
██║ ╚═╝ ██║   ██║       ██║██║ ╚████║╚██████╔╝██║ ╚████║   ██║   ╚██████╔╝██║  ██║███████╗   ██║   
╚═╝     ╚═╝   ╚═╝       ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝  ╚═══╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚══════╝   ╚═╝   
        ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nBienvenue dans MY INVENTORIST - Votre gestionnaire d'inventaire intelligent !");
        Console.ResetColor();
        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
        Console.ReadKey();
    }

    static void ChargerInventaire()
    {
        if (File.Exists("inventaire.json"))
        {
            string json = File.ReadAllText("inventaire.json");
            inventaire = JsonConvert.DeserializeObject<List<Produit>>(json) ?? new List<Produit>();
        }
    }

    static void SauvegarderInventaire()
    {
        string json = JsonConvert.SerializeObject(inventaire, Formatting.Indented);
        File.WriteAllText("inventaire.json", json);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Inventaire sauvegardé avec succès !");
        Console.ResetColor();
    }

    static void AjouterProduit()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Ajout d'un produit");

        Console.Write("Nom du produit : ");
        string nom = Console.ReadLine().Trim();

        Console.Write("Prix du produit : ");
        while (!double.TryParse(Console.ReadLine(), out double prix))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Prix invalide !");
            Console.ResetColor();
            Console.Write("Prix du produit : ");
        }

        Console.Write("Catégorie du produit : ");
        string categorie = Console.ReadLine().Trim();

        inventaire.Add(new Produit(nom, prix, categorie));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Produit ajouté avec succès !");
        Console.ResetColor();

        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
        Console.ReadKey();
    }

    static void AfficherProduitsParCategorie()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Liste des produits par catégorie :\n");

        if (inventaire.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Aucun produit dans l'inventaire.");
        }
        else
        {
            var groupes = inventaire.GroupBy(p => p.Categorie).OrderBy(g => g.Key);
            foreach (var groupe in groupes)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"=== {groupe.Key.ToUpper()} ===");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var produit in groupe)
                {
                    Console.WriteLine(produit);
                }
                Console.WriteLine();
            }
        }
        Console.ResetColor();

        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
        Console.ReadKey();
    }

    static void RechercherProduit()
    {
        Console.Clear();
        Console.Write("Entrez un nom ou une catégorie : ");
        string recherche = Console.ReadLine().ToLower();

        var resultats = inventaire.Where(p => p.Nom.ToLower().Contains(recherche) || p.Categorie.ToLower().Contains(recherche)).ToList();

        if (resultats.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Aucun produit trouvé.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var produit in resultats)
            {
                Console.WriteLine(produit);
            }
        }
        Console.ResetColor();

        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
        Console.ReadKey();
    }

    static void SupprimerProduit()
    {
        Console.Clear();
        Console.Write("Nom du produit à supprimer : ");
        string nom = Console.ReadLine().ToLower();

        var produit = inventaire.Find(p => p.Nom.ToLower() == nom);

        if (produit != null)
        {
            inventaire.Remove(produit);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Produit supprimé !");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Produit non trouvé.");
        }
        Console.ResetColor();

        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
        Console.ReadKey();
    }

    static void AfficherStatistiques()
    {
        Console.Clear();
        Console.WriteLine($"Nombre total de produits : {inventaire.Count}");
        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
        Console.ReadKey();
    }
}

class Produit
{
    public string Nom { get; set; }
    public double Prix { get; set; }
    public string Categorie { get; set; }

    public Produit(string nom, double prix, string categorie)
    {
        Nom = nom;
        Prix = prix;
        Categorie = categorie;
    }

    public override string ToString() => $"Nom: {Nom} | Prix: {Prix}€";
}
