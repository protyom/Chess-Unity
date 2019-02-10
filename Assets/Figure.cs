using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets {
    public enum Team {
        WHITE, BLACK
    }
    public enum TypeFigure {
        Pawn = 10,Knight = 30, Bishop = 40, Rook = 50, Queen = 90, King = 900
    }

    public class Figure : MonoBehaviour {

        private Team team_;
        private TypeFigure typeFigure;
        private Vector2Int[] moves_;
        private Vector2Int[] vectorMoves_;
        private Vector2Int[] attackMoves_;
        private bool wasMoved;

        public Team team {
            get {
                return team_;
            }
            set {
                team_ = value;
            }
        }

        public TypeFigure Type {
            get {
                return typeFigure;
            }
            set {
                typeFigure = value;
            }
        }

        public Vector2Int[] Moves {
            get {
                return moves_;
            }
            set {
                moves_ = value;
            }
        }

        public Vector2Int[] VectorMoves {
            get {
                return vectorMoves_;
            }
            set {
                vectorMoves_ = value;
            }
        }

        public Vector2Int[] AttackMoves {
            get {
                return attackMoves_;
            }
            set {
                attackMoves_ = value;
            }
        }

        public bool WasMoved {
            get {
                return wasMoved;
            }
            set {
                wasMoved = value;
            }
        }

        // Start is called before the first frame update
         void Start(){

            wasMoved = false;
         }

        /*  // Update is called once per frame
          void Update(){

          }*/
    }
}
