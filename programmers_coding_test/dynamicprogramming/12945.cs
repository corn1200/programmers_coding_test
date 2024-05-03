public class Solution
{
    private static int[] memo = new int[]{};
    
    public int solution(int n) {
        int answer = 0;

        memo = new int[n + 1];
        answer = fib(n);
        
        return answer;
    }

    static int fib(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        if (memo[n] != 0)
        {
            return memo[n];
        }

        memo[n] = (fib(n - 1) + fib(n - 2)) % 1234567;
        return memo[n];
    }
}