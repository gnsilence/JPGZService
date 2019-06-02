using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using JPGZService.AppointmentDetails;
using JPGZService.Authorization.Roles;
using JPGZService.Authorization.Users;
using JPGZService.BranchSchools;
using JPGZService.ChargeDatas;
using JPGZService.ClassAddtions;
using JPGZService.ClassInfos;
using JPGZService.CoachRankingss;
using JPGZService.Complaints;
using JPGZService.ConfigFirsts;
using JPGZService.ConfigSeconds;
using JPGZService.DriveSchools;
using JPGZService.Evaluations;
using JPGZService.ExamRecords;
using JPGZService.FindDrivingSchools;
using JPGZService.MultiTenancy;
using JPGZService.Videos;
using JPGZService.PreRegistrations;
using JPGZService.RegisterRelations;
using JPGZService.RegistrationCodes;
using JPGZService.ReleaseCourses;
using JPGZService.StudentBases;
using JPGZService.StudyRecordResults;
using JPGZService.Teachers;
using JPGZService.GetQuestion;
using JPGZService.SchoolSubjects;
using JPGZService.StudyStatQuerys;
using JPGZService.SurplusStudyTimes;
using JPGZService.Vehicles;
using JPGZService.TrainCurriculum;
using JPGZService.News;
using JPGZService.QuestionsCollects;
using JPGZService.Feedback;
using JPGZService.Organizes;
using JPGZService.Sites;
using JPGZService.TeacherTemplates;
using JPGZService.StudentBlackLists;
using JPGZService.TeacherLeaves;
using JPGZService.StudyStat_Student;
using JPGZService.StudyTimes;
using JPGZService.TeachingAreas;
using JPGZService.VehicleBrandModels;
using Abp.EntityFrameworkCore;
using Abp.Domain.Repositories;

namespace JPGZService.EntityFrameworkCore
{
    public class JPGZServiceDbContext : AbpDbContext
    {
        /* Define a DbSet for each entity of the application */
        public JPGZServiceDbContext(DbContextOptions<JPGZServiceDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var converter = new CastingConverter<int, decimal>();
            //modelBuilder.Entity<Evaluation>().Property(p => p.Overall).HasConversion(converter);

            //对已经删除的试题进行全局过滤
            //modelBuilder.Entity<QuestionInfo>(k =>
            //{
            //    k.HasQueryFilter(n => (n.IsDelete == 0 ? true : false));
            //});
            //modelBuilder.Entity<Video>(v =>
            //{
            //    v.HasQueryFilter(n => (n.IsDelete == 0 ? true : false));
            //});
            //modelBuilder.Entity<TrainCurriculumModel>(v =>
            //{
            //    v.HasQueryFilter(n => n.IsDelete == 0);
            //});
            //modelBuilder.Entity<ClassInfo>(c =>
            //{
            //    c.HasQueryFilter(cs => (cs.ActiveStatus == 1 && cs.IsDelete == 0)); // 班型为已经发布的,未删除的
            //});
            //modelBuilder.Entity<Teacher>(t =>
            //{
            //    t.HasQueryFilter(ts => (ts.DeleteMark == false && ts.Employstatus == 0 && ts.TrainingStatus == 0 && ts.Status == 1 && ts.CoachRole == 1 && (ts.UploadStatus == 2 || ts.UploadStatus == 3)));  // 已激活，未删除，培训状态为“正常”，在职状态为“在职”
            //});
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Questions_AnswerCount> questions_AnswerCounts { get; set; }
        public DbSet<Account.UserAccount> UserAccount { get; set; }
        public DbSet<StudentBase> StudentBase { get; set; }
        public DbSet<PreRegistration> PreRegistration { get; set; }
        public DbSet<RegisterRelation> RegisterRelation { get; set; }
        public DbSet<RegistrationCode> RegistrationCode { get; set; }
        public DbSet<VideoRecord> _VideoRecord { get; set; }
        public DbSet<Video> _Video { get; set; }
        public DbSet<Study_Photo> _Study_Photo { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<TeachingArea> TeachingArea { get; set; }
        public DbSet<DriveSchool> DriveSchool { get; set; }
        public DbSet<Evaluation> Evaluation { get; set; }
        public DbSet<ClassInfo> ClassInfo { get; set; }
        public DbSet<TrainCurriculumModel> TrainCurriculumModel { get; set; }
        public DbSet<BranchSchool> BranchSchool { get; set; }
        public DbSet<ConfigFirst> ConfigFirst { get; set; }
        public DbSet<ConfigSecond> ConfigSecond { get; set; }
        public DbSet<ExamRecord> ExamRecord { get; set; }
        public DbSet<StudyRecordResult> StudyRecordResult { get; set; }
        public DbSet<Complaint> Complaint { get; set; }
        public DbSet<AppointmentDetail> AppointmentDetail { get; set; }
        public DbSet<ReleaseCourse> ReleaseCourse { get; set; }
        public DbSet<Questions_ErrorCount> questions_ErrorCounts { get; set; }
        public DbSet<PpaperGenerating> ppaperGeneratings { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Video_PlayCountInfo> Video_PlayCountInfo { get; set; }
        public DbSet<StudyStatQuery> StudyStatQuery { get; set; }
        public DbSet<SurplusStudyTime> SurplusStudyTime { get; set; }
        public DbSet<SchoolSubject> SchoolSubject { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<ClassAddtion> ClassAddtion { get; set; }
        public DbSet<FindDrivingSchool> FindDrivingSchool { get; set; }
        public DbSet<QuestionsCollect> QuestionsCollect { get; set; }
        public DbSet<CoachRankings> CoachRankings { get; set; }
        public DbSet<QuestionInfo> QuestionInfo { get; set; }
        public DbSet<Video_EvaluationInfo> Video_EvaluationInfo { get; set; }
        public DbSet<Feedback.Feedback> Feedback { get; set; }

        public DbSet<TeacherTemplate> TeacherTemplate { get; set; }
        public DbSet<StudentBlackList> StudentBlackList { get; set; }
        public DbSet<Site> Site { get; set; }
        public DbSet<ChargeData> ChargeData { get; set; }
        public DbSet<Organize> Organize { get; set; }
        public DbSet<tb_StudyStat_Student> tb_StudyStat_Students { get; set; }
        public DbSet<TeacherLeave> TeacherLeave { get; set; }
        public DbSet<StudyTime> StudyTime { get; set; }
        public DbSet<VehicleBrandModel> VehicleBrandModel { get; set; }

    }
}
