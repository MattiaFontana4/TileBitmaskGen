using NUnit.Framework;
using TileBitmaskCore;
using System.Collections.Generic;

namespace TestProject
{
    public class BitmaskGeneratorTests
    {
        private BitmaskGenerator _generator;

        [SetUp]
        public void Setup()
        {
            var rules = new List<TileRule>
            {
                new TileRule("isolated",
                    TileAdjacencyRule.None,
                    TileAdjacencyRule.None,
                    TileAdjacencyRule.None,
                    TileAdjacencyRule.None,
                    TileAdjacencyRule.None,
                    TileAdjacencyRule.None,
                    TileAdjacencyRule.None,
                    TileAdjacencyRule.None),
                new TileRule("top",
                    TileAdjacencyRule.Same,
                    TileAdjacencyRule.Any,
                    TileAdjacencyRule.Any,
                    TileAdjacencyRule.Any,
                    TileAdjacencyRule.Any,
                    TileAdjacencyRule.Any,
                    TileAdjacencyRule.Any,
                    TileAdjacencyRule.Any)
            };

            _generator = new BitmaskGenerator(rules, "default");
        }

        [Test]
        public void GetTileNames_ReturnsDefaultAndRuleNames()
        {
            var names = _generator.GetTileNames();
            var expected = new[] {"default", "isolated", "top"};
            Assert.AreEqual(expected, names);
        }

        [Test]
        public void GetTileBitmasks_GeneratesExpectedValues()
        {
            var bitmasks = _generator.GetTileBitmasks();
            Assert.AreEqual(256, bitmasks.Length);

            // No neighbours -> isolated rule
            Assert.AreEqual(1, bitmasks[0]);

            // Top neighbour present -> top rule
            Assert.AreEqual(2, bitmasks[1]); // top only
            Assert.AreEqual(2, bitmasks[65]); // top + right
            Assert.AreEqual(2, bitmasks[255]); // all neighbours

            // Left neighbour only -> default rule
            Assert.AreEqual(0, bitmasks[4]);
        }
    }
}
