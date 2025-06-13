using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileBitmaskGen
{
    internal class TileRule
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public TileAdjacencyRule Top
        {
            get => top;
            set => top = value;
        }
        public TileAdjacencyRule TopLeft
        {
            get => topLeft;
            set => topLeft = value;
        }
        public TileAdjacencyRule Left
        {
            get => left;
            set => left = value;
        }
        public TileAdjacencyRule BottomLeft
        {
            get => bottomLeft;
            set => bottomLeft = value;
        }
        public TileAdjacencyRule Bottom
        {
            get => bottom;
            set => bottom = value;
        }
        public TileAdjacencyRule BottomRight
        {
            get => bottomRight;
            set => bottomRight = value;
        }
        public TileAdjacencyRule Right
        {
            get => right;
            set => right = value;
        }
        public TileAdjacencyRule TopRight
        {
            get => topRight;
            set => topRight = value;
        }

        private TileAdjacencyRule top;
        private TileAdjacencyRule topLeft;
        private TileAdjacencyRule left;
        private TileAdjacencyRule bottomLeft;
        private TileAdjacencyRule bottom;
        private TileAdjacencyRule bottomRight;
        private TileAdjacencyRule right;
        private TileAdjacencyRule topRight;

        public TileRule(string name, TileAdjacencyRule top, TileAdjacencyRule topLeft, TileAdjacencyRule left, TileAdjacencyRule bottomLeft, TileAdjacencyRule bottom, TileAdjacencyRule bottomRight, TileAdjacencyRule right, TileAdjacencyRule topRight)
        {
            _name = name;
            this.top = top;
            this.topLeft = topLeft;
            this.left = left;
            this.bottomLeft = bottomLeft;
            this.bottom = bottom;
            this.bottomRight = bottomRight;
            this.right = right;
            this.topRight = topRight;
        }

        public bool Check(bool top, bool topLeft, bool left, bool bottomLeft, bool bottom, bool bottomRight, bool right, bool topRight)
        {
            return CheckTile(top, this.top) &&
                   CheckTile(topLeft, this.topLeft) &&
                   CheckTile(left, this.left) &&
                   CheckTile(bottomLeft, this.bottomLeft) &&
                   CheckTile(bottom, this.bottom) &&
                   CheckTile(bottomRight, this.bottomRight) &&
                   CheckTile(right, this.right) &&
                   CheckTile(topRight, this.topRight);
        }

        private bool CheckTile(bool b, TileAdjacencyRule rule)
        {
            bool result = false;

            switch (rule)
            {
                case TileAdjacencyRule.Any:
                    result = true; // Matches any tile
                    break;
                case TileAdjacencyRule.None:
                    result = !b; // Matches no tiles
                    break;
                case TileAdjacencyRule.Same:
                    result = b; // Matches tiles of the same type
                    break;
            }

            return result;
        }
    }


    internal enum TileAdjacencyRule
    {
        Any = 0, // Matches any tile
        None = 1, // Matches no tiles
        Same = 2, // Matches tiles of the same type
    }
}
