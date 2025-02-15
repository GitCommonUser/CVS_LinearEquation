﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_Equation
{
    public class LinearEquation
    {
        List<float> coefficients = new List<float>();
        public int Size => coefficients.Count;

        /// <summary>
        /// Конструирует уравнение вида aN*x + coefficients[0]y + ... + coefficients[N-2]z + coefficients[N-1] = 0
        /// </summary>
        /// 
        /// Примеры:
        /// <example>
        /// LinearEquation(1,2,3,4) => 1x + 2y + 3z + 4 = 0
        /// LinearEquation(1,2) => 1x + 2 = 0
        /// LinearEquation(1) => 1 = 0 (не имеет решений)
        /// </example>
        /// 
        /// <param name="aN">Последний коэффициент</param>
        /// <param name="coefficients">Остальные коэффициенты</param>
        public LinearEquation(params float[] coefficients)
        {
            this.coefficients.AddRange(coefficients);
        }
        public LinearEquation(List<float> coefficients)
        {
            this.coefficients = coefficients;
        }

        /// <summary>
        /// Суммирует свободный член first с second
        /// </summary>
        static public LinearEquation operator +(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            int lastCoef = equation.coefficients.Count - 1;
            equation.coefficients[lastCoef] += second;
            return equation;
        }
        /// <summary>
        /// Вычитает second из свободного члена first
        /// </summary>
        static public LinearEquation operator -(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            int lastCoef = equation.coefficients.Count - 1;
            equation.coefficients[lastCoef] -= second;
            return equation;
        }
        public override bool Equals(object obj)
        {
            if (obj is LinearEquation equation)
            {
                if (Size != equation.Size)
                    return false;
                for (int i = 0; i < Size; i++)
                {
                    if (this.coefficients[i] != equation.coefficients[i])
                        return false;
                }
                return true;
            }
            return false;
        }
        static public bool operator ==(LinearEquation first, LinearEquation second)
        {
            return first.Equals(second);
        }
        static public bool operator !=(LinearEquation first, LinearEquation second)
        {
            return !first.Equals(second);
        }
        public float this[int i]
        {
            get { return coefficients[i]; }
        }
        static public LinearEquation operator -(LinearEquation first,LinearEquation second)
        {
            if (first.Size != second.Size)
                throw new IndexOutOfRangeException("Разная размерность");
            List<float> result = new List<float>();
            for (int i = 0; i < second.Size; i++)
            {
                result.Add(first[i] - second[i]);
            }
            return new LinearEquation(result);
        }
        static public LinearEquation operator +(LinearEquation first, LinearEquation second)
        {
            if (first.Size != second.Size)
                throw new IndexOutOfRangeException("Разная размерность");
            List<float> result = new List<float>();
            for (int i = 0; i < second.Size; i++)
            {
                result.Add(first[i] + second[i]);
            }
            return new LinearEquation(result);
        }
        static public implicit operator bool(LinearEquation first)
        {
            int lastCoef = first.Size - 1;
            if (first[lastCoef] == 0)
                return true;
            else
            {
                for(int i = 0; i < lastCoef; i++)
                {
                    if (first[i] != 0)
                        return true;
                }
                return false;
            }
        }
        public float? GetSolution(LinearEquation first)
        {
            if(first.Size > 2)
                throw new IndexOutOfRangeException("Уравнение имеет более 1 неизвестной");
            if (first[0] == 0)
            {
                return null;
            }
            else
            {
                float solution = -1 *first[1]/ first[0];
                return solution;
            }
        }
        public string EquationToString(LinearEquation first)
        {
            string names = "xyzabcdefghijklmn";
            string equation = "";
            for(int i = 0; i < first.Size - 1; i++)
            {
                equation += first[i].ToString() + names[i] + " + ";
            }
            equation += first[first.Size - 1].ToString() + " = 0";
            return equation;
        }
        public void InitializeRandom(LinearEquation first)
        {
            Random rand = new Random();
            for(int i = 0; i < first.Size; i++)
            {
                first.coefficients[i] = rand.Next(-1000, 1000);
            }
        }
        public void InitializeSame(LinearEquation first, int a)
        {
            for(int i = 0; i < first.Size; i++)
            {
                first.coefficients[i] = a;
            }
        }
        public void Multiplication(LinearEquation first, int a)
        {
            for (int i = 0; i < first.Size; i++)
            {
                first.coefficients[i] *= a;
            }
        }
    }
}
