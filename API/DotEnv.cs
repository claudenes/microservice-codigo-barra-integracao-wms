namespace API
{
    public class DotEnv
    {
        public static void Load(string filePath)
        {
            var exists = File.Exists(filePath);
            if (!exists)
                return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(
                    '=', 2);

                if (parts.Length != 2)
                    continue;

                if (Environment.GetEnvironmentVariable(parts[0]) == null)
                    Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }
    }
}
