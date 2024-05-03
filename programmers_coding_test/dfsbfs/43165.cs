using System;

public class Solution {
    static int answer = 0;
    
    public int solution(int[] numbers, int target) {
        DFS(0, 0, numbers, target);
        return answer;
    }

    public void DFS(int index, int data, int[] numbers, int target)
    {
        if (index == numbers.Length)
        {
            if (data == target)
            {
                answer++;
            }
            return;
        }

        DFS(index + 1, data + numbers[index], numbers, target);
        DFS(index + 1, data - numbers[index], numbers, target);
    }
}