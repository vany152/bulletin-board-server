﻿using BulletInBoardServer.Domain.Models.Attachments.Surveys.Answers;
using BulletInBoardServer.Domain.Models.Attachments.Surveys.Exceptions;
using BulletInBoardServer.Domain.Models.Attachments.Surveys.Questions;
using BulletInBoardServer.Domain.Models.Attachments.Surveys.Questions.Validation;
using FluentAssertions;
using JetBrains.Annotations;

namespace BulletInBoardServer.Domain.Test.Models.Attachments.Surveys.Questions.Validation;

[TestSubject(typeof(QuestionValidator))]
public class QuestionValidatorTest
{
    [Fact] // todo прогнать тест
    public void AllQuestionsValidOrThrow_AllSerialsUniqueOrThrow_Throws()
    {
        var questions = new QuestionList
        {
            new(Guid.NewGuid(), 1, Guid.NewGuid(), "q1", false,
                [
                    new Answer(Guid.NewGuid(), 1, Guid.NewGuid(), "a1"),
                    new Answer(Guid.NewGuid(), 2, Guid.NewGuid(), "a2"),
                ]
            ),
            new(Guid.NewGuid(), 1, Guid.NewGuid(), "q2", false,
                [
                    new Answer(Guid.NewGuid(), 1, Guid.NewGuid(), "a1"),
                    new Answer(Guid.NewGuid(), 2, Guid.NewGuid(), "a2"),
                ]
            ),
        };

        var validation = () => QuestionValidator.AllQuestionsValidOrThrow(questions);

        validation.Should()
            .Throw<SurveyContainsQuestionSerialsDuplicates>()
            .WithMessage("Среди порядковых номеров вопросов не должно быть повторений");
    }
    
    [Fact]
    public void AllQuestionsValidOrThrow_EmptyQuestionList_Throws()
    {
        var questions = new QuestionList();

        var validation = () => QuestionValidator.AllQuestionsValidOrThrow(questions);

        validation.Should()
            .Throw<ArgumentException>()
            .WithMessage("Список вопросов не может быть пустым");
    }

    [Fact]
    public void QuestionContentValidOrThrow_NullQuestionContent_Throws()
    {
        var validation = () => QuestionValidator.QuestionContentValidOrThrow(null!);

        validation.Should()
            .Throw<ArgumentException>()
            .WithMessage("Контент вопроса не может быть пустым");
    }

    [Fact]
    public void QuestionContentValidOrThrow_EmptyQuestionContent_Throws()
    {
        var validation = () => QuestionValidator.QuestionContentValidOrThrow(string.Empty);

        validation.Should()
            .Throw<ArgumentException>()
            .WithMessage("Контент вопроса не может быть пустым");
    }

    [Fact]
    public void QuestionContentValidOrThrow_WhitespaceQuestionContent_Throws()
    {
        var validation = () => QuestionValidator.QuestionContentValidOrThrow("   ");

        validation.Should()
            .Throw<ArgumentException>()
            .WithMessage("Контент вопроса не может быть пустым");
    }

    [Fact]
    public void AllAnswersValidOrThrow_LessThanTwoAnswersPerQuestion_Throws()
    {
        var answers = new AnswerList
        {
            new(Guid.NewGuid(), 1, Guid.NewGuid(), "answer 1")
        };

        var validation = () => QuestionValidator.AllAnswersValidOrThrow(answers);

        validation.Should()
            .Throw<ArgumentException>()
            .WithMessage("Вариантов ответов не может быть меньше двух");
    }

    [Fact]
    public void AnswerContentValidOrThrow_NullAnswerContent_Throws()
    {
        var validation = () => QuestionValidator.AnswerContentValidOrThrow(null!);

        validation.Should()
            .Throw<ArgumentException>()
            .WithMessage("Контент варианта ответа не может быть пустым");
    }

    [Fact]
    public void AllAnswersValidOrThrow_EmptyAnswerContent_Throws()
    {
        var validation = () => QuestionValidator.AnswerContentValidOrThrow(string.Empty);

        validation.Should()
            .Throw<ArgumentException>()
            .WithMessage("Контент варианта ответа не может быть пустым");
    }

    [Fact]
    public void AllQuestionsValidOrThrow_WhitespaceAnswerContent_Throws()
    {
        var validation = () => QuestionValidator.AnswerContentValidOrThrow("   ");

        validation.Should()
            .Throw<ArgumentException>()
            .WithMessage("Контент варианта ответа не может быть пустым");
    }
}