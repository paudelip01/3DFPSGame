
[System.Serializable]
public class  Player
{
    int highScore;
    int coins;

    bool gun1;
    bool gun2;
    bool gun3;
    bool gun4;
    public Player(int hs,int totalCoins,bool g1, bool g2, bool g3, bool g4){
        gun1 = g1;
        gun2 = g2;
        gun3 = g3;
        gun4 = g4;
        highScore = hs;
        coins = totalCoins;
    }

    public bool Gun1()
    {
        return gun1;
    }
    public bool Gun2()
    {
        return gun2;
    }

    public bool Gun3()
    {
        return gun3;
    }

    public bool Gun4()
    {
        return gun4;
    }

    public int HighSco(){
        return highScore;
    }
    public int TotalCoins(){
        return coins;
    }
}