namespace BeehiveManagementSystem
{
    public class Bee
    {
        public string Job { get; private set; }
        public virtual float CostPerShift { get; }

        public Bee(string job)
        {
            Job = job;
        }

        public void WorkNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift)){
                DoJob();
            }
        }

        public virtual void DoJob() { }
    }
}
