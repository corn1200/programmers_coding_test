using System;

public class Solution
{
    public int solution(int n, int[] lost, int[] reserve)
    {
        // 학생 배열
        int[] Person = new int[n];

        // 학생 배열에 도난 당하기 전 체육복 추가
        for (int i = 0; i < n; i++)
        {
            Person[i] = 1;
        }

        // 학생 배열에 도난 당한 체육복 반영
        for (int i = 0; i < lost.Length; i++)
        {
            Person[lost[i] - 1]--;
        }

        // 학생 배열에 여벌 체육복 반영
        for (int i = 0; i < reserve.Length; i++)
        {
            Person[reserve[i] - 1]++;
        }

        // 학생 수만큼 순회
        for (int i = 0; i < Person.Length - 1; i++)
        {
            // 만약 현재 학생과 다음 학생의 체육복 갯수 차이가 2일 경우 실행
            if (Math.Abs(Person[i] - Person[i + 1]) == 2)
            {
                // 앞뒤로 체육복을 나눠 가진다
                Person[i] = 1;
                Person[i + 1] = 1;
            }
        }

        // 체육복이 없는 학생 계산하기
        int count = 0;
        for (int i = 0; i < Person.Length; i++)
        {
            if (Person[i] == 0)
            {
                count++;
            }
        }
        
        // 체육 수업을 들을 수 있는 인원 반환
        return Person.Length - count;
    }
}