namespace RPG_Go
{
    public interface IFileInterface
    {
        void SaveCharacter(Character character);

        Character LoadCharacter(int id);
    }
}