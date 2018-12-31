using System.Collections.Generic;
using Game.DAO;

namespace Game.SpecialMath
{
    public class Position
    {
        public Position()
        {
            X = 65535;
            Y = 65535;
            Z = 255;
        }

        public static Position Zero = new Position(0, 0, 0);

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }

        public Size ToSize()
        {
            return new Size(X, Y);
        }
        public Position(Position pos)
        {
            X = pos.X;
            Y = pos.Y;
            Z = pos.Z;
        }

        public Position(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = (short) z;
        }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Z = 0;
        }

        public Position TranslatedToDirection(Direction direction)
        {
            Position pos = this;
            switch (direction)
            {
                case Direction.North:
                    pos.Y--;
                    break;
                case Direction.East:
                    pos.X++;
                    break;
                case Direction.South:
                    pos.Y++;
                    break;
                case Direction.West:
                    pos.X--;
                    break;
                case Direction.NorthEast:
                    pos.X++;
                    pos.Y--;
                    break;
                case Direction.SouthEast:
                    pos.X++;
                    pos.Y++;
                    break;
                case Direction.SouthWest:
                    pos.X--;
                    pos.Y++;
                    break;
                case Direction.NorthWest:
                    pos.X--;
                    pos.Y--;
                    break;
                default:
                    break;
            }
            return pos;
        }

        public Position TranslatedToReverseDirection(Direction direction)
        {
            Position pos = this;
            switch (direction)
            {
                case Direction.North:
                    pos.Y++;
                    break;
                case Direction.East:
                    pos.X--;
                    break;
                case Direction.South:
                    pos.Y--;
                    break;
                case Direction.West:
                    pos.X++;
                    break;
                case Direction.NorthEast:
                    pos.X--;
                    pos.Y++;
                    break;
                case Direction.SouthEast:
                    pos.X--;
                    pos.Y--;
                    break;
                case Direction.SouthWest:
                    pos.X++;
                    pos.Y--;
                    break;
                case Direction.NorthWest:
                    pos.X++;
                    pos.Y++;
                    break;
                default:
                    break;
            }
            return pos;
        }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ClassicVector<Position> translatedToDirections(const ClassicVector<Otc::Direction>& dirs) const
        public List<Position> TranslatedToDirections(List<Direction> dirs)
        {
            Position lastPos = this;
            List<Position> positions = new List<Position>();

            if (!lastPos.IsValid())
                return positions;

            positions.Add(lastPos);

            foreach (var dir in dirs)
            {
                lastPos = lastPos.TranslatedToDirection(dir);
                if (!lastPos.IsValid())
                    break;
                positions.Add(lastPos);
            }

            return positions;
        }




//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool isMapPosition() const
        public bool IsMapPosition()
        {
            return (X >= 0 && Y >= 0 && Z >= 0 && X < 65535 && Y < 65535 && Z <= (float) AnonymousEnum12.MAX_Z);
        }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool isValid() const
        public bool IsValid()
        {
            return !(X == 65535 && Y == 65535 && Z == 255);
        }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C

        public void Translate(int dx, int dy)
        {
            Translate(dx, dy, 0);
        }

//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: void translate(int dx, int dy, short dz = 0)
        public void Translate(int dx, int dy, short dz)
        {
            X += dx;
            Y += dy;
            Z += dz;
        }

        public Position Translated(int dx, int dy)
        {
            return Translated(dx, dy, 0);
        }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Position translated(int dx, int dy, short dz = 0) const
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
        public Position Translated(int dx, int dy, short dz)
        {
            Position pos = this;
            pos.X += dx;
            pos.Y += dy;
            pos.Z += dz;
            return pos;
        }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Position operator +(const Position& other) const
        public static Position operator +(Position impliedObject, Position other)
        {
            return new Position(impliedObject.X + other.X, impliedObject.Y + other.Y, impliedObject.Z + other.Z);
        }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Position operator -(const Position& other) const
        public static Position operator -(Position impliedObject, Position other)
        {
            return new Position(impliedObject.X - other.X, impliedObject.Y - other.Y, impliedObject.Z - other.Z);
        }

        public static Position operator -(Position impliedObject, int other)
        {
            return new Position(impliedObject.X - other, impliedObject.Y - other, impliedObject.Z - other);
        }

        public static Position operator *(Position impliedObject, int other)
        {
            return new Position(impliedObject.X * other, impliedObject.Y * other, impliedObject.Z * other);
        }

        public static Position operator /(Position impliedObject, int other)
        {
            return new Position(impliedObject.X / other, impliedObject.Y / other, impliedObject.Z / other);
        }

//C++ TO C# CONVERTER NOTE: This 'CopyFrom' method was converted from the original C++ copy assignment operator:
//ORIGINAL LINE: Position& operator =(const Position& other)
        public Position CopyFrom(Position other)
        {
            X = other.X;
            Y = other.Y;
            Z = other.Z;
            return this;
        }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator ==(const Position& other) const
	public static bool operator ==(Position impliedObject, Position other)
	{
	    if (Equals(other, null) || Equals(impliedObject, null))
	    {
	        return false;
	    }
	    return other.X == impliedObject.X && other.Y == impliedObject.Y && other.Z == impliedObject.Z;
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator !=(const Position& other) const
	public static bool operator !=(Position impliedObject, Position other)
	{
	    if (Equals(other, null) && Equals(impliedObject, null))
	    {
	        return false;
	    }
	    if (Equals(other, null) && !Equals(impliedObject, null))
	    {
	        return true;
	    }
		return other.X!=impliedObject.X || other.Y!=impliedObject.Y || other.Z!=impliedObject.Z;
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool isInRange(const Position& pos, int minXRange, int maxXRange, int minYRange, int maxYRange) const
        public bool IsInRange(Position pos, int minXRange, int maxXRange, int minYRange, int maxYRange)
        {
            return (pos.X >= X - minXRange && pos.X <= X + maxXRange && pos.Y >= Y - minYRange &&
                    pos.Y <= Y + maxYRange && pos.Z == Z);
        }

        // operator less than for std::map
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator <(const Position& other) const
        public static bool operator <(Position impliedObject, Position other)
        {
            return impliedObject.X < other.X || impliedObject.Y < other.Y || impliedObject.Z < other.Z;
        }

        public static bool operator >(Position impliedObject, Position other)
        {
            return impliedObject.X > other.X || impliedObject.Y > other.Y || impliedObject.Z > other.Z;
        }

        public bool Up()
        {
            return Up(1);
        }

//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: bool up(int n = 1)
        public bool Up(int n)
        {
            int nz = Z - n;
            if (nz >= 0 && nz <= (float) AnonymousEnum12.MAX_Z)
            {
                Z = (short) nz;
                return true;
            }
            return false;
        }

        public bool Down()
        {
            return Down(1);
        }

//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: bool down(int n = 1)
        public bool Down(int n)
        {
            int nz = Z + n;
            if (nz >= 0 && nz <= (float) AnonymousEnum12.MAX_Z)
            {
                Z = (short) nz;
                return true;
            }
            return false;
        }

        public bool CoveredUp()
        {
            return CoveredUp(1);
        }

        public bool CoveredUp(int n)
        {
            int nx = X + n;
            int ny = Y + n;
            int nz = Z - n;
            if (nx >= 0 && nx <= 65535 && ny >= 0 && ny <= 65535 && nz >= 0 && nz <= (float) AnonymousEnum12.MAX_Z)
            {
                X = nx;
                Y = ny;
                Z = (short) nz;
                return true;
            }
            return false;
        }

        public bool CoveredDown()
        {
            return CoveredDown(1);
        }

//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: bool coveredDown(int n = 1)
        public bool CoveredDown(int n)
        {
            int nx = X - n;
            int ny = Y - n;
            int nz = Z + n;
            if (nx >= 0 && nx <= 65535 && ny >= 0 && ny <= 65535 && nz >= 0 && nz <= (float) AnonymousEnum12.MAX_Z)
            {
                X = nx;
                Y = ny;
                Z = (short) nz;
                return true;
            }
            return false;
        }

        public int X;
        public int Y;
        public short Z;

    }
}