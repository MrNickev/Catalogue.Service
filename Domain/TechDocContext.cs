using System;
using System.Collections.Generic;
using Domain.TechDoc.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Domain.TechDoc;

public partial class TechDocContext : DbContext
{
    public TechDocContext()
    {
    }

    public TechDocContext(DbContextOptions<TechDocContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<ArticleAcc> ArticleAccs { get; set; }

    public virtual DbSet<ArticleAttribute> ArticleAttributes { get; set; }

    public virtual DbSet<ArticleCross> ArticleCrosses { get; set; }

    public virtual DbSet<ArticleEan> ArticleEans { get; set; }

    public virtual DbSet<ArticleImage> ArticleImages { get; set; }

    public virtual DbSet<ArticleInf> ArticleInfs { get; set; }

    public virtual DbSet<ArticleLi> ArticleLis { get; set; }

    public virtual DbSet<ArticleLink> ArticleLinks { get; set; }

    public virtual DbSet<ArticleNn> ArticleNns { get; set; }

    public virtual DbSet<ArticleNumber> ArticleNumbers { get; set; }

    public virtual DbSet<ArticleOe> ArticleOes { get; set; }

    public virtual DbSet<ArticlePart> ArticleParts { get; set; }

    public virtual DbSet<ArticlePrd> ArticlePrds { get; set; }

    public virtual DbSet<ArticleRn> ArticleRns { get; set; }

    public virtual DbSet<ArticleUn> ArticleUns { get; set; }

    public virtual DbSet<Axle> Axles { get; set; }

    public virtual DbSet<AxleAttribute> AxleAttributes { get; set; }

    public virtual DbSet<AxlePd> AxlePds { get; set; }

    public virtual DbSet<AxlePrd> AxlePrds { get; set; }

    public virtual DbSet<AxleTree> AxleTrees { get; set; }

    public virtual DbSet<CommercialDriverCab> CommercialDriverCabs { get; set; }

    public virtual DbSet<CommercialVehicle> CommercialVehicles { get; set; }

    public virtual DbSet<CommercialVehicleAttribute> CommercialVehicleAttributes { get; set; }

    public virtual DbSet<CommercialVehicleAxle> CommercialVehicleAxles { get; set; }

    public virtual DbSet<CommercialVehicleEngine> CommercialVehicleEngines { get; set; }

    public virtual DbSet<CommercialVehiclePd> CommercialVehiclePds { get; set; }

    public virtual DbSet<CommercialVehiclePrd> CommercialVehiclePrds { get; set; }

    public virtual DbSet<CommercialVehicleQsi> CommercialVehicleQsis { get; set; }

    public virtual DbSet<CommercialVehicleSubType> CommercialVehicleSubTypes { get; set; }

    public virtual DbSet<CommercialVehicleTree> CommercialVehicleTrees { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<CountryGroup> CountryGroups { get; set; }

    public virtual DbSet<Engine> Engines { get; set; }

    public virtual DbSet<EngineAttribute> EngineAttributes { get; set; }

    public virtual DbSet<EnginePd> EnginePds { get; set; }

    public virtual DbSet<EnginePrd> EnginePrds { get; set; }

    public virtual DbSet<EngineTree> EngineTrees { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<ManufacturersOfNewLinkage> ManufacturersOfNewLinkages { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Motorbike> Motorbikes { get; set; }

    public virtual DbSet<MotorbikeAttribute> MotorbikeAttributes { get; set; }

    public virtual DbSet<MotorbikePd> MotorbikePds { get; set; }

    public virtual DbSet<MotorbikePrd> MotorbikePrds { get; set; }

    public virtual DbSet<MotorbikeQsi> MotorbikeQsis { get; set; }

    public virtual DbSet<MotorbikeTree> MotorbikeTrees { get; set; }

    public virtual DbSet<PassangerCar> PassangerCars { get; set; }

    public virtual DbSet<PassangerCarAttribute> PassangerCarAttributes { get; set; }

    public virtual DbSet<PassangerCarEngine> PassangerCarEngines { get; set; }

    public virtual DbSet<PassangerCarPd> PassangerCarPds { get; set; }

    public virtual DbSet<PassangerCarPrd> PassangerCarPrds { get; set; }

    public virtual DbSet<PassangerCarQsi> PassangerCarQsis { get; set; }

    public virtual DbSet<PassangerCarTree> PassangerCarTrees { get; set; }

    public virtual DbSet<Prd> Prds { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierDetail> SupplierDetails { get; set; }

    public virtual DbSet<SuppliersWithNvArticle> SuppliersWithNvArticles { get; set; }

    public virtual DbSet<SuppliersWithNvLinkage> SuppliersWithNvLinkages { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     // => optionsBuilder.UseSqlServer("Server=DESKTOP-0NE5VP2;Database=td1q2018;Trusted_Connection=True;TrustServerCertificate=True;");
    // }
        
    
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => new { e.SupplierId, e.DataSupplierArticleNumber }).HasName("PK_articles_supplierId");
    
            entity.ToTable("articles", "td1q2018");
    
            entity.HasIndex(e => e.DataSupplierArticleNumber, "DataSupplierArticleNumber");
    
            entity.HasIndex(e => e.FoundString, "FoundString");
    
            entity.HasIndex(e => e.SupplierId, "supplierId");
    
            entity.Property(e => e.SupplierId).HasColumnName("supplierId");
            entity.Property(e => e.DataSupplierArticleNumber).HasMaxLength(32);
            entity.Property(e => e.ArticleStateDisplayValue).HasMaxLength(128);
            entity.Property(e => e.Description).HasMaxLength(128);
            entity.Property(e => e.FlagAccessory).HasMaxLength(5);
            entity.Property(e => e.FlagMaterialCertification).HasMaxLength(5);
            entity.Property(e => e.FlagRemanufactured).HasMaxLength(5);
            entity.Property(e => e.FlagSelfServicePacking).HasMaxLength(5);
            entity.Property(e => e.FoundString).HasMaxLength(64);
            entity.Property(e => e.HasAxle).HasMaxLength(5);
            entity.Property(e => e.HasCommercialVehicle).HasMaxLength(5);
            entity.Property(e => e.HasCvmanuId)
                .HasMaxLength(5)
                .HasColumnName("HasCVManuID");
            entity.Property(e => e.HasEngine).HasMaxLength(5);
            entity.Property(e => e.HasLinkitems).HasMaxLength(5);
            entity.Property(e => e.HasMotorbike).HasMaxLength(5);
            entity.Property(e => e.HasPassengerCar).HasMaxLength(5);
            entity.Property(e => e.IsValid).HasMaxLength(5);
            entity.Property(e => e.LotSize1).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.LotSize2).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.NormalizedDescription).HasMaxLength(128);
            entity.Property(e => e.PackingUnit).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.QuantityPerPackingUnit).HasDefaultValueSql("(NULL)");
    
            entity.HasOne(d => d.Supplier).WithMany(p => p.Articles)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("articles_supplier___fk");
        });
    
        modelBuilder.Entity<ArticleAcc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("article_acc", "td1q2018");
    
            entity.HasIndex(e => e.AccDataSupplierArticleNumber, "AccDataSupplierArticleNumber");
    
            entity.HasIndex(e => e.AccSupplierId, "AccSupplierId");
    
            entity.HasIndex(e => e.DataSupplierArticleNumber, "DataSupplierArticleNumber");
    
            entity.HasIndex(e => e.SupplierId, "supplierId");
    
            entity.Property(e => e.AccDataSupplierArticleNumber).HasMaxLength(32);
            entity.Property(e => e.DataSupplierArticleNumber).HasMaxLength(32);
            entity.Property(e => e.SupplierId).HasColumnName("supplierId");
    
            entity.HasOne(d => d.Supplier).WithMany()
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("supplier_id___fk");
        });
    
        modelBuilder.Entity<ArticleAttribute>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("article_attributes", "td1q2018");
    
            entity.HasIndex(e => new { e.Supplierid, e.Datasupplierarticlenumber }, "article");
    
            entity.HasIndex(e => e.Id, "id");
    
            entity.Property(e => e.Datasupplierarticlenumber)
                .HasMaxLength(32)
                .HasColumnName("datasupplierarticlenumber");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Displaytitle)
                .HasMaxLength(128)
                .HasColumnName("displaytitle");
            entity.Property(e => e.Displayvalue)
                .HasMaxLength(4000)
                .HasColumnName("displayvalue");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
        });
    
        modelBuilder.Entity<ArticleCross>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("article_cross", "td1q2018");
    
            entity.HasIndex(e => e.Oenbr, "OENbr");
    
            entity.HasIndex(e => new { e.SupplierId, e.PartsDataSupplierArticleNumber }, "SupplierId");
    
            entity.HasIndex(e => e.ManufacturerId, "manufacturerId");
    
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturerId");
            entity.Property(e => e.Oenbr)
                .HasMaxLength(64)
                .HasColumnName("OENbr");
            entity.Property(e => e.PartsDataSupplierArticleNumber).HasMaxLength(32);
        });
    
        modelBuilder.Entity<ArticleEan>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("article_ean", "td1q2018");
    
            entity.HasIndex(e => e.Ean, "ean");
    
            entity.HasIndex(e => new { e.Supplierid, e.Datasupplierarticlenumber }, "supplierid");
    
            entity.Property(e => e.Datasupplierarticlenumber)
                .HasMaxLength(32)
                .HasColumnName("datasupplierarticlenumber");
            entity.Property(e => e.Ean)
                .HasMaxLength(24)
                .HasColumnName("ean");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
        });
    
        modelBuilder.Entity<ArticleImage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("article_images", "td1q2018");
    
            entity.HasIndex(e => e.DocumentType, "DocumentType");
    
            entity.HasIndex(e => new { e.SupplierId, e.DataSupplierArticleNumber }, "supplierId");
    
            entity.Property(e => e.AdditionalDescription).HasMaxLength(64);
            entity.Property(e => e.DataSupplierArticleNumber).HasMaxLength(32);
            entity.Property(e => e.Description).HasMaxLength(64);
            entity.Property(e => e.DocumentName).HasMaxLength(128);
            entity.Property(e => e.DocumentType).HasMaxLength(8);
            entity.Property(e => e.NormedDescriptionId).HasColumnName("NormedDescriptionID");
            entity.Property(e => e.PictureName).HasMaxLength(64);
            entity.Property(e => e.ShowImmediately).HasMaxLength(5);
            entity.Property(e => e.SupplierId).HasColumnName("supplierId");
        });
    
        modelBuilder.Entity<ArticleInf>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("article_inf", "td1q2018");
    
            entity.HasIndex(e => new { e.SupplierId, e.DataSupplierArticleNumber }, "supplierId");
    
            entity.Property(e => e.DataSupplierArticleNumber).HasMaxLength(32);
            entity.Property(e => e.InformationType).HasMaxLength(64);
            entity.Property(e => e.SupplierId).HasColumnName("supplierId");
        });
    
        modelBuilder.Entity<ArticleLi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("article_li", "td1q2018");
    
            entity.HasIndex(e => e.LinkageTypeId, "linkageTypeId");
    
            entity.HasIndex(e => new { e.SupplierId, e.DataSupplierArticleNumber }, "supplierId");
    
            entity.Property(e => e.DataSupplierArticleNumber).HasMaxLength(32);
            entity.Property(e => e.LinkageId).HasColumnName("linkageId");
            entity.Property(e => e.LinkageTypeId)
                .HasMaxLength(32)
                .HasColumnName("linkageTypeId");
            entity.Property(e => e.SupplierId).HasColumnName("supplierId");
        });
    
        modelBuilder.Entity<ArticleLink>(entity =>
        {
            entity.HasKey(e => new { e.Supplierid, e.Productid, e.Linkageid, e.Linkagetypeid, e.Datasupplierarticlenumber }).HasName("PK_article_links_supplierid");
    
            entity.ToTable("article_links", "td1q2018");
    
            entity.HasIndex(e => e.Datasupplierarticlenumber, "datasupplierarticlenumber");
    
            entity.HasIndex(e => e.Linkageid, "linkageid");
    
            entity.HasIndex(e => e.Linkagetypeid, "linkagetypeid");
    
            entity.HasIndex(e => e.Productid, "productid");
    
            entity.HasIndex(e => e.Supplierid, "supplierid");
    
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Linkageid).HasColumnName("linkageid");
            entity.Property(e => e.Linkagetypeid).HasColumnName("linkagetypeid");
            entity.Property(e => e.Datasupplierarticlenumber)
                .HasMaxLength(32)
                .HasColumnName("datasupplierarticlenumber");
        });
    
        modelBuilder.Entity<ArticleNn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("article_nn", "td1q2018");
    
            entity.HasIndex(e => new { e.Supplierid, e.Datasupplierarticlenumber }, "supplierid");
    
            entity.Property(e => e.Datasupplierarticlenumber)
                .HasMaxLength(32)
                .HasColumnName("datasupplierarticlenumber");
            entity.Property(e => e.Newdatasupplierarticlenumber)
                .HasMaxLength(32)
                .HasColumnName("newdatasupplierarticlenumber");
            entity.Property(e => e.Newnbr)
                .HasMaxLength(32)
                .HasColumnName("newnbr");
            entity.Property(e => e.Newsupplierid).HasColumnName("newsupplierid");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
        });
    
        modelBuilder.Entity<ArticleNumber>(entity =>
        {
            entity.HasKey(e => new { e.Supplierid, e.Datasupplierarticlenumber }).HasName("PK_article_numbers_supplierid");
    
            entity.ToTable("article_numbers", "td1q2018");
    
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
            entity.Property(e => e.Datasupplierarticlenumber)
                .HasMaxLength(32)
                .HasColumnName("datasupplierarticlenumber");
        });
    
        modelBuilder.Entity<ArticleOe>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("article_oe", "td1q2018");
    
            entity.HasIndex(e => e.Oenbr, "OENbr");
    
            entity.HasIndex(e => e.ManufacturerId, "manufacturerId");
    
            entity.HasIndex(e => new { e.Supplierid, e.Datasupplierarticlenumber }, "supplierid");
    
            entity.Property(e => e.Datasupplierarticlenumber)
                .HasMaxLength(32)
                .HasColumnName("datasupplierarticlenumber");
            entity.Property(e => e.IsAdditive).HasMaxLength(5);
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturerId");
            entity.Property(e => e.Oenbr)
                .HasMaxLength(64)
                .HasColumnName("OENbr");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
        });
    
        modelBuilder.Entity<ArticlePart>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("article_parts", "td1q2018");
    
            entity.HasIndex(e => new { e.SupplierId, e.DataSupplierArticleNumber }, "supplierId");
    
            entity.Property(e => e.DataSupplierArticleNumber).HasMaxLength(32);
            entity.Property(e => e.PartsDataSupplierArticleNumber).HasMaxLength(32);
            entity.Property(e => e.SupplierId).HasColumnName("supplierId");
        });
    
        modelBuilder.Entity<ArticlePrd>(entity =>
        {
            entity.HasKey(e => new { e.Supplierid, e.Datasupplierarticlenumber, e.ProductId }).HasName("PK_article_prd_supplierid");
    
            entity.ToTable("article_prd", "td1q2018");
    
            entity.HasIndex(e => new { e.Supplierid, e.Datasupplierarticlenumber }, "supplierid");
    
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
            entity.Property(e => e.Datasupplierarticlenumber)
                .HasMaxLength(32)
                .HasColumnName("datasupplierarticlenumber");
            entity.Property(e => e.ProductId).HasColumnName("productId");
        });
    
        modelBuilder.Entity<ArticleRn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("article_rn", "td1q2018");
    
            entity.HasIndex(e => new { e.Supplierid, e.Datasupplierarticlenumber }, "supplierid");
    
            entity.Property(e => e.Datasupplierarticlenumber)
                .HasMaxLength(32)
                .HasColumnName("datasupplierarticlenumber");
            entity.Property(e => e.Replacedatasupplierarticlenumber)
                .HasMaxLength(32)
                .HasColumnName("replacedatasupplierarticlenumber");
            entity.Property(e => e.Replacedupplierid).HasColumnName("replacedupplierid");
            entity.Property(e => e.Replacenbr)
                .HasMaxLength(32)
                .HasColumnName("replacenbr");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
        });
    
        modelBuilder.Entity<ArticleUn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("article_un", "td1q2018");
    
            entity.HasIndex(e => new { e.Supplierid, e.Datasupplierarticlenumber }, "supplierid");
    
            entity.Property(e => e.Datasupplierarticlenumber)
                .HasMaxLength(32)
                .HasColumnName("datasupplierarticlenumber");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
            entity.Property(e => e.Utilityno)
                .HasMaxLength(64)
                .HasColumnName("utilityno");
        });
    
        modelBuilder.Entity<Axle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_axles_id");
    
            entity.ToTable("axles", "td1q2018");
    
            entity.HasIndex(e => new { e.Canbedisplayed, e.Isaxle, e.Istransporter, e.Iscommercialvehicle, e.Iscvmanufacturerid, e.Isengine, e.Ismotorbike, e.Ispassengercar }, "id");
    
            entity.HasIndex(e => e.Modelid, "modelid");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Canbedisplayed)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("canbedisplayed");
            entity.Property(e => e.Constructioninterval)
                .HasMaxLength(24)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("constructioninterval");
            entity.Property(e => e.Description)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Fulldescription)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("fulldescription");
            entity.Property(e => e.Haslink)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("haslink");
            entity.Property(e => e.Isaxle)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isaxle");
            entity.Property(e => e.Iscommercialvehicle)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("iscommercialvehicle");
            entity.Property(e => e.Iscvmanufacturerid)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("iscvmanufacturerid");
            entity.Property(e => e.Isengine)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isengine");
            entity.Property(e => e.Ismotorbike)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ismotorbike");
            entity.Property(e => e.Ispassengercar)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ispassengercar");
            entity.Property(e => e.Istransporter)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("istransporter");
            entity.Property(e => e.Modelid)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("modelid");
        });
    
        modelBuilder.Entity<AxleAttribute>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("axle_attributes", "td1q2018");
    
            entity.HasIndex(e => e.Attributegroup, "attributegroup");
    
            entity.HasIndex(e => e.Axleid, "axleid");
    
            entity.Property(e => e.Attributegroup)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("attributegroup");
            entity.Property(e => e.Attributetype)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("attributetype");
            entity.Property(e => e.Axleid).HasColumnName("axleid");
            entity.Property(e => e.Displaytitle)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("displaytitle");
            entity.Property(e => e.Displayvalue)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("displayvalue");
        });
    
        modelBuilder.Entity<AxlePd>(entity =>
        {
            entity.HasKey(e => new { e.Axleid, e.Nodeid, e.Productid, e.Supplierid }).HasName("PK_axle_pds_axleid");
    
            entity.ToTable("axle_pds", "td1q2018");
    
            entity.HasIndex(e => e.Axleid, "axleid");
    
            entity.HasIndex(e => e.Supplierid, "supplierid");
    
            entity.Property(e => e.Axleid).HasColumnName("axleid");
            entity.Property(e => e.Nodeid).HasColumnName("nodeid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
        });
    
        modelBuilder.Entity<AxlePrd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_axle_prd_id");
    
            entity.ToTable("axle_prd", "td1q2018");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Assemblygroupdescription)
                .HasMaxLength(128)
                .HasColumnName("assemblygroupdescription");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasColumnName("description");
            entity.Property(e => e.Normalizeddescription)
                .HasMaxLength(128)
                .HasColumnName("normalizeddescription");
            entity.Property(e => e.Usagedescription)
                .HasMaxLength(128)
                .HasColumnName("usagedescription");
        });
    
        modelBuilder.Entity<AxleTree>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("axle_trees", "td1q2018");
    
            entity.HasIndex(e => e.Axleid, "axleid");
    
            entity.HasIndex(e => e.Id, "id");
    
            entity.HasIndex(e => e.Parentid, "parentid");
    
            entity.Property(e => e.Axleid).HasColumnName("axleid");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Parentid)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("parentid");
            entity.Property(e => e.Searchtreeid).HasColumnName("searchtreeid");
        });
    
        modelBuilder.Entity<CommercialDriverCab>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("commercial_driver_cabs", "td1q2018");
    
            entity.HasIndex(e => e.Drivercabid, "drivercabid");
    
            entity.HasIndex(e => e.Id, "id");
    
            entity.Property(e => e.Drivercabid).HasColumnName("drivercabid");
            entity.Property(e => e.Id).HasColumnName("id");
        });
    
        modelBuilder.Entity<CommercialVehicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_commercial_vehicles_id");
    
            entity.ToTable("commercial_vehicles", "td1q2018");
    
            entity.HasIndex(e => new { e.Canbedisplayed, e.Isaxle, e.Iscommercialvehicle, e.Iscvmanufacturerid, e.Isengine, e.Ismotorbike, e.Ispassengercar, e.Istransporter }, "id");
    
            entity.HasIndex(e => e.Modelid, "modelid");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Canbedisplayed)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("canbedisplayed");
            entity.Property(e => e.Constructioninterval)
                .HasMaxLength(24)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("constructioninterval");
            entity.Property(e => e.Description)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Fulldescription)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("fulldescription");
            entity.Property(e => e.Haslink)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("haslink");
            entity.Property(e => e.Isaxle)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isaxle");
            entity.Property(e => e.Iscommercialvehicle)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("iscommercialvehicle");
            entity.Property(e => e.Iscvmanufacturerid)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("iscvmanufacturerid");
            entity.Property(e => e.Isengine)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isengine");
            entity.Property(e => e.Ismotorbike)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ismotorbike");
            entity.Property(e => e.Ispassengercar)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ispassengercar");
            entity.Property(e => e.Istransporter)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("istransporter");
            entity.Property(e => e.Modelid)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("modelid");
        });
    
        modelBuilder.Entity<CommercialVehicleAttribute>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("commercial_vehicle_attributes", "td1q2018");
    
            entity.HasIndex(e => e.Attributegroup, "attributegroup");
    
            entity.HasIndex(e => e.Commercialvehicleid, "commercialvehicleid");
    
            entity.Property(e => e.Attributegroup)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("attributegroup");
            entity.Property(e => e.Attributetype)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("attributetype");
            entity.Property(e => e.Commercialvehicleid).HasColumnName("commercialvehicleid");
            entity.Property(e => e.Displaytitle)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("displaytitle");
            entity.Property(e => e.Displayvalue)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("displayvalue");
        });
    
        modelBuilder.Entity<CommercialVehicleAxle>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("commercial_vehicle_axles", "td1q2018");
    
            entity.HasIndex(e => e.Axleid, "axleid");
    
            entity.HasIndex(e => e.Id, "id");
    
            entity.Property(e => e.Axleid).HasColumnName("axleid");
            entity.Property(e => e.Id).HasColumnName("id");
        });
    
        modelBuilder.Entity<CommercialVehicleEngine>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("commercial_vehicle_engines", "td1q2018");
    
            entity.HasIndex(e => e.Engineid, "engineid");
    
            entity.HasIndex(e => e.Id, "id");
    
            entity.Property(e => e.Engineid).HasColumnName("engineid");
            entity.Property(e => e.Id).HasColumnName("id");
        });
    
        modelBuilder.Entity<CommercialVehiclePd>(entity =>
        {
            entity.HasKey(e => new { e.Commertialvehicleid, e.Nodeid, e.Productid, e.Supplierid }).HasName("PK_commercial_vehicle_pds_commertialvehicleid");
    
            entity.ToTable("commercial_vehicle_pds", "td1q2018");
    
            entity.HasIndex(e => e.Commertialvehicleid, "commertialvehicleid");
    
            entity.HasIndex(e => new { e.Supplierid, e.Productid }, "supplierid");
    
            entity.Property(e => e.Commertialvehicleid).HasColumnName("commertialvehicleid");
            entity.Property(e => e.Nodeid).HasColumnName("nodeid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
        });
    
        modelBuilder.Entity<CommercialVehiclePrd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_commercial_vehicle_prd_id");
    
            entity.ToTable("commercial_vehicle_prd", "td1q2018");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Assemblygroupdescription)
                .HasMaxLength(128)
                .HasColumnName("assemblygroupdescription");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasColumnName("description");
            entity.Property(e => e.Normalizeddescription)
                .HasMaxLength(128)
                .HasColumnName("normalizeddescription");
            entity.Property(e => e.Usagedescription)
                .HasMaxLength(128)
                .HasColumnName("usagedescription");
        });
    
        modelBuilder.Entity<CommercialVehicleQsi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("commercial_vehicle_qsi", "td1q2018");
    
            entity.HasIndex(e => e.Commercialvehicleid, "commercialvehicleid");
    
            entity.Property(e => e.Commercialvehicleid).HasColumnName("commercialvehicleid");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Quickstarttype)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("quickstarttype");
        });
    
        modelBuilder.Entity<CommercialVehicleSubType>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Subtypeid }).HasName("PK_commercial_vehicle_sub_types_id");
    
            entity.ToTable("commercial_vehicle_sub_types", "td1q2018");
    
            entity.HasIndex(e => e.Id, "id");
    
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Subtypeid).HasColumnName("subtypeid");
        });
    
        modelBuilder.Entity<CommercialVehicleTree>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("commercial_vehicle_trees", "td1q2018");
    
            entity.HasIndex(e => e.Commercialvehicleid, "commercialvehicleid");
    
            entity.HasIndex(e => e.Id, "id");
    
            entity.HasIndex(e => e.Parentid, "parentid");
    
            entity.Property(e => e.Commercialvehicleid).HasColumnName("commercialvehicleid");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Parentid)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("parentid");
            entity.Property(e => e.Searchtreeid).HasColumnName("searchtreeid");
        });
    
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Countrycode).HasName("PK_countries_countrycode");
    
            entity.ToTable("countries", "td1q2018");
    
            entity.Property(e => e.Countrycode)
                .HasMaxLength(4)
                .HasColumnName("countrycode");
            entity.Property(e => e.Currencycode)
                .HasMaxLength(4)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("currencycode");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Isgroup)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isgroup");
            entity.Property(e => e.Isocode2)
                .HasMaxLength(4)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isocode2");
            entity.Property(e => e.Isocode3)
                .HasMaxLength(4)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isocode3");
            entity.Property(e => e.Isocodeno)
                .HasMaxLength(4)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isocodeno");
        });
    
        modelBuilder.Entity<CountryGroup>(entity =>
        {
            entity.HasKey(e => e.Countrycode).HasName("PK_country_groups_countrycode");
    
            entity.ToTable("country_groups", "td1q2018");
    
            entity.Property(e => e.Countrycode)
                .HasMaxLength(4)
                .HasColumnName("countrycode");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
        });
    
        modelBuilder.Entity<Engine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_engines_id");
    
            entity.ToTable("engines", "td1q2018");
    
            entity.HasIndex(e => new { e.Canbedisplayed, e.Isaxle, e.Iscommercialvehicle, e.Iscvmanufacturerid, e.Isengine, e.Ismotorbike, e.Ispassengercar, e.Istransporter }, "id");
    
            entity.HasIndex(e => e.Manufacturerid, "manufacturerid");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Canbedisplayed)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("canbedisplayed");
            entity.Property(e => e.Constructioninterval)
                .HasMaxLength(24)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("constructioninterval");
            entity.Property(e => e.Description)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Fulldescription)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("fulldescription");
            entity.Property(e => e.Haslink)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("haslink");
            entity.Property(e => e.Haslinkitem)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("haslinkitem");
            entity.Property(e => e.Isaxle)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isaxle");
            entity.Property(e => e.Iscommercialvehicle)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("iscommercialvehicle");
            entity.Property(e => e.Iscvmanufacturerid)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("iscvmanufacturerid");
            entity.Property(e => e.Isengine)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isengine");
            entity.Property(e => e.Ismotorbike)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ismotorbike");
            entity.Property(e => e.Ispassengercar)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ispassengercar");
            entity.Property(e => e.Istransporter)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("istransporter");
            entity.Property(e => e.Manufacturerid)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("manufacturerid");
            entity.Property(e => e.Salesdescription)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("salesdescription");
        });
    
        modelBuilder.Entity<EngineAttribute>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("engine_attributes", "td1q2018");
    
            entity.HasIndex(e => e.Attributegroup, "attributegroup");
    
            entity.HasIndex(e => e.Engineid, "engineid");
    
            entity.Property(e => e.Attributegroup)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("attributegroup");
            entity.Property(e => e.Attributetype)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("attributetype");
            entity.Property(e => e.Displaytitle)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("displaytitle");
            entity.Property(e => e.Displayvalue)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("displayvalue");
            entity.Property(e => e.Engineid).HasColumnName("engineid");
        });
    
        modelBuilder.Entity<EnginePd>(entity =>
        {
            entity.HasKey(e => new { e.Engineid, e.Nodeid, e.Productid, e.Supplierid }).HasName("PK_engine_pds_engineid");
    
            entity.ToTable("engine_pds", "td1q2018");
    
            entity.HasIndex(e => e.Engineid, "engineid");
    
            entity.HasIndex(e => e.Supplierid, "supplierid");
    
            entity.Property(e => e.Engineid).HasColumnName("engineid");
            entity.Property(e => e.Nodeid).HasColumnName("nodeid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
        });
    
        modelBuilder.Entity<EnginePrd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_engine_prd_id");
    
            entity.ToTable("engine_prd", "td1q2018");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Assemblygroupdescription)
                .HasMaxLength(128)
                .HasColumnName("assemblygroupdescription");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasColumnName("description");
            entity.Property(e => e.Normalizeddescription)
                .HasMaxLength(128)
                .HasColumnName("normalizeddescription");
            entity.Property(e => e.Usagedescription)
                .HasMaxLength(128)
                .HasColumnName("usagedescription");
        });
    
        modelBuilder.Entity<EngineTree>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("engine_trees", "td1q2018");
    
            entity.HasIndex(e => e.Engineid, "engineid");
    
            entity.HasIndex(e => e.Id, "id");
    
            entity.HasIndex(e => e.Parentid, "parentid");
    
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Engineid).HasColumnName("engineid");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Parentid)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("parentid");
            entity.Property(e => e.Searchtreeid).HasColumnName("searchtreeid");
        });
    
        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_languages_id");
    
            entity.ToTable("languages", "td1q2018");
    
            entity.HasIndex(e => e.Isocode2, "isocode2");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Codepage)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("codepage");
            entity.Property(e => e.Description)
                .HasMaxLength(16)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Isocode2)
                .HasMaxLength(2)
                .HasDefaultValueSql("(NULL)")
                .IsFixedLength()
                .HasColumnName("isocode2");
        });
    
        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Isaxle, e.Iscommercialvehicle, e.Isengine, e.Ismotorbike, e.Ispassengercar, e.Istransporter }).HasName("PK_manufacturers_id");
    
            entity.ToTable("manufacturers", "td1q2018");
    
            entity.HasIndex(e => e.Canbedisplayed, "canbedisplayed");
    
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Isaxle)
                .HasMaxLength(5)
                .HasColumnName("isaxle");
            entity.Property(e => e.Iscommercialvehicle)
                .HasMaxLength(5)
                .HasColumnName("iscommercialvehicle");
            entity.Property(e => e.Isengine)
                .HasMaxLength(5)
                .HasColumnName("isengine");
            entity.Property(e => e.Ismotorbike)
                .HasMaxLength(5)
                .HasColumnName("ismotorbike");
            entity.Property(e => e.Ispassengercar)
                .HasMaxLength(5)
                .HasColumnName("ispassengercar");
            entity.Property(e => e.Istransporter)
                .HasMaxLength(5)
                .HasColumnName("istransporter");
            entity.Property(e => e.Canbedisplayed)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("canbedisplayed");
            entity.Property(e => e.Description)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Fulldescription)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("fulldescription");
            entity.Property(e => e.Haslink)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("haslink");
            entity.Property(e => e.Isvgl)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isvgl");
            entity.Property(e => e.Matchcode)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("matchcode");
        });
    
        modelBuilder.Entity<ManufacturersOfNewLinkage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("manufacturers_of_new_linkages", "td1q2018");
    
            entity.HasIndex(e => new { e.Canbedisplayed, e.Isaxle, e.Iscommercialvehicle, e.Iscvmanufacturerid, e.Isengine, e.Ismotorbike, e.Ispassengercar, e.Istransporter }, "canbedisplayed");
    
            entity.HasIndex(e => e.Id, "id");
    
            entity.HasIndex(e => e.SupplierId, "supplier_id");
    
            entity.Property(e => e.Canbedisplayed)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("canbedisplayed");
            entity.Property(e => e.Description)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Fulldescription)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("fulldescription");
            entity.Property(e => e.Haslink)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("haslink");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Isaxle)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isaxle");
            entity.Property(e => e.Iscommercialvehicle)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("iscommercialvehicle");
            entity.Property(e => e.Iscvmanufacturerid)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("iscvmanufacturerid");
            entity.Property(e => e.Isengine)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isengine");
            entity.Property(e => e.Ismotorbike)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ismotorbike");
            entity.Property(e => e.Ispassengercar)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ispassengercar");
            entity.Property(e => e.Istransporter)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("istransporter");
            entity.Property(e => e.Isvgl)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isvgl");
            entity.Property(e => e.Linkitemtype)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("linkitemtype");
            entity.Property(e => e.Matchcode)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("matchcode");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
        });
    
        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Isaxle, e.Istransporter, e.Ispassengercar, e.Ismotorbike, e.Isengine, e.Iscommercialvehicle }).HasName("PK_models_id");
    
            entity.ToTable("models", "td1q2018");
    
            entity.HasIndex(e => e.Canbedisplayed, "canbedisplayed");
    
            entity.HasIndex(e => e.Manufacturerid, "manufacturerid");
    
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Isaxle)
                .HasMaxLength(5)
                .HasColumnName("isaxle");
            entity.Property(e => e.Istransporter)
                .HasMaxLength(5)
                .HasColumnName("istransporter");
            entity.Property(e => e.Ispassengercar)
                .HasMaxLength(5)
                .HasColumnName("ispassengercar");
            entity.Property(e => e.Ismotorbike)
                .HasMaxLength(5)
                .HasColumnName("ismotorbike");
            entity.Property(e => e.Isengine)
                .HasMaxLength(5)
                .HasColumnName("isengine");
            entity.Property(e => e.Iscommercialvehicle)
                .HasMaxLength(5)
                .HasColumnName("iscommercialvehicle");
            entity.Property(e => e.Canbedisplayed)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("canbedisplayed");
            entity.Property(e => e.Constructioninterval)
                .HasMaxLength(24)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("constructioninterval");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Fulldescription)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("fulldescription");
            entity.Property(e => e.Haslink)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("haslink");
            entity.Property(e => e.Manufacturerid)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("manufacturerid");
        });
    
        modelBuilder.Entity<Motorbike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_motorbikes_id");
    
            entity.ToTable("motorbikes", "td1q2018");
    
            entity.HasIndex(e => new { e.Canbedisplayed, e.Isaxle, e.Iscommercialvehicle, e.Iscvmanufacturerid, e.Isengine, e.Ismotorbike, e.Ispassengercar, e.Istransporter }, "id");
    
            entity.HasIndex(e => e.Modelid, "modelid");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Canbedisplayed)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("canbedisplayed");
            entity.Property(e => e.Constructioninterval)
                .HasMaxLength(24)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("constructioninterval");
            entity.Property(e => e.Description)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Fulldescription)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("fulldescription");
            entity.Property(e => e.Haslink)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("haslink");
            entity.Property(e => e.Isaxle)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isaxle");
            entity.Property(e => e.Iscommercialvehicle)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("iscommercialvehicle");
            entity.Property(e => e.Iscvmanufacturerid)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("iscvmanufacturerid");
            entity.Property(e => e.Isengine)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isengine");
            entity.Property(e => e.Ismotorbike)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ismotorbike");
            entity.Property(e => e.Ispassengercar)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ispassengercar");
            entity.Property(e => e.Istransporter)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("istransporter");
            entity.Property(e => e.Modelid)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("modelid");
        });
    
        modelBuilder.Entity<MotorbikeAttribute>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("motorbike_attributes", "td1q2018");
    
            entity.HasIndex(e => e.Attributegroup, "attributegroup");
    
            entity.HasIndex(e => e.Motorbikeid, "motorbikeid");
    
            entity.Property(e => e.Attributegroup)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("attributegroup");
            entity.Property(e => e.Attributetype)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("attributetype");
            entity.Property(e => e.Displaytitle)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("displaytitle");
            entity.Property(e => e.Displayvalue)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("displayvalue");
            entity.Property(e => e.Motorbikeid).HasColumnName("motorbikeid");
        });
    
        modelBuilder.Entity<MotorbikePd>(entity =>
        {
            entity.HasKey(e => new { e.Motorbikeid, e.Nodeid, e.Productid, e.Supplierid }).HasName("PK_motorbike_pds_motorbikeid");
    
            entity.ToTable("motorbike_pds", "td1q2018");
    
            entity.HasIndex(e => e.Motorbikeid, "motorbikeid");
    
            entity.HasIndex(e => new { e.Productid, e.Supplierid }, "productid");
    
            entity.Property(e => e.Motorbikeid).HasColumnName("motorbikeid");
            entity.Property(e => e.Nodeid).HasColumnName("nodeid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
        });
    
        modelBuilder.Entity<MotorbikePrd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_motorbike_prd_id");
    
            entity.ToTable("motorbike_prd", "td1q2018");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Assemblygroupdescription)
                .HasMaxLength(128)
                .HasColumnName("assemblygroupdescription");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasColumnName("description");
            entity.Property(e => e.Normalizeddescription)
                .HasMaxLength(128)
                .HasColumnName("normalizeddescription");
            entity.Property(e => e.Usagedescription)
                .HasMaxLength(128)
                .HasColumnName("usagedescription");
        });
    
        modelBuilder.Entity<MotorbikeQsi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("motorbike_qsi", "td1q2018");
    
            entity.HasIndex(e => e.Motorbikeid, "motorbikeid");
    
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Motorbikeid).HasColumnName("motorbikeid");
            entity.Property(e => e.Quickstarttype)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("quickstarttype");
        });
    
        modelBuilder.Entity<MotorbikeTree>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("motorbike_trees", "td1q2018");
    
            entity.HasIndex(e => e.Id, "id");
    
            entity.HasIndex(e => e.Motorbikeid, "motorbikeid");
    
            entity.HasIndex(e => e.Parentid, "parentid");
    
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Motorbikeid).HasColumnName("motorbikeid");
            entity.Property(e => e.Parentid)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("parentid");
            entity.Property(e => e.Searchtreeid).HasColumnName("searchtreeid");
        });
    
        modelBuilder.Entity<PassangerCar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_passanger_cars_id");
    
            entity.ToTable("passanger_cars", "td1q2018");
    
            entity.HasIndex(e => new { e.Canbedisplayed, e.Isaxle, e.Iscommercialvehicle, e.Iscvmanufacturerid, e.Isengine, e.Ismotorbike, e.Ispassengercar, e.Istransporter }, "id");
    
            entity.HasIndex(e => e.Modelid, "modelid");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Canbedisplayed)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("canbedisplayed");
            entity.Property(e => e.Constructioninterval)
                .HasMaxLength(24)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("constructioninterval");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Fulldescription)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("fulldescription");
            entity.Property(e => e.Haslink)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("haslink");
            entity.Property(e => e.Isaxle)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isaxle");
            entity.Property(e => e.Iscommercialvehicle)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("iscommercialvehicle");
            entity.Property(e => e.Iscvmanufacturerid)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("iscvmanufacturerid");
            entity.Property(e => e.Isengine)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("isengine");
            entity.Property(e => e.Ismotorbike)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ismotorbike");
            entity.Property(e => e.Ispassengercar)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ispassengercar");
            entity.Property(e => e.Istransporter)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("istransporter");
            entity.Property(e => e.Modelid)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("modelid");
        });
    
        modelBuilder.Entity<PassangerCarAttribute>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("passanger_car_attributes", "td1q2018");
    
            entity.HasIndex(e => e.Attributegroup, "attributegroup");
    
            entity.HasIndex(e => e.Passangercarid, "passangercarid");
    
            entity.Property(e => e.Attributegroup)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("attributegroup");
            entity.Property(e => e.Attributetype)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("attributetype");
            entity.Property(e => e.Displaytitle)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("displaytitle");
            entity.Property(e => e.Displayvalue)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("displayvalue");
            entity.Property(e => e.Passangercarid).HasColumnName("passangercarid");
        });
    
        modelBuilder.Entity<PassangerCarEngine>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("passanger_car_engines", "td1q2018");
    
            entity.HasIndex(e => e.Engineid, "engineid");
    
            entity.HasIndex(e => e.Id, "id");
    
            entity.Property(e => e.Engineid).HasColumnName("engineid");
            entity.Property(e => e.Id).HasColumnName("id");
        });
    
        modelBuilder.Entity<PassangerCarPd>(entity =>
        {
            entity.HasKey(e => new { e.Passangercarid, e.Nodeid, e.Productid, e.Supplierid }).HasName("PK_passanger_car_pds_passangercarid");
    
            entity.ToTable("passanger_car_pds", "td1q2018");
    
            entity.HasIndex(e => e.Nodeid, "nodeid");
    
            entity.HasIndex(e => e.Passangercarid, "passangercarid");
    
            entity.HasIndex(e => e.Productid, "productid");
    
            entity.HasIndex(e => e.Supplierid, "supplierid");
    
            entity.Property(e => e.Passangercarid).HasColumnName("passangercarid");
            entity.Property(e => e.Nodeid).HasColumnName("nodeid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
        });
    
        modelBuilder.Entity<PassangerCarPrd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_passanger_car_prd_id");
    
            entity.ToTable("passanger_car_prd", "td1q2018");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Assemblygroupdescription)
                .HasMaxLength(128)
                .HasColumnName("assemblygroupdescription");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasColumnName("description");
            entity.Property(e => e.Normalizeddescription)
                .HasMaxLength(128)
                .HasColumnName("normalizeddescription");
            entity.Property(e => e.Usagedescription)
                .HasMaxLength(128)
                .HasColumnName("usagedescription");
        });
    
        modelBuilder.Entity<PassangerCarQsi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("passanger_car_qsi", "td1q2018");
    
            entity.HasIndex(e => e.Passangercarid, "passangercarid");
    
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Passangercarid).HasColumnName("passangercarid");
            entity.Property(e => e.Quickstarttype)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("quickstarttype");
        });
    
        modelBuilder.Entity<PassangerCarTree>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("passanger_car_trees", "td1q2018");
    
            entity.HasIndex(e => e.Id, "id");
    
            entity.HasIndex(e => e.Parentid, "parentid");
    
            entity.HasIndex(e => e.Passangercarid, "passangercarid");
    
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Parentid)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("parentid");
            entity.Property(e => e.Passangercarid).HasColumnName("passangercarid");
            entity.Property(e => e.Searchtreeid).HasColumnName("searchtreeid");
        });
    
        modelBuilder.Entity<Prd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_prd_id");
    
            entity.ToTable("prd", "td1q2018");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Assemblygroupdescription)
                .HasMaxLength(128)
                .HasColumnName("assemblygroupdescription");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasColumnName("description");
            entity.Property(e => e.Normalizeddescription)
                .HasMaxLength(128)
                .HasColumnName("normalizeddescription");
            entity.Property(e => e.Usagedescription)
                .HasMaxLength(128)
                .HasColumnName("usagedescription");
        });
    
        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_suppliers_id");
    
            entity.ToTable("suppliers", "td1q2018");
    
            entity.HasIndex(e => e.Description, "description");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Dataversion)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("dataversion");
            entity.Property(e => e.Description)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Hasnewversionarticles)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("hasnewversionarticles");
            entity.Property(e => e.Matchcode)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("matchcode");
            entity.Property(e => e.Nbrofarticles)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("nbrofarticles");
        });
    
        modelBuilder.Entity<SupplierDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("supplier_details", "td1q2018");
    
            entity.HasIndex(e => new { e.Supplierid, e.Addresstypeid }, "supplierid");
    
            entity.Property(e => e.Addresstype)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("addresstype");
            entity.Property(e => e.Addresstypeid)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("addresstypeid");
            entity.Property(e => e.City1)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("city1");
            entity.Property(e => e.City2)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("city2");
            entity.Property(e => e.Countrycode)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("countrycode");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("email");
            entity.Property(e => e.Fax)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("fax");
            entity.Property(e => e.Homepage)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("homepage");
            entity.Property(e => e.Name1)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("name1");
            entity.Property(e => e.Name2)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("name2");
            entity.Property(e => e.Postalcodecity)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("postalcodecity");
            entity.Property(e => e.Postalcodepob)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("postalcodepob");
            entity.Property(e => e.Postalcodewholesaler)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("postalcodewholesaler");
            entity.Property(e => e.Postalcountrycode)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("postalcountrycode");
            entity.Property(e => e.Postofficebox)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("postofficebox");
            entity.Property(e => e.Street1)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("street1");
            entity.Property(e => e.Street2)
                .HasMaxLength(64)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("street2");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
            entity.Property(e => e.Telephone)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("telephone");
        });
    
        modelBuilder.Entity<SuppliersWithNvArticle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_suppliers_with_nv_articles_id");
    
            entity.ToTable("suppliers_with_nv_articles", "td1q2018");
    
            entity.HasIndex(e => e.Description, "description");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Dataversion)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("dataversion");
            entity.Property(e => e.Description)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Hasnewversionarticles)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("hasnewversionarticles");
            entity.Property(e => e.Matchcode)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("matchcode");
            entity.Property(e => e.Nbrofarticles)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("nbrofarticles");
        });
    
        modelBuilder.Entity<SuppliersWithNvLinkage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_suppliers_with_nv_linkages_id");
    
            entity.ToTable("suppliers_with_nv_linkages", "td1q2018");
    
            entity.HasIndex(e => e.Description, "description");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Dataversion)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("dataversion");
            entity.Property(e => e.Description)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Hasnewversionarticles)
                .HasMaxLength(5)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("hasnewversionarticles");
            entity.Property(e => e.Matchcode)
                .HasMaxLength(32)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("matchcode");
            entity.Property(e => e.Nbrofarticles)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("nbrofarticles");
        });
    
        OnModelCreatingPartial(modelBuilder);
    }
    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
