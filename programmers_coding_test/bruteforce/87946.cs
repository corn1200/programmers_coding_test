using System;

public class Solution
{
    // 던전 방문 여부
    public bool[] visit;
    // 최대 던전 방문 횟수
    public int answer = 0;

    public int solution(int k, int[,] dungeons)
    {
        // 던전 방문 여부 배열 초기화
        visit = new bool[dungeons.Length];
        
        // 던전 방문 시작
        VisitDungeons(k, dungeons, 0);
        
        return answer;
    }

    // 던전 방문 함수
    public void VisitDungeons(int k, int[,] dungeons, int cnt)
    {
        // 던전 갯수만큼 반복
        for (int i = 0; i < dungeons.GetLength(0); i++)
        {
            // 현재 피로도가 최소 필요 피로도 이상이고, 아직 방문하지 않은 던전일 경우 실행 
            if (k >= dungeons[i, 0] && !visit[i])
            {
                // 던전 방문한 것으로 체크
                visit[i] = true;
                // 피로도를 사용하고 다음 던전으로 이동
                VisitDungeons(k - dungeons[i, 1], dungeons, cnt + 1);
                // 현재 던전을 방문하고 나면 다시 미방문으로 바꿈
                visit[i] = false;
            }
        }

        // 던전 방문 횟수가 더 많을 경우 답안 업데이트
        answer = Math.Max(cnt, answer);
    }
}