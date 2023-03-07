using Core;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SchoolERP.Data.Model;
using SchoolERP.Data.Models;
using SchoolERP.Data.Models.Maping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolERP.Data
{
 
    public class SCDbContext : DbContext
    {
        private readonly Tenant _tenant;
        public SCDbContext(CoreDbContextOptionsBuilder optionsBuilder, Tenant tenant)
       : base(optionsBuilder.SelectDatabase<SCDbContext>())
        {
            _tenant = tenant;   
        }
        public override int SaveChanges()
        {
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is not AuditEntry && (entry.State == EntityState.Added || entry.State == EntityState.Modified))
                {
                    auditEntries.Add(new AuditEntry
                    {
                        EntityName = entry.Entity.GetType().Name,
                        EntityId = (int)entry.CurrentValues["Id"],
                        Action = entry.State.ToString(),
                        ObjectValue= JsonSerializer.Serialize(entry),
                        Timestamp = DateTime.Now
                    });
                }
            }

            AuditEntries.AddRange(auditEntries);

            return base.SaveChanges();
        }
        public virtual DbSet<AuditEntry> AuditEntries { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<RoleUser> RoleUsers { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuPermission> MenuPermissions { get; set; }
        public virtual DbSet<AppSetting> AppSettings { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<SessionYear> SessionYears { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<SalaryGrade> SalaryGrades { get; set; }
        public virtual DbSet<SalaryType> SalaryTypes { get; set; }
        public virtual DbSet<Classes> Classess { get; set; }
        public virtual DbSet<Models.Section> Sections { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectType> SubjectTypes { get; set; }
        public virtual DbSet<Syllabus> Syllabuss { get; set; }
        public virtual DbSet<ClassRoutine> ClassRoutines { get; set; }
        public virtual DbSet<MDay> MDays { get; set; }
        public virtual DbSet<Guardian> Guardians { get; set; }
        public virtual DbSet<GuardianRelation> GuardianRelations { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<UserAttendance> UserAttendances { get; set; }
        public virtual DbSet<StudentAttendance> StudentAttendances { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<ExamGrade> ExamGrades { get; set; }
        public virtual DbSet<ExamTerm> ExamTerms { get; set; }
        public virtual DbSet<ExamSchedule> ExamSchedules { get; set; }
        public virtual DbSet<ExamSuggestion> ExamSuggestions { get; set; }
        public virtual DbSet<ExamAttendance> ExamAttendances { get; set; }
        public virtual DbSet<ExamMark> ExamMarks { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<CertificateType> CertificateTypes { get; set; }
        public virtual DbSet<LibraryBook> LibraryBooks { get; set; }
        public virtual DbSet<LibraryMember> LibraryMembers { get; set; }
        public virtual DbSet<LibraryIssueAndReturn> LibraryIssueAndReturns { get; set; }
        public virtual DbSet<TransportVehicle> TransportVehicles { get; set; }
        public virtual DbSet<TransportRoute> TransportRoutes { get; set; }
        public virtual DbSet<TransportMember> TransportMembers { get; set; }
        public virtual DbSet<HostelType> HostelTypes { get; set; }
        public virtual DbSet<Hostel> Hostels { get; set; }
        public virtual DbSet<HostelRoom> HostelRooms { get; set; }
        public virtual DbSet<HostelMember> HostelMembers { get; set; }
        public virtual DbSet<Notice> Notices { get; set; }
        public virtual DbSet<News> Newss { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }
        public virtual DbSet<SalaryPayment> SalaryPayments { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<LedgerHead> LedgerHeads { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<MyDocument> MyDocuments { get; set; }
        public virtual DbSet<FeesHead> FeesHeads { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<EmailAttachment> EmailAttachments { get; set; }
        public virtual DbSet<EmailMember> EmailMembers { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }



        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleUserMap());
            modelBuilder.ApplyConfiguration(new MenuMap());
            modelBuilder.ApplyConfiguration(new MenuPermissionMap());
            modelBuilder.ApplyConfiguration(new AppSettingMap());
            modelBuilder.ApplyConfiguration(new LanguageMap());
            modelBuilder.ApplyConfiguration(new SessionYearMap());
            modelBuilder.ApplyConfiguration(new SettingMap());
            modelBuilder.ApplyConfiguration(new DesignationMap());
            modelBuilder.ApplyConfiguration(new GenderMap());
            modelBuilder.ApplyConfiguration(new SalaryGradeMap());
            modelBuilder.ApplyConfiguration(new SalaryTypeMap());
            modelBuilder.ApplyConfiguration(new ClassesMap());
            modelBuilder.ApplyConfiguration(new SectionMap());
            modelBuilder.ApplyConfiguration(new SubjectMap());
            modelBuilder.ApplyConfiguration(new SubjectTypeMap());
            modelBuilder.ApplyConfiguration(new SyllabusMap());
            modelBuilder.ApplyConfiguration(new ClassRoutineMap());
            modelBuilder.ApplyConfiguration(new MDayMap());
            modelBuilder.ApplyConfiguration(new GuardianMap());
            modelBuilder.ApplyConfiguration(new GuardianRelationMap());
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new UserAttendanceMap());
            modelBuilder.ApplyConfiguration(new StudentAttendanceMap());
            modelBuilder.ApplyConfiguration(new AssignmentMap());
            modelBuilder.ApplyConfiguration(new ExamGradeMap());
            modelBuilder.ApplyConfiguration(new ExamTermMap());
            modelBuilder.ApplyConfiguration(new ExamScheduleMap());
            modelBuilder.ApplyConfiguration(new ExamSuggestionMap());
            modelBuilder.ApplyConfiguration(new ExamAttendanceMap());
            modelBuilder.ApplyConfiguration(new ExamMarkMap());
            modelBuilder.ApplyConfiguration(new PromotionMap());
            modelBuilder.ApplyConfiguration(new CertificateTypeMap());
            modelBuilder.ApplyConfiguration(new LibraryBookMap());
            modelBuilder.ApplyConfiguration(new LibraryMemberMap());
            modelBuilder.ApplyConfiguration(new LibraryIssueAndReturnMap());
            modelBuilder.ApplyConfiguration(new TransportVehicleMap());
            modelBuilder.ApplyConfiguration(new TransportRouteMap());
            modelBuilder.ApplyConfiguration(new TransportMemberMap());
            modelBuilder.ApplyConfiguration(new HostelTypeMap());
            modelBuilder.ApplyConfiguration(new HostelMap());
            modelBuilder.ApplyConfiguration(new HostelRoomMap());
            modelBuilder.ApplyConfiguration(new HostelMemberMap());
            modelBuilder.ApplyConfiguration(new NoticeMap());
            modelBuilder.ApplyConfiguration(new NewsMap());
            modelBuilder.ApplyConfiguration(new HolidayMap());
            modelBuilder.ApplyConfiguration(new EventMap());
            modelBuilder.ApplyConfiguration(new VisitorMap());
            modelBuilder.ApplyConfiguration(new SalaryPaymentMap());
            modelBuilder.ApplyConfiguration(new PaymentMethodMap());
            modelBuilder.ApplyConfiguration(new LedgerHeadMap());
            modelBuilder.ApplyConfiguration(new IncomeMap());
            modelBuilder.ApplyConfiguration(new ExpenseMap());
            modelBuilder.ApplyConfiguration(new MyDocumentMap());
            modelBuilder.ApplyConfiguration(new FeesHeadMap());
            modelBuilder.ApplyConfiguration(new InvoiceMap());
            modelBuilder.ApplyConfiguration(new NotificationMap());
            modelBuilder.ApplyConfiguration(new EmailAttachmentMap());
            modelBuilder.ApplyConfiguration(new EmailMemberMap());
            modelBuilder.ApplyConfiguration(new EmailMessageMap());

            Expression<Func<BaseEntity, bool>> filterExpr = bm => (bm.TenantId == _tenant.TenantId && bm.IsDeleted == false);

            // Cache the filterExpr Lambda expression
            var cachedFilterExpr = new Dictionary<Type, Expression<Func<BaseEntity, bool>>>();
            
            if (!cachedFilterExpr.TryGetValue(typeof(BaseEntity), out var lambdaExpression))
            {
                lambdaExpression = filterExpr;
                cachedFilterExpr[typeof(BaseEntity)] = lambdaExpression;
            }

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var type = entity.ClrType;
                if (typeof(BaseEntity).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
                {
                    var parameter = Expression.Parameter(entity.ClrType);
                    var body = ReplacingExpressionVisitor.Replace(lambdaExpression.Parameters.First(), parameter, lambdaExpression.Body);
                    lambdaExpression =(Expression<Func<BaseEntity, bool>>) Expression.Lambda(body, parameter);
                    entity.SetQueryFilter(lambdaExpression);
                }
            }


            //Expression<Func<BaseEntity, bool>> filterExpr = bm =>( bm.TenantId == _tenant.TenantId && bm.IsDeleted==false);
            //foreach (var entity in modelBuilder.Model.GetEntityTypes())
            //{
            //    var type = entity.ClrType;
            //    if (typeof(BaseEntity).IsAssignableFrom(type))
            //    {
            //        var parameter = Expression.Parameter(entity.ClrType);
            //        var body = ReplacingExpressionVisitor.Replace(filterExpr.Parameters.First(), parameter, filterExpr.Body);
            //        var lambdaExpression = Expression.Lambda(body, parameter);
            //        entity.SetQueryFilter(lambdaExpression);
            //    }
            //}
        

            base.OnModelCreating(modelBuilder);
        }
        //
    }
}
