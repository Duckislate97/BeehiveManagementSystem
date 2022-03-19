namespace BeehiveManagementSystem
{
    public class NectarCollector : Bee
    {
        private const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;

        public override float CostPerShift { get { return 1.95f; } }

        public NectarCollector() : base("Nectar Collector") { }

        public override void DoJob()
        {
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
        }
    }
}
