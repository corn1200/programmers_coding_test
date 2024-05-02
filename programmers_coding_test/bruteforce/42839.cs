using System;
using System.Collections.Generic;

public class Solution {
    // 숫자 조합
    static HashSet<int> numberSet = new HashSet<int>();
    
    public int solution(string numbers) {
        // 숫자 조합 찾기
        FindCombinations(numbers);
        
        // 소수 갯수 반환
        return CountPrimes();
    }

    // 문자열에서 가능한 모든 숫자 조합을 재귀적으로 찾는 함수
    public static void FindCombinations(string digits, string current = "")
    {
        // 현재 문자열이 null이나 비어있지 않을 경우 실행
        if (!string.IsNullOrEmpty(current))
        {
            // 숫자 조합 집합에 현재 문자 추가
            numberSet.Add(Convert.ToInt32(current));
        }

        // 조합 문자 길이만큼 순회
        for (int i = 0; i < digits.Length; i++)
        {
            // 다음 조합 문자로 줄 문자 추출
            string next = digits.Remove(i, 1);
            // 다음 조합 문자와 현재 문자 + 현재 조합 문자를 넘겨준다
            FindCombinations(next, current + digits[i]);
        }
    }
    
    // 소수를 샌다
    static int CountPrimes()
    {
        int count = 0;
        foreach (var i in numberSet)
        {
            // 소수인지 판별하여 카운트를 올린다
            if (IsPrime(i))
            {
                count++;
            }
        }

        return count;
    }

    // 소수 판별
    static bool IsPrime(int num)
    {
        // 2보다 작을 경우 소수가 아니다
        if (num < 2)
        {
            return false;
        }

        // 2의 배수일 경우 실행
        if (num % 2 == 0)
        {
            // 2의 배수는 2일 경우만 소수다
            return num == 2;
        }

        // 해당 숫자가 나누어질 수 있는 찾기
        for (int i = 3; i * i <= num; i += 2)
        {
            if (num % i == 0)
            {
                return false;
            }
        }

        // 나누어지는 수가 없다면 소수다
        return true;
    }
}