

namespace Lab_4
{
    public class CNum
    {
        public int _NumA { get; set; }
        public int _NumB { get; set; }


        public CNum() : this(0, 0) { }

        public CNum(int a) : this(a, 0) { }

        public CNum(int a, int b)
        {
            _NumA = a;
            _NumB = b;
        }


        public string Print()
        {
            return $"{_NumA} + {_NumB}i";
        }

        public CNum Add(CNum secondCNum)
        {
            int newA = _NumA + secondCNum._NumA;
            int newB = _NumB + secondCNum._NumB;

            CNum result = new (newA, newB);
            return result;
        }

        public CNum Subt(CNum secondCNum)
        {
            int newA = _NumA - secondCNum._NumA;
            int newB = _NumB - secondCNum._NumB;

            CNum result = new (newA, newB);
            return result;
        }

        public CNum Mult(CNum secondCNum)
        {
            int newA = (_NumA * secondCNum._NumA) - (_NumB * secondCNum._NumB);
            int newB = (_NumA * secondCNum._NumA) + (_NumB * secondCNum._NumB);

            CNum result = new (newA, newB);
            return result;
        }
    }
}
