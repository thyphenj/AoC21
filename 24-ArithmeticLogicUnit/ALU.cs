using System;
namespace _24_ArithmeticLogicUnit
{
    public class ALU
    {
        public long[] Vars;
        public int[] instream;
        private int numptr;

        public ALU(int[] nums)
        {
            Vars = new long[4];
            numptr = 0;
            instream = nums;
        }

        public ALU ( long number)
        {
            Vars = new long[4];
            numptr = 0;

            string numAsString = number.ToString();
            instream = new int[numAsString.Length];
            int i = 0;
            foreach ( var ch in numAsString)
            {
                instream[i++] = int.Parse("" + ch);
            }
        }

        public void Process(string str)
        {
            varName ind = varName.W;
            long param = 0;
            string[] tokens = str.Split(' ');

            switch (tokens[1][0])
            {
                case 'w':
                    ind = varName.W;
                    break;
                case 'x':
                    ind = varName.X;
                    break;
                case 'y':
                    ind = varName.Y;
                    break;
                case 'z':
                    ind = varName.Z;
                    break;
            }
            if ( tokens.Length == 3)
            {
                switch (tokens[2][0])
                {
                    case 'w':
                        param = Vars[(int)varName.W];
                        break;
                    case 'x':
                        param = Vars[(int)varName.X];
                        break;
                    case 'y':
                        param = Vars[(int)varName.Y];
                        break;
                    case 'z':
                        param = Vars[(int)varName.Z];
                        break;
                    default:
                        param = int.Parse(tokens[2]);
                        break;
                }
            }
            switch (tokens[0].ToLower())
            {
                case "inp":
                    Inp(ind, instream[numptr++]);
                    break;
                case "add":
                    Add(ind, param);
                    break;
                case "mul":
                    Mul(ind, param);
                    break;
                case "div":
                    Div(ind, param);
                    break;
                case "mod":
                    Mod(ind, param);
                    break;
                case "eql":
                    Eql(ind, param);
                    break;
            }

//            Console.WriteLine($"{str}   {this}");
        }

        public void Inp ( varName var, long val)
        {
            Vars[(int)var] = val;
        }

        public void Add(varName a, long val)
        {
            Vars[(int)a] += val;
        }

        public void Mul(varName a, long val)
        {
            Vars[(int)a] *= val;
        }

        public void Div(varName a, long val)
        {
            Vars[(int)a] /= val;
        }

        public void Mod(varName a, long val)
        {
            Vars[(int)a] %= val;
        }

        public void Eql (varName a, long val)
        {
            Vars[(int)a] = (Vars[(int)a] == val ? 1 : 0);
        }

        public override string ToString()
        {
            return $"{Vars[0]}  {Vars[1]}  {Vars[2]}  {Vars[3]}";
        }
    }
}
