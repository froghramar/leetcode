public class Solution {
    public IList<IList<string>> Partition(string s)
    {
        if (s.Length == 0)
        {
            return new List<IList<string>> { new List<string>() };
        }

        var result = new List<IList<string>>();
        
        for (var i = 0; i < s.Length; i++)
        {
            var subString = s.Substring(0, i + 1);
            if (IsPalindrome(subString))
            {
                var rightPartitions = Partition(s.Substring(i + 1));

                foreach (var rightPartition in rightPartitions)
                {
                    var newPartition = new List<string> {subString};
                    newPartition.AddRange(rightPartition);
                    result.Add(newPartition);
                }
            }
        }

        return result;
    }

    bool IsPalindrome(string s)
    {
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] != s[s.Length - i - 1])
            {
                return false;
            }
        }

        return true;
    }
}