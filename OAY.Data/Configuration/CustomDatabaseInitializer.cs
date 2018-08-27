using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using OAY.Models;
using System.Collections.Generic;

namespace OAY.Data.Configuration
{
    //DropCreateDatabaseIfModelChanges<DataContext>
    //DropCreateDatabaseAlways<DataContext>
    public class CustomDatabaseInitializer :  CreateDatabaseIfNotExists<DataContext>  
    {          
        protected override void Seed(DataContext context)
        {
            //WebSecurity.InitializeDatabaseConnection("OAAzureDEV", "UserProfile", "UserId", "UserName", autoCreateTables: true);


            context.Batturer.AddOrUpdate(
                p => p.BatturId,
                new Battur
                {
                    BatturId = 1,
                    Beskrivelse = "Lorem Ipsum...",
                    EngelskBeskrivelse = "English Lorem Ipsum...",
                    MinimumTid = 3,
                    TilSted = "Hovedøya",
                    FraSted = "Oslo",
                    Ingress = "Ingress bla bla",
                    Overskrift = "Lunsjcruise i Oslofjorden"

                },
                new Battur
                {
                    BatturId = 2,
                    Beskrivelse = "Lorem Ipsum...",
                    EngelskBeskrivelse = "English Lorem Ipsum...",
                    MinimumTid = 3,
                    TilSted = "Kjeholmen",
                    FraSted = "Oslo",
                    Ingress = "Ingress bla bla",
                    Overskrift = "Kosetur i Oslofjorden"

                },
                new Battur
                {
                    BatturId = 3,
                    Beskrivelse = "Lorem Ipsum...",
                    EngelskBeskrivelse = "English Lorem Ipsum...",
                    MinimumTid = 2,
                    TilSted = "Bygdøy",
                    FraSted = "Oslo",
                    Ingress = "Ingress bla bla",
                    Overskrift = "Familietur i Oslofjorden"

                },
                new Battur
                {
                    BatturId = 4,
                    Beskrivelse = "Lorem Ipsum...",
                    EngelskBeskrivelse = "English Lorem Ipsum...",
                    MinimumTid = 2,
                    TilSted = "Oslo",
                    FraSted = "Oslo",
                    Ingress = "Ingress bla bla",
                    Overskrift = "Kosetur i Oslofjorden"

                },
                new Battur
                {
                    BatturId = 5,
                    Beskrivelse = "Lorem Ipsum...",
                    EngelskBeskrivelse = "English Lorem Ipsum...",
                    MinimumTid = 7,
                    TilSted = "Villa Malla",
                    FraSted = "Oslo",
                    Ingress = "Ingress bla bla",
                    Overskrift = "Vennefest i Oslofjorden"

                },
                new Battur
                {
                    BatturId = 6,
                    Beskrivelse = "Lorem Ipsum...",
                    EngelskBeskrivelse = "English Lorem Ipsum...",
                    MinimumTid = 6,
                    TilSted = "Oscarsborg",
                    FraSted = "Oslo",
                    Ingress = "Ingress bla bla",
                    Overskrift = "Kosetur i Oslofjorden"

                }
                );

            base.Seed(context);



            context.BatturImages.AddOrUpdate(
                p => p.ImageId,
                new BatturImage()
                {
                    ImageId = 1,
                    ImageFile = "battur-i-oslofjorden1.jpg",
                    BatturId = 1,
                    ErHovedbilde = false
                },
                new BatturImage()
                {
                    ImageId = 2,
                    ImageFile = "battur-i-oslofjorden2.jpg",
                    BatturId = 1,
                    ErHovedbilde = true
                },
                new BatturImage()
                {
                    ImageId = 3,
                    ImageFile = "battur-i-oslofjorden3.jpg",
                    BatturId = 2,
                    ErHovedbilde = false
                },
                new BatturImage()
                {
                    ImageId = 4,
                    ImageFile = "battur-i-oslofjorden4.jpg",
                    BatturId = 2,
                    ErHovedbilde = true
                },
                new BatturImage()
                {
                    ImageId = 5,
                    ImageFile = "battur-i-oslofjorden5.jpg",
                    BatturId = 3,
                    ErHovedbilde = false
                },
                new BatturImage()
                {
                    ImageId = 6,
                    ImageFile = "battur-i-oslofjorden6.jpg",
                    BatturId = 3,
                    ErHovedbilde = true
                },
                new BatturImage()
                {
                    ImageId = 7,
                    ImageFile = "battur-i-oslofjorden7.jpg",
                    BatturId = 4,
                    ErHovedbilde = false
                },
                new BatturImage()
                {
                    ImageId = 8,
                    ImageFile = "battur-i-oslofjorden8.jpg",
                    BatturId = 4,
                    ErHovedbilde = true
                },
                new BatturImage()
                {
                    ImageId = 9,
                    ImageFile = "battur-i-oslofjorden9.jpg",
                    BatturId = 5,
                    ErHovedbilde = false
                },
                new BatturImage()
                {
                    ImageId = 10,
                    ImageFile = "battur-i-oslofjorden10.jpg",
                    BatturId = 5,
                    ErHovedbilde = true
                },
                new BatturImage()
                {
                    ImageId = 11,
                    ImageFile = "battur-i-oslofjorden11.jpg",
                    BatturId = 6,
                    ErHovedbilde = false
                },
                new BatturImage()
                {
                    ImageId = 12,
                    ImageFile = "battur-i-oslofjorden12.jpg",
                    BatturId = 6,
                    ErHovedbilde = true
                }
                );

            base.Seed(context);

            context.BloggImages.AddOrUpdate(
                p => p.ImageId,
                new BloggImage() {ImageId = 1, ImageFile = "nyRib.jpg", BloggpostId = 1},
                new BloggImage() {ImageId = 2, ImageFile = "nyRib.jpg", BloggpostId = 1},
                new BloggImage() {ImageId = 3, ImageFile = "nyRib.jpg", BloggpostId = 2},
                new BloggImage() {ImageId = 4, ImageFile = "nyRib.jpg", BloggpostId = 3}

                );

            base.Seed(context);


            context.Samarbeidspartnere.AddOrUpdate(
                p => p.SamarbeidspartnerId,
                new Samarbeidspartner() {SamarbeidspartnerId = 1, Overskrift = "M/Y Martinique", Ingress = "litt ingress", AntallPersoner = 10, Beskrivelse = "Fantastisk yacht. ", Merke = "luksusmerke", Logo = "", Link = ""}
                   );
            base.Seed(context);

            context.SamarbeidspartnerImages.AddOrUpdate(
                p => p.SamarbeidspartnerImageId,
                new SamarbeidspartnerImage() { SamarbeidspartnerImageId = 1, ImageFile = "Martinique1.jpg", SamarbeidspartnerId = 1, ErHovedbilde = false },
                new SamarbeidspartnerImage() { SamarbeidspartnerImageId = 2, ImageFile = "Martinique2.jpg", SamarbeidspartnerId = 1, ErHovedbilde = false },
                new SamarbeidspartnerImage() { SamarbeidspartnerImageId = 3, ImageFile = "Martinique3.jpg", SamarbeidspartnerId = 1, ErHovedbilde = true },
                new SamarbeidspartnerImage() { SamarbeidspartnerImageId = 4, ImageFile = "Martinique4.jpg", SamarbeidspartnerId = 1, ErHovedbilde = false }
                );
            base.Seed(context);


        context.Kategorier.AddOrUpdate(
            p => p.KategoriId,
                new Kategori() { KategoriId = 1, KategoriNavn = "Vennefest" },
                new Kategori() { KategoriId = 2, KategoriNavn = "Sightseeing" },
                new Kategori() { KategoriId = 3, KategoriNavn = "Lunsjcruise" },
                new Kategori() { KategoriId = 4, KategoriNavn = "Firmafest" },
                new Kategori() { KategoriId = 5, KategoriNavn = "Bursdag" },
                new Kategori() { KategoriId = 6, KategoriNavn = "Dagscruise" },
                new Kategori() { KategoriId = 7, KategoriNavn = "Firmaevent" },
                new Kategori() { KategoriId = 8, KategoriNavn = "Event" }
                );

            base.Seed(context);

            context.HvasKjer.AddOrUpdate(
           p => p.HvaSkjerId,
               new HvaSkjer() { HvaSkjerId = 1, Overskrift = "Vennefest", Innhold = "båtrace ved Operaen", Dag = 10, Mnd = "JUN", Link = "http://www.vg.no" },
               new HvaSkjer() { HvaSkjerId = 2, Overskrift = "Sightseeing", Innhold = "svømmekonkurranse Tjuvholmen", Dag = 29, Mnd = "JUL", Link = "http://www.vg.no" }
               );
            base.Seed(context);


            


            context.BatturKategorier.AddOrUpdate(
            p => p.BatturKategoriId,
               new BatturKategori() { BatturKategoriId = 1, KategoriId = 1, BatturId = 1 },
               new BatturKategori() { BatturKategoriId = 2, KategoriId = 1, BatturId = 3 },
               new BatturKategori() { BatturKategoriId = 3, KategoriId = 2, BatturId = 1 },
               new BatturKategori() { BatturKategoriId = 4, KategoriId = 2, BatturId = 2 },
               new BatturKategori() { BatturKategoriId = 5, KategoriId = 3, BatturId = 4 },
               new BatturKategori() { BatturKategoriId = 6, KategoriId = 3, BatturId = 1 },
               new BatturKategori() { BatturKategoriId = 7, KategoriId = 4, BatturId = 3 },
               new BatturKategori() { BatturKategoriId = 10, KategoriId = 7, BatturId = 4 },
               new BatturKategori() { BatturKategoriId = 11, KategoriId = 8, BatturId = 1 },
               new BatturKategori() { BatturKategoriId = 12, KategoriId = 8, BatturId = 3 },
               new BatturKategori() { BatturKategoriId = 13, KategoriId = 5, BatturId = 1 },
               new BatturKategori() { BatturKategoriId = 14, KategoriId = 6, BatturId = 2 },
               new BatturKategori() { BatturKategoriId = 15, KategoriId = 6, BatturId = 4 },
               new BatturKategori() { BatturKategoriId = 16, KategoriId = 7, BatturId = 1 },
               new BatturKategori() { BatturKategoriId = 17, KategoriId = 3, BatturId = 3 },
               new BatturKategori() { BatturKategoriId = 18, KategoriId = 4, BatturId = 1 },
               new BatturKategori() { BatturKategoriId = 19, KategoriId = 5, BatturId = 2 },
               new BatturKategori() { BatturKategoriId = 20, KategoriId = 5, BatturId = 5 },
               new BatturKategori() { BatturKategoriId = 21, KategoriId = 2, BatturId = 5 },
               new BatturKategori() { BatturKategoriId = 22, KategoriId = 6, BatturId = 5 },
               new BatturKategori() { BatturKategoriId = 23, KategoriId = 7, BatturId = 5 },
               new BatturKategori() { BatturKategoriId = 24, KategoriId = 3, BatturId = 6 },
               new BatturKategori() { BatturKategoriId = 25, KategoriId = 4, BatturId = 6 },
               new BatturKategori() { BatturKategoriId = 26, KategoriId = 5, BatturId = 6 }
               );

            base.Seed(context);


            context.Meny.AddOrUpdate(
           p => p.MenyId,
               new Meny() { MenyId = 1, Type = "Forrett", EngelskBeskrivelse = "engelsk...", Beskrivelse = "Jordbær i boller", Pris = 45 },
               new Meny() { MenyId = 2, Type = "Forrett", EngelskBeskrivelse = "engelsk...", Beskrivelse = "Grønnsaks- eller Fruktanretning", Pris = 85 },
               new Meny() { MenyId = 3, Type = "Forrett", EngelskBeskrivelse = "engelsk...", Beskrivelse = "Snitter 5 stk. pr. person", Pris = 195 },
               new Meny() { MenyId = 4, Type = "Hovedrett", EngelskBeskrivelse = "engelsk...", Beskrivelse = "Rekeaften 500 gram pr.person", Pris = 235 },
               new Meny() { MenyId = 5, Type = "Hovedrett", EngelskBeskrivelse = "engelsk...", Beskrivelse = "Havets fristelser", Pris = 385 },
               new Meny() { MenyId = 6, Type = "Hovedrett", EngelskBeskrivelse = "engelsk...", Beskrivelse = "Seafood de lux", Pris = 425 },
               new Meny() { MenyId = 7, Type = "Hovedrett", EngelskBeskrivelse = "engelsk...", Beskrivelse = "Tapas", Pris = 455 },
               new Meny() { MenyId = 8, Type = "Hovedrett", EngelskBeskrivelse = "engelsk...", Beskrivelse = "Spekefat de lux", Pris = 395 },
               new Meny() { MenyId = 9, Type = "Hovedrett", EngelskBeskrivelse = "engelsk...", Beskrivelse = "Koldtbord Executive", Pris = 375 },
               new Meny() { MenyId = 10, Type = "Hovedrett", EngelskBeskrivelse = "engelsk...", Beskrivelse = "Neptuns Skattkammer", Pris = 565 },
               new Meny() { MenyId = 11, Type = "Hovedrett", EngelskBeskrivelse = "engelsk...", Beskrivelse = "Grillmeny 2", Pris = 380 },
               new Meny() { MenyId = 12, Type = "Hovedrett", EngelskBeskrivelse = "engelsk...", Beskrivelse = "1/2 kylling m/ris eller salat", Pris = 235 },
               new Meny() { MenyId = 13, Type = "Dessert", EngelskBeskrivelse = "engelsk...", Beskrivelse = "Friske jordbær med fløte og sukker", Pris = 89 },
               new Meny() { MenyId = 14, Type = "Dessert", EngelskBeskrivelse = "engelsk...", Beskrivelse = "Skogsbærkake m/friske bær, porsjonert", Pris = 70 },
               new Meny() { MenyId = 15, Type = "Dessert", EngelskBeskrivelse = "engelsk...", Beskrivelse = "Kringle m/eple eller makronfyll", Pris = 55 },
               new Meny() { MenyId = 16, Type = "Dessert", EngelskBeskrivelse = "engelsk...", Beskrivelse = "Frukttartelett m/vaniljekrem", Pris = 60 },
               new Meny() { MenyId = 17, Type = "Diverse", EngelskBeskrivelse = "Coffee", Beskrivelse = "Kaffe m/fløte og sukker:", Pris = 32 },
               new Meny() { MenyId = 18, Type = "Diverse", EngelskBeskrivelse = "Ringnes drafted beer 0,3l", Beskrivelse = "Ringnes fatpils tappet 0,3 ltr", Pris = 235 },
               new Meny() { MenyId = 19, Type = "Diverse", EngelskBeskrivelse = "Clausthaler (beer alcohol-free)", Beskrivelse = "Clausthaler", Pris = 385 },
               new Meny() { MenyId = 20, Type = "Diverse", EngelskBeskrivelse = "Mineralwater", Beskrivelse = "Assortert mineralvann", Pris = 425 },
               new Meny() { MenyId = 21, Type = "Hvitvin", EngelskBeskrivelse = "Soave Classico Superior Cesari-Maison", Beskrivelse = "Soave Classico Superior Cesari-Husets", Pris = 295 },
               new Meny() { MenyId = 22, Type = "Hvitvin", EngelskBeskrivelse = "Petit Bourgeoise Sauvignon", Beskrivelse = "Petit Bourgeoise Sauvignon", Pris = 430 },
               new Meny() { MenyId = 23, Type = "Hvitvin", EngelskBeskrivelse = "William Fevre Petit Chablis", Beskrivelse = "William Fevre Petit Chablis", Pris = 410 },
               new Meny() { MenyId = 24, Type = "Rodvin", EngelskBeskrivelse = "Finca Constancia-maison", Beskrivelse = "Finca Constancia-Husets", Pris = 265 },
               new Meny() { MenyId = 25, Type = "Rodvin", EngelskBeskrivelse = "Beronia Reserva 2007", Beskrivelse = "Beronia Reserva 2007", Pris = 375 },
               new Meny() { MenyId = 26, Type = "Rodvin", EngelskBeskrivelse = "Cesari Mara Ripasso Valpolicella", Beskrivelse = "Cesari Mara Ripasso Valpolicella", Pris = 339 },
               new Meny() { MenyId = 27, Type = "Rodvin", EngelskBeskrivelse = "Côtes du Rhône parallèle 45", Beskrivelse = "Côtes du Rhône parallèle 45", Pris = 325 },
               new Meny() { MenyId = 29, Type = "Aperitiff", EngelskBeskrivelse = "Prosecco Spumante Pizzolato", Beskrivelse = "Prosecco Spumante Pizzolato", Pris = 329 },
               new Meny() { MenyId = 30, Type = "Aperitiff", EngelskBeskrivelse = "Vilarnau Brut Cava", Beskrivelse = "Vilarnau Brut Cava", Pris = 270 },
               new Meny() { MenyId = 31, Type = "Aperitiff", EngelskBeskrivelse = "Champagne Henriot Blanc de Blancs", Beskrivelse = "Champagne Henriot Blanc de Blancs", Pris = 380 },
               new Meny() { MenyId = 32, Type = "Aperitiff", EngelskBeskrivelse = "The captain's coctail", Beskrivelse = "Kapteinens velkomstdrink", Pris = 45 },
               new Meny() { MenyId = 33, Type = "Likor", EngelskBeskrivelse = "Thor Heyerdahl XO", Beskrivelse = "Thor Heyerdahl XO", Pris = 78 },
               new Meny() { MenyId = 34, Type = "Likor", EngelskBeskrivelse = "Carolans Irish Cream", Beskrivelse = "Carolans Irish Cream", Pris = 45 },
               new Meny() { MenyId = 35, Type = "Likor", EngelskBeskrivelse = "Jägermeister", Beskrivelse = "Jägermeister:", Pris = 65 }
               );

            base.Seed(context);

            context.Bloggposter.AddOrUpdate(
           p => p.BloggpostId,
              new Bloggpost() { BloggpostId = 1, BloggpostOverskrift = "bloggpost 1 overskrift", BloggpostInnhold = "bloggpost 1 innhold" },
              new Bloggpost() { BloggpostId = 2, BloggpostOverskrift = "bloggpost 2 overskrift", BloggpostInnhold = "bloggpost 2 innhold" },
              new Bloggpost() { BloggpostId = 3, BloggpostOverskrift = "bloggpost 3 overskrift", BloggpostInnhold = "bloggpost 3 innhold" }
         
              );

            base.Seed(context);

             context.Bloggsvar.AddOrUpdate(
           p => p.BloggsvarId,
              new Bloggsvar() { BloggsvarId = 1, BloggpostId = 1, BloggsvarNavn = "Bob Dylan",  BloggsvarInnhold = "bloggsvar 1 innhold svar på bloggpost 1" },
              new Bloggsvar() { BloggsvarId = 2, BloggpostId = 1, BloggsvarNavn = "Michael Jackson", BloggsvarInnhold = "bloggsvar 1 innhold svar på bloggpost 1" },
              new Bloggsvar() { BloggsvarId = 3, BloggpostId = 1, BloggsvarNavn = "Bonnie Taylor",  BloggsvarInnhold = "bloggsvar 1 innhold svar på bloggpost 1" },
              new Bloggsvar() { BloggsvarId = 4, BloggpostId = 2, BloggsvarNavn = "Prince",  BloggsvarInnhold = "bloggsvar 1 innhold svar på bloggpost 2" },
              new Bloggsvar() { BloggsvarId = 5, BloggpostId = 3, BloggsvarNavn = "James Dean",  BloggsvarInnhold = "bloggsvar 1 innhold svar på bloggpost 3" },
              new Bloggsvar() { BloggsvarId = 6, BloggpostId = 3, BloggsvarNavn = "Marilyn Monroe",  BloggsvarInnhold = "bloggsvar 1 innhold svar på bloggpost 3" },
              new Bloggsvar() { BloggsvarId = 7, BloggpostId = 1, BloggsvarNavn = "Bruce Springsteen",  BloggsvarInnhold = "bloggsvar 1 innhold svar på bloggpost 1" }
              );

            base.Seed(context);


            context.UserProfiles.AddOrUpdate(
         p => p.UserId,
            new UserProfile() { UserId = 1, UserName = "admin" }

            );
        }
    }
}
