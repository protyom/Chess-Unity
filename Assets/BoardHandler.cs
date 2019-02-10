using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class BoardHandler{
        public static Vector3 toWorldPos(int x,int y) {
            return new Vector3(-3.0f + x * 0.86f,0.62f,-3.5f + y*0.86f);
        }

        public static Vector3 toWorldPos(Vector2Int pos) {
            return new Vector3(-3.0f + pos.x * 0.86f, 0.62f, -3.5f + pos.y * 0.86f);
        }

        public static Vector2Int toGamePos(Vector3 pos) {
            return new Vector2Int(Convert.ToInt32((pos.x + 3.0f)/0.86f),Convert.ToInt32(Math.Floor((pos.z + 3.5f) / 0.86f)));
        }
    }
}
