using System;
using System.Text;
using System.Linq;

public class Solution {
    public string solution(int[] numbers) {
        // 입력된 정수 배열을 문자열로 저장하기 위해 문자열 배열 생성
        string[] numberStr = new string[numbers.Length];

        // for문을 통해 각 숫자들을 문자열로 변환하여 저장
        for (int i = 0; i < numberStr.Length; i++)
        {
            numberStr[i] = numbers[i].ToString();
        }
        
        // 배열을 내림차순으로 정렬, 정렬 기준은 두 문자열을 이어 붙인 결과의 대소 비교
        // y + x와 x + y를 비교해 정렬
        Array.Sort(numberStr, (x, y) => String.CompareOrdinal(y + x, x + y));

        // 문자열을 효율적으로 처리하기 위해 StringBuilder 생성
        StringBuilder sb = new StringBuilder();

        // for문을 통해 정렬된 문자열을 sb에 추가
        for (int i = 0; i < numberStr.Length; i++)
        {
            sb.Append(numberStr[i]);
        }

        // sb에 저장된 문자열을 최종적인 결과 문자열로 변환
        string resultNum = sb.ToString();

        // 만약 결과 문자열에 0이 아닌 숫자가 존재할 경우 resultNum 반환
        if (resultNum.Any(match => match != '0'))
        {
            return resultNum;
        }
        
        return "0";
    }
}