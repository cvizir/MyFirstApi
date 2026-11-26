using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Models;

namespace MyFirstApi.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Billboard> Billboards { get; set; }

    public virtual DbSet<BillboardCat> BillboardCats { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Orderlist> Orderlists { get; set; }

    public virtual DbSet<Pdcat> Pdcats { get; set; }

    public virtual DbSet<PdcatM> PdcatMs { get; set; }

    public virtual DbSet<PdcatT> PdcatTs { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Qa> Qas { get; set; }

    public virtual DbSet<SpecGroup> SpecGroups { get; set; }

    public virtual DbSet<SpecInfo> SpecInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.No).HasName("PRIMARY");

            entity.ToTable("admin");

            entity.Property(e => e.No)
                .HasColumnType("int(11)")
                .HasColumnName("no");
            entity.Property(e => e.AdminCode)
                .HasMaxLength(32)
                .HasColumnName("admin_code");
            entity.Property(e => e.AdminId)
                .HasMaxLength(255)
                .HasColumnName("admin_id");
            entity.Property(e => e.AdminIndex)
                .HasMaxLength(32)
                .HasColumnName("admin_index");
            entity.Property(e => e.AdminPsw)
                .HasMaxLength(255)
                .HasColumnName("admin_psw");
            entity.Property(e => e.AdminPv)
                .HasColumnType("text")
                .HasColumnName("admin_pv");
            entity.Property(e => e.Ishow)
                .HasColumnType("int(11)")
                .HasColumnName("ishow");
            entity.Property(e => e.Uptime)
                .HasColumnType("datetime")
                .HasColumnName("uptime");
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("article");

            entity.Property(e => e.Author)
                .HasMaxLength(64)
                .HasColumnName("author");
            entity.Property(e => e.ClickNum)
                .HasColumnType("int(11)")
                .HasColumnName("click_num");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.Info)
                .HasColumnType("text")
                .HasColumnName("info");
            entity.Property(e => e.Ishow)
                .HasColumnType("int(11)")
                .HasColumnName("ishow");
            entity.Property(e => e.MSort)
                .HasColumnType("int(11)")
                .HasColumnName("m_sort");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NewsCode)
                .HasMaxLength(32)
                .HasColumnName("news_code");
            entity.Property(e => e.NewsType)
                .HasMaxLength(255)
                .HasColumnName("news_type");
            entity.Property(e => e.No)
                .HasColumnType("int(11)")
                .HasColumnName("no");
            entity.Property(e => e.Photo)
                .HasColumnType("text")
                .HasColumnName("photo");
            entity.Property(e => e.Ps)
                .HasColumnType("text")
                .HasColumnName("ps");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");
            entity.Property(e => e.Summary)
                .HasColumnType("text")
                .HasColumnName("summary");
            entity.Property(e => e.TopIshow)
                .HasColumnType("int(11)")
                .HasColumnName("top_ishow");
            entity.Property(e => e.Uptime)
                .HasColumnType("datetime")
                .HasColumnName("uptime");
            entity.Property(e => e.WebUrl)
                .HasColumnType("text")
                .HasColumnName("web_url");
            entity.Property(e => e.Wttime)
                .HasColumnType("datetime")
                .HasColumnName("wttime");
            entity.Property(e => e.YouTubeCode)
                .HasColumnType("text")
                .HasColumnName("you_tube_code");
        });

        modelBuilder.Entity<Billboard>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("billboard");

            entity.Property(e => e.BdClass)
                .HasMaxLength(64)
                .HasColumnName("bd_class");
            entity.Property(e => e.BillboardCatCode)
                .HasMaxLength(16)
                .HasColumnName("billboard_cat_code");
            entity.Property(e => e.BillboardCode)
                .HasMaxLength(16)
                .HasColumnName("billboard_code");
            entity.Property(e => e.DelSw)
                .HasColumnType("int(11)")
                .HasColumnName("del_sw");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.IndexCode)
                .HasColumnType("text")
                .HasColumnName("index_code");
            entity.Property(e => e.IndexName)
                .HasMaxLength(32)
                .HasColumnName("index_name");
            entity.Property(e => e.Info)
                .HasColumnType("text")
                .HasColumnName("info");
            entity.Property(e => e.Ishow)
                .HasColumnType("int(11)")
                .HasColumnName("ishow");
            entity.Property(e => e.MSort)
                .HasColumnType("int(11)")
                .HasColumnName("m_sort");
            entity.Property(e => e.MType)
                .HasMaxLength(8)
                .HasColumnName("m_type");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.No)
                .HasColumnType("int(11)")
                .HasColumnName("no");
            entity.Property(e => e.Photo)
                .HasColumnType("text")
                .HasColumnName("photo");
            entity.Property(e => e.PicSize)
                .HasMaxLength(255)
                .HasColumnName("pic_size");
            entity.Property(e => e.Ps)
                .HasColumnType("text")
                .HasColumnName("ps");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");
            entity.Property(e => e.Uptime)
                .HasColumnType("datetime")
                .HasColumnName("uptime");
            entity.Property(e => e.WebCode).HasColumnName("web_code");
            entity.Property(e => e.WebUrl)
                .HasColumnType("text")
                .HasColumnName("web_url");
        });

        modelBuilder.Entity<BillboardCat>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("billboard_cat");

            entity.Property(e => e.BillboardCatCode)
                .HasMaxLength(16)
                .HasColumnName("billboard_cat_code");
            entity.Property(e => e.DelSw)
                .HasColumnType("int(11)")
                .HasColumnName("del_sw");
            entity.Property(e => e.EditUrl)
                .HasMaxLength(255)
                .HasColumnName("edit_url");
            entity.Property(e => e.IndexCode)
                .HasMaxLength(255)
                .HasColumnName("index_code");
            entity.Property(e => e.Ishow)
                .HasColumnType("int(11)")
                .HasColumnName("ishow");
            entity.Property(e => e.LimitNum)
                .HasColumnType("int(11)")
                .HasColumnName("limit_num");
            entity.Property(e => e.ListUrl)
                .HasMaxLength(255)
                .HasColumnName("list_url");
            entity.Property(e => e.MSort)
                .HasColumnType("int(11)")
                .HasColumnName("m_sort");
            entity.Property(e => e.Name)
                .HasMaxLength(2525)
                .HasColumnName("name");
            entity.Property(e => e.No)
                .HasColumnType("int(11)")
                .HasColumnName("no");
            entity.Property(e => e.Ps)
                .HasColumnType("text")
                .HasColumnName("ps");
            entity.Property(e => e.SaveUrl)
                .HasMaxLength(255)
                .HasColumnName("save_url");
            entity.Property(e => e.SltLg)
                .HasMaxLength(64)
                .HasColumnName("slt_lg");
            entity.Property(e => e.WebUrl)
                .HasMaxLength(255)
                .HasColumnName("web_url");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("contact");

            entity.Property(e => e.Addr)
                .HasMaxLength(255)
                .HasColumnName("addr");
            entity.Property(e => e.ContactCode)
                .HasMaxLength(32)
                .HasColumnName("contact_code");
            entity.Property(e => e.Email)
                .HasMaxLength(32)
                .HasColumnName("email");
            entity.Property(e => e.Mphone)
                .HasMaxLength(32)
                .HasColumnName("mphone");
            entity.Property(e => e.Msg)
                .HasColumnType("text")
                .HasColumnName("msg");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .HasColumnName("name");
            entity.Property(e => e.No)
                .HasColumnType("int(11)")
                .HasColumnName("no");
            entity.Property(e => e.PostTime)
                .HasColumnType("date")
                .HasColumnName("post_time");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasColumnName("subject");
            entity.Property(e => e.Tel)
                .HasMaxLength(32)
                .HasColumnName("tel");
            entity.Property(e => e.Uptime)
                .HasColumnType("date")
                .HasColumnName("uptime");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.No).HasName("PRIMARY");

            entity.ToTable("member", tb => tb.HasComment("會員資料表"));

            entity.HasIndex(e => e.Email, "idx_email").IsUnique();

            entity.HasIndex(e => e.MemberCode, "idx_member_code").IsUnique();

            entity.Property(e => e.No)
                .HasComment("會員流水號")
                .HasColumnType("int(11)")
                .HasColumnName("no");
            entity.Property(e => e.Addr)
                .HasMaxLength(255)
                .HasComment("詳細地址")
                .HasColumnName("addr");
            entity.Property(e => e.Area)
                .HasMaxLength(20)
                .HasComment("鄉鎮市區")
                .HasColumnName("area");
            entity.Property(e => e.Birthday)
                .HasComment("生日")
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.City)
                .HasMaxLength(6)
                .HasComment("居住縣市")
                .HasColumnName("city");
            entity.Property(e => e.CpId)
                .HasMaxLength(20)
                .HasComment("公司統編")
                .HasColumnName("cp_id");
            entity.Property(e => e.CpTitle)
                .HasMaxLength(64)
                .HasComment("公司抬頭")
                .HasColumnName("cp_title");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasComment("電子郵件")
                .HasColumnName("email");
            entity.Property(e => e.EmailCheck)
                .HasDefaultValueSql("'0'")
                .HasComment("信箱驗證")
                .HasColumnType("int(4)")
                .HasColumnName("email_check");
            entity.Property(e => e.Esend)
                .HasDefaultValueSql("'0'")
                .HasComment("訂閱電子報")
                .HasColumnType("int(4)")
                .HasColumnName("esend");
            entity.Property(e => e.MemberCode)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasComment("會員代碼(英數混合9位)")
                .HasColumnName("member_code");
            entity.Property(e => e.MemberMode)
                .HasDefaultValueSql("'1'")
                .HasComment("會員狀態")
                .HasColumnType("tinyint(4)")
                .HasColumnName("member_mode");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("真實姓名")
                .HasColumnName("name");
            entity.Property(e => e.Nickname)
                .HasMaxLength(50)
                .HasComment("暱稱(英文名)")
                .HasColumnName("nickname");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasComment("手機號碼")
                .HasColumnName("phone");
            entity.Property(e => e.Photo)
                .HasComment("大頭照")
                .HasColumnType("text")
                .HasColumnName("photo");
            entity.Property(e => e.Pid)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasComment("身分證字號")
                .HasColumnName("pid");
            entity.Property(e => e.Psw)
                .HasMaxLength(32)
                .HasComment("密碼")
                .HasColumnName("psw");
            entity.Property(e => e.Regtime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("註冊時間")
                .HasColumnType("datetime")
                .HasColumnName("regtime");
            entity.Property(e => e.Sex)
                .HasComment("性別")
                .HasColumnType("int(2)")
                .HasColumnName("sex");
            entity.Property(e => e.Tel)
                .HasMaxLength(20)
                .HasComment("市內電話")
                .HasColumnName("tel");
            entity.Property(e => e.Uptime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("更新時間")
                .HasColumnType("datetime")
                .HasColumnName("uptime");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(6)
                .HasComment("郵遞區號")
                .HasColumnName("zipcode");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.No).HasName("PRIMARY");

            entity.ToTable("news");

            entity.HasIndex(e => e.No, "no");

            entity.Property(e => e.No)
                .HasColumnType("int(11)")
                .HasColumnName("no");
            entity.Property(e => e.ClickNum)
                .HasColumnType("int(11)")
                .HasColumnName("click_num");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.Info)
                .HasColumnType("text")
                .HasColumnName("info");
            entity.Property(e => e.Ishow)
                .HasColumnType("int(11)")
                .HasColumnName("ishow");
            entity.Property(e => e.MSort)
                .HasColumnType("int(11)")
                .HasColumnName("m_sort");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NewsCode)
                .HasMaxLength(32)
                .HasColumnName("news_code");
            entity.Property(e => e.NewsType)
                .HasMaxLength(255)
                .HasColumnName("news_type");
            entity.Property(e => e.Photo)
                .HasColumnType("text")
                .HasColumnName("photo");
            entity.Property(e => e.Ps)
                .HasColumnType("text")
                .HasColumnName("ps");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");
            entity.Property(e => e.Summary)
                .HasColumnType("text")
                .HasColumnName("summary");
            entity.Property(e => e.TopIshow)
                .HasColumnType("int(11)")
                .HasColumnName("top_ishow");
            entity.Property(e => e.Uptime)
                .HasColumnType("datetime")
                .HasColumnName("uptime");
            entity.Property(e => e.WebUrl)
                .HasColumnType("text")
                .HasColumnName("web_url");
            entity.Property(e => e.Wttime)
                .HasColumnType("date")
                .HasColumnName("wttime");
            entity.Property(e => e.YouTubeCode)
                .HasColumnType("text")
                .HasColumnName("you_tube_code");
        });

        modelBuilder.Entity<Orderlist>(entity =>
        {
            entity.HasKey(e => e.No).HasName("PRIMARY");

            entity.ToTable("orderlist");

            entity.Property(e => e.No)
                .HasColumnType("int(11)")
                .HasColumnName("no");
            entity.Property(e => e.Amount)
                .HasColumnType("int(11)")
                .HasColumnName("amount");
            entity.Property(e => e.AtmNum)
                .HasMaxLength(32)
                .HasColumnName("atm_num");
            entity.Property(e => e.Buytime)
                .HasColumnType("datetime")
                .HasColumnName("buytime");
            entity.Property(e => e.CounterState)
                .HasColumnType("int(11)")
                .HasColumnName("counter_state");
            entity.Property(e => e.GetMode)
                .HasMaxLength(8)
                .HasColumnName("get_mode");
            entity.Property(e => e.InvoiceAddr)
                .HasMaxLength(255)
                .HasColumnName("invoice_addr");
            entity.Property(e => e.InvoiceArea)
                .HasMaxLength(64)
                .HasColumnName("invoice_area");
            entity.Property(e => e.InvoiceCity)
                .HasMaxLength(64)
                .HasColumnName("invoice_city");
            entity.Property(e => e.InvoiceCountry)
                .HasMaxLength(32)
                .HasColumnName("invoice_country");
            entity.Property(e => e.InvoiceEmail)
                .HasMaxLength(255)
                .HasColumnName("invoice_email");
            entity.Property(e => e.InvoiceGet)
                .HasColumnType("int(11)")
                .HasColumnName("invoice_get");
            entity.Property(e => e.InvoiceName)
                .HasMaxLength(255)
                .HasColumnName("invoice_name");
            entity.Property(e => e.InvoiceNum)
                .HasMaxLength(255)
                .HasColumnName("invoice_num");
            entity.Property(e => e.InvoiceStore)
                .HasMaxLength(64)
                .HasColumnName("invoice_store");
            entity.Property(e => e.InvoiceTel)
                .HasMaxLength(64)
                .HasColumnName("invoice_tel");
            entity.Property(e => e.InvoiceTitle)
                .HasMaxLength(255)
                .HasColumnName("invoice_title");
            entity.Property(e => e.InvoiceType)
                .HasMaxLength(255)
                .HasColumnName("invoice_type");
            entity.Property(e => e.InvoiceZipcode)
                .HasMaxLength(255)
                .HasColumnName("invoice_zipcode");
            entity.Property(e => e.MemberCode)
                .HasMaxLength(255)
                .HasColumnName("member_code");
            entity.Property(e => e.MemberNo)
                .HasMaxLength(255)
                .HasColumnName("member_no");
            entity.Property(e => e.OrderCode)
                .HasMaxLength(64)
                .HasColumnName("order_code");
            entity.Property(e => e.OrderHtml)
                .HasColumnType("text")
                .HasColumnName("order_html");
            entity.Property(e => e.OrderInfo).HasColumnName("order_info");
            entity.Property(e => e.OrderPs)
                .HasColumnType("text")
                .HasColumnName("order_ps");
            entity.Property(e => e.OrderState)
                .HasMaxLength(32)
                .HasColumnName("order_state");
            entity.Property(e => e.OtherPrice)
                .HasColumnType("int(11)")
                .HasColumnName("other_price");
            entity.Property(e => e.OtherPs)
                .HasMaxLength(256)
                .HasColumnName("other_ps");
            entity.Property(e => e.PayInfo)
                .HasColumnType("text")
                .HasColumnName("pay_info");
            entity.Property(e => e.PayMode)
                .HasMaxLength(25)
                .HasColumnName("pay_mode");
            entity.Property(e => e.PayModePrice)
                .HasColumnType("int(11)")
                .HasColumnName("pay_mode_price");
            entity.Property(e => e.PostCpy)
                .HasMaxLength(32)
                .HasColumnName("post_cpy");
            entity.Property(e => e.PostDate)
                .HasColumnType("date")
                .HasColumnName("post_date");
            entity.Property(e => e.PostNum)
                .HasMaxLength(32)
                .HasColumnName("post_num");
            entity.Property(e => e.PrePostDate)
                .HasColumnType("date")
                .HasColumnName("pre_post_date");
            entity.Property(e => e.Ps)
                .HasColumnType("text")
                .HasColumnName("ps");
            entity.Property(e => e.ReceivesAddr)
                .HasMaxLength(255)
                .HasColumnName("receives_addr");
            entity.Property(e => e.ReceivesArea)
                .HasMaxLength(64)
                .HasColumnName("receives_area");
            entity.Property(e => e.ReceivesCity)
                .HasMaxLength(64)
                .HasColumnName("receives_city");
            entity.Property(e => e.ReceivesCountry)
                .HasMaxLength(32)
                .HasColumnName("receives_country");
            entity.Property(e => e.ReceivesMphone)
                .HasMaxLength(255)
                .HasColumnName("receives_mphone");
            entity.Property(e => e.ReceivesName)
                .HasMaxLength(255)
                .HasColumnName("receives_name");
            entity.Property(e => e.ReceivesTel)
                .HasMaxLength(64)
                .HasColumnName("receives_tel");
            entity.Property(e => e.ReceivesTime)
                .HasColumnType("int(11)")
                .HasColumnName("receives_time");
            entity.Property(e => e.ReceivesZipcode)
                .HasMaxLength(255)
                .HasColumnName("receives_zipcode");
            entity.Property(e => e.StoreNum)
                .HasMaxLength(64)
                .HasColumnName("store_num");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("int(11)")
                .HasColumnName("total_amount");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(255)
                .HasColumnName("transaction_Id");
            entity.Property(e => e.Transportation)
                .HasColumnType("int(11)")
                .HasColumnName("transportation");
            entity.Property(e => e.TransportationPs)
                .HasColumnType("text")
                .HasColumnName("transportation_ps");
            entity.Property(e => e.Uptime)
                .HasColumnType("datetime")
                .HasColumnName("uptime");
        });

        modelBuilder.Entity<Pdcat>(entity =>
        {
            entity.HasKey(e => e.PdcatCode).HasName("PRIMARY");

            entity.ToTable("pdcat", tb => tb.HasComment("第三層子分類表"));

            entity.HasIndex(e => e.PdcatMCode, "idx_pdcat_m_code");

            entity.HasIndex(e => e.No, "no");

            entity.Property(e => e.PdcatCode)
                .HasMaxLength(9)
                .HasComment("第三層子分類代碼")
                .HasColumnName("pdcat_code");
            entity.Property(e => e.Ishow)
                .HasDefaultValueSql("'1'")
                .HasComment("是否顯示 (1: 顯示, 0: 隱藏)")
                .HasColumnName("ishow");
            entity.Property(e => e.LinkType)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasComment("連結開啟方式")
                .HasColumnName("link_type");
            entity.Property(e => e.MSort)
                .HasDefaultValueSql("'0'")
                .HasComment("排序")
                .HasColumnType("int(11)")
                .HasColumnName("m_sort");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasComment("分類名稱/說明")
                .HasColumnName("name");
            entity.Property(e => e.No)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)")
                .HasColumnName("no");
            entity.Property(e => e.PdcatMCode)
                .HasMaxLength(9)
                .HasComment("關聯：第二層中分類代碼")
                .HasColumnName("pdcat_m_code");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasComment("連結網址")
                .HasColumnName("url");

            entity.HasOne(d => d.PdcatMCodeNavigation).WithMany(p => p.Pdcats)
                .HasForeignKey(d => d.PdcatMCode)
                .HasConstraintName("fk_pdcat_mcode");
        });

        modelBuilder.Entity<PdcatM>(entity =>
        {
            entity.HasKey(e => e.PdcatMCode).HasName("PRIMARY");

            entity.ToTable("pdcat_m", tb => tb.HasComment("第二層中分類表"));

            entity.HasIndex(e => e.PdcatTCode, "idx_pdcat_t_code");

            entity.HasIndex(e => e.No, "no");

            entity.Property(e => e.PdcatMCode)
                .HasMaxLength(9)
                .HasComment("第二層中分類代碼")
                .HasColumnName("pdcat_m_code");
            entity.Property(e => e.Ishow)
                .HasDefaultValueSql("'1'")
                .HasComment("是否顯示 (1: 顯示, 0: 隱藏)")
                .HasColumnName("ishow");
            entity.Property(e => e.LinkType)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasComment("連結開啟方式")
                .HasColumnName("link_type");
            entity.Property(e => e.MSort)
                .HasDefaultValueSql("'0'")
                .HasComment("排序")
                .HasColumnType("int(11)")
                .HasColumnName("m_sort");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasComment("分類名稱/說明")
                .HasColumnName("name");
            entity.Property(e => e.No)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)")
                .HasColumnName("no");
            entity.Property(e => e.PdcatTCode)
                .HasMaxLength(9)
                .HasComment("關聯：第一層主分類代碼")
                .HasColumnName("pdcat_t_code");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasComment("連結網址")
                .HasColumnName("url");

            entity.HasOne(d => d.PdcatTCodeNavigation).WithMany(p => p.PdcatMs)
                .HasForeignKey(d => d.PdcatTCode)
                .HasConstraintName("fk_pdcat_m_tcode");
        });

        modelBuilder.Entity<PdcatT>(entity =>
        {
            entity.HasKey(e => e.PdcatTCode).HasName("PRIMARY");

            entity.ToTable("pdcat_t", tb => tb.HasComment("第一層主分類表"));

            entity.HasIndex(e => e.No, "no");

            entity.Property(e => e.PdcatTCode)
                .HasMaxLength(9)
                .HasComment("第一層主分類代碼")
                .HasColumnName("pdcat_t_code");
            entity.Property(e => e.Ishow)
                .HasDefaultValueSql("'1'")
                .HasComment("是否顯示 (1: 顯示, 0: 隱藏)")
                .HasColumnName("ishow");
            entity.Property(e => e.LinkType)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasComment("連結開啟方式 (例如 _self, _blank)")
                .HasColumnName("link_type");
            entity.Property(e => e.MSort)
                .HasDefaultValueSql("'0'")
                .HasComment("排序 (數字越小越前面)")
                .HasColumnType("int(11)")
                .HasColumnName("m_sort");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasComment("分類名稱/說明")
                .HasColumnName("name");
            entity.Property(e => e.No)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)")
                .HasColumnName("no");
            entity.Property(e => e.Url)
                .HasComment("連結網址")
                .HasColumnType("text")
                .HasColumnName("url");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.No).HasName("PRIMARY");

            entity.ToTable("product");

            entity.Property(e => e.No)
                .HasColumnType("int(11)")
                .HasColumnName("no");
            entity.Property(e => e.HotItem)
                .HasColumnType("int(2)")
                .HasColumnName("hot_item");
            entity.Property(e => e.Ishow)
                .HasColumnType("int(2)")
                .HasColumnName("ishow");
            entity.Property(e => e.MSort)
                .HasColumnType("int(2)")
                .HasColumnName("m_sort");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OPrice)
                .HasColumnType("int(5)")
                .HasColumnName("o_price");
            entity.Property(e => e.PdInfo).HasColumnName("pd_info");
            entity.Property(e => e.PdStock)
                .HasColumnType("int(6)")
                .HasColumnName("pd_stock");
            entity.Property(e => e.PdTitle)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("pd_title");
            entity.Property(e => e.PdcatCode)
                .HasMaxLength(13)
                .HasColumnName("pdcat_code");
            entity.Property(e => e.Photo)
                .HasColumnType("text")
                .HasColumnName("photo");
            entity.Property(e => e.Price)
                .HasColumnType("int(5)")
                .HasColumnName("price");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(13)
                .HasColumnName("product_code");
            entity.Property(e => e.Ps)
                .HasColumnType("text")
                .HasColumnName("ps");
            entity.Property(e => e.ReleaseDate)
                .HasColumnType("date")
                .HasColumnName("release_date");
            entity.Property(e => e.Uptime)
                .HasColumnType("datetime")
                .HasColumnName("uptime");
            entity.Property(e => e.YouTubeCode)
                .HasColumnType("text")
                .HasColumnName("you_tube_code");
        });

        modelBuilder.Entity<Qa>(entity =>
        {
            entity.HasKey(e => e.No).HasName("PRIMARY");

            entity.ToTable("qa");

            entity.Property(e => e.No)
                .HasColumnType("int(11)")
                .HasColumnName("no");
            entity.Property(e => e.Ans)
                .HasColumnType("text")
                .HasColumnName("ans");
            entity.Property(e => e.CatId)
                .HasMaxLength(11)
                .HasColumnName("cat_id");
            entity.Property(e => e.Ishow)
                .HasColumnType("int(2)")
                .HasColumnName("ishow");
            entity.Property(e => e.MSort)
                .HasColumnType("int(11)")
                .HasColumnName("m_sort");
            entity.Property(e => e.QaCode)
                .HasMaxLength(32)
                .HasColumnName("qa_code");
            entity.Property(e => e.Question)
                .HasColumnType("text")
                .HasColumnName("question");
            entity.Property(e => e.Uptime)
                .HasColumnType("datetime")
                .HasColumnName("uptime");
        });

        modelBuilder.Entity<SpecGroup>(entity =>
        {
            entity.HasKey(e => e.No).HasName("PRIMARY");

            entity.ToTable("spec_group");

            entity.Property(e => e.No)
                .HasColumnType("int(11)")
                .HasColumnName("no");
            entity.Property(e => e.Ishow)
                .HasColumnType("int(11)")
                .HasColumnName("ishow");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PdcatCode)
                .HasMaxLength(16)
                .HasColumnName("pdcat_code");
            entity.Property(e => e.SpecCode)
                .HasColumnType("text")
                .HasColumnName("spec_code");
            entity.Property(e => e.SpecGroupCode)
                .HasMaxLength(32)
                .HasColumnName("spec_group_code");
        });

        modelBuilder.Entity<SpecInfo>(entity =>
        {
            entity.HasKey(e => e.No).HasName("PRIMARY");

            entity.ToTable("spec_info");

            entity.Property(e => e.No)
                .HasColumnType("int(11)")
                .HasColumnName("no");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .HasColumnName("color");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(255)
                .HasColumnName("img_url");
            entity.Property(e => e.Ishow)
                .HasColumnType("int(11)")
                .HasColumnName("ishow");
            entity.Property(e => e.ShowType)
                .HasMaxLength(16)
                .HasColumnName("show_type");
            entity.Property(e => e.SpecCode)
                .HasMaxLength(64)
                .HasColumnName("spec_code");
            entity.Property(e => e.SpecType)
                .HasMaxLength(8)
                .HasDefaultValueSql("''")
                .HasColumnName("spec_type");
            entity.Property(e => e.Text)
                .HasMaxLength(255)
                .HasColumnName("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
