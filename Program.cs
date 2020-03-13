using System;
using System.Collections.Generic;

namespace FindPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] wordsArray =new string[][]
            {
                new string[] { "start", "stop", "station" },
                new string[] {"ran", "rantime"},
                new string[] {"begin" },
                new string[] { "start", "stop", "station", " " },
                new string[] { "bardsdsda", "bardssdfadf", "bardsstation", "bardsjdhjdf" }
            };


            foreach (var words in wordsArray)
            {
                Console.WriteLine("words: " + string.Join(" || ", words));
                Console.WriteLine("prefix: " + FindPrefix(words) + "\n");
            }
            Console.ReadLine();
        }

        static string FindPrefix(string[] words)
        {
            var prefix = words[0].ToCharArray();
            for (int i = 1; i < words.Length; i++)
            {
                //для каждогослова находится общая часть с последним
                //префиксом и записывается в currentPrefix
                var currentPrefix = new List<char>();
                var word = words[i].ToCharArray();

                //префикс, то есть общая часть последнего найденного префикса и
                //сравниваемого слова, не может быть больше чем самое короткое из них
                for (int j = 0; j < Math.Min(prefix.Length, word.Length); j++)
                {
                    //сравнивая каждое слово посимвольно с предыдущим префиксом
                    //мы создаем новый, добавляя в список символов совпавшие символы
                    //пока они одинаковы
                    if (prefix[j] == word[j])
                    {
                        currentPrefix.Add(prefix[j]);
                        continue;
                    }
                    break;
                }
                prefix = currentPrefix.ToArray();
                //если длина префикса = 0, то в словах нет общего префикса
                if (prefix.Length == 0) return "";
            }
            return new string(prefix);
        }
    }
}
