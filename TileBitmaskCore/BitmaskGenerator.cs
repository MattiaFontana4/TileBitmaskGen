﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileBitmaskCore
{
    public class BitmaskGenerator
    {
        private string[] tileNames;
        private string _defaultTileName; // Default tile name if no rules match
        private int[] tileBitmasks = new int[256]; // 256 possible bitmask combinations (2^8)
        
        private List<TileRule> _rules;

        private const int BitmaskSize = 8; // 8 bits for 8 directions
        private const int topbit = 1 << 0; // 00000001
        private const int topLeftbit = 1 << 1; // 00000010
        private const int leftbit = 1 << 2; // 00000100
        private const int bottomLeftbit = 1 << 3; // 00001000
        private const int bottombit = 1 << 4; // 00010000
        private const int bottomRightbit = 1 << 5; // 00100000
        private const int rightbit = 1 << 6; // 01000000
        private const int topRightbit = 1 << 7; // 10000000

        public BitmaskGenerator( )
        {
            _rules = new List<TileRule>( );
        }

        public BitmaskGenerator(string defaultTileName)
        {
            _rules = new List<TileRule>( );
            this._defaultTileName = defaultTileName;
        }

        public BitmaskGenerator(List<TileRule> ruleList, string defaultTileName)
        {
            if (ruleList == null)
            {
                throw new ArgumentNullException(nameof(ruleList), "Rule list cannot be null.");
            }
            if (ruleList.Count == 0)
            {
                throw new ArgumentException("Rule list cannot be empty.", nameof(ruleList));
            }
            if ( string.IsNullOrEmpty(defaultTileName) )
            {
                throw new ArgumentNullException(nameof(defaultTileName), "Default tile name cannot be null.");
            }

            _rules = ruleList;
            _defaultTileName = defaultTileName;
            
            List<string> ruleNames = new List<string>( );
            ruleNames.Add( _defaultTileName );
            ruleNames.AddRange( _rules.Select( r => r.Name ) );
            tileNames = ruleNames.ToArray( );

            GenerateBitmasks( );
        }

        private void GenerateBitmasks( )
        {
            for (int i = 0 ; i < 256 ; i++)
            {
                int bitmask = 0;
                bool top = (i & topbit) != 0;
                bool topLeft = (i & topLeftbit) != 0;
                bool left = (i & leftbit) != 0;
                bool bottomLeft = (i & bottomLeftbit) != 0;
                bool bottom = (i & bottombit) != 0;
                bool bottomRight = (i & bottomRightbit) != 0;
                bool right = (i & rightbit) != 0;
                bool topRight = (i & topRightbit) != 0;

                int matchingRuleIndex = _rules.FindIndex(rule =>
                    rule.Check(top, topLeft, left, bottomLeft, bottom, bottomRight, right, topRight)
                );
                bitmask = matchingRuleIndex >= 0 ? matchingRuleIndex+1 : 0;

                //for (int k = 0 ; k < _rules.Count ; k++)
                //{
                //    var rule = _rules[k];
                //    if (rule.Check(top, topLeft, left, bottomLeft, bottom, bottomRight, right, topRight))
                //    {
                //        bitmask = k; // Combine the bitmask of the matching rule
                //        break; // Stop at the first matching rule
                //    }
                //}

                tileBitmasks[i] = bitmask;
            }
        }

        public int[] GetTileBitmasks( )
        {
            if (tileNames == null || tileNames.Length == 0)
            {
                throw new InvalidOperationException("Tile names are not initialized. Please set the rules first.");
            }
            if (tileBitmasks == null || tileBitmasks.Length == 0)
            {
                throw new InvalidOperationException("Tile bitmasks are not initialized. Please set the rules first.");
            }

            GenerateBitmasks( );
            return tileBitmasks;
        }

        public string[] GetTileNames( )
        {
            if (tileNames == null || tileNames.Length == 0)
            {
                throw new InvalidOperationException("Tile names are not initialized. Please set the rules first.");
            }
            return tileNames;
        }

        public void SetRules(List<TileRule> rules, string defaultName)
        {
            if (rules == null || rules.Count == 0)
            {
                throw new ArgumentException("Rules cannot be null or empty.", nameof(rules));
            }
            if (string.IsNullOrEmpty(defaultName))
            {
                throw new ArgumentNullException(nameof(defaultName), "Default tile name cannot be null or empty.");
            }
            _defaultTileName = defaultName;
            _rules = rules;
            tileNames = _rules.Select(r => r.Name).ToArray( );
            GenerateBitmasks( ); // Regenerate bitmasks when rules are set

        }

        public int GetTileCount
        {
            get
            {
                return GetTileCountInternal( );
            } 
        }
        
        private int GetTileCountInternal( )
        {
            if (tileNames == null || tileNames.Length == 0)
            {
                throw new InvalidOperationException("Tile names are not initialized. Please set the rules first.");
            }
            return tileNames.Length;
        }

    }

}
