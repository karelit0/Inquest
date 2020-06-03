using System.Data.Common;
using Abp.Zero.EntityFramework;
using DanielMaldonado.Inquest.Authorization.Roles;
using DanielMaldonado.Inquest.MultiTenancy;
using DanielMaldonado.Inquest.Users;
using DanielMaldonado.Inquest.Entity.Survey;
using System.Data.Entity;
using DanielMaldonado.Inquest.EntityFramework.Mapping;
using DanielMaldonado.Inquest.Entity.Location;
using DanielMaldonado.Inquest.EntityFramework.Mapping.Location;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DanielMaldonado.Inquest.EntityFramework
{
    public class InquestDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        #region Survey
        public virtual IDbSet<Answer> AnswerList { get; set; }
        public virtual IDbSet<Category> CategoryList { get; set; }
        public virtual IDbSet<Question> QuestionList { get; set; }
        public virtual IDbSet<QuestionOption> QuestionOptionList { get; set; }
        public virtual IDbSet<QuestionType> QuestionTypeList { get; set; }
        public virtual IDbSet<Survey> SurveyList { get; set; }
        public virtual IDbSet<Surveyed> SurveyedList { get; set; }
        public virtual IDbSet<PersonSurveyed> PersonSurveyedList { get; set; }
        #endregion

        #region Location
        public virtual IDbSet<Country> CountryList { get; set; }
        public virtual IDbSet<Province> ProvinceList { get; set; }
        public virtual IDbSet<City> CityList { get; set; }
        public virtual IDbSet<BranchOffice> BranchOfficeList { get; set; }
        #endregion

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public InquestDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in InquestDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of InquestDbContext since ABP automatically handles it.
         */
        public InquestDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public InquestDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public InquestDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //this.Configuration.LazyLoadingEnabled = false;

            #region Survey
            modelBuilder.Configurations.Add(new AnswerMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new QuestionOptionMap());
            modelBuilder.Configurations.Add(new QuestionTypeMap());
            modelBuilder.Configurations.Add(new SurveyMap());
            modelBuilder.Configurations.Add(new SurveyedMap());
            modelBuilder.Configurations.Add(new PersonSurveyedMap());
            #endregion

            #region Location
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new ProvinceMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new BranchOfficeMap());
            #endregion

        }
    }
}
