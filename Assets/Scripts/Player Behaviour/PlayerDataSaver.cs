public class PlayerDataSaver
{
    public double Hp;
    public double Hunger;
    public int MoneyCount;
    public int FoodCount;

    public PlayerDataSaver(PlayerParameters parameters)
    {
        Hp = parameters.playerLiveBehaviour.HealtPoints;
        Hunger = parameters.playerLiveBehaviour.Hunger;
        MoneyCount = parameters.moneyCount;
        FoodCount = parameters.foodCount;
    }
}