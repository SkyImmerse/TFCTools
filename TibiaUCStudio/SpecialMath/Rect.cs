using Game.DAO;

namespace Game.SpecialMath
{
    public class Rect
    {
        public Rect()
        {
            _x1 = 0;
            _y1 = 0;
            _x2 = -1;
            _y2 = -1;
        }
        public Rect(int x, int y, int width, int height)
        {
            _x1 = x;
            _y1 = y;
            _x2 = x+width-1;
            _y2 = y+height-1;
        }
        public Rect(Position topLeft, Position bottomRight)
        {
            _x1 = topLeft.X;
            _y1 = topLeft.Y;
            _x2 = bottomRight.X;
            _y2 = bottomRight.Y;
        }
        public Rect(Rect other)
        {
            _x1 = other._x1;
            _y1 = other._y1;
            _x2 = other._x2;
            _y2 = other._y2;
        }
        public Rect(int x, int y, Size size)
        {
            _x1 = x;
            _y1 = y;
            _x2 = x+size.Width()-1;
            _y2 = y+size.Height()-1;
        }
        public Rect(Position topLeft, Size size)
        {
            _x1 = topLeft.X;
            _y1 = topLeft.Y;
            _x2 = _x1+size.Width()-1;
            _y2 = _y1+size.Height()-1;
        }
        public Rect(Position topLeft, int width, int height)
        {
            _x1 = topLeft.X;
            _y1 = topLeft.Y;
            _x2 = _x1+width-1;
            _y2 = _y1+height-1;
        }


        public bool IsNull()
        {
            return _x2 == _x1 - 1 && _y2 == _y1 - 1;
        }

        public bool IsEmpty()
        {
            return _x1 > _x2 || _y1 > _y2;
        }

        public bool IsValid()
        {
            return _x1 <= _x2 && _y1 <= _y2;
        }


        public int Left()
        {
            return _x1;
        }

        public int Top()
        {
            return _y1;
        }

        public int Right()
        {
            return _x2;
        }

        public int Bottom()
        {
            return _y2;
        }

        public int HorizontalCenter()
        {
            return _x1 + (_x2 - _x1)/2;
        }

        public int VerticalCenter()
        {
            return _y1 + (_y2 - _y1)/2;
        }

        public int X()
        {
            return _x1;
        }

        public int Y()
        {
            return _y1;
        }

        public Position TopLeft()
        {
            return new Position(_x1, _y1);
        }

        public Position BottomRight()
        {
            return new Position(_x2, _y2);
        }

        public Position TopRight()
        {
            return new Position(_x2, _y1);
        }

        public Position BottomLeft()
        {
            return new Position(_x1, _y2);
        }

        public Position TopCenter()
        {
            return new Position((_x1+_x2)/2, _y1);
        }

        public Position BottomCenter()
        {
            return new Position((_x1+_x2)/2, _y2);
        }

        public Position CenterLeft()
        {
            return new Position(_x1, (_y1+_y2)/2);
        }

        public Position CenterRight()
        {
            return new Position(_x2, (_y1+_y2)/2);
        }

        public Position Center()
        {
            return new Position((_x1+_x2)/2, (_y1+_y2)/2);
        }

        public int Width()
        {
            return _x2 - _x1 + 1;
        }

        public int Height()
        {
            return _y2 - _y1 + 1;
        }

        public Size Size()
        {
            return new Size(Width(), Height());
        }
        public void Reset()
        {
            _x1 = _y1 = 0;
            _x2 = _y2 = -1;
        }
        public void Clear()
        {
            _x2 = _x1 - 1;
            _y2 = _y1 - 1;
        }

        public void SetLeft(int pos)
        {
            _x1 = pos;
        }
        public void SetTop(int pos)
        {
            _y1 = pos;
        }
        public void SetRight(int pos)
        {
            _x2 = pos;
        }
        public void SetBottom(int pos)
        {
            _y2 = pos;
        }
        public void SetX(int x)
        {
            _x1 = x;
        }
        public void SetY(int y)
        {
            _y1 = y;
        }
        public void SetTopLeft(Position p)
        {
            _x1 = p.X;
            _y1 = p.Y;
        }
        public void SetBottomRight(Position p)
        {
            _x2 = p.X;
            _y2 = p.Y;
        }
        public void SetTopRight(Position p)
        {
            _x2 = p.X;
            _y1 = p.Y;
        }
        public void SetBottomLeft(Position p)
        {
            _x1 = p.X;
            _y2 = p.Y;
        }
        public void SetWidth(int width)
        {
            _x2 = _x1 + width - 1;
        }
        public void SetHeight(int height)
        {
            _y2 = _y1 + height- 1;
        }
        public void SetSize(Size size)
        {
            _x2 = _x1 + size.Width() - 1;
            _y2 = _y1 + size.Height() - 1;
        }
        public void SetRect(int x, int y, int width, int height)
        {
            _x1 = x;
            _y1 = y;
            _x2 = (x + width - 1);
            _y2 = (y + height - 1);
        }
        public void SetCoords(int left, int top, int right, int bottom)
        {
            _x1 = left;
            _y1 = top;
            _x2 = right;
            _y2 = bottom;
        }

        public void ExpandLeft(int add)
        {
            _x1 -= add;
        }
        public void ExpandTop(int add)
        {
            _y1 -= add;
        }
        public void ExpandRight(int add)
        {
            _x2 += add;
        }
        public void ExpandBottom(int add)
        {
            _y2 += add;
        }
        public void Expand(int top, int right, int bottom, int left)
        {
            _x1 -= left;
            _y1 -= top;
            _x2 += right;
            _y2 += bottom;
        }
        public void Expand(int add)
        {
            _x1 -= add;
            _y1 -= add;
            _x2 += add;
            _y2 += add;
        }

        public void Translate(int x, int y)
        {
            _x1 += x;
            _y1 += y;
            _x2 += x;
            _y2 += y;
        }
        public void Translate(Position p)
        {
            _x1 += p.X;
            _y1 += p.Y;
            _x2 += p.X;
            _y2 += p.Y;
        }
        public void Resize(Size size)
        {
            _x2 = _x1 + size.Width() - 1;
            _y2 = _y1 + size.Height() - 1;
        }
        public void Resize(int width, int height)
        {
            _x2 = _x1 + width - 1;
            _y2 = _y1 + height - 1;
        }
        public void Move(int x, int y)
        {
            _x2 += x - _x1;
            _y2 += y - _y1;
            _x1 = x;
            _y1 = y;
        }
        public void Move(Position p)
        {
            _x2 += p.X - _x1;
            _y2 += p.Y - _y1;
            _x1 = p.X;
            _y1 = p.Y;
        }
        public void MoveLeft(int pos)
        {
            _x2 += (pos - _x1);
            _x1 = pos;
        }
        public void MoveTop(int pos)
        {
            _y2 += (pos - _y1);
            _y1 = pos;
        }
        public void MoveRight(int pos)
        {
            _x1 += (pos - _x2);
            _x2 = pos;
        }
        public void MoveBottom(int pos)
        {
            _y1 += (pos - _y2);
            _y2 = pos;
        }
        public void MoveTopLeft(Position p)
        {
            MoveLeft(p.X);
            MoveTop(p.Y);
        }
        public void MoveBottomRight(Position p)
        {
            MoveRight(p.X);
            MoveBottom(p.Y);
        }
        public void MoveTopRight(Position p)
        {
            MoveRight(p.X);
            MoveTop(p.Y);
        }
        public void MoveBottomLeft(Position p)
        {
            MoveLeft(p.X);
            MoveBottom(p.Y);
        }
        public void MoveTopCenter(Position p)
        {
            MoveHorizontalCenter(p.X);
            MoveTop(p.Y);
        }
        public void MoveBottomCenter(Position p)
        {
            MoveHorizontalCenter(p.X);
            MoveBottom(p.Y);
        }
        public void MoveCenterLeft(Position p)
        {
            MoveLeft(p.X);
            MoveVerticalCenter(p.Y);
        }
        public void MoveCenterRight(Position p)
        {
            MoveRight(p.X);
            MoveVerticalCenter(p.Y);
        }


        public Rect Translated(int x, int y)
        {
            return new Rect(new Position(_x1 + x, _y1 + y), new Position(_x2 + x, _y2 + y));
        }

        public Rect Translated(Position p)
        {
            return new Rect(new Position(_x1 + p.X, _y1 + p.Y), new Position(_x2 + p.X, _y2 + p.Y));
        }


        public Rect Expanded(int add)
        {
            return new Rect(new Position(_x1 - add, _y1 - add), new Position(_x2 + add, _y2 + add));
        }

        public void MoveCenter(Position p)
        {
            int w = _x2 - _x1;
            int h = _y2 - _y1;
            _x1 = p.X - w/2;
            _y1 = p.Y - h/2;
            _x2 = _x1 + w;
            _y2 = _y1 + h;
        }
        public void MoveHorizontalCenter(int x)
        {
            int w = _x2 - _x1;
            _x1 = x - w/2;
            _x2 = _x1 + w;
        }
        public void MoveVerticalCenter(int y)
        {
            int h = _y2 - _y1;
            _y1 = y - h/2;
            _y2 = _y1 + h;
        }

        public bool Contains(Position p)
        {
            return Contains(p, false);
        }

        public bool Contains(Position p, bool insideOnly)
        {
            int l = new int();
            int r = new int();
            if(_x2 < _x1 - 1)
            {
                l = _x2;
                r = _x1;
            }
            else
            {
                l = _x1;
                r = _x2;
            }
            if(insideOnly)
            {
                if(p.X <= l || p.X >= r)
                    return false;
            }
            else
            {
                if(p.X < l || p.X > r)
                    return false;
            }
            int t = new int();
            int b = new int();
            if(_y2 < _y1 - 1)
            {
                t = _y2;
                b = _y1;
            }
            else
            {
                t = _y1;
                b = _y2;
            }
            if(insideOnly)
            {
                if(p.Y <= t || p.Y >= b)
                    return false;
            }
            else
            {
                if(p.Y < t || p.Y > b)
                    return false;
            }
            return true;
        }

        public bool Contains(Rect r)
        {
            return Contains(r, false);
        }

        public bool Contains(Rect r, bool insideOnly)
        {
            if(Contains(r.TopLeft(), insideOnly) && Contains(r.BottomRight(), insideOnly))
                return true;
            return false;
        }


        public bool Intersects(Rect r)
        {
            if(IsNull() || r.IsNull())
                return false;

            int l1 = _x1;
            int r1 = _x1;
            if(_x2 - _x1 + 1 < 0)
                l1 = _x2;
            else
                r1 = _x2;

            int l2 = r._x1;
            int r2 = r._x1;
            if(r._x2 - r._x1 + 1 < 0)
                l2 = r._x2;
            else
                r2 = r._x2;

            if(l1 > r2 || l2 > r1)
                return false;

            int t1 = _y1;
            int b1 = _y1;
            if(_y2 - _y1 + 1 < 0)
                t1 = _y2;
            else
                b1 = _y2;

            int t2 = r._y1;
            int b2 = r._y1;
            if(r._y2 - r._y1 + 1 < 0)
                t2 = r._y2;
            else
                b2 = r._y2;

            if(t1 > b2 || t2 > b1)
                return false;

            return true;
        }


        public Rect United(Rect r)
        {
            Rect tmp = new Rect();
            tmp._x1 = System.Math.Min(_x1, r._x1);
            tmp._x2 = System.Math.Max(_x2, r._x2);
            tmp._y1 = System.Math.Min(_y1, r._y1);
            tmp._y2 = System.Math.Max(_y2, r._y2);
            return tmp;
        }


        public Rect Intersection(Rect r)
        {
            if(IsNull())
                return r;
            if(r.IsNull())
                return this;

            int l1 = _x1;
            int r1 = _x1;
            if(_x2 - _x1 + 1 < 0)
                l1 = _x2;
            else
                r1 = _x2;

            int l2 = r._x1;
            int r2 = r._x1;
            if(r._x2 - r._x1 + 1 < 0)
                l2 = r._x2;
            else
                r2 = r._x2;

            int t1 = _y1;
            int b1 = _y1;
            if(_y2 - _y1 + 1 < 0)
                t1 = _y2;
            else
                b1 = _y2;

            int t2 = r._y1;
            int b2 = r._y1;
            if(r._y2 - r._y1 + 1 < 0)
                t2 = r._y2;
            else
                b2 = r._y2;

            Rect tmp = new Rect();
            tmp._x1 = System.Math.Max(l1, l2);
            tmp._x2 = System.Math.Min(r1, r2);
            tmp._y1 = System.Math.Max(t1, t2);
            tmp._y2 = System.Math.Min(b1, b2);
            return tmp;
        }

        public void Bind(Rect r)
        {
            if(IsNull() || r.IsNull())
                return;

            if(Right() > r.Right())
                MoveRight(r.Right());
            if(Bottom() > r.Bottom())
                MoveBottom(r.Bottom());
            if(Left() < r.Left())
                MoveLeft(r.Left());
            if(Top() < r.Top())
                MoveTop(r.Top());
        }

        public void AlignIn(Rect r, AlignmentFlag align)
        {
            switch (align)
            {
                case AlignmentFlag.AlignTopLeft:
                    MoveTopLeft(r.TopLeft());
                    break;
                case AlignmentFlag.AlignTopRight:
                    MoveTopRight(r.TopRight());
                    break;
                case AlignmentFlag.AlignTopCenter:
                    MoveTopCenter(r.TopCenter());
                    break;
                case AlignmentFlag.AlignBottomLeft:
                    MoveBottomLeft(r.BottomLeft());
                    break;
                case AlignmentFlag.AlignBottomRight:
                    MoveBottomRight(r.BottomRight());
                    break;
                case AlignmentFlag.AlignBottomCenter:
                    MoveBottomCenter(r.BottomCenter());
                    break;
                case AlignmentFlag.AlignLeftCenter:
                    MoveCenterLeft(r.CenterLeft());
                    break;
                case AlignmentFlag.AlignCenter:
                    MoveCenter(r.Center());
                    break;
                case AlignmentFlag.AlignRightCenter:
                    MoveCenterRight(r.CenterRight());
                    break;
            }
        }


        public Rect CopyFrom(Rect other)
        {
            _x1 = other._x1;
            _y1 = other._y1;
            _x2 = other._x2;
            _y2 = other._y2;
            return this;
        }

        public static bool operator ==(Rect impliedObject, Rect other)
        {
            return (impliedObject._x1 == other._x1 && impliedObject._y1 == other._y1 && impliedObject._x2 == other._x2 && impliedObject._y2 == other._y2);
        }

        public static bool operator !=(Rect impliedObject, Rect other)
        {
            return (impliedObject._x1 != other._x1 || impliedObject._y1 != other._y1 || impliedObject._x2 != other._x2 || impliedObject._y2 != other._y2);
        }


        private int _x1 = new int();
        private int _y1 = new int();
        private int _x2 = new int();
        private int _y2 = new int();
    }


}