namespace BeehiveManagementSystem
{
    public class Queen : Bee
    {
        private const float EGGS_PER_SHIFT = 0.45f;
        private const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

        private Bee[] workers = new Bee[0];
        private float eggs = 0;
        private float unassignedWorkers = 3;

        public string StatusReport { get; private set; }
        public override float CostPerShift { get { return 2.15f; } }

        public Queen() : base("Queen")
        {
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");
            AssignBee("Egg Care");
        }

        public override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;

            foreach(Bee worker in workers)
            {
                worker.WorkNextShift();
            }

            HoneyVault.ConsumeHoney(unassignedWorkers * HONEY_PER_UNASSIGNED_WORKER);

            UpdateStatusReport();
        }

        public void AssignBee(string job)
        {
            switch (job)
            {
                case "Nectar Collector":
                    AddWorker(new NectarCollector());
                    break;

                case "Honey Manufacturer":
                    AddWorker(new HoneyManufacturer());
                    break;

                case "Egg Care":
                    AddWorker(new EggCare(this));
                    break;
            }

            UpdateStatusReport();
        }

        public void AddWorker(Bee worker)
        {
            if(unassignedWorkers >= 1)
            {
                unassignedWorkers--; ;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }

        public void CareForEggs(float eggsToConvert)
        {
            if(eggs > eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }

        private void UpdateStatusReport()
        {
            StatusReport = $"Vault report:\n{HoneyVault.StatusReport}\n" +
                $"Egg count: {eggs:0.00}\n" +
                $"Unassigned workers: {unassignedWorkers:0.00}\n" +
                $"{WorkerStatus("Nectar Collector")}\n" +
                $"{WorkerStatus("Honey Manufacturer")}\n" +
                $"{WorkerStatus("Egg Care")}\n" +
                $"TOTAL WORKERS: {workers.Length}";
        }

        private string WorkerStatus(string job)
        {
            int count = 0;

            foreach(Bee worker in workers)
            {
                if(worker.Job == job)
                {
                    count++;
                }
            }

            string plural;

            if(count == 1)
            {
                plural = "";
            }
            else
            {
                plural = "s";
            }

            return $"{count} {job} {plural}";
        }
    }
}
