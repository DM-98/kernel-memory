﻿// Copyright (c) Microsoft. All rights reserved.

using System.Text.Json;
using Microsoft.KernelMemory.MemoryDb.Qdrant.Client.Http;
using UnitTests.TestHelpers;
using Xunit.Abstractions;

namespace UnitTests.MemoryStorage.Qdrant.Client.Http;

public class ScrollVectorsRequestTest : BaseTestCase
{
    public ScrollVectorsRequestTest(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    [Trait("Category", "UnitTest")]
    public void FiltersAreRenderedToJson()
    {
        const string Expected = """
                                {
                                    "filter":
                                    {
                                        "must":
                                        [
                                            {
                                                "key": "tags",
                                                "match":
                                                {
                                                    "value": "user:devis"
                                                }
                                            },
                                            {
                                                "key": "tags",
                                                "match":
                                                {
                                                    "value": "type:blog"
                                                }
                                            },
                                            {
                                                "should":
                                                [
                                                    {
                                                        "must":
                                                        [
                                                            {
                                                                "key": "tags",
                                                                "match":
                                                                {
                                                                    "value": "month:january"
                                                                }
                                                            },
                                                            {
                                                                "key": "tags",
                                                                "match":
                                                                {
                                                                    "value": "year:2000"
                                                                }
                                                            }
                                                        ]
                                                    },
                                                    {
                                                        "must":
                                                        [
                                                            {
                                                                "key": "tags",
                                                                "match":
                                                                {
                                                                    "value": "month:july"
                                                                }
                                                            },
                                                            {
                                                                "key": "tags",
                                                                "match":
                                                                {
                                                                    "value": "year:2003"
                                                                }
                                                            }
                                                        ]
                                                    }
                                                ]
                                            }
                                        ]
                                    },
                                    "limit": 1,
                                    "offset": 0,
                                    "with_payload": false,
                                    "with_vector": false
                                }
                                """;
        // Arrange
        var request = ScrollVectorsRequest
            .Create("coll")
            .HavingAllTags(new[] { "user:devis", "type:blog" })
            .HavingSomeTags(new[]
            {
                new[] { "month:january", "year:2000" },
                new[] { "month:july", "year:2003" },
            });

        // Act
        var actual = JsonSerializer.Serialize(request);

        // Assert
        var expected = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(Expected));
        Assert.Equal(expected, actual);
    }

    [Fact]
    [Trait("Category", "UnitTest")]
    public void ItRendersOptimizedConditions()
    {
        const string Expected = """
                                {
                                    "filter":
                                    {
                                        "must":
                                        [
                                            {
                                                "key": "tags",
                                                "match":
                                                {
                                                    "value": "user:devis"
                                                }
                                            },
                                            {
                                                "key": "tags",
                                                "match":
                                                {
                                                    "value": "type:blog"
                                                }
                                            },
                                            {
                                                "key": "tags",
                                                "match":
                                                {
                                                    "value": "month:january"
                                                }
                                            },
                                            {
                                                "key": "tags",
                                                "match":
                                                {
                                                    "value": "year:2000"
                                                }
                                            }
                                        ]
                                    },
                                    "limit": 1,
                                    "offset": 0,
                                    "with_payload": false,
                                    "with_vector": false
                                }
                                """;
        // Arrange
        var request = ScrollVectorsRequest
            .Create("coll")
            .HavingAllTags(new[] { "user:devis", "type:blog" })
            .HavingSomeTags(new[] { new[] { "month:january", "year:2000" } });

        // Act
        var actual = JsonSerializer.Serialize(request);

        // Assert
        var expected = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(Expected));
        Assert.Equal(expected, actual);
    }
}
