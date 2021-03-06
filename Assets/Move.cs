﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets {
    public class Move {
        private GameObject moved;
        private GameObject beaten;
        private Vector2Int oldPoint;
        private Vector2Int endPoint;
        private bool isFirstTimeMoved;
        public Move(GameObject moved, GameObject beaten, Vector2Int oldPoint, Vector2Int endPoint,bool isFirstTimeMoved) {
            this.moved = moved;
            this.beaten = beaten;
            this.oldPoint = oldPoint;
            this.endPoint = endPoint;
            this.isFirstTimeMoved = isFirstTimeMoved;
        }

        public GameObject Moved {
            get{
                return moved;
            }
        }

        public GameObject Beaten {
            get {
                return beaten;
            }
        }

        public Vector2Int OldPoint {
            get {
                return oldPoint;
            }
        }

        public Vector2Int EndPoint {
            get {
                return endPoint;
            }
        }

        public bool IsFirstTimeMoved {
            get {
                return isFirstTimeMoved;
            }
        }

        public GameObject getMoved() {
            return moved;
        }

        public GameObject getBeaten() {
            return beaten;
        }

        public Vector2Int getEndPoint() {
            return endPoint;
        }

        public Vector2Int getOldPoint() {
            return oldPoint;
        }
    }
}
