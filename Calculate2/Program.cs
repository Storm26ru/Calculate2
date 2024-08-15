using System;
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
			expression = "((22+33)*77)*((55-50)/11)";
			Console.WriteLine(expression);
			Console.WriteLine(Explore(expression));
			Console.WriteLine(Calculate(Explore(expression)));
		}
		static string Explore (string expression)
        {
			int num=0;
			while (expression.Contains("("))
			{ for (int i = 0; i < expression.Length; i++)
				{
					if (expression[i] == '(') num = i;
					if (expression[i] == ')')
					{
						if (num !=-1)
						{
							expression = expression.Replace(expression.Substring(num, i - num + 1),
												Calculate(expression.Substring(num + 1, i - num - 1)).ToString());
							num = -1;
						}
					}

				}
			}
			return expression;
        }
		static double Calculate(string expression)
		{
			expression = expression.Replace(" ", "").Replace(".",",");
			string[] s_operands = expression.Split('+', '-', '*', '/');
			double[] d_operands = new double[s_operands.Length];
			for (int i = 0; i < s_operands.Length; i++) d_operands[i] = Convert.ToDouble(s_operands[i]);
			string[] operators = (expression.Split('0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',')).Where(item=>item!="").ToArray();
			for(int i = 0; i<operators.Length;i++)
			{
				while (operators[i] == "*" || operators[i] == "/")
				{
					if (operators[i] == "*") d_operands[i] *= d_operands[i + 1];
					if (operators[i] == "/") d_operands[i] /= d_operands[i + 1];
					ShiftLeft(d_operands, i + 1);
					ShiftLeft(operators, i);
				}
			}
			for (int i = 0; i < operators.Length; i++)
			{
				while (operators[i] == "+" || operators[i] == "-")
				{
					if (operators[i] == "+") d_operands[i] += d_operands[i + 1];
					if (operators[i] == "-") d_operands[i] -= d_operands[i + 1];
					ShiftLeft(d_operands, i + 1);
					ShiftLeft(operators, i);
				}
			}


			return d_operands[0];
		}
		static void ShiftLeft(double[]arr,int index= 0)
		{
			for (int i = index; i < arr.Length-1; i++) arr[i] = arr[i + 1];
			arr[arr.Length - 1] = 0;
		}
		static void ShiftLeft(string[] arr, int index = 0)
		{
			for (int i = index; i < arr.Length-1; i++) arr[i] = arr[i + 1];
			arr[arr.Length - 1] = "\0";
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