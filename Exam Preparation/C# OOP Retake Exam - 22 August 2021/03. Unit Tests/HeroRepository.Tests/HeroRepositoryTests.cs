using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void MethodCreateThrowExceptionWhenHeroIsNull()
    {
        var hero = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() => hero.Create(null));
    }

    [Test]
    public void MethodCreateThrowExceptionWhenHeroIsExsist()
    {
        var hero = new HeroRepository();
        var superHero = new Hero("Ico", 100);
        hero.Create(superHero);
        Assert.Throws<InvalidOperationException>(() => hero.Create(superHero));
    }

    [Test]
    public void MethodCreateShouldWorkCorectly()
    {
        var hero = new HeroRepository();
        var superHero = new Hero("Ico", 100);        
        string target = $"Successfully added hero Ico with level 100";
        string result = hero.Create(superHero);
        Assert.AreEqual(target,result);
    }

    [Test]
    public void MethodRemoveThrowExceptionWhenHeroIsNull()
    {
        var hero = new HeroRepository();
        var superHero = new Hero("Ico", 100);
        Assert.Throws<ArgumentNullException>(() => hero.Remove(null));
    }

    [Test]
    public void MethodRemoveShouldWorkCorectly()
    {
        var hero = new HeroRepository();
        var superHero = new Hero("Ico", 100);
        hero.Create(superHero);
        var target = true;
        var result = hero.Remove("Ico");
        Assert.AreEqual(target, result);
    }

    [Test]
    public void MethodGetHeroWithHighestLevelShouldWorkCorectly()
    {
        var hero = new HeroRepository();
        var superHero = new Hero("Ico", 100);
        hero.Create(superHero);
        hero.Create(new Hero("Petio", 10));
        hero.Create(new Hero("Gosho", 70));
        hero.Create(new Hero("Ivan", 45));
        var target = superHero;
        var result = hero.GetHeroWithHighestLevel();
        Assert.AreEqual(target, result);
    }

    [Test]
    public void MethodGetHeroShouldWorkCorectly()
    {
        var hero = new HeroRepository();
        var superHero = new Hero("Ico", 100);
        hero.Create(superHero);
        hero.Create(new Hero("Petio", 10));
        hero.Create(new Hero("Gosho", 70));
        hero.Create(new Hero("Ivan", 45));
        var target = superHero;
        var result = hero.GetHero("Ico");
        Assert.AreEqual(target, result);
    }

}