using System;

public class Solution {
    public int solution(string name)
    {
        // 총 조작 횟수
        int totalMoves = 0;
        // 만들어야 하는 이름의 길이
        int length = name.Length;
        // 최소 이동은 처음부터 끝까지 가는 것으로 초기 설정
        int minMove = length - 1;

        // 이름 길이만큼 순회
        for (int i = 0; i < length; i++)
        {
            // 각 문자에 대해 'A'에서 최소 조작 횟수를 계산
            totalMoves += Math.Min(name[i] - 'A', 'Z' - name[i] + 1);

            // 다음 문자가 'A'인지 확인하고 연속된 'A'들을 스킵하는 최적의 이동 계산
            int nextIndex = i + 1;
            while (nextIndex < length && name[nextIndex] == 'A')
            {
                nextIndex++;
            }

            // 현재 위치에서 뒤로 다시 돌아가는 것과 뒤쪽의 'A'를 스킵하고 다시 돌아오는 것을 비교
            minMove = Math.Min(minMove, i + length - nextIndex + Math.Min(i, length - nextIndex));
        }

        return totalMoves + minMove;
    }
}