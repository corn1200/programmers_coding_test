using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int solution(int[,] jobs)
    {
        // 작업 초기화 및 요청 시간에 따라 정렬
        var jobList = new List<(int RequestTime, int Duration)>();
        for (int i = 0; i < jobs.GetLength(0); i++)
        {
            jobList.Add((jobs[i, 0], jobs[i, 1]));
        }
        jobList = jobList.OrderBy(job => job.RequestTime).ToList();

        // 작업 시간을 키로 사용하는 SortedList 초기화
        var heap = new SortedList<(int Duration, int Index), int>();
        // 현재 시간
        int currentTime = 0;
        // 총 소요된 시간
        int totalWaitTime = 0;
        // 현재 인덱스
        int index = 0;
        // 작업 고유 인덱스
        int jobIndex = 0;

        // 현재 인덱스가 총작업 갯수보다 작거나 실행할 작업이 남아있는 경우 반복
        while (index < jobList.Count || heap.Count > 0)
        {
            // 현재 시간 이전에 들어온 모든 요청을 힙에 추가
            while (index < jobList.Count && jobList[index].RequestTime <= currentTime)
            {
                // 힙에 작업 추가하고 인덱스 증가
                heap.Add((jobList[index].Duration, jobIndex++), jobList[index].RequestTime);
                index++;
            }

            // 힙에 작업이 있을 경우 실행
            if (heap.Count > 0)
            {
                // 다음 작업을 힙에서 꺼낸다
                var nextJob = heap.First();
                heap.RemoveAt(0);
                
                // 현재 시간에 다음 작업이 걸리는 시간을 추가함
                currentTime += nextJob.Key.Duration;
                // 총 걸린 시간에 현재 시간에서 다음 작업의 시작 시간을 뺌
                totalWaitTime += currentTime - nextJob.Value;
            }
            // 힙에 작업이 없으나 현재 인덱스가 작업 총갯수보다 작을 경우 실행
            else if (index < jobList.Count)
            {
                // 현재 시간을 현재 인덱스 작업의 시작 시간으로 바꾼다
                currentTime = jobList[index].RequestTime;
            }
        }

        // 총 작업 시간의 평균값 반환
        return totalWaitTime / jobList.Count;
    }
}