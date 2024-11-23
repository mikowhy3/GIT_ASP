using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApp_ASP.Models.Services
{
    public class AppDbContext:DbContext
    {

        /*
         * DbSet<ContactEntity> Contacts – Właściwość typu DbSet<ContactEntity>, 
         * która reprezentuje kolekcję kontaktów w bazie danych. Każdy DbSet w DbContext 
         * odpowiada jednej tabeli w bazie danych. W tym przypadku tabela Contacts będzie 
         * przechowywać dane obiektów ContactEntity.
       
            Tworzy "most" między Twoją aplikacją a tabelą Contacts w bazie danych.
             Umożliwia wykonywanie operacji CRUD na danych w sposób obiektowy.
             Jest to kluczowy element mapowania encji (ContactEntity) na dane w bazie.
         * */

        public DbSet<ContactEntity> Contacts { get; set; }  

        //private string DbPath – Prywatna zmienna, która przechowuje ścieżkę do pliku bazy danych SQLite.
        //Będzie używana do ustalenia, gdzie zapisuje się baza danych na dysku.
        private string DbPath { get; set; }


        //Konstruktor AppDbContext ustawia ścieżkę do bazy danych.
        //Używa specjalnej lokalizacji (SpecialFolder.LocalApplicationData)
        //w systemie operacyjnym do zapisania pliku bazy danych SQLite.
        //Ścieżka do bazy danych będzie zawierać plik o nazwie contacts.db.
        public AppDbContext()
        {
            //Environment.SpecialFolder.LocalApplicationData to specjalny enum, który
            //reprezentuje standardowy katalog używany do przechowywania danych
            //aplikacji dla konkretnego użytkownika na komputerze.
            Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;


            //Environment.GetFolderPath(folder) pobiera pełną
            //ścieżkę do folderu określonego przez Environment.SpecialFolder.LocalApplicationData.
            string path = Environment.GetFolderPath(folder);

            //System.IO.Path.Join(path, "contacts.db") łączy ścieżkę path z nazwą pliku
            //contacts.db, tworząc pełną ścieżkę do pliku bazy danych.
            DbPath = System.IO.Path.Join(path, "contacts.db");
        }

        //OnConfiguring – Nadpisanie tej metody pozwala skonfigurować połączenie z bazą danych.
        //UseSqlite wskazuje, że będzie używana baza danych SQLite, a Data Source={DbPath} to
        //ścieżka do pliku bazy danych, którą określiliśmy wcześniej.


        //OnConfiguring to metoda wbudowana w DbContext, którą możesz przesłonić,
        //aby dostarczyć konfigurację dla bazy danych.
        //W tej metodzie ustawiasz szczegóły dotyczące połączenia z bazą danych oraz opcje jej działania.



        //Dlaczego jest przesłaniana(override)?

        //Domyślnie DbContext nie wie, z jaką bazą danych ma się połączyć.
        //Musisz to skonfigurować, podając szczegóły, takie jak typ bazy danych
        //(np.SQLite) oraz lokalizację bazy (DbPath w naszym przypadku).
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            //options to obiekt typu DbContextOptionsBuilder,
            //który służy do definiowania opcji dla kontekstu bazy danych.


            //UseSqlite() to metoda rozszerzająca, która:
            //Określa, że używaną bazą danych jest SQLite.
            //Przyjmuje ciąg połączenia(connection string), który wskazuje,
            //gdzie baza danych jest przechowywana.

            // baza danych przechowywana w naszym dbpath
            options.UseSqlite($"Data Source={DbPath}");
        }



        //OnModelCreating – Ta metoda jest wywoływana podczas konfigurowania modelu bazy danych.
        //Używając modelBuilder.Entity<ContactEntity>().HasData(), definiujemy początkowe dane,
        //które zostaną dodane do bazy danych po jej utworzeniu. W tym przypadku dodawane są
        //dwa przykładowe kontakty (ContactEntity).



        //Kiedy metoda OnModelCreating jest wywoływana?

        //Metoda jest wywoływana jednorazowo podczas tworzenia schematu bazy danych

        //Gdy wykonujesz migracje (np. dotnet ef migrations add).
        //Gdy aktualizujesz bazę danych poleceniem dotnet ef database update.
        //W przypadku automatycznego tworzenia bazy danych(np.podczas pierwszego uruchomienia
        //aplikacji, jeśli nie stosujesz migracji, a baza nie istnieje).
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Służy do wprowadzenia danych początkowych (seed data),
            //które zostaną zapisane w bazie danych zaraz po jej utworzeniu.

            //Encja ContactEntity nie tyle pobiera dane, ile definiuje, co znajduje się w tabeli w bazie.

            //Podsumowując: encja to po prostu "most" między tabelą SQL a twoim kodem aplikacji.
            //Dzięki niej pracujesz z obiektami, a nie z SQL bezpośrednio. 😊
            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() 
                { Id = 1, 
                    First_Name = "Adam",
                    Last_Name = "Kowalski",
                    Email = "adam@wsei.edu.pl", 
                    PhoneNumber = "127813268163", 
                    BirthDate = new DateOnly(2000, 10, 10) 
                }
                ,
                new ContactEntity() { 
                    Id = 2, 
                    First_Name = "Ewa",
                    Last_Name = "Nowak",
                    Email = "ewa@wsei.edu.pl", 
                    PhoneNumber = "293443823478", 
                    BirthDate = new DateOnly(1999, 8, 10) 
                }
            );
        }

    }
}
/*Dokładnie tak! Reasumując, proces wygląda następująco:

    Tworzenie tabeli Contacts:
        Właściwość DbSet<ContactEntity> w AppDbContext definiuje tabelę o nazwie Contacts, która odpowiada strukturze zdefiniowanej w klasie ContactEntity.

    Tworzenie ścieżki do bazy danych:
        W konstruktorze AppDbContext ustalamy, gdzie będzie znajdował się plik bazy danych:
            Environment.SpecialFolder.LocalApplicationData: Wskazuje folder lokalnych danych aplikacji (np. C:\Users\TwojeImię\AppData\Local).
            System.IO.Path.Join(path, "contacts.db"): Do ścieżki dodajemy nazwę pliku contacts.db.

    Konfiguracja połączenia z bazą danych:
        W metodzie OnConfiguring mówimy EF Core:
            UseSqlite($"Data Source={DbPath}"):
                Ścieżka z DbPath (np. C:\Users\TwojeImię\AppData\Local\contacts.db) jest przekazywana jako źródło danych.
                Określamy, że korzystamy z SQLite jako systemu zarządzania bazą danych.

    Przekazanie konfiguracji do SQLite:
        EF Core i SQLite wykorzystują przekazaną ścieżkę do:
            Znalezienia istniejącego pliku .db, jeśli istnieje.
            Automatycznego utworzenia nowego pliku .db, jeśli go brakuje.
        W ten sposób SQLite wie, gdzie przechowywać lub odczytywać dane.
*/