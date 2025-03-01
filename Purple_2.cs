using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Purple_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _jump;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public double Distance => _jump;
            public int[] Markers
            {
                get
                {
                    if (_marks == null) return null;
                    int[] copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }


            public int Result
            {
                get
                {
                    if (_marks == null) return 0;
                    int summ = 0;
                    int max = _marks[0];
                    int min = _marks[0];
                    for (int i = 0; i < _marks.Length; i++)
                    {

                        summ += _marks[i];
                        if (_marks[i] > max)
                        {
                            max = _marks[i];
                        }
                        if (_marks[i] < min)
                        {
                            min = _marks[i];
                        }
                    }
                    int jump = _jump;
                    summ -= max + min;
                    summ += 60;
                    if (jump > 120)
                    {
                        jump -= 120;
                        summ += jump * 2;
                    }
                    else if (jump < 120)
                    {
                        jump = 120 - jump;
                        summ -= jump * 2;
                    }
                    if (summ < 0)
                        summ = 0;
                    return summ;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                //int i = _name.Length;
                _surname = surname;
                _marks = new int[5];
                _jump = 0; // не сказано про это
                for (int i = 0; i < _marks.Length; i++)
                    _marks[i] = 0;
            }

            public void Jump(int distance, int[] marks)
            {
                if (_marks == null || marks == null || _marks.Length == 0 || distance == null || _marks.Length != marks.Length) return;
                _jump = distance;
                for (int i = 0; i < _marks.Length; i++)
                {
                    _marks[i] = marks[i];
                }
            }

            public static void Sort(Participant[] array)
            {

                if (array == null) return;
                Array.Sort(array, (a, b) =>
                {
                    double x = b.Result - a.Result;
                    if (x < 0) return -1;
                    else if (x > 0) return 1;
                    else return 0;
                });

            }

            public static void Print(Participant[] array)
            {
                foreach (var p1 in array)
                {
                    {
                        Console.WriteLine(p1.Name + " " + p1.Surname + " " + p1.Result);
                    }
                }

            }
        }
    }
}
