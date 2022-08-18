namespace BlackAndWhite.Assets.Scripts.Attack
{
    public enum AttackColor { Black, White }


    public class AttackType
    {
        public int Damage { get; set; }

        public AttackColor AttackColor { get; set; }


        public AttackType(int damage, AttackColor attackColor)
        {
            Damage = damage;
            AttackColor = attackColor;
        }
    }
}