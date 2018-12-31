using Game.DAO;

namespace Game.SpecialMath
{
    public class Size
    {
        public Size()
        {
            _wd = -1;
            _ht = -1;
        }

        public Size(int width, int height)
        {
            _wd = width;
            _ht = height;
        }

        public Size(Size other)
        {
            _wd = other._wd;
            _ht = other._ht;
        }


        public bool IsNull()
        {
            return _wd == 0 && _ht == 0;
        }

        public bool IsEmpty()
        {
            return _wd < 1 || _ht < 1;
        }

        public bool IsValid()
        {
            return _wd >= 0 && _ht >= 0;
        }


        public int Width()
        {
            return _wd;
        }

        public int Height()
        {
            return _ht;
        }

        public void Resize(int w, int h)
        {
            _wd = w;
            _ht = h;
        }

        public void SetWidth(int w)
        {
            _wd = w;
        }

        public void SetHeight(int h)
        {
            _ht = h;
        }


        public static Size operator -(Size impliedObject)
        {
            return new Size(-impliedObject._wd, -impliedObject._ht);
        }

        public static Size operator +(Size impliedObject, Size other)
        {
            return new Size(impliedObject._wd + other._wd, impliedObject._ht + other._ht);
        }

        public static Size operator -(Size impliedObject, Size other)
        {
            return new Size(impliedObject._wd - other._wd, impliedObject._ht - other._ht);
        }


        public static Size operator *(Size impliedObject, Size other)
        {
            return new Size((int) other._wd * impliedObject._wd, (int) impliedObject._ht * other._ht);
        }

        public static Size operator /(Size impliedObject, Size other)
        {
            return new Size((int) impliedObject._wd / other._wd, (int) impliedObject._ht / other._ht);
        }

        public static Size operator *(Size impliedObject, int v)
        {
            return new Size((int) impliedObject._wd * v, (int) impliedObject._ht * v);
        }


        public static Size operator /(Size impliedObject, int v)
        {
            return new Size((int) impliedObject._wd / v, (int) impliedObject._ht / v);
        }

        public static bool operator <=(Size impliedObject, Size other)
        {
            return impliedObject._wd <= other._wd || impliedObject._ht <= other._ht;
        }

        public static bool operator >=(Size impliedObject, Size other)
        {
            return impliedObject._wd >= other._wd || impliedObject._ht >= other._ht;
        }

        public static bool operator <(Size impliedObject, Size other)
        {
            return impliedObject._wd < other._wd || impliedObject._ht < other._ht;
        }

        public static bool operator >(Size impliedObject, Size other)
        {
            return impliedObject._wd > other._wd || impliedObject._ht > other._ht;
        }

        public Size CopyFrom(Size other)
        {
            _wd = other._wd;
            _ht = other._ht;
            return this;
        }

        public static bool operator ==(Size impliedObject, Size other)
        {
            return other._wd == impliedObject._wd && other._ht == impliedObject._ht;
        }

        public static bool operator !=(Size impliedObject, Size other)
        {
            return other._wd != impliedObject._wd || other._ht != impliedObject._ht;
        }


        public void Scale(Size s, AspectRatioMode mode)
        {
            if (mode == AspectRatioMode.IgnoreAspectRatio || _wd == 0 || _ht == 0)
            {
                _wd = s._wd;
                _ht = s._ht;
            }
            else
            {
                bool useHeight;
                int rw = (s._ht * _wd) / _ht;

                if (mode == AspectRatioMode.KeepAspectRatio)
                    useHeight = (rw <= s._wd);
                else // mode == Fw::KeepAspectRatioByExpanding
                    useHeight = (rw >= s._wd);

                if (useHeight)
                {
                    _wd = rw;
                    _ht = s._ht;
                }
                else
                {
                    _ht = (s._wd * _ht) / _wd;
                    _wd = s._wd;
                }
            }
        }

        public void Scale(int w, int h, AspectRatioMode mode)
        {
            Scale(new Size(w, h), mode);
        }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: float ratio() const
        public float Ratio()
        {
            return (float) _wd / _ht;
        }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: T area() const
        public float Area()
        {
            return _wd * _ht;
        }

        private int _wd = new int();
        private int _ht = new int();


        public Position ToPoint()
        {
            return new Position(_wd, _ht);
        }
    }
}
//C++ TO C# CONVERTER TODO TASK: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>