using System;

public class Solution {
    public long solution(int n, int[] times) {
        // 심사관을 심사 소요 시간 순으로 정렬
        Array.Sort(times);
        // 가능한 최소 시간, 가장 빠른 경우 1초 동안 처리할 수 있다고 가정
        long left = 1;
        // 가능한 최대 시간, 가장 오래 걸리는 심사관이 모든 사람을 처리하는 시간이 최악의 경우다
        long right = (long)times[times.Length - 1] * n;
        // 최소 심사 시간을 저장, 초기 값은 최대 시간이다
        long answer = right;

        // 이진 탐색은 최소 시간이 최대 시간보다 작거나 같은 동안 계속 된다
        while (left <= right)
        {
            // 사용 가능한 심사시간
            long mid = (left + right) / 2;
            
            // mid 시간 동안 처리 가능한 인원
            long count = 0;

            // 각 심사관마다 mid 시간 동안 처리할 수 있는 인원 수를 모두 합친다
            foreach (int time in times)
            {
                // mid 시간 동안 처리 가능한 인원을 전부 합하고 모든 인원보다 많을 경우 반복 종료
                count += mid / time;
                if (count >= n) break;
            }

            // 처리할 수 있는 인원 수에 따라 탐색 범위 조정
            // mid 시간으로 처리할 수 있는 인원이 전체 인원보다 많을 경우
            if (count >= n)
            {
                // 답을 mid로 갱신함
                answer = mid;
                // 최대 시간을 mid - 1로 좁히고 재검색
                right = mid - 1;
            }
            // mid 시간으로 처리할 수 있는 인원이 전체 인원 미달일 경우
            else
            {
                // 최소 시간을 mid + 1로 좁히고 재검색
                left = mid + 1;
            }
        }

        return answer;
    }
}