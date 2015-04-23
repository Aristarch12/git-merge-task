namespace Kontur.Courses.Git
{
	public class Calculator
	{
		private Maybe<double> lastResult = 0;

		public Maybe<double> Calculate(string[] args)
		{
			if (args.Length == 0)
				return lastResult;
			if (args.Length == 1)
				return lastResult = TryParseDouble(args[0]);
			if (args.Length == 2)
			{
			    var v2 = double.Parse(args[1]);
                return lastResult = Execute(args[0], lastResult.Value, v2);
			}
			if (args.Length == 3)
			{
				var v1 = TryParseDouble(args[0]);
				var v2 = TryParseDouble(args[2]);
				if (!v1.HasValue) return v1;
				if (!v2.HasValue) return v2;
				return lastResult = Execute(args[1], v1.Value, v2.Value);
			}
			return Maybe<double>.FromError("Error input");
		}

		private Maybe<double> TryParseDouble(string s)
		{
			double v;
			if (double.TryParse(s, out v))
				return v;
			return Maybe<double>.FromError("Not a number '{0}'", s);
		}

		private Maybe<double> Execute(string op, double v1, double v2)
		{
			switch (op)
			{
			    case "+":
			        return v1 + v2;
			    case "-":
			        return v1 - v2;
			    case "*":
			        return v1 * v2;
			    case "/":
			        return v1 / v2;
			}
		    return Maybe<double>.FromError("Unknown operation '{0}'", op);
		}
	}
}