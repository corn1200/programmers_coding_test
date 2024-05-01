using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int bridge_length, int weight, int[] truck_weights)
    {
        // 답안, 트럭 순서, 다리 무게, 현재 시간
        int answer = 0;
        int truckCount = 0;
        int allWeight = 0;
        int time = 0;
        
        // 다리 큐
        Queue<int> bridge = new Queue<int>();

        while (true)
        {
            // 트럭 갯수만큼 모든 트럭을 옮겼을 경우 실행
            if (truckCount == truck_weights.Length)
            {
                // 반복문 종료
                break;
            }

            // 다리에 있는 트럭 수가 다리 길이랑 같을 경우 실행
            if (bridge.Count == bridge_length)
            {
                // 트럭 하나를 완전히 이동시키고 다리 무게를 감소시킨다
                allWeight -= bridge.Dequeue();
            }

            // 현재 트럭을 다리에 추가할 수 있을 경우 실행
            if (allWeight + truck_weights[truckCount] <= weight)
            {
                // 현재 트럭을 다리에 추가하고 무게를 다리 무게에 추가
                allWeight += truck_weights[truckCount];
                bridge.Enqueue(truck_weights[truckCount]);
                // 다음 트럭을 지정
                truckCount++;
            }
            else
            {
                // 다리에 트럭을 추가할 수 없으므로 트럭을 이동시키기만함
                bridge.Enqueue(0);
            }

            // 시간 더하기
            time++;
        }

        // 반복문을 탈출하기 전까지 시간은 마지막 트럭이 다리를 올라간 시간이다
        // 마지막 트럭의 이동 시간 = 마지막 트럭이 다리를 올라간 시간 + 다리 길이
        answer = time + bridge_length;
        return answer;
    }
}