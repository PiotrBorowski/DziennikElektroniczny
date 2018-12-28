using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DziennikElektroniczny.Models
{
    public partial class DziennikElektronicznyContext : DbContext
    {
        public DziennikElektronicznyContext()
        {
        }

        public DziennikElektronicznyContext(DbContextOptions<DziennikElektronicznyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JednostkaLekcyjna> JednostkaLekcyjna { get; set; }
        public virtual DbSet<KategoriaOceny> KategoriaOceny { get; set; }
        public virtual DbSet<Klasa> Klasa { get; set; }
        public virtual DbSet<Lekcja> Lekcja { get; set; }
        public virtual DbSet<ListaObecnosci> ListaObecnosci { get; set; }
        public virtual DbSet<Obecnosc> Obecnosc { get; set; }
        public virtual DbSet<Ocena> Ocena { get; set; }
        public virtual DbSet<PlanLekcji> PlanLekcji { get; set; }
        public virtual DbSet<Przedmiot> Przedmiot { get; set; }
        public virtual DbSet<Rola> Rola { get; set; }
        public virtual DbSet<Uczen> Uczen { get; set; }
        public virtual DbSet<Usprawiedliwienie> Usprawiedliwienie { get; set; }
        public virtual DbSet<Uwaga> Uwaga { get; set; }
        public virtual DbSet<Uzytkownik> Uzytkownik { get; set; }
        public virtual DbSet<Wiadomosc> Wiadomosc { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer();
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<JednostkaLekcyjna>(entity =>
            {
                entity.HasKey(e => e.IdJednostkiLekcyjnej);

                entity.ToTable("Jednostka_lekcyjna");

                entity.HasIndex(e => e.IdPlanuLekcji)
                    .HasName("fkIdx_121");

                entity.HasIndex(e => e.IdPrzedmiotu)
                    .HasName("fkIdx_112");

                entity.Property(e => e.IdJednostkiLekcyjnej).HasColumnName("id_jednostki_lekcyjnej");

                entity.Property(e => e.DzienTygodnia)
                    .IsRequired()
                    .HasColumnName("dzien_tygodnia")
                    .HasMaxLength(20);

                entity.Property(e => e.Godzina)
                    .HasColumnName("godzina")
                    .HasColumnType("time(0)");

                entity.Property(e => e.IdPlanuLekcji).HasColumnName("id_planu_lekcji");

                entity.Property(e => e.IdPrzedmiotu).HasColumnName("id_przedmiotu");

                entity.Property(e => e.Sala)
                    .IsRequired()
                    .HasColumnName("sala")
                    .HasMaxLength(6);

                entity.HasOne(d => d.IdPlanuLekcjiNavigation)
                    .WithMany(p => p.JednostkaLekcyjna)
                    .HasForeignKey(d => d.IdPlanuLekcji)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_121");

                entity.HasOne(d => d.IdPrzedmiotuNavigation)
                    .WithMany(p => p.JednostkaLekcyjna)
                    .HasForeignKey(d => d.IdPrzedmiotu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_112");
            });

            modelBuilder.Entity<KategoriaOceny>(entity =>
            {
                entity.HasKey(e => e.IdKategoriiOceny);

                entity.ToTable("Kategoria_Oceny");

                entity.Property(e => e.IdKategoriiOceny).HasColumnName("id_kategorii_oceny");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(20);

                entity.Property(e => e.Waga).HasColumnName("waga");
            });

            modelBuilder.Entity<Klasa>(entity =>
            {
                entity.HasKey(e => e.IdKlasy);

                entity.HasIndex(e => e.IdWychowawcy)
                    .HasName("fkIdx_50");

                entity.Property(e => e.IdKlasy).HasColumnName("id_klasy");

                entity.Property(e => e.IdWychowawcy).HasColumnName("id_wychowawcy");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(20);

                entity.Property(e => e.RokSzkolny)
                    .IsRequired()
                    .HasColumnName("rok_szkolny")
                    .HasMaxLength(9);

                entity.HasOne(d => d.IdWychowawcyNavigation)
                    .WithMany(p => p.Klasa)
                    .HasForeignKey(d => d.IdWychowawcy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_50");
            });

            modelBuilder.Entity<Lekcja>(entity =>
            {
                entity.HasKey(e => e.IdLekcji);

                entity.HasIndex(e => e.IdJednostkiLekcyjnej)
                    .HasName("fkIdx_146");

                entity.HasIndex(e => e.IdProwadzacegoLekcje)
                    .HasName("fkIdx_103");

                entity.Property(e => e.IdLekcji).HasColumnName("id_lekcji");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.IdJednostkiLekcyjnej).HasColumnName("id_jednostki_lekcyjnej");

                entity.Property(e => e.IdProwadzacegoLekcje).HasColumnName("id_prowadzacego_lekcje");

                entity.Property(e => e.Temat)
                    .IsRequired()
                    .HasColumnName("temat")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdJednostkiLekcyjnejNavigation)
                    .WithMany(p => p.Lekcja)
                    .HasForeignKey(d => d.IdJednostkiLekcyjnej)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_146");

                entity.HasOne(d => d.IdProwadzacegoLekcjeNavigation)
                    .WithMany(p => p.Lekcja)
                    .HasForeignKey(d => d.IdProwadzacegoLekcje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_103");
            });

            modelBuilder.Entity<ListaObecnosci>(entity =>
            {
                entity.HasKey(e => e.IdListy);

                entity.ToTable("Lista_obecnosci");

                entity.HasIndex(e => e.IdLekcji)
                    .HasName("fkIdx_140");

                entity.Property(e => e.IdListy).HasColumnName("id_listy");

                entity.Property(e => e.IdLekcji).HasColumnName("id_lekcji");

                entity.HasOne(d => d.IdLekcjiNavigation)
                    .WithMany(p => p.ListaObecnosci)
                    .HasForeignKey(d => d.IdLekcji)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_140");
            });

            modelBuilder.Entity<Obecnosc>(entity =>
            {
                entity.HasKey(e => e.IdObecnosci);

                entity.HasIndex(e => e.IdListy)
                    .HasName("fkIdx_134");

                entity.HasIndex(e => e.IdUcznia)
                    .HasName("fkIdx_137");

                entity.Property(e => e.IdObecnosci).HasColumnName("id_obecnosci");

                entity.Property(e => e.CzyObecny).HasColumnName("czy_obecny");

                entity.Property(e => e.IdListy).HasColumnName("id_listy");

                entity.Property(e => e.IdUcznia).HasColumnName("id_ucznia");

                entity.HasOne(d => d.IdListyNavigation)
                    .WithMany(p => p.Obecnosc)
                    .HasForeignKey(d => d.IdListy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_134");

                entity.HasOne(d => d.IdUczniaNavigation)
                    .WithMany(p => p.Obecnosc)
                    .HasForeignKey(d => d.IdUcznia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_137");
            });

            modelBuilder.Entity<Ocena>(entity =>
            {
                entity.HasKey(e => e.IdOceny);

                entity.HasIndex(e => e.IdKategoriiOceny)
                    .HasName("fkIdx_75");

                entity.HasIndex(e => e.IdPrzedmiotu)
                    .HasName("fkIdx_67");

                entity.HasIndex(e => e.IdUcznia)
                    .HasName("fkIdx_80");

                entity.Property(e => e.IdOceny).HasColumnName("id_oceny");

                entity.Property(e => e.IdKategoriiOceny).HasColumnName("id_kategorii_oceny");

                entity.Property(e => e.IdPrzedmiotu).HasColumnName("id_przedmiotu");

                entity.Property(e => e.IdUcznia).HasColumnName("id_ucznia");

                entity.Property(e => e.Wartosc).HasColumnName("wartosc");

                entity.HasOne(d => d.IdKategoriiOcenyNavigation)
                    .WithMany(p => p.Ocena)
                    .HasForeignKey(d => d.IdKategoriiOceny)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_75");

                entity.HasOne(d => d.IdPrzedmiotuNavigation)
                    .WithMany(p => p.Ocena)
                    .HasForeignKey(d => d.IdPrzedmiotu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_67");

                entity.HasOne(d => d.IdUczniaNavigation)
                    .WithMany(p => p.Ocena)
                    .HasForeignKey(d => d.IdUcznia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_80");
            });

            modelBuilder.Entity<PlanLekcji>(entity =>
            {
                entity.HasKey(e => e.IdPlanuLekcji);

                entity.ToTable("Plan_Lekcji");

                entity.HasIndex(e => e.IdKlasy)
                    .HasName("fkIdx_118");

                entity.Property(e => e.IdPlanuLekcji).HasColumnName("id_planu_lekcji");

                entity.Property(e => e.IdKlasy).HasColumnName("id_klasy");

                entity.HasOne(d => d.IdKlasyNavigation)
                    .WithMany(p => p.PlanLekcji)
                    .HasForeignKey(d => d.IdKlasy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_118");
            });

            modelBuilder.Entity<Przedmiot>(entity =>
            {
                entity.HasKey(e => e.IdPrzedmiotu);

                entity.HasIndex(e => e.IdProwadzacego)
                    .HasName("fkIdx_57");

                entity.Property(e => e.IdPrzedmiotu).HasColumnName("id_przedmiotu");

                entity.Property(e => e.IdProwadzacego).HasColumnName("id_prowadzacego");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdProwadzacegoNavigation)
                    .WithMany(p => p.Przedmiot)
                    .HasForeignKey(d => d.IdProwadzacego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_57");
            });

            modelBuilder.Entity<Rola>(entity =>
            {
                entity.HasKey(e => e.IdRoli);

                entity.Property(e => e.IdRoli).HasColumnName("id_roli");

                entity.Property(e => e.NazwaRoli)
                    .IsRequired()
                    .HasColumnName("nazwa_roli")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Uczen>(entity =>
            {
                entity.HasKey(e => e.IdUzytkownika);

                entity.HasIndex(e => e.IdKlasy)
                    .HasName("fkIdx_159");

                entity.HasIndex(e => e.IdRodzica)
                    .HasName("fkIdx_41");

                entity.HasIndex(e => e.IdUzytkownika)
                    .HasName("fkIdx_16");

                entity.Property(e => e.IdUzytkownika)
                    .HasColumnName("id_uzytkownika")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdKlasy).HasColumnName("id_klasy");

                entity.Property(e => e.IdRodzica).HasColumnName("id_rodzica");

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasColumnName("PESEL")
                    .HasMaxLength(11);

                entity.HasOne(d => d.IdKlasyNavigation)
                    .WithMany(p => p.Uczen)
                    .HasForeignKey(d => d.IdKlasy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_159");

                entity.HasOne(d => d.IdRodzicaNavigation)
                    .WithMany(p => p.UczenIdRodzicaNavigation)
                    .HasForeignKey(d => d.IdRodzica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_41");

                entity.HasOne(d => d.IdUzytkownikaNavigation)
                    .WithOne(p => p.UczenIdUzytkownikaNavigation)
                    .HasForeignKey<Uczen>(d => d.IdUzytkownika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_16");
            });

            modelBuilder.Entity<Usprawiedliwienie>(entity =>
            {
                entity.HasKey(e => e.IdUsprawiedliwienie);

                entity.HasIndex(e => e.IdRodzica)
                    .HasName("fkIdx_25");

                entity.HasIndex(e => e.IdWychowawcy)
                    .HasName("fkIdx_28");

                entity.Property(e => e.IdUsprawiedliwienie).HasColumnName("id_usprawiedliwienie");

                entity.Property(e => e.CzyZatwierdzone).HasColumnName("czy_zatwierdzone");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.IdRodzica).HasColumnName("id_rodzica");

                entity.Property(e => e.IdWychowawcy).HasColumnName("id_wychowawcy");

                entity.Property(e => e.Tresc)
                    .IsRequired()
                    .HasColumnName("tresc")
                    .HasColumnType("ntext");

                entity.HasOne(d => d.IdRodzicaNavigation)
                    .WithMany(p => p.UsprawiedliwienieIdRodzicaNavigation)
                    .HasForeignKey(d => d.IdRodzica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_25");

                entity.HasOne(d => d.IdWychowawcyNavigation)
                    .WithMany(p => p.UsprawiedliwienieIdWychowawcyNavigation)
                    .HasForeignKey(d => d.IdWychowawcy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_28");
            });

            modelBuilder.Entity<Uwaga>(entity =>
            {
                entity.HasKey(e => e.IdUwagi);

                entity.HasIndex(e => e.IdNauczyciela)
                    .HasName("fkIdx_92");

                entity.HasIndex(e => e.IdUcznia)
                    .HasName("fkIdx_95");

                entity.Property(e => e.IdUwagi).HasColumnName("id_uwagi");

                entity.Property(e => e.IdNauczyciela).HasColumnName("id_nauczyciela");

                entity.Property(e => e.IdUcznia).HasColumnName("id_ucznia");

                entity.Property(e => e.Tresc)
                    .IsRequired()
                    .HasColumnName("tresc")
                    .HasColumnType("ntext");

                entity.HasOne(d => d.IdNauczycielaNavigation)
                    .WithMany(p => p.Uwaga)
                    .HasForeignKey(d => d.IdNauczyciela)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_92");

                entity.HasOne(d => d.IdUczniaNavigation)
                    .WithMany(p => p.Uwaga)
                    .HasForeignKey(d => d.IdUcznia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_95");
            });

            modelBuilder.Entity<Uzytkownik>(entity =>
            {
                entity.HasKey(e => e.IdUzytkownika);

                entity.HasIndex(e => e.IdRoli)
                    .HasName("fkIdx_13");

                entity.Property(e => e.IdUzytkownika).HasColumnName("id_uzytkownika");

                entity.Property(e => e.IdRoli).HasColumnName("id_roli");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasColumnName("imie")
                    .HasMaxLength(20);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasColumnName("nazwisko")
                    .HasMaxLength(30);

                entity.Property(e => e.NumerKontaktowy)
                    .HasColumnName("numer_kontaktowy")
                    .HasMaxLength(9);

                entity.HasOne(d => d.IdRoliNavigation)
                    .WithMany(p => p.Uzytkownik)
                    .HasForeignKey(d => d.IdRoli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_13");
            });

            modelBuilder.Entity<Wiadomosc>(entity =>
            {
                entity.HasKey(e => e.IdWiadomosci);

                entity.HasIndex(e => e.IdNadawcy)
                    .HasName("fkIdx_35");

                entity.HasIndex(e => e.IdOdbiorcy)
                    .HasName("fkIdx_38");

                entity.Property(e => e.IdWiadomosci).HasColumnName("id_wiadomosci");

                entity.Property(e => e.IdNadawcy).HasColumnName("id_nadawcy");

                entity.Property(e => e.IdOdbiorcy).HasColumnName("id_odbiorcy");

                entity.Property(e => e.Tresc)
                    .IsRequired()
                    .HasColumnName("tresc")
                    .HasColumnType("ntext");

                entity.HasOne(d => d.IdNadawcyNavigation)
                    .WithMany(p => p.WiadomoscIdNadawcyNavigation)
                    .HasForeignKey(d => d.IdNadawcy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_35");

                entity.HasOne(d => d.IdOdbiorcyNavigation)
                    .WithMany(p => p.WiadomoscIdOdbiorcyNavigation)
                    .HasForeignKey(d => d.IdOdbiorcy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_38");
            });
        }
    }
}
