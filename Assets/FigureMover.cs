using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets {
    class FigureMover {
        public static Vector2Int[] getWhitePawnVectorMoves() {
            return new Vector2Int[] {
                new Vector2Int (0,2)
            };
        }
        public static Vector2Int[] getBlackPawnVectorMoves() {
            return new Vector2Int[] {
                new Vector2Int (0,-2)
            };
        }

        public static Vector2Int[] getWhitePawnAttackMoves() {
            return new Vector2Int[] {
                new Vector2Int (1,1),
                new Vector2Int (-1,1),
            };
        }
        public static Vector2Int[] getBlackPawnAttackMoves() {
            return new Vector2Int[] {
                new Vector2Int (1,-1),
                new Vector2Int (-1,-1),
            };
        }

        public static Vector2Int[] getRookVectorMoves() {

            return new Vector2Int[] {
                new Vector2Int(8,0),
                new Vector2Int(-8, 0),
                new Vector2Int(0, 8),
                new Vector2Int(0, -8)
            };
        }

        public static Vector2Int[] getBishopVectorMoves() {
            return new Vector2Int[] {
                new Vector2Int(8, 8),
                new Vector2Int(-8, 8),
                new Vector2Int(8, -8),
                new Vector2Int(-8, -8)
            };
        }
        public static Vector2Int[] getKnightMoves() {
            return new Vector2Int[] {
                new Vector2Int(1,2),
                new Vector2Int(-1,2),
                new Vector2Int (1,-2),
                new Vector2Int (-1,-2),

                new Vector2Int (2,1),
                new Vector2Int(2,-1),
                new Vector2Int (-2,1),
                new Vector2Int(-2,-1),

            };
        }
        public static Vector2Int[] getQueenVectorMoves() {
            return new Vector2Int[] {
                new Vector2Int(8, 8),
                new Vector2Int(-8, 8),
                new Vector2Int(8, -8),
                new Vector2Int(-8, -8),
                new Vector2Int(8,0),
                new Vector2Int(-8, 0),
                new Vector2Int(0, 8),
                new Vector2Int(0, -8)
            };
        }
        public static Vector2Int[] getKingMoves() {
            return new Vector2Int[] {
                new Vector2Int(0,1),
                new Vector2Int(1,1),
                new Vector2Int (1,0),
                new Vector2Int (1,-1),

                new Vector2Int (0,-1),
                new Vector2Int(-1,-1),
                new Vector2Int (-1,0),
                new Vector2Int(-1,1),

            };
        }
    }
}
