using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGenerator.src
{
    /// <summary>
    /// A point in 3d space.
    /// </summary>
    public class Vector3
    {

        float x, y, z;


        public float X
        {
            get
            {
                return x;
            }
        }

        public float Y
        {
            get
            {
                return y;
            }
        }

        public float Z
        {
            get
            {
                return z;
            }
        }

        public Vector3(Vector3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3 operator + (Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y,v1.z + v2.z);
        }

        public static Vector3 operator - (Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3 operator * (Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

        public static Vector3 operator / (Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        }

        public static Vector3 operator + (Vector3 v1, float f)
        {
            return new Vector3(v1.x + f, v1.y + f, v1.z + f);
        }

        public static Vector3 operator - (Vector3 v1, float f)
        {
            return new Vector3(v1.x - f, v1.y - f, v1.z - f);
        }

        public static Vector3 operator * (Vector3 v1, float f)
        {
            return new Vector3(v1.x * f, v1.y * f, v1.z * f);
        }

        public static Vector3 operator / (Vector3 v, float f)
        {
            return new Vector3(v.x / f, v.y / f, v.z / f);
        }

        public static Vector3 Normalize(Vector3 v)
        {
            float length = (float)Math.Sqrt((v.x * v.x) + (v.y * v.y) + (v.z * v.z));

            return new Vector3(v) / length;
        }

        public static Vector3 Normalize(Vector3 v1, Vector3 v2)
        {
            Vector3 res = v1 - v2;

            return res.Normalized;
        }

        public static float Distance(Vector3 v1, Vector3 v2)
        {
            return (float)Math.Sqrt(Math.Pow(v1.x - v2.x, 2) + Math.Pow(v1.y - v2.y, 2) + Math.Pow(v1.z - v2.z, 2));
        }

        public Vector3 Normalized
        {
            get
            {
                return Vector3.Normalize(this);
            }
        }
        /// <summary>
        /// Rotates a Vector3 around Y X Z in that order.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="rot"></param>
        /// <returns></returns>
        public static Vector3 Rotate(Vector3 pos, Vector3 rot)
        {
            //Rotate around Y first. Then X then Z
            //manip X Z first, then Y Z then Y X
            Vector3 result = new Vector3(pos);
            float x, y, z;
            rot.x *= ((float)Math.PI / 180f);
            rot.y *= ((float)Math.PI / 180f);
            rot.z *= ((float)Math.PI / 180f);

            x = result.x;
            y = result.y;
            z = result.z;

            //Rotate around Y
            x = (float)(result.x * Math.Cos(rot.y) - result.z * Math.Sin(rot.y));
            z = (float)(result.z * Math.Cos(rot.y) + result.x * Math.Sin(rot.y));
            result.x = x;
            result.z = z;
            //Rotate around X
            y = (float)(result.y * Math.Cos(rot.x) - result.z * Math.Sin(rot.x));
            z = (float)(result.z * Math.Cos(rot.x) + result.y * Math.Sin(rot.x));
            result.y = y;
            result.z = z;
            //Rotate around Z
            x = (float)(result.x * Math.Cos(rot.z) - result.y * Math.Sin(rot.z));
            y = (float)(result.y * Math.Cos(rot.z) + result.x * Math.Sin(rot.z));
            result.y = y;
            result.x = x;
            return result;
        }
        public override string ToString()
        {
            return $"({x}|{y}|{z})";
        }
    }
}
