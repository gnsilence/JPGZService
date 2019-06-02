using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JPGZService.Migrations.JPGZServiceDb
{
    public partial class sqlserverinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_AppointmentDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppNo = table.Column<string>(nullable: true),
                    CourseNo = table.Column<string>(nullable: true),
                    StuID = table.Column<int>(nullable: true),
                    TeacherID = table.Column<int>(nullable: true),
                    CourseType = table.Column<int>(nullable: true),
                    DrivingType = table.Column<string>(nullable: true),
                    CoursePrice = table.Column<decimal>(nullable: true),
                    CourseDiscount = table.Column<double>(nullable: true),
                    PayMoney = table.Column<decimal>(nullable: true),
                    AppStatus = table.Column<int>(nullable: true),
                    ReviewStatus = table.Column<int>(nullable: true),
                    EvalStatus = table.Column<int>(nullable: true),
                    EvalClass = table.Column<int>(nullable: true),
                    EvalContent = table.Column<string>(nullable: true),
                    EvalDateTime = table.Column<DateTime>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    PayPath = table.Column<int>(nullable: true),
                    PayType = table.Column<int>(nullable: true),
                    IsCheckout = table.Column<int>(nullable: true),
                    CourseID = table.Column<int>(nullable: true),
                    VehicleLevel = table.Column<int>(nullable: true),
                    CourseLevel = table.Column<int>(nullable: true),
                    IsAbsenteeism = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_AppointmentDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_BranchSchool",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DriveSchoolId = table.Column<int>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BName = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    OpenDate = table.Column<DateTime>(nullable: true),
                    TechSiteNum = table.Column<int>(nullable: true),
                    AdmissionsSiteNum = table.Column<int>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    PhotoAlbum = table.Column<string>(nullable: true),
                    Introduction = table.Column<string>(nullable: true),
                    DeleteMark = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_BranchSchool", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_ChargeData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: true),
                    ChargeType = table.Column<int>(nullable: true),
                    ChargeStatus = table.Column<int>(nullable: true),
                    ChargeMoney = table.Column<decimal>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    ChargeUserId = table.Column<int>(nullable: true),
                    ChargeTime = table.Column<DateTime>(nullable: true),
                    AuditUserId = table.Column<int>(nullable: true),
                    AuditTime = table.Column<DateTime>(nullable: true),
                    AuditStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ChargeData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_ClassAddtion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassId = table.Column<int>(nullable: false),
                    StandardPrice = table.Column<decimal>(nullable: true),
                    TrainPattern = table.Column<int>(nullable: true),
                    ChargePattern = table.Column<int>(nullable: true),
                    PayMentPattern = table.Column<int>(nullable: true),
                    Part1Hours = table.Column<double>(nullable: true),
                    Part2Hours = table.Column<double>(nullable: true),
                    Part3Hours = table.Column<double>(nullable: true),
                    Part4Hours = table.Column<double>(nullable: true),
                    Part1PreMoney = table.Column<decimal>(nullable: true),
                    Part2PreMoney = table.Column<decimal>(nullable: true),
                    Part3PreMoney = table.Column<decimal>(nullable: true),
                    Part4PreMoney = table.Column<decimal>(nullable: true),
                    ChargeDescribe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_ClassAddtion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_ClassInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassName = table.Column<string>(nullable: true),
                    Propagslogan = table.Column<string>(nullable: true),
                    CarType = table.Column<int>(nullable: true),
                    CarTypeName = table.Column<string>(nullable: true),
                    ClassLable = table.Column<string>(nullable: true),
                    ServiceExplain = table.Column<string>(nullable: true),
                    Applicatnotes = table.Column<string>(nullable: true),
                    ClassAlbum = table.Column<string>(nullable: true),
                    ActiveStatus = table.Column<int>(nullable: true),
                    IsDelete = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    ActiveTime = table.Column<DateTime>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    CancelActiveUser = table.Column<string>(nullable: true),
                    CancelTime = table.Column<DateTime>(nullable: true),
                    ClassIntro = table.Column<string>(nullable: true),
                    DriveSchoolId = table.Column<int>(nullable: false),
                    BranchSchoolId = table.Column<int>(nullable: false),
                    seq = table.Column<string>(nullable: true),
                    UploadStatus = table.Column<int>(nullable: true),
                    uptime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_ClassInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Complaint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Objenum = table.Column<int>(nullable: false),
                    Cdate = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Depaopinion = table.Column<string>(nullable: true),
                    Schopinion = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    HandleDate = table.Column<DateTime>(nullable: true),
                    HandleStatus = table.Column<int>(nullable: true),
                    ReceptionUser = table.Column<int>(nullable: true),
                    UploadStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Complaint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_ConfigFirst",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    FirstMark = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    Ldate = table.Column<DateTime>(nullable: true),
                    DeleteMark = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ConfigFirst", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_ConfigSecond",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SecondID = table.Column<int>(nullable: false),
                    FirstID = table.Column<int>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    Ldate = table.Column<DateTime>(nullable: true),
                    SecondOrder = table.Column<int>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: true),
                    SecondMark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ConfigSecond", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_DriveSchool",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DriveSchoolNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RegionNo = table.Column<string>(nullable: true),
                    TechType = table.Column<string>(nullable: true),
                    TechTypeName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TrainUnitSigner = table.Column<string>(nullable: true),
                    BName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    BusinessNo = table.Column<string>(nullable: true),
                    LegalMan = table.Column<string>(nullable: true),
                    Mobilephone = table.Column<string>(nullable: true),
                    Landline = table.Column<string>(nullable: true),
                    Lesence = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: true),
                    FirstHalfYear = table.Column<int>(nullable: true),
                    SecondHalfYear = table.Column<int>(nullable: true),
                    ICCardCount = table.Column<int>(nullable: true),
                    MinCarNum = table.Column<int>(nullable: true),
                    Gpsid = table.Column<int>(nullable: true),
                    IsUpLoadStuPic = table.Column<bool>(nullable: false),
                    IsUpLoadTeacherPic = table.Column<bool>(nullable: false),
                    IsShowLegalManSeal = table.Column<bool>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: true),
                    AddUserId = table.Column<int>(nullable: true),
                    OrganizeID = table.Column<int>(nullable: false),
                    ClassLevel = table.Column<int>(nullable: true),
                    TrafficId = table.Column<int>(nullable: true),
                    IsSubjectTwo = table.Column<int>(nullable: false),
                    IsSubjectThree = table.Column<int>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: true),
                    Latitude = table.Column<decimal>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    PhotoAlbum = table.Column<string>(nullable: true),
                    ConsultNum = table.Column<int>(nullable: true),
                    Inscode = table.Column<string>(nullable: true),
                    Licetime = table.Column<DateTime>(nullable: true),
                    Creditcode = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    Coachnumber = table.Column<int>(nullable: false),
                    Grasupvnum = table.Column<int>(nullable: false),
                    Safmngnum = table.Column<int>(nullable: false),
                    Tracarnum = table.Column<int>(nullable: false),
                    Classroom = table.Column<decimal>(nullable: false),
                    Thclassroom = table.Column<decimal>(nullable: false),
                    Praticefield = table.Column<decimal>(nullable: false),
                    UploadStatus = table.Column<int>(nullable: false),
                    District = table.Column<string>(nullable: true),
                    UrbanCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_DriveSchool", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Evaluation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<string>(nullable: true),
                    Evalobject = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Overall = table.Column<int>(nullable: false),
                    Part = table.Column<int>(nullable: false),
                    Evaluatetime = table.Column<DateTime>(nullable: true),
                    Srvmanner = table.Column<string>(nullable: true),
                    Teachlevel = table.Column<string>(nullable: true),
                    UploadStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Evaluation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Exam_Record",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: true),
                    Score = table.Column<int>(nullable: true),
                    ExamTime = table.Column<DateTime>(nullable: true),
                    Subject = table.Column<int>(nullable: true),
                    TrainType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Exam_Record", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    FContent = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    HandleTime = table.Column<DateTime>(nullable: true),
                    HandleIdea = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    DataType = table.Column<int>(nullable: true),
                    DriverId = table.Column<int>(nullable: true),
                    StuId = table.Column<int>(nullable: true),
                    HandleState = table.Column<int>(nullable: true),
                    RegisteredID = table.Column<int>(nullable: true),
                    Overall = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Feedback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ntype = table.Column<int>(nullable: true),
                    UserType = table.Column<int>(nullable: true),
                    Ntitle = table.Column<string>(nullable: true),
                    Ncontent = table.Column<string>(nullable: true),
                    Nattachment = table.Column<string>(nullable: true),
                    SysNattachment = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    Cdate = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    DataOrganizeID = table.Column<int>(nullable: true),
                    IsPublish = table.Column<int>(nullable: false),
                    NewObject = table.Column<int>(nullable: true),
                    CoverPicture = table.Column<string>(nullable: true),
                    IsTopping = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Organize",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    TableName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CorrespondingId = table.Column<int>(nullable: true),
                    levelNum = table.Column<int>(nullable: true),
                    gpsid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Organize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_PaperGenerating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Subject = table.Column<int>(nullable: false),
                    PgName = table.Column<string>(nullable: true),
                    PgCreateUser = table.Column<string>(nullable: true),
                    AddTime = table.Column<DateTime>(nullable: false),
                    MCCount = table.Column<int>(nullable: false),
                    MCFraction = table.Column<int>(nullable: false),
                    MCQCount = table.Column<int>(nullable: false),
                    MCQFraction = table.Column<int>(nullable: false),
                    JudgmentCount = table.Column<int>(nullable: false),
                    JudgmentFraction = table.Column<int>(nullable: false),
                    TrainIsPassFration = table.Column<int>(nullable: false),
                    PageDuration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_PaperGenerating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_PreRegistration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Mobilephone = table.Column<string>(nullable: true),
                    ClassInfoId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    IdCardNo = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true),
                    HouseholdType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_PreRegistration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurriculumId = table.Column<int>(nullable: true),
                    QuesTitle = table.Column<string>(nullable: true),
                    QuesType = table.Column<int>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    FileType = table.Column<int>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    AddTime = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<int>(nullable: true),
                    KnowledgeType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Questions_AnswerCount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    AnswerCount = table.Column<int>(nullable: false),
                    ErrorCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Questions_AnswerCount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Questions_Collect",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: true),
                    CollectUer = table.Column<int>(nullable: true),
                    CollectTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Questions_Collect", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Questions_ErrorCount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    AnswerUer = table.Column<int>(nullable: false),
                    AnswerTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Questions_ErrorCount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_RegisterRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationQuantity = table.Column<int>(nullable: true),
                    ApplicationTime = table.Column<DateTime>(nullable: true),
                    Applicant = table.Column<int>(nullable: true),
                    ApplicationState = table.Column<int>(nullable: true),
                    ApprovalTime = table.Column<DateTime>(nullable: true),
                    Approver = table.Column<int>(nullable: true),
                    ApplicationDrivingSchoolId = table.Column<int>(nullable: true),
                    OrderCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_RegisterRelation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_RegistrationCode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    ApplicationTime = table.Column<DateTime>(nullable: true),
                    ApplicationRecordId = table.Column<int>(nullable: true),
                    BoundStudentId = table.Column<int>(nullable: true),
                    UseState = table.Column<int>(nullable: true),
                    BoundTime = table.Column<DateTime>(nullable: true),
                    BoundDrivingSchoolId = table.Column<int>(nullable: true),
                    CodeKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_RegistrationCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_ReleaseCourse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseNo = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true),
                    CourseDate = table.Column<DateTime>(nullable: true),
                    CourseTimeSlot = table.Column<string>(nullable: true),
                    CoursePrice = table.Column<decimal>(nullable: true),
                    CourseDiscount = table.Column<double>(nullable: true),
                    SiteId = table.Column<int>(nullable: false),
                    VehicleNo = table.Column<string>(nullable: true),
                    DrivingType = table.Column<string>(nullable: true),
                    CourseType = table.Column<int>(nullable: true),
                    CourseContent = table.Column<string>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    IsCancel = table.Column<bool>(nullable: true),
                    HasAppointmentCount = table.Column<int>(nullable: true),
                    AppointmentCount = table.Column<int>(nullable: true),
                    CourseBeginDateTime = table.Column<DateTime>(nullable: true),
                    CourseEndDateTime = table.Column<DateTime>(nullable: true),
                    CourseStatus = table.Column<int>(nullable: true),
                    GPSID = table.Column<int>(nullable: true),
                    PracticeArea = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_ReleaseCourse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_SchoolSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubjectId = table.Column<int>(nullable: true),
                    DrivingType = table.Column<int>(nullable: true),
                    MonitorTime = table.Column<int>(nullable: true),
                    SyllabusTime = table.Column<double>(nullable: true),
                    StudyRate = table.Column<double>(nullable: true),
                    Numerical = table.Column<double>(nullable: true),
                    DeleteMark = table.Column<bool>(nullable: true),
                    SyllabusTime_Simulate = table.Column<double>(nullable: true),
                    StudyRate_Simulate = table.Column<double>(nullable: true),
                    SyllabusTime_Theoretical = table.Column<double>(nullable: true),
                    StudyRate_Theoretical = table.Column<double>(nullable: true),
                    SyllabusTime_Operate = table.Column<double>(nullable: true),
                    StudyRate_Operate = table.Column<double>(nullable: true),
                    SyllabusMil = table.Column<double>(nullable: true),
                    MinStudyTime = table.Column<double>(nullable: true),
                    MinMilage = table.Column<double>(nullable: true),
                    MaxStudyTime = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_SchoolSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Site",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DriveSchoolId = table.Column<int>(nullable: true),
                    BranchSchoolId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    SiteType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Site", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Student_Base",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICCardNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: true),
                    Native = table.Column<string>(nullable: true),
                    Birthday = table.Column<string>(nullable: true),
                    IDCardNo = table.Column<string>(nullable: true),
                    FamilyAddress = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Mobilephone = table.Column<string>(nullable: true),
                    Landline = table.Column<string>(nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: true),
                    DriveType = table.Column<int>(nullable: true),
                    RegisterPlace = table.Column<int>(nullable: true),
                    AddUserId = table.Column<int>(nullable: true),
                    FingerPrint4 = table.Column<string>(nullable: true),
                    AddTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Batch = table.Column<int>(nullable: true),
                    Pic = table.Column<string>(nullable: true),
                    PaType = table.Column<int>(nullable: true),
                    NativeType = table.Column<int>(nullable: true),
                    RegType = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    MakeStatus = table.Column<int>(nullable: true),
                    ActiveTime = table.Column<DateTime>(nullable: true),
                    SeforeStudyVehicleType = table.Column<int>(nullable: true),
                    FingerPrint1 = table.Column<string>(nullable: true),
                    FingerPrint2 = table.Column<string>(nullable: true),
                    FingerPrint3 = table.Column<string>(nullable: true),
                    TheoryState = table.Column<int>(nullable: true),
                    OperationState = table.Column<int>(nullable: true),
                    OriginalDrivingLicenseNo = table.Column<string>(nullable: true),
                    DrivingLicenseOfMaturity = table.Column<DateTime>(nullable: true),
                    TemporaryRP = table.Column<string>(nullable: true),
                    TemporaryRPDate = table.Column<DateTime>(nullable: true),
                    TrainingContractScan = table.Column<string>(nullable: true),
                    PAIjInsurance = table.Column<int>(nullable: true),
                    GeaduateDate = table.Column<DateTime>(nullable: true),
                    GraduateNo = table.Column<string>(nullable: true),
                    DriveSchoolId = table.Column<int>(nullable: true),
                    StudentCardNo = table.Column<string>(nullable: true),
                    DeleteMark = table.Column<bool>(nullable: true),
                    S_PrintStuCard = table.Column<string>(nullable: true),
                    ApprovalOpinion = table.Column<string>(nullable: true),
                    DataOrganizeID = table.Column<int>(nullable: true),
                    DriveTypeName = table.Column<string>(nullable: true),
                    CheckResult = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Stunum = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    PhotoId = table.Column<string>(nullable: true),
                    FingerprintId = table.Column<string>(nullable: true),
                    Fstdrilicdate = table.Column<DateTime>(nullable: true),
                    UploadStatus = table.Column<int>(nullable: true),
                    BusitType = table.Column<int>(nullable: true),
                    GpsId = table.Column<int>(nullable: true),
                    Rowver = table.Column<DateTime>(nullable: true),
                    ClassId = table.Column<int>(nullable: true),
                    Age = table.Column<int>(nullable: true),
                    BranchSchoolId = table.Column<int>(nullable: true),
                    SiteId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true),
                    ChannelId = table.Column<int>(nullable: true),
                    ClassInfoId = table.Column<int>(nullable: true),
                    HouseholdType = table.Column<int>(nullable: true),
                    ContractAddress = table.Column<string>(nullable: true),
                    Gid = table.Column<string>(nullable: true),
                    RecordType = table.Column<int>(nullable: true),
                    UID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Student_Base", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_StudentAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Createtime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: true),
                    Pic = table.Column<string>(nullable: true),
                    DriveTypeName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    IDCardNo = table.Column<string>(nullable: true),
                    OpenId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_StudentAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_StudentBlackList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    AddTime = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<int>(nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    AddCount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_StudentBlackList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_StudyRecord_Result",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true),
                    BeginTime = table.Column<DateTime>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true),
                    RealTime = table.Column<double>(nullable: true),
                    ActualTime = table.Column<double>(nullable: true),
                    StudyMile = table.Column<double>(nullable: true),
                    SubjectID = table.Column<int>(nullable: true),
                    UploadTime = table.Column<DateTime>(nullable: true),
                    DriveSchoolId = table.Column<int>(nullable: true),
                    GpsId = table.Column<int>(nullable: true),
                    ValidActualTime = table.Column<double>(nullable: true),
                    StudyRate = table.Column<decimal>(nullable: true),
                    HasStat = table.Column<int>(nullable: true),
                    UploadFlag = table.Column<int>(nullable: true),
                    DeleteMark = table.Column<bool>(nullable: true),
                    IsManual = table.Column<bool>(nullable: true),
                    ValidFlag = table.Column<int>(nullable: true),
                    MaxSpeed = table.Column<int>(nullable: true),
                    Mileage = table.Column<double>(nullable: true),
                    HasCalcMileage = table.Column<bool>(nullable: true),
                    CalcFlag = table.Column<int>(nullable: true),
                    StudyType = table.Column<int>(nullable: true),
                    ValidSpeed = table.Column<bool>(nullable: true),
                    HasCalcVehStatus = table.Column<bool>(nullable: true),
                    ValidVehStatus = table.Column<bool>(nullable: true),
                    HasAnalysed = table.Column<bool>(nullable: true),
                    HasCalcBlindspot = table.Column<bool>(nullable: true),
                    ValidBlindspot = table.Column<bool>(nullable: true),
                    StudentCardNo = table.Column<string>(nullable: true),
                    TecCardNo = table.Column<string>(nullable: true),
                    VehicleNo = table.Column<string>(nullable: true),
                    DriveSchoolName = table.Column<string>(nullable: true),
                    TeacherName = table.Column<string>(nullable: true),
                    UploadPhotos = table.Column<bool>(nullable: true),
                    UploadStatus = table.Column<int>(nullable: true),
                    Recnum = table.Column<string>(nullable: true),
                    TrainingPrograms = table.Column<string>(nullable: true),
                    ClassId = table.Column<string>(nullable: true),
                    Stunum = table.Column<string>(nullable: true),
                    Coachnum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_StudyRecord_Result", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_StudyStat_Query",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: true),
                    Subject1Theory = table.Column<double>(nullable: true),
                    Subject1ToTalAmt = table.Column<double>(nullable: true),
                    Subject2ToTalAmt = table.Column<double>(nullable: true),
                    Subject2Theory = table.Column<double>(nullable: true),
                    Subject2Operate = table.Column<double>(nullable: true),
                    Subject2Simulate = table.Column<double>(nullable: true),
                    Subject3ToTalAmt = table.Column<double>(nullable: true),
                    Subject3Theory = table.Column<double>(nullable: true),
                    Subject3Operate = table.Column<double>(nullable: true),
                    Subject3Simulate = table.Column<double>(nullable: true),
                    BInNewApply = table.Column<int>(nullable: true),
                    Subject1_OnlineLearning = table.Column<double>(nullable: true),
                    Subject2_OnlineLearning = table.Column<double>(nullable: true),
                    Subject3_OnlineLearning = table.Column<double>(nullable: true),
                    S3mileage = table.Column<double>(nullable: true),
                    LastStudyTime = table.Column<DateTime>(nullable: true),
                    Subject4Theory = table.Column<double>(nullable: true),
                    Subject4ToTalAmt = table.Column<double>(nullable: true),
                    Subject4_OnlineLearning = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_StudyStat_Query", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_StudyStat_Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: true),
                    SubjectId = table.Column<int>(nullable: true),
                    RealTime = table.Column<double>(nullable: true),
                    ActualTime = table.Column<double>(nullable: true),
                    ValidActualTime = table.Column<double>(nullable: true),
                    InvalidActualTime = table.Column<double>(nullable: true),
                    StudyRate = table.Column<double>(nullable: true),
                    ValidStudyTimeExam = table.Column<int>(nullable: true),
                    StudyType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_StudyStat_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_SurplusStudyTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: true),
                    Part1SUMHours = table.Column<double>(nullable: true),
                    Part2SUMHours = table.Column<double>(nullable: true),
                    Part3SUMHours = table.Column<double>(nullable: true),
                    Part4SUMHours = table.Column<double>(nullable: true),
                    Part1SurplusHours = table.Column<double>(nullable: true),
                    Part2SurplusHours = table.Column<double>(nullable: true),
                    Part3SurplusHours = table.Column<double>(nullable: true),
                    Part4SurplusHours = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_SurplusStudyTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICCardNo = table.Column<string>(nullable: true),
                    TeacherCardNo = table.Column<string>(nullable: true),
                    TeacherName = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    IDCardNo = table.Column<string>(nullable: true),
                    Mobilephone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    TechVehicleType = table.Column<string>(nullable: true),
                    DriveVehicleType = table.Column<string>(nullable: true),
                    DriveCardNo = table.Column<string>(nullable: true),
                    TeachYear = table.Column<string>(nullable: true),
                    DriveYear = table.Column<string>(nullable: true),
                    BeginCardDate = table.Column<DateTime>(nullable: true),
                    BeginDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    TeacherType = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DriveSchoolId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    StatusUserId = table.Column<int>(nullable: true),
                    ContractNo = table.Column<string>(nullable: true),
                    HireStartDate = table.Column<DateTime>(nullable: true),
                    HireEndDate = table.Column<DateTime>(nullable: true),
                    FireDate = table.Column<DateTime>(nullable: true),
                    Beian = table.Column<string>(nullable: true),
                    PaType = table.Column<string>(nullable: true),
                    TeachPaNo = table.Column<string>(nullable: true),
                    EducationBg = table.Column<int>(nullable: true),
                    TechGrade = table.Column<int>(nullable: true),
                    CarType = table.Column<int>(nullable: true),
                    CarTypeName = table.Column<string>(nullable: true),
                    AddTime = table.Column<DateTime>(nullable: true),
                    TechPic = table.Column<string>(nullable: true),
                    FingerPrint1 = table.Column<string>(nullable: true),
                    FingerPrint2 = table.Column<string>(nullable: true),
                    FingerPrint3 = table.Column<string>(nullable: true),
                    FingerPrint4 = table.Column<string>(nullable: true),
                    Gpsid = table.Column<int>(nullable: true),
                    DeleteMark = table.Column<bool>(nullable: true),
                    AddUserId = table.Column<int>(nullable: true),
                    TeachCarType = table.Column<int>(nullable: true),
                    TecCardNo = table.Column<string>(nullable: true),
                    DataOrganizeID = table.Column<int>(nullable: true),
                    TheoryState = table.Column<int>(nullable: true),
                    OperationState = table.Column<int>(nullable: true),
                    ActionType = table.Column<int>(nullable: true),
                    BranchSchoolId = table.Column<int>(nullable: true),
                    UID = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true),
                    Coachnum = table.Column<string>(nullable: true),
                    PhotoId = table.Column<string>(nullable: true),
                    FingerprintId = table.Column<string>(nullable: true),
                    Occupationno = table.Column<string>(nullable: true),
                    Employstatus = table.Column<int>(nullable: false),
                    TrainingStatus = table.Column<int>(nullable: false),
                    CoachRole = table.Column<int>(nullable: false),
                    UploadStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_TeacherLeave",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeacherId = table.Column<int>(nullable: true),
                    TimeToLeave = table.Column<float>(nullable: true),
                    LeaveCause = table.Column<string>(nullable: true),
                    IsPushInfo = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    OperateMan = table.Column<string>(nullable: true),
                    LeaveCourseIds = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_TeacherLeave", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_teacherTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddType = table.Column<int>(nullable: true),
                    DriveSchoolID = table.Column<int>(nullable: true),
                    TeaOrGroupID = table.Column<int>(nullable: true),
                    TemplateName = table.Column<string>(nullable: true),
                    IsPush = table.Column<int>(nullable: true),
                    Isdefault = table.Column<int>(nullable: true),
                    AppRange = table.Column<int>(nullable: true),
                    PayPath = table.Column<int>(nullable: true),
                    CarType = table.Column<string>(nullable: true),
                    SubjectID = table.Column<int>(nullable: true),
                    DetailSubjectID = table.Column<int>(nullable: true),
                    IntervalTime = table.Column<int>(nullable: true),
                    BeginTime = table.Column<string>(nullable: true),
                    EndTime = table.Column<string>(nullable: true),
                    CanAppCount = table.Column<int>(nullable: true),
                    ClassIDS = table.Column<string>(nullable: true),
                    StandardPrice = table.Column<decimal>(nullable: true),
                    SiteId = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_teacherTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_TeachingArea",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DriveSchoolId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Area = table.Column<decimal>(nullable: true),
                    VehicleType = table.Column<string>(nullable: true),
                    Polygon = table.Column<string>(nullable: true),
                    Totalvehnum = table.Column<int>(nullable: true),
                    Curvehnum = table.Column<int>(nullable: true),
                    UploadStatus = table.Column<string>(nullable: true),
                    Flag = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    DriveSchoolName = table.Column<string>(nullable: true),
                    TAType = table.Column<int>(nullable: true),
                    seq = table.Column<string>(nullable: true),
                    polygonGuid = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    GpsCoordinates = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_TeachingArea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_TrainCurriculum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Subject = table.Column<int>(nullable: true),
                    TrainType = table.Column<int>(nullable: true),
                    TrainTypeName = table.Column<string>(nullable: true),
                    SubjCode = table.Column<string>(nullable: true),
                    Curriculum = table.Column<string>(nullable: true),
                    CurriculumType = table.Column<int>(nullable: true),
                    Intcurriculum = table.Column<string>(nullable: true),
                    Duration = table.Column<double>(nullable: true),
                    Learningper = table.Column<DateTime>(nullable: true),
                    Accessper = table.Column<int>(nullable: true),
                    Changing = table.Column<double>(nullable: true),
                    IsDelete = table.Column<int>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    AddTime = table.Column<DateTime>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_TrainCurriculum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleNo = table.Column<string>(nullable: true),
                    FrameNo = table.Column<string>(nullable: true),
                    KindID = table.Column<int>(nullable: true),
                    DrivingLicenseNo = table.Column<string>(nullable: true),
                    OperatingLicensesNo = table.Column<string>(nullable: true),
                    EngineModel = table.Column<string>(nullable: true),
                    Manufactory = table.Column<int>(nullable: false),
                    FactoryDate = table.Column<DateTime>(nullable: true),
                    BuyDate = table.Column<DateTime>(nullable: true),
                    BuyMoney = table.Column<double>(nullable: true),
                    OperationsDate = table.Column<DateTime>(nullable: true),
                    OperationsType = table.Column<int>(nullable: true),
                    WorkStatus = table.Column<int>(nullable: true),
                    Vpicture = table.Column<string>(nullable: true),
                    PlateColor = table.Column<int>(nullable: true),
                    ColorID = table.Column<int>(nullable: true),
                    Usage = table.Column<int>(nullable: true),
                    BandID = table.Column<int>(nullable: true),
                    EngineNo = table.Column<string>(nullable: true),
                    Vweight = table.Column<double>(nullable: true),
                    LoadingCapacity = table.Column<double>(nullable: true),
                    SeatCount = table.Column<int>(nullable: true),
                    RegAddress = table.Column<string>(nullable: true),
                    EnergyType = table.Column<int>(nullable: true),
                    QualificationNo = table.Column<string>(nullable: true),
                    BusinessScope = table.Column<string>(nullable: true),
                    Structure = table.Column<int>(nullable: true),
                    ExhaustEmissions = table.Column<double>(nullable: true),
                    DeleteMark = table.Column<bool>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: true),
                    AddUserId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TrainSiteId = table.Column<int>(nullable: true),
                    Beian = table.Column<int>(nullable: false),
                    DriveSchoolId = table.Column<int>(nullable: true),
                    DataOrganizeID = table.Column<int>(nullable: false),
                    GpsId = table.Column<int>(nullable: true),
                    BranchSchoolId = table.Column<int>(nullable: true),
                    Carnum = table.Column<string>(nullable: true),
                    PhotoId = table.Column<string>(nullable: true),
                    VehicleTiainType = table.Column<string>(nullable: true),
                    UploadStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_VehicleBrandModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ManufacturerName = table.Column<string>(nullable: true),
                    JG_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_VehicleBrandModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Video",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurriculumId = table.Column<int>(nullable: true),
                    CoursewareCode = table.Column<string>(nullable: true),
                    Courseware = table.Column<string>(nullable: true),
                    CoursewareType = table.Column<int>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    IntCourseware = table.Column<string>(nullable: true),
                    Duration = table.Column<double>(nullable: true),
                    CoursePath = table.Column<string>(nullable: true),
                    Accessper = table.Column<int>(nullable: true),
                    Changing = table.Column<double>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    AddTime = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Video", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Video_Evaluation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: true),
                    VideoId = table.Column<int>(nullable: true),
                    Overall = table.Column<int>(nullable: true),
                    EvaluateTime = table.Column<DateTime>(nullable: true),
                    Srvmanner = table.Column<string>(nullable: true),
                    Teachlevel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Video_Evaluation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Video_PlayCount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VideoId = table.Column<int>(nullable: true),
                    PlayCount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Video_PlayCount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Video_Record",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    VideoId = table.Column<int>(nullable: false),
                    Subject = table.Column<int>(nullable: false),
                    TrainType = table.Column<string>(nullable: true),
                    PlayTime = table.Column<DateTime>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    StudyRecordResultId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Video_Record", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "td_Study_Photo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GpsId = table.Column<int>(nullable: true),
                    PhotoTime = table.Column<DateTime>(nullable: false),
                    PhotoPathName = table.Column<string>(nullable: true),
                    UploadTime = table.Column<DateTime>(nullable: false),
                    PhotoId = table.Column<string>(nullable: true),
                    PhotoSource = table.Column<int>(nullable: false),
                    UploadStatus = table.Column<int>(nullable: false),
                    ClassId = table.Column<string>(nullable: true),
                    Stunum = table.Column<string>(nullable: true),
                    EventType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_td_Study_Photo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "V_CoachRankings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeacherName = table.Column<string>(nullable: true),
                    TechPic = table.Column<string>(nullable: true),
                    TeachYear = table.Column<string>(nullable: true),
                    TotalReview = table.Column<int>(nullable: true),
                    PraiseTotal = table.Column<int>(nullable: true),
                    BadTotal = table.Column<int>(nullable: true),
                    Average = table.Column<int>(nullable: true),
                    RegistrationTotal = table.Column<int>(nullable: true),
                    MothRegistrationTotal = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Bname = table.Column<string>(nullable: true),
                    BAddress = table.Column<string>(nullable: true),
                    UrbanCode = table.Column<string>(nullable: true),
                    RegionNo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StandardPrice = table.Column<decimal>(nullable: true),
                    DriveSchoolId = table.Column<int>(nullable: true),
                    CoachRole = table.Column<int>(nullable: true),
                    Employstatus = table.Column<int>(nullable: true),
                    DeleteMark = table.Column<bool>(nullable: true),
                    TrainingStatus = table.Column<int>(nullable: true),
                    UploadStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_CoachRankings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "V_FindDrivingSchool",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    SNum = table.Column<int>(nullable: true),
                    StandardPrice = table.Column<decimal>(nullable: true),
                    Score = table.Column<int>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Longitude = table.Column<decimal>(nullable: true),
                    Latitude = table.Column<decimal>(nullable: true),
                    UrbanCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_FindDrivingSchool", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "V_StudyTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: true),
                    Part1SUMValidHours = table.Column<int>(nullable: true),
                    Part2SUMValidHours = table.Column<int>(nullable: true),
                    Part3SUMValidHours = table.Column<int>(nullable: true),
                    Part4SUMValidHours = table.Column<int>(nullable: true),
                    Part1SUMHours = table.Column<int>(nullable: true),
                    Part2SUMHours = table.Column<int>(nullable: true),
                    Part3SUMHours = table.Column<int>(nullable: true),
                    Part4SUMHours = table.Column<int>(nullable: true),
                    Part1SurplusHours = table.Column<double>(nullable: true),
                    Part2SurplusHours = table.Column<double>(nullable: true),
                    Part3SurplusHours = table.Column<double>(nullable: true),
                    Part4SurplusHours = table.Column<double>(nullable: true),
                    IDCardNo = table.Column<string>(nullable: true),
                    DriveType = table.Column<int>(nullable: true),
                    DriveTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_StudyTime", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_AppointmentDetail");

            migrationBuilder.DropTable(
                name: "Tb_BranchSchool");

            migrationBuilder.DropTable(
                name: "tb_ChargeData");

            migrationBuilder.DropTable(
                name: "Tb_ClassAddtion");

            migrationBuilder.DropTable(
                name: "Tb_ClassInfo");

            migrationBuilder.DropTable(
                name: "tb_Complaint");

            migrationBuilder.DropTable(
                name: "tb_ConfigFirst");

            migrationBuilder.DropTable(
                name: "tb_ConfigSecond");

            migrationBuilder.DropTable(
                name: "tb_DriveSchool");

            migrationBuilder.DropTable(
                name: "tb_Evaluation");

            migrationBuilder.DropTable(
                name: "tb_Exam_Record");

            migrationBuilder.DropTable(
                name: "tb_Feedback");

            migrationBuilder.DropTable(
                name: "tb_News");

            migrationBuilder.DropTable(
                name: "tb_Organize");

            migrationBuilder.DropTable(
                name: "tb_PaperGenerating");

            migrationBuilder.DropTable(
                name: "tb_PreRegistration");

            migrationBuilder.DropTable(
                name: "tb_Questions");

            migrationBuilder.DropTable(
                name: "tb_Questions_AnswerCount");

            migrationBuilder.DropTable(
                name: "tb_Questions_Collect");

            migrationBuilder.DropTable(
                name: "tb_Questions_ErrorCount");

            migrationBuilder.DropTable(
                name: "tb_RegisterRelation");

            migrationBuilder.DropTable(
                name: "tb_RegistrationCode");

            migrationBuilder.DropTable(
                name: "Tb_ReleaseCourse");

            migrationBuilder.DropTable(
                name: "tb_SchoolSubjects");

            migrationBuilder.DropTable(
                name: "tb_Site");

            migrationBuilder.DropTable(
                name: "tb_Student_Base");

            migrationBuilder.DropTable(
                name: "tb_StudentAccount");

            migrationBuilder.DropTable(
                name: "tb_StudentBlackList");

            migrationBuilder.DropTable(
                name: "tb_StudyRecord_Result");

            migrationBuilder.DropTable(
                name: "tb_StudyStat_Query");

            migrationBuilder.DropTable(
                name: "tb_StudyStat_Student");

            migrationBuilder.DropTable(
                name: "tb_SurplusStudyTime");

            migrationBuilder.DropTable(
                name: "tb_Teacher");

            migrationBuilder.DropTable(
                name: "Tb_TeacherLeave");

            migrationBuilder.DropTable(
                name: "tb_teacherTemplate");

            migrationBuilder.DropTable(
                name: "tb_TeachingArea");

            migrationBuilder.DropTable(
                name: "tb_TrainCurriculum");

            migrationBuilder.DropTable(
                name: "tb_Vehicle");

            migrationBuilder.DropTable(
                name: "tb_VehicleBrandModel");

            migrationBuilder.DropTable(
                name: "tb_Video");

            migrationBuilder.DropTable(
                name: "tb_Video_Evaluation");

            migrationBuilder.DropTable(
                name: "tb_Video_PlayCount");

            migrationBuilder.DropTable(
                name: "tb_Video_Record");

            migrationBuilder.DropTable(
                name: "td_Study_Photo");

            migrationBuilder.DropTable(
                name: "V_CoachRankings");

            migrationBuilder.DropTable(
                name: "V_FindDrivingSchool");

            migrationBuilder.DropTable(
                name: "V_StudyTime");
        }
    }
}
