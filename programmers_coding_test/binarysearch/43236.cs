using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int distance, int[] rocks, int n) {
        // 지점 순서대로 바위 정렬
        Array.Sort(rocks);
        // 바위를 리스트로 변환
        List<int> rockList = rocks.ToList();
        // 도착 지점을 바위 리스트에 추가
        rockList.Add(distance);
        
        // 왼쪽, 오른쪽, 중앙 값
        int left = 0;
        int right = distance;
        int mid = 0;
        
        // 왼쪽이 오른쪽보다 작거나 같을 때까지만 반복
        while (left <= right)
        {
            // mid = 거리의 최솟값
            mid = (left + right) / 2; 
            
            // 제거한 돌 갯수
            int deletedRockCount = 0;
            // 이전 바위
            int prevRock = 0;
            
            // 돌 리스트 순회
            foreach (int rock in rockList)
            {
                // 두 바위 사이가 지정한 최소보다 작은경우
                if (rock - prevRock < mid)
                {
                    // 해당 rock 제거 (즉, prevRock은 유지)
                    deletedRockCount += 1;
                }
                else
                {
                    // 돌을 제거 안한 경우 다음 바위로 넘어감
                    prevRock = rock;
                }

                // 돌 제거 최대에 도달할 경우 순회 종료
                if (deletedRockCount > n)
                {
                    break;
                }
            }
            
            // 돌을 최대 갯수 초과로 제거한 경우 right를 mid - 1로 좁힙
            if (deletedRockCount > n)
            {
                right = mid - 1;
            }
            // 돌을 최대 갯수 이하로 제거한 경우 left를 mid + 1로 좁힙
            else
            {
                left = mid + 1;
            }
        }
        return left - 1;
    }
}