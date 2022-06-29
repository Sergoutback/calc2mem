using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System.Linq;
namespace CalculatorUI
{

    public class Percent : MonoBehaviour
    {
        public string ParsePercent(string expression)
        {
            var list = SplitAndKeep(expression, expression.Where(x => x != '%' && !char.IsDigit(x)).ToArray()).ToList();

            if (list.Count > 0 && list[0].Contains('%'))
            {
                list[0] = list[0].Replace("%", "");
            }

            for (int i = 1; i < list.Count; i++)
            {
                if (!char.IsDigit(list[i][0]))
                    continue;

                if (list[i].Contains('%'))
                {
                    list[i] = (int.Parse(list[i - 2]) * int.Parse(list[i].Replace("%", "")) / 100).ToString();
                }
            }
            return string.Join("", list);
        }

        public static IEnumerable<string> SplitAndKeep(string s, char[] delims)
        {
            int start = 0, index;

            while ((index = s.IndexOfAny(delims, start)) != -1)
            {
                if (index - start > 0)
                    yield return s.Substring(start, index - start);
                yield return s.Substring(index, 1);
                start = index + 1;
            }

            if (start < s.Length)
            {
                yield return s.Substring(start);
            }
        }
    }
}