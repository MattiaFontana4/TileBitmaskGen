using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileBitmaskGen
{
    internal class TileBitmaskStringGenerator
    {

        private int[] _bitmask;
        private string[] _tileNames;
        public TileBitmaskStringGenerator(int[] bitmask, string[] tileNames)
        {
            _bitmask = bitmask ?? throw new ArgumentNullException(nameof(bitmask), "Bitmask cannot be null.");
            _tileNames = tileNames ?? throw new ArgumentNullException(nameof(tileNames), "Tile names cannot be null.");
        }

        public StringBuilder GenerateBitmaskStringBuilderCSharp( )
        {
            if(_bitmask == null || _tileNames == null || _tileNames.Length == 0)
            {
                throw new InvalidOperationException("Bitmask or tile names are not properly initialized.");
            }
            int[] bitmask = new int[256];
            bitmask[0] = 1;

            StringBuilder sb = new StringBuilder( );
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine();
            sb.AppendLine("namespace TileBitmask");
            sb.AppendLine("{");
            sb.AppendLine("    internal class TileBitmask");
            sb.AppendLine("    {");

            // Generating the getTileBitmask method
            sb.AppendLine("         public int[] getTileBitmask()");
            sb.AppendLine("         {");
            sb.AppendLine("         int[] bitmask = new int[256];");

            // Generate the bitmask string
            for (int i = 0; i < _bitmask.Length; i++)
            {
                sb.AppendLine("         bitmask[" + i.ToString( ) + "] = " + bitmask[i].ToString( ) + ";");
            }
            sb.AppendLine("         return bitmask;");
            sb.AppendLine("         }");
            sb.AppendLine( );


            // Generating the getTileNames method
            sb.AppendLine("         public string[] getTileNames()");
            sb.AppendLine("         {");
            sb.AppendLine("         string[] tileNames = new string[" + _tileNames.Count() + "];");

            for (int i = 0 ; i < _bitmask.Length ; i++)
            {
                sb.AppendLine("         tileNames[" + i.ToString( ) + "] = " + _tileNames[i].ToString( ) + ";");
            }

            sb.AppendLine("         return tileNames;");
            sb.AppendLine("         }");

            sb.AppendLine( );

            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;
        }

        public string GenerateBitmaskStringCSharp( )
        {
            StringBuilder sb = GenerateBitmaskStringBuilderCSharp( );
            return sb.ToString( );
        }


        public StringBuilder GenerateBitmaskStringBuilderJava( )
        {
            if (_bitmask == null || _tileNames == null || _tileNames.Length == 0)
            {
                throw new InvalidOperationException("Bitmask or tile names are not properly initialized.");
            }

            StringBuilder sb = new StringBuilder( );
            sb.AppendLine("package tilebitmask;");
            sb.AppendLine( );
            sb.AppendLine("public class TileBitmask {");
            sb.AppendLine( );

            // Metodo per ottenere il bitmask
            sb.AppendLine("    public static int[] getTileBitmask() {");
            sb.AppendLine("        int[] bitmask = new int[256];");
            for (int i = 0 ; i < _bitmask.Length ; i++)
            {
                sb.AppendLine($"        bitmask[{i}] = {_bitmask[i]};");
            }
            sb.AppendLine("        return bitmask;");
            sb.AppendLine("    }");
            sb.AppendLine( );

            // Metodo per ottenere i nomi delle tile
            sb.AppendLine("    public static String[] getTileNames() {");
            sb.AppendLine($"        String[] tileNames = new String[{_tileNames.Length}];");
            for (int i = 0 ; i < _tileNames.Length ; i++)
            {
                sb.AppendLine($"        tileNames[{i}] = \"{_tileNames[i]}\";");
            }
            sb.AppendLine("        return tileNames;");
            sb.AppendLine("    }");
            sb.AppendLine( );

            sb.AppendLine("}");

            return sb;
        }


    }
}
