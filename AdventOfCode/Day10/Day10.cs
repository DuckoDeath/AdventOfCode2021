using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day10
{
    public class Day10
    {
        public static long ExecutePart1(string filename, bool debug = false)
        {
            return DoExecutePart(filename, 1, debug);
        }

        public static long ExecutePart2(string filename, bool debug = false)
        {
            return DoExecutePart(filename, 2, debug);
        }

        private static long DoExecutePart(string filename, int part, bool debug = false)
        {
            Console.WriteLine("Part One");

            var lines = File.ReadAllLines(filename);
            Console.WriteLine("Lines: " + lines.Count());

            var fails = new List<char>();
            var lineNo = 1;
            var good = new List<List<char>>();
            foreach (var l in lines)
            {
                bool wasFail = false;
                var chars = l.ToCharArray().ToList();
                var stack = new List<char>();
                stack.Add(chars[0]);
                Console.WriteLine("Line: " + lineNo++);
                for (int i=1; i<chars.Count;i++)
                {
                    Console.WriteLine(i);
                    var chr = chars[i];
                    if (chr=='(' || chr=='{' || chr=='[' || chr=='<')
                    {
                        stack.Add(chr);
                        continue;
                    }
                    var lastChar = stack[stack.Count - 1];
                    if (chr==')')
                    {
                        if (lastChar=='(')
                        {
                            stack.RemoveAt(stack.Count-1);
                            continue;
                        }
                    } else if (chr=='}')
                    {
                        if (lastChar == '{')
                        {
                            stack.RemoveAt(stack.Count - 1);
                            continue;
                        }
                    }
                    else if (chr == ']')
                    {
                        if (lastChar == '[')
                        {
                            stack.RemoveAt(stack.Count - 1);
                            continue;
                        }
                    }
                    else if (chr == '>')
                    {
                        if (lastChar == '<')
                        {
                            stack.RemoveAt(stack.Count - 1);
                            continue;
                        }
                    }
                    fails.Add(chr);
                    wasFail = true;
                    break;
                }
                if (!wasFail)
                {
                    good.Add(new List<char>(stack));
                }
            }

            var failResult = 0;
            foreach (var f in fails)
            {
                switch (f) {                    
                    case '}':
                        failResult += 1197;
                        break;
                    case ')':
                        failResult += 3;
                        break;
                    case ']':
                        failResult += 57;
                        break;
                    case '>':
                        failResult += 25137;
                        break;
                }
            }

            List<long> scores = new List<long>();
            foreach (var g in good)
            {
                var s = 0L;
                for (int i=g.Count-1;i>=0;i--)
                {
                    s *= 5;
                    var c = g[i];
                    switch (c)
                    {
                        case '(':
                            s += 1;
                            break;
                        case '[':
                            s += 2;
                            break;
                        case '{':
                            s += 3;
                            break;
                        case '<':
                            s += 4;
                            break;
                    }
                }
                scores.Add(s);
            }
            var sortedScores = scores.OrderBy(x=>x).ToList();
            var gResult = sortedScores[sortedScores.Count / 2];
            var result = part==1 ? failResult : gResult;
            Console.WriteLine("Answer: " + result);
            Console.WriteLine();
            return result;
        }

    }
}
