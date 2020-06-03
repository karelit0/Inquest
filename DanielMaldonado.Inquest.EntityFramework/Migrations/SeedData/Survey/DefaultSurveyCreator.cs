using System.Linq;
using Abp.Application.Editions;
using DanielMaldonado.Inquest.Editions;
using DanielMaldonado.Inquest.EntityFramework;
using DanielMaldonado.Inquest.Entity.Survey;
using System;

namespace DanielMaldonado.Inquest.Migrations.SeedData
{
    public class DefaultSurveyCreator
    {
        private readonly InquestDbContext _context;

        public DefaultSurveyCreator(InquestDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var questionTypeYesNo = this.createQuestionType("YES/NO");
            var questionOption = this.createQuestionOption(questionTypeYesNo, "SI", "1");
            questionOption = this.createQuestionOption(questionTypeYesNo, "NO", "0");

            var questionTypeNumeric = this.createQuestionType("NUMERIC");
            questionOption = this.createQuestionOption(questionTypeNumeric, "0", "0");
            questionOption = this.createQuestionOption(questionTypeNumeric, "1", "1");
            questionOption = this.createQuestionOption(questionTypeNumeric, "2", "2");
            questionOption = this.createQuestionOption(questionTypeNumeric, "3", "3");
            questionOption = this.createQuestionOption(questionTypeNumeric, "4", "4");
            questionOption = this.createQuestionOption(questionTypeNumeric, "5", "5");
            questionOption = this.createQuestionOption(questionTypeNumeric, "6", "6");
            questionOption = this.createQuestionOption(questionTypeNumeric, "7", "7");
            questionOption = this.createQuestionOption(questionTypeNumeric, "8", "8");
            questionOption = this.createQuestionOption(questionTypeNumeric, "9", "9");
            questionOption = this.createQuestionOption(questionTypeNumeric, "10", "10");

            var survey = this.createSurvey("ENCUESTA DE SATISFACCION");
            var category = this.createCategory("ESTANDARES");
            var question = this.createQuestion(survey, category, questionTypeYesNo, "LE DESPACHARON LOS PRODUCTOS REVISANDO LA FACTURA", "LA PREGUNTA ES DE SELECCION SIMPLE", false);
            question = this.createQuestion(survey, category, questionTypeYesNo, "LE ENTREGARON LA FACTURA", string.Empty, false);

            category = this.createCategory("SATISFACCION");
            question = this.createQuestion(survey, category, questionTypeNumeric, "LA AMABILIDAD DEL CAJERO", "LAS OPCIONES QUE SE DESPLIEGA PARA ESTA PREGUNTA SON 0...10", false);
            question = this.createQuestion(survey, category, questionTypeNumeric, "LA SATISFACCION EN GENERAL", string.Empty, false);
            question = this.createQuestion(survey, category, questionTypeNumeric, "EN QUE NIVEL RECOMENDARIA A FYBECA A AMIGOS O FAMILIARES", string.Empty, false);
        }



        private Question createQuestion(Survey survey, Category category, QuestionType questionType, string name, string note, bool HasMultipleAnswer)
        {
            var question = _context.QuestionList.FirstOrDefault(e => e.Name == name);
            if (question == null)
            {
                question = new Question { Id = Guid.NewGuid(), Survey = survey, Category = category, QuestionType = questionType, Name = name, Note = note, HasMultipleAnswer = HasMultipleAnswer, CreationTime = DateTime.Now, CreatorUserId = 2 };

                _context.QuestionList.Add(question);
                _context.SaveChanges();
            }

            return question;
        }

        private QuestionOption createQuestionOption(QuestionType questionType, string name, string value)
        {
            var questionOption = _context.QuestionOptionList.FirstOrDefault(e => e.Name == name && e.Value == value);
            if (questionOption == null)
            {
                questionOption = new QuestionOption { Id = Guid.NewGuid(), QuestionType = questionType, Name = name, Value = value, CreationTime = DateTime.Now, CreatorUserId = 2 };

                _context.QuestionOptionList.Add(questionOption);
                _context.SaveChanges();
            }

            return questionOption;
        }
        private QuestionType createQuestionType(string name)
        {
            var questionType = _context.QuestionTypeList.FirstOrDefault(e => e.Name == name);
            if (questionType == null)
            {
                questionType = new QuestionType { Id = Guid.NewGuid(), Name = name, CreationTime = DateTime.Now, CreatorUserId = 2 };

                _context.QuestionTypeList.Add(questionType);
                _context.SaveChanges();
            }

            return questionType;
        }
        private Survey createSurvey(string name)
        {
            var survey = _context.SurveyList.FirstOrDefault(e => e.Name == name);
            if (survey == null)
            {
                survey = new Survey { Id = Guid.NewGuid(), Name = name, CreationTime = DateTime.Now, CreatorUserId = 2 };
                _context.SurveyList.Add(survey);
                _context.SaveChanges();
            }

            return survey;
        }
        private Category createCategory(string name)
        {
            var category = _context.CategoryList.FirstOrDefault(e => e.Name == name);
            if (category == null)
            {
                category = new Category { Id = Guid.NewGuid(), Name = name, CreationTime = DateTime.Now, CreatorUserId = 2 };
                _context.CategoryList.Add(category);
                _context.SaveChanges();
            }

            return category;
        }

    }
}