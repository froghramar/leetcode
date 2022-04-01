public class Solution {
    public bool LemonadeChange(int[] bills)
    {
        int fives = 0, tens = 0, twenties = 0;
        foreach (var bill in bills)
        {
            switch (bill)
            {
                case 5:
                    fives++;
                    break;
                
                case 10:
                    if (fives == 0)
                    {
                        return false;
                    }

                    fives--;
                    tens++;
                    break;
                
                case 20:
                    if (tens > 0 && fives > 0)
                    {
                        fives--;
                        tens--;
                        twenties++;
                    }
                    else if (fives > 2)
                    {
                        fives -= 3;
                        twenties++;
                    }
                    else
                    {
                        return false;
                    }
                    
                    break;
            }
        }
        
        return true;
    }
}