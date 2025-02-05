namespace TextRPG;

public static class Global
{
    public static GameIntro GameIntro = new GameIntro();
}

public static class GameState
{
    // 전역적으로 Player 객체를 하나만 생성하여 사용
    public static Player CurrentPlayer { get; set; }
}
