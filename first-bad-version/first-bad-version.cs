/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        int left = 1, right = n;

        while (left <= right)
        {
            if (left == right)
            {
                return left;
            }
            
            var mid = (int) (((long)left + right) / 2L);

            if (IsBadVersion(mid) is false)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return -1;
    }
}