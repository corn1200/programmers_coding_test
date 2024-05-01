using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MusicInfo
{
    public int Index { get; set; }
    public string Genre { get; set; }
    public int Play { get; set; }

    public MusicInfo(int index, string genre, int play)
    {
        Index = index;
        Genre = genre;
        Play = play;
    }
}

public class Solution
{
    public int[] solution(string[] genres, int[] plays)
    {
        List<int> answer = new List<int>();

        List<MusicInfo> musicList = new List<MusicInfo>();

        for (int i = 0; i < genres.Length; i++)
        {
            musicList.Add(new MusicInfo(i, genres[i], plays[i]));
        }

        var query = musicList.GroupBy(m => m.Genre)
            .Select(g => new { genre = g.First().Genre, playSum = g.Sum(x => x.Play) })
            .OrderByDescending(x => x.playSum).ToList();

        foreach (var hitGenre in query)
        {
            var query2 = musicList.Where(m => m.Genre == hitGenre.genre)
                .OrderByDescending(m => m.Play).Take(2);

            foreach (var pick in query2)
            {
                answer.Add(pick.Index);
            }
        }

        return answer.ToArray();
    }
}