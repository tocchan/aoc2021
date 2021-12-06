using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public struct ivec2
    {
        public int x = 0; 
        public int y = 0;

        public static readonly ivec2 ZERO = new ivec2(0, 0); 
        public static readonly ivec2 ONE = new ivec2(1, 1); 


        public ivec2( int v )
        {
            x = v; 
            y = v; 
        }

        public ivec2( int xv, int yv )
        {
            x = xv; 
            y = yv; 
        }

        public int Dot( ivec2 v ) => x * v.x + y * v.y; 
        public int GetLengthSquared() => x * x + y * y; 
        public float GetLength() => MathF.Sqrt( (float) GetLengthSquared() ); 

        public static ivec2 operator +( ivec2 v ) => v; 
        public static ivec2 operator -( ivec2 v ) => new ivec2( -v.x, -v.y ); 
        public static ivec2 operator +( ivec2 a, ivec2 b ) => new ivec2( a.x + b.x, a.y + b.y ); 
        public static ivec2 operator -( ivec2 a, ivec2 b ) => new ivec2( a.x - b.x, a.y - b.y ); 
        public static ivec2 operator *( ivec2 a, ivec2 b ) => new ivec2( a.x * b.x, a.y * b.y ); 
        public static ivec2 operator *( int a, ivec2 v ) => new ivec2( a * v.x, a * v.y ); 
        public static ivec2 operator *( ivec2 v, int a ) => new ivec2( a * v.x, a * v.y ); 
        public static bool operator ==( ivec2 a, ivec2 b ) => (a.x == b.x) && (a.y == b.y); 
        public static bool operator !=( ivec2 a, ivec2 b ) => (a.x != b.x) || (a.y != b.y); 
        public static bool operator < ( ivec2 a, ivec2 b ) => (a.x < b.x) && (a.y < b.y); 
        public static bool operator <=( ivec2 a, ivec2 b ) => (a.x <= b.x) && (a.y <= b.y); 
        public static bool operator > ( ivec2 a, ivec2 b ) => (a.x > b.x) && (a.y > b.y); 
        public static bool operator >=( ivec2 a, ivec2 b ) => (a.x >= b.x) && (a.y >= b.y); 

        public static ivec2 Sign( ivec2 v ) => new ivec2( Math.Sign(v.x), Math.Sign(v.y) ); 
        public static ivec2 Min( ivec2 a, ivec2 b ) => new ivec2( Math.Min(a.x, b.x), Math.Min(a.y, b.y) ); 
        public static ivec2 Max( ivec2 a, ivec2 b ) => new ivec2( Math.Max(a.x, b.x), Math.Max(a.y, b.y) ); 

        public static int Dot( ivec2 a, ivec2 b ) => a.x * b.x + a.y * b.y; 

        public static ivec2 Parse( string s )
        {
            string[] parts = s.Split(',', 2); 
            int x = int.Parse(parts[0]); 
            int y = int.Parse(parts[1]); 
            return new ivec2( x, y );  
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if ((obj == null) || !obj.GetType().Equals(GetType()))
            {
                return false; 
            }

            ivec2 other = (ivec2) obj; 
            return (x == other.x) && (y == other.y); 
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{x},{y}"; 
        }
    }
}
