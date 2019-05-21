namespace Kata_Zombie_Survivors
{
    public class Survivor
    {
        public Survivor(string name)
        {
            Name = name;
        }
        
        public string Name { get; set; }
        public uint Wounds { get; set; } = 0;

        public SurvivorState State { get; set; } = SurvivorState.Alive;
    }
}