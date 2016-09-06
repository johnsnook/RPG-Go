namespace RPG_Go
{
    public interface IFileInterface
    {
        void SaveCharacter(CharacterSheet character);

        CharacterSheet LoadCharacter(int id);
    }
}