using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CruiseWorld.Models;

public partial class CruiseContext : DbContext
{
    public CruiseContext()
    {
    }

    public CruiseContext(DbContextOptions<CruiseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Cabin> Cabins { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Cruise> Cruises { get; set; }

    public virtual DbSet<CruisePort> CruisePorts { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Manifest> Manifests { get; set; }

    public virtual DbSet<Operator> Operators { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Port> Ports { get; set; }

    public virtual DbSet<PortTemp> PortTemps { get; set; }

    public virtual DbSet<Ship> Ships { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<TourLang> TourLangs { get; set; }

    public virtual DbSet<TourWhen> TourWhens { get; set; }

    public virtual DbSet<Touroffer> Touroffers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("address_pk");

            entity.ToTable("address");

            entity.HasIndex(e => new { e.AddressStreet, e.AddressTown, e.AddressPcode, e.CountryCode }, "address_nk").IsUnique();

            entity.Property(e => e.AddressId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("address_id");
            entity.Property(e => e.AddressPcode)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("address_pcode");
            entity.Property(e => e.AddressStreet)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address_street");
            entity.Property(e => e.AddressTown)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("address_town");
            entity.Property(e => e.CountryCode)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("country_code");

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CountryCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("country_address_fk");
        });

        modelBuilder.Entity<Cabin>(entity =>
        {
            entity.HasKey(e => new { e.ShipCode, e.CabinNo }).HasName("cabin_pk");

            entity.ToTable("cabin");

            entity.Property(e => e.ShipCode).HasColumnName("ship_code");
            entity.Property(e => e.CabinNo)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("cabin_no");
            entity.Property(e => e.CabinCapacity)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("cabin_capacity");
            entity.Property(e => e.CabinClass)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cabin_class");

            entity.HasOne(d => d.ShipCodeNavigation).WithMany(p => p.Cabins)
                .HasForeignKey(d => d.ShipCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ship_cabin_fk");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryCode).HasName("country_pk");

            entity.ToTable("country");

            entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("country_code");
            entity.Property(e => e.CountryName)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("country_name");
        });

        modelBuilder.Entity<Cruise>(entity =>
        {
            entity.HasKey(e => e.CruiseId).HasName("cruise_pk");

            entity.ToTable("cruise");

            entity.Property(e => e.CruiseId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("cruise_id");
            entity.Property(e => e.CruiseDescription)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("cruise_description");
            entity.Property(e => e.CruiseName)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("cruise_name");
            entity.Property(e => e.ShipCode).HasColumnName("ship_code");

            entity.HasOne(d => d.ShipCodeNavigation).WithMany(p => p.Cruises)
                .HasForeignKey(d => d.ShipCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ship_cruise_fk");
        });

        modelBuilder.Entity<CruisePort>(entity =>
        {
            entity.HasKey(e => new { e.CruiseId, e.CpDatetime }).HasName("cruise_port_pk");

            entity.ToTable("cruise_port");

            entity.Property(e => e.CruiseId).HasColumnName("cruise_id");
            entity.Property(e => e.CpDatetime).HasColumnName("cp_datetime");
            entity.Property(e => e.CpDepartArrive)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cp_depart_arrive");
            entity.Property(e => e.PortCode).HasColumnName("port_code");

            entity.HasOne(d => d.Cruise).WithMany(p => p.CruisePorts)
                .HasForeignKey(d => d.CruiseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cruise_cruise_port_fk");

            entity.HasOne(d => d.PortCodeNavigation).WithMany(p => p.CruisePorts)
                .HasForeignKey(d => d.PortCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("port_cruise_port_fk");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LangCode).HasName("lang_pk");

            entity.ToTable("language");

            entity.Property(e => e.LangCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lang_code");
            entity.Property(e => e.LangName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lang_name");

            entity.HasMany(d => d.Tours).WithMany(p => p.LangCodes)
                .UsingEntity<Dictionary<string, object>>(
                    "TourLanguage",
                    r => r.HasOne<Tour>().WithMany()
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("tour_tour_language_fk"),
                    l => l.HasOne<Language>().WithMany()
                        .HasForeignKey("LangCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("language_tour_language_fk"),
                    j =>
                    {
                        j.HasKey("LangCode", "TourId").HasName("tour_language_pk");
                        j.ToTable("tour_language");
                        j.IndexerProperty<string>("LangCode")
                            .HasMaxLength(2)
                            .IsUnicode(false)
                            .IsFixedLength()
                            .HasColumnName("lang_code");
                        j.IndexerProperty<Guid>("TourId").HasColumnName("tour_id");
                    });
        });

        modelBuilder.Entity<Manifest>(entity =>
        {
            entity.HasKey(e => new { e.PassengerId, e.CruiseId }).HasName("manifest_pk");

            entity.ToTable("manifest");

            entity.Property(e => e.PassengerId).HasColumnName("passenger_id");
            entity.Property(e => e.CruiseId).HasColumnName("cruise_id");
            entity.Property(e => e.CabinNo).HasColumnName("cabin_no");
            entity.Property(e => e.MainfestBoardTime).HasColumnName("mainfest_board_time");
            entity.Property(e => e.ShipCode).HasColumnName("ship_code");

            entity.HasOne(d => d.Cruise).WithMany(p => p.Manifests)
                .HasForeignKey(d => d.CruiseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cruise_manifest_fk");

            entity.HasOne(d => d.Passenger).WithMany(p => p.Manifests)
                .HasForeignKey(d => d.PassengerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("passenger_manifest_fk");

            entity.HasOne(d => d.Cabin).WithMany(p => p.Manifests)
                .HasForeignKey(d => new { d.ShipCode, d.CabinNo })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cabin_manifest_fk");
        });

        modelBuilder.Entity<Operator>(entity =>
        {
            entity.HasKey(e => e.OperId).HasName("operator_pk");

            entity.ToTable("operator");

            entity.Property(e => e.OperId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("oper_id");
            entity.Property(e => e.OperCeo)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("oper_ceo");
            entity.Property(e => e.OperCompName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("oper_comp_name");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.ParticipantId).HasName("participant_pk");

            entity.ToTable("participant");

            entity.HasIndex(e => new { e.PassengerId, e.TourofferDate, e.TourId }, "participant_nk").IsUnique();

            entity.Property(e => e.ParticipantId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("participant_id");
            entity.Property(e => e.CruiseId).HasColumnName("cruise_id");
            entity.Property(e => e.PassengerId).HasColumnName("passenger_id");
            entity.Property(e => e.TourId).HasColumnName("tour_id");
            entity.Property(e => e.TourPaid)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tour_paid");
            entity.Property(e => e.TourofferDate).HasColumnName("touroffer_date");

            entity.HasOne(d => d.Cruise).WithMany(p => p.Participants)
                .HasForeignKey(d => d.CruiseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cruise_participant_fk");

            entity.HasOne(d => d.Passenger).WithMany(p => p.Participants)
                .HasForeignKey(d => d.PassengerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("passenger_participant_fk");

            entity.HasOne(d => d.Touroffer).WithMany(p => p.Participants)
                .HasForeignKey(d => new { d.TourofferDate, d.TourId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("touroffer_participant_fk");
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.PassengerId).HasName("passenger_pk");

            entity.ToTable("passenger");

            entity.Property(e => e.PassengerId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("passenger_id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.GuardianId).HasColumnName("guardian_id");
            entity.Property(e => e.LangCode)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lang_code");
            entity.Property(e => e.PassengerContact)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("passenger_contact");
            entity.Property(e => e.PassengerDob).HasColumnName("passenger_dob");
            entity.Property(e => e.PassengerFname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("passenger_fname");
            entity.Property(e => e.PassengerGender)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("passenger_gender");
            entity.Property(e => e.PassengerLname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("passenger_lname");

            entity.HasOne(d => d.Address).WithMany(p => p.Passengers)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("address_passenger_fk");

            entity.HasOne(d => d.Guardian).WithMany(p => p.InverseGuardian)
                .HasForeignKey(d => d.GuardianId)
                .HasConstraintName("passenger_passenger_fk");

            entity.HasOne(d => d.LangCodeNavigation).WithMany(p => p.Passengers)
                .HasForeignKey(d => d.LangCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("language_passenger_fk");
        });

        modelBuilder.Entity<Port>(entity =>
        {
            entity.HasKey(e => e.PortCode).HasName("port_pk");

            entity.ToTable("port");

            entity.Property(e => e.PortCode)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("port_code");
            entity.Property(e => e.CountryCode)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("country_code");
            entity.Property(e => e.PortLat)
                .HasColumnType("numeric(9, 7)")
                .HasColumnName("port_lat");
            entity.Property(e => e.PortLong)
                .HasColumnType("numeric(10, 7)")
                .HasColumnName("port_long");
            entity.Property(e => e.PortName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("port_name");
            entity.Property(e => e.PortPopulation)
                .HasColumnType("numeric(6, 0)")
                .HasColumnName("port_population");
        });

        modelBuilder.Entity<PortTemp>(entity =>
        {
            entity.HasKey(e => new { e.TempMonth, e.PortCode }).HasName("port_temp_pk");

            entity.ToTable("port_temp");

            entity.Property(e => e.TempMonth).HasColumnName("temp_month");
            entity.Property(e => e.PortCode).HasColumnName("port_code");
            entity.Property(e => e.TempHigh)
                .HasColumnType("numeric(4, 1)")
                .HasColumnName("temp_high");
            entity.Property(e => e.TempLow)
                .HasColumnType("numeric(3, 1)")
                .HasColumnName("temp_low");

            entity.HasOne(d => d.PortCodeNavigation).WithMany(p => p.PortTemps)
                .HasForeignKey(d => d.PortCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("port_port_temp_fk");
        });

        modelBuilder.Entity<Ship>(entity =>
        {
            entity.HasKey(e => e.ShipCode).HasName("ship_pk");

            entity.ToTable("ship");

            entity.Property(e => e.ShipCode)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ship_code");
            entity.Property(e => e.CountryCode)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("country_code");
            entity.Property(e => e.OperId).HasColumnName("oper_id");
            entity.Property(e => e.ShipDateCommiss).HasColumnName("ship_date_commiss");
            entity.Property(e => e.ShipGuestCapacity)
                .HasColumnType("numeric(4, 0)")
                .HasColumnName("ship_guest_capacity");
            entity.Property(e => e.ShipName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ship_name");
            entity.Property(e => e.ShipTonnage)
                .HasColumnType("numeric(6, 0)")
                .HasColumnName("ship_tonnage");

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.Ships)
                .HasForeignKey(d => d.CountryCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("country_ship_fk");

            entity.HasOne(d => d.Oper).WithMany(p => p.Ships)
                .HasForeignKey(d => d.OperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("operator_ship_fk");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.TourId).HasName("tour_pk");

            entity.ToTable("tour");

            entity.HasIndex(e => new { e.TourNumber, e.PortCode }, "tour_nk").IsUnique();

            entity.Property(e => e.TourId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("tour_id");
            entity.Property(e => e.PortCode).HasColumnName("port_code");
            entity.Property(e => e.TourCostPp)
                .HasColumnType("numeric(6, 2)")
                .HasColumnName("tour_cost_pp");
            entity.Property(e => e.TourDescription)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("tour_description");
            entity.Property(e => e.TourHours)
                .HasColumnType("numeric(3, 1)")
                .HasColumnName("tour_hours");
            entity.Property(e => e.TourMinParticipants)
                .HasColumnType("numeric(3, 0)")
                .HasColumnName("tour_min_participants");
            entity.Property(e => e.TourName)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("tour_name");
            entity.Property(e => e.TourNumber)
                .HasColumnType("numeric(3, 0)")
                .HasColumnName("tour_number");
            entity.Property(e => e.TourStarttime).HasColumnName("tour_starttime");
            entity.Property(e => e.TourWchairAccess)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tour_wchair_access");
            entity.Property(e => e.TourWhenCode).HasColumnName("tour_when_code");

            entity.HasOne(d => d.PortCodeNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.PortCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("port_tour_fk");

            entity.HasOne(d => d.TourWhenCodeNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.TourWhenCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tour_when_tour_fk");
        });

        modelBuilder.Entity<TourLang>(entity =>
        {
            entity.HasKey(e => new { e.LangCode, e.TourId }).HasName("tour_lang_pk");

            entity.ToTable("tour_lang");

            entity.Property(e => e.LangCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lang_code");
            entity.Property(e => e.TourId).HasColumnName("tour_id");
        });

        modelBuilder.Entity<TourWhen>(entity =>
        {
            entity.HasKey(e => e.TourWhenCode).HasName("tour_when_code_pk");

            entity.ToTable("tour_when");

            entity.Property(e => e.TourWhenCode)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("tour_when_code");
            entity.Property(e => e.TourWhenDesc)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tour_when_desc");
        });

        modelBuilder.Entity<Touroffer>(entity =>
        {
            entity.HasKey(e => new { e.TourofferDate, e.TourId }).HasName("touroffer_pk");

            entity.ToTable("touroffer");

            entity.Property(e => e.TourofferDate).HasColumnName("touroffer_date");
            entity.Property(e => e.TourId).HasColumnName("tour_id");

            entity.HasOne(d => d.Tour).WithMany(p => p.Touroffers)
                .HasForeignKey(d => d.TourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tour_touroffer_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
