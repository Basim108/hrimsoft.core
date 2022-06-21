// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the\nproperty of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual\nproperty law. Dissemination of this information or reproduction of this material is strictly forbidden,\nunless prior written permission is obtained from EPAM Systems, Inc

using System;
using System.Collections.Generic;
using FluentAssertions;
using Hrimsoft.Core.Extensions;
using Xunit;

namespace Hrimsoft.Core.Tests.Extensions;

public class DictionaryExtensionTests
{
    private readonly Dictionary<string, string> _dict = new();
    
    [Fact]
    public void Given_Null_Dictionary_Throws_ArgumentNullException()
    {
        Dictionary<string, string> dict = null;
        var ex =Assert.Throws<ArgumentNullException>(() => dict.GetValue("key", ""));
        ex.ParamName.Should().Be("dictionary");
    }
    
    [Fact]
    public void Given_Empty_Dictionary_Returns_Default_Value()
    {
        var expected = "default value";
        var actual = _dict.GetValue("key", expected);
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void Given_Existed_Value_Returns_It()
    {
        var expected = "existed value";
        _dict.Add("key", expected);
        var actual   = _dict.GetValue("key", "default value");
        actual.Should().Be(expected);
    }
}