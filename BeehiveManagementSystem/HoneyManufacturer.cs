namespace BeehiveManagementSystem
{
    public class HoneyManufacturer : Bee
    {
        private const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;

        public override float CostPerShift { get { return 1.7f; } }

        public HoneyManufacturer() : base("Honey Manufacturer") { }

        public override void DoJob()
        {
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }
    }
}
