using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article article;

    [SetUp]
    public void SetUp()
    {
        article = new Article();
    }

    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] input = new string[] { "VW Golf Bild", "Champions Wimbledon Times", "Invincibles Arsenal Guardian" };
        Article expected = new Article();
        for (int i = 0; i < input.Length; i++)
        {
            string[] tokens = input[0].Split(" ");
            article.Title = tokens[0];
            article.Content = tokens[1];
            article.Author = tokens[2];
            expected.ArticleList.Add(article);
        }

        // Act
        Article actual = article.AddArticles(input);

        // Assert
        Assert.AreEqual(expected.ArticleList.Count, actual.ArticleList.Count);
        Assert.AreEqual(expected.Title, actual.Title);
        Assert.AreEqual(expected.Content, actual.Content);
        Assert.AreEqual(expected.Author, actual.Author);
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        // Arrange
        string[] input = new string[] { "VW Golf Bild", "Champions Wimbledon Times", "Invincibles Arsenal Guardian" };
        string criteria = "title";
        Article currentArticle = article.AddArticles(input);
        string expected = $"Champions - Wimbledon: Times{Environment.NewLine}" +
                          $"Invincibles - Arsenal: Guardian{Environment.NewLine}" +
                          $"VW - Golf: Bild";

        // Act
        string actual = article.GetArticleList(currentArticle, criteria);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        // Arrange
        string[] input = new string[] { "VW Golf Bild", "Champions Wimbledon Times", "Invincibles Arsenal Guardian" };
        string criteria = "";
        Article currentArticle = article.AddArticles(input);
        string expected = "";

        // Act
        string actual = article.GetArticleList(currentArticle, criteria);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
