public class Solution {
    public int CompareVersion(string version1, string version2)
    {
        var revisions1 = version1.Split('.');
        var revisions2 = version2.Split('.');

        for (var i = 0; i < revisions1.Length || i < revisions2.Length ; i++)
        {
            var r1 = GetRevision(revisions1, i);
            var r2 = GetRevision(revisions2, i);

            if (r1 < r2)
            {
                return -1;
            }

            if (r1 > r2)
            {
                return 1;
            }
        }

        return 0;
    }

    private static int GetRevision(string[] version, int i)
    {
        return i >= version.Length ? 0 : int.Parse(version[i]);
    }
}