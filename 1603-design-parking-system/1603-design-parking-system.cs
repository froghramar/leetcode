public class ParkingSystem {
    private readonly int[] _count;

    public ParkingSystem(int big, int medium, int small)
    {
        _count = new[] { big, medium, small };
    }
    
    public bool AddCar(int carType) {
        if (_count[carType - 1] == 0)
        {
            return false;
        }

        _count[carType - 1]--;
        return true;
    }
}