namespace BeehiveManagementSystem
{
    static class HoneyVault
    {
        private const float NECTAR_CONVERSION_RATIO = 0.19f;
        private const float LOW_LEVEL_WARNING = 10f;

        private static float honey = 25f;
        private static float nectar = 100f;

        public static string StatusReport
        {
            get
            {
                string status = $"{honey:0.00} units of honey\n" +
                                $"{nectar:0.00} units of nectar\n";

                string warnings = "";

                if(honey < LOW_LEVEL_WARNING)
                {
                    warnings += "LOW HONEY - ADD HONEY MANUFACTURER\n";
                }

                if(nectar < LOW_LEVEL_WARNING)
                {
                    warnings += "LOW NECTAR - ADD NECTAR COLLECTOR";
                }

                return status + warnings;
            }
        }

        public static void CollectNectar(float amount)
        {
            nectar += amount;
        }

        public static void ConvertNectarToHoney(float amount)
        {
            if(nectar >= amount)
            {
                nectar -= amount;
                honey += amount * NECTAR_CONVERSION_RATIO;
            }
            else
            {
                honey += nectar * NECTAR_CONVERSION_RATIO;
                nectar = 0;
            }
        }

        public static bool ConsumeHoney(float amount)
        {
            if(honey >= amount)
            {
                honey -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
