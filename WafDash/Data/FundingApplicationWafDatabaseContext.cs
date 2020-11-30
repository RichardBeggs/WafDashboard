using Microsoft.EntityFrameworkCore;
using WafDash.Models;

namespace WafDash.Data
{
    public partial class FundingApplicationWafDatabaseContext : DbContext
    {
        public FundingApplicationWafDatabaseContext()
        {
        }

        public FundingApplicationWafDatabaseContext(DbContextOptions<FundingApplicationWafDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WafLogs> WafLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FundingApplicationWafDatabase;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WafLogs>(entity =>
            {
                entity.ToTable("Waf_Logs");

                entity.Property(e => e.Action).HasMaxLength(500);

                entity.Property(e => e.Attack).HasMaxLength(500);

                entity.Property(e => e.AuthenticatedUser)
                    .HasColumnName("Authenticated_User")
                    .HasMaxLength(500);

                entity.Property(e => e.ClientIp)
                    .HasColumnName("Client_Ip")
                    .HasMaxLength(500);

                entity.Property(e => e.ClientPort)
                    .HasColumnName("Client_Port")
                    .HasMaxLength(500);

                entity.Property(e => e.ClientRiskScore)
                    .HasColumnName("Client_Risk_Score")
                    .HasMaxLength(500);

                entity.Property(e => e.Country).HasMaxLength(500);

                entity.Property(e => e.Detail).HasMaxLength(500);

                entity.Property(e => e.Fingerprint).HasMaxLength(500);

                entity.Property(e => e.FollowUp)
                    .HasColumnName("Follow_Up")
                    .HasMaxLength(500);

                entity.Property(e => e.Host).HasMaxLength(500);

                entity.Property(e => e.Level).HasMaxLength(500);

                entity.Property(e => e.Method).HasMaxLength(500);

                entity.Property(e => e.Protocol).HasMaxLength(500);

                entity.Property(e => e.ProxyIp)
                    .HasColumnName("Proxy_Ip")
                    .HasMaxLength(500);

                entity.Property(e => e.ProxyPort)
                    .HasColumnName("Proxy_Port")
                    .HasMaxLength(500);

                entity.Property(e => e.QueryStr)
                    .HasColumnName("Query_Str")
                    .HasMaxLength(500);

                entity.Property(e => e.Referer).HasMaxLength(500);

                entity.Property(e => e.ReqRiskScore)
                    .HasColumnName("Req_Risk_Score")
                    .HasMaxLength(500);

                entity.Property(e => e.RuleId)
                    .HasColumnName("Rule_Id")
                    .HasMaxLength(500);

                entity.Property(e => e.RuleType)
                    .HasColumnName("Rule_Type")
                    .HasMaxLength(500);

                entity.Property(e => e.SessionId).HasMaxLength(500);

                entity.Property(e => e.TimeStamp).HasMaxLength(500);

                entity.Property(e => e.Url).HasMaxLength(500);

                entity.Property(e => e.UserAgent)
                    .HasColumnName("User_Agent")
                    .HasMaxLength(500);

                entity.Property(e => e.VipIp)
                    .HasColumnName("Vip_Ip")
                    .HasMaxLength(500);

                entity.Property(e => e.VipPort)
                    .HasColumnName("Vip_Port")
                    .HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}