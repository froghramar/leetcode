public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        int newFlowers = 0, emptyCount = 0;
        var flowered = false;
        for (var i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] == 0)
            {
                emptyCount++;
            }
            else
            {
                if (flowered is false)
                {
                    newFlowers = i / 2;
                }
                else
                {
                    newFlowers += (emptyCount - 1) / 2;
                }

                emptyCount = 0;
                flowered = true;
            }
        }

        if (flowered is false)
        {
            newFlowers = (emptyCount + 1) / 2;
        }
        else
        {
            newFlowers += emptyCount / 2;
        }

        return newFlowers >= n;
    }
}