using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Lab_6
{
    public class Purple_1
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _numberJump;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return null;
                    double[] copy = new double[_coefs.Length];
                    Array.Copy(_coefs, copy, _coefs.Length);
                    return copy;
                }
            }

            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[,] copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public double TotalScore
            {
                get
                {
                    if (_coefs == null || _marks == null) return 0;
                    double summ = 0;
                    for(int i = 0; i < _marks.GetLength(0); i++)
                    {
                        double total = 0;
                        double max = double.MinValue;
                        double min = double.MaxValue;
                        for(int j = 0; j < _marks.GetLength(1); j++)
                        {
                            total += _marks[i, j];
                            if( _marks[i, j] > max)
                            {
                                max = _marks[i, j];
                            }
                            if( _marks[i, j] < min)
                            {
                                min = _marks[i, j];
                            }
                        }
                        total = total - max - min;
                        total *= _coefs[i];
                        summ += total;
                        
                    }
                    return summ;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[4, 7];
                _numberJump = 0;
                for(int i = 0; i < _marks.GetLength(0); i++)
                {
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        _marks[i, j] = 0;
                    }
                }

            }

            public void SetCriterias(double[] coefs)
            {
                if (_coefs == null || coefs == null || coefs.Length != _coefs.Length) return;
                for (int i = 0; i < _coefs.Length; i++) 
                {
                    _coefs[i] = coefs[i];
                }
            }

            public void Jump(int[] marks)
            {
                if(_marks == null || marks == null || _numberJump >= _marks.GetLength(0) || _marks.GetLength(1) != marks.Length) return;
                for(int i = 0; i < marks.Length; i++)
                {
                    _marks[_numberJump, i] = marks[i];
                }
                _numberJump++;
            }

            public static void Sort(Participant[] array)
            {
                if(array == null) return;


                Array.Sort(array, (a, b) => {
                    double x = b.TotalScore - a.TotalScore;
                    if (x < 0) return -1;
                    else if (x > 0) return 1;
                    else return 0;
                });

            }


            public void Print()
            {
                
                Console.WriteLine(Name + " " + Surname + " " + TotalScore);
                
            }
        }
    }
}
