﻿using BulletInBoardServer.Domain.Models.Attachments.Surveys.Questions;
using BulletInBoardServer.Domain.Models.Attachments.Surveys.SurveyParticipation;

namespace BulletInBoardServer.Domain.Models.Attachments.Surveys.Answers;

/// <summary>
/// Вариант ответа вопроса
/// </summary>
public class Answer
{
    /// <summary>
    /// Идентификатор варианта ответа
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Порядковый номер варианта ответа
    /// </summary>
    public int Serial { get; init; }

    /// <summary>
    /// Идентификатор опроса, к которому относится вариант ответа
    /// </summary>
    public Guid QuestionId { get; init; }

    /// <summary>
    /// Опрос, к которому относится вариант ответа
    /// </summary>
    /// <remarks>
    /// Поле должно устанавливаться только при помощи Entity Framework или конструктора.
    /// Перед использование обязательно должно быть установлено
    /// </remarks>
    public Question Question { get; init; } = null!;

    /// <summary>
    /// Текстовое содержимое варианта ответа
    /// </summary>
    public string Content { get; init; }

    /// <summary>
    /// Количество выбравших вариант ответа пользователей
    /// </summary>
    public int VotersCount { get; set; }

    /// <summary>
    /// Участия пользователей
    /// </summary>
    /// <remarks>
    /// Массив будет пустым, если вариант ответа относится к анонимному опросе
    /// </remarks>
    public ParticipationList Participation { get; init; } = [];



    /// <summary>
    /// Вариант ответа вопроса
    /// </summary>
    /// <param name="id">Идентификатор варианта ответа</param>
    /// <param name="serial">Порядковый номер враианта ответа</param>
    /// <param name="questionId">Идентификатор вопроса, с которым связан вариант вопроса</param>
    /// <param name="content">Текст варианта ответа</param>
    /// <param name="votersCount">Количество проголосовавших за вариант ответа</param>
    public Answer(Guid id, int serial, Guid questionId, string content, int votersCount = 0)
    {
        Id = id;
        Serial = serial;
        QuestionId = questionId;
        Content = content;
        VotersCount = votersCount;
    }

    /// <summary>
    /// Вариант ответа вопроса
    /// </summary>
    /// <param name="id">Идентификатор варианта ответа</param>
    /// <param name="serial">Порядковый номер враианта ответа</param>
    /// <param name="question">Вопрос, с которым связан вариант вопроса</param>
    /// <param name="content">Текст варианта ответа</param>
    /// <param name="votersCount">Количество проголосовавших за вариант ответа</param>
    public Answer(Guid id, int serial,  Question question, string content, int votersCount = 0)
        : this(id, serial, question.Id, content, votersCount)
    {
        Question = question;
    }

    public Answer()
    {
    }



    /// <summary>
    /// Увеличить количество проголосовавших за вариант ответа на 1
    /// </summary>
    public void IncreaseVotersCount() =>
        VotersCount++;
}