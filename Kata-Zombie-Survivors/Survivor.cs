namespace Kata_Zombie_Survivors
{
    public class Survivor
    {
        private const uint NbMaxWoundsThatICanReceive = 2;
        private const uint NbMaxActionsPerTurn = 3;

        public Survivor(string name)
        {
            Name = name;
        }

        public void UndergoWounds()
        {
            if (Wounds == NbMaxWoundsThatICanReceive) return;
            Wounds += 1;
            if (Wounds == NbMaxWoundsThatICanReceive)
                State = SurvivorState.Dead;
        }

        public string Name { get; set; }
        public uint Wounds { get; set; } = 0;

        public uint NbActions { get; private set; } = NbMaxActionsPerTurn;

        public SurvivorState State { get; set; } = SurvivorState.Alive;
    }
}