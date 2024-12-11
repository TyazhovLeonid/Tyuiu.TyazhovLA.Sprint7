namespace Tyuiu.TyazhovLA.Sprint7.Project.V1.Lib
{
    public class DataService
    {
        public string[,] GetData(string path)
        {
            string[] fileData = File.ReadAllText(path).Replace('\n', '\r').Split('\r', StringSplitOptions.RemoveEmptyEntries);

            int rows = fileData.Length;
            int columns = fileData[0].Split(';').Length;

            string [,] data = new string[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                string[] line = fileData[i].Split(";");
                for (int j = 0; j < columns; j++)
                {
                    data[i, j] = line[j];
                }
            }
            return data;
        }
    }
}
