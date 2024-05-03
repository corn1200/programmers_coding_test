using System;
using System.Collections.Generic;

public class Solution
{
    public int solution(string begin, string target, string[] words)
    {
        if (Array.IndexOf(words, target) < 0)
        {
            return 0;
        }

        bool[] visited = new bool[words.Length];
        Queue<(string, int)> queue = new Queue<(string, int)>();

        queue.Enqueue((begin, 0));

        while (queue.Count > 0)
        {
            var (currentWord, currentCount) = queue.Dequeue();

            if (currentWord.Equals(target))
            {
                return currentCount;
            }

            for (int i = 0; i < words.Length; i++)
            {
                if (WordUnmatch(currentWord, words[i]) > 1)
                {
                    continue;
                }
                
                if (!visited[i])
                {
                    visited[i] = true;
                    queue.Enqueue((words[i], currentCount + 1));
                }
            }
        }

        return 0;
    }

    public static int WordUnmatch(string target, string compare)
    {
        int wordUnmatch = 0;
        
        for (int j = 0; j < target.Length; j++)
        {
            if (target[j] != compare[j])
            {
                wordUnmatch++;
            }
        }

        return wordUnmatch;
    }
}