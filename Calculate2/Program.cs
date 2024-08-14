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
			expression = "((2+3)*(5+1)-5)+1"; //"(22+33)*77*(55-50/11)";
			//Explore(expression);
			Console.WriteLine(expression);
			Explore(expression);
			Console.WriteLine(expression);
			
			//Console.WriteLine(Calculate(expression));
		}
		static void Explore (string expression)
        {
			for(int i =0; i<expression.Length; i++)
            {

				if (expression[i] == '(')
				{
					for (int j = i + 1; j < expression.Length; j++)
					{
						if (expression[j] == '(') Explore(expression.Substring(j+1, expression.Length - j-1));
						if (expression[j] == ')')
						{
							Program.expression = expression.Replace(expression.Substring(i, j - i + 1),
															Calculate(expression.Substring(i + 1, j - i - 1)).ToString());
							Explore(Program.expression);
						}
					}
				} 

				if (expression[i]==')')
				{
					Program.expression = expression.Replace(expression.Substring(0, i),
															Calculate(expression.Substring(0, i)).ToString());
					Explore(Program.expression);
				}
            }
        }
		static double Calculate(string expression)
		{
			expression = expression.Replace(" ", "").Replace(".",",");
			string[] s_operands = expression.Split('+', '-', '*', '/');
			double[] d_operands = new double[s_operands.Length];
			for (int i = 0; i < s_operands.Length; i++) d_operands[i] = Convert.ToDouble(s_operands[i]);
			//char[] operators = expression.Where(item => "+-*/".Contains(item)).ToArray();
			string[] operators = (expression.Split('0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',')).Where(item=>item!="").ToArray();
			//Print(d_operands);
			//Console.WriteLine();
			//Print(operators);
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
