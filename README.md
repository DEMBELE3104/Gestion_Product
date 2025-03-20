
MY INVENTORIST - Gestionnaire d'Inventaire

Description: 

MY INVENTORIST est un programme de gestion d'inventaire simple et efficace qui permet de gérer une liste de produits. Il offre plusieurs fonctionnalités telles que l'ajout, la suppression, la recherche de produits, ainsi que l'affichage des produits par catégorie et des statistiques d'inventaire. Les données sont sauvegardées dans un fichier JSON, garantissant ainsi la persistance des informations entre les exécutions du programme.

Fonctionnalités: 

Ajouter un produit : Permet d'ajouter un produit avec un nom, un prix et une catégorie.
Afficher les produits par catégorie : Affiche tous les produits regroupés par catégorie.
Rechercher un produit : Recherche des produits par nom ou par catégorie.
Supprimer un produit : Supprime un produit en fonction de son nom.
Afficher les statistiques : Affiche le nombre total de produits dans l'inventaire.
Sauvegarder et quitter : Sauvegarde l'inventaire dans un fichier JSON et quitte le programme.

Prérequis:

.NET Core 3.1 ou supérieur
Newtonsoft.Json (Pour la gestion des fichiers JSON)

Installation: 

Clonez ou téléchargez le projet.
Assurez-vous que le projet cible une version de .NET Core 3.1 ou supérieure.

Ajoutez la bibliothèque Newtonsoft.Json via NuGet :
bash : dotnet add package Newtonsoft.Json

Utilisation:

Exécutez le programme via la ligne de commande ou un IDE compatible.
Suivez les instructions affichées à l'écran pour interagir avec le menu et gérer l'inventaire.

Exemple d'utilisation :

Ajouter un produit : Ajoutez un produit avec un nom, un prix et une catégorie.
Afficher les produits : Consultez les produits par catégorie.
Rechercher un produit : Trouvez un produit par son nom ou sa catégorie.
Supprimer un produit : Supprimez un produit en fonction de son nom.
Statistiques : Consultez le nombre total de produits.

Fichier de sauvegarde: 

Les données de l'inventaire sont sauvegardées dans un fichier inventaire.json dans le répertoire racine du programme. Ce fichier contient une liste de produits en format JSON, garantissant la persistance des informations entre les sessions.

License
Ce projet est sous licence MIT.

Avec MY INVENTORIST, la gestion de votre inventaire devient simple et efficace !
