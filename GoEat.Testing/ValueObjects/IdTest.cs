using FluentAssertions;
using GoEat.Logic.Order.Exceptions;
using GoEat.Logic.Order.ValueObjects;
using NUnit.Framework;
using System;


namespace GoEat.UnitTests.ValueObjects;

[TestFixture]
public class IdTest
{
    [Test]

    public void Id_IsEmptyGuid_ThrowsException()
    {
        // TODO: find fluent assertions throw equivlent
        Assert.Throws<GuidCannotBeEmptyException>(() => new Id(Guid.Empty));
    }

    [Test]

    public void Id_StringIsNotValidGuidFormat_ThrowsException()
    {
        Assert.Throws<NotAValidGuidException>(() => new Id("abc"));
    }

    [Test]

    public void Id_StringIsEmptyGuid_ThrowsException()
    {
        Assert.Throws<GuidCannotBeEmptyException>(() => new Id("00000000-0000-0000-0000-000000000000"));
    }
    
    [Test]
    public void Id_StringIsNotEmpty_returnsId()
    {
        var id = new Id(Guid.NewGuid());
        //Assert.IsTrue(Guid.TryParse(id.Value.ToString(), out _));

        Guid.TryParse(id.Value.ToString(), out _).Should().BeTrue();
    }

    [Test]
    public void Test()
    {
        var id = new Id("B442AEBC-6A71-455C-B1B8-D1C33BFFC1E2");
        Assert.IsTrue(id.Value.ToString().Equals(id.Value.ToString()));
    }
}
