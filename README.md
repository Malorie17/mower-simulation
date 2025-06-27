# Prérequis

Pour exécuter ce projet, il faut avoir les éléments suivants :

    SDK .NET 8.0 ou supérieur. Téléchargeable depuis le site officiel de .NET.

    make pour utiliser le Makefile fourni.


# Exécution

Pour exécuter le code, il faut utiliser le Makefile depuis la racine du projet ou directement le CLI .NET.

Depuis la racine du projet :

    make run

Cela va construire le projet et exécuter le simulateur avec src/QwantApp/input.txt comme fichier d'entrée par défaut.

Manuellement avec le CLI .NET :

    dotnet run --project src/QwantApp/QwantApp.csproj -- src/QwantApp/Inputs/input.txt


#Exécution des Tests

Exécuter tous les tests (Unitaires + Intégration) :

    make test

Exécuter uniquement les tests unitaires :

    make unit_test

Exécuter uniquement les tests d'intégration :

    make integration_test

Nettoyage

Pour supprimer les fichiers de compilation (bin/ et obj/) :

    make clean
