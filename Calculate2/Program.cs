﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate2
{
	class Program
	{
		static string expression;
		static void Main(string[] args)
		{
			expression = "22 +33*77*55-50/11";
			Calculate(expression);
		}
		static double Calculate(string expression)
		{
			expression = expression.Replace(" ", "").Replace(".",",");
			string[] s_operands = expression.Split('+', '-', '*', '/');
			double[] d_operands = new double[s_operands.Length];
			for (int i = 0; i < s_operands.Length; i++) d_operands[i] = Convert.ToDouble(s_operands[i]);
			//char[] operators = expression.Where(item => "+-*/".Contains(item)).ToArray();
			string[] operators = (expression.Split('0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',')).Where(item=>item!="").ToArray();
			for(int i = 0; i<operators.Length;i++)
			{
				if (operators[i] == "*" || operators[i] == "/")
				{
					if (operators[i] == "*") d_operands[i] *= d_operands[i + 1];
					if (operators[i] == "/") d_operands[i] /= d_operands[i + 1];
				}
			}
		

			return d_operands[0];
		}
		static void Print(string[] arr)
		{
			foreach (string item in arr) Console.WriteLine(item);
		}
		static void Print(double[] arr)
		{
			foreach (double item in arr) Console.WriteLine(item);
		}
	}
}
