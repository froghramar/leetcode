public class Solution {
    public IList<int> PartitionLabels(string s)
    {
        var first = new int[26];
        var last = new int[26];

        for (var i = 0; i < 26; i++)
        {
            first[i] = int.MaxValue;
            last[i] = int.MinValue;
        }

        for (var i = 0; i < s.Length; i++)
        {
            var id = s[i] - 'a';
            first[id] = Math.Min(first[id], i);
            last[id] = Math.Max(last[id], i);
        }

        var partitions = new List<int>();
        var lastPartition = 0;
        for (var i = 0; i < s.Length; i++)
        {
            var id = s[i] - 'a';
            if (i != last[id])
            {
                continue;
            }

            var partitionPossible = true;
            for (var j = 0; j < 26; j++)
            {
                if (first[j] == int.MaxValue)
                {
                    continue;
                }

                if (first[j] < i && last[j] > i)
                {
                    partitionPossible = false;
                    break;
                }
            }

            if (partitionPossible)
            {
                partitions.Add(i + 1 - lastPartition);
                lastPartition = i + 1;
            }
        }

        return partitions;
    }
}