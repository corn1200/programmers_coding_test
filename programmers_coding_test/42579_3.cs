using System;
using System.Collections.Generic;

public class Solution
{
    public int[] solution(string[] genres, int[] plays)
    {
        // 답안 리스트
        List<int> answer = new List<int>();
        // 장르별 앨범에 저장할 노래 딕셔너리
        Dictionary<string, PlaySong> streamList = new Dictionary<string, PlaySong>();

        // 장르 배열 순회
        for (int i = 0; i < genres.Length; i++)
        {
            // 앨범에 들어갈 노래에 현재 장르가 있는지 확인
            if (streamList.ContainsKey(genres[i]))
            {
                // 해당 장르에 새로운 음악을 추가함
                streamList[genres[i]].InputList(plays[i], i);
            }
            else
            {
                // 새 장르를 추가하고 음악을 추가한 뒤 앨범에 들어갈 노래에 추가한다
                PlaySong p = new PlaySong();
                p.InputList(plays[i], i);
                streamList.Add(genres[i], p);
            }
        }

        // 장르별 음악들을 리스트화시킨 후 정렬함
        List<PlaySong> playSongs = new List<PlaySong>(streamList.Values);
        playSongs.Sort();

        // 정렬한 장르별 음악을 순회
        for (int i = 0; i < playSongs.Count; i++)
        {
            // 현재 장르의 첫번째 음악을 답안에 추가
            answer.Add(playSongs[i].index1);

            // 만약 두번째 음악이 있을 경우 실행
            if (playSongs[i].index2 != -1)
            {
                // 현재 장르의 두번째 음악을 답안에 추가
                answer.Add(playSongs[i].index2);
            }
        }

        return answer.ToArray();
    }
}

public class PlaySong : IComparable<PlaySong>
{
    // 장르의 총 재생 수
    public int allCount = 0;

    // 첫번째, 두번째 음악의 재생수와 인덱스
    public int count1 = 0;
    public int count2 = 0;
    public int index1 = -1;
    public int index2 = -1;

    // 음악 추가 함수
    public void InputList(int _count, int _index)
    {
        // 새로 추가한 음악의 재생수를 장르의 총 재생수에 추가
        allCount += _count;

        // 새로 추가한 음악이 현재 첫번째 음악보다 재생수가 많거나 같을 경우 실행
        if (_count >= count1)
        {
            // 첫번째 음악을 두번째 음악으로 옮기고, 새로 추가한 음악을 첫번째 음악에 추가
            count2 = count1;
            count1 = _count;
            index2 = index1;
            index1 = _index;
            // 첫번째와 두번째가 재생횟수가 같으나 인덱스가 더 클 경우
            if (count1 == count2 && index1 > index2)
            {
                // 인덱스가 낮은게 앞으로 오도록 교환
                int temp = index2;
                index2 = index1;
                index1 = temp;
            }
        }
        // 새로 추가한 음악이 현재 두번째 음악보다 재생수가 많을 경우 실행
        else if (_count > count2)
        {
            // 새로 추가한 음악을 두번째 음악에 추가한다
            count2 = _count;
            index2 = _index;
        }
        // 새로 추가한 음악이 두번째 음악과 재생수가 같으나 인덱스가 더 낮을 경우
        else if (_count == count2 && index2 > _index)
        {
            // 두번째 음악 인덱스를 새로 추가한 음악의 인덱스로 교체한다
            index2 = _index;
        }
    }

    // 크기 비교 함수
    public int CompareTo(PlaySong other)
    {
        // 장르의 전체 재생수 비교, 내림차순 비교
        return -allCount.CompareTo(other.allCount);
    }
}