namespace RPG_Go
{
    public class Armor : Item
    {
        public enum ArmorTypes
        {
            Heavy, Medium, Light
        }

        public ArmorTypes Type;

        public void Wear(string Effect)
        {
        }

        public void PutAway()
        {
        }
    }
}