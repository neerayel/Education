using System;

namespace Lab_7_1
{
    public class Vector3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }

        public Vector3(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Vector3 operator +(Vector3 vector1, Vector3 vector2)
        {
            return new Vector3(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);
        }

        public static Vector3 operator *(Vector3 vector, int multiplier)
        {
            return new Vector3(vector.X * (double)multiplier, vector.Y * (double)multiplier, vector.Z * (double)multiplier);
        }

        public static Vector3 operator *(Vector3 vector, float multiplier)
        {
            return new Vector3(vector.X * (double)multiplier, vector.Y * (double)multiplier, vector.Z * (double)multiplier);
        }

        public static Vector3 operator *(Vector3 vector, double multiplier)
        {
            return new Vector3(vector.X * multiplier, vector.Y * multiplier, vector.Z * multiplier);
        }

        public double Length()
        {
            return Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
        }
    }
}
