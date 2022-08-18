namespace BlackAndWhite.Assets.Scripts.Attack
{
    public static class AttackTypesProvider
    {
        public static AttackType AttackWhite = new(10, AttackColor.White);

        public static AttackType AttackBlack = new(10, AttackColor.Black);

        public static AttackType AttackWhiteCharged = new(50, AttackColor.White);

        public static AttackType AttackBlackCharged = new(50, AttackColor.Black);
    }
}