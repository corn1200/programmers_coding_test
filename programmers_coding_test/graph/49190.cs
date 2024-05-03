using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] arrows) {
        HashSet<(int, int)> vertices = new HashSet<(int, int)>();
        HashSet<((int, int), (int, int))> edges = new HashSet<((int, int), (int, int))>();

        int[] dx = {0, 1, 1, 1, 0, -1, -1, -1};
        int[] dy = {1, 1, 0, -1, -1, -1, 0, 1};

        int x = 0, y = 0;
        vertices.Add((x, y));
        int rooms = 0;

        foreach (var arrow in arrows)
        {
            for (int i = 0; i < 2; i++) // 각 방향으로 두 번 이동
            {
                int nx = x + dx[arrow];
                int ny = y + dy[arrow];

                // 이미 방문한 정점으로 다시 오는 경우 체크
                if (vertices.Contains((nx, ny)))
                {
                    if (!edges.Contains(((x, y), (nx, ny))) && !edges.Contains(((nx, ny), (x, y))))
                    {
                        rooms++;
                    }
                }
                
                // 이동 경로 추가
                edges.Add(((x, y), (nx, ny)));
                edges.Add(((nx, ny), (x, y)));
                x = nx;
                y = ny;
                vertices.Add((x, y));
            }
        }

        return rooms;
    }
}