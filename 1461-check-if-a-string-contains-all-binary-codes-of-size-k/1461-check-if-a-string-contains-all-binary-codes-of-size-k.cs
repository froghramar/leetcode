public class Solution {
    public bool HasAllCodes(string s, int k) {
        var codes = new HashSet<int>();
        int total = 1 << k, allOnes = total - 1, hashCode = 0;
        
        for (var i = 0; i< s.Length; i++)
        {
            hashCode = ((hashCode << 1) & allOnes) | (s[i] - '0');
            if (i >= k - 1 && codes.Add(hashCode) && codes.Count == total) return true;
        }
        
        return false;
    }
}