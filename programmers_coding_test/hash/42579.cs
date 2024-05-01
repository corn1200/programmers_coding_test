using System;
using System.Collections.Generic;

public class Solution
{
    class PlaySong : IComparable<PlaySong>
    {
        public int id;
        public string gneres;
        public int plays;

        public PlaySong(int id, string gneres, int plays)
        {
            this.id = id;
            this.gneres = gneres;
            this.plays = plays;
        }

        public int CompareTo(PlaySong other)
        {
            if (genresCount[gneres] == genresCount[other.gneres])
            {
                return other.plays.CompareTo(plays);
            }

            return genresCount[other.gneres].CompareTo(genresCount[gneres]);
        }
    }

    static Dictionary<string, int> genresCount = new Dictionary<string, int>();

    public int[] solution(string[] genres, int[] plays)
    {
        List<int> answer = new List<int>();
        SortedSet<PlaySong> priorityQueue = new SortedSet<PlaySong>();

        for (int i = 0; i < genres.Length; i++)
        {
            if (genresCount.ContainsKey(genres[i]))
            {
                genresCount[genres[i]] += plays[i];
            }
            else
            {
                genresCount[genres[i]] = plays[i];
            }
        }

        for (int i = 0; i < plays.Length; i++)
        {
            priorityQueue.Add(new PlaySong(i, genres[i], plays[i]));
        }

        Dictionary<string, int> genreAlbumCount = new Dictionary<string, int>();
        
        foreach (var playSong in priorityQueue)
        {
            if (genreAlbumCount.ContainsKey(playSong.gneres))
            {
                if (genreAlbumCount[playSong.gneres] > 1)
                {
                    continue;
                }
                genreAlbumCount[playSong.gneres]++;
            }
            else
            {
                genreAlbumCount[playSong.gneres] = 1;
            }
            answer.Add(playSong.id);
        }

        return answer.ToArray();
    }
}