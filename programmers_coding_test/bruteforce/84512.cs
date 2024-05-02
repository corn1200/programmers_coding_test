using System;
using System.Collections.Generic;

public class Solution {
    // 알파벳 모음
    char[] words = { 'A', 'E', 'I', 'O', 'U' };
    // 단어 사전
    List<string> results = new List<string>();
    
    public int solution(string word) {
        // 단어 사전 채우기
        GenerateWords("", 0);
        
        // 단어 사전에서 단어 찾아서 몇 번째인지 반환하기
        return results.FindIndex(x => x.Equals(word)) + 1;
    }
    
    // 단어 사전 만드는 함수
    void GenerateWords(string current, int depth)
    {
        // 5글자 이상일 경우 종료
        if (depth > 5)
        {
            return;
        }

        // 현재 단어가 유효할 경우 사전에 추가
        if (!string.IsNullOrEmpty(current))
        {
            results.Add(current);
        }

        // 현재 단어에 단어 사전의 단어 한개씩 추가
        foreach (char word in words)
        {
            GenerateWords(current + word, depth + 1);
        }
    }
}