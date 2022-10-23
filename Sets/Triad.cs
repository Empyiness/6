using System;

namespace Sets
{
    public class Triad
    {
        private int[] _triadArray = new int[3];
        public Triad()
        {
            Random random = new Random();
            _triadArray[0] = random.Next(0, 100);
            _triadArray[1] = random.Next(0, 100);
            _triadArray[2] = random.Next(0, 100);
        }

        public Triad(int firstNumber, int secondNumber, int thirdNumber)
        {
            _triadArray[0] = firstNumber;
            _triadArray[1] = secondNumber;
            _triadArray[2] = thirdNumber;
        }

        public int FirstNumber
        {
            get => _triadArray[0];
            private set => _triadArray[0] = value;
        }

        public int SecondNumber
        {
            get => _triadArray[1];
            private set => _triadArray[1] = value;
        }

        public int ThirdNumber
        {
            get => _triadArray[2];
            private set => _triadArray[2] = value;
        }

        public void Add(int number)
        {
            _triadArray[0] += number;
            _triadArray[1] += number;
            _triadArray[2] += number;
        }

        public void Add(Triad triad)
        {
            _triadArray[0] += triad.FirstNumber;
            _triadArray[1] += triad.SecondNumber;
            _triadArray[2] += triad.ThirdNumber;
        }

        public void Multiply(int number)
        {
            _triadArray[0] *= number;
            _triadArray[1] *= number;
            _triadArray[2] *= number;
        }

        public bool Compare(int index1, int index2)
        {
            if (_triadArray[index1 - 1] == _triadArray[index2 - 1])
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return FirstNumber + " " + SecondNumber + " " + ThirdNumber;
        }
        public static Triad operator +(Triad triad, int number)
        {
            return new Triad
            {
                FirstNumber = triad.FirstNumber + number,
                SecondNumber = triad.SecondNumber + number,
                ThirdNumber = triad.ThirdNumber + number
            };
        }

        public static Triad operator +(Triad triad, Triad otherTriad)
        {
            return new Triad
            {
                FirstNumber = triad.FirstNumber + otherTriad.FirstNumber,
                SecondNumber = triad.SecondNumber + otherTriad.SecondNumber,
                ThirdNumber = triad.ThirdNumber + otherTriad.ThirdNumber
            };
        }
    }
}

