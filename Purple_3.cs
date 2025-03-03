using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _position;
            private int _judge;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    double[] copy = new double[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public int[] Places
            {
                get
                {
                    if (_position == null) return null;
                    int[] copy = new int[_position.Length];
                    Array.Copy(_position, copy, _position.Length);
                    return copy;
                }
            }
            
            public int Score
            {
                get
                {
                    if (_position == null) return 0;
                    int estimation = 0;
                    foreach (int i in _position)
                        estimation += i;
                    return estimation;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7]; 
                _position = new int[7]; 
                _judge = 0;
                for (int i = 0; i < _marks.Length; i++)
                    _marks[i] = 0;
                for (int i = 0; i < _position.Length; i++)
                    _position[i] = 0;

            }

            public void Evaluate(double result)
            {
                if (_marks == null || _judge >= _marks.Length) return;
                _marks[_judge] = result;
                _judge++;
                   
            }
            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null) return;
                for (int i = 0; i < 7; i++)
                {
                    Array.Sort(participants, (a, b) =>
                    {
                        double aa = a.Marks != null ? a.Marks[i] : 0;
                        double bb = b.Marks != null ? b.Marks[i] : 0;
                        double x = aa - bb;
                        if (x > 0) return -1;
                        else if (x < 0) return 1;
                        else return 0;
                    });
                    for(int j = 0; j < participants.Length; j++)
                    {
                        participants[j].Method(i, j + 1);
                    }
                }
            }
            private void Method(int i, int j)
            {
                if(_position == null || i < 0 || i >= _position.Length) return;
                _position[i] = j;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null) return;


                Array.Sort(array, (a, b) => {
                    if(a.Score == b.Score)
                    {
                        if(a.Winner == b.Winner)
                        {

                            double x = a.Summm - b.Summm;
                            if (x > 0) return -1;
                            else if (x < 0) return 1;
                            else return 0;
                        }
                        return a.Winner - b.Winner;
                    }
                    return a.Score - b.Score;
                });
            }
            public double Summm
            {
                get
                {
                    if (_marks == null) return 0;
                    double sum = 0;
                    foreach (double i in _marks)
                    {
                        sum += i;
                    }
                    return sum;
                }
            }
            public int Winner
            {
                get
                {
                    if (_position == null) return 0;
                    int mini = 0;
                    for(int i = 0; i < _position.Length; i++)
                    {
                        if (_position[i] < _position[mini])
                        {
                            mini = i;
                        }
                    }
                    return _position[mini];
                }
                
            }
            public static void Print(Participant[] array)
            {
                foreach (var p1 in array)
                {
                    Console.WriteLine(p1.Name + " " + p1.Surname + " " + p1.Score + " " + p1.Winner + " " + p1.Summm);
                }
            }
        }
    }
}
